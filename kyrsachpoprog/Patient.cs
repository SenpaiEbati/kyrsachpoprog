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
        public int _TimeAtDoctor;

        public Patient()
        {
            _ID = ++Counter;
            _NumDoctorsVisit = new Queue<int>();
        }

        public override string ToString()
        {
            return string.Format("Пациент {0} прошёл {1} {2}", 
                _ID, (_NumDoctorsVisit.Count - 1 <= 0 ? "ни одного": 
                $"{_NumDoctorsVisit.Count - 1}"), _NumDoctorsVisit.Count - 1 <= 1 ? "врача" : "врачей");
        }

        public int ID {  get { return _ID; } }

        public Queue<int> NumDoctorsVisit { get {  return _NumDoctorsVisit; } }

        public int TimeAtDoctor
        {
            get { return _TimeAtDoctor;}    
            set { if (value >= 0) _TimeAtDoctor = value; }
        }

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
