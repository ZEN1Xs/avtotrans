using System.Windows;
using System.Windows.Controls;
using WpfAppAvtoTrans.Model;

namespace WpfAppAvtoTrans.Pages
{
    public partial class CustomerPage : Page
    {
        private User _currentUser;

        public CustomerPage(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            WelcomeTextBlock.Text = $"Добро пожаловать, {_currentUser.FullName}";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddRequestButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RequestEditPage());
        }

        private void ViewRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewRequestsPage(_currentUser));
        }
    }
}
