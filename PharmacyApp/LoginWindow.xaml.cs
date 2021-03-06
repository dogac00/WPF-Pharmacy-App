﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PharmacyApp.Services;

namespace PharmacyApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private PasswordService _service;
        private UserService _userService;
        private Window _windowToClose;

        public LoginWindow(Window window)
        {
            InitializeComponent();

            _service = new PasswordService();
            _userService = ServiceProvider.GetUserService();
            _windowToClose = window;
            loginButton.IsDefault = true;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tüm alanlar zorunludur.");

                return;
            }

            string hash = _service.HashPassword(password);

            var user = _userService.TryGetUser(username, hash);

            if (user == null)
            {
                MessageBox.Show("Giriş bilgileri hatalıdır. Lütfen bilgilerinizi kontrol edin.");

                return;
            }

            MainWindow window = new MainWindow(user);

            window.Show();

            this.Close();
            _windowToClose.Close();
        }
    }
}
