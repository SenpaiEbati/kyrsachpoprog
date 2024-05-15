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
        private Queue<int> _NumDoctorsVisit;

        public Patient()
        {
            _ID = ++Counter;
            _NumDoctorsVisit = new Queue<int>();
        }

        public override string ToString()
        {
            return string.Format("Пациент {0} прошёл {1} врача/-ей",_ID, _NumDoctorsVisit.Count);
        }

        public int ID {  get { return _ID; } }

        public bool CountDoctorsVisited(int DoctorID)
        {
            return _NumDoctorsVisit.Contains(DoctorID);
        }

        public void VisitDoctor(int DoctorID)
        {
            _NumDoctorsVisit.Enqueue(DoctorID);
        }
    }
}
