namespace University_Dasboard
{
    partial class FrmSchedulingDisciplineReport
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            departmentBindingSource1 = new BindingSource(components);
            departmentBindingSource = new BindingSource(components);
            userBindingSource1 = new BindingSource(components);
            userBindingSource = new BindingSource(components);
            comboBoxTeacher = new ComboBox();
            label8 = new Label();
            button2 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            SuspendLayout();
            // 
            // comboBoxTeacher
            // 
            comboBoxTeacher.BackColor = Color.FromArgb(158, 161, 178);
            comboBoxTeacher.FlatStyle = FlatStyle.Flat;
            comboBoxTeacher.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            comboBoxTeacher.ForeColor = Color.FromArgb(24, 30, 54);
            comboBoxTeacher.FormattingEnabled = true;
            comboBoxTeacher.Location = new Point(723, 87);
            comboBoxTeacher.Name = "comboBoxTeacher";
            comboBoxTeacher.Size = new Size(204, 26);
            comboBoxTeacher.TabIndex = 65;
            comboBoxTeacher.SelectedIndexChanged += cbTeacher_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(158, 161, 178);
            label8.Location = new Point(723, 66);
            label8.Name = "label8";
            label8.Size = new Size(130, 18);
            label8.TabIndex = 66;
            label8.Text = "Преподаватель";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 126, 249);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(24, 30, 54);
            button2.Location = new Point(238, 78);
            button2.Name = "button2";
            button2.Size = new Size(240, 132);
            button2.TabIndex = 71;
            button2.Text = "Создать отчёт Pdf";
            button2.UseVisualStyleBackColor = false;
            button2.Click += GenerateReportPdf;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(158, 161, 178);
            label1.Location = new Point(201, 22);
            label1.Name = "label1";
            label1.Size = new Size(363, 29);
            label1.TabIndex = 1;
            label1.Text = "Отчёт по проверке занятий";
            // 
            // FrmSchedulingDisciplineReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(980, 653);
            Controls.Add(button2);
            Controls.Add(label8);
            Controls.Add(comboBoxTeacher);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmSchedulingDisciplineReport";
            Text = "frmScheduling";
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private BindingSource departmentBindingSource1;
		private BindingSource departmentBindingSource;
		private BindingSource userBindingSource1;
		private BindingSource userBindingSource;
        private ComboBox comboBoxTeacher;
        private Label label8;
        private Button button2;
        private Label label1;
    }
}