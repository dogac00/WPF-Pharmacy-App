using System;
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

        public RegisterWindow(Window window)
        {
            InitializeComponent();

            _passwordService = new PasswordService();
            _userService = ServiceProvider.GetUserService();
        }

        private async void registerSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string password1 = passwordTextBox.Password;
            string password2 = passwordAgainTextBox.Password;
            string username = usernameTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password1) ||
                string.IsNullOrEmpty(password2))
            {
                MessageBox.Show("Tüm bilgileri zorunludur.");

                return;
            }

            if (password1 != password2)
            {
                MessageBox.Show("Şifreler eşleşmiyor. Lütfen tekrar deneyin.");

                return;
            }

            if (username.Length < 5)
            {
                MessageBox.Show("Kullanıcı adı en az 5 karakter içermelidir.");

                return;
            }

            if (await _userService.IsUsernameTakenAsync(username))
            {
                MessageBox.Show("Kullanici adı alınmış. Farklı bir kullanıcı adı deneyin.");

                return;
            }

            await RegisterSuccessful(username, password1);
        }

        private async Task RegisterSuccessful(string username, string password)
        {
            string hashedPassword = _passwordService.HashPassword(password);

            PharmacyUser user = new PharmacyUser { UserName = username, Password = hashedPassword };

            await _userService.AddUserAsync(user);
            
            MessageBox.Show("Kayıt Başarılı.");

            this.Close();
        }
    }
}
