using System.Windows.Forms;

namespace University_Dasboard
{
    partial class FrmTeachersConstraint
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
            btnAdd = new Button();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            tbNote = new TextBox();
            comboBoxTeachers = new ComboBox();
            dgvTeacherConstraintList = new DataGridView();
            btnDelete = new Button();
            btnReset = new Button();
            btnSave = new Button();
            lbDbSaveResult = new Label();
            label9 = new Label();
            dateTimePickerStartTime = new DateTimePicker();
            dateTimePickerEndTime = new DateTimePicker();
            cbDayOfWeek = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvTeacherConstraintList).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 126, 249);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(24, 30, 54);
            btnAdd.Location = new Point(470, 106);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(116, 49);
            btnAdd.TabIndex = 21;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAddConstraint_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(158, 161, 178);
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 19;
            label2.Text = "День недели:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(158, 161, 178);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(150, 20);
            label1.TabIndex = 19;
            label1.Text = "Преподаватель:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(158, 161, 178);
            label3.Location = new Point(12, 100);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 19;
            label3.Text = "Время с:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(158, 161, 178);
            label4.Location = new Point(12, 135);
            label4.Name = "label4";
            label4.Size = new Size(95, 20);
            label4.TabIndex = 19;
            label4.Text = "Время до:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(158, 161, 178);
            label5.Location = new Point(10, 178);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 19;
            label5.Text = "Описание:";
            // 
            // tbNote
            // 
            tbNote.BackColor = Color.FromArgb(158, 161, 178);
            tbNote.BorderStyle = BorderStyle.FixedSingle;
            tbNote.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbNote.ForeColor = Color.FromArgb(24, 30, 54);
            tbNote.Location = new Point(217, 174);
            tbNote.Name = "tbNote";
            tbNote.Size = new Size(185, 24);
            tbNote.TabIndex = 20;
            // 
            // comboBoxTeachers
            // 
            comboBoxTeachers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxTeachers.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxTeachers.BackColor = Color.FromArgb(158, 161, 178);
            comboBoxTeachers.FlatStyle = FlatStyle.Flat;
            comboBoxTeachers.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            comboBoxTeachers.ForeColor = Color.FromArgb(24, 30, 54);
            comboBoxTeachers.FormattingEnabled = true;
            comboBoxTeachers.Items.AddRange(new object[] { "Да", "Нет" });
            comboBoxTeachers.Location = new Point(168, 16);
            comboBoxTeachers.Name = "comboBoxTeachers";
            comboBoxTeachers.Size = new Size(234, 26);
            comboBoxTeachers.TabIndex = 22;
            comboBoxTeachers.Text = "Выберите преподавателя";
            comboBoxTeachers.SelectedIndexChanged += cbTeacher_SelectedIndexChanged;
            // 
            // dgvTeacherConstraintList
            // 
            dgvTeacherConstraintList.AllowUserToAddRows = false;
            dgvTeacherConstraintList.AllowUserToDeleteRows = false;
            dgvTeacherConstraintList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTeacherConstraintList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeacherConstraintList.Location = new Point(12, 261);
            dgvTeacherConstraintList.Name = "dgvTeacherConstraintList";
            dgvTeacherConstraintList.Size = new Size(862, 380);
            dgvTeacherConstraintList.TabIndex = 28;
            dgvTeacherConstraintList.CellFormatting += dgvTeacherConstraintList_CellFormatting;
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
            btnReset.TabIndex = 26;
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
            btnSave.Location = new Point(623, 106);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(116, 52);
            btnSave.TabIndex = 27;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lbDbSaveResult
            // 
            lbDbSaveResult.AutoSize = true;
            lbDbSaveResult.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
            lbDbSaveResult.Location = new Point(572, 223);
            lbDbSaveResult.Name = "lbDbSaveResult";
            lbDbSaveResult.Size = new Size(302, 20);
            lbDbSaveResult.TabIndex = 23;
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
            lbDbSaveResult.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(158, 161, 178);
            label9.Location = new Point(12, 216);
            label9.Name = "label9";
            label9.Size = new Size(277, 29);
            label9.TabIndex = 24;
            label9.Text = "Список ограничений";
            // 
            // dateTimePickerStartTime
            // 
            dateTimePickerStartTime.Format = DateTimePickerFormat.Time;
            dateTimePickerStartTime.Location = new Point(199, 97);
            dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            dateTimePickerStartTime.ShowUpDown = true;
            dateTimePickerStartTime.CustomFormat = "HH:mm";
            dateTimePickerStartTime.Size = new Size(203, 23);
            dateTimePickerStartTime.TabIndex = 31;
            // 
            // dateTimePickerEndTime
            // 
            dateTimePickerEndTime.Format = DateTimePickerFormat.Time;
            dateTimePickerEndTime.Location = new Point(199, 135);
            dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            dateTimePickerEndTime.ShowUpDown = true;
            dateTimePickerEndTime.CustomFormat = "HH:mm";
            dateTimePickerEndTime.Size = new Size(203, 23);
            dateTimePickerEndTime.TabIndex = 38;
            // 
            // cbDayOfWeek
            // 
            cbDayOfWeek.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbDayOfWeek.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbDayOfWeek.BackColor = Color.FromArgb(158, 161, 178);
            cbDayOfWeek.FlatStyle = FlatStyle.Flat;
            cbDayOfWeek.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            cbDayOfWeek.ForeColor = Color.FromArgb(24, 30, 54);
            cbDayOfWeek.FormattingEnabled = true;
            cbDayOfWeek.Items.AddRange(new object[] { "Да", "Нет" });
            cbDayOfWeek.Location = new Point(168, 52);
            cbDayOfWeek.Name = "cbDayOfWeek";
            cbDayOfWeek.Size = new Size(234, 26);
            cbDayOfWeek.TabIndex = 39;
            cbDayOfWeek.Text = "Выберите день недели";
            cbDayOfWeek.SelectedIndexChanged += cbDayOfWeek_SelectedIndexChanged;
            // 
            // FrmTeachersConstraint
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(980, 653);
            Controls.Add(cbDayOfWeek);
            Controls.Add(dateTimePickerEndTime);
            Controls.Add(dateTimePickerStartTime);
            Controls.Add(dgvTeacherConstraintList);
            Controls.Add(btnDelete);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(lbDbSaveResult);
            Controls.Add(label9);
            Controls.Add(comboBoxTeachers);
            Controls.Add(btnAdd);
            Controls.Add(tbNote);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTeachersConstraint";
            Text = "frmStudentList";
            ((System.ComponentModel.ISupportInitialize)dgvTeacherConstraintList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox tbNote;
        private ComboBox comboBoxTeachers;
        private DataGridView dgvTeacherConstraintList;
        private Button btnDelete;
        private Button btnReset;
        private Button btnSave;
        private Label lbDbSaveResult;
        private Label label9;
        private DateTimePicker dateTimePickerStartTime;
        private DateTimePicker dateTimePickerEndTime;
        private ComboBox cbDayOfWeek;
    }
}