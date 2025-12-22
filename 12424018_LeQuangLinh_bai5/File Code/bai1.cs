using Microsoft.Data.SqlClient;
using System.Data;

namespace BTH5
{
    public partial class bai1 : Form
    {
        private string connectionString =
        @"Server=LAPTOP-URJUI0ET;
          Database=sachdb;
          Integrated Security=True;
          TrustServerCertificate=True;";
        public bai1()
        {
            InitializeComponent();
        }

        private void bai1_Load(object sender, EventArgs e)
        {
            load_data();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button2.Enabled = false; //luu
            button3.Enabled = false;// Xóa
            button4.Enabled = false; // skipp
            LoadCategories();
        }
        private void LoadCategories()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM categories", con);
                    DataTable tb = new DataTable();
                    da.Fill(tb);

                    comboBox1.DataSource = tb;
                    comboBox1.DisplayMember = "categoryname"; 
                    comboBox1.ValueMember = "categoryid"; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh mục: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM products", con);
                    DataTable tb = new DataTable();
                    da.Fill(tb);
                    dataGridView1.DataSource = tb;
                    textBox1.DataBindings.Clear();
                    textBox2.DataBindings.Clear();
                    textBox3.DataBindings.Clear();
                    textBox4.DataBindings.Clear();
                    textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "productcode");
                    textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "Description");
                    textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "UnitPrice");
                    textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "OnHandQuantity");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e) //add
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox1.Text = "";// delete text
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            textBox1.Focus();
            button1.Enabled = false; 
            button3.Enabled = false; // Xóa
            button2.Enabled = true;  // Lưu
            button4.Enabled = true;  // akip
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã sách!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO products (productcode, description, unitprice, OnHandQuantity, categoryid) " +
                                   "VALUES (@productcode, @description, @unitprice, @onhandquantity, @categoryid)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@productcode", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@description", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@unitprice",
                        string.IsNullOrWhiteSpace(textBox3.Text) ? 0 : decimal.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@onhandquantity",
                        string.IsNullOrWhiteSpace(textBox4.Text) ? 0 : int.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@categoryid", comboBox1.SelectedValue);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Thêm sách thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_data();
                    button1.Enabled = true;
                    button2.Enabled = false;
                    button4.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa sách này không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(
                            "DELETE FROM products WHERE productcode = @productcode", con);
                        cmd.Parameters.AddWithValue("@productcode", textBox1.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Xóa sách thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        load_data();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            load_data();

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE products SET description=@description, unitprice=@unitprice, " +
                        "OnHandQuantity=@onhandquantity, categoryid=@categoryid " +
                        "WHERE productcode=@productcode", con);

                    cmd.Parameters.AddWithValue("@description", textBox2.Text);
                    cmd.Parameters.AddWithValue("@unitprice", decimal.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@onhandquantity", int.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@categoryid", comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@productcode", textBox1.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Cập nhật thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    load_data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null ||
        comboBox1.SelectedValue is DataRowView)
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT * FROM products WHERE categoryid=@categoryid", con);

                    da.SelectCommand.Parameters.AddWithValue(
                        "@categoryid", comboBox1.SelectedValue);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Chưa chọn sách để xóa!");
                return;
            }

            DialogResult kq = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sách này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(
                            "DELETE FROM products WHERE productcode=@productcode", con);

                        cmd.Parameters.AddWithValue("@productcode", textBox1.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xóa thành công!");

                    load_data();
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            load_data();

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            button1.Enabled = true;   
            button2.Enabled = false;  
            button3.Enabled = false; 
            button4.Enabled = false;
        }
    }
}
