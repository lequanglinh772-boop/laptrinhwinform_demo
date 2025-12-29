using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace ThiWF
{
    internal class KetnoiCSDL
    {
        private string connStr =
    @"Data Source=LAPTOP-URJUI0ET;
      Initial Catalog=QLSP;
      Integrated Security=True;
      TrustServerCertificate=True";

        public DataTable GetData(string sql, SqlParameter[] param = null)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, connStr);

            if (param != null)
                da.SelectCommand.Parameters.AddRange(param);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int ExecuteSQL(string sql, SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (param != null)
                    cmd.Parameters.AddRange(param);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
