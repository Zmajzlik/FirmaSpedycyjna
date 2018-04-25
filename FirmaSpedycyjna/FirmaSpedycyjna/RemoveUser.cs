using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FirmaSpedycyjna
{
    class RemoveUser
    {
        string sqlConString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=spedycjaath;User ID=spedycjaath;Password=Qd6QQ~!3f4iN";
        void FillIdCombo()
        {
            SqlConnection sql = new SqlConnection(sqlConString);
            try
            {
                sql.Open();
                string Query = "SELECT * from Drivers";
                string RemQuery = "SELECT DriverID, EmployeeID from Drivers join Employees on Employees.EmployeeID=Drivers.EmployeeID";
                SqlCommand showID = new SqlCommand(Query, sql);

            }
            catch
            {

            }
        }
    }
}
