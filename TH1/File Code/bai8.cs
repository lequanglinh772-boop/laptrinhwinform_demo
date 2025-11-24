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
    public partial class bai8 : Form
    {
        public bai8()
        {
            InitializeComponent();
            btnGiai.Click += btnGiai_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click += btnThoat_Click;
            txtA.TextChanged += txtA_TextChanged;
            txtB.TextChanged += txtB_TextChanged;
            btnGiai.Enabled = false;
            btnXoa.Enabled = false;
            txtA.Focus();
        }
        private void txtA_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtA, "Bạn phải nhập số A");
                btnGiai.Enabled = false;
                return;
            }
            double a;
            if (!double.TryParse(ctr.Text, out a))
            {
                this.errorProvider1.SetError(txtA, "A phải là số");
                btnGiai.Enabled = false;
                return;
            }

            this.errorProvider1.Clear();
            KiemTraHopLe();
        }
        private void txtB_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtB, "Bạn phải nhập số B");
                btnGiai.Enabled = false;
                return;
            }
            double b;
            if (!double.TryParse(ctr.Text, out b))
            {
                this.errorProvider1.SetError(txtB, "B phải là số");
                btnGiai.Enabled = false;
                return;
            }
            this.errorProvider1.Clear();
            KiemTraHopLe();
        }
        private void KiemTraHopLe()
        {
            double a, b;
            if (double.TryParse(txtA.Text, out a) && double.TryParse(txtB.Text, out b))
            {
                btnGiai.Enabled = true;
            }
            else
            {
                btnGiai.Enabled = false;
            }
        }
        private void btnGiai_Click(object sender, EventArgs e)
        {
            double a = double.Parse(txtA.Text);
            double b = double.Parse(txtB.Text);
            string ketqua = "";
            if (a == 0)
            {
                if (b == 0)
                {
                    ketqua = "Phương trình có vô số nghiệm";
                }
                else
                {
                    ketqua = "Phương trình vô nghiệm";
                }
            }
            else
            {
                double x = -b / a;
                ketqua = "Nghiệm x = " + x.ToString();
            }
            txtKQ.Text = ketqua;
            btnGiai.Enabled = false;
            btnXoa.Enabled = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtKQ.Clear();
            errorProvider1.Clear();
            btnXoa.Enabled = false;
            btnGiai.Enabled = false;
            txtA.Focus();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}