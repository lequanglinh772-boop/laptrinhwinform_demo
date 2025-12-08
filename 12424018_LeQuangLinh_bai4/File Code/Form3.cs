using BTH3;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BTH3
{
    public partial class Form3 : Form
    {
        private DataTable dtNhanVien;
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
            string sql = "INSERT INTO NhanVien(MaNV, TenNV, DiaChi, TenDN, MatKhau, QuyenHan) " +
                 "VALUES (@ma, @ten, @dc, @tendn, @mk, @qh)";

            Program.Db.ExecuteNonQuery(sql,
                new SqlParameter("@ma", txtMaNV.Text),
                new SqlParameter("@ten", txtTenNV.Text),
                new SqlParameter("@dc", txtDiaChi.Text),
                new SqlParameter("@tendn", txtTenDangNhap.Text),
                new SqlParameter("@mk", txtPass.Text),
                new SqlParameter("@qh", cboQuyenHan.Text)
            );

            LoadData();
            MessageBox.Show("Thêm thành công");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "EXEC spUpdateNhanVien @ma, @ten, @dc, @tendn, @mk, @qh";

            Program.Db.ExecuteNonQuery(sql,
                new SqlParameter("@ma", txtMaNV.Text),
                new SqlParameter("@ten", txtTenNV.Text),
                new SqlParameter("@dc", txtDiaChi.Text),
                new SqlParameter("@tendn", txtTenDangNhap.Text),
                new SqlParameter("@mk", txtPass.Text),
                new SqlParameter("@qh", cboQuyenHan.Text)
            );

            LoadData();
            MessageBox.Show("Sửa thành công");
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa nhân viên?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string sql = "DELETE FROM NhanVien WHERE MaNV=@ma";

            Program.Db.ExecuteNonQuery(sql, new SqlParameter("@ma", txtMaNV.Text));

            LoadData();
            MessageBox.Show("Xóa thành công");

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataRow row = dtNhanVien.Rows[e.RowIndex];

            txtMaNV.Text = row["MaNV"].ToString();
            txtTenNV.Text = row["TenNV"].ToString();
            txtDiaChi.Text = row["DiaChi"].ToString();
            txtTenDangNhap.Text = row["TenDN"].ToString();
            txtPass.Text = row["MatKhau"].ToString();
            cboQuyenHan.Text = row["QuyenHan"].ToString();
        }
    }
}
