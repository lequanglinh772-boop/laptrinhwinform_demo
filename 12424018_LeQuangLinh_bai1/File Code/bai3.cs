using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Baith1
{
    public partial class bai3 : Form
    {
        public bai3()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSo.Text, out int so))
            {
                cboSo.Items.Add(txtSo.Text);
                lstTinh.Items.Clear();
                for (int i = 1; i <= so; i++)
                {
                    if ((so % i) == 0)
                    {
                        lstTinh.Items.Add(i);
                    }
                }

                txtSo.Clear();
                txtSo.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số!");
            }
        }
        private void cboSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSo.SelectedItem != null)
            {
                int so = int.Parse(cboSo.SelectedItem.ToString());
                lstTinh.Items.Clear();
                for (int i = 1; i <= so; i++)
                {
                    if ((so % i) == 0)
                    {
                        lstTinh.Items.Add(i);
                    }
                }
            }
        }
        private void btnTongUoc_Click(object sender, EventArgs e)
        {
            int tong = 0;
            for (int i = 0; i < lstTinh.Items.Count; i++)
            {
                tong += int.Parse(lstTinh.Items[i].ToString());
            }
            MessageBox.Show("Tổng các ước số: " + tong);
        }
        private void btnSoLuongChan_Click(object sender, EventArgs e)
        {
            int dem = 0;
            for (int i = 0; i < lstTinh.Items.Count; i++)
            {
                int so = int.Parse(lstTinh.Items[i].ToString());
                if (so % 2 == 0)
                    dem++;
            }
            MessageBox.Show("Số lượng ước số chẵn: " + dem);
        }
        // Hàm kiểm tra số nguyên tố
        private bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        private void btnUocNguyenTo_Click(object sender, EventArgs e)
        {
            int tong = 0;
            for (int i = 0; i < lstTinh.Items.Count; i++)
            {
                int so = int.Parse(lstTinh.Items[i].ToString());
                if (LaSoNguyenTo(so))
                {
                    tong += so;
                }
            }
            MessageBox.Show("Tổng các ước số nguyên tố: " + tong);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUocChan_Click(object sender, EventArgs e)
        {
            int tong = 0;
            for (int i = 0; i < lstTinh.Items.Count; i++)
            {
                int so = int.Parse(lstTinh.Items[i].ToString());
                if (so % 2 == 0)
                {
                    tong += so;
                }
            }
            MessageBox.Show("Tổng các ước số chẵn: " + tong);
        }
    }
}
