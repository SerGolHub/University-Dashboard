namespace University_Dasboard
{
	partial class FrmStudentCard
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
			cbStudent = new ComboBox();
			label1 = new Label();
			dgvStudentInfo = new DataGridView();
			label9 = new Label();
			btnGenerate = new Button();
			((System.ComponentModel.ISupportInitialize)dgvStudentInfo).BeginInit();
			SuspendLayout();
			// 
			// cbStudent
			// 
			cbStudent.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbStudent.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbStudent.BackColor = Color.FromArgb(158, 161, 178);
			cbStudent.FlatStyle = FlatStyle.Flat;
			cbStudent.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbStudent.ForeColor = Color.FromArgb(24, 30, 54);
			cbStudent.FormattingEnabled = true;
			cbStudent.Location = new Point(135, 17);
			cbStudent.Name = "cbStudent";
			cbStudent.Size = new Size(207, 26);
			cbStudent.TabIndex = 24;
			cbStudent.SelectedIndexChanged += cbStudent_SelectedIndexChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.FromArgb(158, 161, 178);
			label1.Location = new Point(23, 23);
			label1.Name = "label1";
			label1.Size = new Size(86, 20);
			label1.TabIndex = 23;
			label1.Text = "Студент:";
			// 
			// dgvStudentInfo
			// 
			dgvStudentInfo.AllowUserToAddRows = false;
			dgvStudentInfo.AllowUserToDeleteRows = false;
			dgvStudentInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvStudentInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvStudentInfo.Location = new Point(12, 241);
			dgvStudentInfo.Name = "dgvStudentInfo";
			dgvStudentInfo.ReadOnly = true;
			dgvStudentInfo.Size = new Size(972, 400);
			dgvStudentInfo.TabIndex = 46;
			dgvStudentInfo.RowPostPaint += dgvStudentInfo_RowPostPaint;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label9.ForeColor = Color.FromArgb(158, 161, 178);
			label9.Location = new Point(12, 209);
			label9.Name = "label9";
			label9.Size = new Size(318, 29);
			label9.TabIndex = 45;
			label9.Text = "Информация о студенте";
			// 
			// btnGenerate
			// 
			btnGenerate.BackColor = Color.FromArgb(0, 126, 249);
			btnGenerate.FlatAppearance.BorderSize = 0;
			btnGenerate.FlatStyle = FlatStyle.Flat;
			btnGenerate.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnGenerate.ForeColor = Color.FromArgb(24, 30, 54);
			btnGenerate.Location = new Point(215, 49);
			btnGenerate.Name = "btnGenerate";
			btnGenerate.Size = new Size(127, 48);
			btnGenerate.TabIndex = 47;
			btnGenerate.Text = "Выбрать";
			btnGenerate.UseVisualStyleBackColor = false;
			btnGenerate.Click += btnGenerate_Click;
			// 
			// FrmStudentCard
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(996, 653);
			Controls.Add(btnGenerate);
			Controls.Add(dgvStudentInfo);
			Controls.Add(label9);
			Controls.Add(cbStudent);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FrmStudentCard";
			Text = "FrmStudentCard";
			((System.ComponentModel.ISupportInitialize)dgvStudentInfo).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ComboBox cbStudent;
		private Label label1;
		private DataGridView dgvStudentInfo;
		private Label label9;
		private Button btnGenerate;
	}
}