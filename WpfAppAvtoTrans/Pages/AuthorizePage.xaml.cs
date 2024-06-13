using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppAvtoTrans.Model;

namespace WpfAppAvtoTrans.Pages
{
    public partial class AuthorizePage : Page
    {
        public AuthorizePage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            var user = Model.DbConnection.AvtoTransEntities.Users
                         .FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                MessageBox.Show("Успешный вход", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                // Перенаправление в зависимости от роли
                switch (user.RoleId)
                {
                    case 1: // Менеджер
                        NavigationService.Navigate(new ManagerPage());
                        break;
                    case 2: // Автомеханик
                        NavigationService.Navigate(new MechanicPage());
                        break;
                    case 3: // Оператор
                        NavigationService.Navigate(new OperatorPage());
                        break;
                    case 4: // Заказчик
                        NavigationService.Navigate(new CustomerPage());
                        break;
                    default:
                        MessageBox.Show("Неизвестная роль пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
