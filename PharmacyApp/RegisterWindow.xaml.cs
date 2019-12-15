﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PharmacyApp.Data;
using PharmacyApp.Services;

namespace PharmacyApp
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private PasswordService _passwordService;
        private UserService _userService;

        public RegisterWindow()
        {
            InitializeComponent();

            _passwordService = new PasswordService();
            _userService = new UserService();
        }

        private async void registerSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string password1 = passwordTextBox.Password;
            string password2 = passwordAgainTextBox.Password;
            string username = usernameTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password1) ||
                string.IsNullOrEmpty(password2))
            {
                MessageBox.Show("Tüm bilgiler zorunludur.");

                return;
            }

            if (password1 != password2)
            {
                MessageBox.Show("Şifreler eşleşmiyor. Lütfen tekrar deneyin.");

                return;
            }

            if (username.Length < 5)
            {
                MessageBox.Show("Kullanıcı adı en az 5 karakter içemelidir.");

                return;
            }

            await RegisterSuccessful(username, password1);
        }

        private async Task RegisterSuccessful(string username, string password)
        {
            string hashedPassword = _passwordService.HashPassword(password);

            PharmacyUser user = new PharmacyUser(username, hashedPassword);

            await _userService.AddUser(user);

            MessageBox.Show("Kayıt Başarılı.");

            this.Close();
        }
    }
}