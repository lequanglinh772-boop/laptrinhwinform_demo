using BTH3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string quyen, sv, db, un, pw;

            try
            {
                ClsCSDL.ReadConfig("config.ini",
                                      out quyen, out sv, out db, out un, out pw);

                if (quyen == "WD")
                    rdoWindow.Checked = true;
                else
                    rdoAccount.Checked = true;

                txtTenMay.Text = sv;
                txtData.Text = db;
                txtUserName.Text = un;
                txtPassword.Text = pw;
            }
            catch
            {
                // File chưa tồn tại, dùng giá trị mặc định
                rdoWindow.Checked = true;
                txtTenMay.Text = "localhost";
                txtData.Text = "quanlythuvien";
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            string quyen = rdoWindow.Checked ? "WD" : "AC";
            string sv = txtTenMay.Text.Trim();
            string db = txtData.Text.Trim();
            string un = txtUserName.Text.Trim();
            string pw = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(sv) || string.IsNullOrWhiteSpace(db))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên Máy và Tên Data!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMay.Focus();
                return;
            }

            try
            {
                ClsCSDL temp;
                if (quyen == "WD")
                    temp = new ClsCSDL(sv, db);
                else
                    temp = new ClsCSDL(sv, db, un, pw);

                temp.Open(); 
                temp.Close();

                // Ghi file
                ClsCSDL.WriteConfig("config.ini", quyen, sv, db, un, pw);

                MessageBox.Show("Kết nối thành công, đã lưu cấu hình.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gán cho Program.Db và mở Form đăng nhập
                Program.Db = temp;
                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenMay.Focus();
            }
        }
    }
}
