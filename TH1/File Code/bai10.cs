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
    public partial class bai10 : Form
    {
        public bai10()
        {
            InitializeComponent();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (lstlopa.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tên để xóa!", "Thông báo");
                return;
            }
            for (int i = lstlopa.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstlopa.Items.RemoveAt(lstlopa.SelectedIndices[i]);
            }
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtnhap.Text == "")
            {
                errorProvider1.SetError(txtnhap, "Vui lòng nhập họ và tên");
            }
            lstlopa.Items.Add(txtnhap.Text);
            txtnhap.Text = "";
        }

        private void btnsangb_Click(object sender, EventArgs e)
        {
            foreach (var item in lstlopa.Items)
                lstlopb.Items.Add(item);

            lstlopa.Items.Clear();
        }

        private void btnsangb1_Click(object sender, EventArgs e)
        {
            for (int i = lstlopa.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = lstlopa.SelectedIndices[i];
                lstlopb.Items.Add(lstlopa.Items[index]);
                lstlopa.Items.RemoveAt(index);
            }
        }

        private void btnsanga1_Click(object sender, EventArgs e)
        {
            for (int i = lstlopb.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = lstlopb.SelectedIndices[i];
                lstlopa.Items.Add(lstlopb.Items[index]);
                lstlopb.Items.RemoveAt(index);
            }
        }

        private void btnsanga_Click(object sender, EventArgs e)
        {
            foreach (var item in lstlopb.Items)
                lstlopa.Items.Add(item);

            lstlopb.Items.Clear();
        }

        private void btnketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
