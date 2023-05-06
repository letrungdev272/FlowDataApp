using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Data_PLC;

namespace Tutorial.SqlConn
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=data_plc;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }

}