namespace BTH2._1
{
    public partial class bai1 : Form
    {
        public bai1()
        {
            InitializeComponent();
        }
        int i = 10;
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;

        }

        private void btnDung_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblDongHo.Text = i.ToString(); i--;
            if (i < 0)
                this.timer1.Enabled = false;
        }

        private void lblDongHo_Click(object sender, EventArgs e)
        {

        }
    }
}
