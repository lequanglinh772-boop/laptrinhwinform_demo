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
    public partial class bai8 : Form
    {
        public bai8()
        {
            InitializeComponent();
        }

        private void bai8_Load(object sender, EventArgs e)
        {
            TreeNode lopA = new TreeNode("Lớp A");
            TreeNode lopB = new TreeNode("Lớp B");
            TreeNode lopC = new TreeNode("Lớp C");

            treeView1.Nodes.Add(lopA);
            treeView1.Nodes.Add(lopB);
            treeView1.Nodes.Add(lopC);

            treeView1.ExpandAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ma = txtMaSV.Text.Trim();
            string ten = txtHoTen.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();

            if (ma == "" || ten == "" || diachi == "")
            {
                MessageBox.Show("Không được để trống thông tin!");
                return;
            }

            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Parent != null)
            {
                MessageBox.Show("Bạn phải chọn một lớp để thêm sinh viên!");
                return;
            }

            foreach (TreeNode lop in treeView1.Nodes)
            {
                foreach (TreeNode sv in lop.Nodes)
                {
                    if (sv.Text.StartsWith(ma + " "))
                    {
                        MessageBox.Show("Trùng mã sinh viên!");
                        return;
                    }
                }
            }
            string textSV = ma + " – " + ten;
            TreeNode nodeSV = new TreeNode(textSV);
            TreeNode nodeDiaChi = new TreeNode("Địa chỉ: " + diachi);

            nodeSV.Nodes.Add(nodeDiaChi);
            treeView1.SelectedNode.Nodes.Add(nodeSV);
            treeView1.SelectedNode.Expand();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Chưa chọn đối tượng để xóa!");
                return;
            }
            if (treeView1.SelectedNode.Parent == null)
            {
                MessageBox.Show("Không được xoá lớp!");
                return;
            }

            if (treeView1.SelectedNode.Parent.Parent == null)
            {
                DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xoá sinh viên này?",
                                                 "Xác nhận",
                                                 MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    treeView1.SelectedNode.Remove();
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn nút mã SV để xoá!");
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;

            if (node.Parent == null)
            {
                txtMaSV.Clear();
                txtHoTen.Clear();
                txtDiaChi.Clear();
                return;
            }
            if (node.Text.StartsWith("Địa chỉ:"))
            {
                txtDiaChi.Text = node.Text.Replace("Địa chỉ: ", "");
                node = node.Parent;
            }
            string[] parts = node.Text.Split('–'); // dấu dài ALT+0150
            txtMaSV.Text = parts[0].Trim();
            txtHoTen.Text = parts[1].Trim();
            if (node.Nodes.Count > 0)
            {
                txtDiaChi.Text = node.Nodes[0].Text.Replace("Địa chỉ: ", "");
            }
        }
    }
}
