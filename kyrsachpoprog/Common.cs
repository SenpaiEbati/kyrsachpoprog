using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsachpoprog
{
    public delegate void CalcBack(string s);
    // Требуется для определения готов ли доктор принимать пациента
    public delegate bool DoctorCalcBack(PatientArgs e);
    // Требуется для отображения в LogPatients_TB
    public delegate void LogCalcBack(LogItem e);
    // Делегат требующийся для передачи пациента из рук доктора в руки очереди
    public delegate void IsFinished(PatientArgs e, List<QueuePatient> q, List<Doctor> r);
}
