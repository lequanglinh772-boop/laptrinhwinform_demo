using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH5
{
    public partial class bai4 : Form
    {
        KetNoiDuLieubai2 kn = new KetNoiDuLieubai2();
        public bai4()
        {
            InitializeComponent();
        }

        private void bai4_Load(object sender, EventArgs e)
        {
            try
            {
                kn.myconnect();
                LoadClassToComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void LoadClassToComboBox()
        {
            string sql = "SELECT * FROM StudentClass ORDER BY classNo";
            DataTable dt = kn.taobang(sql);

            cboClassNo.DataSource = dt;
            cboClassNo.DisplayMember = "classNo";
            cboClassNo.ValueMember = "classNo";
        }

        private void cboClassNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClassNo.SelectedValue != null)
            {
                string classNo = cboClassNo.SelectedValue.ToString();
                LoadClassInfo(classNo);
                LoadStudents(classNo);
            }
        }
        private void LoadClassInfo(string classNo)
        {
            string sql = "SELECT * FROM StudentClass WHERE classNo = '" + classNo + "'";
            DataTable dt = kn.taobang(sql);

            if (dt.Rows.Count > 0)
            {
                txtHomeroom.Text = dt.Rows[0]["homeroomTeacher"].ToString();
                txtTotal.Text = dt.Rows[0]["totalStudent"].ToString();
            }
        }

        private void LoadStudents(string classNo)
        {
            string sql = @"SELECT 
                            stlName AS [Student Name],
                            FORMAT(stlYear, 'dd/MM/yyyy') AS [Birth Day],
                            address AS [Address]
                          FROM Student
                          WHERE classNo = '" + classNo + "' " +
                          "ORDER BY stlNo";

            DataTable dt = kn.taobang(sql);
            dgvStudents.DataSource = dt;

            // Tùy chỉnh độ rộng cột
            if (dgvStudents.Columns.Count > 0)
            {
                dgvStudents.Columns[0].Width = 200;
                dgvStudents.Columns[1].Width = 120;
                dgvStudents.Columns[2].Width = 200;
            }
        }
    }
}
