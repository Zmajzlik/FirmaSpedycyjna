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
    /// Logika interakcji dla klasy ShowInvoicesCtrl.xaml
    /// </summary>
    public partial class ShowInvoicesCtrl : UserControl
    {
         string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";

        public ShowInvoicesCtrl()
        {
            InitializeComponent();
            FillComboBox();
        }
        private void FillComboBox()
        {
            CustomerInvoicesGrid.Visibility = Visibility.Hidden;
            SqlConnection sql = new SqlConnection(sqlConString);
            try
            {
                CustomerInvoicesGrid.Visibility = Visibility.Visible;
                sql.Open();
                using (SqlCommand query = new SqlCommand())
                {
                    string task = "select CONCAT('(',Customers.CustomerID,')',' ',CompanyName, ' - ',Country) as Company, CompanyName as [Company Name], OrderDate, Freight,Price,Distance from Customers join Orders on Customers.CustomerID=Orders.CustomerID join OrderDetails on Orders.OrderID=OrderDetails.OrderID";
                    SqlCommand push = new SqlCommand(task, sql);
                    push.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sdr = new SqlDataAdapter(push);
                    sdr.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        CustomerBox.Items.Add(dr["Company"].ToString());
                    }
                    CustomerBox.SelectionChanged += (o, a) =>
                    {
                        var selectedCustomer = new
                        {
                            CompanyName = dt.Rows[CustomerBox.SelectedIndex][1].ToString(),
                            InvoiceDate = dt.Rows[CustomerBox.SelectedIndex][2].ToString(),
                            Freight = dt.Rows[CustomerBox.SelectedIndex][3].ToString(),
                            InvoiceValue = dt.Rows[CustomerBox.SelectedIndex][4].ToString(),
                            Distance = dt.Rows[CustomerBox.SelectedIndex][5].ToString(),

                        };
                        CustomerInvoicesGrid.ItemsSource = new[] { selectedCustomer };

                    };
                }
                sql.Close();
                    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                sql.Close();
            }
        }
        private void Back()
        {
            CustomerInvoicesGrid.Visibility = Visibility.Hidden;
            CustomerBox.Visibility = Visibility.Hidden;
        }

        private void BackBtn(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}
