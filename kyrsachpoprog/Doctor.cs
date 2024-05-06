using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsachpoprog
{
    public class Doctor
    {
        private static int Counter;
        private int _ID;
        private TextBox _TB;
        private Patient _Current;
        private string _Name;

        public Doctor(TextBox TB)
        {
            _ID = ++Counter;
            _Name = "Доктор " + _ID;
            _TB = TB;
            if (_TB != null)
                TB.Clear();
        }

        public Doctor(): this(null) { }
        public override string ToString()
        {
            return _Name;
        }

        public int DoctorNumber
        {
            get{ return _ID; }
        }

        private bool SetPatient(PatientArgs E)
        {
            if (E.Sick != null)
                if (_Current == null)
                {
                    _Current = E.Sick;
                    if (_TB != null)
                        _TB.Text = E.Sick.ToString();
                    if (E.PrintResult != null)
                        E.PrintResult(this + ":принял у себя <" + E.Sick + ">");
                }
                else
                {
                    if (E.PrintResult != null)
                        E.PrintResult(this + ": <" + E.Sick + "> непопал на прием к врачу из-за занятости кабинета другим пациентом или других причин!");
                }
            return _Current == null;
        }

        public event EventHandler<DoctorArgs> IsReadyEvent;
        
        private void OnIsReady(CalcBack PrintResult)
        {
            if (IsReadyEvent != null && _Current == null)
            {
                DoctorArgs E = new DoctorArgs();
                E.PrintResult = PrintResult;
                //E.SetDoctor = SetPatient;
                E.IsReady = true;
                IsReadyEvent(this, E);
            }
        }

        public void RunTime(object sender, LogArgs e)
        {
            if (_Current != null)
            {
                if (_TB != null)
                    _TB.Clear();
                if (e.PrintResult != null)
                    e.PrintResult(this + ": покинул кабинет <" + _Current + ">");
                _Current = null;
                OnIsReady(e.PrintResult);
            }
            else
                if (_TB != null)
                    _TB.Text = _Current.ToString();
        }

        public void WaitSignal(object sender, OnlyPrintArgs e)
        {
            OnIsReady(e.PrintResult);
        }
    }
}
