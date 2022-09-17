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
    /// Interaction logic for ArchiveView.xaml
    /// </summary>
    public partial class ArchiveView : UserControl
    {
        DatabaseHelper _dbHelper = new DatabaseHelper();
        MySqlConnection _connection;
        public ArchiveView()
        {
            InitializeComponent();
            _connection = _dbHelper.connectToDatabase();


            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select id, user_id, begin_date, expire_date, membership_card, price from Archive", _connection);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBindingArchive");
                dataGridArchive.DataContext = ds;
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
