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
    public partial class bai2 : Form
    {
        public bai2()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKQ_Click(object sender, EventArgs e)
        {
            string hoten = this.txtHoTen.Text.Trim();
            if (this.rad1.Checked == true)
                txtKQ.Text = hoten.ToLower();
            if (this.rad2.Checked == true)
                txtKQ.Text = hoten.ToUpper();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.txtHoTen.Clear();
            this.txtKQ.Clear();
            this.rad1.Checked = true;
            this.txtHoTen.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtKQ_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
