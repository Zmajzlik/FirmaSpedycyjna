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
using MahApps.Metro.Controls;

namespace FirmaSpedycyjna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";

        public MainWindow()
        {
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri(@"C:\Users\Artur\Desktop\FirmaSpedycyjna\FirmaSpedycyjna\bg.png", UriKind.Absolute));
            this.Background = myBrush;
        }
        private void CloseAllWindows()
        {
            App.Current.MainWindow.Close();
        }
        private void Login()
        {

            SqlConnection sql = new SqlConnection(sqlConString);
            using (SqlCommand loginCmd = new SqlCommand())
            {
                loginCmd.Connection = sql;
                sql.Open();
                loginCmd.CommandType = System.Data.CommandType.Text;
                loginCmd.CommandText = "SELECT UserName, UserPassword from OfficeEmployees where UserName = @UserName AND UserPassword = @UserPassword";
                loginCmd.Parameters.AddWithValue("@UserName", Login_Box.Text);
                loginCmd.Parameters.AddWithValue("@UserPassword", PasswordBox.Password);
                loginCmd.ExecuteNonQuery();
                SqlDataReader dr = loginCmd.ExecuteReader();

                int count = 0;
                while (dr.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    Window2 okienko = new Window2();
                    CloseAllWindows();
                    okienko.Show();
                }
                if (count > 1 && count < 1)
                {
                    MessageBox.Show("Wrong username or password.");
                }
            }
        }
        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            Login();
        }  
    }
}

