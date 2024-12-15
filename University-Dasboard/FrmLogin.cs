using Database;
using Microsoft.EntityFrameworkCore;
using NLog;
using University_Dasboard.Controllers;

namespace University_Dasboard
{
    public partial class FrmLogin : Form
    {
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		private Panel panelLoader;
        private Form frmAuthorization;
        public FrmLogin(Panel panelLoader, Form frmAuthorization)
        {
            InitializeComponent();
            this.panelLoader = panelLoader;
            this.frmAuthorization = frmAuthorization;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPassword.Text;
            if (login == "" || password == "")
            {
                MessageBox.Show("Введён неверный логин или пароль");
                logger.Warn("Пользователь ввёл неверный логин или пароль. Проходит валидация.");
                return;
            }
            try
            {
                var userController = new UserController();
                var user = await UserController.GetUserAsync(login);
                if (user == null)
                {
                    MessageBox.Show("Введён неверный логин или пароль");
					logger.Warn("Пользователь ввёл неверный логин или пароль. Пользователя не существует.");
					return;
                }

                string passwordHash = PasswordSecurity.getHash(password);
                if (user.PasswordHash != passwordHash)
                {
                    MessageBox.Show("Введён неверный логин или пароль");
					logger.Warn("Пользователь ввёл неверный логин или пароль. Проверка пароля.");
					return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Во время проверки наличия пользователя " +
                    $"с введённым логином произошла ошибка: {ex.Message}");
                
                logger.Error($"Во время проверки наличия пользователя " +
					$"с введённым логином произошла ошибка: {ex.Message}");
                return;
            }

            frmAuthorization.Hide();
            Form mainProgram = new FrmMainProgram(login: login);
            mainProgram.Show();

            logger.Info("Пользователь успешно вошёл в приложение.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLoader.loadForm(panelLoader, new FrmRegister(panelLoader, frmAuthorization));
        }

        private void btnChangePasswordVisibility_Click(object sender, EventArgs e)
        {
            PasswordVisibility.changeVisibility(btnChangePasswordVisibility, tbPassword);
        }
    }
}
