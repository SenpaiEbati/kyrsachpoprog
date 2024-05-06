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
        private int _DoctorNumber;

        public LogItem(int DoctorNumber)
        {
            if (DoctorNumber > 0 && DoctorNumber < 6)
            {
                _ID = ++Counter;
                _DoctorNumber = DoctorNumber;
            }
            else
                throw new Exception("Параметры Log-файла заданы неправильно");
        }

        public override string ToString()
        {
            return string.Format("Доктор {0} принимает {1}",_DoctorNumber,1111);
        }

        public int DoctorNumber
        {
            get { return _DoctorNumber; }
            set { if (value > 0 && value < 6) _DoctorNumber = value; }
        }
    }
}
