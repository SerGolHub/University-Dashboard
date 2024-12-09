namespace University_Dasboard
{
    partial class FrmSchedulingWeek
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
			tbPracticeHours = new TextBox();
			tbLectionsHours = new TextBox();
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
			label5 = new Label();
			tbLaboratoryHours = new TextBox();
			label2 = new Label();
			tbWeek = new TextBox();
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
			label1.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.FromArgb(158, 161, 178);
			label1.Location = new Point(105, 9);
			label1.Name = "label1";
			label1.Size = new Size(565, 32);
			label1.TabIndex = 1;
			label1.Text = "Составление расписания (Расчасовка)";
			// 
			// tbPracticeHours
			// 
			tbPracticeHours.BackColor = Color.FromArgb(158, 161, 178);
			tbPracticeHours.BorderStyle = BorderStyle.FixedSingle;
			tbPracticeHours.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			tbPracticeHours.ForeColor = Color.FromArgb(24, 30, 54);
			tbPracticeHours.Location = new Point(730, 130);
			tbPracticeHours.Name = "tbPracticeHours";
			tbPracticeHours.Size = new Size(127, 24);
			tbPracticeHours.TabIndex = 57;
			// 
			// tbLectionsHours
			// 
			tbLectionsHours.BackColor = Color.FromArgb(158, 161, 178);
			tbLectionsHours.BorderStyle = BorderStyle.FixedSingle;
			tbLectionsHours.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			tbLectionsHours.ForeColor = Color.FromArgb(24, 30, 54);
			tbLectionsHours.Location = new Point(730, 190);
			tbLectionsHours.Name = "tbLectionsHours";
			tbLectionsHours.Size = new Size(127, 24);
			tbLectionsHours.TabIndex = 56;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.FromArgb(158, 161, 178);
			label4.Location = new Point(730, 161);
			label4.Name = "label4";
			label4.Size = new Size(134, 20);
			label4.TabIndex = 54;
			label4.Text = "Лекции (часы):";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.ForeColor = Color.FromArgb(158, 161, 178);
			label3.Location = new Point(730, 98);
			label3.Name = "label3";
			label3.Size = new Size(153, 20);
			label3.TabIndex = 52;
			label3.Text = "Практики (часы):";
			// 
			// btnDelete
			// 
			btnDelete.BackColor = Color.FromArgb(0, 126, 249);
			btnDelete.FlatAppearance.BorderSize = 0;
			btnDelete.FlatStyle = FlatStyle.Flat;
			btnDelete.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnDelete.ForeColor = Color.FromArgb(24, 30, 54);
			btnDelete.Location = new Point(587, 420);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(104, 53);
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
			btnAdd.Location = new Point(842, 354);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(112, 42);
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
			btnReset.Location = new Point(730, 420);
			btnReset.Name = "btnReset";
			btnReset.Size = new Size(93, 53);
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
			lbDbSaveResult.Location = new Point(12, 435);
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
			btnSave.Location = new Point(861, 420);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(93, 53);
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
			dgvSchedules.Location = new Point(12, 54);
			dgvSchedules.Name = "dgvSchedules";
			dgvSchedules.Size = new Size(679, 342);
			dgvSchedules.TabIndex = 51;
			dgvSchedules.CellValueChanged += dgvSchedules_CellValueChanged;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.ForeColor = Color.FromArgb(158, 161, 178);
			label5.Location = new Point(730, 228);
			label5.Name = "label5";
			label5.Size = new Size(197, 20);
			label5.TabIndex = 55;
			label5.Text = "Лабораторные (часы):";
			// 
			// tbLaboratoryHours
			// 
			tbLaboratoryHours.BackColor = Color.FromArgb(158, 161, 178);
			tbLaboratoryHours.BorderStyle = BorderStyle.FixedSingle;
			tbLaboratoryHours.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			tbLaboratoryHours.ForeColor = Color.FromArgb(24, 30, 54);
			tbLaboratoryHours.Location = new Point(730, 262);
			tbLaboratoryHours.Name = "tbLaboratoryHours";
			tbLaboratoryHours.Size = new Size(127, 24);
			tbLaboratoryHours.TabIndex = 46;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(158, 161, 178);
			label2.Location = new Point(730, 21);
			label2.Name = "label2";
			label2.Size = new Size(164, 20);
			label2.TabIndex = 43;
			label2.Text = "Название недели:";
			// 
			// tbWeek
			// 
			tbWeek.BackColor = Color.FromArgb(158, 161, 178);
			tbWeek.BorderStyle = BorderStyle.FixedSingle;
			tbWeek.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			tbWeek.ForeColor = Color.FromArgb(24, 30, 54);
			tbWeek.Location = new Point(730, 54);
			tbWeek.Name = "tbWeek";
			tbWeek.Size = new Size(127, 24);
			tbWeek.TabIndex = 58;
			// 
			// FrmSchedulingWeek
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(981, 653);
			Controls.Add(tbWeek);
			Controls.Add(tbPracticeHours);
			Controls.Add(tbLectionsHours);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(btnDelete);
			Controls.Add(btnAdd);
			Controls.Add(btnReset);
			Controls.Add(lbDbSaveResult);
			Controls.Add(btnSave);
			Controls.Add(dgvSchedules);
			Controls.Add(label5);
			Controls.Add(tbLaboratoryHours);
			Controls.Add(label2);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FrmSchedulingWeek";
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
		private TextBox tbPracticeHours;
		private TextBox tbLectionsHours;
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
		private Label label5;
		private TextBox tbLaboratoryHours;
		private Label label2;
		private TextBox tbWeek;
	}
}