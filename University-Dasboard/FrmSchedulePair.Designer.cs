namespace University_Dasboard
{
    partial class FrmSchedulePair
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnDelete = new Button();
            btnAdd = new Button();
            btnReset = new Button();
            lbDbSaveResult = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnSave = new Button();
            departmentBindingSource1 = new BindingSource(components);
            departmentBindingSource = new BindingSource(components);
            dgvSchedules = new DataGridView();
            userBindingSource1 = new BindingSource(components);
            userBindingSource = new BindingSource(components);
            label2 = new Label();
            comboBoxDayOfWeek = new ComboBox();
            label6 = new Label();
            comboBoxSchedule = new ComboBox();
            label7 = new Label();
            tbClassroomNumber = new TextBox();
            comboBoxTeacher = new ComboBox();
            tbNumberPair = new TextBox();
            dateTimePickerEndTime = new DateTimePicker();
            dateTimePickerStartTime = new DateTimePicker();
            label5 = new Label();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSchedules).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(158, 161, 178);
            label1.Location = new Point(12, 258);
            label1.Name = "label1";
            label1.Size = new Size(533, 29);
            label1.TabIndex = 1;
            label1.Text = "Составление расписания по дисциплине";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(158, 161, 178);
            label4.Location = new Point(12, 18);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 54;
            label4.Text = "Номер пары:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(158, 161, 178);
            label3.Location = new Point(12, 46);
            label3.Name = "label3";
            label3.Size = new Size(150, 20);
            label3.TabIndex = 52;
            label3.Text = "Преподаватель:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(0, 126, 249);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.FromArgb(24, 30, 54);
            btnDelete.Location = new Point(877, 599);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 42);
            btnDelete.TabIndex = 48;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 126, 249);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(24, 30, 54);
            btnAdd.Location = new Point(12, 189);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(108, 51);
            btnAdd.TabIndex = 49;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(0, 126, 249);
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.FromArgb(24, 30, 54);
            btnReset.Location = new Point(877, 551);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(88, 42);
            btnReset.TabIndex = 50;
            btnReset.Text = "Сбросить изменения";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // lbDbSaveResult
            // 
            lbDbSaveResult.AutoSize = true;
            lbDbSaveResult.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
            lbDbSaveResult.Location = new Point(569, 267);
            lbDbSaveResult.Name = "lbDbSaveResult";
            lbDbSaveResult.Size = new Size(302, 20);
            lbDbSaveResult.TabIndex = 45;
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
            lbDbSaveResult.Visible = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 126, 249);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.FromArgb(24, 30, 54);
            btnSave.Location = new Point(881, 290);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 42);
            btnSave.TabIndex = 47;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // dgvSchedules
            // 
            dgvSchedules.AllowUserToAddRows = false;
            dgvSchedules.AllowUserToDeleteRows = false;
            dgvSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedules.Location = new Point(12, 290);
            dgvSchedules.Name = "dgvSchedules";
            dgvSchedules.Size = new Size(859, 351);
            dgvSchedules.TabIndex = 51;
            dgvSchedules.CellFormatting += dgvTeacherConstraintList_CellFormatting;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(158, 161, 178);
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 43;
            label2.Text = "Расчасовка:";
            // 
            // comboBoxDayOfWeek
            // 
            comboBoxDayOfWeek.BackColor = Color.FromArgb(158, 161, 178);
            comboBoxDayOfWeek.FlatStyle = FlatStyle.Flat;
            comboBoxDayOfWeek.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            comboBoxDayOfWeek.ForeColor = Color.FromArgb(24, 30, 54);
            comboBoxDayOfWeek.FormattingEnabled = true;
            comboBoxDayOfWeek.Location = new Point(201, 112);
            comboBoxDayOfWeek.Name = "comboBoxDayOfWeek";
            comboBoxDayOfWeek.Size = new Size(290, 26);
            comboBoxDayOfWeek.TabIndex = 58;
            comboBoxDayOfWeek.SelectedIndexChanged += cbDayOfWeek_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(158, 161, 178);
            label6.Location = new Point(8, 114);
            label6.Name = "label6";
            label6.Size = new Size(125, 20);
            label6.TabIndex = 60;
            label6.Text = "День недели:";
            // 
            // comboBoxSchedule
            // 
            comboBoxSchedule.BackColor = Color.FromArgb(158, 161, 178);
            comboBoxSchedule.FlatStyle = FlatStyle.Flat;
            comboBoxSchedule.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            comboBoxSchedule.ForeColor = Color.FromArgb(24, 30, 54);
            comboBoxSchedule.FormattingEnabled = true;
            comboBoxSchedule.Location = new Point(201, 78);
            comboBoxSchedule.Name = "comboBoxSchedule";
            comboBoxSchedule.Size = new Size(290, 26);
            comboBoxSchedule.TabIndex = 61;
            comboBoxSchedule.SelectedIndexChanged += cbScheduleDiscipline_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(158, 161, 178);
            label7.Location = new Point(575, 36);
            label7.Name = "label7";
            label7.Size = new Size(90, 18);
            label7.TabIndex = 64;
            label7.Text = "Аудитория";
            // 
            // tbClassroomNumber
            // 
            tbClassroomNumber.BackColor = Color.FromArgb(158, 161, 178);
            tbClassroomNumber.BorderStyle = BorderStyle.FixedSingle;
            tbClassroomNumber.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbClassroomNumber.ForeColor = Color.FromArgb(24, 30, 54);
            tbClassroomNumber.Location = new Point(762, 30);
            tbClassroomNumber.Name = "tbClassroomNumber";
            tbClassroomNumber.Size = new Size(204, 24);
            tbClassroomNumber.TabIndex = 63;
            // 
            // comboBoxTeacher
            // 
            comboBoxTeacher.BackColor = Color.FromArgb(158, 161, 178);
            comboBoxTeacher.FlatStyle = FlatStyle.Flat;
            comboBoxTeacher.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            comboBoxTeacher.ForeColor = Color.FromArgb(24, 30, 54);
            comboBoxTeacher.FormattingEnabled = true;
            comboBoxTeacher.Location = new Point(201, 44);
            comboBoxTeacher.Name = "comboBoxTeacher";
            comboBoxTeacher.Size = new Size(290, 26);
            comboBoxTeacher.TabIndex = 65;
            comboBoxTeacher.SelectedIndexChanged += cbTeacher_SelectedIndexChanged;
            // 
            // tbNumberPair
            // 
            tbNumberPair.BackColor = Color.FromArgb(158, 161, 178);
            tbNumberPair.BorderStyle = BorderStyle.FixedSingle;
            tbNumberPair.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbNumberPair.ForeColor = Color.FromArgb(24, 30, 54);
            tbNumberPair.Location = new Point(201, 14);
            tbNumberPair.Name = "tbNumberPair";
            tbNumberPair.Size = new Size(290, 24);
            tbNumberPair.TabIndex = 71;
            // 
            // dateTimePickerEndTime
            // 
            dateTimePickerEndTime.CustomFormat = "HH:mm";
            dateTimePickerEndTime.Format = DateTimePickerFormat.Time;
            dateTimePickerEndTime.Location = new Point(762, 113);
            dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            dateTimePickerEndTime.ShowUpDown = true;
            dateTimePickerEndTime.Size = new Size(203, 23);
            dateTimePickerEndTime.TabIndex = 75;
            // 
            // dateTimePickerStartTime
            // 
            dateTimePickerStartTime.CustomFormat = "HH:mm";
            dateTimePickerStartTime.Format = DateTimePickerFormat.Time;
            dateTimePickerStartTime.Location = new Point(762, 75);
            dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            dateTimePickerStartTime.ShowUpDown = true;
            dateTimePickerStartTime.Size = new Size(203, 23);
            dateTimePickerStartTime.TabIndex = 74;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(158, 161, 178);
            label5.Location = new Point(575, 113);
            label5.Name = "label5";
            label5.Size = new Size(153, 20);
            label5.TabIndex = 72;
            label5.Text = "Окончание пары:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(158, 161, 178);
            label11.Location = new Point(575, 78);
            label11.Name = "label11";
            label11.Size = new Size(125, 20);
            label11.TabIndex = 73;
            label11.Text = "Начало пары:";
            // 
            // FrmSchedulePair
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(980, 653);
            Controls.Add(dateTimePickerEndTime);
            Controls.Add(dateTimePickerStartTime);
            Controls.Add(label5);
            Controls.Add(label11);
            Controls.Add(tbNumberPair);
            Controls.Add(comboBoxTeacher);
            Controls.Add(label7);
            Controls.Add(tbClassroomNumber);
            Controls.Add(comboBoxSchedule);
            Controls.Add(label6);
            Controls.Add(comboBoxDayOfWeek);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnReset);
            Controls.Add(lbDbSaveResult);
            Controls.Add(btnSave);
            Controls.Add(dgvSchedules);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmSchedulePair";
            Text = "frmScheduling";
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSchedules).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
		private Label label4;
		private Label label3;
		private Button btnDelete;
		private Button btnAdd;
		private Button btnReset;
		private Label lbDbSaveResult;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private Button btnSave;
		private BindingSource departmentBindingSource1;
		private BindingSource departmentBindingSource;
		private DataGridView dgvSchedules;
		private BindingSource userBindingSource1;
		private BindingSource userBindingSource;
		private Label label2;
		private ComboBox comboBoxDayOfWeek;
		private Label label6;
		private ComboBox comboBoxSchedule;
        private Label label7;
        private TextBox tbClassroomNumber;
        private ComboBox comboBoxTeacher;
        private TextBox tbNumberPair;
        private DateTimePicker dateTimePickerEndTime;
        private DateTimePicker dateTimePickerStartTime;
        private Label label5;
        private Label label11;
    }
}