using System;
using System.Collections;
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
        private PatientArgs _CurrentArgs;
        private string _Name;

        public Doctor(TextBox TB)
        {
            _ID = ++Counter - 1;
            _Name = _ID == 0 ? "Регистратура" : "Врач №" + _ID;
            _TB = TB;
            if (_TB != null)
                TB.Clear();
        }

        public Doctor() : this(null) { }
        public override string ToString()
        {
            return _Name;
        }

        public int DoctorNumber
        {
            get { return _ID; }
        }

        private bool SetPatient(PatientArgs E)
        {
            if (E.Sick != null)
                if (_CurrentArgs == null)
                {
                    _CurrentArgs = E;

                    if (_TB != null)
                        _TB.Text = E.Sick.ToString();

                    _CurrentArgs.Sick.VisitDoctor(_ID);

                    if (E.PrintResult != null)
                        E.PrintResult(this + (_ID == 0 ? 
                            ": приняла у себя <" + E.Sick + ">" : 
                            ": принял у себя <" + E.Sick + ">"));
                }
                else
                {
                    if (E.PrintResult != null)
                        E.PrintResult(this + (_ID == 0 ? 
                            ": <" + E.Sick + "> непопал на стойку из-за занятости другим пациентом или других причин!" : 
                            ": <" + E.Sick + "> непопал на прием к врачу из-за занятости кабинета другим пациентом или других причин!"));
                }
            return _CurrentArgs.Sick == null;
        }

        public event EventHandler<DoctorArgs> IsReadyEvent;

        private void OnIsReady(CalcBack PrintResult)
        {
            if (IsReadyEvent != null && _CurrentArgs == null)
            {
                DoctorArgs E = new DoctorArgs();
                E.SetDoctor = SetPatient;
                E.CurrentDocID = _ID;
                E.PrintResult = PrintResult;
                E.IsReady = true;
                IsReadyEvent(this, E);
            }
        }

        public event IsFinished IsFinishedАppointment;

        public void RunTime(object sender, LogArgs e)
        {
            if (_CurrentArgs != null)
            {
                if (_CurrentArgs.Sick != null)
                {
                    if (e.PrintResult != null)
                        e.PrintLog(new LogItem(_ID, _CurrentArgs.Sick));

                    _CurrentArgs.Sick.TimeAtDoctor++;

                    if ((_ID == 0 && _CurrentArgs.Sick.TimeAtDoctor >= 2) ||
                        (!(_CurrentArgs.Sick.ID == 1 && _ID == 5) && 
                        _ID != 0 && _CurrentArgs.Sick.TimeAtDoctor >= _ID) ||
                        (_ID == 5 && _CurrentArgs.Sick.ID == 1 && 
                        _CurrentArgs.Sick.TimeAtDoctor >= _ID + 1))
                    {
                        if (_TB != null)
                            _TB.Clear();
                        if (e.PrintResult != null)
                        {
                            e.PrintResult(this + (_ID == 0 ? 
                                ": покинул стойку <" + _CurrentArgs.Sick + ">" : 
                                ": покинул кабинет <" + _CurrentArgs.Sick + ">"));
                            if (_CurrentArgs.Sick.NumDoctorsVisit.Count == 6)
                                e.PrintResult(_CurrentArgs.Sick + " и покинул поликлинику");
                        }

                        Patient p = _CurrentArgs.Sick;
                        if (IsFinishedАppointment != null)
                            IsFinishedАppointment(this, _CurrentArgs);

                        p.TimeAtDoctor = 0;
                        _CurrentArgs = null;
                        OnIsReady(e.PrintResult);
                    }
                }
            }
        }

        public void WaitSingle(object sender, OnlyPrintArgs e)
        {
            OnIsReady(e.PrintResult);
        }
    }
}
