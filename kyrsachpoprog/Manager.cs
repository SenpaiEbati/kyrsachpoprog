using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsachpoprog
{
    class Manager
    {
        private List<QueuePatient> QueuesPatient = new List<QueuePatient>();
        private List<Doctor> Doctors = new List<Doctor>();
        private List<Registry> Registries = new List<Registry>();
        private List<LogItem> LogList = new List<LogItem>();
        private Random Rnd = new Random();
        private TextBox _LogPatient_TB, _Stat_TB;

        private int _Chance = 2;
        private int _CountPatient = 1;
        public Manager(TextBox LogPatient_TB, TextBox Stat_TB)
        {
            _LogPatient_TB = LogPatient_TB;
            _Stat_TB = Stat_TB;
        }

        public Manager() : this(null, null) { }

        public int Chance
        {
            set { if (value >= 1 && value <= 5) _Chance = value; }
        }

        public int CountPatient
        {
            set { if (value >= 1 && value <= 20) _CountPatient = value; }
        }

        private event EventHandler<PatientArgs> NewPatientEvent;

        private void OnNewPatient()
        {
            PatientArgs E = new PatientArgs();
            E.Sick = new Patient();
            E.PrintResult = PrintResult;
  
            if (NewPatientEvent != null)
                NewPatientEvent(this, E);

            if (E.Sick != null)
                PrintResult("Не найдена подходящая очередь, <" +  E.Sick + "> покинул поликлинику");
        }

        private event EventHandler<LogArgs> RunTimeEvent;

        private void OnRunTime()
        {
            if (RunTimeEvent != null)
            {
                LogArgs E = new LogArgs();
                E.PrintResult = PrintResult;
                E.PrintLog = PrintLog;
                RunTimeEvent(this, E);
            }
        }

        private void PrintResult(string s)
        {
            if (_LogPatient_TB != null)
                _LogPatient_TB.AppendText(s + Environment.NewLine);
        }

        private void PrintLog(LogItem Item) 
        {
            LogList.Add(Item);
        }

        public void OnTimer()
        {
            _LogPatient_TB.Clear();
            OnRunTime();
            if (Rnd.Next(_Chance) == 0)
            {
                int Count = Rnd.Next(_CountPatient) + 1;
                for (int i = 1; i <= Count; i++)
                    OnNewPatient();
            }
        }

        /*public void SetStat()
        {
            var res = //
            _Stat_TB.Clear();
            foreach (var elem in res)
            {

            }
        }*/

        public void AddQueue(QueuePatient Queue)
        {
            QueuesPatient.Add(Queue);
            NewPatientEvent += Queue.NewPatient;
            foreach (Doctor Doc in Doctors)
            {
                Doc.IsReadyEvent += Queue.SetDoctor;
                Queue.SinglePatientEvent += Doc.WaitSingle;
            } 
        }

        public void RemoveQueue(QueuePatient Queue)
        {
            QueuesPatient.Remove(Queue);
            NewPatientEvent -= Queue.NewPatient;
            foreach(Doctor Doc in Doctors)
                Doc.IsReadyEvent -= Queue.SetDoctor;
        }

        public void AddDoctor(Doctor Doc)
        {
            Doctors.Add(Doc);
            RunTimeEvent += Doc.RunTime;
            foreach (QueuePatient Queue in QueuesPatient)
            {
                Queue.SinglePatientEvent += Doc.WaitSingle;
                Doc.IsReadyEvent += Queue.SetDoctor;
            }
        }

        public void RemoveDoctor(Doctor Doc)
        {
            Doctors.Remove(Doc);
            RunTimeEvent -= Doc.RunTime;
            foreach(QueuePatient Queue in QueuesPatient)
                Queue.SinglePatientEvent -= Doc.WaitSingle;
        }

        public void AddRegistry(Registry Reg)
        {
            Registries.Add(Reg);
            RunTimeEvent += Reg.RunTime;
            foreach (QueuePatient Queue in QueuesPatient)
            {
                Queue.SinglePatientEvent += Reg.WaitSingle;
                Reg.IsReadyEventRegistry += Queue.SetRegistry;
            }
        }

        public void RemoveRegistry(Registry Reg)
        {
            Registries.Remove(Reg);
            RunTimeEvent -= Reg.RunTime;
            foreach (QueuePatient Queue in QueuesPatient)
                Queue.SinglePatientEvent -= Reg.WaitSingle;
            
        }

        private void AssingPatientToDoctor(Patient patient)
        {
            var availableDoctors = Doctors
                .Where(d => !patient.CountDoctorsVisited(d.DoctorNumber))
                .OrderBy(d => d.CountAcceptedPatient)
                .ThenByDescending(d => d.DoctorNumber)
                .ToList();
            if (availableDoctors.Any())
            {
                var doctor = availableDoctors.First();  
            }
        }
    }
}
