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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace FirmaSpedycyjna
{
    /// <summary>
    /// Logika interakcji dla klasy AddDriversCtrl.xaml
    /// </summary>
    public partial class AddDriversCtrl : UserControl
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        public AddDriversCtrl()
        {
            InitializeComponent();
            GetID();
        }
        private void GetID()
        {
                Random rnd = new Random();
                string sqlQuery = "SELECT TOP 1 EmployeeID from Employees order by EmployeeID desc";
                SqlConnection sql = new SqlConnection(sqlConString);
                sql.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, sql);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string input = dr["EmployeeID"].ToString();
                    string angka = input.Substring(input.Length - Math.Min(3, input.Length));
                    int number = Convert.ToInt32(angka);
                    number += 1;    
                    string str = number.ToString("D3");
                    IDBox.Text = str;
                }
            dr.Close();
                string sqlQuery2 = "SELECT TOP 1 DriverID from Drivers order by DriverID desc";
                SqlCommand cmd2 = new SqlCommand(sqlQuery2, sql);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    string input = dr2["DriverID"].ToString();
                    string angka2 = input.Substring(input.Length - Math.Min(3, input.Length));
                    int number2 = Convert.ToInt32(angka2);
                    number2 += 1;
                    string str2 = number2.ToString("D4");
                    IDBox2.Text = str2;
                }
            dr2.Close();
                string sqlQuery3 = "SELECT TOP 1 TruckID from Trucks order by TruckID desc";
                SqlCommand cmd3 = new SqlCommand(sqlQuery3, sql);
                SqlDataReader dr3 = cmd3.ExecuteReader();
                while (dr3.Read())
                {
                    string input = dr3["TruckID"].ToString();
                    string angka3 = input.Substring(input.Length - Math.Min(3, input.Length));
                    int number3 = Convert.ToInt32(angka3);
                    number3 += 1;
                    string str3 = number3.ToString("D5");
                    IDBox3.Text = str3;
                }
            dr3.Close();
                string sqlQuery4 = "SELECT TOP 1 EmployeeID from Employees order by EmployeeID desc";
                SqlCommand cmd4 = new SqlCommand(sqlQuery4, sql);
                SqlDataReader dr4 = cmd4.ExecuteReader();
                while (dr4.Read())
                {
                    string input = dr4["EmployeeID"].ToString();
                    string angka4 = input.Substring(input.Length - Math.Min(3, input.Length));
                    int number4 = Convert.ToInt32(angka4);
                    string str4 = number4.ToString("D6");
                    number4 += 0;
                    IDBox4.Text = str4;
                }
            dr4.Close();
                string sqlQuery5 = "SELECT TOP 1 EmployeeID from Drivers order by EmployeeID desc";
                SqlCommand cmd5 = new SqlCommand(sqlQuery5, sql);
                SqlDataReader dr5 = cmd5.ExecuteReader();
                while (dr5.Read())
                {
                    string input = dr5["EmployeeID"].ToString();
                    string angka5 = input.Substring(input.Length - Math.Min(3, input.Length));
                    int number5 = Convert.ToInt32(angka5);
                    number5 += 1;
                    string str5 = number5.ToString("D7");
                    IDBox5.Text = str5;
                }
            int val = (rnd.Next(0, 2)) * 1;
            ADRBox.Text = val.ToString();
            IDBox5.Visibility = Visibility.Hidden;
            IDBox4.Visibility = Visibility.Hidden;
            IDBox3.Visibility = Visibility.Hidden;
            IDBox2.Visibility = Visibility.Hidden;
            IDBox.Visibility = Visibility.Hidden;
        }
        private void AddDrivers()
        {
            SqlConnection sql = new SqlConnection(sqlConString);
            sql.Open();
            try
            {
                string TaskToEmployees = "INSERT INTO Employees(Employees.EmployeeID,FirstName,LastName,BirthDate,HireDate) VALUES(@EmployeeID,@FirstName,@LastName,@BirthDate,@HireDate)";
                string TaskToDrivers = "INSERT INTO Drivers(DriverID,EmployeeID,ADR) VALUES(@DriverID,@EmployeeID,@ADR)";
                string TaskToTrucks = "INSERT INTO Trucks(TruckID, DriverID, Truck, LicensePlate) VALUES(@TruckID,@DriverID,@Truck,@LicensePlate)";
                SqlCommand addToEmployees = sql.CreateCommand();
                SqlCommand addToDrivers = sql.CreateCommand();
                SqlCommand addToTrucks = sql.CreateCommand();
                addToEmployees.CommandType = System.Data.CommandType.Text;
                addToDrivers.CommandType = System.Data.CommandType.Text;
                addToTrucks.CommandType = System.Data.CommandType.Text;
                addToDrivers.CommandText = TaskToDrivers;
                addToEmployees.CommandText = TaskToEmployees;
                addToTrucks.CommandText = TaskToTrucks;
                //Adding to Drivers
                addToDrivers.Parameters.AddWithValue("@DriverID", IDBox2.Text); // DriverID
                addToDrivers.Parameters.AddWithValue("@EmployeeID", IDBox4.Text); // EmployeeID
                addToDrivers.Parameters.AddWithValue("@ADR", ADRBox.Text); // ADR
                //Adding to Employees
                addToEmployees.Parameters.AddWithValue("@EmployeeID", IDBox.Text); // EmployeeID
                addToEmployees.Parameters.AddWithValue("@FirstName", FNameBox.Text); // FirstName
                addToEmployees.Parameters.AddWithValue("@LastName", LNameBox.Text); // LastName
                addToEmployees.Parameters.AddWithValue("@BirthDate", BirthDate.SelectedDate); // Birth date
                addToEmployees.Parameters.AddWithValue("@HireDate", HireDate.SelectedDate); // Hire Date
                //Adding to trucks
                addToTrucks.Parameters.AddWithValue("@TruckID", IDBox3.Text);
                addToTrucks.Parameters.AddWithValue("@DriverID", IDBox2.Text);
                addToTrucks.Parameters.AddWithValue("@Truck", TruckBox.Text);
                addToTrucks.Parameters.AddWithValue("@LicensePlate", LicensePlateBox.Text);
                //Execute
                addToDrivers.ExecuteNonQuery();
                addToEmployees.ExecuteNonQuery();
                addToTrucks.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Hide()
        {
            FNameBox.Visibility = Visibility.Hidden;
            LNameBox.Visibility = Visibility.Hidden;
            TruckBox.Visibility = Visibility.Hidden;
            LicensePlateBox.Visibility = Visibility.Hidden;
            IDBox2.Visibility = Visibility.Hidden;
            IDBox.Visibility = Visibility.Hidden;
            IDBox3.Visibility = Visibility.Hidden;
            IDBox5.Visibility = Visibility.Hidden;
            ADRBox.Visibility = Visibility.Hidden;
            HireDate.Visibility = Visibility.Hidden;
            BirthDate.Visibility = Visibility.Hidden;
            TruckIDBox.Visibility = Visibility.Hidden;
            FNameTxt.Visibility = Visibility.Hidden;
            LNameTxt.Visibility = Visibility.Hidden;
            BDayTxt.Visibility = Visibility.Hidden;
            HDayTxt.Visibility = Visibility.Hidden;
            TruckTxt.Visibility = Visibility.Hidden;
            LPlateTxt.Visibility = Visibility.Hidden;
            SubmitBut.Visibility = Visibility.Hidden;
        }
        private void SubmitBtn(object sender, RoutedEventArgs e)
        {
            AddDrivers();
            Hide();
        }
    }
}
