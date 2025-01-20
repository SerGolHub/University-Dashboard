namespace University_Dasboard
{
    partial class FrmDepartments
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
			tbNewDepartmentName = new TextBox();
			label2 = new Label();
			userBindingSource = new BindingSource(components);
			userBindingSource1 = new BindingSource(components);
			dgvDepartments = new DataGridView();
			departmentBindingSource3 = new BindingSource(components);
			departmentBindingSource = new BindingSource(components);
			departmentBindingSource1 = new BindingSource(components);
			btnSave = new Button();
			backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			btnAdd = new Button();
			btnDelete = new Button();
			btnReset = new Button();
			lbDbSaveResult = new Label();
			cbFaculties = new ComboBox();
			label4 = new Label();
			departmentBindingSource2 = new BindingSource(components);
			Id = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			facultyIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			DgvCbFaculty = new DataGridViewComboBoxColumn();
			((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)userBindingSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvDepartments).BeginInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource3).BeginInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource2).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.FromArgb(158, 161, 178);
			label1.Location = new Point(12, 269);
			label1.Name = "label1";
			label1.Size = new Size(202, 29);
			label1.TabIndex = 1;
			label1.Text = "Список кафедр";
			// 
			// tbNewDepartmentName
			// 
			tbNewDepartmentName.BackColor = Color.FromArgb(158, 161, 178);
			tbNewDepartmentName.BorderStyle = BorderStyle.FixedSingle;
			tbNewDepartmentName.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			tbNewDepartmentName.ForeColor = Color.FromArgb(24, 30, 54);
			tbNewDepartmentName.Location = new Point(12, 42);
			tbNewDepartmentName.Name = "tbNewDepartmentName";
			tbNewDepartmentName.Size = new Size(369, 24);
			tbNewDepartmentName.TabIndex = 8;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(158, 161, 178);
			label2.Location = new Point(12, 19);
			label2.Name = "label2";
			label2.Size = new Size(219, 20);
			label2.TabIndex = 1;
			label2.Text = "Введите новую кафедру";
			// 
			// dgvDepartments
			// 
			dgvDepartments.AllowUserToAddRows = false;
			dgvDepartments.AllowUserToDeleteRows = false;
			dgvDepartments.AutoGenerateColumns = false;
			dgvDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvDepartments.Columns.AddRange(new DataGridViewColumn[] { Id, nameDataGridViewTextBoxColumn, facultyIdDataGridViewTextBoxColumn, DgvCbFaculty });
			dgvDepartments.DataSource = departmentBindingSource3;
			dgvDepartments.Location = new Point(12, 304);
			dgvDepartments.Name = "dgvDepartments";
			dgvDepartments.Size = new Size(862, 337);
			dgvDepartments.TabIndex = 19;
			dgvDepartments.CellClick += dgvDepartments_CellClick;
			dgvDepartments.CellValueChanged += dgvDepartments_CellValueChanged;
			dgvDepartments.RowPostPaint += dgvDepartments_RowPostPaint;
			// 
			// departmentBindingSource3
			// 
			departmentBindingSource3.DataSource = typeof(Database.Models.Department);
			// 
			// btnSave
			// 
			btnSave.BackColor = Color.FromArgb(0, 126, 249);
			btnSave.FlatAppearance.BorderSize = 0;
			btnSave.FlatStyle = FlatStyle.Flat;
			btnSave.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnSave.ForeColor = Color.FromArgb(24, 30, 54);
			btnSave.Location = new Point(880, 304);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(88, 42);
			btnSave.TabIndex = 18;
			btnSave.Text = "Сохранить";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += btnSave_Click;
			// 
			// btnAdd
			// 
			btnAdd.BackColor = Color.FromArgb(0, 126, 249);
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = FlatStyle.Flat;
			btnAdd.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnAdd.ForeColor = Color.FromArgb(24, 30, 54);
			btnAdd.Location = new Point(12, 148);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(86, 26);
			btnAdd.TabIndex = 18;
			btnAdd.Text = "Добавить";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += btnAdd_Click;
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
			btnDelete.TabIndex = 18;
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
			btnReset.TabIndex = 18;
			btnReset.Text = "Сбросить изменения";
			btnReset.UseVisualStyleBackColor = false;
			btnReset.Click += btnReset_Click;
			// 
			// lbDbSaveResult
			// 
			lbDbSaveResult.AutoSize = true;
			lbDbSaveResult.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
			lbDbSaveResult.Location = new Point(559, 281);
			lbDbSaveResult.Name = "lbDbSaveResult";
			lbDbSaveResult.Size = new Size(302, 20);
			lbDbSaveResult.TabIndex = 1;
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
			lbDbSaveResult.Visible = false;
			// 
			// cbFaculties
			// 
			cbFaculties.BackColor = Color.FromArgb(158, 161, 178);
			cbFaculties.FlatStyle = FlatStyle.Flat;
			cbFaculties.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbFaculties.ForeColor = Color.FromArgb(24, 30, 54);
			cbFaculties.FormattingEnabled = true;
			cbFaculties.Location = new Point(12, 99);
			cbFaculties.Name = "cbFaculties";
			cbFaculties.Size = new Size(369, 26);
			cbFaculties.TabIndex = 24;
			cbFaculties.SelectedValueChanged += cbFaculties_SelectedValueChanged;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.FromArgb(158, 161, 178);
			label4.Location = new Point(12, 77);
			label4.Name = "label4";
			label4.Size = new Size(108, 20);
			label4.TabIndex = 23;
			label4.Text = "Факультет:";
			// 
			// departmentBindingSource2
			// 
			departmentBindingSource2.DataSource = typeof(Database.Models.Department);
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
			nameDataGridViewTextBoxColumn.HeaderText = "Кафедра";
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			// 
			// facultyIdDataGridViewTextBoxColumn
			// 
			facultyIdDataGridViewTextBoxColumn.DataPropertyName = "FacultyId";
			facultyIdDataGridViewTextBoxColumn.HeaderText = "FacultyId";
			facultyIdDataGridViewTextBoxColumn.Name = "facultyIdDataGridViewTextBoxColumn";
			facultyIdDataGridViewTextBoxColumn.Visible = false;
			// 
			// DgvCbFaculty
			// 
			DgvCbFaculty.HeaderText = "Факультет";
			DgvCbFaculty.Name = "DgvCbFaculty";
			// 
			// FrmDepartments
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(980, 653);
			Controls.Add(cbFaculties);
			Controls.Add(label4);
			Controls.Add(dgvDepartments);
			Controls.Add(btnDelete);
			Controls.Add(btnAdd);
			Controls.Add(btnReset);
			Controls.Add(btnSave);
			Controls.Add(tbNewDepartmentName);
			Controls.Add(lbDbSaveResult);
			Controls.Add(label2);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FrmDepartments";
			Text = "frmDepartmentList";
			((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)userBindingSource1).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvDepartments).EndInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource3).EndInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource1).EndInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private TextBox tbNewDepartmentName;
        private Label label2;
        private BindingSource userBindingSource;
        private BindingSource userBindingSource1;
        private DataGridView dgvDepartments;
        private Button btnSave;
        private BindingSource departmentBindingSource;
        private BindingSource departmentBindingSource1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnReset;
        private Label lbDbSaveResult;
        private ComboBox cbFaculties;
        private Label label4;
		private BindingSource departmentBindingSource2;
		private BindingSource departmentBindingSource3;
		private DataGridViewTextBoxColumn Id;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn facultyIdDataGridViewTextBoxColumn;
		private DataGridViewComboBoxColumn DgvCbFaculty;
	}
}