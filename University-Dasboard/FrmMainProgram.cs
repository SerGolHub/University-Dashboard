using Database;
using NLog;

namespace University_Dasboard
{
	public partial class FrmMainProgram : Form
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public FrmMainProgram(string fullName = "", string login = "")
		{
			InitializeComponent();
			logger.Info("Главная форма запущена");

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
					// Ищем пользователя по логину
					User user = ctx.User.First(u => u.Login == login);
					// Выставляем имя пользователя
					lbUserName.Text = user.FullName;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}
			}
			// Размещаем имя пользователя по середине боковой панели
			int labelCenterPositionX = picProfile.Left + (picProfile.Width - lbUserName.Width) / 2;
			lbUserName.Location = new Point(labelCenterPositionX, lbUserName.Location.Y);

			logger.Info("Пользователь авторизован");
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

		private void restoreButtonsBackColor()
		{
			Color color = Color.FromArgb(24, 30, 54);
			btnFaculties.BackColor = color;
			btnDepartments.BackColor = color;
			btnDirections.BackColor = color;
			btnSubjects.BackColor = color;
			btnGroups.BackColor = color;
			btnStudents.BackColor = color;
			btnTeachers.BackColor = color;

			btnGrades.BackColor = color;

			btnAcademicHours.BackColor = color;
			btnSchedulingDisciplines.BackColor = color;
            btnSchedulePair.BackColor = color;

			btnReports.BackColor = color;
			btnAboutGradeRecords.BackColor = color;
			btnStudentCard.BackColor = color;
		}

		private void hideSubMenu()
		{
			pnlManageDataSubMenu.Visible = false;
			pnlGradeRecordSubMenu.Visible = false;
			pnlSchedulingSubMenu.Visible = false;
			pnlReportsSubMenu.Visible = false;
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

		private void btnManageData_Click(object sender, EventArgs e)
		{
			changeSubMenuVisibility(pnlManageDataSubMenu);
			restoreButtonsBackColor();
			moveNavigationPanel(btnManageData);
		}
		#region button ManageData sub buttons
		private void btnFaculties_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmFaculties());
			restoreButtonsBackColor();
			moveNavigationSubPanel(btnFaculties, pnlManageDataSubMenu);
		}

		private void btnDepartments_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmDepartments());
			restoreButtonsBackColor();
			moveNavigationSubPanel(btnDepartments, pnlManageDataSubMenu);
		}

		private void btnDirections_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmDirections());
			restoreButtonsBackColor();
			moveNavigationSubPanel(btnDirections, pnlManageDataSubMenu);
		}

		private void btnSubjects_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmSubjects());
			restoreButtonsBackColor();
			moveNavigationSubPanel(btnSubjects, pnlManageDataSubMenu);
		}

		private void btnGroups_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmGroups());
			restoreButtonsBackColor();
			moveNavigationSubPanel(btnGroups, pnlManageDataSubMenu);
		}

		private void btnStudents_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmStudents());
			restoreButtonsBackColor();
			moveNavigationSubPanel(btnStudents, pnlManageDataSubMenu);
		}

		private void btnTeachers_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmTeachers());
			restoreButtonsBackColor();
			moveNavigationSubPanel(btnTeachers, pnlManageDataSubMenu);
		}
        #endregion

        private void btnGradeRecord_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmGradeRecords());
			changeSubMenuVisibility(pnlGradeRecordSubMenu);
			restoreButtonsBackColor();
			moveNavigationPanel(btnGradeRecord);
		}

		private void btnSchedulingWeek_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmSchedulingWeek());
			changeSubMenuVisibility(pnlSchedulingSubMenu);
			restoreButtonsBackColor();
			moveNavigationPanel(btnScheduling);
		}

        private void btnTeacherConstraints_Click(object sender, EventArgs e)
        {
            FormLoader.loadForm(pnlFormLoader, new FrmTeachersConstraint());
            changeSubMenuVisibility(pnlSchedulingSubMenu);
            restoreButtonsBackColor();
            moveNavigationPanel(btnTeacherConstraints);
        }

        private void btnReportCheckLesson_Click(object sender, EventArgs e)
        {
            FormLoader.loadForm(pnlFormLoader, new FrmSchedulingDisciplineReport());
            changeSubMenuVisibility(pnlSchedulingSubMenu);
            restoreButtonsBackColor();
            moveNavigationPanel(btnReportCheckLesson);
        }

        private void btnSchedulingDisciplines_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmSchedulingDiscipline());
			restoreButtonsBackColor();
			moveNavigationSubPanel(btnSchedulingDisciplines, pnlSchedulingSubMenu);
		}

		private void btnReports_Click(object sender, EventArgs e)
		{
			changeSubMenuVisibility(pnlReportsSubMenu);
			restoreButtonsBackColor();
			moveNavigationPanel(btnReports);
		}

		private void btnAboutGradeRecords_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmAboutGradeRecords());
			restoreButtonsBackColor();
			moveNavigationSubPanel(btnAboutGradeRecords, pnlReportsSubMenu);
		}

		private void btnStudentCard_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmStudentCard());
			restoreButtonsBackColor();
			moveNavigationSubPanel(btnStudentCard, pnlReportsSubMenu);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnMinimize_Click(object sender, EventArgs e)
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

		private void btGrades_Click(object sender, EventArgs e)
		{
			FormLoader.loadForm(pnlFormLoader, new FrmMarks());
			restoreButtonsBackColor();
			moveNavigationSubPanel(btnGrades, pnlGradeRecordSubMenu);
		}

		private void btnScheduling_Click(object sender, EventArgs e)
		{
            FormLoader.loadForm(pnlFormLoader, new FrmSchedulePair());
            restoreButtonsBackColor();
            moveNavigationSubPanel(btnSchedulePair, pnlSchedulingSubMenu);
        }

		private void btnAcademicHours_Click(object sender, EventArgs e)
		{
			restoreButtonsBackColor();
			moveNavigationSubPanel(btnAcademicHours, pnlSchedulingSubMenu);
		}
	}
}
