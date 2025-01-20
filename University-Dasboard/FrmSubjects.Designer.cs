namespace University_Dasboard
{
    partial class FrmSubjects
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
			tbNewDisciplineName = new TextBox();
			label2 = new Label();
			label1 = new Label();
			userBindingSource = new BindingSource(components);
			userBindingSource1 = new BindingSource(components);
			dgvDisciplines = new DataGridView();
			subjectBindingSource = new BindingSource(components);
			departmentBindingSource = new BindingSource(components);
			departmentBindingSource1 = new BindingSource(components);
			btnSave = new Button();
			backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			btnDelete = new Button();
			btnAdd = new Button();
			btnReset = new Button();
			lbDbSaveResult = new Label();
			cbDirection = new ComboBox();
			cbDepartment = new ComboBox();
			cbFaculty = new ComboBox();
			label10 = new Label();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			cbTeacher = new ComboBox();
			label6 = new Label();
			tbSemesters = new TextBox();
			Id = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			Semester = new DataGridViewTextBoxColumn();
			directionIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			directionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			teacherIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			teacherDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			marksDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			scheduleDisciplinesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			DgvCbTeacher = new DataGridViewComboBoxColumn();
			DgvCbDirection = new DataGridViewComboBoxColumn();
			((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)userBindingSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvDisciplines).BeginInit();
			((System.ComponentModel.ISupportInitialize)subjectBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource1).BeginInit();
			SuspendLayout();
			// 
			// tbNewDisciplineName
			// 
			tbNewDisciplineName.BackColor = Color.FromArgb(158, 161, 178);
			tbNewDisciplineName.BorderStyle = BorderStyle.FixedSingle;
			tbNewDisciplineName.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			tbNewDisciplineName.ForeColor = Color.FromArgb(24, 30, 54);
			tbNewDisciplineName.Location = new Point(273, 22);
			tbNewDisciplineName.Name = "tbNewDisciplineName";
			tbNewDisciplineName.Size = new Size(249, 24);
			tbNewDisciplineName.TabIndex = 23;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(158, 161, 178);
			label2.Location = new Point(12, 26);
			label2.Name = "label2";
			label2.Size = new Size(249, 20);
			label2.TabIndex = 20;
			label2.Text = "Введите новую дисциплину:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.FromArgb(158, 161, 178);
			label1.Location = new Point(12, 273);
			label1.Name = "label1";
			label1.Size = new Size(251, 29);
			label1.TabIndex = 21;
			label1.Text = "Список дисциплин";
			// 
			// dgvDisciplines
			// 
			dgvDisciplines.AllowUserToAddRows = false;
			dgvDisciplines.AllowUserToDeleteRows = false;
			dgvDisciplines.AutoGenerateColumns = false;
			dgvDisciplines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvDisciplines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvDisciplines.Columns.AddRange(new DataGridViewColumn[] { Id, nameDataGridViewTextBoxColumn, Semester, directionIdDataGridViewTextBoxColumn, directionDataGridViewTextBoxColumn, teacherIdDataGridViewTextBoxColumn, teacherDataGridViewTextBoxColumn, marksDataGridViewTextBoxColumn, scheduleDisciplinesDataGridViewTextBoxColumn, DgvCbTeacher, DgvCbDirection });
			dgvDisciplines.DataSource = subjectBindingSource;
			dgvDisciplines.Location = new Point(12, 308);
			dgvDisciplines.Name = "dgvDisciplines";
			dgvDisciplines.Size = new Size(862, 333);
			dgvDisciplines.TabIndex = 28;
			dgvDisciplines.CellClick += dgvDisciplines_CellClick;
			dgvDisciplines.CellValueChanged += dgvSubjects_CellValueChanged;
			dgvDisciplines.RowPostPaint += dgvSubjects_RowPostPaint;
			// 
			// subjectBindingSource
			// 
			subjectBindingSource.DataSource = typeof(Database.Models.Subject);
			// 
			// btnSave
			// 
			btnSave.BackColor = Color.FromArgb(0, 126, 249);
			btnSave.FlatAppearance.BorderSize = 0;
			btnSave.FlatStyle = FlatStyle.Flat;
			btnSave.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnSave.ForeColor = Color.FromArgb(24, 30, 54);
			btnSave.Location = new Point(880, 308);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(88, 42);
			btnSave.TabIndex = 24;
			btnSave.Text = "Сохранить";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += btnSave_Click;
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
			// btnAdd
			// 
			btnAdd.BackColor = Color.FromArgb(0, 126, 249);
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = FlatStyle.Flat;
			btnAdd.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnAdd.ForeColor = Color.FromArgb(24, 30, 54);
			btnAdd.Location = new Point(418, 219);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(104, 46);
			btnAdd.TabIndex = 26;
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
			btnReset.Location = new Point(880, 551);
			btnReset.Name = "btnReset";
			btnReset.Size = new Size(88, 42);
			btnReset.TabIndex = 27;
			btnReset.Text = "Сбросить изменения";
			btnReset.UseVisualStyleBackColor = false;
			btnReset.Click += btnReset_Click;
			// 
			// lbDbSaveResult
			// 
			lbDbSaveResult.AutoSize = true;
			lbDbSaveResult.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
			lbDbSaveResult.Location = new Point(572, 285);
			lbDbSaveResult.Name = "lbDbSaveResult";
			lbDbSaveResult.Size = new Size(302, 20);
			lbDbSaveResult.TabIndex = 22;
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
			lbDbSaveResult.Visible = false;
			// 
			// cbDirection
			// 
			cbDirection.BackColor = Color.FromArgb(158, 161, 178);
			cbDirection.FlatStyle = FlatStyle.Flat;
			cbDirection.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbDirection.ForeColor = Color.FromArgb(24, 30, 54);
			cbDirection.FormattingEnabled = true;
			cbDirection.Location = new Point(273, 116);
			cbDirection.Name = "cbDirection";
			cbDirection.Size = new Size(249, 26);
			cbDirection.TabIndex = 52;
			cbDirection.Text = "Выберите кафедру ↑";
			cbDirection.SelectedIndexChanged += cbDirection_SelectedIndexChanged;
			// 
			// cbDepartment
			// 
			cbDepartment.BackColor = Color.FromArgb(158, 161, 178);
			cbDepartment.FlatStyle = FlatStyle.Flat;
			cbDepartment.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbDepartment.ForeColor = Color.FromArgb(24, 30, 54);
			cbDepartment.FormattingEnabled = true;
			cbDepartment.Location = new Point(273, 84);
			cbDepartment.Name = "cbDepartment";
			cbDepartment.Size = new Size(249, 26);
			cbDepartment.TabIndex = 51;
			cbDepartment.Text = "Выберите факультет ↑";
			cbDepartment.SelectedIndexChanged += cbDepartment_SelectedIndexChanged;
			// 
			// cbFaculty
			// 
			cbFaculty.BackColor = Color.FromArgb(158, 161, 178);
			cbFaculty.FlatStyle = FlatStyle.Flat;
			cbFaculty.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbFaculty.ForeColor = Color.FromArgb(24, 30, 54);
			cbFaculty.FormattingEnabled = true;
			cbFaculty.Location = new Point(273, 52);
			cbFaculty.Name = "cbFaculty";
			cbFaculty.Size = new Size(249, 26);
			cbFaculty.TabIndex = 50;
			cbFaculty.SelectedIndexChanged += cbFaculty_SelectedIndexChanged;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label10.ForeColor = Color.FromArgb(158, 161, 178);
			label10.Location = new Point(12, 122);
			label10.Name = "label10";
			label10.Size = new Size(128, 20);
			label10.TabIndex = 49;
			label10.Text = "Направление:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.ForeColor = Color.FromArgb(158, 161, 178);
			label5.Location = new Point(12, 90);
			label5.Name = "label5";
			label5.Size = new Size(93, 20);
			label5.TabIndex = 48;
			label5.Text = "Кафедра:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.FromArgb(158, 161, 178);
			label4.Location = new Point(12, 58);
			label4.Name = "label4";
			label4.Size = new Size(108, 20);
			label4.TabIndex = 47;
			label4.Text = "Факультет:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.ForeColor = Color.FromArgb(158, 161, 178);
			label3.Location = new Point(12, 184);
			label3.Name = "label3";
			label3.Size = new Size(150, 20);
			label3.TabIndex = 49;
			label3.Text = "Преподаватель:";
			// 
			// cbTeacher
			// 
			cbTeacher.BackColor = Color.FromArgb(158, 161, 178);
			cbTeacher.FlatStyle = FlatStyle.Flat;
			cbTeacher.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbTeacher.ForeColor = Color.FromArgb(24, 30, 54);
			cbTeacher.FormattingEnabled = true;
			cbTeacher.Location = new Point(273, 178);
			cbTeacher.Name = "cbTeacher";
			cbTeacher.Size = new Size(249, 26);
			cbTeacher.TabIndex = 52;
			cbTeacher.SelectedIndexChanged += cbTeacher_SelectedIndexChanged;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.ForeColor = Color.FromArgb(158, 161, 178);
			label6.Location = new Point(12, 154);
			label6.Name = "label6";
			label6.Size = new Size(99, 20);
			label6.TabIndex = 49;
			label6.Text = "Семестры:";
			// 
			// tbSemesters
			// 
			tbSemesters.BackColor = Color.FromArgb(158, 161, 178);
			tbSemesters.BorderStyle = BorderStyle.FixedSingle;
			tbSemesters.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			tbSemesters.ForeColor = Color.FromArgb(24, 30, 54);
			tbSemesters.Location = new Point(273, 148);
			tbSemesters.Name = "tbSemesters";
			tbSemesters.Size = new Size(249, 24);
			tbSemesters.TabIndex = 23;
			tbSemesters.KeyPress += tbSemesters_KeyPress;
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
			nameDataGridViewTextBoxColumn.HeaderText = "Дисциплина";
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			// 
			// Semester
			// 
			Semester.DataPropertyName = "Semester";
			Semester.HeaderText = "Семестр";
			Semester.Name = "Semester";
			// 
			// directionIdDataGridViewTextBoxColumn
			// 
			directionIdDataGridViewTextBoxColumn.DataPropertyName = "DirectionId";
			directionIdDataGridViewTextBoxColumn.HeaderText = "DirectionId";
			directionIdDataGridViewTextBoxColumn.Name = "directionIdDataGridViewTextBoxColumn";
			directionIdDataGridViewTextBoxColumn.Visible = false;
			// 
			// directionDataGridViewTextBoxColumn
			// 
			directionDataGridViewTextBoxColumn.DataPropertyName = "Direction";
			directionDataGridViewTextBoxColumn.HeaderText = "Direction";
			directionDataGridViewTextBoxColumn.Name = "directionDataGridViewTextBoxColumn";
			directionDataGridViewTextBoxColumn.Visible = false;
			// 
			// teacherIdDataGridViewTextBoxColumn
			// 
			teacherIdDataGridViewTextBoxColumn.DataPropertyName = "TeacherId";
			teacherIdDataGridViewTextBoxColumn.HeaderText = "TeacherId";
			teacherIdDataGridViewTextBoxColumn.Name = "teacherIdDataGridViewTextBoxColumn";
			teacherIdDataGridViewTextBoxColumn.Visible = false;
			// 
			// teacherDataGridViewTextBoxColumn
			// 
			teacherDataGridViewTextBoxColumn.DataPropertyName = "Teacher";
			teacherDataGridViewTextBoxColumn.HeaderText = "Teacher";
			teacherDataGridViewTextBoxColumn.Name = "teacherDataGridViewTextBoxColumn";
			teacherDataGridViewTextBoxColumn.Visible = false;
			// 
			// marksDataGridViewTextBoxColumn
			// 
			marksDataGridViewTextBoxColumn.DataPropertyName = "Marks";
			marksDataGridViewTextBoxColumn.HeaderText = "Marks";
			marksDataGridViewTextBoxColumn.Name = "marksDataGridViewTextBoxColumn";
			marksDataGridViewTextBoxColumn.Visible = false;
			// 
			// scheduleDisciplinesDataGridViewTextBoxColumn
			// 
			scheduleDisciplinesDataGridViewTextBoxColumn.DataPropertyName = "ScheduleDisciplines";
			scheduleDisciplinesDataGridViewTextBoxColumn.HeaderText = "ScheduleDisciplines";
			scheduleDisciplinesDataGridViewTextBoxColumn.Name = "scheduleDisciplinesDataGridViewTextBoxColumn";
			scheduleDisciplinesDataGridViewTextBoxColumn.Visible = false;
			// 
			// DgvCbTeacher
			// 
			DgvCbTeacher.HeaderText = "Преподаватель";
			DgvCbTeacher.Name = "DgvCbTeacher";
			// 
			// DgvCbDirection
			// 
			DgvCbDirection.HeaderText = "Направление";
			DgvCbDirection.Name = "DgvCbDirection";
			// 
			// FrmSubjects
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(980, 653);
			Controls.Add(cbTeacher);
			Controls.Add(cbDirection);
			Controls.Add(cbDepartment);
			Controls.Add(label6);
			Controls.Add(cbFaculty);
			Controls.Add(label3);
			Controls.Add(label10);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(tbSemesters);
			Controls.Add(tbNewDisciplineName);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(dgvDisciplines);
			Controls.Add(btnSave);
			Controls.Add(btnDelete);
			Controls.Add(btnAdd);
			Controls.Add(btnReset);
			Controls.Add(lbDbSaveResult);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FrmSubjects";
			Text = "frmDisciplineList";
			((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)userBindingSource1).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvDisciplines).EndInit();
			((System.ComponentModel.ISupportInitialize)subjectBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox tbNewDisciplineName;
        private Label label2;
        private Label label1;
        private BindingSource userBindingSource;
        private BindingSource userBindingSource1;
        private DataGridView dgvDisciplines;
        private BindingSource departmentBindingSource;
        private BindingSource departmentBindingSource1;
        private Button btnSave;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnReset;
        private Label lbDbSaveResult;
		private ComboBox cbDirection;
		private ComboBox cbDepartment;
		private ComboBox cbFaculty;
		private Label label10;
		private Label label5;
		private Label label4;
		private Label label3;
		private ComboBox cbTeacher;
		private Label label6;
		private TextBox tbSemesters;
		private BindingSource subjectBindingSource;
		private DataGridViewTextBoxColumn departmentIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn Id;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn Semester;
		private DataGridViewTextBoxColumn directionIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn directionDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn teacherIdDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn teacherDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn marksDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn scheduleDisciplinesDataGridViewTextBoxColumn;
		private DataGridViewComboBoxColumn DgvCbTeacher;
		private DataGridViewComboBoxColumn DgvCbDirection;
	}
}