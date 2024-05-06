using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsachpoprog
{
    public class Patient
    {
        private static int Counter;
        private int _ID;
        private int _NumDoctorVisit;

        public Patient(int n)
        {
            _ID = ++Counter;
            _NumDoctorVisit = n;
        }

        public Patient(): this(0) { }

        public override string ToString()
        {
            return string.Format("Пациент {0} прошёл {1} врача/-ей",_NumDoctorVisit,"*************");
        }
    }
}
