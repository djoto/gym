using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Database;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for AddEmployeeView.xaml
    /// </summary>
    public partial class AddEmployeeView : UserControl
    {
        DatabaseHelper _dbHelper = new DatabaseHelper();
        MySqlConnection _connection;
        public AddEmployeeView()
        {
            InitializeComponent();
            _connection = _dbHelper.connectToDatabase();
        }

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

        private void addButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtSurname.Text) || String.IsNullOrEmpty(PassBox.Password) || String.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Polja za ime, prezime, e-mail i lozinku moraju biti popunjena!", "Neispravan unos");
            }
            else
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string e_mail = txtEmail.Text;
                string staff_type = "employee";
                string password = ComputeSha256Hash(PassBox.Password.ToString());


                _connection.Open();


                string myInsertQuery = "INSERT INTO Staff (first_name, last_name, e_mail, staff_type, pass_hash) VALUES ('" + name + "','" + surname + "', '" + e_mail + "', '" + staff_type + "', '" + password + "')";

                MySqlCommand cmdInsertUser = new MySqlCommand(myInsertQuery, _connection);

                cmdInsertUser.ExecuteNonQuery();

                _connection.Close();

                MessageBox.Show("Uspešno ste dodali zaposlenog!", "Obaveštenje");

            }
        }
    }
}
