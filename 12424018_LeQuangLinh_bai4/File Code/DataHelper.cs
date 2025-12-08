using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace BTH3
{
    public class DataHelper
    {
        private SqlConnection conn;



        public SqlConnection Connection => conn;

        public DataHelper(string server, string database, string user, string pass)
        {
            string conStr =
                $"Server={server};Database={database};User Id={user};Password={pass};TrustServerCertificate=True";
            conn = new SqlConnection(conStr);
        }
        public DataHelper(string server, string database)
        {
            string conStr =
                $"Server={server};Database={database};Trusted_Connection=True;TrustServerCertificate=True";
            conn = new SqlConnection(conStr);
        }

        public void Open()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        public void Close()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }

        public DataTable FillDataTable(string sql)
        {
            Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            Close();
            return tb;
        }
        public void InsertTable(DataTable tb, params object[] values)
        {
            DataRow r = tb.NewRow();
            for (int i = 0; i < values.Length; i++)
            {
                r[i] = values[i];
            }
            tb.Rows.Add(r);
        }

        public void UpdateTable(DataTable tb, params object[] values)
        {
            string ma = values[0].ToString();

            foreach (DataRow r in tb.Rows)
            {
                if (r["MaNV"].ToString() == ma)
                {
                    for (int i = 1; i < values.Length; i++)
                        r[i] = values[i];
                    break;
                }
            }
        }

        public void DeleteTable(DataTable tb, string maNV)
        {
            foreach (DataRow r in tb.Rows)
            {
                if (r["MaNV"].ToString() == maNV)
                {
                    r.Delete();
                    break;
                }
            }
        }
        public void UpdateTableToDataBase(DataTable dt, string tableName)
        {
            Open();
            string sql = $"SELECT * FROM {tableName}";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            da.Update(dt);

            Close();
        }
        public int ExecuteNonQuery(string sql, params SqlParameter[] pr)
        {
            Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(pr);
            int result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }
        public static void WriteConfig(string file, string quyen, string sv, string db, string un, string pw)
        {
            File.WriteAllLines(file, new string[] { quyen, sv, db, un, pw });
        }

        public static void ReadConfig(string file, out string quyen, out string sv, out string db, out string un, out string pw)
        {
            string[] lines = File.ReadAllLines(file);

            quyen = lines[0];
            sv = lines[1];
            db = lines[2];
            un = lines[3];
            pw = lines[4];
        }

    }
}
