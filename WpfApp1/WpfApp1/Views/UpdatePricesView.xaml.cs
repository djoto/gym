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

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for UpdatePricesView.xaml
    /// </summary>
    public partial class UpdatePricesView : UserControl
    {
        DatabaseHelper _dbHelper = new DatabaseHelper();
        MySqlConnection _connection;
        public UpdatePricesView()
        {
            InitializeComponent();
            _connection = _dbHelper.connectToDatabase();
        }

        private void updatePrButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem userTypeItem = (ComboBoxItem)comboType.SelectedItem;
            string userType = userTypeItem.Content.ToString();
            ComboBoxItem membership_durationItem = (ComboBoxItem)comboDuration.SelectedItem;
            string membership_duration = membership_durationItem.Content.ToString();

            updatePrice(userType, membership_duration, txtNewPrice.Text);
        }

        private void getPriceButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem userTypeItem = (ComboBoxItem)comboType.SelectedItem;
            string userType = userTypeItem.Content.ToString();
            ComboBoxItem membership_durationItem = (ComboBoxItem)comboDuration.SelectedItem;
            string membership_duration = membership_durationItem.Content.ToString();

            txtPrice.Text = getPrice(userType, membership_duration).ToString();
        }

        public int getPrice(String userType, String membership_duration)
        {
            int price = 0;
            try
            {
                _connection.Open();
                //MySqlCommand cmd = new MySqlCommand("Select e_mail, pass_hash, staff_type from staff where e_mail='"+email+ "' COLLATE SQL_Latin1_General_CP1_CS_AS and '" + password+ "' COLLATE SQL_Latin1_General_CP1_CS_AS", _connection);
                MySqlCommand cmd = new MySqlCommand("select price from Price where user_type='" + userType + "' and membership_duration='" + membership_duration + "'", _connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    price = Int32.Parse(reader.GetString("price"));
                }

                _connection.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return price;
        }

        public void updatePrice(String userType, String membership_duration, String newPrice) {
            var isNumeric = int.TryParse(newPrice, out _);
            if (String.IsNullOrEmpty(newPrice) || !isNumeric)
            {
                MessageBox.Show("Polje za novu cenu mora biti popunjeno i imati numeričku vrednost!", "Neispravan unos");
            }
            else
            {
                _connection.Open();

                string myUpdateQuery = "update Price set price='" + newPrice + "' where user_type='" + userType + "' and membership_duration='" + membership_duration + "'";
                MySqlCommand cmdUpdateUser = new MySqlCommand(myUpdateQuery, _connection);

                MySqlDataReader MyReaderUpdate;
                MyReaderUpdate = cmdUpdateUser.ExecuteReader();
                while (MyReaderUpdate.Read())
                {
                }

                _connection.Close();

                MessageBox.Show("Cena je uspešno ažurirana!", "Obaveštenje");
            }
        }

    }
}
