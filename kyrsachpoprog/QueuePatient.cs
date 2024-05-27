using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsachpoprog
{
    public class QueuePatient
    {
        private static int Counter;
        private int _ID;
        // Список пациентов находящихся в очереди
        private Queue<Patient> _Queue = new Queue<Patient>();
        private ListBox _LB;
        private string _Name;

        public QueuePatient(ListBox LB)
        {
            _ID = ++Counter - 1;
            _LB = LB;
            _Name = string.Format("Очередь {0}", _ID > 0 ? "к доктору №" + _ID : "в регистратуру");
        }

        public QueuePatient() : this(null) { }

        public override string ToString()
        {
            return _Name;
        }

        public int QueueNumber
        {
            get { return _ID; }
        }

        public int CountPatient
        {
            get { return _Queue.Count; }
        }
        // Событие "Первый пациент в очереди"
        public event EventHandler<OnlyPrintArgs> SinglePatientEvent;
        // Активатор события "Первый пациент в очереди"
        private void OnSinglePatient(CalcBack PrintResult)
        {
            // Событие генерируется если пациент первый в очереди
            if (SinglePatientEvent != null && _Queue.Count == 1)
            {
                // Создание параметров события
                OnlyPrintArgs E = new OnlyPrintArgs();
                E.PrintResult = PrintResult;
                // Генерация события
                SinglePatientEvent(this, E);
            }
        }
        // Обработка события Новый пациент
        public void NewPatient(object sender, PatientArgs E)
        {
            // Пациент должен существовать
            if (E.Sick != null)
            {
                // Пациент должен пройти регистратуру и идти к тем врачам которых не прошел
                // или идти сначала в регистратуру
                if ((E.Sick.CountDoctorsVisited(0) && !E.Sick.CountDoctorsVisited(_ID)) || (!E.Sick.CountDoctorsVisited(0) && _ID == 0))
                {
                    // Добавление пациента в очередь
                    _Queue.Enqueue(E.Sick);
                    // Отображение в визуальном компоненте
                    if (_LB != null)
                        _LB.Items.Add(E.Sick);
                    // Вывод описания факта размещения пациента
                    if (E.PrintResult != null)
                        E.PrintResult(this + ": добавлен <" + E.Sick + ">");
                    // Пациент уже добавлен в очередь и не должен быть добавлен вновь
                    E.Sick = null;
                    // Возможная активация события "Первый в очереди"
                    OnSinglePatient(E.PrintResult);
                }
            }
        }
        // Обработка события доктор свободен
        public void SetDoctor(object sender, DoctorArgs e)
        {
            // Обработка происходит если в очереди есть пациенты, очередь готова и очередь ведет к данному доктору(ID доктора == ID очереди)
            if (_Queue.Count > 0 && e.IsReady && e.CurrentDocID == _ID)
            {
                // Подготовка параметров для передачи пациента доктору
                PatientArgs E = new PatientArgs();
                // Удаление пациента из очереди и записывание его в параметр
                E.Sick = _Queue.Dequeue();
                // Обновление визуального компонента
                _LB.Items.Remove(E.Sick);
                if (e.PrintResult != null)
                    e.PrintResult(this + ": покинул очередь <" + E.Sick + ">");
                E.PrintResult = e.PrintResult;
                /* Попытка размещения пациента у доктора и 
                 * корректировка доступности доктора по результатам размещения */
                e.IsReady = e.SetDoctor(E);

            }
        }
        // Обработка события окончания приема 
        public void SetQueueRun(PatientArgs E, List<QueuePatient> Q, List<Doctor> D)
        {
            // Проверка на существование
            if (E.Sick != null && Q != null && D != null)
            {
                // Сортировка очередей по количеству внутри пациентов и докторов по времени приема
                // с отсеиванием прошедших докторов и регистратуры
                var dogs = (from d in D
                            where !E.Sick.CountDoctorsVisited(d.DoctorNumber) && d.DoctorNumber != 0
                            orderby Q.ElementAt(d.DoctorNumber).CountPatient, d.DoctorNumber descending
                            select d).ToList();
                // Проверка на существование
                if (dogs.Any())
                {
                    // Берем первого из списка
                    var doctor = dogs.First();
                    // Отправляем в нужнуб очередь
                    Q.ElementAt(doctor.DoctorNumber).NewPatient(this, E);
                }
            }
        }
    }
}
