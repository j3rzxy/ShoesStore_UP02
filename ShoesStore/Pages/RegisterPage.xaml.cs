using ShoesStore.Database;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ShoesStore.Pages
{
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();

            // Загружаем роли СРАЗУ при открытии страницы, а не при нажатии на кнопку
            RoleComboBox.ItemsSource = Core.Context.Roles_.ToList();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            string fullname = FullNameBox.Text;
            string login = RegLoginBox.Text;
            string password = RegPassBox.Password;
            string confirmpassword = ConfirmPassBox.Password;

            if (string.IsNullOrEmpty(fullname))
            {
                MessageBox.Show("Введите ФИО.");
                return;
            }

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин.");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль.");
                return;
            }

            if (string.IsNullOrEmpty(confirmpassword))
            {
                MessageBox.Show("Подтвердите пароль.");
                return;
            }

            if (password != confirmpassword)
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }

            // Проверяем, выбрана ли роль в ComboBox
            if (RoleComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите роль.");
                return;
            }

            if (Core.Context.Users_.Any(u => u.Login == login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует.");
                return;
            }

            var selectedRole = (Roles_)RoleComboBox.SelectedItem;

            var newUser = new Users_
            {
                FullName = fullname,
                Login = login,
                Password = password,
                RoleID = selectedRole.ID
            };

            Core.Context.Users_.Add(newUser);
            Core.Context.SaveChanges();

            MessageBox.Show("Вы успешно зарегистрированы!");
        }

        private void LabelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void GuestRegButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewPage());
        }
    }
}
