using Microsoft.Data.SqlClient;
using BTH3;
using System;
using System.IO;
using System.Windows.Forms;

namespace BTH3
{
    internal static class Program
    {
        public static ClsCSDL Db;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            if (TestConnection())
            {
                Application.Run(new Form1()); // Form đăng nhập
            }
            else
            {
                Application.Run(new Form2()); // Form cấu hình
            }
        }

        private static bool TestConnection()
        {
            try
            {
                string quyen, sv, dbname, un, pw;
                string configFile = "config.ini";

                // Chưa có file config.ini → mở form cấu hình
                if (!File.Exists(configFile))
                {
                    File.Create(configFile).Close();
                    return false;
                }

                // Đọc cấu hình từ file
                ClsCSDL.ReadConfig(configFile,
                    out quyen, out sv, out dbname, out un, out pw);

                if (string.IsNullOrWhiteSpace(sv) ||
                    string.IsNullOrWhiteSpace(dbname))
                    return false;

                // Tạo connectionString
                string connectionString = "";

                if (quyen == "WD")
                {
                    connectionString =
                        $"Server={sv};Database={dbname};Trusted_Connection=True;TrustServerCertificate=True";
                }
                else
                {
                    connectionString =
                        $"Server={sv};Database={dbname};User Id={un};Password={pw};TrustServerCertificate=True";
                }

                // GÁN VÀO Db (đây chính là chỗ bạn đang hỏi)
                Db = new ClsCSDL(sv, dbname, un, pw);

                // Kiểm tra kết nối
                Db.Open();
                Db.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}