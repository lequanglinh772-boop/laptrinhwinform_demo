using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH2._1
{
    public partial class bai5 : Form
    {
        public bai5()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text == "" || txtHoTen.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            dgvSV.Rows.Add(txtMaSV.Text, txtHoTen.Text, txtDiaChi.Text);
        }

        private void dgvSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaSV.Text = dgvSV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtHoTen.Text = dgvSV.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvSV.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
        

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string ma = txtMaSV.Text;
            foreach (DataGridViewRow row in dgvSV.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == ma)
                {
                    row.Cells[1].Value = txtHoTen.Text;
                    row.Cells[2].Value = txtDiaChi.Text;

                    MessageBox.Show("Sửa thành công!");
                    return;
                }
            }

            MessageBox.Show("Không tìm thấy mã SV để sửa!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaSV.Text;

            foreach (DataGridViewRow row in dgvSV.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == ma)
                {
                    dgvSV.Rows.Remove(row);
                    MessageBox.Show("Đã xóa!");
                    return;
                }
            }

            MessageBox.Show("Không tìm thấy mã SV để xóa!");
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string ma = txtMaSV.Text;

            foreach (DataGridViewRow row in dgvSV.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == ma)
                {
                    row.Selected = true;
                    dgvSV.FirstDisplayedScrollingRowIndex = row.Index;
                    MessageBox.Show("Đã tìm thấy sinh viên!");
                    return;
                }
            }

            MessageBox.Show("Không tìm thấy sinh viên!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
