namespace kyrsachpoprog
{
    partial class Main_F
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Doctor1_TB = new System.Windows.Forms.TextBox();
            this.Doctor1_L = new System.Windows.Forms.Label();
            this.QueueDoctor1_L = new System.Windows.Forms.Label();
            this.QueueReg_L = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Registry_TB = new System.Windows.Forms.TextBox();
            this.Doctors_GB = new System.Windows.Forms.GroupBox();
            this.QueueDoctor5_LB = new System.Windows.Forms.ListBox();
            this.QueueDoctor4_LB = new System.Windows.Forms.ListBox();
            this.QueueDoctor3_LB = new System.Windows.Forms.ListBox();
            this.QueueDoctor2_LB = new System.Windows.Forms.ListBox();
            this.QueueDoctor1_LB = new System.Windows.Forms.ListBox();
            this.QueueDoctor5_L = new System.Windows.Forms.Label();
            this.Doctor2_TB = new System.Windows.Forms.TextBox();
            this.Doctor2_L = new System.Windows.Forms.Label();
            this.Doctor5_L = new System.Windows.Forms.Label();
            this.Doctor5_TB = new System.Windows.Forms.TextBox();
            this.QueueDoctor2_L = new System.Windows.Forms.Label();
            this.QueueDoctor4_L = new System.Windows.Forms.Label();
            this.Doctor3_TB = new System.Windows.Forms.TextBox();
            this.Doctor3_L = new System.Windows.Forms.Label();
            this.Doctor4_L = new System.Windows.Forms.Label();
            this.Doctor4_TB = new System.Windows.Forms.TextBox();
            this.QueueDoctor3_L = new System.Windows.Forms.Label();
            this.Registry_L = new System.Windows.Forms.Label();
            this.Managment_GB = new System.Windows.Forms.GroupBox();
            this.Manual_B = new System.Windows.Forms.Button();
            this.Manual_RB = new System.Windows.Forms.RadioButton();
            this.Auto_RB = new System.Windows.Forms.RadioButton();
            this.NewPatients_GB = new System.Windows.Forms.GroupBox();
            this.Count_NUD = new System.Windows.Forms.NumericUpDown();
            this.Input_NUD = new System.Windows.Forms.NumericUpDown();
            this.Count_L = new System.Windows.Forms.Label();
            this.Input_L = new System.Windows.Forms.Label();
            this.LogPatients_L = new System.Windows.Forms.Label();
            this.LogPatients_TB = new System.Windows.Forms.TextBox();
            this.Report_GB = new System.Windows.Forms.GroupBox();
            this.Report_LB = new System.Windows.Forms.ListBox();
            this.Report_B = new System.Windows.Forms.Button();
            this.Report_L = new System.Windows.Forms.Label();
            this.QueueReg_TB = new System.Windows.Forms.ListBox();
            this.Registry_GB = new System.Windows.Forms.GroupBox();
            this.Doctors_GB.SuspendLayout();
            this.Managment_GB.SuspendLayout();
            this.NewPatients_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Count_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_NUD)).BeginInit();
            this.Report_GB.SuspendLayout();
            this.Registry_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // Doctor1_TB
            // 
            this.Doctor1_TB.Location = new System.Drawing.Point(18, 55);
            this.Doctor1_TB.Name = "Doctor1_TB";
            this.Doctor1_TB.Size = new System.Drawing.Size(172, 20);
            this.Doctor1_TB.TabIndex = 0;
            // 
            // Doctor1_L
            // 
            this.Doctor1_L.AutoSize = true;
            this.Doctor1_L.Location = new System.Drawing.Point(15, 39);
            this.Doctor1_L.Name = "Doctor1_L";
            this.Doctor1_L.Size = new System.Drawing.Size(51, 13);
            this.Doctor1_L.TabIndex = 1;
            this.Doctor1_L.Text = "Врач №1";
            // 
            // QueueDoctor1_L
            // 
            this.QueueDoctor1_L.AutoSize = true;
            this.QueueDoctor1_L.Location = new System.Drawing.Point(15, 95);
            this.QueueDoctor1_L.Name = "QueueDoctor1_L";
            this.QueueDoctor1_L.Size = new System.Drawing.Size(110, 13);
            this.QueueDoctor1_L.TabIndex = 11;
            this.QueueDoctor1_L.Text = "Очередь к врачу №1";
            // 
            // QueueReg_L
            // 
            this.QueueReg_L.AutoSize = true;
            this.QueueReg_L.Location = new System.Drawing.Point(3, 61);
            this.QueueReg_L.Name = "QueueReg_L";
            this.QueueReg_L.Size = new System.Drawing.Size(129, 13);
            this.QueueReg_L.TabIndex = 31;
            this.QueueReg_L.Text = "Очередь в регистратуру";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(-127, 382);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Регистратура";
            // 
            // Registry_TB
            // 
            this.Registry_TB.Location = new System.Drawing.Point(6, 35);
            this.Registry_TB.Name = "Registry_TB";
            this.Registry_TB.Size = new System.Drawing.Size(172, 20);
            this.Registry_TB.TabIndex = 28;
            this.Registry_TB.TextChanged += new System.EventHandler(this.Registry_TB_TextChanged);
            // 
            // Doctors_GB
            // 
            this.Doctors_GB.Controls.Add(this.QueueDoctor5_LB);
            this.Doctors_GB.Controls.Add(this.QueueDoctor4_LB);
            this.Doctors_GB.Controls.Add(this.QueueDoctor3_LB);
            this.Doctors_GB.Controls.Add(this.QueueDoctor2_LB);
            this.Doctors_GB.Controls.Add(this.QueueDoctor1_LB);
            this.Doctors_GB.Controls.Add(this.Doctor1_TB);
            this.Doctors_GB.Controls.Add(this.Doctor1_L);
            this.Doctors_GB.Controls.Add(this.label12);
            this.Doctors_GB.Controls.Add(this.QueueDoctor1_L);
            this.Doctors_GB.Controls.Add(this.QueueDoctor5_L);
            this.Doctors_GB.Controls.Add(this.Doctor2_TB);
            this.Doctors_GB.Controls.Add(this.Doctor2_L);
            this.Doctors_GB.Controls.Add(this.Doctor5_L);
            this.Doctors_GB.Controls.Add(this.Doctor5_TB);
            this.Doctors_GB.Controls.Add(this.QueueDoctor2_L);
            this.Doctors_GB.Controls.Add(this.QueueDoctor4_L);
            this.Doctors_GB.Controls.Add(this.Doctor3_TB);
            this.Doctors_GB.Controls.Add(this.Doctor3_L);
            this.Doctors_GB.Controls.Add(this.Doctor4_L);
            this.Doctors_GB.Controls.Add(this.Doctor4_TB);
            this.Doctors_GB.Controls.Add(this.QueueDoctor3_L);
            this.Doctors_GB.Location = new System.Drawing.Point(12, 294);
            this.Doctors_GB.Name = "Doctors_GB";
            this.Doctors_GB.Size = new System.Drawing.Size(1018, 333);
            this.Doctors_GB.TabIndex = 32;
            this.Doctors_GB.TabStop = false;
            this.Doctors_GB.Text = "Коридор с кабинетами врачей";
            // 
            // QueueDoctor5_LB
            // 
            this.QueueDoctor5_LB.FormattingEnabled = true;
            this.QueueDoctor5_LB.Location = new System.Drawing.Point(832, 112);
            this.QueueDoctor5_LB.Name = "QueueDoctor5_LB";
            this.QueueDoctor5_LB.Size = new System.Drawing.Size(172, 212);
            this.QueueDoctor5_LB.TabIndex = 34;
            // 
            // QueueDoctor4_LB
            // 
            this.QueueDoctor4_LB.FormattingEnabled = true;
            this.QueueDoctor4_LB.Location = new System.Drawing.Point(631, 112);
            this.QueueDoctor4_LB.Name = "QueueDoctor4_LB";
            this.QueueDoctor4_LB.Size = new System.Drawing.Size(172, 212);
            this.QueueDoctor4_LB.TabIndex = 33;
            // 
            // QueueDoctor3_LB
            // 
            this.QueueDoctor3_LB.FormattingEnabled = true;
            this.QueueDoctor3_LB.Location = new System.Drawing.Point(428, 112);
            this.QueueDoctor3_LB.Name = "QueueDoctor3_LB";
            this.QueueDoctor3_LB.Size = new System.Drawing.Size(172, 212);
            this.QueueDoctor3_LB.TabIndex = 32;
            // 
            // QueueDoctor2_LB
            // 
            this.QueueDoctor2_LB.FormattingEnabled = true;
            this.QueueDoctor2_LB.Location = new System.Drawing.Point(228, 112);
            this.QueueDoctor2_LB.Name = "QueueDoctor2_LB";
            this.QueueDoctor2_LB.Size = new System.Drawing.Size(172, 212);
            this.QueueDoctor2_LB.TabIndex = 31;
            // 
            // QueueDoctor1_LB
            // 
            this.QueueDoctor1_LB.FormattingEnabled = true;
            this.QueueDoctor1_LB.Location = new System.Drawing.Point(18, 112);
            this.QueueDoctor1_LB.Name = "QueueDoctor1_LB";
            this.QueueDoctor1_LB.Size = new System.Drawing.Size(172, 212);
            this.QueueDoctor1_LB.TabIndex = 30;
            // 
            // QueueDoctor5_L
            // 
            this.QueueDoctor5_L.AutoSize = true;
            this.QueueDoctor5_L.Location = new System.Drawing.Point(829, 96);
            this.QueueDoctor5_L.Name = "QueueDoctor5_L";
            this.QueueDoctor5_L.Size = new System.Drawing.Size(110, 13);
            this.QueueDoctor5_L.TabIndex = 27;
            this.QueueDoctor5_L.Text = "Очередь к врачу №5";
            // 
            // Doctor2_TB
            // 
            this.Doctor2_TB.Location = new System.Drawing.Point(228, 56);
            this.Doctor2_TB.Name = "Doctor2_TB";
            this.Doctor2_TB.Size = new System.Drawing.Size(172, 20);
            this.Doctor2_TB.TabIndex = 12;
            // 
            // Doctor2_L
            // 
            this.Doctor2_L.AutoSize = true;
            this.Doctor2_L.Location = new System.Drawing.Point(225, 40);
            this.Doctor2_L.Name = "Doctor2_L";
            this.Doctor2_L.Size = new System.Drawing.Size(51, 13);
            this.Doctor2_L.TabIndex = 13;
            this.Doctor2_L.Text = "Врач №2";
            // 
            // Doctor5_L
            // 
            this.Doctor5_L.AutoSize = true;
            this.Doctor5_L.Location = new System.Drawing.Point(829, 39);
            this.Doctor5_L.Name = "Doctor5_L";
            this.Doctor5_L.Size = new System.Drawing.Size(51, 13);
            this.Doctor5_L.TabIndex = 25;
            this.Doctor5_L.Text = "Врач №5";
            // 
            // Doctor5_TB
            // 
            this.Doctor5_TB.Location = new System.Drawing.Point(832, 55);
            this.Doctor5_TB.Name = "Doctor5_TB";
            this.Doctor5_TB.Size = new System.Drawing.Size(172, 20);
            this.Doctor5_TB.TabIndex = 24;
            // 
            // QueueDoctor2_L
            // 
            this.QueueDoctor2_L.AutoSize = true;
            this.QueueDoctor2_L.Location = new System.Drawing.Point(225, 96);
            this.QueueDoctor2_L.Name = "QueueDoctor2_L";
            this.QueueDoctor2_L.Size = new System.Drawing.Size(110, 13);
            this.QueueDoctor2_L.TabIndex = 15;
            this.QueueDoctor2_L.Text = "Очередь к врачу №2";
            // 
            // QueueDoctor4_L
            // 
            this.QueueDoctor4_L.AutoSize = true;
            this.QueueDoctor4_L.Location = new System.Drawing.Point(628, 96);
            this.QueueDoctor4_L.Name = "QueueDoctor4_L";
            this.QueueDoctor4_L.Size = new System.Drawing.Size(110, 13);
            this.QueueDoctor4_L.TabIndex = 23;
            this.QueueDoctor4_L.Text = "Очередь к врачу №4";
            // 
            // Doctor3_TB
            // 
            this.Doctor3_TB.Location = new System.Drawing.Point(428, 55);
            this.Doctor3_TB.Name = "Doctor3_TB";
            this.Doctor3_TB.Size = new System.Drawing.Size(172, 20);
            this.Doctor3_TB.TabIndex = 16;
            // 
            // Doctor3_L
            // 
            this.Doctor3_L.AutoSize = true;
            this.Doctor3_L.Location = new System.Drawing.Point(425, 39);
            this.Doctor3_L.Name = "Doctor3_L";
            this.Doctor3_L.Size = new System.Drawing.Size(51, 13);
            this.Doctor3_L.TabIndex = 17;
            this.Doctor3_L.Text = "Врач №3";
            // 
            // Doctor4_L
            // 
            this.Doctor4_L.AutoSize = true;
            this.Doctor4_L.Location = new System.Drawing.Point(628, 39);
            this.Doctor4_L.Name = "Doctor4_L";
            this.Doctor4_L.Size = new System.Drawing.Size(51, 13);
            this.Doctor4_L.TabIndex = 21;
            this.Doctor4_L.Text = "Врач №4";
            // 
            // Doctor4_TB
            // 
            this.Doctor4_TB.Location = new System.Drawing.Point(631, 55);
            this.Doctor4_TB.Name = "Doctor4_TB";
            this.Doctor4_TB.Size = new System.Drawing.Size(172, 20);
            this.Doctor4_TB.TabIndex = 20;
            // 
            // QueueDoctor3_L
            // 
            this.QueueDoctor3_L.AutoSize = true;
            this.QueueDoctor3_L.Location = new System.Drawing.Point(425, 96);
            this.QueueDoctor3_L.Name = "QueueDoctor3_L";
            this.QueueDoctor3_L.Size = new System.Drawing.Size(110, 13);
            this.QueueDoctor3_L.TabIndex = 19;
            this.QueueDoctor3_L.Text = "Очередь к врачу №3";
            // 
            // Registry_L
            // 
            this.Registry_L.AutoSize = true;
            this.Registry_L.Location = new System.Drawing.Point(6, 19);
            this.Registry_L.Name = "Registry_L";
            this.Registry_L.Size = new System.Drawing.Size(116, 13);
            this.Registry_L.TabIndex = 33;
            this.Registry_L.Text = "Стойка регистратуры";
            this.Registry_L.Click += new System.EventHandler(this.Registry_L_Click);
            // 
            // Managment_GB
            // 
            this.Managment_GB.Controls.Add(this.Manual_B);
            this.Managment_GB.Controls.Add(this.Manual_RB);
            this.Managment_GB.Controls.Add(this.Auto_RB);
            this.Managment_GB.Location = new System.Drawing.Point(12, 12);
            this.Managment_GB.Name = "Managment_GB";
            this.Managment_GB.Size = new System.Drawing.Size(241, 109);
            this.Managment_GB.TabIndex = 34;
            this.Managment_GB.TabStop = false;
            this.Managment_GB.Text = "Управление";
            // 
            // Manual_B
            // 
            this.Manual_B.Location = new System.Drawing.Point(118, 69);
            this.Manual_B.Name = "Manual_B";
            this.Manual_B.Size = new System.Drawing.Size(108, 23);
            this.Manual_B.TabIndex = 2;
            this.Manual_B.Text = "Шаг";
            this.Manual_B.UseVisualStyleBackColor = true;
            // 
            // Manual_RB
            // 
            this.Manual_RB.AutoSize = true;
            this.Manual_RB.Location = new System.Drawing.Point(6, 72);
            this.Manual_RB.Name = "Manual_RB";
            this.Manual_RB.Size = new System.Drawing.Size(67, 17);
            this.Manual_RB.TabIndex = 1;
            this.Manual_RB.TabStop = true;
            this.Manual_RB.Text = "Вручную";
            this.Manual_RB.UseVisualStyleBackColor = true;
            // 
            // Auto_RB
            // 
            this.Auto_RB.AutoSize = true;
            this.Auto_RB.Location = new System.Drawing.Point(6, 19);
            this.Auto_RB.Name = "Auto_RB";
            this.Auto_RB.Size = new System.Drawing.Size(103, 17);
            this.Auto_RB.TabIndex = 0;
            this.Auto_RB.TabStop = true;
            this.Auto_RB.Text = "Автоматически";
            this.Auto_RB.UseVisualStyleBackColor = true;
            // 
            // NewPatients_GB
            // 
            this.NewPatients_GB.Controls.Add(this.Count_NUD);
            this.NewPatients_GB.Controls.Add(this.Input_NUD);
            this.NewPatients_GB.Controls.Add(this.Count_L);
            this.NewPatients_GB.Controls.Add(this.Input_L);
            this.NewPatients_GB.Location = new System.Drawing.Point(12, 149);
            this.NewPatients_GB.Name = "NewPatients_GB";
            this.NewPatients_GB.Size = new System.Drawing.Size(241, 139);
            this.NewPatients_GB.TabIndex = 35;
            this.NewPatients_GB.TabStop = false;
            this.NewPatients_GB.Text = "Новые пациенты";
            // 
            // Count_NUD
            // 
            this.Count_NUD.Location = new System.Drawing.Point(163, 85);
            this.Count_NUD.Name = "Count_NUD";
            this.Count_NUD.Size = new System.Drawing.Size(72, 20);
            this.Count_NUD.TabIndex = 37;
            // 
            // Input_NUD
            // 
            this.Input_NUD.Location = new System.Drawing.Point(163, 41);
            this.Input_NUD.Name = "Input_NUD";
            this.Input_NUD.Size = new System.Drawing.Size(72, 20);
            this.Input_NUD.TabIndex = 36;
            // 
            // Count_L
            // 
            this.Count_L.AutoSize = true;
            this.Count_L.Location = new System.Drawing.Point(6, 87);
            this.Count_L.Name = "Count_L";
            this.Count_L.Size = new System.Drawing.Size(104, 13);
            this.Count_L.TabIndex = 1;
            this.Count_L.Text = "Количество от 1 до";
            // 
            // Input_L
            // 
            this.Input_L.AutoSize = true;
            this.Input_L.Location = new System.Drawing.Point(6, 43);
            this.Input_L.Name = "Input_L";
            this.Input_L.Size = new System.Drawing.Size(153, 13);
            this.Input_L.TabIndex = 0;
            this.Input_L.Text = "Вероятность появления 1 из";
            // 
            // LogPatients_L
            // 
            this.LogPatients_L.AutoSize = true;
            this.LogPatients_L.Location = new System.Drawing.Point(489, 9);
            this.LogPatients_L.Name = "LogPatients_L";
            this.LogPatients_L.Size = new System.Drawing.Size(226, 13);
            this.LogPatients_L.TabIndex = 36;
            this.LogPatients_L.Text = "Дейстрия выполненые на последнем шаге";
            // 
            // LogPatients_TB
            // 
            this.LogPatients_TB.Location = new System.Drawing.Point(492, 31);
            this.LogPatients_TB.Multiline = true;
            this.LogPatients_TB.Name = "LogPatients_TB";
            this.LogPatients_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogPatients_TB.Size = new System.Drawing.Size(538, 257);
            this.LogPatients_TB.TabIndex = 37;
            // 
            // Report_GB
            // 
            this.Report_GB.Controls.Add(this.Report_LB);
            this.Report_GB.Controls.Add(this.Report_B);
            this.Report_GB.Controls.Add(this.Report_L);
            this.Report_GB.Location = new System.Drawing.Point(1036, 12);
            this.Report_GB.Name = "Report_GB";
            this.Report_GB.Size = new System.Drawing.Size(335, 615);
            this.Report_GB.TabIndex = 38;
            this.Report_GB.TabStop = false;
            this.Report_GB.Text = "Отчет";
            // 
            // Report_LB
            // 
            this.Report_LB.FormattingEnabled = true;
            this.Report_LB.Location = new System.Drawing.Point(6, 49);
            this.Report_LB.Name = "Report_LB";
            this.Report_LB.Size = new System.Drawing.Size(320, 498);
            this.Report_LB.TabIndex = 41;
            // 
            // Report_B
            // 
            this.Report_B.Location = new System.Drawing.Point(6, 561);
            this.Report_B.Name = "Report_B";
            this.Report_B.Size = new System.Drawing.Size(323, 45);
            this.Report_B.TabIndex = 40;
            this.Report_B.Text = "Количество  обслуженных врачами пациентов";
            this.Report_B.UseVisualStyleBackColor = true;
            // 
            // Report_L
            // 
            this.Report_L.AutoSize = true;
            this.Report_L.Location = new System.Drawing.Point(3, 26);
            this.Report_L.Name = "Report_L";
            this.Report_L.Size = new System.Drawing.Size(112, 13);
            this.Report_L.TabIndex = 39;
            this.Report_L.Text = "Результаты запроса";
            // 
            // QueueReg_TB
            // 
            this.QueueReg_TB.FormattingEnabled = true;
            this.QueueReg_TB.Location = new System.Drawing.Point(6, 77);
            this.QueueReg_TB.Name = "QueueReg_TB";
            this.QueueReg_TB.Size = new System.Drawing.Size(172, 186);
            this.QueueReg_TB.TabIndex = 35;
            // 
            // Registry_GB
            // 
            this.Registry_GB.Controls.Add(this.QueueReg_TB);
            this.Registry_GB.Controls.Add(this.Registry_TB);
            this.Registry_GB.Controls.Add(this.QueueReg_L);
            this.Registry_GB.Controls.Add(this.Registry_L);
            this.Registry_GB.Location = new System.Drawing.Point(276, 12);
            this.Registry_GB.Name = "Registry_GB";
            this.Registry_GB.Size = new System.Drawing.Size(190, 276);
            this.Registry_GB.TabIndex = 39;
            this.Registry_GB.TabStop = false;
            this.Registry_GB.Text = "Регистратура";
            // 
            // Main_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 634);
            this.Controls.Add(this.Registry_GB);
            this.Controls.Add(this.Report_GB);
            this.Controls.Add(this.LogPatients_TB);
            this.Controls.Add(this.LogPatients_L);
            this.Controls.Add(this.NewPatients_GB);
            this.Controls.Add(this.Managment_GB);
            this.Controls.Add(this.Doctors_GB);
            this.Name = "Main_F";
            this.Text = "Поликлиника";
            this.Doctors_GB.ResumeLayout(false);
            this.Doctors_GB.PerformLayout();
            this.Managment_GB.ResumeLayout(false);
            this.Managment_GB.PerformLayout();
            this.NewPatients_GB.ResumeLayout(false);
            this.NewPatients_GB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Count_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_NUD)).EndInit();
            this.Report_GB.ResumeLayout(false);
            this.Report_GB.PerformLayout();
            this.Registry_GB.ResumeLayout(false);
            this.Registry_GB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Doctor1_TB;
        private System.Windows.Forms.Label Doctor1_L;
        private System.Windows.Forms.Label QueueDoctor1_L;
        private System.Windows.Forms.Label QueueReg_L;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Registry_TB;
        private System.Windows.Forms.GroupBox Doctors_GB;
        private System.Windows.Forms.Label Registry_L;
        private System.Windows.Forms.GroupBox Managment_GB;
        private System.Windows.Forms.Button Manual_B;
        private System.Windows.Forms.RadioButton Manual_RB;
        private System.Windows.Forms.RadioButton Auto_RB;
        private System.Windows.Forms.GroupBox NewPatients_GB;
        private System.Windows.Forms.NumericUpDown Count_NUD;
        private System.Windows.Forms.NumericUpDown Input_NUD;
        private System.Windows.Forms.Label Count_L;
        private System.Windows.Forms.Label Input_L;
        private System.Windows.Forms.Label LogPatients_L;
        private System.Windows.Forms.TextBox LogPatients_TB;
        private System.Windows.Forms.GroupBox Report_GB;
        private System.Windows.Forms.Button Report_B;
        private System.Windows.Forms.Label Report_L;
        private System.Windows.Forms.ListBox QueueDoctor1_LB;
        private System.Windows.Forms.ListBox Report_LB;
        private System.Windows.Forms.ListBox QueueReg_TB;
        private System.Windows.Forms.ListBox QueueDoctor5_LB;
        private System.Windows.Forms.ListBox QueueDoctor4_LB;
        private System.Windows.Forms.ListBox QueueDoctor3_LB;
        private System.Windows.Forms.ListBox QueueDoctor2_LB;
        private System.Windows.Forms.Label QueueDoctor5_L;
        private System.Windows.Forms.TextBox Doctor2_TB;
        private System.Windows.Forms.Label Doctor2_L;
        private System.Windows.Forms.Label Doctor5_L;
        private System.Windows.Forms.TextBox Doctor5_TB;
        private System.Windows.Forms.Label QueueDoctor2_L;
        private System.Windows.Forms.Label QueueDoctor4_L;
        private System.Windows.Forms.TextBox Doctor3_TB;
        private System.Windows.Forms.Label Doctor3_L;
        private System.Windows.Forms.Label Doctor4_L;
        private System.Windows.Forms.TextBox Doctor4_TB;
        private System.Windows.Forms.Label QueueDoctor3_L;
        private System.Windows.Forms.GroupBox Registry_GB;
    }
}

