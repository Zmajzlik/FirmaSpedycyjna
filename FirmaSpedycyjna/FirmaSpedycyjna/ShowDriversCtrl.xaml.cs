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
    /// Interaction logic for ShowDriversCtrl.xaml
    /// </summary>
    public partial class ShowDriversCtrl : UserControl
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        public ShowDriversCtrl()
        {
            InitializeComponent();
            GridDrivers.Visibility = Visibility.Visible;
            FillData();
            RemoveButton.Visibility = Visibility.Hidden;
        }

        private void BtnBack(object sender, RoutedEventArgs e)
        {
            GridDrivers.Visibility = Visibility.Hidden;
            GridForRemoving.Visibility = Visibility.Hidden;
            GridForAdding.Visibility = Visibility.Hidden; 
        }
        private void FillData()
        {
            GridForAdding.Visibility = Visibility.Hidden;
            string showByName = "SELECT Drivers.DriverID,FirstName,LastName,convert(varchar(10),BirthDate) as BirthDate,Truck,ADR,Busy from Employees" +
                " join Drivers on Employees.EmployeeID=Drivers.EmployeeID" +
                " join Trucks on Trucks.DriverID=Drivers.DriverID";
            SqlConnection sql = new SqlConnection(sqlConString);
            sql.Open();
            using (SqlCommand showing = new SqlCommand())
            {
                SqlCommand show = new SqlCommand(showByName, sql);
                SqlDataAdapter sdr = new SqlDataAdapter(show);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                drvGrd.ItemsSource = dt.DefaultView;
            }
        }
        private void BtnAdd(object sender, RoutedEventArgs e) 
        {
            AddButton.Visibility = Visibility.Hidden;
            drvGrd.Visibility = Visibility.Hidden;
            RemoveButton.Visibility = Visibility.Hidden;
            ButtonBack.Visibility = Visibility.Hidden;
            AddDriversCtrl drvAdd = new AddDriversCtrl();
            GridForAdding.Children.Add(drvAdd);
            GridForAdding.Visibility = Visibility.Visible;
        }
        private void BtnRemove(object sender, RoutedEventArgs e)
        {
            AddButton.Visibility = Visibility.Hidden;
            drvGrd.Visibility = Visibility.Hidden;
            GridForAdding.Visibility = Visibility.Hidden;
            RemoveButton.Visibility = Visibility.Hidden;
            ButtonBack.Visibility = Visibility.Hidden;
            RemoveDriver rmvDrv = new RemoveDriver();
            GridForRemoving.Children.Add(rmvDrv);
        }
    }
}
