namespace University_Dasboard
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
            pnlReportsSubMenu = new Panel();
            btnExport = new Button();
            btnStudentCard = new Button();
            btnAboutGradeRecords = new Button();
            btnReports = new Button();
            pnlNavigation = new Panel();
            pnlSchedulingSubMenu = new Panel();
            btnReportCheckLesson = new Button();
            btnTeacherConstraints = new Button();
            btnSchedulingTeachers = new Button();
            btnSchedulingDisciplines = new Button();
            btnAcademicHours = new Button();
            btnScheduling = new Button();
            pnlGradeRecordSubMenu = new Panel();
            pnlNavigationSubmenu = new Panel();
            btnGrades = new Button();
            btnGradeRecord = new Button();
            pnlManageDataSubMenu = new Panel();
            button1 = new Button();
            btnTeachers = new Button();
            btnStudents = new Button();
            btnGroups = new Button();
            btnSubjects = new Button();
            btnDirections = new Button();
            btnDepartments = new Button();
            btnFaculties = new Button();
            btnManageData = new Button();
            panel2 = new Panel();
            picProfile = new PictureBox();
            panel4 = new Panel();
            label2 = new Label();
            lbUserName = new Label();
            btnClose = new Button();
            btnMinimize = new Button();
            panel3 = new Panel();
            pnlFormLoader = new Panel();
            panel1.SuspendLayout();
            pnlReportsSubMenu.SuspendLayout();
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
            panel1.Controls.Add(pnlReportsSubMenu);
            panel1.Controls.Add(btnReports);
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
            panel1.Size = new Size(187, 691);
            panel1.TabIndex = 0;
            // 
            // pnlReportsSubMenu
            // 
            pnlReportsSubMenu.Controls.Add(btnExport);
            pnlReportsSubMenu.Controls.Add(btnStudentCard);
            pnlReportsSubMenu.Controls.Add(btnAboutGradeRecords);
            pnlReportsSubMenu.Dock = DockStyle.Top;
            pnlReportsSubMenu.Location = new Point(0, 1152);
            pnlReportsSubMenu.Name = "pnlReportsSubMenu";
            pnlReportsSubMenu.Size = new Size(170, 208);
            pnlReportsSubMenu.TabIndex = 8;
            pnlReportsSubMenu.Visible = false;
            // 
            // btnExport
            // 
            btnExport.Dock = DockStyle.Top;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.ForeColor = Color.FromArgb(0, 126, 249);
            btnExport.ImageAlign = ContentAlignment.MiddleRight;
            btnExport.Location = new Point(0, 128);
            btnExport.Name = "btnExport";
            btnExport.Padding = new Padding(20, 0, 15, 0);
            btnExport.Size = new Size(170, 64);
            btnExport.TabIndex = 4;
            btnExport.Text = "Экспорт";
            btnExport.TextAlign = ContentAlignment.MiddleLeft;
            btnExport.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnStudentCard
            // 
            btnStudentCard.Dock = DockStyle.Top;
            btnStudentCard.FlatAppearance.BorderSize = 0;
            btnStudentCard.FlatStyle = FlatStyle.Flat;
            btnStudentCard.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStudentCard.ForeColor = Color.FromArgb(0, 126, 249);
            btnStudentCard.ImageAlign = ContentAlignment.MiddleRight;
            btnStudentCard.Location = new Point(0, 64);
            btnStudentCard.Name = "btnStudentCard";
            btnStudentCard.Padding = new Padding(20, 0, 15, 0);
            btnStudentCard.Size = new Size(170, 64);
            btnStudentCard.TabIndex = 3;
            btnStudentCard.Text = "Карточка студента";
            btnStudentCard.TextAlign = ContentAlignment.MiddleLeft;
            btnStudentCard.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnStudentCard.UseVisualStyleBackColor = true;
            btnStudentCard.Click += btnStudentCard_Click;
            // 
            // btnAboutGradeRecords
            // 
            btnAboutGradeRecords.Dock = DockStyle.Top;
            btnAboutGradeRecords.FlatAppearance.BorderSize = 0;
            btnAboutGradeRecords.FlatStyle = FlatStyle.Flat;
            btnAboutGradeRecords.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAboutGradeRecords.ForeColor = Color.FromArgb(0, 126, 249);
            btnAboutGradeRecords.ImageAlign = ContentAlignment.MiddleRight;
            btnAboutGradeRecords.Location = new Point(0, 0);
            btnAboutGradeRecords.Name = "btnAboutGradeRecords";
            btnAboutGradeRecords.Padding = new Padding(20, 0, 15, 0);
            btnAboutGradeRecords.Size = new Size(170, 64);
            btnAboutGradeRecords.TabIndex = 2;
            btnAboutGradeRecords.Text = "Об успеваемости";
            btnAboutGradeRecords.TextAlign = ContentAlignment.MiddleLeft;
            btnAboutGradeRecords.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAboutGradeRecords.UseVisualStyleBackColor = true;
            btnAboutGradeRecords.Click += btnAboutGradeRecords_Click;
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReports.ForeColor = Color.FromArgb(0, 126, 249);
            btnReports.ImageAlign = ContentAlignment.MiddleRight;
            btnReports.Location = new Point(0, 1088);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(5, 0, 15, 0);
            btnReports.Size = new Size(170, 64);
            btnReports.TabIndex = 7;
            btnReports.Text = "Отчёты";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
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
            pnlSchedulingSubMenu.AutoScroll = true;
            pnlSchedulingSubMenu.Controls.Add(btnReportCheckLesson);
            pnlSchedulingSubMenu.Controls.Add(btnTeacherConstraints);
            pnlSchedulingSubMenu.Controls.Add(btnSchedulingTeachers);
            pnlSchedulingSubMenu.Controls.Add(btnSchedulingDisciplines);
            pnlSchedulingSubMenu.Controls.Add(btnAcademicHours);
            pnlSchedulingSubMenu.Dock = DockStyle.Top;
            pnlSchedulingSubMenu.Location = new Point(0, 880);
            pnlSchedulingSubMenu.Name = "pnlSchedulingSubMenu";
            pnlSchedulingSubMenu.Size = new Size(170, 208);
            pnlSchedulingSubMenu.TabIndex = 4;
            pnlSchedulingSubMenu.Visible = false;
            // 
            // btnReportCheckLesson
            // 
            btnReportCheckLesson.BackColor = Color.FromArgb(24, 30, 54);
            btnReportCheckLesson.Dock = DockStyle.Top;
            btnReportCheckLesson.FlatAppearance.BorderSize = 0;
            btnReportCheckLesson.FlatStyle = FlatStyle.Flat;
            btnReportCheckLesson.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportCheckLesson.ForeColor = Color.FromArgb(0, 126, 249);
            btnReportCheckLesson.ImageAlign = ContentAlignment.MiddleRight;
            btnReportCheckLesson.Location = new Point(0, 256);
            btnReportCheckLesson.Name = "btnReportCheckLesson";
            btnReportCheckLesson.Padding = new Padding(20, 0, 15, 0);
            btnReportCheckLesson.Size = new Size(153, 64);
            btnReportCheckLesson.TabIndex = 15;
            btnReportCheckLesson.Text = "Отчёт по проверкам";
            btnReportCheckLesson.TextAlign = ContentAlignment.MiddleLeft;
            btnReportCheckLesson.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnReportCheckLesson.UseVisualStyleBackColor = false;
            btnReportCheckLesson.Click += btnReportCheckLesson_Click;
            // 
            // btnTeacherConstraints
            // 
            btnTeacherConstraints.BackColor = Color.FromArgb(24, 30, 54);
            btnTeacherConstraints.Dock = DockStyle.Top;
            btnTeacherConstraints.FlatAppearance.BorderSize = 0;
            btnTeacherConstraints.FlatStyle = FlatStyle.Flat;
            btnTeacherConstraints.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTeacherConstraints.ForeColor = Color.FromArgb(0, 126, 249);
            btnTeacherConstraints.ImageAlign = ContentAlignment.MiddleRight;
            btnTeacherConstraints.Location = new Point(0, 192);
            btnTeacherConstraints.Name = "btnTeacherConstraints";
            btnTeacherConstraints.Padding = new Padding(20, 0, 15, 0);
            btnTeacherConstraints.Size = new Size(153, 64);
            btnTeacherConstraints.TabIndex = 15;
            btnTeacherConstraints.Text = "Ограничения преподавателей";
            btnTeacherConstraints.TextAlign = ContentAlignment.MiddleLeft;
            btnTeacherConstraints.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnTeacherConstraints.UseVisualStyleBackColor = false;
            btnTeacherConstraints.Click += btnTeacherConstraints_Click;
            // 
            // btnSchedulingTeachers
            // 
            btnSchedulingTeachers.Dock = DockStyle.Top;
            btnSchedulingTeachers.FlatAppearance.BorderSize = 0;
            btnSchedulingTeachers.FlatStyle = FlatStyle.Flat;
            btnSchedulingTeachers.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSchedulingTeachers.ForeColor = Color.FromArgb(0, 126, 249);
            btnSchedulingTeachers.ImageAlign = ContentAlignment.MiddleRight;
            btnSchedulingTeachers.Location = new Point(0, 128);
            btnSchedulingTeachers.Name = "btnSchedulingTeachers";
            btnSchedulingTeachers.Padding = new Padding(20, 0, 15, 0);
            btnSchedulingTeachers.Size = new Size(153, 64);
            btnSchedulingTeachers.TabIndex = 4;
            btnSchedulingTeachers.Text = "По преподавателю";
            btnSchedulingTeachers.TextAlign = ContentAlignment.MiddleLeft;
            btnSchedulingTeachers.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSchedulingTeachers.UseVisualStyleBackColor = true;
            btnSchedulingTeachers.Click += btnbtnSchedulingTeachers_Click;
            // 
            // btnSchedulingDisciplines
            // 
            btnSchedulingDisciplines.Dock = DockStyle.Top;
            btnSchedulingDisciplines.FlatAppearance.BorderSize = 0;
            btnSchedulingDisciplines.FlatStyle = FlatStyle.Flat;
            btnSchedulingDisciplines.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSchedulingDisciplines.ForeColor = Color.FromArgb(0, 126, 249);
            btnSchedulingDisciplines.ImageAlign = ContentAlignment.MiddleRight;
            btnSchedulingDisciplines.Location = new Point(0, 64);
            btnSchedulingDisciplines.Name = "btnSchedulingDisciplines";
            btnSchedulingDisciplines.Padding = new Padding(20, 0, 15, 0);
            btnSchedulingDisciplines.Size = new Size(153, 64);
            btnSchedulingDisciplines.TabIndex = 3;
            btnSchedulingDisciplines.Text = "По дисциплине";
            btnSchedulingDisciplines.TextAlign = ContentAlignment.MiddleLeft;
            btnSchedulingDisciplines.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSchedulingDisciplines.UseVisualStyleBackColor = true;
            btnSchedulingDisciplines.Click += btnSchedulingDisciplines_Click;
            // 
            // btnAcademicHours
            // 
            btnAcademicHours.Dock = DockStyle.Top;
            btnAcademicHours.FlatAppearance.BorderSize = 0;
            btnAcademicHours.FlatStyle = FlatStyle.Flat;
            btnAcademicHours.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAcademicHours.ForeColor = Color.FromArgb(0, 126, 249);
            btnAcademicHours.ImageAlign = ContentAlignment.MiddleRight;
            btnAcademicHours.Location = new Point(0, 0);
            btnAcademicHours.Name = "btnAcademicHours";
            btnAcademicHours.Padding = new Padding(20, 0, 15, 0);
            btnAcademicHours.Size = new Size(153, 64);
            btnAcademicHours.TabIndex = 2;
            btnAcademicHours.Text = "Академические часы";
            btnAcademicHours.TextAlign = ContentAlignment.MiddleLeft;
            btnAcademicHours.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAcademicHours.UseVisualStyleBackColor = true;
            btnAcademicHours.Click += btnAcademicHours_Click;
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
            btnGrades.Padding = new Padding(20, 0, 15, 0);
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
            pnlManageDataSubMenu.Controls.Add(button1);
            pnlManageDataSubMenu.Controls.Add(btnTeachers);
            pnlManageDataSubMenu.Controls.Add(btnStudents);
            pnlManageDataSubMenu.Controls.Add(btnGroups);
            pnlManageDataSubMenu.Controls.Add(btnSubjects);
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
            // button1
            // 
            button1.BackColor = Color.FromArgb(24, 30, 54);
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(0, 126, 249);
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(0, 448);
            button1.Name = "button1";
            button1.Padding = new Padding(20, 0, 15, 0);
            button1.Size = new Size(170, 100);
            button1.TabIndex = 15;
            button1.Text = "Преподаватели";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.TextImageRelation = TextImageRelation.TextBeforeImage;
            button1.UseVisualStyleBackColor = false;
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
            btnTeachers.Padding = new Padding(20, 0, 15, 0);
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
            btnStudents.Padding = new Padding(20, 0, 15, 0);
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
            btnGroups.Padding = new Padding(20, 0, 15, 0);
            btnGroups.Size = new Size(170, 64);
            btnGroups.TabIndex = 12;
            btnGroups.Text = "Группы";
            btnGroups.TextAlign = ContentAlignment.MiddleLeft;
            btnGroups.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnGroups.UseVisualStyleBackColor = false;
            btnGroups.Click += btnGroups_Click;
            // 
            // btnSubjects
            // 
            btnSubjects.BackColor = Color.FromArgb(24, 30, 54);
            btnSubjects.Dock = DockStyle.Top;
            btnSubjects.FlatAppearance.BorderSize = 0;
            btnSubjects.FlatStyle = FlatStyle.Flat;
            btnSubjects.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubjects.ForeColor = Color.FromArgb(0, 126, 249);
            btnSubjects.ImageAlign = ContentAlignment.MiddleRight;
            btnSubjects.Location = new Point(0, 192);
            btnSubjects.Name = "btnSubjects";
            btnSubjects.Padding = new Padding(20, 0, 15, 0);
            btnSubjects.Size = new Size(170, 64);
            btnSubjects.TabIndex = 10;
            btnSubjects.Text = "Дисциплины";
            btnSubjects.TextAlign = ContentAlignment.MiddleLeft;
            btnSubjects.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSubjects.UseVisualStyleBackColor = false;
            btnSubjects.Click += btnSubjects_Click;
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
            btnDirections.Padding = new Padding(20, 0, 15, 0);
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
            btnDepartments.Padding = new Padding(20, 0, 15, 0);
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
            btnFaculties.Padding = new Padding(20, 0, 15, 0);
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
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(0, 126, 249);
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(956, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 40);
            btnClose.TabIndex = 1;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMinimize.ForeColor = Color.FromArgb(0, 126, 249);
            btnMinimize.Image = Properties.Resources.button_minimize;
            btnMinimize.Location = new Point(916, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(40, 40);
            btnMinimize.TabIndex = 2;
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(24, 30, 54);
            panel3.Controls.Add(btnMinimize);
            panel3.Controls.Add(btnClose);
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
            pnlFormLoader.Size = new Size(996, 653);
            pnlFormLoader.TabIndex = 4;
            // 
            // FrmMainProgram
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1183, 691);
            Controls.Add(pnlFormLoader);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmMainProgram";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            pnlReportsSubMenu.ResumeLayout(false);
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
        private Button btnClose;
        private Button btnMinimize;
        private Panel panel3;
        private Panel panel4;
        private Panel pnlFormLoader;
        private Panel pnlManageDataSubMenu;
        private Panel pnlGradeRecordSubMenu;
        private Panel pnlSchedulingSubMenu;
        private Button btnSchedulingTeachers;
        private Button btnSchedulingDisciplines;
        private Button btnAcademicHours;
        private Panel pnlNavigationSubmenu;
        private Button btnGrades;
        private Button btnManageData;
        private Button btnDirections;
        private Button btnFaculties;
        private Button btnDepartments;
        private Button btnSubjects;
        private Button btnStudents;
        private Button btnGroups;
        private Button btnTeachers;
        private Button btnTeacherConstraints;
        private Button btnReportCheckLesson;
        private Button btnReports;
		private Panel pnlReportsSubMenu;
		private Button btnExport;
		private Button btnStudentCard;
		private Button btnAboutGradeRecords;
        private Button button1;
    }
}
