using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppAvtoTrans.Model;

namespace WpfAppAvtoTrans.Pages
{
    public partial class RequestEditPage : Page
    {
        private Request _currentRequest;

        public RequestEditPage(Request request = null)
        {
            InitializeComponent();

            if (request != null)
            {
                _currentRequest = request;
                LoadRequestData();
            }
            else
            {
                _currentRequest = new Request
                {
                    Car = new Car(),
                    Client = new Client()
                };
            }
        }

        private void LoadRequestData()
        {
            if (_currentRequest != null)
            {
                CarTypeTextBox.Text = _currentRequest.Car.CarType;
                CarModelTextBox.Text = _currentRequest.Car.CarModel;
                ProblemDescriptionTextBox.Text = _currentRequest.ProblemDescription;
                ClientNameTextBox.Text = _currentRequest.Client.FullName;
                PhoneNumberTextBox.Text = _currentRequest.Client.PhoneNumber;
            }
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

            if (_currentRequest == null)
            {
                _currentRequest = new Request
                {
                    Car = new Car(),
                    Client = new Client()
                };
                DbConnection.AvtoTransEntities.Requests.Add(_currentRequest);
            }

            _currentRequest.Car.CarType = CarTypeTextBox.Text;
            _currentRequest.Car.CarModel = CarModelTextBox.Text;
            _currentRequest.ProblemDescription = ProblemDescriptionTextBox.Text;
            _currentRequest.Client.FullName = ClientNameTextBox.Text;
            _currentRequest.Client.PhoneNumber = PhoneNumberTextBox.Text;
            _currentRequest.RequestStatus = "Новая заявка";
            _currentRequest.StartDate = DateTime.Now;

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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
