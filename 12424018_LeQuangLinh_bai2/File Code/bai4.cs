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
    public partial class bai4 : Form
    {
        public bai4()
        {
            InitializeComponent();
            InitializeImageLists();
            InitializeListView();
        }
        private void InitializeImageLists()
        {
            ilsNho.ImageSize = new System.Drawing.Size(16, 16);
            ilsNho.ColorDepth = ColorDepth.Depth32Bit;
            ilsLon.ImageSize = new System.Drawing.Size(48, 48);
            ilsLon.ColorDepth = ColorDepth.Depth32Bit;
            listView1.SmallImageList = ilsNho;
            listView1.LargeImageList = ilsLon;
        }
        private void InitializeListView()
        {
            // Cấu hình ListView
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = true;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SV!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text == txtMa.Text)
                {
                    item.SubItems[1].Text = txtName.Text;
                    item.SubItems[2].Text = txtDiaChi.Text;
                    item.SubItems[3].Text = dtp.Value.ToString("dd/MM/yyyy");
                    item.SubItems[4].Text = cbLop.Text;

                    MessageBox.Show("Đã cập nhật thông tin sinh viên!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            ListViewItem lvi = new ListViewItem(txtMa.Text);
            lvi.SubItems.Add(txtName.Text);
            lvi.SubItems.Add(txtDiaChi.Text);
            lvi.SubItems.Add(dtp.Value.ToString("dd/MM/yyyy"));
            lvi.SubItems.Add(cbLop.Text);

            listView1.Items.Add(lvi);

            MessageBox.Show("Đã thêm sinh viên mới!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int dong = listView1.SelectedItems[0].Index;
                ListViewItem l = listView1.Items[dong];
                txtMa.Text = l.SubItems[0].Text;
                txtName.Text = l.SubItems[1].Text;
                txtDiaChi.Text = l.SubItems[2].Text;
                try
                {
                    dtp.Value = DateTime.ParseExact(l.SubItems[3].Text, "dd/MM/yyyy", null);
                }
                catch
                {
                    dtp.Value = DateTime.Now;
                }

                cbLop.Text = l.SubItems[4].Text;
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa {listView1.SelectedItems.Count} sinh viên đã chọn?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
                {
                    listView1.Items.Remove(listView1.SelectedItems[i]);
                }

                MessageBox.Show("Đã xóa sinh viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
