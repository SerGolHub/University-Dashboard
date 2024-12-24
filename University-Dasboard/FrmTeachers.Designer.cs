namespace University_Dasboard
{
    partial class FrmTeachers
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
            btnAdd = new Button();
            tbFullName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            cbDegree = new ComboBox();
            tbPhoneNumber = new TextBox();
            tbEmail = new TextBox();
            comboBoxTeachers = new ComboBox();
            dgvTeacherList = new DataGridView();
            btnDelete = new Button();
            btnReset = new Button();
            btnSave = new Button();
            lbDbSaveResult = new Label();
            label9 = new Label();
            checkedListBoxDays = new CheckedListBox();
            dtpHireDate = new DateTimePicker();
            cbDepartment = new ComboBox();
            cbStatus = new ComboBox();
            label10 = new Label();
            dateTimePickerStartTime = new DateTimePicker();
            dateTimePickerEndTime = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvTeacherList).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 126, 249);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(24, 30, 54);
            btnAdd.Location = new Point(230, 587);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 42);
            btnAdd.TabIndex = 21;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // tbFullName
            // 
            tbFullName.BackColor = Color.FromArgb(158, 161, 178);
            tbFullName.BorderStyle = BorderStyle.FixedSingle;
            tbFullName.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbFullName.ForeColor = Color.FromArgb(24, 30, 54);
            tbFullName.Location = new Point(73, 25);
            tbFullName.Name = "tbFullName";
            tbFullName.Size = new Size(282, 24);
            tbFullName.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(158, 161, 178);
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(161, 20);
            label2.TabIndex = 19;
            label2.Text = "Номер телефона:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(158, 161, 178);
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 19;
            label1.Text = "ФИО:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(158, 161, 178);
            label3.Location = new Point(12, 96);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 19;
            label3.Text = "Почта:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(158, 161, 178);
            label4.Location = new Point(12, 132);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 19;
            label4.Text = "Степень:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(158, 161, 178);
            label5.Location = new Point(12, 172);
            label5.Name = "label5";
            label5.Size = new Size(212, 20);
            label5.TabIndex = 19;
            label5.Text = "Дата приёма на работу:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(158, 161, 178);
            label7.Location = new Point(432, 67);
            label7.Name = "label7";
            label7.Size = new Size(93, 20);
            label7.TabIndex = 19;
            label7.Text = "Кафедра:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(158, 161, 178);
            label8.Location = new Point(432, 113);
            label8.Name = "label8";
            label8.Size = new Size(73, 20);
            label8.TabIndex = 19;
            label8.Text = "Статус:";
            // 
            // cbDegree
            // 
            cbDegree.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbDegree.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbDegree.BackColor = Color.FromArgb(158, 161, 178);
            cbDegree.FlatStyle = FlatStyle.Flat;
            cbDegree.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            cbDegree.ForeColor = Color.FromArgb(24, 30, 54);
            cbDegree.FormattingEnabled = true;
            cbDegree.Location = new Point(114, 130);
            cbDegree.Name = "cbDegree";
            cbDegree.Size = new Size(118, 26);
            cbDegree.TabIndex = 22;
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.BackColor = Color.FromArgb(158, 161, 178);
            tbPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            tbPhoneNumber.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbPhoneNumber.ForeColor = Color.FromArgb(24, 30, 54);
            tbPhoneNumber.Location = new Point(179, 63);
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(185, 24);
            tbPhoneNumber.TabIndex = 20;
            // 
            // tbEmail
            // 
            tbEmail.BackColor = Color.FromArgb(158, 161, 178);
            tbEmail.BorderStyle = BorderStyle.FixedSingle;
            tbEmail.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbEmail.ForeColor = Color.FromArgb(24, 30, 54);
            tbEmail.Location = new Point(97, 96);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(185, 24);
            tbEmail.TabIndex = 20;
            // 
            // comboBoxTeachers
            // 
            comboBoxTeachers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxTeachers.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxTeachers.BackColor = Color.FromArgb(158, 161, 178);
            comboBoxTeachers.FlatStyle = FlatStyle.Flat;
            comboBoxTeachers.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            comboBoxTeachers.ForeColor = Color.FromArgb(24, 30, 54);
            comboBoxTeachers.FormattingEnabled = true;
            comboBoxTeachers.Items.AddRange(new object[] { "Да", "Нет" });
            comboBoxTeachers.Location = new Point(701, 249);
            comboBoxTeachers.Name = "comboBoxTeachers";
            comboBoxTeachers.Size = new Size(234, 26);
            comboBoxTeachers.TabIndex = 22;
            comboBoxTeachers.Text = "Выберите преподавателя";
            // 
            // dgvTeacherList
            // 
            dgvTeacherList.AllowUserToAddRows = false;
            dgvTeacherList.AllowUserToDeleteRows = false;
            dgvTeacherList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTeacherList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeacherList.Location = new Point(12, 244);
            dgvTeacherList.Name = "dgvTeacherList";
            dgvTeacherList.Size = new Size(648, 254);
            dgvTeacherList.TabIndex = 28;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(0, 126, 249);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.FromArgb(24, 30, 54);
            btnDelete.Location = new Point(12, 587);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 42);
            btnDelete.TabIndex = 25;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(0, 126, 249);
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.FromArgb(24, 30, 54);
            btnReset.Location = new Point(114, 587);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(88, 42);
            btnReset.TabIndex = 26;
            btnReset.Text = "Сбросить изменения";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 126, 249);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.FromArgb(24, 30, 54);
            btnSave.Location = new Point(401, 563);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 66);
            btnSave.TabIndex = 27;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lbDbSaveResult
            // 
            lbDbSaveResult.AutoSize = true;
            lbDbSaveResult.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
            lbDbSaveResult.Location = new Point(448, 172);
            lbDbSaveResult.Name = "lbDbSaveResult";
            lbDbSaveResult.Size = new Size(302, 20);
            lbDbSaveResult.TabIndex = 23;
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
            lbDbSaveResult.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(158, 161, 178);
            label9.Location = new Point(10, 211);
            label9.Name = "label9";
            label9.Size = new Size(320, 29);
            label9.TabIndex = 24;
            label9.Text = "Список преподавателей";
            // 
            // checkedListBoxDays
            // 
            checkedListBoxDays.FormattingEnabled = true;
            checkedListBoxDays.Location = new Point(767, 511);
            checkedListBoxDays.Name = "checkedListBoxDays";
            checkedListBoxDays.Size = new Size(168, 130);
            checkedListBoxDays.TabIndex = 29;
            // 
            // dtpHireDate
            // 
            dtpHireDate.Location = new Point(230, 172);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(147, 23);
            dtpHireDate.TabIndex = 33;
            // 
            // cbDepartment
            // 
            cbDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbDepartment.BackColor = Color.FromArgb(158, 161, 178);
            cbDepartment.FlatStyle = FlatStyle.Flat;
            cbDepartment.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            cbDepartment.ForeColor = Color.FromArgb(24, 30, 54);
            cbDepartment.FormattingEnabled = true;
            cbDepartment.Location = new Point(566, 63);
            cbDepartment.Name = "cbDepartment";
            cbDepartment.Size = new Size(209, 26);
            cbDepartment.TabIndex = 35;
            cbDepartment.Text = "Выберите кафедру";
            cbDepartment.SelectedIndexChanged += cbDepartment_SelectedIndexChanged;
            // 
            // cbStatus
            // 
            cbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbStatus.BackColor = Color.FromArgb(158, 161, 178);
            cbStatus.FlatStyle = FlatStyle.Flat;
            cbStatus.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            cbStatus.ForeColor = Color.FromArgb(24, 30, 54);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(566, 107);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(209, 26);
            cbStatus.TabIndex = 36;
            cbStatus.Text = "Статус";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(158, 161, 178);
            label10.Location = new Point(767, 474);
            label10.Name = "label10";
            label10.Size = new Size(73, 20);
            label10.TabIndex = 37;
            label10.Text = "Статус:";
            // 
            // dateTimePickerStartTime
            // 
            dateTimePickerStartTime.Location = new Point(701, 339);
            dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            dateTimePickerStartTime.Size = new Size(200, 23);
            dateTimePickerStartTime.TabIndex = 31;
            // 
            // dateTimePickerEndTime
            // 
            dateTimePickerEndTime.Location = new Point(701, 398);
            dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            dateTimePickerEndTime.Size = new Size(200, 23);
            dateTimePickerEndTime.TabIndex = 32;
            // 
            // FrmTeachers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(980, 653);
            Controls.Add(label10);
            Controls.Add(cbStatus);
            Controls.Add(cbDepartment);
            Controls.Add(dtpHireDate);
            Controls.Add(dateTimePickerEndTime);
            Controls.Add(dateTimePickerStartTime);
            Controls.Add(checkedListBoxDays);
            Controls.Add(dgvTeacherList);
            Controls.Add(btnDelete);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(lbDbSaveResult);
            Controls.Add(label9);
            Controls.Add(comboBoxTeachers);
            Controls.Add(cbDegree);
            Controls.Add(btnAdd);
            Controls.Add(tbEmail);
            Controls.Add(tbPhoneNumber);
            Controls.Add(tbFullName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTeachers";
            Text = "frmStudentList";
            ((System.ComponentModel.ISupportInitialize)dgvTeacherList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private TextBox tbFullName;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private ComboBox cbDegree;
        private TextBox tbPhoneNumber;
        private TextBox tbEmail;
        private ComboBox comboBoxTeachers;
        private DataGridView dgvTeacherList;
        private Button btnDelete;
        private Button btnReset;
        private Button btnSave;
        private Label lbDbSaveResult;
        private Label label9;
        private CheckedListBox checkedListBoxDays;
        private DateTimePicker dtpHireDate;
        private ComboBox cbDepartment;
        private ComboBox cbStatus;
        private Label label10;
        private DateTimePicker dateTimePickerStartTime;
        private DateTimePicker dateTimePickerEndTime;
    }
}