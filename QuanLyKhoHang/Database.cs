using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyKhoHang
{
    class Database
    {
        //Thuộc tính
        SqlConnection conn;
        DataSet ds;
        SqlDataAdapter da;
        //Constructor khởi tạo

        public Database(string svrName, string dbName,
            bool IntergratedMode,
            string usrName, string pwd)
        {
            string connStr;
            if (IntergratedMode == true)
            {
                //Sư dụng Window Authentication Mode
                connStr = "server=" + svrName + "; database=" + dbName
                    + ";  Integrated Security = True";
            }
            else
            {
                //Sư dụng SQL Server Authentication Mode 
                connStr = "server=" + svrName + "; uid=" + usrName
                    + ";pwd=" + pwd + ";database=" + dbName;
            }

            conn = new SqlConnection(connStr);
        }

        public DataTable Execute(string strquery)
        {
            da = new SqlDataAdapter(strquery, conn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public void ExecuteNonQuery(string strquery)
        {

            conn.Open();
            try
            {
                SqlCommand sqlcomm = new SqlCommand(strquery, conn);

                sqlcomm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(string strquery, DataTable table)
        {
            da = new SqlDataAdapter(strquery, conn);
            SqlCommandBuilder sqlcb = new SqlCommandBuilder(da);
            da.Update(table);
        }
    }
}
