using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.IO;

namespace BTH3
{
    public class ClsCSDL
    {
        private SqlConnection conn;

        public SqlConnection Connection => conn;
        
        public ClsCSDL(string server, string database)
        {
            string conStr =
                $"Server={server};Database={database};Trusted_Connection=True;TrustServerCertificate=True";
            conn = new SqlConnection(conStr);
        }

        public ClsCSDL(string server, string database, string user, string pass)
        {
            string conStr =
                $"Server={server};Database={database};User Id={user};Password={pass};TrustServerCertificate=True";
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
            DataTable dt = new DataTable();
            da.Fill(dt);

            Close();
            return dt;
        }

        public void InsertTable(DataTable tb, params object[] gt)
        {
            DataRow r = tb.NewRow();
            for (int i = 0; i < gt.Length; i++)
                r[i] = gt[i];
            tb.Rows.Add(r);
        }

        public void UpdateTable(DataTable tb, params object[] gt)
        {
            string ma = gt[0].ToString();

            foreach (DataRow r in tb.Rows)
            {
                if (r["MaNV"].ToString() == ma)
                {
                    for (int i = 1; i < gt.Length; i++)
                        r[i] = gt[i];
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
        public int ExecuteNonQuery(string sql, params SqlParameter[] p)
        {
            Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            if (p != null && p.Length > 0)
                cmd.Parameters.AddRange(p);

            int result = cmd.ExecuteNonQuery();

            Close();
            return result;
        }

        public static void WriteConfig(string file, string quyen, string sv, string db, string un, string pw)
        {
            File.WriteAllLines(file, new string[]
            {
                quyen, sv, db, un, pw
            });
        }

        public static void ReadConfig(string file,
            out string quyen, out string sv, out string db, out string un, out string pw)
        {
            string[] lines = File.ReadAllLines(file);

            quyen = lines.Length > 0 ? lines[0] : "";
            sv = lines.Length > 1 ? lines[1] : "";
            db = lines.Length > 2 ? lines[2] : "";
            un = lines.Length > 3 ? lines[3] : "";
            pw = lines.Length > 4 ? lines[4] : "";
        }
    }
}
