using Database;

namespace University_Dasboard
{
    public partial class FrmMainProgram : Form
    {

        public FrmMainProgram(string fullName = "", string login = "")
        {
            InitializeComponent();
            //checkAuthorisation(fullName, login);

        }
        private void checkAuthorisation(string fullName = "", string login = "")
        {
            if (fullName != "")
            {

                lbUserName.Text = fullName;
            }
            else
            {
                if (login == "")
                {
                    MessageBox.Show("Что-то пошло не так :(");
                    return;
                }
                try
                {
                    using var ctx = new DatabaseContext();
                    User user = ctx.User.First(u => u.Login == login);
                    lbUserName.Text = user.FullName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            int labelCenterPositionX = picProfile.Left + (picProfile.Width - lbUserName.Width) / 2;
            lbUserName.Location = new Point(labelCenterPositionX, lbUserName.Location.Y);
        }
        private void moveNavigationPanel(Button button)
        {
            pnlNavigation.Show();
            pnlNavigation.Height = button.Height;
            pnlNavigation.Top = button.Top;
            pnlNavigation.Left = button.Left;
        }

        private void moveNavigationSubPanel(Button button, Panel subMenu)
        {
            pnlNavigationSubmenu.Parent = subMenu;
            pnlNavigationSubmenu.Height = button.Height;
            pnlNavigationSubmenu.Top = button.Top;
            pnlNavigationSubmenu.Width = 15;
            pnlNavigationSubmenu.BringToFront();
            pnlNavigationSubmenu.Show();
            button.BackColor = Color.FromArgb(46, 51, 73);
        }
        private void loadFrmMainProgram(Form form)
        {
            pnlFormLoader.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.TopMost = true;
            pnlFormLoader.Controls.Add(form);
            form.Show();
        }

        private void restoreButtonsBackColor()
        {
            Color color = Color.FromArgb(24, 30, 54);
            btnFaculties.BackColor = color;
            btnDepartments.BackColor = color;
            btnDirections.BackColor = color;

            btnStudents.BackColor = color;
            btnDisciplines.BackColor = color;
            btnGrades.BackColor = color;

            button3.BackColor = color;
            button4.BackColor = color;
            button5.BackColor = color;
        }

        private void hideSubMenu()
        {
            pnlOtherSubMenu.Visible = false;
            pnlGradeRecordSubMenu.Visible = false;
            pnlSchedulingSubMenu.Visible = false;
        }

        private void changeSubMenuVisibility(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            //FormLoader.loadForm(pnlFormLoader, new FrmFaculties());
            changeSubMenuVisibility(pnlOtherSubMenu);
            restoreButtonsBackColor();
            moveNavigationPanel(btnOther);
        }

        private void btnGradeRecord_Click(object sender, EventArgs e)
        {
            FormLoader.loadForm(pnlFormLoader, new FrmGradeRecords());
            changeSubMenuVisibility(pnlGradeRecordSubMenu);
            restoreButtonsBackColor();
            moveNavigationPanel(btnGradeRecord);
        }

        private void btnScheduling_Click(object sender, EventArgs e)
        {
            FormLoader.loadForm(pnlFormLoader, new FrmScheduling());
            changeSubMenuVisibility(pnlSchedulingSubMenu);
            restoreButtonsBackColor();
            moveNavigationPanel(btnScheduling);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveWindow.ReleaseCapture();
                MoveWindow.SendMessage(Handle, MoveWindow.WM_NLCBUTTONDOWN, MoveWindow.HT_CAPTION, 0);
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveWindow.ReleaseCapture();
                MoveWindow.SendMessage(Handle, MoveWindow.WM_NLCBUTTONDOWN, MoveWindow.HT_CAPTION, 0);
            }
        }

        private void picProfile_Click(object sender, EventArgs e)
        {
            FormLoader.loadForm(pnlFormLoader, new FrmProfile());
            restoreButtonsBackColor();
            hideSubMenu();
            pnlNavigation.Hide();
        }

        private void btnFaculties_Click(object sender, EventArgs e)
        {
            FormLoader.loadForm(pnlFormLoader, new FrmFaculties());
            restoreButtonsBackColor();
            moveNavigationSubPanel(btnFaculties, pnlOtherSubMenu);
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            FormLoader.loadForm(pnlFormLoader, new FrmDepartments());
            restoreButtonsBackColor();
            moveNavigationSubPanel(btnDepartments, pnlOtherSubMenu);
        }

        private void btnDirections_Click(object sender, EventArgs e)
        {
            FormLoader.loadForm(pnlFormLoader, new FrmDirections());
            restoreButtonsBackColor();
            moveNavigationSubPanel(btnDirections, pnlOtherSubMenu);
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            FormLoader.loadForm(pnlFormLoader, new FrmStudents());
            restoreButtonsBackColor();
            moveNavigationSubPanel(btnStudents, pnlGradeRecordSubMenu);
        }

        private void btnDisciplines_Click(object sender, EventArgs e)
        {
            FormLoader.loadForm(pnlFormLoader, new FrmDisciplines());
            restoreButtonsBackColor();
            moveNavigationSubPanel(btnDisciplines, pnlGradeRecordSubMenu);
        }
        private void btGrades_Click(object sender, EventArgs e)
        {
            FormLoader.loadForm(pnlFormLoader, new FrmGrades());
            restoreButtonsBackColor();
            moveNavigationSubPanel(btnGrades, pnlGradeRecordSubMenu);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            restoreButtonsBackColor();
            moveNavigationSubPanel(button3, pnlSchedulingSubMenu);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            restoreButtonsBackColor();
            moveNavigationSubPanel(button4, pnlSchedulingSubMenu);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            restoreButtonsBackColor();
            moveNavigationSubPanel(button5, pnlSchedulingSubMenu);
        }
    }
}
