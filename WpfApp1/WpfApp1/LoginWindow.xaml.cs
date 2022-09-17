using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DatabaseHelper _dbHelper = new DatabaseHelper();
        MySqlConnection _connection;
        public LoginWindow()
        {
            InitializeComponent();
            _connection = _dbHelper.connectToDatabase();




            /*string iDate = "05.05.2005";
            DateTime oDate = Convert.ToDateTime(iDate);
            string iDate2 = "05.05.2005";
            DateTime oDate2 = Convert.ToDateTime(iDate2);
            string currentDate = DateTime.Now.Date.ToShortDateString();
            int result = DateTime.Compare(oDate, oDate2);
            if (result < 0)
                MessageBox.Show("prvi raniji");
            else if (result == 0)
                MessageBox.Show("isti");
            else
                MessageBox.Show("prvi kasniji");
            */



            /*
            string currentDate = DateTime.Now.Date.ToShortDateString();

            _connection.Open();
            MySqlCommand cmd = new MySqlCommand("Select first_name, e_mail, expire_date from GymUser", _connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string eMail = reader.GetString("e_mail");
                string fName = reader.GetString("first_name");
                if (eMail != "Nema")
                {
                    string expDate = reader.GetString("expire_date");
                    DateTime eDate = Convert.ToDateTime(expDate);
                    DateTime expDatePlusTwoDays = eDate.AddDays(2);
                    int result = DateTime.Compare(expDatePlusTwoDays, Convert.ToDateTime(currentDate));
                    if (result == 0)
                    {
                        sendExpireMessage(eMail, fName, expDate);
                    }
                }
            }
            _connection.Close();
            */



        }


        /*
        public void sendExpireMessage(string to, string who, string expDate)
        {
            string from = "nesto@gmail.com";
            string subject = "Obaveštenje o isteku članarine za GYM";
            string body = @"Poštovani " + who + ",\n Želimo da Vas obavestimo da Vaša članarina u teretani GYM ističe "+expDate+"!\n Pozdravlja Vas GYM TEAM";

            MailMessage message = new MailMessage(from, to, subject, body);

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(from, "secretPass"),
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
        }*/





        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text;
            //MessageBox.Show(email);
            string password = ComputeSha256Hash(PassBox.Password.ToString());
            //MessageBox.Show(password);
            string staff_type = "";



            try
            {
                _connection.Open();
                //MySqlCommand cmd = new MySqlCommand("Select e_mail, pass_hash, staff_type from staff where e_mail='"+email+ "' COLLATE SQL_Latin1_General_CP1_CS_AS and '" + password+ "' COLLATE SQL_Latin1_General_CP1_CS_AS", _connection);
                MySqlCommand cmd = new MySqlCommand("Select e_mail, pass_hash, staff_type from Staff where e_mail='" + email + "' and pass_hash='" + password + "' ", _connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                Boolean exist = false;
                while (reader.Read())
                {
                    staff_type = reader.GetString("staff_type");
                    //MessageBox.Show(staff_type);
                    exist = true;  
                }

                _connection.Close();

                if (exist)
                {
                    if (staff_type == "admin")
                    {
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                    }
                    else
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                    this.Close();
                }
                else {
                    MessageBox.Show("Neispravan e-mail ili lozinka! Pokušaj ponovo.");
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void CheckTempNumButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                _connection.Open();
                //MySqlCommand cmd = new MySqlCommand("Select e_mail, pass_hash, staff_type from staff where e_mail='"+email+ "' COLLATE SQL_Latin1_General_CP1_CS_AS and '" + password+ "' COLLATE SQL_Latin1_General_CP1_CS_AS", _connection);
                MySqlCommand cmd = new MySqlCommand("select count(*) as cnt from GymUser where at_gym_currently='da'", _connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                //Boolean exist = false;
                while (reader.Read())
                {
                    int num = reader.GetInt32("cnt");
                    MessageBox.Show("Trenutno je "+num.ToString()+" članova u teretani");
                    //exist = true;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
