using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baith1
{
    public partial class bai4 : Form
    {
        public bai4()
        {
            InitializeComponent();

            // Căn giữa form
            this.StartPosition = FormStartPosition.CenterScreen;
            radcong.Checked = true;
        }
        private void radcong_CheckedChanged(object sender, EventArgs e)
        {
            if (radcong.Checked)
            {
                TinhToan();
            }
        }
        private void radtru_CheckedChanged(object sender, EventArgs e)
        {
            if (radtru.Checked)
            {
                TinhToan();
            }
        }
        private void radnhan_CheckedChanged(object sender, EventArgs e)
        {
            if (radnhan.Checked)
            {
                TinhToan();
            }
        }
        private void radchia_CheckedChanged(object sender, EventArgs e)
        {
            if (radchia.Checked)
            {
                TinhToan();
            }
        }
        private void TinhToan()
        {
            if (double.TryParse(txt1.Text, out double so1) &&
                double.TryParse(txt2.Text, out double so2))
            {
                double ketQua = 0;
                if (radcong.Checked)
                {
                    ketQua = so1 + so2;
                }
                else if (radtru.Checked)
                {
                    ketQua = so1 - so2;
                }
                else if (radnhan.Checked)
                {
                    ketQua = so1 * so2;
                }
                else if (radchia.Checked)
                {
                    if (so2 != 0)
                    {
                        ketQua = so1 / so2;
                    }
                    else
                    {
                        MessageBox.Show("Không thể chia cho 0!", "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtKQ.Text = "";
                        return;
                    }
                }
                txtKQ.Text = ketQua.ToString();
            }
            else
            {
                txtKQ.Text = "";
            }
        }
        private void txt1_TextChanged(object sender, EventArgs e)
        {
            TinhToan();
        }
        private void txt2_TextChanged(object sender, EventArgs e)
        {
            TinhToan();
        }
    }
}
