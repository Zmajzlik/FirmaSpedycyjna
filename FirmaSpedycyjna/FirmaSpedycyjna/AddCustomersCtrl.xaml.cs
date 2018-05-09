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
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FirmaSpedycyjna
{
   public partial class AddCustomersCtrl : UserControl
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        public AddCustomersCtrl()
        {
            InitializeComponent();
            GetID();
        }
        private void GetID()
        {
            try
            {
                
                string sqlQuery = "SELECT TOP 1 CustomerID from Customers order by CustomerID desc";
                SqlConnection sql = new SqlConnection(sqlConString);
                sql.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, sql);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string input = dr["CustomerID"].ToString();
                    string angka = input.Substring(input.Length - Math.Min(3, input.Length));
                    int number = Convert.ToInt32(angka);
                    number += 1;
                    string str = number.ToString("D3");
                    IDBox.Text = str;
                }
            }
            catch {

            }
        }
        private void AddCustomers()
        {
            SqlConnection sql = new SqlConnection(sqlConString);
            using (SqlCommand addCustomer = new SqlCommand())
            {
                addCustomer.Connection = sql;
                addCustomer.CommandType = System.Data.CommandType.Text;
                addCustomer.CommandText = "INSERT INTO Customers(CustomerID,CompanyName, CompanyAddress, City, Region, PostalCode, Country) VALUES(@CustomerID,@CompanyName, @CompanyAddress, @City, @Region, @PostalCode, @Country)";
                addCustomer.Parameters.AddWithValue("@CustomerID", IDBox.Text);
                addCustomer.Parameters.AddWithValue("@CompanyName",CompNameBox.Text);
                addCustomer.Parameters.AddWithValue("@CompanyAddress",CompAddrBox.Text);
                addCustomer.Parameters.AddWithValue("@City",CompCityBox.Text);
                addCustomer.Parameters.AddWithValue("@Region",CompRegionBox.Text);
                addCustomer.Parameters.AddWithValue("@PostalCode",CompPostalBox.Text);
                addCustomer.Parameters.AddWithValue("@Country",CompCountryBox.Text);
                try
                {
                    sql.Open();
                    addCustomer.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AddBtn(object sender, RoutedEventArgs e)
        {
            AddCustomers();
            CompNameBox.Clear();
            CompAddrBox.Clear();
            CompCityBox.Clear();
            CompCountryBox.Clear();
            CompPostalBox.Clear();
            CompRegionBox.Clear();
        }
        private void Back()
        {
            GridForAddingCustomers.Visibility = Visibility.Hidden;
        }
        private void BackBtn(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}
