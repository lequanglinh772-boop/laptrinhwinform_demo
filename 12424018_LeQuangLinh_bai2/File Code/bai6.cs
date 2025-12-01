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
    public partial class bai6 : Form
    {
        public bai6()
        {
            InitializeComponent();
        }

        private void bai6_Load(object sender, EventArgs e)
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                TreeNode node = new TreeNode(c.ToString());
                treeView1.Nodes.Add(node);
            }

            treeView1.ExpandAll(); // mở sẵn cho giống hình

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string first = txtFirstName.Text.Trim();
            string last = txtLastName.Text.Trim();

            if (first == "" || last == "")
            {
                MessageBox.Show("Vui lòng nhập đủ First Name và Last Name!");
                return;
            }
            string full = last + ", " + first;
            char key = char.ToUpper(last[0]);

            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Text == key.ToString())
                {
                    node.Nodes.Add(full);
                    treeView1.ExpandAll();
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    return;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

