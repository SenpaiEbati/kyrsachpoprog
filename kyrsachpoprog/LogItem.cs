using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsachpoprog
{
    public class LogItem
    {
        private static int Counter;
        private int _ID;
        private int _Number;
        private Patient _Patient;

        public LogItem(int Number, Patient P)
        {
            if (Number >= 0 && Number <=5)
            {
                _ID = ++Counter;
                _Number = Number;
                _Patient = P;
            }
            else
                throw new Exception("Параметры Log-файла заданы неправильно");
        }

        public override string ToString()
        {
            return string.Format("{0} принимает пациента №{1}",_Number > 0 ? "Доктор №" + _Number : "Регистратура",_Patient.ID);
        }

        public int Number
        {
            get { return _Number; }
            set { if (value > 0 && value < 6) _Number = value; }
        }

        public Patient Patient
        {
            get { return _Patient; }
        }
    }
}
