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
    public partial class bai7 : Form
    {
        public bai7()
        {
            InitializeComponent();
        }

        private void bai7_Load(object sender, EventArgs e)
        {

            TreeNode cntt = new TreeNode("Khoa CNTT");
            TreeNode kinhte = new TreeNode("Khoa Kinh Tế");

            TreeNode lopA = new TreeNode("Lớp A");
            TreeNode lopB = new TreeNode("Lớp B");

            lopA.Nodes.Add(new TreeNode("Nguyễn Văn A"));
            lopA.Nodes.Add(new TreeNode("Trần Thị B"));

            lopB.Nodes.Add(new TreeNode("Lê Văn C"));

            TreeNode lopC = new TreeNode("Lớp C");
            lopC.Nodes.Add(new TreeNode("Phạm Văn D"));

            cntt.Nodes.Add(lopA);
            cntt.Nodes.Add(lopB);

            kinhte.Nodes.Add(lopC);

            treeView1.Nodes.Add(cntt);
            treeView1.Nodes.Add(kinhte);

            treeView1.ExpandAll();

            listView1.View = View.Details;
            listView1.Columns.Add("Họ tên", 150);
            listView1.Columns.Add("Lớp", 80);

            treeView1.SelectedNode = null;

            this.ActiveControl = txtTim;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            listView1.Items.Clear();

            if (node.Parent == null)
            {

                foreach (TreeNode lop in node.Nodes)
                {
                    foreach (TreeNode sv in lop.Nodes)
                    {
                        AddToListView(sv.Text, lop.Text);
                    }
                }
            }
            else if (node.Parent.Parent == null)
            {
                foreach (TreeNode sv in node.Nodes)
                {
                    AddToListView(sv.Text, node.Text);
                }
            }
            else
            {
                AddToListView(node.Text, node.Parent.Text);
            }
        }
        private void AddToListView(string hoten, string lop)
        {
            ListViewItem item = new ListViewItem(hoten);
            item.SubItems.Add(lop);
            listView1.Items.Add(item);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string key = txtTim.Text.Trim().ToLower();
            if (key == "")
            {
                MessageBox.Show("Nhập từ khóa cần tìm!");
                return;
            }

            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Hãy chọn Khoa hoặc Lớp trên TreeView!");
                return;
            }

            listView1.Items.Clear();
            TreeNode node = treeView1.SelectedNode;

            if (node.Parent == null)
            {
                foreach (TreeNode lop in node.Nodes)
                {
                    foreach (TreeNode sv in lop.Nodes)
                    {
                        if (sv.Text.ToLower().Contains(key))
                            AddToListView(sv.Text, lop.Text);
                    }
                }
            }
            else if (node.Parent.Parent == null)
            {
                foreach (TreeNode sv in node.Nodes)
                {
                    if (sv.Text.ToLower().Contains(key))
                        AddToListView(sv.Text, node.Text);
                }
            }
            else
            {
                if (node.Text.ToLower().Contains(key))
                {
                    AddToListView(node.Text, node.Parent.Text);
                }
            }
        }
    }
}
