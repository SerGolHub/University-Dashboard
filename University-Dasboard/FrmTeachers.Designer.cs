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
			components = new System.ComponentModel.Container();
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
			dgvTeacherList = new DataGridView();
			teacherBindingSource = new BindingSource(components);
			btnDelete = new Button();
			btnReset = new Button();
			btnSave = new Button();
			lbDbSaveResult = new Label();
			label9 = new Label();
			dtpHireDate = new DateTimePicker();
			cbDepartment = new ComboBox();
			cbStatus = new ComboBox();
			Id = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			PhoneNumber = new DataGridViewTextBoxColumn();
			Email = new DataGridViewTextBoxColumn();
			hireDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			degreeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			subjectsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			departmentIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			departmentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			schedulesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			constraintsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			Department = new DataGridViewComboBoxColumn();
			((System.ComponentModel.ISupportInitialize)dgvTeacherList).BeginInit();
			((System.ComponentModel.ISupportInitialize)teacherBindingSource).BeginInit();
			SuspendLayout();
			// 
			// btnAdd
			// 
			btnAdd.BackColor = Color.FromArgb(0, 126, 249);
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = FlatStyle.Flat;
			btnAdd.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnAdd.ForeColor = Color.FromArgb(24, 30, 54);
			btnAdd.Location = new Point(419, 184);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(116, 49);
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
			tbFullName.Location = new Point(98, 24);
			tbFullName.Name = "tbFullName";
			tbFullName.Size = new Size(282, 24);
			tbFullName.TabIndex = 20;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(158, 161, 178);
			label2.Location = new Point(10, 58);
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
			label1.Location = new Point(12, 28);
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
			label3.Location = new Point(12, 88);
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
			label4.Location = new Point(12, 117);
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
			label5.Location = new Point(10, 146);
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
			label7.Location = new Point(10, 178);
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
			label8.Location = new Point(12, 213);
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
			cbDegree.Location = new Point(262, 111);
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
			tbPhoneNumber.Location = new Point(195, 54);
			tbPhoneNumber.Name = "tbPhoneNumber";
			tbPhoneNumber.Size = new Size(185, 24);
			tbPhoneNumber.TabIndex = 20;
			tbPhoneNumber.KeyPress += tbPhoneNumber_KeyPress;
			// 
			// tbEmail
			// 
			tbEmail.BackColor = Color.FromArgb(158, 161, 178);
			tbEmail.BorderStyle = BorderStyle.FixedSingle;
			tbEmail.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			tbEmail.ForeColor = Color.FromArgb(24, 30, 54);
			tbEmail.Location = new Point(195, 84);
			tbEmail.Name = "tbEmail";
			tbEmail.Size = new Size(185, 24);
			tbEmail.TabIndex = 20;
			// 
			// dgvTeacherList
			// 
			dgvTeacherList.AllowUserToAddRows = false;
			dgvTeacherList.AllowUserToDeleteRows = false;
			dgvTeacherList.AutoGenerateColumns = false;
			dgvTeacherList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvTeacherList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvTeacherList.Columns.AddRange(new DataGridViewColumn[] { Id, nameDataGridViewTextBoxColumn, PhoneNumber, Email, hireDateDataGridViewTextBoxColumn, degreeDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, subjectsDataGridViewTextBoxColumn, departmentIdDataGridViewTextBoxColumn, departmentDataGridViewTextBoxColumn, schedulesDataGridViewTextBoxColumn, constraintsDataGridViewTextBoxColumn, Department });
			dgvTeacherList.DataSource = teacherBindingSource;
			dgvTeacherList.Location = new Point(12, 302);
			dgvTeacherList.Name = "dgvTeacherList";
			dgvTeacherList.Size = new Size(862, 339);
			dgvTeacherList.TabIndex = 28;
			dgvTeacherList.CellClick += dgvTeacherList_CellClick;
			dgvTeacherList.CellValueChanged += dgvTeacherList_CellValueChanged;
			// 
			// teacherBindingSource
			// 
			teacherBindingSource.DataSource = typeof(Database.Models.Teacher);
			// 
			// btnDelete
			// 
			btnDelete.BackColor = Color.FromArgb(0, 126, 249);
			btnDelete.FlatAppearance.BorderSize = 0;
			btnDelete.FlatStyle = FlatStyle.Flat;
			btnDelete.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnDelete.ForeColor = Color.FromArgb(24, 30, 54);
			btnDelete.Location = new Point(880, 599);
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
			btnReset.Location = new Point(880, 551);
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
			btnSave.Location = new Point(880, 302);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(88, 42);
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
			lbDbSaveResult.Location = new Point(572, 280);
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
			label9.Location = new Point(10, 270);
			label9.Name = "label9";
			label9.Size = new Size(320, 29);
			label9.TabIndex = 24;
			label9.Text = "Список преподавателей";
			// 
			// dtpHireDate
			// 
			dtpHireDate.Location = new Point(233, 143);
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
			cbDepartment.Location = new Point(171, 172);
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
			cbStatus.Location = new Point(171, 207);
			cbStatus.Name = "cbStatus";
			cbStatus.Size = new Size(209, 26);
			cbStatus.TabIndex = 36;
			cbStatus.Text = "Статус";
			// 
			// Id
			// 
			Id.DataPropertyName = "Id";
			Id.HeaderText = "Id";
			Id.Name = "Id";
			Id.Visible = false;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn.HeaderText = "ФИО";
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			// 
			// PhoneNumber
			// 
			PhoneNumber.DataPropertyName = "PhoneNumber";
			PhoneNumber.HeaderText = "Телефон";
			PhoneNumber.Name = "PhoneNumber";
			// 
			// Email
			// 
			Email.DataPropertyName = "Email";
			Email.HeaderText = "Почта";
			Email.Name = "Email";
			// 
			// hireDateDataGridViewTextBoxColumn
			// 
			hireDateDataGridViewTextBoxColumn.DataPropertyName = "HireDate";
			hireDateDataGridViewTextBoxColumn.HeaderText = "Дата найма";
			hireDateDataGridViewTextBoxColumn.Name = "hireDateDataGridViewTextBoxColumn";
			// 
			// degreeDataGridViewTextBoxColumn
			// 
			degreeDataGridViewTextBoxColumn.DataPropertyName = "Degree";
			degreeDataGridViewTextBoxColumn.HeaderText = "Должность";
			degreeDataGridViewTextBoxColumn.Name = "degreeDataGridViewTextBoxColumn";
			// 
			// statusDataGridViewTextBoxColumn
			// 
			statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
			statusDataGridViewTextBoxColumn.HeaderText = "Статус";
			statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
			// 
			// subjectsDataGridViewTextBoxColumn
			// 
			subjectsDataGridViewTextBoxColumn.DataPropertyName = "Subjects";
			subjectsDataGridViewTextBoxColumn.HeaderText = "Subjects";
			subjectsDataGridViewTextBoxColumn.Name = "subjectsDataGridViewTextBoxColumn";
			subjectsDataGridViewTextBoxColumn.Visible = false;
			// 
			// departmentIdDataGridViewTextBoxColumn
			// 
			departmentIdDataGridViewTextBoxColumn.DataPropertyName = "DepartmentId";
			departmentIdDataGridViewTextBoxColumn.HeaderText = "DepartmentId";
			departmentIdDataGridViewTextBoxColumn.Name = "departmentIdDataGridViewTextBoxColumn";
			departmentIdDataGridViewTextBoxColumn.Visible = false;
			// 
			// departmentDataGridViewTextBoxColumn
			// 
			departmentDataGridViewTextBoxColumn.DataPropertyName = "Department";
			departmentDataGridViewTextBoxColumn.HeaderText = "Department";
			departmentDataGridViewTextBoxColumn.Name = "departmentDataGridViewTextBoxColumn";
			departmentDataGridViewTextBoxColumn.Visible = false;
			// 
			// schedulesDataGridViewTextBoxColumn
			// 
			schedulesDataGridViewTextBoxColumn.DataPropertyName = "Schedules";
			schedulesDataGridViewTextBoxColumn.HeaderText = "Schedules";
			schedulesDataGridViewTextBoxColumn.Name = "schedulesDataGridViewTextBoxColumn";
			schedulesDataGridViewTextBoxColumn.Visible = false;
			// 
			// constraintsDataGridViewTextBoxColumn
			// 
			constraintsDataGridViewTextBoxColumn.DataPropertyName = "Constraints";
			constraintsDataGridViewTextBoxColumn.HeaderText = "Constraints";
			constraintsDataGridViewTextBoxColumn.Name = "constraintsDataGridViewTextBoxColumn";
			constraintsDataGridViewTextBoxColumn.Visible = false;
			// 
			// Department
			// 
			Department.HeaderText = "Кафедра";
			Department.Name = "Department";
			// 
			// FrmTeachers
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(980, 653);
			Controls.Add(cbStatus);
			Controls.Add(cbDepartment);
			Controls.Add(dtpHireDate);
			Controls.Add(dgvTeacherList);
			Controls.Add(btnDelete);
			Controls.Add(btnReset);
			Controls.Add(btnSave);
			Controls.Add(lbDbSaveResult);
			Controls.Add(label9);
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
			((System.ComponentModel.ISupportInitialize)teacherBindingSource).EndInit();
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
        private DataGridView dgvTeacherList;
        private Button btnDelete;
        private Button btnReset;
        private Button btnSave;
        private Label lbDbSaveResult;
        private Label label9;
        private DateTimePicker dtpHireDate;
        private ComboBox cbDepartment;
        private ComboBox cbStatus;
		private BindingSource teacherBindingSource;
		private DataGridViewTextBoxColumn Id;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn PhoneNumber;
		private DataGridViewTextBoxColumn Email;
		private DataGridViewTextBoxColumn hireDateDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn degreeDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn subjectsDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn departmentIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn schedulesDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn constraintsDataGridViewTextBoxColumn;
		private DataGridViewComboBoxColumn Department;
	}
}