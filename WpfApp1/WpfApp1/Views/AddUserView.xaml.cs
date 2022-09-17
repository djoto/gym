using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Interaction logic for AddUserView.xaml
    /// </summary>
    public partial class AddUserView : UserControl
    {
        DatabaseHelper _dbHelper = new DatabaseHelper();
        MySqlConnection _connection;
        public AddUserView()
        {
            InitializeComponent();
            _connection = _dbHelper.connectToDatabase();
        }

        /*
        public void sendWelcomeMessage(string to, string who)
        {
            string from = "mejl@gmail.com";
            string subject = "Dobrodošli u teretanu GYM";
            string body = @"Poštovani " + who + ",\n Želimo Vam dobrodošlicu u teretanu GYM!\n Pozdravlja Vas GYM TEAM";

            MailMessage message = new MailMessage(from, to, subject, body);

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(from, "password"),
                EnableSsl = true
            };

            try
            {
                client.Send(message);
                //MessageBox.Show("Poslato");
            }
            catch
            {
                throw;
                //MessageBox.Show("Nije uspelo slanje");
            }
        }
        */

        private void addButton_Click(object sender, RoutedEventArgs e)
        { 
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtSurname.Text) || String.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Polja za ime, prezime i cenu moraju biti popunjena!", "Neispravan unos");
            }
            else
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string e_mail = txtEmail.Text;
                if (String.IsNullOrEmpty(txtEmail.Text)) { 
                    e_mail = "Nema";
                }
                ComboBoxItem userTypeItem = (ComboBoxItem)comboType.SelectedItem;
                string userType = userTypeItem.Content.ToString();
                ComboBoxItem membership_durationItem = (ComboBoxItem)comboDuration.SelectedItem;
                string membership_duration = membership_durationItem.Content.ToString();
                string price = getPrice(userType, membership_duration).ToString();
                string expireDate = getExpireDate(membership_duration);
                
                /*string iDate = "05.05.2005";
                DateTime oDate = Convert.ToDateTime(iDate);
                string iDate2 = "05.05.2005";
                DateTime oDate2 = Convert.ToDateTime(iDate2);
                int result = DateTime.Compare(oDate, oDate2);
                if (result < 0)
                    MessageBox.Show("prvi raniji");
                else if (result == 0)
                    MessageBox.Show("isti");
                else
                    MessageBox.Show("prvi kasniji");
                */
                

                _connection.Open();


                string myInsertQuery = "INSERT INTO GymUser (first_name, last_name, e_mail, user_type, membership_card, expire_date, at_gym_currently) VALUES ('" + name + "','" + surname + "', '" + e_mail + "', '" + userType + "', '" + membership_duration + "', '" + expireDate + "', 'ne')";

                MySqlCommand cmdInsertUser = new MySqlCommand(myInsertQuery, _connection);

                cmdInsertUser.ExecuteNonQuery();
                int lastId = (Int32)cmdInsertUser.LastInsertedId;


                string currentDate = DateTime.Now.Date.ToShortDateString();

                string myInsertQueryArchive = "INSERT INTO Archive (user_id, begin_date, expire_date, membership_card, price) VALUES (" + lastId.ToString() + ", '" + currentDate + "', '" + expireDate + "', '" + membership_duration + "', '" + price + "')";

                MySqlCommand cmdInsertArchive = new MySqlCommand(myInsertQueryArchive, _connection);

                cmdInsertArchive.ExecuteNonQuery();

                _connection.Close();



                /*
                if (e_mail != "Nema")
                {
                    sendWelcomeMessage(e_mail, name);
                }
                */


                MessageBox.Show("Uspešno ste dodali člana", "Obaveštenje");

            }

        }
        public int getPrice(String userType, String membership_duration) {
            int price = 0;
            try
            {
                _connection.Open();
                //MySqlCommand cmd = new MySqlCommand("Select e_mail, pass_hash, staff_type from staff where e_mail='"+email+ "' COLLATE SQL_Latin1_General_CP1_CS_AS and '" + password+ "' COLLATE SQL_Latin1_General_CP1_CS_AS", _connection);
                MySqlCommand cmd = new MySqlCommand("select price from Price where user_type='" + userType + "' and membership_duration='"+ membership_duration + "'", _connection);

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

        public string getExpireDate(string membership_duration) {
        

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

        private void getPriceButton_Click(object sender, RoutedEventArgs e)
        {

            ComboBoxItem userTypeItem = (ComboBoxItem)comboType.SelectedItem;
            string userType = userTypeItem.Content.ToString();
            ComboBoxItem membership_durationItem = (ComboBoxItem)comboDuration.SelectedItem;
            string membership_duration = membership_durationItem.Content.ToString();


            txtPrice.Text = getPrice(userType, membership_duration).ToString();
        }
    }
}
