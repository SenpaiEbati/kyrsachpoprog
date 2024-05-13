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

        public QueuePatient(int DoctorNumber, ListBox LB)
        {
            _ID = ++Counter;
            _LB = LB;
            _Name = string.Format("Очередь {0}",DoctorNumber > 0 ? "к доктору №" + DoctorNumber : "в регистратуру");
        }

        public QueuePatient() : this(0, null) { } 

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
            if (SinglePatientEvent != null && _Queue.Count == 1) { 
                OnlyPrintArgs E = new OnlyPrintArgs();
                E.PrintResult = PrintResult;
                SinglePatientEvent(this, E);
            }
        }

        public void NewPatient(object sender, PatientArgs e) 
        {
            if (e.Sick != null)
            {
                _Queue.Enqueue(e.Sick);
                if (_LB != null)
                    _LB.Items.Add(e.Sick);
                if (e.PrintResult != null)
                    e.PrintResult(this + ": добавлен <" +  e.Sick + ">");

                e.Sick = null;
                OnSinglePatient(e.PrintResult);
            }
        }

        public void SetDoctor(object sender, DoctorArgs e)
        {
            if (_Queue.Count > 0 && e.IsReady)
            {
                PatientArgs E = new PatientArgs();
                E.Sick = _Queue.Dequeue();
                _LB.Items.Remove(E.Sick);
                if (e.PrintResult != null)
                    e.PrintResult(this + ": вышел из кабинета" + E.Sick + ">");
                E.PrintResult = e.PrintResult;
                e.IsReady = e.SetDoctor(E);
            }
        }

        public void SetRegistry(object sender, RegistryArgs e)
        {
            if (_Queue.Count > 0 && e.IsReady)
            {
                PatientArgs E = new PatientArgs();
                E.Sick = _Queue.Dequeue();
                _LB.Items.Remove(E.Sick);
                if (e.PrintResult != null)
                    e.PrintResult(this + ": вышел из кабинета" + E.Sick + ">");
                E.PrintResult = e.PrintResult;
                e.IsReady = e.SetRegistry(E);
            }
        }
    }
}
