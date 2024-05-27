using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsachpoprog
{
    // Требуется для отображения LogPatients_TB фактов приема пациента
    public class LogItem
    {   // "Счетчик"
        private static int Counter;
        // Индентификатор
        private int _ID;
        // ID Доктора
        private int _Number;
        // Текущий пациент в кабинете или на стойке
        private Patient _Patient;
        // Конструктор класса 
        public LogItem(int Number, Patient P)
        {
            // Номер докторов должен быть от 0 до 5
            if (Number >= 0 && Number <=5)
            {
                _ID = ++Counter;
                _Number = Number;
                _Patient = P;
            }
            else
                throw new Exception("Параметры Log-файла заданы неправильно");
        }
        // Конструктор без параметров.
        public LogItem() : this(-1, null) { }
        // ToString() в который будет отображаться в LogPatients_TB
        public override string ToString()
        {
            return string.Format("{0} принимает пациента №{1}",_Number > 0 ? 
                                 "Доктор №" + _Number : "Регистратура",_Patient.ID);
        }
        // Свойство индентификатора 
        public int ID {  get { return _ID; } }
        // Свойство ID Доктора. Используется Manager.SetStat() для статистики
        public int Number
        {
            get { return _Number; }
        }
        // Свойство Текущего пациента в кабинете или на стойке.
        // Используется Manager.SetStat() для статистики
        public Patient Patient
        {
            get { return _Patient; }
        }
    }
}
