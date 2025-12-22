using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Azure.Core.HttpHeader;
using Microsoft.Data.SqlClient;     
namespace BTH5
{
    public partial class bai2 : Form
    {
        KetNoiDuLieubai2 kn = new KetNoiDuLieubai2();
        public bai2()
        {
            InitializeComponent();
        }

        private void bai2_Load(object sender, EventArgs e)
        {
            try
            {
                kn.myconnect();
                LoadMonHocToComboBox();
                kn.myclose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoadMonHocToComboBox()
        {
            try
            {
                string sql = "SELECT * FROM MONHOC";
                DataTable dt = kn.taobang(sql);

                cbMaMon.DataSource = dt;
                cbMaMon.DisplayMember = "MANH"; 
                cbMaMon.ValueMember = "MANH";  
                if (dt.Rows.Count > 0)
                {
                    txtTenMon.Text = dt.Rows[0]["TENMH"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load môn học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMaMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                try
                {
                    string maMon = cbMaMon.SelectedValue.ToString();
                    string sqlMonHoc = "SELECT * FROM MONHOC WHERE MANH = '" + maMon + "'";
                    DataTable dtMonHoc = kn.taobang(sqlMonHoc);

                    if (dtMonHoc.Rows.Count > 0)
                    {
                        txtTenMon.Text = dtMonHoc.Rows[0]["TENMH"].ToString();
                        txtSoTiet.Text = dtMonHoc.Rows[0]["SOTIET"].ToString();
                    }
                    LoadSinhVienTheoMonHoc(maMon);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadSinhVienTheoMonHoc(string maMon)
        {
            try
            {
                string sql = @"SELECT 
                                SV.MASV, 
                                SV.HOSV, 
                                SV.TENSV, 
                                SV.NGAYSINH, 
                                KQ.DIEM
                              FROM SINHVIEN SV
                              INNER JOIN KETQUA KQ ON SV.MASV = KQ.MASV
                              WHERE KQ.MANH = '" + maMon + "' " +
                              "ORDER BY SV.MASV";

                DataTable dt = kn.taobang(sql);
                dataGridView1.DataSource = dt;
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["MASV"].HeaderText = "Mã SV";
                    dataGridView1.Columns["HOSV"].HeaderText = "Họ SV";
                    dataGridView1.Columns["TENSV"].HeaderText = "Tên SV";
                    dataGridView1.Columns["NGAYSINH"].HeaderText = "Ngày sinh";
                    dataGridView1.Columns["DIEM"].HeaderText = "Điểm";
                    dataGridView1.Columns["MASV"].Width = 80;
                    dataGridView1.Columns["HOSV"].Width = 120;
                    dataGridView1.Columns["TENSV"].Width = 100;
                    dataGridView1.Columns["NGAYSINH"].Width = 100;
                    dataGridView1.Columns["DIEM"].Width = 60;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load sinh viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn thoát chương trình?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                kn.myclose();
                this.Close();
            }
        }

        private void bai2_FormClosing(object sender, FormClosingEventArgs e)
        {

            kn.myclose();
        }
    }
}
