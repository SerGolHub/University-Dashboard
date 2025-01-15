namespace University_Dasboard
{
    partial class FrmMarks
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
			dgvMarksList = new DataGridView();
			btnDelete = new Button();
			btnReset = new Button();
			btnSave = new Button();
			lbDbSaveResult = new Label();
			label9 = new Label();
			cbDirection = new ComboBox();
			cbDepartment = new ComboBox();
			cbFaculty = new ComboBox();
			cbGroup = new ComboBox();
			cbSemester = new ComboBox();
			btnShow = new Button();
			label10 = new Label();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label1 = new Label();
			label6 = new Label();
			cbSubject = new ComboBox();
			dateTimePicker1 = new DateTimePicker();
			label2 = new Label();
			label7 = new Label();
			cbStudent = new ComboBox();
			btnAdd = new Button();
			label8 = new Label();
			tbMark = new TextBox();
			label11 = new Label();
			cbMarkType = new ComboBox();
			checkBox1 = new CheckBox();
			((System.ComponentModel.ISupportInitialize)dgvMarksList).BeginInit();
			SuspendLayout();
			// 
			// dgvMarksList
			// 
			dgvMarksList.AllowUserToAddRows = false;
			dgvMarksList.AllowUserToDeleteRows = false;
			dgvMarksList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvMarksList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvMarksList.Location = new Point(12, 315);
			dgvMarksList.Name = "dgvMarksList";
			dgvMarksList.Size = new Size(862, 319);
			dgvMarksList.TabIndex = 53;
			dgvMarksList.CellValueChanged += dgvMarksList_CellValueChanged;
			dgvMarksList.RowPostPaint += dgvMarksList_RowPostPaint;
			// 
			// btnDelete
			// 
			btnDelete.BackColor = Color.FromArgb(0, 126, 249);
			btnDelete.FlatAppearance.BorderSize = 0;
			btnDelete.FlatStyle = FlatStyle.Flat;
			btnDelete.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnDelete.ForeColor = Color.FromArgb(24, 30, 54);
			btnDelete.Location = new Point(880, 592);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(88, 42);
			btnDelete.TabIndex = 50;
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
			btnReset.Location = new Point(880, 544);
			btnReset.Name = "btnReset";
			btnReset.Size = new Size(88, 42);
			btnReset.TabIndex = 51;
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
			btnSave.Location = new Point(880, 315);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(88, 42);
			btnSave.TabIndex = 52;
			btnSave.Text = "Сохранить";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += btnSave_Click;
			// 
			// lbDbSaveResult
			// 
			lbDbSaveResult.AutoSize = true;
			lbDbSaveResult.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
			lbDbSaveResult.Location = new Point(572, 292);
			lbDbSaveResult.Name = "lbDbSaveResult";
			lbDbSaveResult.Size = new Size(302, 20);
			lbDbSaveResult.TabIndex = 48;
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
			lbDbSaveResult.Visible = false;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label9.ForeColor = Color.FromArgb(158, 161, 178);
			label9.Location = new Point(12, 283);
			label9.Name = "label9";
			label9.Size = new Size(201, 29);
			label9.TabIndex = 49;
			label9.Text = "Список оценок";
			// 
			// cbDirection
			// 
			cbDirection.BackColor = Color.FromArgb(158, 161, 178);
			cbDirection.FlatStyle = FlatStyle.Flat;
			cbDirection.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbDirection.ForeColor = Color.FromArgb(24, 30, 54);
			cbDirection.FormattingEnabled = true;
			cbDirection.Location = new Point(167, 77);
			cbDirection.Name = "cbDirection";
			cbDirection.Size = new Size(209, 26);
			cbDirection.TabIndex = 46;
			cbDirection.SelectedIndexChanged += cbDirection_SelectedIndexChanged;
			// 
			// cbDepartment
			// 
			cbDepartment.BackColor = Color.FromArgb(158, 161, 178);
			cbDepartment.FlatStyle = FlatStyle.Flat;
			cbDepartment.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbDepartment.ForeColor = Color.FromArgb(24, 30, 54);
			cbDepartment.FormattingEnabled = true;
			cbDepartment.Location = new Point(167, 45);
			cbDepartment.Name = "cbDepartment";
			cbDepartment.Size = new Size(209, 26);
			cbDepartment.TabIndex = 45;
			cbDepartment.SelectedIndexChanged += cbDepartment_SelectedIndexChanged;
			// 
			// cbFaculty
			// 
			cbFaculty.BackColor = Color.FromArgb(158, 161, 178);
			cbFaculty.FlatStyle = FlatStyle.Flat;
			cbFaculty.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbFaculty.ForeColor = Color.FromArgb(24, 30, 54);
			cbFaculty.FormattingEnabled = true;
			cbFaculty.Location = new Point(167, 13);
			cbFaculty.Name = "cbFaculty";
			cbFaculty.Size = new Size(209, 26);
			cbFaculty.TabIndex = 44;
			cbFaculty.SelectedIndexChanged += cbFaculty_SelectedIndexChanged;
			// 
			// cbGroup
			// 
			cbGroup.BackColor = Color.FromArgb(158, 161, 178);
			cbGroup.FlatStyle = FlatStyle.Flat;
			cbGroup.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbGroup.ForeColor = Color.FromArgb(24, 30, 54);
			cbGroup.FormattingEnabled = true;
			cbGroup.Location = new Point(167, 109);
			cbGroup.Name = "cbGroup";
			cbGroup.Size = new Size(209, 26);
			cbGroup.TabIndex = 43;
			cbGroup.SelectedIndexChanged += cbGroup_SelectedIndexChanged;
			// 
			// cbSemester
			// 
			cbSemester.BackColor = Color.FromArgb(158, 161, 178);
			cbSemester.FlatStyle = FlatStyle.Flat;
			cbSemester.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbSemester.ForeColor = Color.FromArgb(24, 30, 54);
			cbSemester.FormattingEnabled = true;
			cbSemester.Location = new Point(306, 141);
			cbSemester.Name = "cbSemester";
			cbSemester.Size = new Size(70, 26);
			cbSemester.TabIndex = 47;
			cbSemester.SelectedIndexChanged += cbCourse_SelectedIndexChanged;
			// 
			// btnShow
			// 
			btnShow.BackColor = Color.FromArgb(0, 126, 249);
			btnShow.FlatAppearance.BorderSize = 0;
			btnShow.FlatStyle = FlatStyle.Flat;
			btnShow.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnShow.ForeColor = Color.FromArgb(24, 30, 54);
			btnShow.Location = new Point(260, 234);
			btnShow.Name = "btnShow";
			btnShow.Size = new Size(116, 43);
			btnShow.TabIndex = 41;
			btnShow.Text = "Показать оценки";
			btnShow.UseVisualStyleBackColor = false;
			btnShow.Click += btnShow_Click;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label10.ForeColor = Color.FromArgb(158, 161, 178);
			label10.Location = new Point(12, 83);
			label10.Name = "label10";
			label10.Size = new Size(128, 20);
			label10.TabIndex = 36;
			label10.Text = "Направление:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.ForeColor = Color.FromArgb(158, 161, 178);
			label5.Location = new Point(12, 51);
			label5.Name = "label5";
			label5.Size = new Size(93, 20);
			label5.TabIndex = 35;
			label5.Text = "Кафедра:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.FromArgb(158, 161, 178);
			label4.Location = new Point(12, 19);
			label4.Name = "label4";
			label4.Size = new Size(108, 20);
			label4.TabIndex = 34;
			label4.Text = "Факультет:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.ForeColor = Color.FromArgb(158, 161, 178);
			label3.Location = new Point(12, 115);
			label3.Name = "label3";
			label3.Size = new Size(72, 20);
			label3.TabIndex = 33;
			label3.Text = "Группа:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.FromArgb(158, 161, 178);
			label1.Location = new Point(12, 147);
			label1.Name = "label1";
			label1.Size = new Size(87, 20);
			label1.TabIndex = 32;
			label1.Text = "Семестр:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.ForeColor = Color.FromArgb(158, 161, 178);
			label6.Location = new Point(12, 179);
			label6.Name = "label6";
			label6.Size = new Size(117, 20);
			label6.TabIndex = 33;
			label6.Text = "Дисциплина:";
			// 
			// cbSubject
			// 
			cbSubject.BackColor = Color.FromArgb(158, 161, 178);
			cbSubject.FlatStyle = FlatStyle.Flat;
			cbSubject.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbSubject.ForeColor = Color.FromArgb(24, 30, 54);
			cbSubject.FormattingEnabled = true;
			cbSubject.Location = new Point(167, 173);
			cbSubject.Name = "cbSubject";
			cbSubject.Size = new Size(209, 26);
			cbSubject.TabIndex = 43;
			cbSubject.SelectedIndexChanged += cbSubject_SelectedIndexChanged;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.CustomFormat = "MMMM yyyy";
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			dateTimePicker1.Location = new Point(249, 205);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.ShowCheckBox = true;
			dateTimePicker1.ShowUpDown = true;
			dateTimePicker1.Size = new Size(127, 23);
			dateTimePicker1.TabIndex = 54;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(158, 161, 178);
			label2.Location = new Point(12, 208);
			label2.Name = "label2";
			label2.Size = new Size(57, 20);
			label2.TabIndex = 33;
			label2.Text = "Дата:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.ForeColor = Color.FromArgb(158, 161, 178);
			label7.Location = new Point(435, 51);
			label7.Name = "label7";
			label7.Size = new Size(86, 20);
			label7.TabIndex = 34;
			label7.Text = "Студент:";
			label7.Visible = false;
			// 
			// cbStudent
			// 
			cbStudent.BackColor = Color.FromArgb(158, 161, 178);
			cbStudent.FlatStyle = FlatStyle.Flat;
			cbStudent.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbStudent.ForeColor = Color.FromArgb(24, 30, 54);
			cbStudent.FormattingEnabled = true;
			cbStudent.Location = new Point(553, 45);
			cbStudent.Name = "cbStudent";
			cbStudent.Size = new Size(273, 26);
			cbStudent.TabIndex = 44;
			cbStudent.Visible = false;
			cbStudent.SelectedIndexChanged += cbStudent_SelectedIndexChanged;
			// 
			// btnAdd
			// 
			btnAdd.BackColor = Color.FromArgb(0, 126, 249);
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = FlatStyle.Flat;
			btnAdd.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnAdd.ForeColor = Color.FromArgb(24, 30, 54);
			btnAdd.Location = new Point(553, 234);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(116, 43);
			btnAdd.TabIndex = 41;
			btnAdd.Text = "Добавить оценку";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Visible = false;
			btnAdd.Click += btnAdd_Click;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.ForeColor = Color.FromArgb(158, 161, 178);
			label8.Location = new Point(435, 81);
			label8.Name = "label8";
			label8.Size = new Size(76, 20);
			label8.TabIndex = 34;
			label8.Text = "Оценка:";
			label8.Visible = false;
			// 
			// tbMark
			// 
			tbMark.BackColor = Color.FromArgb(158, 161, 178);
			tbMark.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			tbMark.ForeColor = Color.FromArgb(24, 30, 54);
			tbMark.Location = new Point(553, 77);
			tbMark.Name = "tbMark";
			tbMark.Size = new Size(39, 24);
			tbMark.TabIndex = 55;
			tbMark.Visible = false;
			tbMark.KeyPress += tbMark_KeyPress;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label11.ForeColor = Color.FromArgb(158, 161, 178);
			label11.Location = new Point(435, 113);
			label11.Name = "label11";
			label11.Size = new Size(108, 20);
			label11.TabIndex = 33;
			label11.Text = "Тип оценки:";
			label11.Visible = false;
			// 
			// cbMarkType
			// 
			cbMarkType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbMarkType.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbMarkType.BackColor = Color.FromArgb(158, 161, 178);
			cbMarkType.FlatStyle = FlatStyle.Flat;
			cbMarkType.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbMarkType.ForeColor = Color.FromArgb(24, 30, 54);
			cbMarkType.FormattingEnabled = true;
			cbMarkType.Items.AddRange(new object[] { "Лекция", "Практика", "Тест", "Контрольная работа", "Экзамен" });
			cbMarkType.Location = new Point(553, 107);
			cbMarkType.Name = "cbMarkType";
			cbMarkType.Size = new Size(209, 26);
			cbMarkType.TabIndex = 43;
			cbMarkType.Visible = false;
			cbMarkType.SelectedIndexChanged += cbMarkType_SelectedIndexChanged;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
			checkBox1.ForeColor = Color.FromArgb(158, 161, 178);
			checkBox1.Location = new Point(432, 12);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(173, 24);
			checkBox1.TabIndex = 56;
			checkBox1.Text = "Добавить оценку";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += checkBox1_CheckedChanged;
			// 
			// FrmMarks
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(980, 653);
			Controls.Add(checkBox1);
			Controls.Add(tbMark);
			Controls.Add(dateTimePicker1);
			Controls.Add(dgvMarksList);
			Controls.Add(btnDelete);
			Controls.Add(btnReset);
			Controls.Add(btnSave);
			Controls.Add(lbDbSaveResult);
			Controls.Add(label9);
			Controls.Add(cbDirection);
			Controls.Add(cbDepartment);
			Controls.Add(cbStudent);
			Controls.Add(cbFaculty);
			Controls.Add(cbMarkType);
			Controls.Add(cbSubject);
			Controls.Add(cbGroup);
			Controls.Add(cbSemester);
			Controls.Add(btnAdd);
			Controls.Add(btnShow);
			Controls.Add(label10);
			Controls.Add(label5);
			Controls.Add(label8);
			Controls.Add(label2);
			Controls.Add(label7);
			Controls.Add(label11);
			Controls.Add(label6);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FrmMarks";
			Text = "FrmGrades";
			((System.ComponentModel.ISupportInitialize)dgvMarksList).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dgvMarksList;
        private Button btnDelete;
        private Button btnReset;
        private Button btnSave;
        private Label lbDbSaveResult;
        private Label label9;
        private ComboBox cbDirection;
        private ComboBox cbDepartment;
        private ComboBox cbFaculty;
        private ComboBox cbGroup;
        private ComboBox cbSemester;
        private Button btnShow;
        private Label label10;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label6;
        private ComboBox cbSubject;
		private DateTimePicker dateTimePicker1;
		private Label label2;
		private Label label7;
		private ComboBox cbStudent;
		private Button btnAdd;
		private Label label8;
		private TextBox tbMark;
		private Label label11;
		private ComboBox cbMarkType;
		private CheckBox checkBox1;
	}
}