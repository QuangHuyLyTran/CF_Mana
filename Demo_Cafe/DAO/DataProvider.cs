using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        public static SqlConnection GetConnection()
        {
            
            //string con = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\data\ql_cf.mdf;Integrated Security=True";
            string con = @"Data Source=LAPTOP-HKON3I17;Initial Catalog=ql_cf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            return conn;
        }
    }
}
