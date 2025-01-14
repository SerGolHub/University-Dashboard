namespace University_Dasboard
{
    partial class FrmGradeRecords
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
			bindingSource1 = new BindingSource(components);
			npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
			fpGradeAnalysis = new ScottPlot.WinForms.FormsPlot();
			fpGradePrediction = new ScottPlot.WinForms.FormsPlot();
			dtpFrom = new DateTimePicker();
			dtpBy = new DateTimePicker();
			label2 = new Label();
			label1 = new Label();
			label3 = new Label();
			cbFaculty = new ComboBox();
			label4 = new Label();
			((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
			SuspendLayout();
			// 
			// npgsqlDataAdapter1
			// 
			npgsqlDataAdapter1.DeleteCommand = null;
			npgsqlDataAdapter1.InsertCommand = null;
			npgsqlDataAdapter1.SelectCommand = null;
			npgsqlDataAdapter1.UpdateCommand = null;
			// 
			// fpGradeAnalysis
			// 
			fpGradeAnalysis.DisplayScale = 2F;
			fpGradeAnalysis.Location = new Point(62, 194);
			fpGradeAnalysis.Name = "fpGradeAnalysis";
			fpGradeAnalysis.Size = new Size(356, 328);
			fpGradeAnalysis.TabIndex = 0;
			// 
			// fpGradePrediction
			// 
			fpGradePrediction.DisplayScale = 1F;
			fpGradePrediction.Location = new Point(588, 194);
			fpGradePrediction.Name = "fpGradePrediction";
			fpGradePrediction.Size = new Size(356, 328);
			fpGradePrediction.TabIndex = 0;
			// 
			// dtpFrom
			// 
			dtpFrom.CustomFormat = "MMMM yyyy";
			dtpFrom.Format = DateTimePickerFormat.Custom;
			dtpFrom.Location = new Point(373, 90);
			dtpFrom.Name = "dtpFrom";
			dtpFrom.ShowCheckBox = true;
			dtpFrom.ShowUpDown = true;
			dtpFrom.Size = new Size(127, 23);
			dtpFrom.TabIndex = 55;
			// 
			// dtpBy
			// 
			dtpBy.CustomFormat = "MMMM yyyy";
			dtpBy.Format = DateTimePickerFormat.Custom;
			dtpBy.Location = new Point(506, 90);
			dtpBy.Name = "dtpBy";
			dtpBy.ShowCheckBox = true;
			dtpBy.ShowUpDown = true;
			dtpBy.Size = new Size(127, 23);
			dtpBy.TabIndex = 55;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(158, 161, 178);
			label2.Location = new Point(425, 67);
			label2.Name = "label2";
			label2.Size = new Size(26, 20);
			label2.TabIndex = 56;
			label2.Text = "С:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.FromArgb(158, 161, 178);
			label1.Location = new Point(552, 67);
			label1.Name = "label1";
			label1.Size = new Size(37, 20);
			label1.TabIndex = 57;
			label1.Text = "По:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.ForeColor = Color.FromArgb(158, 161, 178);
			label3.Location = new Point(373, 26);
			label3.Name = "label3";
			label3.Size = new Size(260, 31);
			label3.TabIndex = 56;
			label3.Text = "Выберите период:";
			// 
			// cbFaculty
			// 
			cbFaculty.BackColor = Color.FromArgb(158, 161, 178);
			cbFaculty.FlatStyle = FlatStyle.Flat;
			cbFaculty.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbFaculty.ForeColor = Color.FromArgb(24, 30, 54);
			cbFaculty.FormattingEnabled = true;
			cbFaculty.Location = new Point(407, 152);
			cbFaculty.Name = "cbFaculty";
			cbFaculty.Size = new Size(209, 26);
			cbFaculty.TabIndex = 59;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.FromArgb(158, 161, 178);
			label4.Location = new Point(447, 129);
			label4.Name = "label4";
			label4.Size = new Size(108, 20);
			label4.TabIndex = 58;
			label4.Text = "Факультет:";
			// 
			// FrmGradeRecords
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(980, 653);
			Controls.Add(cbFaculty);
			Controls.Add(label4);
			Controls.Add(label1);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(dtpBy);
			Controls.Add(dtpFrom);
			Controls.Add(fpGradePrediction);
			Controls.Add(fpGradeAnalysis);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FrmGradeRecords";
			Text = "FrmGradeRecords";
			((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private BindingSource bindingSource1;
		private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
		private ScottPlot.WinForms.FormsPlot fpGradeAnalysis;
		private ScottPlot.WinForms.FormsPlot fpGradePrediction;
		private DateTimePicker dtpFrom;
		private DateTimePicker dtpBy;
		private Label label2;
		private Label label1;
		private Label label3;
		private ComboBox cbFaculty;
		private Label label4;
	}
}