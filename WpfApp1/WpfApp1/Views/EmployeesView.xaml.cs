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
using WpfApp1.Database;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    public partial class EmployeesView : UserControl
    {
        DatabaseHelper _dbHelper = new DatabaseHelper();
        MySqlConnection _connection;
        public EmployeesView()
        {
            InitializeComponent();
            _connection = _dbHelper.connectToDatabase();

            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select id, first_name, last_name, e_mail, staff_type from Staff", _connection);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                dataGridUsers.DataContext = ds;
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool employeeExists(string id)
        {
            _connection.Open();
            //MySqlCommand cmd = new MySqlCommand("Select e_mail, pass_hash, staff_type from staff where e_mail='"+email+ "' COLLATE SQL_Latin1_General_CP1_CS_AS and '" + password+ "' COLLATE SQL_Latin1_General_CP1_CS_AS", _connection);
            MySqlCommand cmd = new MySqlCommand("Select * from Staff where id=" + id + " and staff_type='employee'", _connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            bool exist = false;
            while (reader.Read())
            {
                exist = true;
            }

            //MessageBox.Show(exist.ToString());

            _connection.Close();

            return exist;
        }

        private void ViewDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string usrId = ViewDeleteIdBox.Text;
            if (employeeExists(usrId))
            {
                if (String.IsNullOrEmpty(ViewDeleteIdBox.Text))
                {
                    MessageBox.Show("Polje za id mora biti popunjeno!", "Neispravan unos");
                }
                else
                {
                    if (MessageBox.Show("Da li želite obrisati zaposlenog?",
                        "Upozorenje",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {

                            _connection.Open();

                            string QueryDeleteFromStaff = "delete from Staff where id=" + usrId + " and staff_type='employee'";


                            MySqlCommand cmdDeleteFromStaff = new MySqlCommand(QueryDeleteFromStaff, _connection);
                            MySqlDataReader MyReaderDeleteFromStaff;
                            MyReaderDeleteFromStaff = cmdDeleteFromStaff.ExecuteReader();
                            while (MyReaderDeleteFromStaff.Read())
                            {
                            }
                            _connection.Close();

                            MessageBox.Show("Uspešno ste obrisali zaposlenog!");




                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ne postoji zaposleni sa unesenim ID-em!");
            }
        }
    }
}
