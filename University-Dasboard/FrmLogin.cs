using Database;
using Microsoft.EntityFrameworkCore;
using University_Dasboard.Controllers;

namespace University_Dasboard
{
    public partial class FrmLogin : Form
    {
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
                return;
            }
            try
            {
                var userController = new UserController();
                var user = await UserController.GetUserAsync(login);
                if (user == null)
                {
                    MessageBox.Show("Введён неверный логин или пароль");
                    return;
                }

                string passwordHash = PasswordSecurity.getHash(password);
                if (user.PasswordHash != passwordHash)
                {
                    MessageBox.Show("Введён неверный логин или пароль");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Во время проверки наличия пользователя " +
                    $"с введённым логином произошла ошибка: {ex.Message}");
                return;
            }
            frmAuthorization.Hide();
            Form mainProgram = new FrmMainProgram(login: login);
            mainProgram.Show();
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
