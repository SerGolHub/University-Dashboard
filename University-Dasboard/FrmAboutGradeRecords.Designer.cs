namespace University_Dasboard
{
	partial class FrmAboutGradeRecords
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
			btnGenerate = new Button();
			dgvReportList = new DataGridView();
			label9 = new Label();
			cbGroup = new ComboBox();
			cbCourse = new ComboBox();
			cbStudent = new ComboBox();
			chbGroup = new CheckBox();
			chbCourse = new CheckBox();
			chbStudent = new CheckBox();
			button1 = new Button();
			((System.ComponentModel.ISupportInitialize)dgvReportList).BeginInit();
			SuspendLayout();
			// 
			// btnGenerate
			// 
			btnGenerate.BackColor = Color.FromArgb(0, 126, 249);
			btnGenerate.FlatAppearance.BorderSize = 0;
			btnGenerate.FlatStyle = FlatStyle.Flat;
			btnGenerate.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnGenerate.ForeColor = Color.FromArgb(24, 30, 54);
			btnGenerate.Location = new Point(12, 169);
			btnGenerate.Name = "btnGenerate";
			btnGenerate.Size = new Size(127, 37);
			btnGenerate.TabIndex = 42;
			btnGenerate.Text = "Сформировать";
			btnGenerate.UseVisualStyleBackColor = false;
			btnGenerate.Click += btnGenerate_Click;
			// 
			// dgvReportList
			// 
			dgvReportList.AllowUserToAddRows = false;
			dgvReportList.AllowUserToDeleteRows = false;
			dgvReportList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvReportList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvReportList.Location = new Point(12, 241);
			dgvReportList.Name = "dgvReportList";
			dgvReportList.ReadOnly = true;
			dgvReportList.Size = new Size(972, 400);
			dgvReportList.TabIndex = 44;
			dgvReportList.RowPostPaint += dgvStudentList_RowPostPaint;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label9.ForeColor = Color.FromArgb(158, 161, 178);
			label9.Location = new Point(12, 209);
			label9.Name = "label9";
			label9.Size = new Size(308, 29);
			label9.TabIndex = 43;
			label9.Text = "Отчёт об успеваемости";
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
			cbGroup.Location = new Point(36, 42);
			cbGroup.Name = "cbGroup";
			cbGroup.Size = new Size(244, 26);
			cbGroup.TabIndex = 47;
			cbGroup.Visible = false;
			cbGroup.SelectedIndexChanged += cbGroup_SelectedIndexChanged;
			// 
			// cbCourse
			// 
			cbCourse.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbCourse.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbCourse.BackColor = Color.FromArgb(158, 161, 178);
			cbCourse.FlatStyle = FlatStyle.Flat;
			cbCourse.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbCourse.ForeColor = Color.FromArgb(24, 30, 54);
			cbCourse.FormattingEnabled = true;
			cbCourse.Location = new Point(455, 42);
			cbCourse.Name = "cbCourse";
			cbCourse.Size = new Size(70, 26);
			cbCourse.TabIndex = 48;
			cbCourse.Visible = false;
			cbCourse.SelectedIndexChanged += cbCourse_SelectedIndexChanged;
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
			cbStudent.Location = new Point(705, 42);
			cbStudent.Name = "cbStudent";
			cbStudent.Size = new Size(232, 26);
			cbStudent.TabIndex = 48;
			cbStudent.Visible = false;
			cbStudent.SelectedIndexChanged += cbStudent_SelectedIndexChanged;
			// 
			// chbGroup
			// 
			chbGroup.AutoSize = true;
			chbGroup.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
			chbGroup.ForeColor = Color.FromArgb(158, 161, 178);
			chbGroup.Location = new Point(36, 12);
			chbGroup.Name = "chbGroup";
			chbGroup.Size = new Size(244, 24);
			chbGroup.TabIndex = 49;
			chbGroup.Text = "Сформировать по группе";
			chbGroup.UseVisualStyleBackColor = true;
			chbGroup.CheckedChanged += chbGroup_CheckedChanged;
			// 
			// chbCourse
			// 
			chbCourse.AutoSize = true;
			chbCourse.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
			chbCourse.ForeColor = Color.FromArgb(158, 161, 178);
			chbCourse.Location = new Point(374, 12);
			chbCourse.Name = "chbCourse";
			chbCourse.Size = new Size(232, 24);
			chbCourse.TabIndex = 49;
			chbCourse.Text = "Сформировать по курсу";
			chbCourse.UseVisualStyleBackColor = true;
			chbCourse.CheckedChanged += chbCourse_CheckedChanged;
			// 
			// chbStudent
			// 
			chbStudent.AutoSize = true;
			chbStudent.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
			chbStudent.ForeColor = Color.FromArgb(158, 161, 178);
			chbStudent.Location = new Point(691, 12);
			chbStudent.Name = "chbStudent";
			chbStudent.Size = new Size(265, 24);
			chbStudent.TabIndex = 49;
			chbStudent.Text = "Сформировать по студенту";
			chbStudent.UseVisualStyleBackColor = true;
			chbStudent.CheckedChanged += chbStudent_CheckedChanged;
			// 
			// button1
			// 
			button1.BackColor = Color.FromArgb(0, 126, 249);
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = FlatStyle.Flat;
			button1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			button1.ForeColor = Color.FromArgb(24, 30, 54);
			button1.Location = new Point(857, 169);
			button1.Name = "button1";
			button1.Size = new Size(127, 66);
			button1.TabIndex = 42;
			button1.Text = "Экспорт в Excel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += btnGenerate_Click;
			// 
			// FrmAboutGradeRecords
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(996, 653);
			Controls.Add(chbStudent);
			Controls.Add(chbCourse);
			Controls.Add(chbGroup);
			Controls.Add(cbGroup);
			Controls.Add(cbStudent);
			Controls.Add(cbCourse);
			Controls.Add(dgvReportList);
			Controls.Add(label9);
			Controls.Add(button1);
			Controls.Add(btnGenerate);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FrmAboutGradeRecords";
			Text = "FrmAboutGradeRecords";
			((System.ComponentModel.ISupportInitialize)dgvReportList).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnGenerate;
		private DataGridView dgvReportList;
		private Label label9;
		private ComboBox cbGroup;
		private ComboBox cbCourse;
		private ComboBox cbStudent;
		private CheckBox chbGroup;
		private CheckBox chbCourse;
		private CheckBox chbStudent;
		private Button button1;
	}
}