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
using System.Windows.Shapes;
using WpfApp1.Database;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for UserDataWindow.xaml
    /// </summary>
    /// 
    public partial class UserDataWindow : Window
    {
        DatabaseHelper _dbHelper = new DatabaseHelper();
        MySqlConnection _connection;
        string userID;
        public UserDataWindow(string userID)
        {
            this.userID = userID;

            InitializeComponent();

            _connection = _dbHelper.connectToDatabase();

            try
            {
                _connection.Open();
                //MySqlCommand cmd = new MySqlCommand("Select e_mail, pass_hash, staff_type from staff where e_mail='"+email+ "' COLLATE SQL_Latin1_General_CP1_CS_AS and '" + password+ "' COLLATE SQL_Latin1_General_CP1_CS_AS", _connection);
                MySqlCommand cmd = new MySqlCommand("Select id, first_name, last_name, e_mail, user_type, membership_card, expire_date, at_gym_currently from GymUser where id=" + userID, _connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                //Boolean exist = false;
                while (reader.Read())
                {
                    IdBlock.Text = "ID člana: "+reader.GetString("id");
                    NameSurnameBlock.Text = "Ime i prezime člana: " + reader.GetString("first_name")+" "+reader.GetString("last_name");
                    EmailBlock.Text = "E-mail adresa člana: " + reader.GetString("e_mail");
                    UserTypeBlock.Text = "Tip člana: " + reader.GetString("user_type");
                    MembershipBlock.Text = "Trajanje članarine: " + reader.GetString("membership_card");
                    ExpireDateBlock.Text = "Datum isteka članarine: " + reader.GetString("expire_date");
                    AtGymBlock.Text = "Trenutno u teretani: " + reader.GetString("at_gym_currently");
                    //exist = true;
                }

                _connection.Close();   

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void getPriceButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem userTypeItem = (ComboBoxItem)comboType.SelectedItem;
            string userType = userTypeItem.Content.ToString();
            ComboBoxItem membership_durationItem = (ComboBoxItem)comboDuration.SelectedItem;
            string membership_duration = membership_durationItem.Content.ToString();

            //MessageBox.Show(userType+" "+membership_duration);

            txtPrice.Text = getPrice(userType, membership_duration).ToString();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Polje za cenu mora biti popunjeno!", "Neispravan unos");
            }
            else
            {
                ComboBoxItem userTypeItem = (ComboBoxItem)comboType.SelectedItem;
                string userType = userTypeItem.Content.ToString();
                ComboBoxItem membership_durationItem = (ComboBoxItem)comboDuration.SelectedItem;
                string membership_duration = membership_durationItem.Content.ToString();
                string price = getPrice(userType, membership_duration).ToString();
                string expireDate = getExpireDate(membership_duration);


                _connection.Open();


                string myUpdateQuery = "update GymUser set user_type='"+userType+"', membership_card='"+membership_duration+"', expire_date='"+expireDate+"' where id=" + userID;
                MySqlCommand cmdUpdateUser = new MySqlCommand(myUpdateQuery, _connection);

                MySqlDataReader MyReaderUpdate;
                MyReaderUpdate = cmdUpdateUser.ExecuteReader();
                while (MyReaderUpdate.Read())
                {
                }

                _connection.Close();

                _connection.Open();

                
                string currentDate = DateTime.Now.Date.ToShortDateString();

                string myInsertQueryArchive = "INSERT INTO Archive (user_id, begin_date, expire_date, membership_card, price) VALUES (" + userID + ", '" + currentDate + "', '" + expireDate + "', '" + membership_duration + "', '" + price + "')";

                MySqlCommand cmdInsertArchive = new MySqlCommand(myInsertQueryArchive, _connection);

                cmdInsertArchive.ExecuteNonQuery();

                _connection.Close();


                MessageBox.Show("Uspešno ste ažurirali člana", "Obaveštenje");

                UserTypeBlock.Text = "Tip člana: " + userType;
                MembershipBlock.Text = "Trajanje članarine: " + membership_duration;
                ExpireDateBlock.Text = "Datum isteka članarine: " + expireDate;

            }
        }

        public UserDataWindow getThis() {
            return this;
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

        public string getExpireDate(string membership_duration)
        {


            DateTime currDate = DateTime.Now.Date;
            DateTime expireDate = currDate;
            if (membership_duration == "1 dan")
            {
                expireDate = currDate.AddDays(1);
            }
            if (membership_duration == "7 dana")
            {
                expireDate = currDate.AddDays(7);
            }
            if (membership_duration == "30 dana")
            {
                expireDate = currDate.AddDays(30);
            }
            if (membership_duration == "6 meseci")
            {
                expireDate = currDate.AddMonths(6);
            }
            if (membership_duration == "1 godina")
            {
                expireDate = currDate.AddYears(1);
            }

            return expireDate.ToShortDateString();
        }

        private void DeleteButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li želite obrisati korisnika i sve njegove članarine iz arhive?",
                    "Upozorenje",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    string QueryDeleteFromArchive = "delete from Archive where user_id=" + userID;

                    _connection.Open();
                    MySqlCommand cmdDeleteFromArchive = new MySqlCommand(QueryDeleteFromArchive, _connection);
                    MySqlDataReader MyReaderDeleteFromArchive;
                    MyReaderDeleteFromArchive = cmdDeleteFromArchive.ExecuteReader();
                    while (MyReaderDeleteFromArchive.Read())
                    {
                    }
                    _connection.Close();

                    string QueryDeleteFromUsers = "delete from GymUser where id=" + userID;

                    _connection.Open();
                    MySqlCommand cmdDeleteFromUsers = new MySqlCommand(QueryDeleteFromUsers, _connection);
                    MySqlDataReader MyReaderDeleteFromUsers;
                    MyReaderDeleteFromUsers = cmdDeleteFromUsers.ExecuteReader();
                    while (MyReaderDeleteFromUsers.Read())
                    {
                    }
                    _connection.Close();
                    MessageBox.Show("Uspešno ste obrisali korisnika!");
                    getThis().Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
          
        }
    }
}
