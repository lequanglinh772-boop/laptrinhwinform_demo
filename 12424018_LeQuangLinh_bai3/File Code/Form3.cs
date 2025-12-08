using BTH3;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BTH3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxQuyenHan();
        }
        private void LoadComboBoxQuyenHan()
        {
            cboQuyenHan.Items.Clear();
            cboQuyenHan.Items.Add("Quản trị");
            cboQuyenHan.Items.Add("Nhân viên");
        }
        private void LoadData()
        {
            try
            {
                Program.Db.Open();

                string sql = "SELECT MaNV, TenNV, DiaChi, TenDN, MatKhau, QuyenHan FROM NhanVien";
                SqlDataAdapter da = new SqlDataAdapter(sql, Program.Db.Connection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // Đặt tiêu đề cột
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                    dataGridView1.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
                    dataGridView1.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dataGridView1.Columns["TenDN"].HeaderText = "Tên Đăng Nhập";
                    dataGridView1.Columns["MatKhau"].HeaderText = "Mật Khẩu";
                    dataGridView1.Columns["QuyenHan"].HeaderText = "Quyền Hạn";
                }

                Program.Db.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtTenDangNhap.Clear();
            cboQuyenHan.SelectedIndex = -1;
            txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE NhanVien SET TenNV=@ten, DiaChi=@dc, TenDN=@tendn, " +
                         "QuyenHan=@qh WHERE MaNV=@ma";

            try
            {
                Program.Db.Open();
                SqlCommand cmd = new SqlCommand(sql, Program.Db.Connection);
                cmd.Parameters.AddWithValue("@ma", txtMaNV.Text.Trim());
                cmd.Parameters.AddWithValue("@ten", txtTenNV.Text.Trim());
                cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@tendn", txtTenDangNhap.Text.Trim());
                cmd.Parameters.AddWithValue("@qh", cboQuyenHan.Text.Trim());

                int n = cmd.ExecuteNonQuery();
                Program.Db.Close();

                if (n > 0)
                {
                    MessageBox.Show("Sửa thành công");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Program.Db.Close();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa nhân viên này?", "Xác nhận",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string sql = "DELETE FROM NhanVien WHERE MaNV=@ma";

            try
            {
                Program.Db.Open();
                SqlCommand cmd = new SqlCommand(sql, Program.Db.Connection);
                cmd.Parameters.AddWithValue("@ma", txtMaNV.Text.Trim());

                int n = cmd.ExecuteNonQuery();
                Program.Db.Close();

                if (n > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadData();
                    btnTaoMoi_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Program.Db.Close();
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dataGridView1.Rows[e.RowIndex];

            txtMaNV.Text = r.Cells["MaNV"].Value?.ToString();
            txtTenNV.Text = r.Cells["TenNV"].Value?.ToString();
            txtDiaChi.Text = r.Cells["DiaChi"].Value?.ToString();
            txtTenDangNhap.Text = r.Cells["TenDN"].Value?.ToString();
            cboQuyenHan.Text = r.Cells["QuyenHan"].Value?.ToString();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int currentIndex = dataGridView1.CurrentRow.Index;
            if (currentIndex > 0)
                dataGridView1.CurrentCell = dataGridView1.Rows[currentIndex - 1].Cells[0];
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int currentIndex = dataGridView1.CurrentRow.Index;
            if (currentIndex < dataGridView1.Rows.Count - 1)
                dataGridView1.CurrentCell = dataGridView1.Rows[currentIndex + 1].Cells[0];
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
        }
    }
}
