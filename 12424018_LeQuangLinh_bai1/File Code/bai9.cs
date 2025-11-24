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
    public partial class bai9 : Form
    {
        public bai9()
        {
            InitializeComponent();
            btnnhap.Click += btnnhap_Click;
            btntong.Click += btntong_Click;
            btnxoadau.Click += btnxoadau_Click;
            btnxoachon.Click += btnxoachon_Click;
            btntang2.Click += btntang2_Click;
            btnbinhphuong.Click += btnbinhphuong_Click;
            btnchan.Click += btnchan_Click;
            btnle.Click += btnle_Click;
            btnketthuc.Click += btnketthuc_Click;
            txtnhap.KeyDown += txtnhap_KeyDown;
        }
        private void btnnhap_Click(object sender, EventArgs e)
        {
            if (txtnhap.Text != "")
            {
                lstnhap.Items.Add(txtnhap.Text);
                txtnhap.Clear();
            }
        }
        private void txtnhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnnhap.PerformClick();
            }
        }
        private void btntong_Click(object sender, EventArgs e)
        {
            int tong = 0;
            foreach (var item in lstnhap.Items)
                tong += int.Parse(item.ToString());

            MessageBox.Show("Tổng = " + tong);
        }
        private void btnxoadau_Click(object sender, EventArgs e)
        {
            if (lstnhap.Items.Count > 0)
                lstnhap.Items.RemoveAt(lstnhap.Items.Count - 1);

            // Sau đó xóa phần tử đầu
            if (lstnhap.Items.Count > 0)
                lstnhap.Items.RemoveAt(0);
        }
        private void btnxoachon_Click(object sender, EventArgs e)
        {
            while (lstnhap.SelectedItems.Count > 0)
                lstnhap.Items.Remove(lstnhap.SelectedItems[0]);
        }
        private void btntang2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstnhap.Items.Count; i++)
            {
                int x = int.Parse(lstnhap.Items[i].ToString());
                lstnhap.Items[i] = (x + 2).ToString();
            }
        }
        private void btnbinhphuong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstnhap.Items.Count; i++)
            {
                int x = int.Parse(lstnhap.Items[i].ToString());
                lstnhap.Items[i] = (x * x).ToString();
            }
        }
        private void btnchan_Click(object sender, EventArgs e)
        {
            lstnhap.ClearSelected();
            for (int i = 0; i < lstnhap.Items.Count; i++)
            {
                int x = int.Parse(lstnhap.Items[i].ToString());
                if (x % 2 == 0)
                    lstnhap.SetSelected(i, true);
            }
        }
        private void btnle_Click(object sender, EventArgs e)
        {
            lstnhap.ClearSelected();
            for (int i = 0; i < lstnhap.Items.Count; i++)
            {
                int x = int.Parse(lstnhap.Items[i].ToString());
                if (x % 2 != 0)
                    lstnhap.SetSelected(i, true);
            }
        }
        private void btnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
    }
}
