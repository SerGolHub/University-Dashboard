namespace University_Dasboard
{
    partial class FrmFaculties
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
			tbNewFacultyName = new TextBox();
			label2 = new Label();
			label1 = new Label();
			userBindingSource = new BindingSource(components);
			userBindingSource1 = new BindingSource(components);
			dgvFaculties = new DataGridView();
			departmentBindingSource = new BindingSource(components);
			departmentBindingSource1 = new BindingSource(components);
			btnSave = new Button();
			backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			btnDelete = new Button();
			btnAdd = new Button();
			btnReset = new Button();
			lbDbSaveResult = new Label();
			((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)userBindingSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvFaculties).BeginInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource1).BeginInit();
			SuspendLayout();
			// 
			// tbNewFacultyName
			// 
			tbNewFacultyName.BackColor = Color.FromArgb(158, 161, 178);
			tbNewFacultyName.BorderStyle = BorderStyle.FixedSingle;
			tbNewFacultyName.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			tbNewFacultyName.ForeColor = Color.FromArgb(24, 30, 54);
			tbNewFacultyName.Location = new Point(12, 42);
			tbNewFacultyName.Name = "tbNewFacultyName";
			tbNewFacultyName.Size = new Size(249, 24);
			tbNewFacultyName.TabIndex = 23;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(158, 161, 178);
			label2.Location = new Point(12, 19);
			label2.Name = "label2";
			label2.Size = new Size(244, 20);
			label2.TabIndex = 20;
			label2.Text = "Введите новый факультет:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.FromArgb(158, 161, 178);
			label1.Location = new Point(12, 269);
			label1.Name = "label1";
			label1.Size = new Size(269, 29);
			label1.TabIndex = 21;
			label1.Text = "Список факультетов";
			// 
			// dgvFaculties
			// 
			dgvFaculties.AllowUserToAddRows = false;
			dgvFaculties.AllowUserToDeleteRows = false;
			dgvFaculties.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvFaculties.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvFaculties.Location = new Point(12, 304);
			dgvFaculties.Name = "dgvFaculties";
			dgvFaculties.Size = new Size(862, 337);
			dgvFaculties.TabIndex = 28;
			dgvFaculties.CellValueChanged += dgvFaculties_CellValueChanged;
			dgvFaculties.RowPostPaint += dgvFaculties_RowPostPaint;
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
			btnAdd.Location = new Point(267, 42);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(84, 24);
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
			lbDbSaveResult.Location = new Point(572, 281);
			lbDbSaveResult.Name = "lbDbSaveResult";
			lbDbSaveResult.Size = new Size(302, 20);
			lbDbSaveResult.TabIndex = 22;
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
			lbDbSaveResult.Visible = false;
			// 
			// FrmFaculties
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(980, 653);
			Controls.Add(tbNewFacultyName);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(dgvFaculties);
			Controls.Add(btnSave);
			Controls.Add(btnDelete);
			Controls.Add(btnAdd);
			Controls.Add(btnReset);
			Controls.Add(lbDbSaveResult);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FrmFaculties";
			Text = "FrmFaculties";
			((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)userBindingSource1).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvFaculties).EndInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)departmentBindingSource1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox tbNewFacultyName;
        private Label label2;
        private Label label1;
        private BindingSource userBindingSource;
        private BindingSource userBindingSource1;
        private DataGridView dgvFaculties;
        private BindingSource departmentBindingSource;
        private BindingSource departmentBindingSource1;
        private Button btnSave;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnReset;
        private Label lbDbSaveResult;
    }
}