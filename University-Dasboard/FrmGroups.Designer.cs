namespace University_Dasboard
{
    partial class FrmGroups
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
            dgvGroupList = new DataGridView();
            btnDelete = new Button();
            btnReset = new Button();
            btnSave = new Button();
            lbDbSaveResult = new Label();
            label9 = new Label();
            cbDirection = new ComboBox();
            cbDepartment = new ComboBox();
            cbFaculty = new ComboBox();
            btnAdd = new Button();
            tbGroupName = new TextBox();
            label10 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            tbMaxCourse = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvGroupList).BeginInit();
            SuspendLayout();
            // 
            // dgvGroupList
            // 
            dgvGroupList.AllowUserToAddRows = false;
            dgvGroupList.AllowUserToDeleteRows = false;
            dgvGroupList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGroupList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGroupList.Location = new Point(12, 284);
            dgvGroupList.Name = "dgvGroupList";
            dgvGroupList.Size = new Size(862, 350);
            dgvGroupList.TabIndex = 53;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(0, 126, 249);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.FromArgb(24, 30, 54);
            btnDelete.Location = new Point(880, 592);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 42);
            btnDelete.TabIndex = 50;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(0, 126, 249);
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.FromArgb(24, 30, 54);
            btnReset.Location = new Point(880, 544);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(88, 42);
            btnReset.TabIndex = 51;
            btnReset.Text = "Сбросить изменения";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 126, 249);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.FromArgb(24, 30, 54);
            btnSave.Location = new Point(880, 284);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 42);
            btnSave.TabIndex = 52;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // lbDbSaveResult
            // 
            lbDbSaveResult.AutoSize = true;
            lbDbSaveResult.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
            lbDbSaveResult.Location = new Point(572, 259);
            lbDbSaveResult.Name = "lbDbSaveResult";
            lbDbSaveResult.Size = new Size(302, 20);
            lbDbSaveResult.TabIndex = 48;
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
            lbDbSaveResult.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(158, 161, 178);
            label9.Location = new Point(12, 252);
            label9.Name = "label9";
            label9.Size = new Size(182, 29);
            label9.TabIndex = 49;
            label9.Text = "Список групп";
            // 
            // cbDirection
            // 
            cbDirection.BackColor = Color.FromArgb(158, 161, 178);
            cbDirection.FlatStyle = FlatStyle.Flat;
            cbDirection.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            cbDirection.ForeColor = Color.FromArgb(24, 30, 54);
            cbDirection.FormattingEnabled = true;
            cbDirection.Location = new Point(250, 99);
            cbDirection.Name = "cbDirection";
            cbDirection.Size = new Size(209, 26);
            cbDirection.TabIndex = 46;
            // 
            // cbDepartment
            // 
            cbDepartment.BackColor = Color.FromArgb(158, 161, 178);
            cbDepartment.FlatStyle = FlatStyle.Flat;
            cbDepartment.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            cbDepartment.ForeColor = Color.FromArgb(24, 30, 54);
            cbDepartment.FormattingEnabled = true;
            cbDepartment.Location = new Point(250, 67);
            cbDepartment.Name = "cbDepartment";
            cbDepartment.Size = new Size(209, 26);
            cbDepartment.TabIndex = 45;
            // 
            // cbFaculty
            // 
            cbFaculty.BackColor = Color.FromArgb(158, 161, 178);
            cbFaculty.FlatStyle = FlatStyle.Flat;
            cbFaculty.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            cbFaculty.ForeColor = Color.FromArgb(24, 30, 54);
            cbFaculty.FormattingEnabled = true;
            cbFaculty.Location = new Point(250, 35);
            cbFaculty.Name = "cbFaculty";
            cbFaculty.Size = new Size(209, 26);
            cbFaculty.TabIndex = 44;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 126, 249);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(24, 30, 54);
            btnAdd.Location = new Point(12, 177);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 44);
            btnAdd.TabIndex = 41;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // tbGroupName
            // 
            tbGroupName.BackColor = Color.FromArgb(158, 161, 178);
            tbGroupName.BorderStyle = BorderStyle.FixedSingle;
            tbGroupName.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbGroupName.ForeColor = Color.FromArgb(24, 30, 54);
            tbGroupName.Location = new Point(177, 5);
            tbGroupName.Name = "tbGroupName";
            tbGroupName.Size = new Size(282, 24);
            tbGroupName.TabIndex = 38;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(158, 161, 178);
            label10.Location = new Point(12, 105);
            label10.Name = "label10";
            label10.Size = new Size(128, 20);
            label10.TabIndex = 36;
            label10.Text = "Направление:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(158, 161, 178);
            label5.Location = new Point(12, 73);
            label5.Name = "label5";
            label5.Size = new Size(93, 20);
            label5.TabIndex = 35;
            label5.Text = "Кафедра:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(158, 161, 178);
            label4.Location = new Point(12, 41);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 34;
            label4.Text = "Факультет:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(158, 161, 178);
            label1.Location = new Point(12, 137);
            label1.Name = "label1";
            label1.Size = new Size(182, 20);
            label1.TabIndex = 32;
            label1.Text = "Максимальный курс:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(158, 161, 178);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(159, 20);
            label2.TabIndex = 29;
            label2.Text = "Название группы:";
            // 
            // tbMaxCourse
            // 
            tbMaxCourse.BackColor = Color.FromArgb(158, 161, 178);
            tbMaxCourse.BorderStyle = BorderStyle.FixedSingle;
            tbMaxCourse.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbMaxCourse.ForeColor = Color.FromArgb(24, 30, 54);
            tbMaxCourse.Location = new Point(400, 131);
            tbMaxCourse.Name = "tbMaxCourse";
            tbMaxCourse.Size = new Size(59, 24);
            tbMaxCourse.TabIndex = 54;
            // 
            // FrmGroups
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(980, 653);
            Controls.Add(tbMaxCourse);
            Controls.Add(dgvGroupList);
            Controls.Add(btnDelete);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(lbDbSaveResult);
            Controls.Add(label9);
            Controls.Add(cbDirection);
            Controls.Add(cbDepartment);
            Controls.Add(cbFaculty);
            Controls.Add(btnAdd);
            Controls.Add(tbGroupName);
            Controls.Add(label10);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmGroups";
            Text = "FrmGroups";
            ((System.ComponentModel.ISupportInitialize)dgvGroupList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvGroupList;
        private Button btnDelete;
        private Button btnReset;
        private Button btnSave;
        private Label lbDbSaveResult;
        private Label label9;
        private ComboBox cbDirection;
        private ComboBox cbDepartment;
        private ComboBox cbFaculty;
        private Button btnAdd;
        private TextBox tbGroupName;
        private Label label10;
        private Label label5;
        private Label label4;
        private Label label1;
        private Label label2;
        private TextBox tbMaxCourse;
    }
}