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
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        public UserControl1()
        {
            InitializeComponent();
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            CustomersGrid.Visibility = Visibility.Hidden;
            try
            {
                CustomersGrid.Visibility = Visibility.Visible;
                SqlConnection sql = new SqlConnection(sqlConString);
                sql.Open();
                string query = "SELECT * from Customers";
                SqlCommand show = sql.CreateCommand();
                show.CommandType = System.Data.CommandType.Text;
                show.CommandText = query;
                show.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(show);
                da.Fill(dt);
                CustomersGrid.ItemsSource = dt.DefaultView;
            }
            catch
            {

            }
        }
        private void Back()
        {
            RmvCustomer.Visibility = Visibility.Hidden;
            AddCustomer.Visibility = Visibility.Hidden;
            CustomersGrid.Visibility = Visibility.Hidden;
            BackButton.Visibility = Visibility.Hidden;
            
        }
        private void BckBtn(object sender, RoutedEventArgs e)
        {
            Back();   
        }
        private void RmvCust(object sender, RoutedEventArgs e)
        {

        }
        private void AddCust(object sender, RoutedEventArgs e)
        {
            Back();
            AddCustomersCtrl newCustomer = new AddCustomersCtrl();
            AddCustomers.Children.Add(newCustomer);
        }
    }   
}
