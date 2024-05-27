using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsachpoprog
{
    // Класс наследник
    public class DoctorArgs: OnlyPrintArgs
    {
        // Требуется для определения готов ли доктор принимать пациента 
        public DoctorCalcBack SetDoctor;
        // Требуется для QueuePatient.SetDoctor(),
        // чтобы доктор принимал только от тех кто в его очереди, а не из других
        public int CurrentDocID;
        // Требуется для определения готов ли доктор принимать пациента
        public bool IsReady;
    }
}
