namespace University_Dasboard
{
    partial class FrmRegister
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
            label3 = new Label();
            label2 = new Label();
            tbPassword = new TextBox();
            tbLogin = new TextBox();
            btnRegister = new Button();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox4 = new PictureBox();
            tbRepeatPassword = new TextBox();
            label4 = new Label();
            linkLogin = new LinkLabel();
            btnChangePasswordVisibility = new Button();
            tbFullName = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(158, 161, 178);
            label3.Location = new Point(72, 280);
            label3.Name = "label3";
            label3.Size = new Size(67, 18);
            label3.TabIndex = 20;
            label3.Text = "Пароль";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(158, 161, 178);
            label2.Location = new Point(72, 226);
            label2.Name = "label2";
            label2.Size = new Size(55, 18);
            label2.TabIndex = 21;
            label2.Text = "Логин";
            // 
            // tbPassword
            // 
            tbPassword.BackColor = Color.FromArgb(158, 161, 178);
            tbPassword.BorderStyle = BorderStyle.FixedSingle;
            tbPassword.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbPassword.ForeColor = Color.FromArgb(24, 30, 54);
            tbPassword.Location = new Point(72, 301);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(249, 24);
            tbPassword.TabIndex = 18;
            // 
            // tbLogin
            // 
            tbLogin.BackColor = Color.FromArgb(158, 161, 178);
            tbLogin.BorderStyle = BorderStyle.FixedSingle;
            tbLogin.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbLogin.ForeColor = Color.FromArgb(24, 30, 54);
            tbLogin.Location = new Point(72, 247);
            tbLogin.Name = "tbLogin";
            tbLogin.Size = new Size(249, 24);
            tbLogin.TabIndex = 19;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(0, 126, 249);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.FromArgb(24, 30, 54);
            btnRegister.Location = new Point(72, 403);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(249, 40);
            btnRegister.TabIndex = 17;
            btnRegister.Text = "Регистрация";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.lock_icon;
            pictureBox3.Location = new Point(43, 301);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(23, 23);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.user_profile2;
            pictureBox2.Location = new Point(43, 247);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(23, 23);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bauhaus 93", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 126, 249);
            label1.Location = new Point(89, 125);
            label1.Name = "label1";
            label1.Size = new Size(214, 36);
            label1.TabIndex = 12;
            label1.Text = "Регистрация";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Untitled_11;
            pictureBox1.Location = new Point(146, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.lock_icon;
            pictureBox4.Location = new Point(43, 355);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(23, 23);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 14;
            pictureBox4.TabStop = false;
            // 
            // tbRepeatPassword
            // 
            tbRepeatPassword.BackColor = Color.FromArgb(158, 161, 178);
            tbRepeatPassword.BorderStyle = BorderStyle.FixedSingle;
            tbRepeatPassword.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbRepeatPassword.ForeColor = Color.FromArgb(24, 30, 54);
            tbRepeatPassword.Location = new Point(72, 355);
            tbRepeatPassword.Name = "tbRepeatPassword";
            tbRepeatPassword.PasswordChar = '*';
            tbRepeatPassword.Size = new Size(249, 24);
            tbRepeatPassword.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(158, 161, 178);
            label4.Location = new Point(72, 334);
            label4.Name = "label4";
            label4.Size = new Size(127, 18);
            label4.TabIndex = 20;
            label4.Text = "Повтор пароля";
            // 
            // linkLogin
            // 
            linkLogin.ActiveLinkColor = Color.Cyan;
            linkLogin.AutoSize = true;
            linkLogin.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            linkLogin.LinkColor = Color.FromArgb(0, 126, 249);
            linkLogin.Location = new Point(101, 459);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(207, 18);
            linkLogin.TabIndex = 23;
            linkLogin.TabStop = true;
            linkLogin.Text = "Уже есть аккаунт? Войти";
            linkLogin.VisitedLinkColor = Color.FromArgb(158, 161, 178);
            linkLogin.LinkClicked += linkLabel2_LinkClicked;
            // 
            // btnChangePasswordVisibility
            // 
            btnChangePasswordVisibility.BackColor = Color.FromArgb(46, 51, 73);
            btnChangePasswordVisibility.FlatAppearance.BorderSize = 0;
            btnChangePasswordVisibility.FlatStyle = FlatStyle.Flat;
            btnChangePasswordVisibility.Font = new Font("Microsoft Sans Serif", 11.25F);
            btnChangePasswordVisibility.ForeColor = Color.FromArgb(24, 30, 54);
            btnChangePasswordVisibility.Image = Properties.Resources.Shown;
            btnChangePasswordVisibility.Location = new Point(327, 301);
            btnChangePasswordVisibility.Name = "btnChangePasswordVisibility";
            btnChangePasswordVisibility.Size = new Size(32, 24);
            btnChangePasswordVisibility.TabIndex = 24;
            btnChangePasswordVisibility.UseVisualStyleBackColor = false;
            btnChangePasswordVisibility.Click += btnChangePasswordVisibility_Click;
            // 
            // tbFullName
            // 
            tbFullName.BackColor = Color.FromArgb(158, 161, 178);
            tbFullName.BorderStyle = BorderStyle.FixedSingle;
            tbFullName.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbFullName.ForeColor = Color.FromArgb(24, 30, 54);
            tbFullName.Location = new Point(72, 193);
            tbFullName.Name = "tbFullName";
            tbFullName.Size = new Size(249, 24);
            tbFullName.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(158, 161, 178);
            label5.Location = new Point(72, 172);
            label5.Name = "label5";
            label5.Size = new Size(47, 18);
            label5.TabIndex = 21;
            label5.Text = "ФИО";
            // 
            // FrmRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(392, 508);
            Controls.Add(btnChangePasswordVisibility);
            Controls.Add(linkLogin);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(tbRepeatPassword);
            Controls.Add(tbPassword);
            Controls.Add(tbFullName);
            Controls.Add(tbLogin);
            Controls.Add(btnRegister);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmRegister";
            Text = "frmRegister";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label2;
        private TextBox tbPassword;
        private TextBox tbLogin;
        private Button btnRegister;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private TextBox tbRepeatPassword;
        private Label label4;
        private LinkLabel linkLogin;
        private Button btnChangePasswordVisibility;
        private TextBox tbFullName;
        private Label label5;
    }
}