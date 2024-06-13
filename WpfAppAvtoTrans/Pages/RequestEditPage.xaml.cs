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
        }

        private void LoadRequestData()
        {
            if (_currentRequest != null)
            {
                CarTypeTextBox.Text = _currentRequest.CarType;
                CarModelTextBox.Text = _currentRequest.CarModel;
                ProblemDescriptionTextBox.Text = _currentRequest.ProblemDescription;
                ClientNameTextBox.Text = _currentRequest.ClientName;
                PhoneNumberTextBox.Text = _currentRequest.PhoneNumber;
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
                _currentRequest = new Request();
                DbConnection.AvtoTransEntities.Requests.Add(_currentRequest);
            }

            _currentRequest.CarType = CarTypeTextBox.Text;
            _currentRequest.CarModel = CarModelTextBox.Text;
            _currentRequest.ProblemDescription = ProblemDescriptionTextBox.Text;
            _currentRequest.ClientName = ClientNameTextBox.Text;
            _currentRequest.PhoneNumber = PhoneNumberTextBox.Text;
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
    }
}
