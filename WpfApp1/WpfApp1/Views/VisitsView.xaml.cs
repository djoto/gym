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
    /// Interaction logic for VisitsView.xaml
    /// </summary>
    public partial class VisitsView : UserControl
    {
        DatabaseHelper _dbHelper = new DatabaseHelper();
        MySqlConnection _connection;
        public VisitsView()
        {
            InitializeComponent();
            _connection = _dbHelper.connectToDatabase();
        }

        public Boolean userExists(string id)
        {
            _connection.Open();

            MySqlCommand cmd = new MySqlCommand("select * from GymUser where id=" + id, _connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            Boolean exist = false;
            while (reader.Read())
            {
                exist = true;
            }
            _connection.Close();

            return exist;
        }

        private void arriveButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(IdVisitBox.Text))
            {
                MessageBox.Show("Polje za ID mora biti popunjeno!", "Neispravan unos");
            }
            else
            {
                try
                {
                    string id1 = IdVisitBox.Text;

                    if (userExists(id1))
                    {

                        _connection.Open();


                        string myUpdateQuery1 = "update GymUser set at_gym_currently='da' where id=" + id1;
                        MySqlCommand cmdUpdateUser1 = new MySqlCommand(myUpdateQuery1, _connection);

                        MySqlDataReader MyReaderUpdate1;
                        MyReaderUpdate1 = cmdUpdateUser1.ExecuteReader();
                        while (MyReaderUpdate1.Read())
                        {
                        }


                        _connection.Close();
                        string currentDate = DateTime.Now.Date.ToShortDateString();
                        string currentDay = DateTime.Now.Date.ToString("dddd");

                        string currentDaySrb = "";

                        switch (currentDay)
                        {
                            case "Monday":
                                currentDaySrb = "Ponedeljak";
                                break;
                            case "Tuesday":
                                currentDaySrb = "Utorak";
                                break;
                            case "Wednesday":
                                currentDaySrb = "Sreda";
                                break;
                            case "Thursday":
                                currentDaySrb = "Četvrtak";
                                break;
                            case "Friday":
                                currentDaySrb = "Petak";
                                break;
                            case "Saturday":
                                currentDaySrb = "Subota";
                                break;
                            case "Sunday":
                                currentDaySrb = "Nedelja";
                                break;
                        }

                        //MessageBox.Show(currentDaySrb, "Obaveštenje");



                        _connection.Open();

                        MySqlCommand cmd = new MySqlCommand("select * from Visit where visit_date='" + currentDate + "'", _connection);

                        MySqlDataReader reader = cmd.ExecuteReader();

                        Boolean exist = false;
                        while (reader.Read())
                        {
                            exist = true;
                        }
                        _connection.Close();

                        if (!exist)
                        {
                            _connection.Open();

                            int begin_num = 1;

                            string myInsertQueryVisit = "INSERT INTO Visit (visit_date, visit_day, num_visitors) VALUES ('" + currentDate + "', '" + currentDaySrb + "', " + begin_num.ToString() + ")";

                            MySqlCommand cmdInsertVisit = new MySqlCommand(myInsertQueryVisit, _connection);

                            cmdInsertVisit.ExecuteNonQuery();


                            _connection.Close();

                        }
                        else
                        {
                            _connection.Open();


                            string myUpdateQueryInc = "update Visit set num_visitors=num_visitors+1 where visit_date='" + currentDate + "'";
                            MySqlCommand cmdUpdateUserInc = new MySqlCommand(myUpdateQueryInc, _connection);

                            MySqlDataReader MyReaderUpdateInc;
                            MyReaderUpdateInc = cmdUpdateUserInc.ExecuteReader();
                            while (MyReaderUpdateInc.Read())
                            {
                            }

                            _connection.Close();
                        }

                        MessageBox.Show("Uspešno ste registrovali dolazak.", "Obaveštenje");
                    }
                    else
                    {
                        MessageBox.Show("Ne postoji član sa unesenim identifikatorom!", "Obaveštenje");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne postoji član sa unesenim identifikatorom ili postoji problem sa konekcijom!", "Obaveštenje");
                }
            }
        }

        private void leftButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(DateTime.Now.Date.ToShortDateString());
            //MessageBox.Show(DateTime.Now.Date.ToString("dddd"));
            if (String.IsNullOrEmpty(IdVisitBox.Text))
            {
                MessageBox.Show("Polje za ID mora biti popunjeno!", "Neispravan unos");
            }
            else
            {
                try
                {
                    string id = IdVisitBox.Text;

                    if (userExists(id))
                    {

                        _connection.Open();


                        string myUpdateQuery = "update GymUser set at_gym_currently='ne' where id=" + id;
                        MySqlCommand cmdUpdateUser = new MySqlCommand(myUpdateQuery, _connection);

                        MySqlDataReader MyReaderUpdate;
                        MyReaderUpdate = cmdUpdateUser.ExecuteReader();
                        while (MyReaderUpdate.Read())
                        {
                        }

                        _connection.Close();
                        MessageBox.Show("Uspešno ste registrovali odlazak.", "Obaveštenje");
                    }
                    else
                    {
                        MessageBox.Show("Ne postoji član sa unesenim identifikatorom!", "Obaveštenje");
                    }
                   
                }
                catch (Exception ex) {
                    MessageBox.Show("Ne postoji član sa unesenim identifikatorom ili postoji problem sa konekcijom!", "Obaveštenje");
                }
            }
        }

        private void listArrivedButton_Click(object sender, RoutedEventArgs e)
        {

            try {
                string query = "Select id, first_name, last_name, e_mail, user_type, membership_card, expire_date, at_gym_currently from GymUser where at_gym_currently='da'";
                UsersAfterSearchWindow usersAfterSearchWindow = new UsersAfterSearchWindow(query);
                usersAfterSearchWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Postoji problem sa konekcijom!", "Obaveštenje");
            }
        }
    }
}
