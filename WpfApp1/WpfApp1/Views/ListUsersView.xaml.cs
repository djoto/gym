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
    /// Interaction logic for ListUsersView.xaml
    /// </summary>
    public partial class ListUsersView : UserControl
    {
        DatabaseHelper _dbHelper = new DatabaseHelper();
        MySqlConnection _connection;
        public ListUsersView()
        {
            InitializeComponent();

            _connection = _dbHelper.connectToDatabase();

            /*
            MySqlCommand cmd = new MySqlCommand("select * from gymuser;", _connection);

            _connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            _connection.Close();

            dtGrid.DataContext = dt;
            */
            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select id, first_name, last_name, e_mail, user_type, membership_card, expire_date, at_gym_currently from GymUser", _connection);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string usrId = ViewUpdateIdBox.Text;
            try
            {
                _connection.Open();
                //MySqlCommand cmd = new MySqlCommand("Select e_mail, pass_hash, staff_type from staff where e_mail='"+email+ "' COLLATE SQL_Latin1_General_CP1_CS_AS and '" + password+ "' COLLATE SQL_Latin1_General_CP1_CS_AS", _connection);
                MySqlCommand cmd = new MySqlCommand("select * from GymUser where id="+usrId, _connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                Boolean exist = false;
                while (reader.Read())
                {
                    exist = true;
                }

                _connection.Close();

                if (exist)
                {
                    UserDataWindow userDataWindow = new UserDataWindow(usrId);
                    userDataWindow.Show();

                }
                else
                {
                    MessageBox.Show("Uneli ste nepostojeći ID! Pokušajte ponovo.");
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Unesite ID ili proverite konekciju sa serverom!");
                //MessageBox.Show(ex.ToString());
            }
        }
    }
}
