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
    /// Logika interakcji dla klasy ShowTrailersCtrl.xaml
    /// </summary>
    
    public partial class ShowTrailersCtrl : UserControl
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        public ShowTrailersCtrl()
        {   
            InitializeComponent();
            FillCombo();
        }
        private void Back()
        {
            TrailerBox.Visibility = Visibility.Hidden;
            TrailerBoxTxt.Visibility = Visibility.Hidden;
            BackBtn.Visibility = Visibility.Hidden;
        }
       private void FillCombo()
        {
            string getTrailer = "select CONCAT('(',TrailerID,')', ' ',TypeName,' ') as Trailer, Payload from TrailerType join Trailers on Trailers.TypeID = TrailerType.TypeID";
            SqlConnection sql = new SqlConnection(sqlConString);
            sql.Open();
            SqlCommand cmd = sql.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT CONCAT('(',TypeID,')',' ', TypeName) as Trailer from TrailerType";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                TrailerBox.Items.Add(dr["Trailer"].ToString());
            }
        }
        private void BtnBackClick(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}
