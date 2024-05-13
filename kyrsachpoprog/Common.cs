using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsachpoprog
{
    public delegate void CalcBack(string s);
    public delegate bool DoctorCalcBack(PatientArgs e);
    public delegate bool RegistryCalcBack(PatientArgs e);
    public delegate void LogCalcBack(LogItem e);
}
