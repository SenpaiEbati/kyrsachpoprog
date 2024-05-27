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

        public event EventHandler<OnlyPrintArgs> SinglePatientEvent;

        private void OnSinglePatient(CalcBack PrintResult)
        {
            if (SinglePatientEvent != null && _Queue.Count == 1)
            {
                OnlyPrintArgs E = new OnlyPrintArgs();
                E.PrintResult = PrintResult;
                SinglePatientEvent(this, E);
            }
        }

        public void NewPatient(object sender, PatientArgs E)
        {
            if (E.Sick != null)
            {
                if ((E.Sick.CountDoctorsVisited(0) && !E.Sick.CountDoctorsVisited(_ID)) || (!E.Sick.CountDoctorsVisited(0) && _ID == 0))
                {
                    _Queue.Enqueue(E.Sick);
                    if (_LB != null)
                        _LB.Items.Add(E.Sick);
                    if (E.PrintResult != null)
                        E.PrintResult(this + ": добавлен <" + E.Sick + ">");
                    E.Sick = null;
                    OnSinglePatient(E.PrintResult);
                }
            }
        }

        public void SetDoctor(object sender, DoctorArgs e)
        {
            if (_Queue.Count > 0 && e.IsReady && e.CurrentDocID == _ID)
            {
                PatientArgs E = new PatientArgs();

                E.Sick = _Queue.Dequeue();
                _LB.Items.Remove(E.Sick);
                if (e.PrintResult != null)
                    e.PrintResult(this + ": покинул очередь <" + E.Sick + ">");
                E.PrintResult = e.PrintResult;
                e.IsReady = e.SetDoctor(E);

            }
        }

        public void SetQueueRun(PatientArgs E, List<QueuePatient> Q, List<Doctor> D)
        {
            if (E.Sick != null)
            {
                var dogs = (from d in D
                            where !E.Sick.CountDoctorsVisited(d.DoctorNumber) && d.DoctorNumber != 0
                            orderby Q.ElementAt(d.DoctorNumber).CountPatient, d.DoctorNumber descending
                            select d).ToList();

                if (dogs.Any())
                {
                    var doctor = dogs.First();
                    Q.ElementAt(doctor.DoctorNumber).NewPatient(this, E);
                }
            }
        }
    }
}
