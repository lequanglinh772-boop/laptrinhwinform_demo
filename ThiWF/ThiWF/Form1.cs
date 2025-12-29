using Microsoft.Data.SqlClient;
using System.Data;

namespace ThiWF
{
    public partial class Form1 : Form
    {
        KetnoiCSDL db = new KetnoiCSDL();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            LoadCategory();
            cboCategory.SelectedIndex = 0;
            LoadProduct();
        }
        void LoadCategory()
        {
            string sql = "SELECT CategoryID, CategoryName FROM Category";
            cboCategory.DataSource = db.GetData(sql);
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryID";
        }
        void LoadProduct()
        {
            if (cboCategory.SelectedValue == null) return;

            string sql = @"SELECT ProductID, ProductName, Price, Quantity
                           FROM Product WHERE CategoryID=@cid";

            SqlParameter[] p =
            {
                new SqlParameter("@cid", cboCategory.SelectedValue)
            };

            dgvProduct.DataSource = db.GetData(sql, p);
            dgvProduct.Columns["ProductID"].Visible = false;
        }
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow == null) return;

            int id = (int)dgvProduct.CurrentRow.Cells["ProductID"].Value;

            string sql = @"UPDATE Product
                           SET ProductName=@n, Price=@p, Quantity=@q
                           WHERE ProductID=@id";

            SqlParameter[] p =
            {
                new SqlParameter("@n", txtName.Text),
                new SqlParameter("@p", decimal.Parse(txtPrice.Text)),
                new SqlParameter("@q", int.Parse(txtQuantity.Text)),
                new SqlParameter("@id", id)
            };

            db.ExecuteSQL(sql, p);
            LoadProduct();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Chưa nhập tên sản phẩm!");
                txtName.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá phải là số!");
                txtPrice.Focus();
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Số lượng phải là số nguyên!");
                txtQuantity.Focus();
                return;
            }

            int categoryId = Convert.ToInt32(cboCategory.SelectedValue);

            string sql = @"INSERT INTO Product(ProductName, Price, Quantity, CategoryID)
                   VALUES (@n, @p, @q, @c)";

            SqlParameter[] p =
            {
        new SqlParameter("@n", txtName.Text),
        new SqlParameter("@p", price),
        new SqlParameter("@q", quantity),
        new SqlParameter("@c", categoryId)
            };
            db.ExecuteSQL(sql, p);
            LoadProduct();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow == null) return;

            int id = (int)dgvProduct.CurrentRow.Cells["ProductID"].Value;

            string sql = "DELETE FROM Product WHERE ProductID=@id";

            SqlParameter[] p =
            {
                new SqlParameter("@id", id)
            };

            db.ExecuteSQL(sql, p);
            LoadProduct();
        }
        void LoadProductSort()
        {
            int cid = Convert.ToInt32(cboCategory.SelectedValue);

            string sql = @"SELECT ProductID, ProductName, Price, Quantity
                   FROM Product
                   WHERE CategoryID = @cid";
            if (rdoTangGia.Checked || rdoThapCao.Checked)
                sql += " ORDER BY Price ASC";
            else if (rdoGiamGia.Checked || rdoCaoThap.Checked)
                sql += " ORDER BY Price DESC";

            SqlParameter[] p =
            {
        new SqlParameter("@cid", cid)
    };

            dgvProduct.DataSource = db.GetData(sql, p);
        }


        private void rdoTangGia_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTangGia.Checked)
                LoadProductSort();
        }

        private void rdoGiamGia_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGiamGia.Checked)
                LoadProductSort();
        }

        private void rdoCaoThap_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCaoThap.Checked)
                LoadProductSort();
        }

        private void rdoThapCao_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoThapCao.Checked)
                LoadProductSort();
        }

        private void cboCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboCategory.SelectedValue == null)
                return;
            if (cboCategory.SelectedValue is DataRowView)
                return;
            LoadProductSort();
        }
    }
}

