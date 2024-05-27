using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsachpoprog
{
    // Класс наследник
    public class LogArgs: OnlyPrintArgs
    {
        // Требуется для отображения в LogPatients_TB
        public LogCalcBack PrintLog;
        // Требуется QueuePatient.SetQueueRun() для определения
        // требующийся очереди для пациентра после прохождения доктора какого-либо 
        public List<QueuePatient> Queues;
        public List<Doctor> Doctors;
    }
}
