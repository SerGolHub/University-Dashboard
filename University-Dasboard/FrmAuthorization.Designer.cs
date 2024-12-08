namespace University_Dasboard
{
    partial class FrmAuthorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuthorization));
            panel3 = new Panel();
            btnMininizeWindow = new Button();
            btnClose = new Button();
            pnlLoadAuthForms = new Panel();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(24, 30, 54);
            panel3.Controls.Add(btnMininizeWindow);
            panel3.Controls.Add(btnClose);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(392, 40);
            panel3.TabIndex = 11;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // btnMininizeWindow
            // 
            btnMininizeWindow.Dock = DockStyle.Right;
            btnMininizeWindow.FlatAppearance.BorderSize = 0;
            btnMininizeWindow.FlatStyle = FlatStyle.Flat;
            btnMininizeWindow.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMininizeWindow.ForeColor = Color.FromArgb(0, 126, 249);
            btnMininizeWindow.Image = (Image)resources.GetObject("btnMininizeWindow.Image");
            btnMininizeWindow.Location = new Point(312, 0);
            btnMininizeWindow.Name = "btnMininizeWindow";
            btnMininizeWindow.Size = new Size(40, 40);
            btnMininizeWindow.TabIndex = 2;
            btnMininizeWindow.UseVisualStyleBackColor = true;
            btnMininizeWindow.Click += btnMininizeWindow_Click;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(0, 126, 249);
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(352, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 40);
            btnClose.TabIndex = 1;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnlLoadAuthForms
            // 
            pnlLoadAuthForms.Dock = DockStyle.Fill;
            pnlLoadAuthForms.Location = new Point(0, 40);
            pnlLoadAuthForms.Name = "pnlLoadAuthForms";
            pnlLoadAuthForms.Size = new Size(392, 508);
            pnlLoadAuthForms.TabIndex = 12;
            // 
            // FrmAuthorization
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(392, 548);
            Controls.Add(pnlLoadAuthForms);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmAuthorization";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLoginScreen";
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Button btnMininizeWindow;
        private Button btnClose;
        private Panel pnlLoadAuthForms;
    }
}