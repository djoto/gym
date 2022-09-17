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
using System.Windows.Shapes;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();

            DataContext = new VisitsModel();

        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddUserModel();
        }

        private void listUsersButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ListUsersModel();
        }

        private void searchUsersButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SearchUsersModel();
        }

        private void archiveButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ArchiveModel();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void visitsButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new VisitsModel();
        }

        private void addEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddEmployeeModel();
        }

        private void listEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EmployeesModel();
        }

        private void updatePricesButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new UpdatePricesModel();
        }

        private void businessDataButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new BusinessDataModel();
        }
    }
}
