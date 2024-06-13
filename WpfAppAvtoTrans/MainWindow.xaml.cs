using System.Windows;
using WpfAppAvtoTrans.Pages;

namespace WpfAppAvtoTrans
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthorizePage());
        }
    }
}
