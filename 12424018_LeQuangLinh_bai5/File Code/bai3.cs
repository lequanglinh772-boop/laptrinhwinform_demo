using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH5
{
    public partial class bai3 : Form
    {
        KetNoiDuLieubai2 kn = new KetNoiDuLieubai2();
        public bai3()
        {
            InitializeComponent();
        }

        private void bai3_Load(object sender, EventArgs e)
        {
            try
            {
                kn.myconnect();
                string sql = "SELECT * FROM Khoa";
                cbMaKhoa.DataSource = kn.taobang(sql);
                cbMaKhoa.DisplayMember = "MAKHOA";
                cbMaKhoa.ValueMember = "MAKHOA";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaKhoa.SelectedValue == null) return;
            if (cbMaKhoa.Text == "System.Data.DataRowView") return;

            string makhoa = cbMaKhoa.SelectedValue.ToString();
            string s = "SELECT TENKHOA FROM KHOA WHERE MAKHOA='" + makhoa + "'";
            DataTable d = kn.taobang(s);
            if (d.Rows.Count > 0)
                txtTenKhoa.Text = d.Rows[0]["TENKHOA"].ToString();
            string sqlSV = "SELECT MASV, HOSV, TENSV, NGAYSINH " +
               "FROM SINHVIEN " +
               "WHERE MAKHOA = '" + makhoa + "' " +
               "ORDER BY MASV";
            DataTable dtSV = kn.taobang(sqlSV);
            dataGridView1.DataSource = dtSV;

            lblTongSV.Text = "Tổng số Sinh Viên:";
            txtTongSV.Text = dtSV.Rows.Count.ToString();
        }
    }
}
