using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsachpoprog
{
    public partial class Main_F : System.Windows.Forms.Form
    {
        public Main_F()
        {
            InitializeComponent();
        }

        private Random Rnd = new Random();
        private Manager MainManager;

        private void Main_F_Load(object sender, EventArgs e)
        {
            MainManager = new Manager(LogPatients_TB,Stat_TB);
            MainManager.Chance = Convert.ToInt32(Input_NUD.Value);
            MainManager.CountPatient = Convert.ToInt32(Count_NUD.Value);

            MainManager.AddQueue(new QueuePatient(QueueReg_LB));
            MainManager.AddRegistry(new Registry(Registry_TB));

            MainManager.AddQueue(new QueuePatient(QueueDoctor1_LB));
            MainManager.AddQueue(new QueuePatient(QueueDoctor2_LB));
            MainManager.AddQueue(new QueuePatient(QueueDoctor3_LB));
            MainManager.AddQueue(new QueuePatient(QueueDoctor4_LB));
            MainManager.AddQueue(new QueuePatient(QueueDoctor5_LB));

            MainManager.AddDoctor(new Doctor(Doctor1_TB));
            MainManager.AddDoctor(new Doctor(Doctor2_TB));
            MainManager.AddDoctor(new Doctor(Doctor3_TB));
            MainManager.AddDoctor(new Doctor(Doctor4_TB));
            MainManager.AddDoctor(new Doctor(Doctor5_TB));
        }

        private void Timer_T_Tick(object sender, EventArgs e)
        {
            MainManager.OnTimer();
        }

        private void Manual_B_Click(object sender, EventArgs e)
        {
            Timer_T_Tick(this, e);
        }

        private void SetMode(object sender, EventArgs e)
        {
            Manual_B.Enabled = Manual_RB.Checked;
            Timer_T.Enabled = Auto_RB.Checked;
            Stat_B.Enabled = Manual_RB.Checked;
        }

        private void Stat_B_Click(object sender, EventArgs e)
        {
            //MainManager.SetStat();
        }

        private void Input_NUD_ValueChanged(object sender, EventArgs e)
        {
            MainManager.Chance = Convert.ToInt32(Input_NUD.Value);
        }

        private void Count_NUD_ValueChanged(object sender, EventArgs e)
        {
            MainManager.CountPatient = Convert.ToInt32(Count_NUD.Value);
        }
    }
}
