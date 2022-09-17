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
    /// Interaction logic for BusinessDataView.xaml
    /// </summary>
    public partial class BusinessDataView : UserControl
    {
        DatabaseHelper _dbHelper = new DatabaseHelper();
        MySqlConnection _connection;
        public BusinessDataView()
        {
            InitializeComponent();
            _connection = _dbHelper.connectToDatabase();
        }

        private void showSalaryButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem monthItem = (ComboBoxItem)comboMonthSalary.SelectedItem;
            string month = monthItem.Content.ToString();
            ComboBoxItem yearItem = (ComboBoxItem)comboYearSalary.SelectedItem;
            string year = yearItem.Content.ToString();



            try
            {
                _connection.Open();
             
                MySqlCommand cmd = new MySqlCommand("select price, begin_date from Archive", _connection);

                MySqlDataReader reader = cmd.ExecuteReader();
                int price = 0;
                while (reader.Read())
                {
                    if ((month == "svaki") && (year == "svake"))
                    {
                        price += Int32.Parse(reader.GetString("price"));
                    }
                    if ((month != "svaki") && (year == "svake"))
                    {
                        if((reader.GetString("begin_date")).Substring(3, 2) == getMonthNum(month))
                        {
                            price += Int32.Parse(reader.GetString("price"));
                        }
                    }
                    if ((month == "svaki") && (year != "svake"))
                    {
                        if ((reader.GetString("begin_date")).Substring(6, 4) == year)
                        {
                            price += Int32.Parse(reader.GetString("price"));
                        }
                    }
                    if ((month != "svaki") && (year != "svake"))
                    {
                        if (((reader.GetString("begin_date")).Substring(3, 2) == getMonthNum(month)) && ((reader.GetString("begin_date")).Substring(6, 4) == year))
                        {
                            price += Int32.Parse(reader.GetString("price"));
                        }
                    }

                }

                _connection.Close();

                MessageBox.Show("Ukupna zarada za "+month+" mesec "+year+" godine je "+price.ToString() + ".", "Podaci o zaradi");

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void showVisitsButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem monthItem = (ComboBoxItem)comboMonthVisits.SelectedItem;
            string month = monthItem.Content.ToString();
            ComboBoxItem yearItem = (ComboBoxItem)comboYearVisits.SelectedItem;
            string year = yearItem.Content.ToString();

            try
            {
                _connection.Open();

                MySqlCommand cmd = new MySqlCommand("select visit_date, num_visitors from Visit", _connection);

                MySqlDataReader reader = cmd.ExecuteReader();
                int numVisitors = 0;
                while (reader.Read())
                {
                    if ((month == "svaki") && (year == "svake"))
                    {
                        numVisitors += reader.GetInt32("num_visitors");
                    }
                    if ((month != "svaki") && (year == "svake"))
                    {
                        if ((reader.GetString("visit_date")).Substring(3, 2) == getMonthNum(month))
                        {
                            numVisitors += reader.GetInt32("num_visitors");
                        }
                    }
                    if ((month == "svaki") && (year != "svake"))
                    {
                        if ((reader.GetString("visit_date")).Substring(6, 4) == year)
                        {
                            numVisitors += reader.GetInt32("num_visitors");
                        }
                    }
                    if ((month != "svaki") && (year != "svake"))
                    {
                        if (((reader.GetString("visit_date")).Substring(3, 2) == getMonthNum(month)) && ((reader.GetString("visit_date")).Substring(6, 4) == year))
                        {
                            numVisitors += reader.GetInt32("num_visitors");
                        }
                    }

                }

                _connection.Close();

                MessageBox.Show("Ukupan broj posetilaca za " + month + " mesec " + year + " godine je " + numVisitors.ToString() + ".", "Podaci o posetama");

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void avgWeekButton_Click(object sender, RoutedEventArgs e)
        {

            int monday = 0;
            int tuesday = 0;
            int wednesday = 0;
            int thursday = 0;
            int friday = 0;
            int saturday = 0;
            int sunday = 0;

            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT round(avg(num_visitors)) as avrg FROM Visit WHERE visit_day='Ponedeljak'", _connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    monday = reader.GetInt32("avrg");
                }
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }


            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT round(avg(num_visitors)) as avrg FROM Visit WHERE visit_day='Utorak'", _connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tuesday = reader.GetInt32("avrg");
                }
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }


            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT round(avg(num_visitors)) as avrg FROM Visit WHERE visit_day='Sreda'", _connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    wednesday = reader.GetInt32("avrg");
                }
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }


            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT round(avg(num_visitors)) as avrg FROM Visit WHERE visit_day='Četvrtak'", _connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    thursday = reader.GetInt32("avrg");
                }
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }


            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT round(avg(num_visitors)) as avrg FROM Visit WHERE visit_day='Petak'", _connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    friday = reader.GetInt32("avrg");
                }
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }


            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT round(avg(num_visitors)) as avrg FROM Visit WHERE visit_day='Subota'", _connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    saturday = reader.GetInt32("avrg");
                }
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }


            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT round(avg(num_visitors)) as avrg FROM Visit WHERE visit_day='Nedelja'", _connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sunday = reader.GetInt32("avrg");
                }
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }


            MessageBox.Show("Prosečan broj posetilaca po danima: " + "\n\nPonedeljak - " + monday.ToString() + "\n\nUtorak - " + tuesday.ToString() + "\n\nSreda - " + wednesday.ToString() + "\n\nČetvrtak - " + thursday.ToString() + "\n\nPetak - " + friday.ToString() + "\n\nSubota - " + saturday.ToString() + "\n\nNedelja - " + sunday.ToString(), "Broj posetilaca po danima u nedelji");

        }

        public String getMonthNum(String monthStr)
        {
            String numStr = "";
            switch (monthStr)
            {
                case "svaki":
                    numStr = "";
                    break;
                case "januar":
                    numStr = "01";
                    break;
                case "februar":
                    numStr = "02";
                    break;
                case "mart":
                    numStr = "03";
                    break;
                case "april":
                    numStr = "04";
                    break;
                case "maj":
                    numStr = "05";
                    break;
                case "jun":
                    numStr = "06";
                    break;
                case "jul":
                    numStr = "07";
                    break;
                case "avgust":
                    numStr = "08";
                    break;
                case "septembar":
                    numStr = "09";
                    break;
                case "oktobar":
                    numStr = "10";
                    break;
                case "novembar":
                    numStr = "11";
                    break;
                case "decembar":
                    numStr = "12";
                    break;
            }
            return numStr;
        }


    }
}
