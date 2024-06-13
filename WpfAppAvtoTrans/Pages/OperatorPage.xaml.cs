using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppAvtoTrans.Model;

namespace WpfAppAvtoTrans.Pages
{
    public partial class OperatorPage : Page
    {
        public OperatorPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CarTypeTextBox.Text) ||
                string.IsNullOrWhiteSpace(CarModelTextBox.Text) ||
                string.IsNullOrWhiteSpace(ProblemDescriptionTextBox.Text) ||
                string.IsNullOrWhiteSpace(ClientNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newRequest = new Request
            {
                Car = new Car
                {
                    CarType = CarTypeTextBox.Text,
                    CarModel = CarModelTextBox.Text
                },
                Client = new Client
                {
                    FullName = ClientNameTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text
                },
                ProblemDescription = ProblemDescriptionTextBox.Text,
                RequestStatus = "Новая заявка",
                StartDate = DateTime.Now
            };

            DbConnection.AvtoTransEntities.Requests.Add(newRequest);

            try
            {
                DbConnection.AvtoTransEntities.SaveChanges();
                MessageBox.Show("Заявка успешно сохранена.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении заявки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ViewRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OperatorRequestsPage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
