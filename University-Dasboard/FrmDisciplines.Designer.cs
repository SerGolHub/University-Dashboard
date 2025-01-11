namespace University_Dasboard
{
    partial class FrmDisciplines
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
			((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)userBindingSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvDisciplines).BeginInit();
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
			dgvDisciplines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvDisciplines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvDisciplines.Location = new Point(12, 308);
			dgvDisciplines.Name = "dgvDisciplines";
			dgvDisciplines.Size = new Size(862, 333);
			dgvDisciplines.TabIndex = 28;
			dgvDisciplines.CellValueChanged += dgvSubjects_CellValueChanged;
			dgvDisciplines.RowPostPaint += dgvSubjects_RowPostPaint;
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
			btnAdd.Location = new Point(16, 211);
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
			label3.Location = new Point(12, 154);
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
			cbTeacher.Location = new Point(273, 148);
			cbTeacher.Name = "cbTeacher";
			cbTeacher.Size = new Size(249, 26);
			cbTeacher.TabIndex = 52;
			cbTeacher.SelectedIndexChanged += cbTeacher_SelectedIndexChanged;
			// 
			// FrmDisciplines
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(980, 653);
			Controls.Add(cbTeacher);
			Controls.Add(cbDirection);
			Controls.Add(cbDepartment);
			Controls.Add(cbFaculty);
			Controls.Add(label3);
			Controls.Add(label10);
			Controls.Add(label5);
			Controls.Add(label4);
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
			Name = "FrmDisciplines";
			Text = "frmDisciplineList";
			((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)userBindingSource1).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvDisciplines).EndInit();
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
	}
}