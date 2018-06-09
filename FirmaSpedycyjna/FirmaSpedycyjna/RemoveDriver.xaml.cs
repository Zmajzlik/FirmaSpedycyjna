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
    /// Logika interakcji dla klasy RemoveDriver.xaml
    /// </summary>
    public partial class RemoveDriver : UserControl
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        public RemoveDriver()
        {
            InitializeComponent();
            FillData();
        }
        private void FillData()
        {
            SqlConnection sql = new SqlConnection(sqlConString);
            try
            {
                sql.Open();
                using (SqlCommand query = new SqlCommand())
                {
                    string task = "select CONCAT('(',Employees.EmployeeID,') ',FirstName,' ', LastName) as Driver, BirthDate , HireDate, Truck, LicensePlate from Drivers join Employees on Drivers.EmployeeID=Employees.EmployeeID join Trucks on Trucks.DriverID=Drivers.DriverID";
                    SqlCommand push = new SqlCommand(task, sql);
                    push.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sdr = new SqlDataAdapter(push);
                    sdr.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        DriverBox.Items.Add(dr["Driver"].ToString());
                    }
                    DriverBox.SelectionChanged += (o, a) =>
                     {
                         var selectedDriver = new
                         {
                             Driver = dt.Rows[DriverBox.SelectedIndex][1].ToString(),
                             BirthDate = dt.Rows[DriverBox.SelectedIndex][2].ToString(),
                             HireDate = dt.Rows[DriverBox.SelectedIndex][3].ToString(),
                             Truck = dt.Rows[DriverBox.SelectedIndex][4].ToString(),
                             LicensePlate = dt.Rows[DriverBox.SelectedIndex][5].ToString(),
                         };
                         DriversInfo.ItemsSource = new[] { selectedDriver };
                     };
                }
                sql.Close();
            }
            catch
            {
                
            }
        }
        private void Remove()
        {
            var selectedDriv = DriversInfo.SelectedItem;
            if (selectedDriv != null)
            {
                DriversInfo.Items.Remove(selectedDriv);
                DriversInfo.Items.Refresh();
            }
        }
        private void BtnRemove(object sender, RoutedEventArgs e)
        {
            Remove();
        }
    }
}
