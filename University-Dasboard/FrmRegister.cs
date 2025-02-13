﻿using Database;
using Microsoft.EntityFrameworkCore;
using NLog;
using University_Dasboard.Controllers;

namespace University_Dasboard
{
    public partial class FrmRegister : Form
    {
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		private Panel panelLoader;
        private Form frmAuthorization;
        public FrmRegister(Panel panelLoader, Form frmAuthorization)
        {
            InitializeComponent();
            this.panelLoader = panelLoader;
            this.frmAuthorization = frmAuthorization;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLoader.loadForm(panelLoader, new FrmLogin(panelLoader, frmAuthorization));
        }

        private void btnChangePasswordVisibility_Click(object sender, EventArgs e)
        {
            PasswordVisibility.changeVisibility(btnChangePasswordVisibility, tbPassword);
            PasswordVisibility.changeVisibility(btnChangePasswordVisibility, tbRepeatPassword);
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text != tbRepeatPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают.");
                logger.Warn("Пароли не совпадают.");
                return;
            }
            if (await UserController.IsUserExistsAsync(tbLogin.Text))
            {
                MessageBox.Show("Данный логин уже занят.");
                logger.Warn("Пользователь ввёл существующий логин.");
            }
            try
            {
               await UserController.AddUserAsync(tbLogin.Text, tbPassword.Text, tbFullName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"При добавлении пользователя произошла ошибка: {ex.Message}");
                logger.Error($"При добавлении пользователя произошла ошибка: {ex.Message}");
            }

            frmAuthorization.Hide();
            Form mainProgram = new FrmMainProgram(fullName: tbFullName.Text);
            mainProgram.Show();
            logger.Info("Пользователь успешно добавлен в базу данных.");
        }
    }
}
