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
    /// Interaction logic for UserGridControl.xaml
    /// </summary>
    public partial class UserGridControl : UserControl
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        public UserGridControl()
        {
            InitializeComponent();
        }
        private void Add()
        {
            SqlConnection sql = new SqlConnection(sqlConString);
            using (SqlCommand addUserCmd = new SqlCommand())
            {
                addUserCmd.Connection = sql;
                addUserCmd.CommandType = System.Data.CommandType.Text;
                addUserCmd.CommandText = "INSERT INTO OfficeEmployee(EmployeeID,UserName, Password) VALUES(@EmployeeID,@UserName, @Password)";
                addUserCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID.Text);
                addUserCmd.Parameters.AddWithValue("@UserName", EmployeeUserName.Text);
                addUserCmd.Parameters.AddWithValue("@Password", EmployeePassword.Text);
                try
                {
                    sql.Open();
                    int recordsAffected = addUserCmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Cannot connect to database");
                }
            }
            UserProperties.Visibility = Visibility.Hidden;
        }
        private void addUserBtn(object sender, RoutedEventArgs e)
        {
            Add();
        }
        private void BackBtn(object sender, RoutedEventArgs e)
        {
            UserProperties.Visibility = Visibility.Hidden;
        }
    }
}
