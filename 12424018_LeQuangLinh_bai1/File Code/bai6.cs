using System;
using System.Drawing;
using System.Windows.Forms;

namespace Baith1
{
    public partial class bai6 : Form
    {
        // Hàm khởi tạo - chạy khi mở form
        public bai6()
        {
            InitializeComponent();

            // GÁN EVENT CHO CÁC RADIOBUTTON (QUAN TRỌNG!)
            radTime.CheckedChanged += radTime_CheckedChanged;
            radAri.CheckedChanged += radAri_CheckedChanged;
            radTah.CheckedChanged += radTah_CheckedChanged;
            radCou.CheckedChanged += radCou_CheckedChanged;

            // Chọn sẵn Tahoma khi mở form
            radTah.Checked = true;

            // Đưa con trỏ chuột vào ô textbox
            txtNhap.Focus();
        }

        // Khi click vào RadioButton "Times New Roman"
        private void radTime_CheckedChanged(object sender, EventArgs e)
        {
            if (radTime.Checked)
            {
                // Đổi font chữ trong textbox thành Times New Roman
                txtNhap.Font = new Font("Times New Roman", txtNhap.Font.Size);
            }
        }

        // Khi click vào RadioButton "Arial"
        private void radAri_CheckedChanged(object sender, EventArgs e)
        {
            if (radAri.Checked)
            {
                // Đổi font chữ trong textbox thành Arial
                txtNhap.Font = new Font("Arial", txtNhap.Font.Size);
            }
        }

        // Khi click vào RadioButton "Tahoma"
        private void radTah_CheckedChanged(object sender, EventArgs e)
        {
            if (radTah.Checked)
            {
                // Đổi font chữ trong textbox thành Tahoma
                txtNhap.Font = new Font("Tahoma", txtNhap.Font.Size);
            }
        }

        // Khi click vào RadioButton "Courier New"
        private void radCou_CheckedChanged(object sender, EventArgs e)
        {
            if (radCou.Checked)
            {
                // Đổi font chữ trong textbox thành Courier New
                txtNhap.Font = new Font("Courier New", txtNhap.Font.Size);
            }
        }

        // Khi click nút "Thoát"
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Đóng form này
            this.Close();
        }
    }
}