using SecurityApp.DataAcces;
using SecurityApp.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SecurityApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignInButonClick(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordBox.Password;

            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Норм введи");
                return;
            }

            using (var context = new SecurityContext())
            {
                var user = context.
                    Users.
                    SingleOrDefault(searchingUser => searchingUser.Login==login);

                if(user==null || !CryptoService.VerifyPassword(password, user.Password))
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                else
                {
                    MessageBox.Show("Успешный ввод");
                }
            }
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            Authentification authentification = new Authentification();
            authentification.Show();
        }
    }
}
