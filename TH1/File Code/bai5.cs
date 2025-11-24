using System;
using System.Drawing;
using System.Windows.Forms;

namespace Baith1
{
    public partial class bai5 : Form
    {
        public bai5()
        {
            InitializeComponent();
            this.Load += bai5_Load;
            txtNhap.TextChanged += txtNhap_TextChanged;
            radRed.CheckedChanged += radRed_CheckedChanged;
            radGreen.CheckedChanged += radGreen_CheckedChanged;
            radBlue.CheckedChanged += radBlue_CheckedChanged;
            radBlack.CheckedChanged += radBlack_CheckedChanged;
            chDam.CheckedChanged += chDam_CheckedChanged;
            chNghieng.CheckedChanged += chNghieng_CheckedChanged;
            chGach.CheckedChanged += chGach_CheckedChanged;
            this.KeyPreview = true;
        }
        private void bai5_Load(object sender, EventArgs e)
        {
            radRed.Checked = true;
            txtNhap.Focus();
        }
        private void txtNhap_TextChanged(object sender, EventArgs e)
        {
            txtLapTrinh.Text = txtNhap.Text;
        }
        private void radRed_CheckedChanged(object sender, EventArgs e)
        {
            if (radRed.Checked)
            {
                txtLapTrinh.ForeColor = Color.Red;
                txtNhap.ForeColor = Color.Red;
            }
        }
        private void radGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (radGreen.Checked)
            {
                txtLapTrinh.ForeColor = Color.Green;
                txtNhap.ForeColor = Color.Green;
            }
        }
        private void radBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (radBlue.Checked)
            {
                txtLapTrinh.ForeColor = Color.Blue;
                txtNhap.ForeColor = Color.Blue;
            }
        }
        private void radBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (radBlack.Checked)
            {
                txtLapTrinh.ForeColor = Color.Black;
                txtNhap.ForeColor = Color.Black;
            }
        }
        private void chDam_CheckedChanged(object sender, EventArgs e)
        {
            txtLapTrinh.Font = new Font(txtLapTrinh.Font.Name,
                txtLapTrinh.Font.Size,
                txtLapTrinh.Font.Style ^ FontStyle.Bold);

            txtNhap.Font = new Font(txtNhap.Font.Name,
                txtNhap.Font.Size,
                txtNhap.Font.Style ^ FontStyle.Bold);
        }
        private void chNghieng_CheckedChanged(object sender, EventArgs e)
        {
            txtLapTrinh.Font = new Font(txtLapTrinh.Font.Name,
                txtLapTrinh.Font.Size,
                txtLapTrinh.Font.Style ^ FontStyle.Italic);

            txtNhap.Font = new Font(txtNhap.Font.Name,
                txtNhap.Font.Size,
                txtNhap.Font.Style ^ FontStyle.Italic);
        }
        private void chGach_CheckedChanged(object sender, EventArgs e)
        {
            txtLapTrinh.Font = new Font(txtLapTrinh.Font.Name,
                txtLapTrinh.Font.Size,
                txtLapTrinh.Font.Style ^ FontStyle.Underline);

            txtNhap.Font = new Font(txtNhap.Font.Name,
                txtNhap.Font.Size,
                txtNhap.Font.Style ^ FontStyle.Underline);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}