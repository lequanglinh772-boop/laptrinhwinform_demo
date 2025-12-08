
using BTH3;
using System;
using System.IO;
using System.Windows.Forms;

namespace BTH3
{
    internal static class Program
    {
        public static DataHelper Db;

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
                string quyen, sv, db, un, pw;
                string configFile = "config.ini";

                if (!File.Exists(configFile))
                {
                    File.Create(configFile).Close();
                    return false;
                }

                DataHelper.ReadConfig(configFile,
                    out quyen, out sv, out db, out un, out pw);

                if (string.IsNullOrWhiteSpace(sv) ||
                    string.IsNullOrWhiteSpace(db))
                    return false;

                if (quyen == "WD")
                    Db = new DataHelper(sv, db);
                else
                    Db = new DataHelper(sv, db, un, pw);

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