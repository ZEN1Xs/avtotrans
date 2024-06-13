using System.Linq;
using System.Windows.Controls;
using WpfAppAvtoTrans.Model;

namespace WpfAppAvtoTrans.Pages
{
    public partial class ViewRequestsPage : Page
    {
        private User _currentUser;

        public ViewRequestsPage(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            LoadRequests();
        }

        private void LoadRequests()
        {
            var requests = DbConnection.AvtoTransEntities.Requests
                             .Where(r => r.ClientId == _currentUser.Id)
                             .Select(r => new
                             {
                                 r.Id,
                                 r.StartDate,
                                 r.Car.CarType,
                                 r.Car.CarModel,
                                 r.ProblemDescription,
                                 r.RequestStatus
                             })
                             .ToList();
            RequestsDataGrid.ItemsSource = requests;
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
