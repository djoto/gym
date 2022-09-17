using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Database
{
    public class DatabaseHelper
    {

        public MySqlConnection connectToDatabase() {
            string connectionString = "SERVER=localhost;DATABASE=gym;UID=root;PASSWORD=JRfbhjF8MbdTpvzT;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }
    }
}
