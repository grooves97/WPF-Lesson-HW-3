using System;
using System.Collections.Generic;
using System.Linq;
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
using SecurityApp.Models;
using SecurityApp.DataAcces;
using SecurityApp.Services;

namespace SecurityApp
{
    /// <summary>
    /// Логика взаимодействия для Authentification.xaml
    /// </summary>
    public partial class Authentification : Window
    {
        public Authentification()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            var newLogin = newLoginTextBox.Text;
            var newPassword = newPasswordBox.Password;
            var confirmNewPassword = confirmPasswordBox.Password;


            if (string.IsNullOrEmpty(newLogin) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmNewPassword))
            {
                MessageBox.Show("Норм введи");
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("Пароль должен быть одинаковый Чувак!");
                return;
            }

            user.Login = newLogin;
            user.Password = CryptoService.HashPassword(newPassword);

            using (var context=new SecurityContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
