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
			dtpPeriodFrom = new DateTimePicker();
			dtpPeriodBy = new DateTimePicker();
			label2 = new Label();
			label1 = new Label();
			label3 = new Label();
			label4 = new Label();
			cbFaculty = new ComboBox();
			lbSelectedFaculty = new Label();
			btnShow = new Button();
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
			fpGradeAnalysis.Location = new Point(12, 219);
			fpGradeAnalysis.Name = "fpGradeAnalysis";
			fpGradeAnalysis.Size = new Size(450, 422);
			fpGradeAnalysis.TabIndex = 0;
			// 
			// fpGradePrediction
			// 
			fpGradePrediction.DisplayScale = 1F;
			fpGradePrediction.Location = new Point(518, 219);
			fpGradePrediction.Name = "fpGradePrediction";
			fpGradePrediction.Size = new Size(450, 422);
			fpGradePrediction.TabIndex = 0;
			// 
			// dtpPeriodFrom
			// 
			dtpPeriodFrom.CustomFormat = "MMMM yyyy";
			dtpPeriodFrom.Format = DateTimePickerFormat.Custom;
			dtpPeriodFrom.Location = new Point(12, 73);
			dtpPeriodFrom.Name = "dtpPeriodFrom";
			dtpPeriodFrom.ShowCheckBox = true;
			dtpPeriodFrom.ShowUpDown = true;
			dtpPeriodFrom.Size = new Size(127, 23);
			dtpPeriodFrom.TabIndex = 55;
			// 
			// dtpPeriodBy
			// 
			dtpPeriodBy.CustomFormat = "MMMM yyyy";
			dtpPeriodBy.Format = DateTimePickerFormat.Custom;
			dtpPeriodBy.Location = new Point(145, 73);
			dtpPeriodBy.Name = "dtpPeriodBy";
			dtpPeriodBy.ShowCheckBox = true;
			dtpPeriodBy.ShowUpDown = true;
			dtpPeriodBy.Size = new Size(127, 23);
			dtpPeriodBy.TabIndex = 55;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(158, 161, 178);
			label2.Location = new Point(64, 50);
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
			label1.Location = new Point(191, 50);
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
			label3.Location = new Point(12, 9);
			label3.Name = "label3";
			label3.Size = new Size(260, 31);
			label3.TabIndex = 56;
			label3.Text = "Выберите период:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
			label4.ForeColor = Color.FromArgb(158, 161, 178);
			label4.Location = new Point(313, 9);
			label4.Name = "label4";
			label4.Size = new Size(166, 31);
			label4.TabIndex = 58;
			label4.Text = "Факультет:";
			// 
			// cbFaculty
			// 
			cbFaculty.BackColor = Color.FromArgb(158, 161, 178);
			cbFaculty.FlatStyle = FlatStyle.Flat;
			cbFaculty.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
			cbFaculty.ForeColor = Color.FromArgb(24, 30, 54);
			cbFaculty.FormattingEnabled = true;
			cbFaculty.Location = new Point(295, 70);
			cbFaculty.Name = "cbFaculty";
			cbFaculty.Size = new Size(209, 26);
			cbFaculty.TabIndex = 59;
			cbFaculty.SelectedIndexChanged += cbFaculty_SelectedIndexChanged;
			// 
			// lbSelectedFaculty
			// 
			lbSelectedFaculty.AutoSize = true;
			lbSelectedFaculty.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbSelectedFaculty.ForeColor = Color.FromArgb(158, 161, 178);
			lbSelectedFaculty.Location = new Point(24, 187);
			lbSelectedFaculty.Name = "lbSelectedFaculty";
			lbSelectedFaculty.Size = new Size(421, 29);
			lbSelectedFaculty.TabIndex = 58;
			lbSelectedFaculty.Text = "Анализ успеваемости за период";
			// 
			// btnShow
			// 
			btnShow.BackColor = Color.FromArgb(0, 126, 249);
			btnShow.FlatAppearance.BorderSize = 0;
			btnShow.FlatStyle = FlatStyle.Flat;
			btnShow.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnShow.ForeColor = Color.FromArgb(24, 30, 54);
			btnShow.Location = new Point(545, 52);
			btnShow.Name = "btnShow";
			btnShow.Size = new Size(120, 44);
			btnShow.TabIndex = 60;
			btnShow.Text = "Посмотреть";
			btnShow.UseVisualStyleBackColor = false;
			btnShow.Click += btnShow_Click;
			// 
			// FrmGradeRecords
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(46, 51, 73);
			ClientSize = new Size(980, 653);
			Controls.Add(btnShow);
			Controls.Add(cbFaculty);
			Controls.Add(lbSelectedFaculty);
			Controls.Add(label4);
			Controls.Add(label1);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(dtpPeriodBy);
			Controls.Add(dtpPeriodFrom);
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
		private DateTimePicker dtpPeriodFrom;
		private DateTimePicker dtpPeriodBy;
		private Label label2;
		private Label label1;
		private Label label3;
		private Label label4;
		private ComboBox cbFaculty;
		private Label lbSelectedFaculty;
		private Button btnShow;
	}
}