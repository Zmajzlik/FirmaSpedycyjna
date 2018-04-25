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
        }
        private void AddOrder()
        {
            SqlConnection sql = new SqlConnection(sqlConString);
            using (SqlCommand addOrder = new SqlCommand())
            {
                addOrder.Connection = sql;
                addOrder.CommandType = System.Data.CommandType.Text;
                addOrder.CommandText= "INSERT Orders.OrderID, @OrderDate, @RequiredDate, @ShippedDate, @FreightType, @FreightWeight, @ShipAddress, ShipCity, ShipCountry, ShippedFrom, Price from Orders join [Order Details] on orders.orderid =[order details].orderid"
                addOrder.Parameters.AddWithValue(@OrderDate,OrderDateBox.Text);
            }
        }
    }
}
/*
String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

    using(SqlCommand command = new SqlCommand(query, connection))
    {
        command.Parameters.AddWithValue("@id", "abc");
        command.Parameters.AddWithValue("@username", "abc");
        command.Parameters.AddWithValue("@password", "abc");
        command.Parameters.AddWithValue("@email", "abc");

        connection.Open();
        int result = command.ExecuteNonQuery();

        // Check Error
        if(result < 0)
            Console.WriteLine("Error inserting data into Database!");
    }
*/