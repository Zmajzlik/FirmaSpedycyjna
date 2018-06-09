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
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using MahApps.Metro.Controls;

namespace FirmaSpedycyjna
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : MetroWindow
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        public Window2()
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri(@"C:\Users\Artur\Desktop\FirmaSpedycyjna\FirmaSpedycyjna\bg.png", UriKind.Absolute));
            this.Background = myBrush;
            InitializeComponent();

        }
        private void Invoices()
        {
            GridForAdding.Visibility = Visibility.Hidden;
            GridForShowingCustomers.Visibility = Visibility.Hidden;
            GridForShowingDrivers.Visibility = Visibility.Hidden;
            GridForShowingOrders.Visibility = Visibility.Hidden;
            GridForShowingTrailers.Visibility = Visibility.Hidden;
            GridForShowingTrucks.Visibility = Visibility.Hidden;
            ShowInvoicesCtrl invShow = new ShowInvoicesCtrl();
            GridForShowingInvoices.Children.Add(invShow);
            GridForShowingInvoices.Visibility = Visibility.Visible;
        }
        private void Orders()
        {
            GridForAdding.Visibility = Visibility.Hidden;
            GridForShowingCustomers.Visibility = Visibility.Hidden;
            GridForShowingDrivers.Visibility = Visibility.Hidden;
            GridForShowingInvoices.Visibility = Visibility.Hidden;
            GridForShowingTrailers.Visibility = Visibility.Hidden;
            GridForShowingTrucks.Visibility = Visibility.Hidden;
            GridForShowingDrivers.Visibility = Visibility.Hidden;
            GridForShowingOrders.Visibility = Visibility.Visible;
            ShowOrdersCtrl showOrd = new ShowOrdersCtrl();
            GridForShowingOrders.Children.Add(showOrd);
            
        }
        private void Customers()
        {
            GridForAdding.Visibility = Visibility.Hidden;
            GridForShowingDrivers.Visibility = Visibility.Hidden;
            GridForShowingInvoices.Visibility = Visibility.Hidden;
            GridForShowingOrders.Visibility = Visibility.Hidden;
            GridForShowingTrailers.Visibility = Visibility.Hidden;
            GridForShowingTrucks.Visibility = Visibility.Hidden;
            UserControl1 showCust = new UserControl1();
            GridForShowingCustomers.Children.Add(showCust);
            GridForShowingCustomers.Visibility= Visibility.Visible; 
        }
        private void Trailers()
        {
            GridForAdding.Visibility = Visibility.Hidden;
            GridForShowingCustomers.Visibility = Visibility.Hidden;
            GridForShowingDrivers.Visibility = Visibility.Hidden;
            GridForShowingInvoices.Visibility = Visibility.Hidden;
            GridForShowingOrders.Visibility = Visibility.Hidden;
            GridForShowingTrucks.Visibility = Visibility.Hidden;
            ShowTrailersCtrl trailer = new ShowTrailersCtrl();
            GridForShowingTrailers.Children.Add(trailer);
            GridForShowingTrailers.Visibility= Visibility.Visible;
        }
        private void Trucks()
        {
            GridForAdding.Visibility = Visibility.Hidden;
            GridForShowingCustomers.Visibility = Visibility.Hidden;
            GridForShowingDrivers.Visibility = Visibility.Hidden;
            GridForShowingInvoices.Visibility = Visibility.Hidden;
            GridForShowingOrders.Visibility = Visibility.Hidden;
            GridForShowingTrailers.Visibility = Visibility.Hidden;
            ShowTruckControl shTr = new ShowTruckControl();
            GridForShowingTrucks.Children.Add(shTr);
            GridForShowingTrucks.Visibility= Visibility.Visible; 

        }
        private void AddUser()
        {
            GridForAdding.Visibility = Visibility.Visible;
            GridForShowingCustomers.Visibility = Visibility.Hidden;
            GridForShowingDrivers.Visibility = Visibility.Hidden;
            GridForShowingInvoices.Visibility = Visibility.Hidden;
            GridForShowingOrders.Visibility = Visibility.Hidden;
            GridForShowingTrailers.Visibility = Visibility.Hidden;
            GridForShowingTrucks.Visibility = Visibility.Hidden;
            UserGridControl ucAdd = new UserGridControl();
            GridForAdding.Children.Add(ucAdd);
        }
        private void Drivers()
        {
            GridForAdding.Visibility = Visibility.Hidden;
            GridForShowingCustomers.Visibility = Visibility.Hidden;
            GridForShowingInvoices.Visibility = Visibility.Hidden;
            GridForShowingOrders.Visibility = Visibility.Hidden;
            GridForShowingTrailers.Visibility = Visibility.Hidden;
            GridForShowingTrucks.Visibility = Visibility.Hidden;
            GridForShowingDrivers.Visibility = Visibility.Visible;
            ShowDriversCtrl drvShow = new ShowDriversCtrl();
            GridForShowingDrivers.Children.Add(drvShow);
        }
        private void ordersBtn(object sender, RoutedEventArgs e)
        {
            Orders();
        }
        private void customersBtn(object sender, RoutedEventArgs e)
        {
            Customers();
        }
        private void trailersBtn(object sender, RoutedEventArgs e)
        {
            Trailers();
        }
        private void trucksBtn(object sender, RoutedEventArgs e)
        {
            Trucks();
        }
        private void addUsr(object sender, RoutedEventArgs e)
        {
            AddUser();
        }
        private void driverBtn(object sender, RoutedEventArgs e)
        {
            Drivers();
        }
        private void InvoicesBtn(object sender, RoutedEventArgs e)
        {
            Invoices();
        }
        private void RefreshBtn(object sender, RoutedEventArgs e)
        {
            GridForAdding.Visibility = Visibility.Hidden;
            GridForShowingCustomers.Visibility = Visibility.Hidden;
            GridForShowingDrivers.Visibility = Visibility.Hidden;
            GridForShowingInvoices.Visibility = Visibility.Hidden;
            GridForShowingOrders.Visibility = Visibility.Hidden;
            GridForShowingTrailers.Visibility = Visibility.Hidden;
            GridForShowingTrucks.Visibility = Visibility.Hidden;
        }
    }
}
