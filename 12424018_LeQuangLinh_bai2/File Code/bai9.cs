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
    public partial class bai9 : Form
    {
        public bai9()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng → không tính
            if (txtHoTen.Text.Trim() == "") return;
            if (cboKhuVuc.SelectedIndex == -1) return;

            // Kiểm tra số
            if (!int.TryParse(txtSoCu.Text, out int soCu)) return;
            if (!int.TryParse(txtSoMoi.Text, out int soMoi)) return;
            if (soMoi < soCu) return;

            int tieuthu = soMoi - soCu;
            txtTieuThu.Text = tieuthu.ToString();

            int dinhmuc = int.Parse(txtDinhMuc.Text);
            int tien;

            if (tieuthu <= dinhmuc)
                tien = tieuthu * 500;
            else
                tien = dinhmuc * 500 + (tieuthu - dinhmuc) * 1000;

            txtThanhTien.Text = tien.ToString();

            // Thêm vào ListView
            ListViewItem item = new ListViewItem(txtHoTen.Text);
            item.SubItems.Add(cboKhuVuc.Text);
            item.SubItems.Add(txtDinhMuc.Text);
            item.SubItems.Add(tieuthu.ToString());
            item.SubItems.Add(tien.ToString());
            lvKetQua.Items.Add(item);

            CapNhatTongTien();
        }
        private void CapNhatTongTien()
        {
            int tong = 0;

            foreach (ListViewItem it in lvKetQua.Items)
                tong += int.Parse(it.SubItems[4].Text);

            txtTongTien.Text = tong.ToString();
        }
        private void cboKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboKhuVuc.SelectedIndex)
            {
                case 0: txtDinhMuc.Text = "50"; break;
                case 1: txtDinhMuc.Text = "100"; break;
                case 2: txtDinhMuc.Text = "150"; break;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            cboKhuVuc.SelectedIndex = -1;
            txtDinhMuc.Clear();
            txtSoCu.Clear();
            txtSoMoi.Clear();
            txtTieuThu.Clear();
            txtThanhTien.Clear();

            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem it in lvKetQua.SelectedItems)
                lvKetQua.Items.Remove(it);

            CapNhatTongTien();
        }

        private void bai9_Load(object sender, EventArgs e)
        {
            cboKhuVuc.Items.Add("Khu vực 1");
            cboKhuVuc.Items.Add("Khu vực 2");
            cboKhuVuc.Items.Add("Khu vực 3");

            txtHoTen.Focus();
        }
    }
}
