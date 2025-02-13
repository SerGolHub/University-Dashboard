﻿namespace University_Dasboard
{
    partial class FrmStudents
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
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			cbGroup = new ComboBox();
			cbFaculty = new ComboBox();
			cbDepartment = new ComboBox();
			tbEnrollmentNumber = new TextBox();
			dgvStudentList = new DataGridView();
			studentBindingSource = new BindingSource(components);
			btnDelete = new Button();
			btnReset = new Button();
			btnSave = new Button();
			lbDbSaveResult = new Label();
			label9 = new Label();
			label10 = new Label();
			cbDirection = new ComboBox();
			dateTimePicker1 = new DateTimePicker();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			Id = new DataGridViewTextBoxColumn();
			DgvCbGroup = new DataGridViewComboBoxColumn();
			IsExcellentStudent = new DataGridViewCheckBoxColumn();
			EnrollmentDate = new DataGridViewTextBoxColumn();
			EnrollmentNumber = new DataGridViewTextBoxColumn();
			groupIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			Group = new DataGridViewTextBoxColumn();
			marksDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dgvStudentList).BeginInit();
			((System.ComponentModel.ISupportInitialize)studentBindingSource).BeginInit();
			SuspendLayout();
			// 
			// btnAdd
			// 
			btnAdd.BackColor = Color.FromArgb(0, 126, 249);
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = FlatStyle.Flat;
			btnAdd.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnAdd.ForeColor = Color.FromArgb(24, 30, 54);
			btnAdd.Location = new Point(239, 200);
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
			label2.Location = new Point(12, 29);
			label2.Name = "label2";
			label2.Size = new Size(55, 20);
			label2.TabIndex = 19;
			label2.Text = "ФИО:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.ForeColor = Color.FromArgb(158, 161, 178);
			label3.Location = new Point(12, 157);
			label3.Name = "label3";
			label3.Size = new Size(72, 20);
			label3.TabIndex = 19;
			label3.Text = "Группа:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.FromArgb(158, 161, 178);
			label4.Location = new Point(12, 61);
			label4.Name = "label4";
			label4.Size = new Size(108, 20);
			label4.TabIndex = 19;
			label4.Text = "Факультет:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.ForeColor = Color.FromArgb(158, 161, 178);
			label5.Location = new Point(12, 93);
			label5.Name = "label5";
			label5.Size = new Size(93, 20);
			label5.TabIndex = 19;
			label5.Text = "Кафедра:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.ForeColor = Color.FromArgb(158, 161, 178);
			label6.Location = new Point(418, 26);
			label6.Name = "label6";
			label6.Size = new Size(173, 20);
			label6.TabIndex = 19;
			label6.Text = "Номер зачисления:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.ForeColor = Color.FromArgb(158, 161, 178);
			label7.Location = new Point(418, 63);
			label7.Name = "label7";
			label7.Size = new Size(161, 20);
			label7.TabIndex = 19;
			label7.Text = "Дата зачисления:";
			// 
			// cbGroup
			// 
			cbGroup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbGroup.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbGroup.BackColor = Color.FromArgb(158, 161, 178);
			cbGroup.FlatStyle = FlatStyle.Flat;
			cbGroup.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbGroup.ForeColor = Color.FromArgb(24, 30, 54);
			cbGroup.FormattingEnabled = true;
			cbGroup.Location = new Point(146, 151);
			cbGroup.Name = "cbGroup";
			cbGroup.Size = new Size(209, 26);
			cbGroup.TabIndex = 22;
			cbGroup.Text = "Выберите направление";
			cbGroup.SelectedIndexChanged += cbGroup_SelectedIndexChanged;
			// 
			// cbFaculty
			// 
			cbFaculty.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbFaculty.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbFaculty.BackColor = Color.FromArgb(158, 161, 178);
			cbFaculty.FlatStyle = FlatStyle.Flat;
			cbFaculty.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbFaculty.ForeColor = Color.FromArgb(24, 30, 54);
			cbFaculty.FormattingEnabled = true;
			cbFaculty.Location = new Point(146, 55);
			cbFaculty.Name = "cbFaculty";
			cbFaculty.Size = new Size(209, 26);
			cbFaculty.TabIndex = 22;
			cbFaculty.SelectedIndexChanged += cbFaculty_SelectedIndexChanged;
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
			cbDepartment.Location = new Point(146, 87);
			cbDepartment.Name = "cbDepartment";
			cbDepartment.Size = new Size(209, 26);
			cbDepartment.TabIndex = 22;
			cbDepartment.Text = "Выберите факультет";
			cbDepartment.SelectedIndexChanged += cbDepartment_SelectedIndexChanged;
			// 
			// tbEnrollmentNumber
			// 
			tbEnrollmentNumber.BackColor = Color.FromArgb(158, 161, 178);
			tbEnrollmentNumber.BorderStyle = BorderStyle.FixedSingle;
			tbEnrollmentNumber.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			tbEnrollmentNumber.ForeColor = Color.FromArgb(24, 30, 54);
			tbEnrollmentNumber.Location = new Point(597, 25);
			tbEnrollmentNumber.Name = "tbEnrollmentNumber";
			tbEnrollmentNumber.Size = new Size(185, 24);
			tbEnrollmentNumber.TabIndex = 20;
			// 
			// dgvStudentList
			// 
			dgvStudentList.AllowUserToAddRows = false;
			dgvStudentList.AllowUserToDeleteRows = false;
			dgvStudentList.AutoGenerateColumns = false;
			dgvStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvStudentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvStudentList.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, Id, DgvCbGroup, IsExcellentStudent, EnrollmentDate, EnrollmentNumber, groupIdDataGridViewTextBoxColumn, Group, marksDataGridViewTextBoxColumn });
			dgvStudentList.DataSource = studentBindingSource;
			dgvStudentList.Location = new Point(12, 322);
			dgvStudentList.Name = "dgvStudentList";
			dgvStudentList.Size = new Size(820, 319);
			dgvStudentList.TabIndex = 28;
			dgvStudentList.CellClick += dgvStudentList_CellClick;
			dgvStudentList.CellValueChanged += dgvStudentList_CellValueChanged;
			dgvStudentList.DataError += dgvStudentList_DataError;
			dgvStudentList.RowPostPaint += dgvStudentList_RowPostPaint;
			// 
			// studentBindingSource
			// 
			studentBindingSource.DataSource = typeof(Database.Models.Student);
			// 
			// btnDelete
			// 
			btnDelete.BackColor = Color.FromArgb(0, 126, 249);
			btnDelete.FlatAppearance.BorderSize = 0;
			btnDelete.FlatStyle = FlatStyle.Flat;
			btnDelete.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnDelete.ForeColor = Color.FromArgb(24, 30, 54);
			btnDelete.Location = new Point(838, 599);
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
			btnReset.Location = new Point(838, 551);
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
			btnSave.Location = new Point(838, 322);
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
			lbDbSaveResult.Location = new Point(530, 299);
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
			label9.Location = new Point(12, 287);
			label9.Name = "label9";
			label9.Size = new Size(237, 29);
			label9.TabIndex = 24;
			label9.Text = "Список студентов";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label10.ForeColor = Color.FromArgb(158, 161, 178);
			label10.Location = new Point(12, 125);
			label10.Name = "label10";
			label10.Size = new Size(128, 20);
			label10.TabIndex = 19;
			label10.Text = "Направление:";
			// 
			// cbDirection
			// 
			cbDirection.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbDirection.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbDirection.BackColor = Color.FromArgb(158, 161, 178);
			cbDirection.FlatStyle = FlatStyle.Flat;
			cbDirection.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbDirection.ForeColor = Color.FromArgb(24, 30, 54);
			cbDirection.FormattingEnabled = true;
			cbDirection.Location = new Point(146, 119);
			cbDirection.Name = "cbDirection";
			cbDirection.Size = new Size(209, 26);
			cbDirection.TabIndex = 22;
			cbDirection.Text = "Выберите кафедру";
			cbDirection.SelectedIndexChanged += cbDirection_SelectedIndexChanged;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.CustomFormat = "MMMM yyyy";
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			dateTimePicker1.Location = new Point(597, 60);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.ShowUpDown = true;
			dateTimePicker1.Size = new Size(127, 23);
			dateTimePicker1.TabIndex = 55;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn.HeaderText = "ФИО";
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			// 
			// Id
			// 
			Id.DataPropertyName = "Id";
			Id.HeaderText = "Id";
			Id.Name = "Id";
			Id.Visible = false;
			// 
			// DgvCbGroup
			// 
			DgvCbGroup.HeaderText = "Группа";
			DgvCbGroup.Name = "DgvCbGroup";
			DgvCbGroup.Resizable = DataGridViewTriState.True;
			// 
			// IsExcellentStudent
			// 
			IsExcellentStudent.DataPropertyName = "IsExcellentStudent";
			IsExcellentStudent.HeaderText = "Отличник";
			IsExcellentStudent.Name = "IsExcellentStudent";
			// 
			// EnrollmentDate
			// 
			EnrollmentDate.DataPropertyName = "EnrollmentDate";
			EnrollmentDate.HeaderText = "Дата зачисления";
			EnrollmentDate.Name = "EnrollmentDate";
			// 
			// EnrollmentNumber
			// 
			EnrollmentNumber.DataPropertyName = "EnrollmentNumber";
			EnrollmentNumber.HeaderText = "Номер зачисления";
			EnrollmentNumber.Name = "EnrollmentNumber";
			// 
			// groupIdDataGridViewTextBoxColumn
			// 
			groupIdDataGridViewTextBoxColumn.DataPropertyName = "GroupId";
			groupIdDataGridViewTextBoxColumn.HeaderText = "GroupId";
			groupIdDataGridViewTextBoxColumn.Name = "groupIdDataGridViewTextBoxColumn";
			groupIdDataGridViewTextBoxColumn.Visible = false;
			// 
			// Group
			// 
			Group.DataPropertyName = "Group";
			Group.HeaderText = "Group";
			Group.Name = "Group";
			Group.Visible = false;
			// 
			// marksDataGridViewTextBoxColumn
			// 
			marksDataGridViewTextBoxColumn.DataPropertyName = "Marks";
			marksDataGridViewTextBoxColumn.HeaderText = "Marks";
			marksDataGridViewTextBoxColumn.Name = "marksDataGridViewTextBoxColumn";
			marksDataGridViewTextBoxColumn.Visible = false;
			// 
			// FrmStudents
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(980, 653);
			Controls.Add(dateTimePicker1);
			Controls.Add(dgvStudentList);
			Controls.Add(btnDelete);
			Controls.Add(btnReset);
			Controls.Add(btnSave);
			Controls.Add(lbDbSaveResult);
			Controls.Add(label9);
			Controls.Add(cbDirection);
			Controls.Add(cbDepartment);
			Controls.Add(cbFaculty);
			Controls.Add(cbGroup);
			Controls.Add(btnAdd);
			Controls.Add(tbEnrollmentNumber);
			Controls.Add(tbFullName);
			Controls.Add(label10);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(label2);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FrmStudents";
			Text = "frmStudentList";
			((System.ComponentModel.ISupportInitialize)dgvStudentList).EndInit();
			((System.ComponentModel.ISupportInitialize)studentBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnAdd;
        private TextBox tbFullName;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox cbGroup;
        private ComboBox cbFaculty;
        private ComboBox cbDepartment;
        private TextBox tbEnrollmentNumber;
        private DataGridView dgvStudentList;
        private Button btnDelete;
        private Button btnReset;
        private Button btnSave;
        private Label lbDbSaveResult;
        private Label label9;
        private Label label10;
        private ComboBox cbDirection;
		private DateTimePicker dateTimePicker1;
		private BindingSource studentBindingSource;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn Id;
		private DataGridViewComboBoxColumn DgvCbGroup;
		private DataGridViewCheckBoxColumn IsExcellentStudent;
		private DataGridViewTextBoxColumn EnrollmentDate;
		private DataGridViewTextBoxColumn EnrollmentNumber;
		private DataGridViewTextBoxColumn groupIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn Group;
		private DataGridViewTextBoxColumn marksDataGridViewTextBoxColumn;
	}
}