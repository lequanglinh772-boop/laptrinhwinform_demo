using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Azure.Core.HttpHeader;

namespace BTH5
{
    internal class KetNoiDuLieubai2
    {
        public SqlConnection cnn = new SqlConnection(
       // QLSV1 bai2 StudentManagementDB bai4 QLSV 1 
       @"Data Source=LAPTOP-URJUI0ET;
      Initial Catalog=QLSV1;
      Integrated Security=True;
      TrustServerCertificate=True");
        public void myconnect()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
        }
        public void myclose()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
        public DataTable taobang(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter ds = new SqlDataAdapter(sql, cnn);
                ds.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo bảng: " + ex.Message);
            }
            return dt;
        }
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                myconnect();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                int result = cmd.ExecuteNonQuery();
                myclose();
                return result;
            }
            catch (Exception ex)
            {
                myclose();
                throw new Exception("Lỗi khi thực thi: " + ex.Message);
            }
        }
        public object ExecuteScalar(string sql)
        {
            try
            {
                myconnect();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                object result = cmd.ExecuteScalar();
                myclose();
                return result;
            }
            catch (Exception ex)
            {
                myclose();
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}

