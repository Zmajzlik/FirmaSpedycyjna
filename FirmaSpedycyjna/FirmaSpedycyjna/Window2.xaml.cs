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

namespace FirmaSpedycyjna
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        public Window2()
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri(@"C:\Users\Artur\Desktop\FirmaSpedycyjna\bg.png", UriKind.Absolute));
            this.Background = myBrush;
            InitializeComponent();

        }
        private void ordersBtn(object sender, RoutedEventArgs e)
        {
            ShowOrdersControl showOrd = new ShowOrdersControl();
            GridForShowingOrders.Children.Add(showOrd);
        }
        private void customersBtn(object sender, RoutedEventArgs e)
        {
            UserControl1 showCust = new UserControl1();
            GridForShowingCustomers.Children.Add(showCust);
        }
        private void trailersBtn(object sender, RoutedEventArgs e)
        {
            ShowTrailersCtrl trailer = new ShowTrailersCtrl();
            GridForShowingTrailers.Children.Add(trailer);
        }
        private void trucksBtn(object sender, RoutedEventArgs e)
        {
            ShowTruckControl shTr = new ShowTruckControl();
            GridForShowingTrucks.Children.Add(shTr);
        }
        private void addUsr(object sender, RoutedEventArgs e)
        {
            UserGridControl ucAdd = new UserGridControl();
            GridForAdding.Children.Add(ucAdd);
        }
        private void driverBtn(object sender, RoutedEventArgs e)
        {
            ShowDriversCtrl drvShow = new ShowDriversCtrl();
            GridForShowingDrivers.Children.Add(drvShow); 
        }
    }
}
