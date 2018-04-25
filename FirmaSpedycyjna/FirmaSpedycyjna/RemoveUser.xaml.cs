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
    /// Logika interakcji dla klasy RemoveUser.xaml
    /// </summary>
    public partial class RemoveUser : UserControl
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";

        public string SqlConString { get => sqlConString; set => sqlConString = value; }

        public RemoveUser()
        {
            InitializeComponent();
            FillCombo();
        }

        private void FillCombo()
        {
            DriverTxt.Visibility = Visibility.Hidden;
            SqlConnection sql = new SqlConnection(SqlConString);
            sql.Open();
            SqlCommand cmd = sql.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "SELECT CONCAT('(',DriverID,')',' ',FirstName,' ',LastName) as Person from Drivers " +
               // "join Employees on Drivers.EmployeeID=Employees.EmployeeID";
            cmd.CommandText = "SELECT CONCAT('(',Employees.EmployeeID,')',' ',FirstName,' ',LastName) as Driver, BirthDate, HireDate from Drivers join Employees on Drivers.EmployeeID=Employees.EmployeeID";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DriverBox.Items.Add(dr["Driver"].ToString());
            }
            DriverBox.SelectionChanged += (o, a) =>
            {
                DriverTxt.Text = DriverBox.SelectedItem.ToString();

                var test=dt.Rows[DriverBox.SelectedIndex].ItemArray.Aggregate((x,y)=>$"{x.ToString()} {y.ToString()}").ToString();

                var selectedPerson = new
                {
                    FullName= dt.Rows[DriverBox.SelectedIndex][0].ToString(),
                    BirthDate= dt.Rows[DriverBox.SelectedIndex][1].ToString(),
                    HireDate = dt.Rows[DriverBox.SelectedIndex][2].ToString()
                };
                DataGrid.ItemsSource = new[] {selectedPerson};

                DriverTxt.Text = test;
            };
        }
        private void Back()
        {
            BackButton.Visibility = Visibility.Hidden;
            RemoveButton.Visibility = Visibility.Hidden;
            DriverTxt.Visibility = Visibility.Hidden;
            DriverBox.Visibility = Visibility.Hidden;
            DataGrid.Visibility = Visibility.Hidden;
        }
        private void RemovedUser()
        {
            string item = DriverBox.SelectedItem.ToString();
        }
        private void BtnRemove(object sender, RoutedEventArgs e)
        {
            RemovedUser();
        }
        private void BtnBack(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }

}
