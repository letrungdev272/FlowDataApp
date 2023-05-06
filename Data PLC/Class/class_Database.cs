using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient; // Thư viện SQL
using System.Net.Sockets;
using System.IO;
using Tutorial.SqlConn;

namespace Data_PLC
{
    class class_Database
    {
        public static void sqlShow(string name, ListBox LB)
        {
            SqlConnection sql_conn; // Khởi tạo tên kết nối SQL
            string query = "Select * from " + name;
            using (sql_conn = DBUtils.GetDBConnection())
            {
                sql_conn.Open();
                SqlCommand cmd = new SqlCommand(query, sql_conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                LB.DataSource = dt;
                LB.DisplayMember = name;
                LB.ValueMember = name;
                sql_conn.Close();
            }     
        }
        
        public static void sqlShowCbb(string name, ComboBox Cbb)
        {
            SqlConnection sql_conn; // Khởi tạo tên kết nối SQL
            string query = "Select * from " + name;
            using (sql_conn = DBUtils.GetDBConnection())
            {
                sql_conn.Open();
                SqlCommand cmd = new SqlCommand(query, sql_conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                Cbb.DataSource = dt;
                Cbb.DisplayMember = name;
                Cbb.ValueMember = name;
                sql_conn.Close();
            }
        }

        public static void sqlAdd(string table_name,string value)
        {
            SqlConnection sql_conn; // Khởi tạo tên kết nối SQL
            string query = "insert into " + table_name + " values('" + value + "');";
            using (sql_conn = DBUtils.GetDBConnection())
            {
                sql_conn.Open();
                SqlCommand cmd = new SqlCommand(query, sql_conn);
                cmd.ExecuteNonQuery();
                sql_conn.Close();
            }
        }

        public static void sqlDel(string table_name, string value)
        {
            SqlConnection sql_conn; // Khởi tạo tên kết nối SQL
            string query = "delete from " + table_name + " where "+ table_name +" = N'" + value + "';";
            using (sql_conn = DBUtils.GetDBConnection())
            {
                sql_conn.Open();
                SqlCommand cmd = new SqlCommand(query, sql_conn);
                cmd.ExecuteNonQuery();
                sql_conn.Close();
            }
        }

        public static void Insert_water(string table_name, string value1, string value2, string value3)
        {
            SqlConnection sql_conn; // Khởi tạo tên kết nối SQL
            string query = "insert into " + table_name + " values (" + value1 + ", "+ value2 + ", " + value3 +");";
            using (sql_conn = DBUtils.GetDBConnection())
            {
                sql_conn.Open();
                SqlCommand cmd = new SqlCommand(query, sql_conn);
                cmd.ExecuteNonQuery();
                sql_conn.Close();
            }
        }
        public static void Insert_LST(string table_name, string value1, int value2, string value3,string value4,string value5)
        {
            try
            {
                SqlConnection sql_conn; // Khởi tạo tên kết nối SQL
                string query = "insert into " + table_name + " values (" + value1 +", "+value2+ ", '" + value3 + "', " + value4 + ", " + value5 + ");";
                using (sql_conn = DBUtils.GetDBConnection())
                {
                    sql_conn.Open();
                    SqlCommand cmd = new SqlCommand(query, sql_conn);
                    cmd.ExecuteNonQuery();
                    sql_conn.Close();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Update(string sql)
        {
            try
            {
                SqlConnection sql_conn; // Khởi tạo tên kết nối SQL
                string query = sql;
                using (sql_conn = DBUtils.GetDBConnection())
                {
                    sql_conn.Open();
                    SqlCommand cmd = new SqlCommand(query, sql_conn);
                    cmd.ExecuteNonQuery();
                    sql_conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SqlSelect(string query, out DataTable table)
        {
            SqlConnection sql_conn; // Khởi tạo tên kết nối SQL
            using (sql_conn = DBUtils.GetDBConnection())
            {
                sql_conn.Open();
                SqlCommand cmd = new SqlCommand(query, sql_conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                table = dt;
                sql_conn.Close();
            }
        }
    }
}
