using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Database;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for SearchUsersView.xaml
    /// </summary>
    public partial class SearchUsersView : UserControl
    {
        DatabaseHelper _dbHelper = new DatabaseHelper();
        MySqlConnection _connection;
        public SearchUsersView()
        {

            InitializeComponent();

            _connection = _dbHelper.connectToDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string query = "Select id, first_name, last_name, e_mail, user_type, membership_card, expire_date, at_gym_currently from GymUser";
            UsersAfterSearchWindow usersAfterSearchWindow = new UsersAfterSearchWindow(getSearchQuery());
            usersAfterSearchWindow.Show();
        }

        public string getSearchQuery() {

            string id = IdFilter.Text;
            string name = NameFilter.Text;
            string surname = SurnameFilter.Text;
            string e_mail = EmailFilter.Text;
            ComboBoxItem userTypeItem = (ComboBoxItem)UserTypeFilterCombo.SelectedItem;
            string userType = userTypeItem.Content.ToString();
            ComboBoxItem membership_durationItem = (ComboBoxItem)DurationFilterCombo.SelectedItem;
            string membership_duration = membership_durationItem.Content.ToString();
            ComboBoxItem atGymItem = (ComboBoxItem)AtGymFilterCombo.SelectedItem;
            string at_gym = atGymItem.Content.ToString();

            string query = "Select id, first_name, last_name, e_mail, user_type, membership_card, expire_date, at_gym_currently from GymUser";

            Boolean filterExist = false;

            if (id != "") {
                query += " where id=" + id;
                filterExist = true;
            }
            if (name != "") {
                if (filterExist) {
                    query += " and first_name like '" + name + "%'";
                }
                else {
                    query += " where first_name like '" + name + "%'";
                }
                filterExist = true;
            }
            if (surname != "") {
                if (filterExist)
                {
                    query += " and last_name like '" + surname + "%'";
                }
                else
                {
                    query += " where last_name like '" + surname + "%'";
                }
                filterExist = true;
            }
            if (e_mail != "") {
                if (filterExist)
                {
                    query += " and e_mail like '" + e_mail + "%'";
                }
                else
                {
                    query += " where e_mail like '" + e_mail + "%'";
                }
                filterExist = true;
            }
            if (userType != "Svi") {
                if (filterExist)
                {
                    query += " and user_type='" + userType + "'";
                }
                else
                {
                    query += " where user_type='" + userType + "'";
                }
                filterExist = true;
            }
            if (membership_duration != "Svi") {
                if (filterExist)
                {
                    query += " and membership_card='" + membership_duration + "'";
                }
                else
                {
                    query += " where membership_card='" + membership_duration + "'";
                }
                filterExist = true;
            }
            if (at_gym != "Svi") {
                if (filterExist)
                {
                    query += " and at_gym_currently='" + at_gym + "'";
                }
                else
                {
                    query += " where at_gym_currently='" + at_gym + "'";
                }
                filterExist = true;
            }

            return query;
        }
    }
}
