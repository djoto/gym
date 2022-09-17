using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModels;
using WpfApp1.Database;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
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
    }
}
