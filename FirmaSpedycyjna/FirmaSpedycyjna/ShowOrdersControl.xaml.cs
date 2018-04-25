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
using GoogleMaps.LocationServices;
using System.Device.Location;



namespace FirmaSpedycyjna
{
    /// <summary>
    /// Logika interakcji dla klasy ShowOrdersControl.xaml
    /// </summary>
    public partial class ShowOrdersControl : UserControl
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        public ShowOrdersControl()
        {
            InitializeComponent();
            Connect();
            FillData();  
        }
        private void FillData()
        {
        }
        private void Connect()
        {
            SqlConnection sql = new SqlConnection(sqlConString);
            sql.Open();
        }
        private void GetDistance()
        {
            var ShipToAddress = "SELECT ShipAddress, ShipCity, ShipCountry from Orders";
            var ShipFromAddress = "SELECT ShippedFrom from [Order Details]";
            var locationServicesA = new GoogleLocationService();
            var locationServicesB = new GoogleLocationService();
            string pointA = ShipToAddress;
            string pointB = ShipFromAddress;
            System.Device.Location.GeoCoordinate gc = new System.Device.Location.GeoCoordinate()
            {
            };
            System.Device.Location.GeoCoordinate gc2 = new System.Device.Location.GeoCoordinate()
            {
            };
            double distance = gc2.GetDistanceTo(gc);
        }
        private void Back()
        {
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowOrdersCtrl addOrder = new ShowOrdersCtrl();
            Grid.Children.Add(addOrder);
        }
    }
}
