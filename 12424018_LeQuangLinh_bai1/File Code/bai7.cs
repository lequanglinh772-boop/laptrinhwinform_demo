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
    public partial class bai7 : Form
    {
        public bai7()
        {          
                InitializeComponent();
                // Gán sự kiện cho các nút và textbox
                btnShow.Click += btnShow_Click;
                btnClear.Click += btnClear_Click;
                btnExit.Click += btnExit_Click;
                txtYourName.Leave += txtYourName_Leave;
                txtYear.TextChanged += txtYear_TextChanged;
                txtYourName.Focus();
        }
            private void btnShow_Click(object sender, EventArgs e)
            {
                // Kiểm tra dữ liệu trước khi hiển thị
                if (txtYourName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must enter your name!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtYourName.Focus();
                    return;
                }
                if (txtYear.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must enter year of birth!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtYear.Focus();
                    return;
                }
                int age = DateTime.Now.Year - Convert.ToInt32(txtYear.Text);
                string s = "My name is: " + txtYourName.Text + "\n" + age.ToString();
                MessageBox.Show(s, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            private void btnClear_Click(object sender, EventArgs e)
            {
                txtYourName.Clear();
                txtYear.Clear();
                errorProvider1.Clear();
                txtYourName.Focus();
            }
            private void btnExit_Click(object sender, EventArgs e)
            {
                this.Close();
            }
            private void txtYourName_Leave(object sender, EventArgs e)
            {
                Control ctr = (Control)sender;
                if (ctr.Text.Trim().Length == 0)
                    this.errorProvider1.SetError(txtYourName, "You must enter Your name");
                else
                    this.errorProvider1.Clear();
            }
            private void txtYear_TextChanged(object sender, EventArgs e)
            {
                Control ctr = (Control)sender;
                if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
                    this.errorProvider1.SetError(txtYear, "This is not invalid number");
                else
                    this.errorProvider1.Clear();
            }
    }
}