namespace Baith1
{
    public partial class bai1 : Form
    {
        public bai1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string thongbao;
            thongbao = "Tên đăng nhập là: ";
            thongbao += this.txtUser.Text;
            thongbao += "\n\rMật khẩu là: ";
            thongbao += this.txtPass.Text;
            if (this.chkNho.Checked == true)
            { thongbao += "\n\rBạn có ghi nhớ."; }
            MessageBox.Show(thongbao, "Thông báo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtUser.Clear(); this.txtPass.Clear(); this.txtUser.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
