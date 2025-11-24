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
    public partial class bai12 : Form
    {
        public bai12()
        {
            InitializeComponent();
        }
        string chuoitam = "";
        char toantu;
        double[] toanhang = new double[2];
        double ketqua;
        int buoc = 1;
        private void btnCongTru_Click(object sender, EventArgs e)
        {
            if (chuoitam.Contains('-'))
                chuoitam = chuoitam.Replace("-", "");
            else
                chuoitam = "-" + chuoitam; txtManHinh.Text = chuoitam;
        }

        private void btnCham_Click(object sender, EventArgs e)
        {
            if (!chuoitam.Contains('.'))
            {
                chuoitam = chuoitam + "."; txtManHinh.Text = chuoitam;
            }

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            if (chuoitam.Length == 0)
            {
                buoc = 1;
                toanhang[0] = toanhang[1] = 0.0; toantu = '\0';
                ketqua = 0.0;
            }
            else
                chuoitam = "0"; txtManHinh.Text = chuoitam;

        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            if (chuoitam.Length != 0)
                toanhang[1] = Double.Parse(chuoitam); switch (toantu)
            {
                case '+': ketqua = toanhang[0] + toanhang[1]; break;
                case '-':
                    ketqua =
                toanhang[0] - toanhang[1]; break;
                case '*':
                    ketqua = toanhang[0] * toanhang[1];
                    break;
                case '/': ketqua = toanhang[0] / toanhang[1]; break;
            }
            txtManHinh.Text = ketqua.ToString();
            //Gán lại giá trị ban đầu buoc =1;
            chuoitam = "";

        }

        private void Operator_Enter(object sender, EventArgs e)
        {
            Button b = sender as Button;

            if (buoc == 1)
                toantu = b.Text[0];

            if (chuoitam.Length == 0)
                toanhang[buoc - 1] = ketqua;
            else
                toanhang[buoc - 1] = Double.Parse(chuoitam);

            if (buoc == 2)
            {
                btnBang_Click(null, null);
                toantu = b.Text[0];
                toanhang[0] = ketqua;
                buoc = 2;
            }
            else
            {
                txtManHinh.Text = toanhang[0].ToString();
                buoc++;
            }

            chuoitam = "";
        }
    }
}
