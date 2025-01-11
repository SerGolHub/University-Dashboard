namespace University_Dasboard
{
    partial class FrmSchedulingDiscipline
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
			label5 = new Label();
			label2 = new Label();
			comboBoxFaculties = new ComboBox();
			comboBoxGroup = new ComboBox();
			comboBoxDirection = new ComboBox();
			comboBoxDiscipline = new ComboBox();
			label6 = new Label();
			comboBoxScheduleWeek = new ComboBox();
			button1 = new Button();
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
			label4.Size = new Size(108, 20);
			label4.TabIndex = 54;
			label4.Text = "Факультет:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.ForeColor = Color.FromArgb(158, 161, 178);
			label3.Location = new Point(12, 46);
			label3.Name = "label3";
			label3.Size = new Size(128, 20);
			label3.TabIndex = 52;
			label3.Text = "Направление:";
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
			dgvSchedules.CellValueChanged += dgvSchedules_CellValueChanged;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.ForeColor = Color.FromArgb(158, 161, 178);
			label5.Location = new Point(12, 114);
			label5.Name = "label5";
			label5.Size = new Size(72, 20);
			label5.TabIndex = 55;
			label5.Text = "Группа:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(158, 161, 178);
			label2.Location = new Point(12, 82);
			label2.Name = "label2";
			label2.Size = new Size(117, 20);
			label2.TabIndex = 43;
			label2.Text = "Дисциплина:";
			// 
			// comboBoxFaculties
			// 
			comboBoxFaculties.BackColor = Color.FromArgb(158, 161, 178);
			comboBoxFaculties.FlatStyle = FlatStyle.Flat;
			comboBoxFaculties.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			comboBoxFaculties.ForeColor = Color.FromArgb(24, 30, 54);
			comboBoxFaculties.FormattingEnabled = true;
			comboBoxFaculties.Location = new Point(201, 12);
			comboBoxFaculties.Name = "comboBoxFaculties";
			comboBoxFaculties.Size = new Size(290, 26);
			comboBoxFaculties.TabIndex = 56;
			// 
			// comboBoxGroup
			// 
			comboBoxGroup.BackColor = Color.FromArgb(158, 161, 178);
			comboBoxGroup.FlatStyle = FlatStyle.Flat;
			comboBoxGroup.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			comboBoxGroup.ForeColor = Color.FromArgb(24, 30, 54);
			comboBoxGroup.FormattingEnabled = true;
			comboBoxGroup.Location = new Point(201, 108);
			comboBoxGroup.Name = "comboBoxGroup";
			comboBoxGroup.Size = new Size(290, 26);
			comboBoxGroup.TabIndex = 57;
			// 
			// comboBoxDirection
			// 
			comboBoxDirection.BackColor = Color.FromArgb(158, 161, 178);
			comboBoxDirection.FlatStyle = FlatStyle.Flat;
			comboBoxDirection.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			comboBoxDirection.ForeColor = Color.FromArgb(24, 30, 54);
			comboBoxDirection.FormattingEnabled = true;
			comboBoxDirection.Location = new Point(201, 44);
			comboBoxDirection.Name = "comboBoxDirection";
			comboBoxDirection.Size = new Size(290, 26);
			comboBoxDirection.TabIndex = 58;
			// 
			// comboBoxDiscipline
			// 
			comboBoxDiscipline.BackColor = Color.FromArgb(158, 161, 178);
			comboBoxDiscipline.FlatStyle = FlatStyle.Flat;
			comboBoxDiscipline.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			comboBoxDiscipline.ForeColor = Color.FromArgb(24, 30, 54);
			comboBoxDiscipline.FormattingEnabled = true;
			comboBoxDiscipline.Location = new Point(201, 76);
			comboBoxDiscipline.Name = "comboBoxDiscipline";
			comboBoxDiscipline.Size = new Size(290, 26);
			comboBoxDiscipline.TabIndex = 59;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.ForeColor = Color.FromArgb(158, 161, 178);
			label6.Location = new Point(12, 146);
			label6.Name = "label6";
			label6.Size = new Size(112, 20);
			label6.TabIndex = 60;
			label6.Text = "Расчасовка:";
			// 
			// comboBoxScheduleWeek
			// 
			comboBoxScheduleWeek.BackColor = Color.FromArgb(158, 161, 178);
			comboBoxScheduleWeek.FlatStyle = FlatStyle.Flat;
			comboBoxScheduleWeek.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			comboBoxScheduleWeek.ForeColor = Color.FromArgb(24, 30, 54);
			comboBoxScheduleWeek.FormattingEnabled = true;
			comboBoxScheduleWeek.Location = new Point(201, 140);
			comboBoxScheduleWeek.Name = "comboBoxScheduleWeek";
			comboBoxScheduleWeek.Size = new Size(290, 26);
			comboBoxScheduleWeek.TabIndex = 61;
			// 
			// button1
			// 
			button1.BackColor = Color.FromArgb(0, 126, 249);
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = FlatStyle.Flat;
			button1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			button1.ForeColor = Color.FromArgb(24, 30, 54);
			button1.Location = new Point(813, 12);
			button1.Name = "button1";
			button1.Size = new Size(156, 59);
			button1.TabIndex = 62;
			button1.Text = "Создать отчёт";
			button1.UseVisualStyleBackColor = false;
			button1.Click += GenerateReport;
			// 
			// FrmSchedulingDiscipline
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(981, 653);
			Controls.Add(button1);
			Controls.Add(comboBoxScheduleWeek);
			Controls.Add(label6);
			Controls.Add(comboBoxDiscipline);
			Controls.Add(comboBoxDirection);
			Controls.Add(comboBoxGroup);
			Controls.Add(comboBoxFaculties);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(btnDelete);
			Controls.Add(btnAdd);
			Controls.Add(btnReset);
			Controls.Add(lbDbSaveResult);
			Controls.Add(btnSave);
			Controls.Add(dgvSchedules);
			Controls.Add(label5);
			Controls.Add(label2);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FrmSchedulingDiscipline";
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
		private Label label5;
		private Label label2;
		private ComboBox comboBoxFaculties;
		private ComboBox comboBoxGroup;
		private ComboBox comboBoxDirection;
		private ComboBox comboBoxDiscipline;
		private Label label6;
		private ComboBox comboBoxScheduleWeek;
		private Button button1;
	}
}