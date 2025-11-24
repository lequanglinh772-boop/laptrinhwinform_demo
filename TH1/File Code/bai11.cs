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
    public partial class bai11 : Form
    {
        public bai11()
        {
            InitializeComponent();
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Xóa trắng tất cả các ô nhập
            txtmasv.Clear();
            txthoten.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            radioButton1.Checked = true;

            // Bỏ chọn tất cả các môn học
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            // Đưa focus về ô MSSV
            txtmasv.Focus();
        }

        private void btndki_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmasv.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmasv.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txthoten.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txthoten.Focus();
                return;
            }
            string hocky = "";
            if (radioButton1.Checked) hocky = "I";
            else if (radioButton2.Checked) hocky = "II";
            else if (radioButton3.Checked) hocky = "III";
            else if (radioButton4.Checked) hocky = "IV";
            string monhoc = "";
            int count = 0;
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                count++;
                monhoc += count + ". " + checkedListBox1.Items[index].ToString() + "\n";
            }

            if (string.IsNullOrEmpty(monhoc))
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 môn học!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string thongtin = $"Sinh viên: {txthoten.Text}\n" +
                            $"Lớp: {comboBox2.Text}\n" +
                            $"Niên khóa: {comboBox1.Text}\n" +
                            $"Đã đăng ký học Học kỳ {hocky} {checkedListBox1.CheckedItems.Count} Các môn học sau:\n" +
                            monhoc;

            MessageBox.Show(thongtin, "Thông tin đăng ký",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
