namespace University_Dasboard
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            btnLogin = new Button();
            tbLogin = new TextBox();
            tbPassword = new TextBox();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            label3 = new Label();
            button1 = new Button();
            btnChangePasswordVisibility = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(146, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bauhaus 93", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 126, 249);
            label1.Location = new Point(150, 125);
            label1.Name = "label1";
            label1.Size = new Size(92, 36);
            label1.TabIndex = 1;
            label1.Text = "Вход";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.user_profile2;
            pictureBox2.Location = new Point(43, 231);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(23, 23);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.lock_icon;
            pictureBox3.Location = new Point(43, 300);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(23, 23);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 126, 249);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Microsoft Sans Serif", 11.25F);
            btnLogin.ForeColor = Color.FromArgb(24, 30, 54);
            btnLogin.Location = new Point(72, 392);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(249, 40);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // tbLogin
            // 
            tbLogin.BackColor = Color.FromArgb(158, 161, 178);
            tbLogin.BorderStyle = BorderStyle.FixedSingle;
            tbLogin.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbLogin.ForeColor = Color.FromArgb(24, 30, 54);
            tbLogin.Location = new Point(72, 231);
            tbLogin.Name = "tbLogin";
            tbLogin.Size = new Size(249, 24);
            tbLogin.TabIndex = 7;
            // 
            // tbPassword
            // 
            tbPassword.BackColor = Color.FromArgb(158, 161, 178);
            tbPassword.BorderStyle = BorderStyle.FixedSingle;
            tbPassword.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            tbPassword.ForeColor = Color.FromArgb(24, 30, 54);
            tbPassword.Location = new Point(72, 300);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(249, 24);
            tbPassword.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(158, 161, 178);
            label2.Location = new Point(72, 210);
            label2.Name = "label2";
            label2.Size = new Size(55, 18);
            label2.TabIndex = 8;
            label2.Text = "Логин";
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.Cyan;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            linkLabel1.LinkColor = Color.FromArgb(0, 126, 249);
            linkLabel1.Location = new Point(130, 459);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(141, 18);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Создать аккаунт";
            linkLabel1.VisitedLinkColor = Color.FromArgb(158, 161, 178);
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(158, 161, 178);
            label3.Location = new Point(72, 279);
            label3.Name = "label3";
            label3.Size = new Size(67, 18);
            label3.TabIndex = 8;
            label3.Text = "Пароль";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(46, 51, 73);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 11.25F);
            button1.Location = new Point(327, 300);
            button1.Name = "button1";
            button1.Size = new Size(23, 23);
            button1.TabIndex = 10;
            button1.UseVisualStyleBackColor = false;
            // 
            // btnChangePasswordVisibility
            // 
            btnChangePasswordVisibility.BackColor = Color.FromArgb(46, 51, 73);
            btnChangePasswordVisibility.FlatAppearance.BorderSize = 0;
            btnChangePasswordVisibility.FlatStyle = FlatStyle.Flat;
            btnChangePasswordVisibility.Font = new Font("Microsoft Sans Serif", 11.25F);
            btnChangePasswordVisibility.ForeColor = Color.FromArgb(24, 30, 54);
            btnChangePasswordVisibility.Image = Properties.Resources.Shown;
            btnChangePasswordVisibility.Location = new Point(327, 300);
            btnChangePasswordVisibility.Name = "btnChangePasswordVisibility";
            btnChangePasswordVisibility.Size = new Size(32, 24);
            btnChangePasswordVisibility.TabIndex = 11;
            btnChangePasswordVisibility.UseVisualStyleBackColor = false;
            btnChangePasswordVisibility.Click += btnChangePasswordVisibility_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(392, 508);
            Controls.Add(btnChangePasswordVisibility);
            Controls.Add(button1);
            Controls.Add(linkLabel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tbPassword);
            Controls.Add(tbLogin);
            Controls.Add(btnLogin);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLoginScreen";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button btnLogin;
        private TextBox tbLogin;
        private TextBox tbPassword;
        private Label label2;
        private LinkLabel linkLabel1;
        private Label label3;
        private Button button1;
        private Button btnChangePasswordVisibility;
    }
}