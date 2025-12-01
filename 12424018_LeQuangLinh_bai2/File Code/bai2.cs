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
    public partial class bai2 : Form
    {
        public bai2()
        {
            InitializeComponent();
        }

        private void bai2_Load(object sender, EventArgs e)
        {
            radVN.Enabled = true;
            picCountry.Image = imageList1.Images[0];
        }

        private void radVietNam_CheckedChanged(object sender, EventArgs e)
        {
            radVN.Enabled = true;
            picCountry.Image = imageList1.Images[0];
        }

        private void radUSA_CheckedChanged(object sender, EventArgs e)
        {
            radUSA.Enabled = true;
            picCountry.Image = imageList1.Images[1];
        }

        private void radItalian_CheckedChanged(object sender, EventArgs e)
        {
            radIta.Enabled = true;
            picCountry.Image = imageList1.Images[2];
        }

        private void radPhilippine_CheckedChanged(object sender, EventArgs e)
        {
            radPhi.Enabled = true;
            picCountry.Image = imageList1.Images[3];
        }
    }
}
