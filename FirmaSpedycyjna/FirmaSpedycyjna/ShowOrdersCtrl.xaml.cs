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
    /// <summary>
    /// Logika interakcji dla klasy ShowOrdersCtrl.xaml
    /// </summary>
    public partial class ShowOrdersCtrl : UserControl
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        
        public ShowOrdersCtrl()
        {
            InitializeComponent();
            InsertDataToGrid();
        }
        private void InsertDataToGrid()
        {
            SqlConnection sql = new SqlConnection(sqlConString);
            //Inserting customers data to DataGrid
            string showcust = "SELECT CONCAT('(',CustomerID,')',' ',CompanyName) as Customer from Customers";
            try
            {
                sql.Open();
                using (SqlCommand showing = new SqlCommand())
                {
                    SqlCommand show = new SqlCommand(showcust, sql);
                    SqlDataAdapter sdr = new SqlDataAdapter(show);
                    DataTable dt = new DataTable();
                    sdr.Fill(dt);
                    CustomersGrid.ItemsSource = dt.DefaultView;
                    show.ExecuteNonQuery();  
                }
                //Close connection after inserting data
                sql.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sql.Close();
            }
        }
        private void AddOrder()
        {
            SqlConnection sql = new SqlConnection(sqlConString);
            String query = "INSERT INTO Orders (OrderID, OrderDate,RequiredDate, Destination, ShippedFrom, ShippedDate,CustomerID) VALUES (@OrderID,@CustomerID,@OrderDate,@RequiredDate,@Destination,@ShippedFrom,@ShippedDate,@CustomerID)";
            try
            {
                sql.Open();
                using (SqlCommand cmd = new SqlCommand(query,sql))
                {
                    //Generating number and get current date
                    int number = 1;
                    number += 1;
                    DateTime orderDate = DateTime.Today;
                    //Calcula`ting summary price
                    int price = Int32.Parse(KmPriceBox.Text) * Int32.Parse(DistanceBox.Text);
                    //Inserting into database
                    cmd.Parameters.AddWithValue("@OrderID", number);
                    cmd.Parameters.AddWithValue("@OrderDate", orderDate);
                    cmd.Parameters.AddWithValue("@RequiredDate", RequiredDateBox.Text);
                    cmd.Parameters.AddWithValue("@Destination", DestinationBox.Text);
                    cmd.Parameters.AddWithValue("@ShippedFrom", ShippedFromBox.Text);
                    cmd.Parameters.AddWithValue("@ShippedDate",ShippedDateBox.Text);
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerIDBox.Text);
                    cmd.Parameters.AddWithValue("@Freight", FreighBox.Text);
                    cmd.Parameters.AddWithValue("@KmPrice", KmPriceBox.Text);
                    cmd.Parameters.AddWithValue("@Distance", DistanceBox.Text);
                    PriceBox.Text= price.ToString();
                    cmd.Parameters.AddWithValue("@Price",price);    
                    cmd.ExecuteNonQuery();
                    //Close connection with database after inserting Order
                    sql.Close();
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
                sql.Close();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddOrder();
        }
        private void Back()
        {
            CustomerIDBox.Visibility = Visibility.Hidden;
            CustomersGrid.Visibility = Visibility.Hidden;
            DistanceBox.Visibility = Visibility.Hidden;
            OrderDateBox.Visibility = Visibility.Hidden;
            RequiredDateBox.Visibility = Visibility.Hidden;
            PriceBox.Visibility = Visibility.Hidden;
            ShippedDateBox.Visibility = Visibility.Hidden;
            ShippedFromBox.Visibility = Visibility.Hidden;
            KmPriceBox.Visibility = Visibility.Hidden;
            FreighBox.Visibility = Visibility.Hidden;
            DestinationBox.Visibility = Visibility.Hidden;
            CustomerIDBox.Visibility = Visibility.Hidden;
            AddOrderBtn.Visibility = Visibility.Hidden;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}
