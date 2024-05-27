using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsachpoprog
{
    public class LogArgs: OnlyPrintArgs
    {
        public LogCalcBack PrintLog;
        public List<QueuePatient> Queues;
        public List<Doctor> Doctors;
    }
}
