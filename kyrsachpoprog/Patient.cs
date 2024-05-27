using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsachpoprog
{
    public class Patient
    {
        /* Поле статического "счетчика", который каждый раз при создании класса
         увеличивается на 1 и записывает это число в _ID*/
        private static int Counter;
        // ID - номер созданого пациента
        private int _ID;
        /*Очередность посещенных пациентом докторов.
        Служит для посчета пройденых врачей в ToString() данного класса,
        Doctor.RunTime() для определения прохождения всех врачей и
        Manager.SetStat() для статистики*/
        private Queue<int> _NumDoctorsVisit;
        /* _TimeAtDoctor требуется для подсчета проведенного времени
         в кабинете у доктора или стойки регистратуры в Doctor.RunTime()*/
        public int _TimeAtDoctor;
        // Конструктор класса
        public Patient()
        {
            // Присвоение номера пациента
            _ID = ++Counter;
            // Создание "карточки пройденых врачей"
            _NumDoctorsVisit = new Queue<int>();
        }
        // ToString() где -1 и 0 пройденых врачей это "ни одного", 1 - "врача", а >1 - "врачей"
        public override string ToString()
        {
            return string.Format("Пациент {0} прошёл {1} {2}", 
                _ID, (_NumDoctorsVisit.Count - 1 <= 0 ? "ни одного": 
                $"{_NumDoctorsVisit.Count - 1}"), _NumDoctorsVisit.Count - 1 <= 1 ? "врача" : "врачей");
        }
        // Свойство для отправки номера пациента
        public int ID {  get { return _ID; } }
        // Свойство для отправки самой типо "картоки пройденых врачей"
        public Queue<int> NumDoctorsVisit { get {  return _NumDoctorsVisit; } }
        // Свойство для проведенного времени в кабинете у доктора или стойки регистратуры
        public int TimeAtDoctor
        {
            get { return _TimeAtDoctor;}    
            set { if (value >= 0) _TimeAtDoctor = value; }
        }
        // Сколько раз пациент посещал данного врача.
        // Используется в QueuePatient.NewPatient() для направления непрошедших ни одного врача в регистратуру,
        // а в QueuePatient.SetQueueRun() для определения не пройленых пациентом врачей
        public bool CountDoctorsVisited(int DoctorID)
        {
            return _NumDoctorsVisit.Contains(DoctorID);
        }
        // Добавляет пройденых врачей в Doctor.SetPatient()
        // когда пациент попадает на прием к врачу
        public void VisitDoctor(int DoctorID)
        {
            _NumDoctorsVisit.Enqueue(DoctorID);
        }
    }
}
