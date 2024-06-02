using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsachpoprog
{
    // Класс доктора
    public class Doctor
    {
        /* Поле статического "счетчика", который каждый раз при создании класса
         увеличивается на 1 и записывает это число в _ID*/
        private static int Counter;
        // ID - номер созданого доктора
        private int _ID;
        // Визуальный компонент Doctor1...5_TB
        private TextBox _TB;
        // Поле текущего пациента 
        private PatientArgs _CurrentArgs;
        // Поле названия для созданого доктора
        private string _Name;
        // Конструктор класса принимающий визуальный компонент
        public Doctor(TextBox TB)
        {
            // ID начинающийся с 0
            _ID = ++Counter - 1;
            // Название доктора, где если _ID == 0 то это регистратура
            _Name = _ID == 0 ? "Регистратура" : "Врач №" + _ID;
            _TB = TB;
            if (_TB != null)
                TB.Clear();
        }
        // Конструктор без параметров
        public Doctor() : this(null) { }
        // ToString() выводящий название которое описано в конструкторе
        public override string ToString()
        {
            return _Name;
        }
        // Свойство ID
        public int DoctorNumber
        {
            get { return _ID; }
        }
        // Метод приема пациента в кабинет доктора
        private bool SetPatient(PatientArgs E)
        {
            // Проверяем, что полученный пациент существует
            if (E.Sick != null)
                // Проверяем, что предыдущий пациент ущел(ликвидирован в RunTime())
                if (_CurrentArgs == null)
                {
                    // Записываем пациента, что доктор его принимает
                    _CurrentArgs = E;
                    // Выводим в Doctor1...5_TB этого пациента
                    if (_TB != null)
                        _TB.Text = E.Sick.ToString();
                    // Добавляем доктора в список пройденых
                    _CurrentArgs.Sick.VisitDoctor(_ID);
                    // В LogPatients_TB выводи информацию
                    if (E.PrintResult != null)
                        E.PrintResult(this + (_ID == 0 ? 
                            ": приняла у себя <" + E.Sick + ">" : 
                            ": принял у себя <" + E.Sick + ">"));
                }
                // Если текущий пациент не ущел(не ликвидирован в RunTime())
                else
                {
                    if (E.PrintResult != null)
                        E.PrintResult(this + (_ID == 0 ? 
                            ": <" + E.Sick + "> непопал на стойку из-за занятости другим пациентом или других причин!" : 
                            ": <" + E.Sick + "> непопал на прием к врачу из-за занятости кабинета другим пациентом или других причин!"));
                }
            return _CurrentArgs.Sick == null;
        }
        // Событие "кабинет освободился"
        public event EventHandler<DoctorArgs> IsReadyEvent;
        // Активатор события "кабинет освободился"
        private void OnIsReady(CalcBack PrintResult)
        {
            // Генерация события будет возможно только когда кабинет свободен
            if (IsReadyEvent != null && _CurrentArgs == null)
            {
                // Создания класса параметров события 
                DoctorArgs E = new DoctorArgs();
                // Ретрансляция метода вывода описания выполненного действия
                E.SetDoctor = SetPatient;
                // Отправки текущего ID Доктора 
                E.CurrentDocID = _ID;
                // Указание метода размещения пациента в кабинете доктора
                E.PrintResult = PrintResult;
                E.IsReady = true;
                // Генерация события 
                IsReadyEvent(this, E);
            }
        }
        // Событие "окончание приема"
        public event IsFinished IsFinishedАppointment;
        // Обработка события "Шаг"
        public void RunTime(object sender, LogArgs e)
        {
            if (_CurrentArgs != null)
            {
                // Проверка на то что пациент в кабинете есть 
                if (_CurrentArgs.Sick != null)
                {
                    // Отображение в визуальном компоненте
                    if (e.PrintResult != null)
                        e.PrintLog(new LogItem(_ID, _CurrentArgs.Sick));
                    // Подсчет времени нахождения в кабинете
                    _CurrentArgs.Sick.TimeAtDoctor++;
                    // Проверка на то, что пациент в регистратуре должен находиться 2 минуты,
                    // у докторов от 1 до 5 минут
                    if ((_ID == 0 && _CurrentArgs.Sick.TimeAtDoctor >= 2) ||
                        (!(_CurrentArgs.Sick.ID == 1 && _ID == 5) && 
                        _ID != 0 && _CurrentArgs.Sick.TimeAtDoctor >= _ID) ||
                        (_ID == 5 && _CurrentArgs.Sick.ID == 1 && 
                        _CurrentArgs.Sick.TimeAtDoctor >= _ID + 1))
                    {
                        // Если время приема прошло то пациент уходит
                        // Очистка ТекстБокса
                        if (_TB != null)
                            _TB.Clear();
                        // Вывод описания факта конца приема у врача
                        if (e.PrintResult != null)
                        {
                            e.PrintResult(this + (_ID == 0 ? 
                                ": покинул стойку <" + _CurrentArgs.Sick + ">" : 
                                ": покинул кабинет <" + _CurrentArgs.Sick + ">"));
                            // Если пройдены все врачи то пациент покидает поликлинику
                            if (_CurrentArgs.Sick.NumDoctorsVisit.Count == 6)
                                e.PrintResult(_CurrentArgs.Sick + " и покинул поликлинику");
                        }
                        // Записываем пациента в переменую 
                        Patient p = _CurrentArgs.Sick;
                        
                        if (IsFinishedАppointment != null)
                        {
                            var dogs = (from d in e.Doctors
                                        where !p.CountDoctorsVisited(d.DoctorNumber) && d.DoctorNumber != 0
                                        orderby e.Queues.ElementAt(d.DoctorNumber).CountPatient, d.DoctorNumber descending
                                        select d).ToList();
                            // Проверка на существование
                            if (dogs.Any())
                            {
                                // Берем первого из списка
                                var doctor = dogs.First();
                                IsFinishedАppointment(_CurrentArgs, doctor.DoctorNumber);
                            }
                        }
                        // Обнуляем время прием проведенное в кабинете
                        p.TimeAtDoctor = 0;
                        // Ликвидируем пациента, так как он уже ушел из кабинета
                        _CurrentArgs = null;
                        // Генерация события колонка свободна
                        OnIsReady(e.PrintResult);
                    }
                }
            }
        }
        // Обработка события Первый пациент в очереди
        public void WaitSingle(object sender, OnlyPrintArgs e)
        {
            // Если доктор свободен то сообщение о том что он готов принять пациента
            OnIsReady(e.PrintResult);
        }
    }
}
