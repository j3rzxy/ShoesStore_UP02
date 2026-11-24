using ShoesStore.Database;
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

namespace ShoesStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = LogPassBox.Password;

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин.");
                LoginBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль.");
                LogPassBox.Focus();
                return;
            }

            var user = Core.Context.Users_.FirstOrDefault(u => u.Login == login);
            if (user != null)
            {
                MessageBox.Show("Неверный логин или пароль.");
                return;
            }
            Core.currentUser = user;
            NavigationService.Navigate(new ViewPage());
        }

        private void LabelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RegisterPage());
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ViewPage());
        }
    }
}
