namespace University_Dasboard
{
    partial class FrmDisciplines
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
            tbNewDisciplineName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            userBindingSource = new BindingSource(components);
            userBindingSource1 = new BindingSource(components);
            dgvDisciplines = new DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)dgvDisciplines).BeginInit();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // tbNewDisciplineName
            // 
            tbNewDisciplineName.BackColor = Color.FromArgb(158, 161, 178);
            tbNewDisciplineName.BorderStyle = BorderStyle.FixedSingle;
            tbNewDisciplineName.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbNewDisciplineName.ForeColor = Color.FromArgb(24, 30, 54);
            tbNewDisciplineName.Location = new Point(12, 46);
            tbNewDisciplineName.Name = "tbNewDisciplineName";
            tbNewDisciplineName.Size = new Size(249, 24);
            tbNewDisciplineName.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(158, 161, 178);
            label2.Location = new Point(12, 23);
            label2.Name = "label2";
            label2.Size = new Size(244, 20);
            label2.TabIndex = 20;
            label2.Text = "Введите новую дисциплину";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(158, 161, 178);
            label1.Location = new Point(12, 273);
            label1.Name = "label1";
            label1.Size = new Size(251, 29);
            label1.TabIndex = 21;
            label1.Text = "Список дисциплин";
            // 
            // dgvDisciplines
            // 
            dgvDisciplines.AllowUserToAddRows = false;
            dgvDisciplines.AllowUserToDeleteRows = false;
            dgvDisciplines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDisciplines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDisciplines.Location = new Point(12, 308);
            dgvDisciplines.Name = "dgvDisciplines";
            dgvDisciplines.Size = new Size(561, 319);
            dgvDisciplines.TabIndex = 28;
            dgvDisciplines.CellValueChanged += dgvSubjects_CellValueChanged;
            dgvDisciplines.RowPostPaint += dgvSubjects_RowPostPaint;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 126, 249);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.FromArgb(24, 30, 54);
            btnSave.Location = new Point(579, 308);
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
            btnDelete.Location = new Point(579, 585);
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
            btnAdd.Location = new Point(267, 46);
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
            btnReset.Location = new Point(579, 537);
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
            lbDbSaveResult.Location = new Point(271, 285);
            lbDbSaveResult.Name = "lbDbSaveResult";
            lbDbSaveResult.Size = new Size(302, 20);
            lbDbSaveResult.TabIndex = 22;
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
            lbDbSaveResult.Visible = false;
            // 
            // FrmSubjectList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(980, 653);
            Controls.Add(tbNewDisciplineName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvDisciplines);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnReset);
            Controls.Add(lbDbSaveResult);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmSubjectList";
            Text = "frmDisciplineList";
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDisciplines).EndInit();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)departmentBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbNewDisciplineName;
        private Label label2;
        private Label label1;
        private BindingSource userBindingSource;
        private BindingSource userBindingSource1;
        private DataGridView dgvDisciplines;
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