
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.IO;
using BTH3;
namespace BTH3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenNguoiDung.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            if (user == "" || pass == "")
            {
                MessageBox.Show("Nhập tên đăng nhập và mật khẩu.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNguoiDung.Focus();
                return;
            }

            try
            {
                Program.Db.Open();

                string sql = "SELECT * FROM NhanVien " +
                             "WHERE TenDN = @user AND MatKhau = @pass";

                SqlCommand cmd = new SqlCommand(sql, Program.Db.Connection);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string tenNV = dr["TenNV"].ToString();
                    string quyenHan = dr["QuyenHan"].ToString();

                    dr.Close();
                    Program.Db.Close();

                    MessageBox.Show($"Đăng nhập thành công!\nXin chào {tenNV}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Form3 f3 = new Form3();
                    f3.ShowDialog();
                    this.Close();
                }
                else
                {
                    dr.Close();
                    Program.Db.Close();
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNguoiDung.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
