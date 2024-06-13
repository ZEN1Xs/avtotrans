using System.Linq;
using System.Windows.Controls;
using WpfAppAvtoTrans.Model;

namespace WpfAppAvtoTrans.Pages
{
    public partial class OperatorRequestsPage : Page
    {
        public OperatorRequestsPage()
        {
            InitializeComponent();
            LoadRequests();
        }

        private void LoadRequests()
        {
            var requests = DbConnection.AvtoTransEntities.Requests
                             .Select(r => new
                             {
                                 r.Id,
                                 r.StartDate,
                                 CarType = r.Car.CarType,
                                 CarModel = r.Car.CarModel,
                                 r.ProblemDescription,
                                 r.RequestStatus,
                                 ClientName = r.Client.FullName,
                                 ClientPhone = r.Client.PhoneNumber
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
