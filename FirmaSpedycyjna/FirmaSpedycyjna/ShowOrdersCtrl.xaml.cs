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
            string showcust = "SELECT CONCAT('(',Customers.CustomerID,')',' ',CompanyName) as Customer,Freight, Price, OrderDate, ShippedDate, ShippedFrom,Destination from Customers join Orders on Orders.CustomerID=Customers.CustomerID join OrderDetails on OrderDetails.OrderID=Orders.OrderID";
            try
            {
                sql.Open();
                using (SqlCommand showing = new SqlCommand())
                {
                    SqlCommand show = new SqlCommand(showcust, sql);
                    SqlDataAdapter sdr = new SqlDataAdapter(show);
                    DataTable dt = new DataTable();
                    sdr.Fill(dt);
                    DataGridForOrders.ItemsSource = dt.DefaultView;
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
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            RmvOrderBtn.Visibility = Visibility.Hidden;
            AddOrderBtn.Visibility = Visibility.Hidden;
            BackBtn.Visibility = Visibility.Hidden;
            DataGridForOrders.Visibility = Visibility.Hidden;
            AddOrder newOrder = new AddOrder();
            AddNewOrder.Children.Add(newOrder);
        }
        private void Back()
        {
            RmvOrderBtn.Visibility = Visibility.Hidden;
            AddOrderBtn.Visibility = Visibility.Hidden;
            BackBtn.Visibility = Visibility.Hidden;
            DataGridForOrders.Visibility = Visibility.Hidden;
        }
        private void RmvBtn_Click(object sender, RoutedEventArgs e)
        { }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}
