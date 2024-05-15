using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsachpoprog
{
    public class Registry
    {
        private TextBox _TB;
        private string _Name;
        private Patient _Current;
        private int _i;
        public Registry(TextBox TB) 
        { 
            _TB = TB;
            if (_TB != null)
                TB.Clear();
            _Name = "Регистратура";
        }

        public Registry(): this(null){ }

        public override string ToString()
        {
            return _Name;
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
                        E.PrintResult(this + ": приняла у себя <" + E.Sick + ">");
                }
                else
                {
                    if (E.PrintResult != null)
                        E.PrintResult(this + ": <" + E.Sick + "> непопал на стойку из-за занятости другим пациентом или других причин!");
                }
            return _Current == null;
        }

        public event EventHandler<RegistryArgs> IsReadyEventRegistry;

        private void OnIsReady(CalcBack PrintResult)
        {
            if (IsReadyEventRegistry != null && _Current == null)
            {
                RegistryArgs E = new RegistryArgs();
                E.PrintResult = PrintResult;
                E.SetRegistry = SetPatient;
                E.IsReady = true;
                IsReadyEventRegistry(this, E);
            }
        }

        public void RunTime(object sender, LogArgs e)
        {
            if (_Current != null)
            {
                if (e.PrintResult != null)
                    e.PrintLog(new LogItem(0,_Current));
                if (_i > 1) 
                {
                    if (_TB != null)
                        _TB.Clear();
                    if (e.PrintResult != null)
                        e.PrintResult(this + ": покинул стойку <" + _Current + ">");
                    AssingPatientToDoctor(_Current);
                    _Current = null;
                    OnIsReady(e.PrintResult);
                    _i = 0;
                }
                _i++;
            }
        }

        public void WaitSingle(object sender, OnlyPrintArgs e)
        {
            OnIsReady(e.PrintResult);
        }
    }
}
