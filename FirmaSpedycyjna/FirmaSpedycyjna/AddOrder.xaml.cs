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
using System.Data;

namespace FirmaSpedycyjna
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : UserControl
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        public AddOrder()
        {
            InitializeComponent();
            GetID();
        }
        private void GetID()
        {
            try
            {
                string sqlQuery = "SELECT TOP 1 OrderID from Orders order by OrderID desc";
                SqlConnection sql = new SqlConnection(sqlConString);
                sql.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, sql);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string input = dr["OrderID"].ToString();
                    string angka = input.Substring(input.Length - Math.Min(3, input.Length));
                    int number = Convert.ToInt32(angka);
                    number += 1;
                    string str = number.ToString("D3");
                    IDBox.Text = str;
                }
                dr.Close();
                string sqlQuery2 = "SELECT TOP 1 OrderDetailsID from OrderDetails order by OrderDetailsID desc";
                SqlCommand cmd2 = new SqlCommand(sqlQuery2, sql);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    string input = dr2["OrderDetailsID"].ToString();
                    string angka2 = input.Substring(input.Length - Math.Min(3, input.Length));
                    int number2 = Convert.ToInt32(angka2);
                    number2 += 1;
                    string str2 = number2.ToString("D4");
                    IDBox2.Text = str2;
                }
                dr2.Close();
                string sqlQuery3 = "select CONCAT('(', Customers.CustomerID, ')', ' ', CompanyName, ' - ', Country) as Company, CompanyName as [Company Name], convert(varchar(10), OrderDate) as [Order Date], Freight,Price,Distance from Customers join Orders on Customers.CustomerID = Orders.CustomerID join OrderDetails on Orders.OrderID = OrderDetails.OrderID";
                SqlCommand cmd3 = new SqlCommand(sqlQuery3, sql);
                cmd3.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd3);
                sdr.Fill(dt);
                foreach (DataRow dr3 in dt.Rows)
                {
                    Customer.Items.Add(dr3["Company"].ToString());
                }
                Customer.SelectionChanged += (o, a) =>
                {
                    var selectedCustomer = new
                    {
                        CompanyName = dt.Rows[Customer.SelectedIndex][1].ToString(),
                    };
                };
                string sqlQuery4 = "select CONCAT(TypeName,' ', 'Load: ',Payload) as Type, TrailerType.TypeID, TrailerID from TrailerType join Trailers on Trailers.TypeID=TrailerType.TypeID";
                SqlCommand cmd4 = new SqlCommand(sqlQuery4, sql);
                cmd4.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter sdr2 = new SqlDataAdapter(cmd4);
                sdr2.Fill(dt2);
                foreach (DataRow dr4 in dt2.Rows)
                {
                    Trailer.Items.Add(dr4["Type"].ToString());
                }
                Trailer.SelectionChanged += (o, a) =>
                {
                    var selectedTrailer = new
                    {
                        TrailerType = dt2.Rows[Trailer.SelectedIndex][1].ToString(),
                    };  
                };
                string sqlQuery5 = "SELECT TOP 1 OrderID from OrdersDetails order by OrderID desc";
                SqlCommand cmd5 = new SqlCommand(sqlQuery5, sql);
                SqlDataReader dr5= cmd.ExecuteReader();
                while (dr5.Read())
                {
                    string input = dr5["OrderID"].ToString();
                    string angka = input.Substring(input.Length - Math.Min(3, input.Length));
                    int number = Convert.ToInt32(angka);
                    number += 1;
                    string str5 = number.ToString("D3");
                    IDBox3.Text = str5;
                }
                int CustomerID;
                using (SqlCommand command = new SqlCommand("SELECT Customers.CustomerID from Customers WHERE CompanyName = @Company"))
                {
                    var DataSet = new DataSet();
                    command.Parameters.AddWithValue("@Company", Customer.SelectedItem);
                    command.ExecuteNonQuery();
                    var dataAdapter = new SqlDataAdapter { SelectCommand = command };
                    dataAdapter.Fill(DataSet);
                    CustomerID = Convert.ToInt32(DataSet.Tables[0].Rows[0]["CustomerID"]);
                }
                CustomerIDBox.Text = CustomerID.ToString();
                int TrailerID;
                using (SqlCommand command2 = new SqlCommand("SELECT TrailerID from Trailers where TrailerID = @TrailerID "))
                {
                    var DataSet = new DataSet();
                    command2.Parameters.AddWithValue("@TrailerID", Trailer.SelectedItem);
                    command2.ExecuteNonQuery();
                    var dataAdap = new SqlDataAdapter { SelectCommand = command2 };
                    dataAdap.Fill(DataSet);
                    TrailerID = Convert.ToInt32(DataSet.Tables[0].Rows[0]["TrailerID"]);
                }
                TrailerIDBox.Text = TrailerID.ToString();
                sql.Close();
            }
            catch
            {
            }
        }
        void GetDestination()
        {
            string address = AddrTxt.ToString();
            string city = CityTxt.ToString();
            string country = CountTxt.ToString();
            string destination = address + ',' + city + ',' + country;
            string startAddress = AddrTxtStart.ToString();
            string startCity = CityTxtStart.ToString();
            string startCountry = CountTxtStart.ToString();
            string startPlace = startAddress + ',' + startCity + ',' + startCountry;
            DistBox.Text = destination;
            StartPlaceBox.Text = startPlace;

            DateTime? nullDate = null;
            string date = nullDate.ToString();
            ShippedDateBox.Text = date;

            var per1km = (float)Convert.ToDecimal(PerKmTxt.Text);
            var distance = (float)Convert.ToDecimal(DistTxt.Text);
            double price = per1km * distance;
            TotalPriceTxt.Text = price.ToString();
        }
        private void AddNewOrder()
        {
            GetDestination();
            SqlConnection sql = new SqlConnection(sqlConString);
            sql.Open();
            try {
                
                string addToOrder = "INSERT INTO Orders(OrderID, OrderDate, RequiredDate, Destination, ShippedFrom, ShippedDate, CustomerID) VALUES(@OrderID, @OrderDate, @RequiredDate, @Destination, @ShippedFrom, @ShippedDate, @CustomerID)";
                string addToOrderDetails = "INSERT INTO OrderDetails(OrderDetailsID,Price, Distance, KmPrice, OrderID, Freight, TrailerID) VALUES (@OrderDetailsID,@Price, @Distance, @KmPrice, @OrderID, @Freight, @TrailerID)";
                SqlCommand addToOrders = sql.CreateCommand();
                SqlCommand addToDetails = sql.CreateCommand();
                addToOrders.CommandType = System.Data.CommandType.Text;
                addToDetails.CommandType = System.Data.CommandType.Text;
                addToOrders.CommandText = addToOrder;
                addToDetails.CommandText = addToOrderDetails;
                //Adding to Orders
                addToOrders.Parameters.AddWithValue("@OrderID", IDBox.Text);
                addToOrders.Parameters.AddWithValue("@OrderDate", OrderDate.SelectedDate);
                addToOrders.Parameters.AddWithValue("@RequiredDate", RequiredDate.SelectedDate);
                addToOrders.Parameters.AddWithValue("@Destination", DistBox.Text);
                addToOrders.Parameters.AddWithValue("@ShippedFrom", StartPlaceBox.Text);
                addToOrders.Parameters.AddWithValue("@ShippedDate", ShippedDateBox.Text);
                addToOrders.Parameters.AddWithValue("@CustomerID", CustomerIDBox.Text);
                //Adding to Order Details
                addToDetails.Parameters.AddWithValue("@OrderDetailsID", IDBox2.Text);
                addToDetails.Parameters.AddWithValue("@Distance", DistTxt.Text);
                addToDetails.Parameters.AddWithValue("@KmPrice", PerKmTxt.Text);
                addToDetails.Parameters.AddWithValue("@Price", TotalPriceTxt.Text);
                addToDetails.Parameters.AddWithValue("@OrderID", IDBox3.Text);
                addToDetails.Parameters.AddWithValue("@Freight", FreightTxt.Text);
                addToDetails.Parameters.AddWithValue("@TrailerID", TrailerIDBox.Text);
                //Execute
                addToOrders.ExecuteNonQuery();
                addToDetails.ExecuteNonQuery();
            }      
            catch { }  
        }
        private void BtnAdd(object sender, RoutedEventArgs e)
        {
            AddNewOrder();
        }
        private void Back()
        {
            IDBox2.Visibility = Visibility.Hidden;
            DistTxt.Visibility = Visibility.Hidden;
            PerKmTxt.Visibility = Visibility.Hidden;
            TotalPriceTxt.Visibility = Visibility.Hidden;
            IDBox3.Visibility = Visibility.Hidden;
            TrailerIDBox.Visibility = Visibility.Hidden;
            FreightTxt.Visibility = Visibility.Hidden;
            IDBox.Visibility = Visibility.Hidden;
            OrderDate.Visibility = Visibility.Hidden;
            RequiredDate.Visibility = Visibility.Hidden;
            DistBox.Visibility = Visibility.Hidden;
            StartPlaceBox.Visibility = Visibility.Hidden;
            CustomerIDBox.Visibility = Visibility.Hidden;
            ShippedDateBox.Visibility = Visibility.Hidden;
            DestinationTxt.Visibility = Visibility.Hidden;
            AddressTxt.Visibility = Visibility.Hidden;
            CityTxtIn.Visibility = Visibility.Hidden;
            CountryTxt.Visibility = Visibility.Hidden;
            DestinationTxt_Copy.Visibility = Visibility.Hidden;
            OrderDateTxt.Visibility = Visibility.Hidden;
            RequiredDateTxt.Visibility = Visibility.Hidden;
            DistanceTxt.Visibility = Visibility.Hidden;
            PricPerKmTxt.Visibility = Visibility.Hidden;
            FreightTxt.Visibility = Visibility.Hidden;
            Customer.Visibility = Visibility.Hidden;
            Trailer.Visibility = Visibility.Hidden;
            TrailerTxt.Visibility = Visibility.Hidden;
            CustTxt.Visibility = Visibility.Hidden;
            FreightText.Visibility = Visibility.Hidden;
            AddrTxt.Visibility = Visibility.Hidden;
            AddrTxtStart.Visibility = Visibility.Hidden;
            CityTxt.Visibility = Visibility.Hidden;
            CityTxtStart.Visibility = Visibility.Hidden;
            CountTxt.Visibility = Visibility.Hidden;
            CountTxtStart.Visibility = Visibility.Hidden;
            AddBtn.Visibility = Visibility.Hidden;
            BackBtn.Visibility = Visibility.Hidden;

        }
        private void BtnBack(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}
