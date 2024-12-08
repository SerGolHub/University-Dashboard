namespace University_Dasboard
{
    partial class FrmDirections
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
            tbNewDirectionName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            userBindingSource = new BindingSource(components);
            userBindingSource1 = new BindingSource(components);
            dgvDirections = new DataGridView();
            departmentBindingSource = new BindingSource(components);
            departmentBindingSource1 = new BindingSource(components);
            btnSave = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnDelete = new Button();
            btnAdd = new Button();
            btnReset = new Button();
            lbDbSaveResult = new Label();
            label3 = new Label();
            cbDepartments = new ComboBox();
            tbDirectionCode = new TextBox();
            label4 = new Label();
            label5 = new Label();
            tbMaxCourse = new TextBox();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDirections).BeginInit();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // tbNewDirectionName
            // 
            tbNewDirectionName.BackColor = Color.FromArgb(158, 161, 178);
            tbNewDirectionName.BorderStyle = BorderStyle.FixedSingle;
            tbNewDirectionName.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbNewDirectionName.ForeColor = Color.FromArgb(24, 30, 54);
            tbNewDirectionName.Location = new Point(12, 34);
            tbNewDirectionName.Name = "tbNewDirectionName";
            tbNewDirectionName.Size = new Size(369, 24);
            tbNewDirectionName.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(158, 161, 178);
            label2.Location = new Point(12, 11);
            label2.Name = "label2";
            label2.Size = new Size(259, 20);
            label2.TabIndex = 29;
            label2.Text = "Введите новое направление:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(158, 161, 178);
            label1.Location = new Point(17, 277);
            label1.Name = "label1";
            label1.Size = new Size(279, 29);
            label1.TabIndex = 30;
            label1.Text = "Список направлений";
            // 
            // dgvDirections
            // 
            dgvDirections.AllowUserToAddRows = false;
            dgvDirections.AllowUserToDeleteRows = false;
            dgvDirections.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDirections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDirections.Location = new Point(12, 312);
            dgvDirections.Name = "dgvDirections";
            dgvDirections.Size = new Size(793, 335);
            dgvDirections.TabIndex = 37;
            dgvDirections.CellValueChanged += dgvDirections_CellValueChanged;
            dgvDirections.RowPostPaint += dgvDirections_RowPostPaint;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 126, 249);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.FromArgb(24, 30, 54);
            btnSave.Location = new Point(811, 312);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 42);
            btnSave.TabIndex = 33;
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
            btnDelete.Location = new Point(811, 604);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 42);
            btnDelete.TabIndex = 34;
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
            btnAdd.Location = new Point(12, 151);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(84, 24);
            btnAdd.TabIndex = 35;
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
            btnReset.Location = new Point(811, 556);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(88, 42);
            btnReset.TabIndex = 36;
            btnReset.Text = "Сбросить изменения";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // lbDbSaveResult
            // 
            lbDbSaveResult.AutoSize = true;
            lbDbSaveResult.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
            lbDbSaveResult.Location = new Point(503, 286);
            lbDbSaveResult.Name = "lbDbSaveResult";
            lbDbSaveResult.Size = new Size(302, 20);
            lbDbSaveResult.TabIndex = 31;
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
            lbDbSaveResult.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(158, 161, 178);
            label3.Location = new Point(12, 70);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 38;
            label3.Text = "Кафедра:";
            // 
            // cbDepartments
            // 
            cbDepartments.BackColor = Color.FromArgb(158, 161, 178);
            cbDepartments.FlatStyle = FlatStyle.Flat;
            cbDepartments.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            cbDepartments.ForeColor = Color.FromArgb(24, 30, 54);
            cbDepartments.FormattingEnabled = true;
            cbDepartments.Location = new Point(12, 93);
            cbDepartments.Name = "cbDepartments";
            cbDepartments.Size = new Size(369, 26);
            cbDepartments.TabIndex = 40;
            cbDepartments.SelectedValueChanged += cbDepartment_SelectedValueChanged;
            // 
            // tbDirectionCode
            // 
            tbDirectionCode.BackColor = Color.FromArgb(158, 161, 178);
            tbDirectionCode.BorderStyle = BorderStyle.FixedSingle;
            tbDirectionCode.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbDirectionCode.ForeColor = Color.FromArgb(24, 30, 54);
            tbDirectionCode.Location = new Point(413, 34);
            tbDirectionCode.Name = "tbDirectionCode";
            tbDirectionCode.Size = new Size(158, 24);
            tbDirectionCode.TabIndex = 42;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(158, 161, 178);
            label4.Location = new Point(413, 11);
            label4.Name = "label4";
            label4.Size = new Size(158, 20);
            label4.TabIndex = 41;
            label4.Text = "Код направления";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(158, 161, 178);
            label5.Location = new Point(413, 70);
            label5.Name = "label5";
            label5.Size = new Size(224, 20);
            label5.TabIndex = 41;
            label5.Text = "Цифра последнего курса";
            // 
            // tbMaxCourse
            // 
            tbMaxCourse.BackColor = Color.FromArgb(158, 161, 178);
            tbMaxCourse.BorderStyle = BorderStyle.FixedSingle;
            tbMaxCourse.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbMaxCourse.ForeColor = Color.FromArgb(24, 30, 54);
            tbMaxCourse.Location = new Point(413, 93);
            tbMaxCourse.Name = "tbMaxCourse";
            tbMaxCourse.Size = new Size(92, 24);
            tbMaxCourse.TabIndex = 42;
            tbMaxCourse.KeyPress += tbMaxCourse_KeyPress;
            // 
            // FrmDirections
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(996, 692);
            Controls.Add(tbMaxCourse);
            Controls.Add(label5);
            Controls.Add(tbDirectionCode);
            Controls.Add(label4);
            Controls.Add(cbDepartments);
            Controls.Add(label3);
            Controls.Add(tbNewDirectionName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvDirections);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnReset);
            Controls.Add(lbDbSaveResult);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmDirections";
            Text = "FrmDirections";
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDirections).EndInit();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbNewDirectionName;
        private Label label2;
        private Label label1;
        private BindingSource userBindingSource;
        private BindingSource userBindingSource1;
        private DataGridView dgvDirections;
        private BindingSource departmentBindingSource;
        private BindingSource departmentBindingSource1;
        private Button btnSave;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnReset;
        private Label lbDbSaveResult;
        private Label label3;
        private ComboBox cbDepartments;
        private TextBox tbDirectionCode;
        private Label label4;
        private Label label5;
        private TextBox tbMaxCourse;
    }
}