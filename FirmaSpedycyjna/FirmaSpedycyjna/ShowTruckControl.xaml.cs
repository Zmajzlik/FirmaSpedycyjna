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
    /// Logika interakcji dla klasy ShowTruckControl.xaml
    /// </summary>
    public partial class ShowTruckControl : UserControl
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        public ShowTruckControl()
        {
            InitializeComponent();
            FillDataGrid(); 
        }
        private void FillDataGrid()
        {
            SqlConnection sql = new SqlConnection(sqlConString);
            sql.Open();
            string showTrucks = "select Trucks.Truck, LicensePlate, CONCAT(FirstName, ' ', LastName) as Driver from Trucks join Drivers on Trucks.DriverID = Drivers.DriverID join Employees on Drivers.EmployeeID = Employees.EmployeeID";
            using (SqlCommand showT = new SqlCommand())
            {
                SqlCommand show = new SqlCommand(showTrucks, sql);
                SqlDataAdapter da = new SqlDataAdapter(show);
                DataTable dt = new DataTable();
                da.Fill(dt);
                TruckGrid.ItemsSource = dt.DefaultView;
            }
            
        }
        private void Back()
        {
            
            TrucksGrid.Visibility = Visibility.Hidden;
        }
        private void BckBtnClick(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}
