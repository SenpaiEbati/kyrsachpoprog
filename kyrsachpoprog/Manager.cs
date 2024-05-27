using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsachpoprog
{
    // Класс менеджера
    class Manager
    {
        // Список очередей
        private List<QueuePatient> QueuesPatient = new List<QueuePatient>();
        // Список докторов
        private List<Doctor> Doctors = new List<Doctor>();
        // Список фактов приема
        private List<LogItem> LogList = new List<LogItem>();
        // Генератор случайных чисел
        private Random Rnd = new Random();
        // Визуалные компоненты для вывода в LogPatients_TB и Stat_TB
        private TextBox _LogPatient_TB, _Stat_TB;
        // Поля для параметров генерации
        private int _Chance = 2;
        private int _CountPatient = 1;
        // Конструктор класса
        public Manager(TextBox LogPatient_TB, TextBox Stat_TB)
        {
            _LogPatient_TB = LogPatient_TB;
            _Stat_TB = Stat_TB;
        }

        public Manager() : this(null, null) { }

        public int Chance
        {
            set { if (value >= 1 && value <= 5) _Chance = value; }
        }

        public int CountPatient
        {
            set { if (value >= 1 && value <= 3) _CountPatient = value; }
        }
        // Событие поступления пациента в поликлинику
        private event EventHandler<PatientArgs> NewPatientEvent;
        // Активатор события "Новый пациент"
        private void OnNewPatient()
        {
            // Cоздание параметров
            PatientArgs E = new PatientArgs();
            // Создание нового пациента
            E.Sick = new Patient();
            
            E.PrintResult = PrintResult;
            // Активация события
            if (NewPatientEvent != null)
                NewPatientEvent(this, E);
            // Если автомобиль существует,
            // то ни одна из очередей его не разместила у себя
            if (E.Sick != null)
                PrintResult("Не найдена подходящая очередь, <" + E.Sick + "> покинул поликлинику");

        }
        // Событие Шаг
        private event EventHandler<LogArgs> RunTimeEvent;
        // Активатор события шаг
        private void OnRunTime()
        {
            if (RunTimeEvent != null)
            {
                LogArgs E = new LogArgs();
                E.PrintResult = PrintResult;
                E.PrintLog = PrintLog;
                // Передаем актуальный список очередей
                E.Queues = QueuesPatient;
                // Передаем актуальный список докторов
                E.Doctors = Doctors;
                // Активация события
                RunTimeEvent(this, E);
            }
        }
        // Метод для отображения выполненого действия
        private void PrintResult(string s)
        {
            if (_LogPatient_TB != null)
                _LogPatient_TB.AppendText(s + Environment.NewLine);
        }
        // Метод для фиксации факта приема
        private void PrintLog(LogItem Item)
        {
            LogList.Add(Item);
        }
        // Метод для генерации события шаг и события нового пациента
        public void OnTimer()
        {
            _LogPatient_TB.Clear();
            OnRunTime();
            if (Rnd.Next(_Chance) == 0)
            {
                int Count = Rnd.Next(_CountPatient) + 1;
                for (int i = 1; i <= Count; i++)
                    OnNewPatient();
            }
        }
        // Метод для расчета статистики
        public void SetStat()
        {
            // Постороение LINQ запроса
            var doctorGroups =
                // Добавляем LogList
                from log in LogList
                // Проверяем что номер доктора больше 0
                where log.Number > 0
                // Групируем по номеру доктору
                group log by log.Number into doctorGroup
                select new
                {
                    // ID Доктора присваиваем
                    DoctorId = doctorGroup.Key,
                    // Получаем количество всего пациентов принятым доктором
                    TotalPatients = doctorGroup.Select(log => log.Patient).Distinct().Count(),
                    
                    PatientsGroupedByVisits =
                    // Выделяем пациентов из log
                    from patient in doctorGroup.Select(log => log.Patient).Distinct()
                    // Групируем по пройденым пациентом врачей 
                    group patient by patient.NumDoctorsVisit.Count(id => id > 0) into visitGroup
                    // Сортируем по этому количеству
                    orderby visitGroup.Key
                    select new
                    {
                        // Получаем количество посещенных врачей
                        VisitCount = visitGroup.Key,
                        // Получаем количество пациентов которые посетили данное количество врачей
                        PatientsCount = visitGroup.Count()
                    }
                };
            // Создаем список с результатами
            var result = new List<string>();

            foreach (var doctorGroup in doctorGroups)
            {   // Добавляем строки с общим количеством принятых доктором пациентов 
                result.Add(string.Format("Доктор №{0} принял всего у себя {1}.",
                                        doctorGroup.DoctorId,
                                        (doctorGroup.TotalPatients > 4 ? 
                                        doctorGroup.TotalPatients + " пациентов" : 
                                        doctorGroup.TotalPatients + " пациента")));
                result.Add("Из них на данный момент:");

                foreach (var visitGroup in doctorGroup.PatientsGroupedByVisits)
                {   // Добавляем строки по количеству пациентов и количеству посещенных врачей 
                    result.Add(string.Format("  {0} {1};",
                        visitGroup.PatientsCount > 1 ?
                            (visitGroup.PatientsCount > 4 ? 
                            visitGroup.PatientsCount + " пациентов посетили" : 
                            visitGroup.PatientsCount + " пациента посетили") :
                            visitGroup.PatientsCount + " пациент посетил",
                        visitGroup.VisitCount > 1 ? 
                        visitGroup.VisitCount + " врачей" : 
                        visitGroup.VisitCount + " врача"));
                }
            }
            // Отчищаем текстбокс
            _Stat_TB.Clear();
            foreach (var line in result)
            {
                // Выводим на Stat_TB
                _Stat_TB.AppendText(line + Environment.NewLine);
            }
        }
        // Метод добавление новой очереди
        public void AddQueue(QueuePatient Queue)
        {
            QueuesPatient.Add(Queue);
            // Фиксация заинтересованности очереди в событии Новый пациент
            NewPatientEvent += Queue.NewPatient;
            foreach (Doctor Doc in Doctors)
            {   // Взаимная фиксации между очередью и доктором
                Doc.IsReadyEvent += Queue.SetDoctor;
                Queue.SinglePatientEvent += Doc.WaitSingle;
            }
        }
        // Метод добавление нового доктора
        public void AddDoctor(Doctor Doc)
        {
            Doctors.Add(Doc);
            // Фиксация заинтересованности доктором в событии шаг
            RunTimeEvent += Doc.RunTime;
            foreach (QueuePatient Queue in QueuesPatient)
            {
                // Фиксация заинтересовани очередью события окончания приема
                Doc.IsFinishedАppointment += Queue.SetQueueRun;
                // Взаимная фиксации между очередью и доктором
                Queue.SinglePatientEvent += Doc.WaitSingle;
                Doc.IsReadyEvent += Queue.SetDoctor;
            }
        }
    }
}
