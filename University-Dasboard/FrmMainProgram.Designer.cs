﻿namespace University_Dasboard
{
    partial class FrmMainProgram
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainProgram));
			panel1 = new Panel();
			pnlNavigation = new Panel();
			pnlSchedulingSubMenu = new Panel();
			button5 = new Button();
			button4 = new Button();
			button3 = new Button();
			btnScheduling = new Button();
			pnlGradeRecordSubMenu = new Panel();
			pnlNavigationSubmenu = new Panel();
			btnGrades = new Button();
			btnGradeRecord = new Button();
			pnlManageDataSubMenu = new Panel();
			btnTeachers = new Button();
			btnStudents = new Button();
			btnGroups = new Button();
			btnDisciplines = new Button();
			btnDirections = new Button();
			btnDepartments = new Button();
			btnFaculties = new Button();
			btnManageData = new Button();
			panel2 = new Panel();
			picProfile = new PictureBox();
			panel4 = new Panel();
			label2 = new Label();
			lbUserName = new Label();
			button1 = new Button();
			button2 = new Button();
			panel3 = new Panel();
			pnlFormLoader = new Panel();
			panel1.SuspendLayout();
			pnlSchedulingSubMenu.SuspendLayout();
			pnlGradeRecordSubMenu.SuspendLayout();
			pnlManageDataSubMenu.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picProfile).BeginInit();
			panel3.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.AutoScroll = true;
			panel1.BackColor = Color.FromArgb(24, 30, 54);
			panel1.Controls.Add(pnlNavigation);
			panel1.Controls.Add(pnlSchedulingSubMenu);
			panel1.Controls.Add(btnScheduling);
			panel1.Controls.Add(pnlGradeRecordSubMenu);
			panel1.Controls.Add(btnGradeRecord);
			panel1.Controls.Add(pnlManageDataSubMenu);
			panel1.Controls.Add(btnManageData);
			panel1.Controls.Add(panel2);
			panel1.Dock = DockStyle.Left;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(187, 730);
			panel1.TabIndex = 0;
			// 
			// pnlNavigation
			// 
			pnlNavigation.BackColor = Color.FromArgb(0, 126, 249);
			pnlNavigation.Location = new Point(0, 185);
			pnlNavigation.Name = "pnlNavigation";
			pnlNavigation.Size = new Size(3, 52);
			pnlNavigation.TabIndex = 2;
			pnlNavigation.Visible = false;
			// 
			// pnlSchedulingSubMenu
			// 
			pnlSchedulingSubMenu.Controls.Add(button5);
			pnlSchedulingSubMenu.Controls.Add(button4);
			pnlSchedulingSubMenu.Controls.Add(button3);
			pnlSchedulingSubMenu.Dock = DockStyle.Top;
			pnlSchedulingSubMenu.Location = new Point(0, 880);
			pnlSchedulingSubMenu.Name = "pnlSchedulingSubMenu";
			pnlSchedulingSubMenu.Size = new Size(170, 208);
			pnlSchedulingSubMenu.TabIndex = 4;
			pnlSchedulingSubMenu.Visible = false;
			// 
			// button5
			// 
			button5.Dock = DockStyle.Top;
			button5.FlatAppearance.BorderSize = 0;
			button5.FlatStyle = FlatStyle.Flat;
			button5.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button5.ForeColor = Color.FromArgb(0, 126, 249);
			button5.ImageAlign = ContentAlignment.MiddleRight;
			button5.Location = new Point(0, 128);
			button5.Name = "button5";
			button5.Padding = new Padding(20, 0, 15, 0);
			button5.Size = new Size(170, 64);
			button5.TabIndex = 4;
			button5.Text = "По преподавателю";
			button5.TextAlign = ContentAlignment.MiddleLeft;
			button5.TextImageRelation = TextImageRelation.TextBeforeImage;
			button5.UseVisualStyleBackColor = true;
			button5.Click += button5_Click;
			// 
			// button4
			// 
			button4.Dock = DockStyle.Top;
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatStyle = FlatStyle.Flat;
			button4.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button4.ForeColor = Color.FromArgb(0, 126, 249);
			button4.ImageAlign = ContentAlignment.MiddleRight;
			button4.Location = new Point(0, 64);
			button4.Name = "button4";
			button4.Padding = new Padding(20, 0, 15, 0);
			button4.Size = new Size(170, 64);
			button4.TabIndex = 3;
			button4.Text = "По дисциплине";
			button4.TextAlign = ContentAlignment.MiddleLeft;
			button4.TextImageRelation = TextImageRelation.TextBeforeImage;
			button4.UseVisualStyleBackColor = true;
			button4.Click += buttonSchedulingDisciplines_Click;
			// 
			// button3
			// 
			button3.Dock = DockStyle.Top;
			button3.FlatAppearance.BorderSize = 0;
			button3.FlatStyle = FlatStyle.Flat;
			button3.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button3.ForeColor = Color.FromArgb(0, 126, 249);
			button3.ImageAlign = ContentAlignment.MiddleRight;
			button3.Location = new Point(0, 0);
			button3.Name = "button3";
			button3.Padding = new Padding(20, 0, 15, 0);
			button3.Size = new Size(170, 64);
			button3.TabIndex = 2;
			button3.Text = "Академические часы";
			button3.TextAlign = ContentAlignment.MiddleLeft;
			button3.TextImageRelation = TextImageRelation.TextBeforeImage;
			button3.UseVisualStyleBackColor = true;
			button3.Click += btnSchedulingWeek_Click;
			// 
			// btnScheduling
			// 
			btnScheduling.Dock = DockStyle.Top;
			btnScheduling.FlatAppearance.BorderSize = 0;
			btnScheduling.FlatStyle = FlatStyle.Flat;
			btnScheduling.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnScheduling.ForeColor = Color.FromArgb(0, 126, 249);
			btnScheduling.ImageAlign = ContentAlignment.MiddleRight;
			btnScheduling.Location = new Point(0, 816);
			btnScheduling.Name = "btnScheduling";
			btnScheduling.Padding = new Padding(5, 0, 15, 0);
			btnScheduling.Size = new Size(170, 64);
			btnScheduling.TabIndex = 1;
			btnScheduling.Text = "Составление расписания";
			btnScheduling.TextAlign = ContentAlignment.MiddleLeft;
			btnScheduling.TextImageRelation = TextImageRelation.TextBeforeImage;
			btnScheduling.UseVisualStyleBackColor = true;
			btnScheduling.Click += btnSchedulingWeek_Click;
			// 
			// pnlGradeRecordSubMenu
			// 
			pnlGradeRecordSubMenu.BackColor = Color.FromArgb(24, 30, 54);
			pnlGradeRecordSubMenu.Controls.Add(pnlNavigationSubmenu);
			pnlGradeRecordSubMenu.Controls.Add(btnGrades);
			pnlGradeRecordSubMenu.Dock = DockStyle.Top;
			pnlGradeRecordSubMenu.Location = new Point(0, 735);
			pnlGradeRecordSubMenu.Name = "pnlGradeRecordSubMenu";
			pnlGradeRecordSubMenu.Size = new Size(170, 81);
			pnlGradeRecordSubMenu.TabIndex = 3;
			pnlGradeRecordSubMenu.Visible = false;
			// 
			// pnlNavigationSubmenu
			// 
			pnlNavigationSubmenu.BackColor = Color.FromArgb(0, 126, 249);
			pnlNavigationSubmenu.Location = new Point(0, 6);
			pnlNavigationSubmenu.Name = "pnlNavigationSubmenu";
			pnlNavigationSubmenu.Size = new Size(3, 52);
			pnlNavigationSubmenu.TabIndex = 3;
			pnlNavigationSubmenu.Visible = false;
			// 
			// btnGrades
			// 
			btnGrades.BackColor = Color.FromArgb(24, 30, 54);
			btnGrades.Dock = DockStyle.Top;
			btnGrades.FlatAppearance.BorderSize = 0;
			btnGrades.FlatStyle = FlatStyle.Flat;
			btnGrades.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnGrades.ForeColor = Color.FromArgb(0, 126, 249);
			btnGrades.ImageAlign = ContentAlignment.MiddleRight;
			btnGrades.Location = new Point(0, 0);
			btnGrades.Name = "btnGrades";
			btnGrades.Padding = new Padding(30, 0, 15, 0);
			btnGrades.Size = new Size(170, 64);
			btnGrades.TabIndex = 5;
			btnGrades.Text = "Оценки";
			btnGrades.TextAlign = ContentAlignment.MiddleLeft;
			btnGrades.TextImageRelation = TextImageRelation.TextBeforeImage;
			btnGrades.UseVisualStyleBackColor = false;
			btnGrades.Click += btGrades_Click;
			// 
			// btnGradeRecord
			// 
			btnGradeRecord.Dock = DockStyle.Top;
			btnGradeRecord.FlatAppearance.BorderSize = 0;
			btnGradeRecord.FlatStyle = FlatStyle.Flat;
			btnGradeRecord.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnGradeRecord.ForeColor = Color.FromArgb(0, 126, 249);
			btnGradeRecord.ImageAlign = ContentAlignment.MiddleRight;
			btnGradeRecord.Location = new Point(0, 671);
			btnGradeRecord.Name = "btnGradeRecord";
			btnGradeRecord.Padding = new Padding(5, 0, 15, 0);
			btnGradeRecord.Size = new Size(170, 64);
			btnGradeRecord.TabIndex = 1;
			btnGradeRecord.Text = "Учёт\r\nуспеваемости";
			btnGradeRecord.TextAlign = ContentAlignment.MiddleLeft;
			btnGradeRecord.TextImageRelation = TextImageRelation.TextBeforeImage;
			btnGradeRecord.UseVisualStyleBackColor = true;
			btnGradeRecord.Click += btnGradeRecord_Click;
			// 
			// pnlManageDataSubMenu
			// 
			pnlManageDataSubMenu.Controls.Add(btnTeachers);
			pnlManageDataSubMenu.Controls.Add(btnStudents);
			pnlManageDataSubMenu.Controls.Add(btnGroups);
			pnlManageDataSubMenu.Controls.Add(btnDisciplines);
			pnlManageDataSubMenu.Controls.Add(btnDirections);
			pnlManageDataSubMenu.Controls.Add(btnDepartments);
			pnlManageDataSubMenu.Controls.Add(btnFaculties);
			pnlManageDataSubMenu.Dock = DockStyle.Top;
			pnlManageDataSubMenu.Location = new Point(0, 208);
			pnlManageDataSubMenu.Name = "pnlManageDataSubMenu";
			pnlManageDataSubMenu.Size = new Size(170, 463);
			pnlManageDataSubMenu.TabIndex = 5;
			pnlManageDataSubMenu.Visible = false;
			// 
			// btnTeachers
			// 
			btnTeachers.BackColor = Color.FromArgb(24, 30, 54);
			btnTeachers.Dock = DockStyle.Top;
			btnTeachers.FlatAppearance.BorderSize = 0;
			btnTeachers.FlatStyle = FlatStyle.Flat;
			btnTeachers.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnTeachers.ForeColor = Color.FromArgb(0, 126, 249);
			btnTeachers.ImageAlign = ContentAlignment.MiddleRight;
			btnTeachers.Location = new Point(0, 384);
			btnTeachers.Name = "btnTeachers";
			btnTeachers.Padding = new Padding(30, 0, 15, 0);
			btnTeachers.Size = new Size(170, 64);
			btnTeachers.TabIndex = 14;
			btnTeachers.Text = "Преподаватели";
			btnTeachers.TextAlign = ContentAlignment.MiddleLeft;
			btnTeachers.TextImageRelation = TextImageRelation.TextBeforeImage;
			btnTeachers.UseVisualStyleBackColor = false;
			btnTeachers.Click += btnTeachers_Click;
			// 
			// btnStudents
			// 
			btnStudents.BackColor = Color.FromArgb(24, 30, 54);
			btnStudents.Dock = DockStyle.Top;
			btnStudents.FlatAppearance.BorderSize = 0;
			btnStudents.FlatStyle = FlatStyle.Flat;
			btnStudents.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnStudents.ForeColor = Color.FromArgb(0, 126, 249);
			btnStudents.ImageAlign = ContentAlignment.MiddleRight;
			btnStudents.Location = new Point(0, 320);
			btnStudents.Name = "btnStudents";
			btnStudents.Padding = new Padding(30, 0, 15, 0);
			btnStudents.Size = new Size(170, 64);
			btnStudents.TabIndex = 13;
			btnStudents.Text = "Студенты";
			btnStudents.TextAlign = ContentAlignment.MiddleLeft;
			btnStudents.TextImageRelation = TextImageRelation.TextBeforeImage;
			btnStudents.UseVisualStyleBackColor = false;
			btnStudents.Click += btnStudents_Click;
			// 
			// btnGroups
			// 
			btnGroups.BackColor = Color.FromArgb(24, 30, 54);
			btnGroups.Dock = DockStyle.Top;
			btnGroups.FlatAppearance.BorderSize = 0;
			btnGroups.FlatStyle = FlatStyle.Flat;
			btnGroups.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnGroups.ForeColor = Color.FromArgb(0, 126, 249);
			btnGroups.ImageAlign = ContentAlignment.MiddleRight;
			btnGroups.Location = new Point(0, 256);
			btnGroups.Name = "btnGroups";
			btnGroups.Padding = new Padding(30, 0, 15, 0);
			btnGroups.Size = new Size(170, 64);
			btnGroups.TabIndex = 12;
			btnGroups.Text = "Группы";
			btnGroups.TextAlign = ContentAlignment.MiddleLeft;
			btnGroups.TextImageRelation = TextImageRelation.TextBeforeImage;
			btnGroups.UseVisualStyleBackColor = false;
			btnGroups.Click += btnGroups_Click;
			// 
			// btnDisciplines
			// 
			btnDisciplines.BackColor = Color.FromArgb(24, 30, 54);
			btnDisciplines.Dock = DockStyle.Top;
			btnDisciplines.FlatAppearance.BorderSize = 0;
			btnDisciplines.FlatStyle = FlatStyle.Flat;
			btnDisciplines.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnDisciplines.ForeColor = Color.FromArgb(0, 126, 249);
			btnDisciplines.ImageAlign = ContentAlignment.MiddleRight;
			btnDisciplines.Location = new Point(0, 192);
			btnDisciplines.Name = "btnDisciplines";
			btnDisciplines.Padding = new Padding(30, 0, 15, 0);
			btnDisciplines.Size = new Size(170, 64);
			btnDisciplines.TabIndex = 10;
			btnDisciplines.Text = "Дисциплины";
			btnDisciplines.TextAlign = ContentAlignment.MiddleLeft;
			btnDisciplines.TextImageRelation = TextImageRelation.TextBeforeImage;
			btnDisciplines.UseVisualStyleBackColor = false;
			btnDisciplines.Click += btnDisciplines_Click;
			// 
			// btnDirections
			// 
			btnDirections.BackColor = Color.FromArgb(24, 30, 54);
			btnDirections.Dock = DockStyle.Top;
			btnDirections.FlatAppearance.BorderSize = 0;
			btnDirections.FlatStyle = FlatStyle.Flat;
			btnDirections.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnDirections.ForeColor = Color.FromArgb(0, 126, 249);
			btnDirections.ImageAlign = ContentAlignment.MiddleRight;
			btnDirections.Location = new Point(0, 128);
			btnDirections.Name = "btnDirections";
			btnDirections.Padding = new Padding(30, 0, 15, 0);
			btnDirections.Size = new Size(170, 64);
			btnDirections.TabIndex = 8;
			btnDirections.Text = "Направления";
			btnDirections.TextAlign = ContentAlignment.MiddleLeft;
			btnDirections.TextImageRelation = TextImageRelation.TextBeforeImage;
			btnDirections.UseVisualStyleBackColor = false;
			btnDirections.Click += btnDirections_Click;
			// 
			// btnDepartments
			// 
			btnDepartments.BackColor = Color.FromArgb(24, 30, 54);
			btnDepartments.Dock = DockStyle.Top;
			btnDepartments.FlatAppearance.BorderSize = 0;
			btnDepartments.FlatStyle = FlatStyle.Flat;
			btnDepartments.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnDepartments.ForeColor = Color.FromArgb(0, 126, 249);
			btnDepartments.ImageAlign = ContentAlignment.MiddleRight;
			btnDepartments.Location = new Point(0, 64);
			btnDepartments.Name = "btnDepartments";
			btnDepartments.Padding = new Padding(30, 0, 15, 0);
			btnDepartments.Size = new Size(170, 64);
			btnDepartments.TabIndex = 3;
			btnDepartments.Text = "Кафедры";
			btnDepartments.TextAlign = ContentAlignment.MiddleLeft;
			btnDepartments.TextImageRelation = TextImageRelation.TextBeforeImage;
			btnDepartments.UseVisualStyleBackColor = false;
			btnDepartments.Click += btnDepartments_Click;
			// 
			// btnFaculties
			// 
			btnFaculties.BackColor = Color.FromArgb(24, 30, 54);
			btnFaculties.Dock = DockStyle.Top;
			btnFaculties.FlatAppearance.BorderSize = 0;
			btnFaculties.FlatStyle = FlatStyle.Flat;
			btnFaculties.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnFaculties.ForeColor = Color.FromArgb(0, 126, 249);
			btnFaculties.ImageAlign = ContentAlignment.MiddleRight;
			btnFaculties.Location = new Point(0, 0);
			btnFaculties.Name = "btnFaculties";
			btnFaculties.Padding = new Padding(30, 0, 15, 0);
			btnFaculties.Size = new Size(170, 64);
			btnFaculties.TabIndex = 7;
			btnFaculties.Text = "Факультеты";
			btnFaculties.TextAlign = ContentAlignment.MiddleLeft;
			btnFaculties.TextImageRelation = TextImageRelation.TextBeforeImage;
			btnFaculties.UseVisualStyleBackColor = false;
			btnFaculties.Click += btnFaculties_Click;
			// 
			// btnManageData
			// 
			btnManageData.Dock = DockStyle.Top;
			btnManageData.FlatAppearance.BorderSize = 0;
			btnManageData.FlatStyle = FlatStyle.Flat;
			btnManageData.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnManageData.ForeColor = Color.FromArgb(0, 126, 249);
			btnManageData.ImageAlign = ContentAlignment.MiddleRight;
			btnManageData.Location = new Point(0, 144);
			btnManageData.Name = "btnManageData";
			btnManageData.Padding = new Padding(5, 0, 15, 0);
			btnManageData.Size = new Size(170, 64);
			btnManageData.TabIndex = 6;
			btnManageData.Text = "Управление данными";
			btnManageData.TextAlign = ContentAlignment.MiddleLeft;
			btnManageData.TextImageRelation = TextImageRelation.TextBeforeImage;
			btnManageData.UseVisualStyleBackColor = true;
			btnManageData.Click += btnManageData_Click;
			// 
			// panel2
			// 
			panel2.Controls.Add(picProfile);
			panel2.Controls.Add(panel4);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(lbUserName);
			panel2.Dock = DockStyle.Top;
			panel2.Location = new Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new Size(170, 144);
			panel2.TabIndex = 0;
			// 
			// picProfile
			// 
			picProfile.Image = Properties.Resources.Untitled_11;
			picProfile.Location = new Point(60, 22);
			picProfile.Name = "picProfile";
			picProfile.Size = new Size(63, 63);
			picProfile.SizeMode = PictureBoxSizeMode.Zoom;
			picProfile.TabIndex = 0;
			picProfile.TabStop = false;
			picProfile.Click += picProfile_Click;
			// 
			// panel4
			// 
			panel4.Dock = DockStyle.Top;
			panel4.Location = new Point(0, 0);
			panel4.Name = "panel4";
			panel4.Size = new Size(170, 40);
			panel4.TabIndex = 3;
			panel4.MouseDown += panel4_MouseDown;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(158, 161, 178);
			label2.Location = new Point(37, 117);
			label2.Name = "label2";
			label2.Size = new Size(108, 12);
			label2.TabIndex = 2;
			label2.Text = "Другая информация";
			// 
			// lbUserName
			// 
			lbUserName.AutoSize = true;
			lbUserName.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbUserName.ForeColor = Color.FromArgb(0, 126, 249);
			lbUserName.Location = new Point(19, 91);
			lbUserName.Name = "lbUserName";
			lbUserName.Size = new Size(145, 16);
			lbUserName.TabIndex = 1;
			lbUserName.Text = "Имя пользователя";
			lbUserName.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			button1.Dock = DockStyle.Right;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = FlatStyle.Flat;
			button1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button1.ForeColor = Color.FromArgb(0, 126, 249);
			button1.Image = (Image)resources.GetObject("button1.Image");
			button1.Location = new Point(956, 0);
			button1.Name = "button1";
			button1.Size = new Size(40, 40);
			button1.TabIndex = 1;
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Dock = DockStyle.Right;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = FlatStyle.Flat;
			button2.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			button2.ForeColor = Color.FromArgb(0, 126, 249);
			button2.Location = new Point(916, 0);
			button2.Name = "button2";
			button2.Size = new Size(40, 40);
			button2.TabIndex = 2;
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// panel3
			// 
			panel3.BackColor = Color.FromArgb(24, 30, 54);
			panel3.Controls.Add(button2);
			panel3.Controls.Add(button1);
			panel3.Dock = DockStyle.Top;
			panel3.Location = new Point(187, 0);
			panel3.Name = "panel3";
			panel3.Size = new Size(996, 40);
			panel3.TabIndex = 3;
			panel3.MouseDown += panel3_MouseDown;
			// 
			// pnlFormLoader
			// 
			pnlFormLoader.Dock = DockStyle.Bottom;
			pnlFormLoader.Location = new Point(187, 38);
			pnlFormLoader.Name = "pnlFormLoader";
			pnlFormLoader.Size = new Size(996, 692);
			pnlFormLoader.TabIndex = 4;
			// 
			// FrmMainProgram
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(1183, 730);
			Controls.Add(pnlFormLoader);
			Controls.Add(panel3);
			Controls.Add(panel1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FrmMainProgram";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Form1";
			panel1.ResumeLayout(false);
			pnlSchedulingSubMenu.ResumeLayout(false);
			pnlGradeRecordSubMenu.ResumeLayout(false);
			pnlManageDataSubMenu.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)picProfile).EndInit();
			panel3.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
        private Panel panel2;
        private PictureBox picProfile;
        private Label lbUserName;
        private Label label2;
        private Button btnGradeRecord;
        private Button btnScheduling;
        private Panel pnlNavigation;
        private Button button1;
        private Button button2;
        private Panel panel3;
        private Panel panel4;
        private Panel pnlFormLoader;
        private Panel pnlManageDataSubMenu;
        private Panel pnlGradeRecordSubMenu;
        private Panel pnlSchedulingSubMenu;
        private Button button5;
        private Button button4;
        private Button button3;
        private Panel pnlNavigationSubmenu;
        private Button btnGrades;
        private Button btnManageData;
        private Button btnDirections;
        private Button btnFaculties;
        private Button btnDepartments;
        private Button btnDisciplines;
        private Button btnStudents;
        private Button btnGroups;
        private Button btnTeachers;
    }
}
