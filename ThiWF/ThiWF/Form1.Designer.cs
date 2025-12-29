namespace ThiWF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboCategory = new ComboBox();
            txtPrice = new TextBox();
            dgvProduct = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtName = new TextBox();
            txtQuantity = new TextBox();
            btnadd = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnHienThi = new Button();
            rdoCaoThap = new RadioButton();
            rdoThapCao = new RadioButton();
            rdoTangGia = new RadioButton();
            rdoGiamGia = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            SuspendLayout();
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(229, 41);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(300, 28);
            cboCategory.TabIndex = 0;
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged_1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(229, 108);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(300, 27);
            txtPrice.TabIndex = 1;
            // 
            // dgvProduct
            // 
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduct.Location = new Point(12, 192);
            dgvProduct.Name = "dgvProduct";
            dgvProduct.RowHeadersWidth = 51;
            dgvProduct.Size = new Size(776, 188);
            dgvProduct.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 41);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 3;
            label1.Text = "Chọn loại sản phẩm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 82);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 4;
            label2.Text = "Tên Sản Phẩm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(122, 111);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 5;
            label3.Text = "Giá ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(122, 142);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 7;
            label4.Text = "Số Lượng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(272, 9);
            label5.Name = "label5";
            label5.Size = new Size(257, 25);
            label5.TabIndex = 6;
            label5.Text = "Quản Lí Sản Phẩm Theo Loại";
            // 
            // txtName
            // 
            txtName.Location = new Point(229, 75);
            txtName.Name = "txtName";
            txtName.Size = new Size(300, 27);
            txtName.TabIndex = 8;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(229, 139);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(300, 27);
            txtQuantity.TabIndex = 9;
            // 
            // btnadd
            // 
            btnadd.Location = new Point(57, 386);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(144, 29);
            btnadd.TabIndex = 10;
            btnadd.Text = "Thêm";
            btnadd.UseVisualStyleBackColor = true;
            btnadd.Click += btnadd_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(247, 386);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(125, 29);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(421, 386);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(133, 29);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnHienThi
            // 
            btnHienThi.Location = new Point(599, 386);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(166, 29);
            btnHienThi.TabIndex = 12;
            btnHienThi.Text = "Hiển thị theo loại";
            btnHienThi.UseVisualStyleBackColor = true;
            // 
            // rdoCaoThap
            // 
            rdoCaoThap.AutoSize = true;
            rdoCaoThap.Location = new Point(631, 45);
            rdoCaoThap.Name = "rdoCaoThap";
            rdoCaoThap.Size = new Size(128, 24);
            rdoCaoThap.TabIndex = 14;
            rdoCaoThap.TabStop = true;
            rdoCaoThap.Text = "Giá cao > thấp";
            rdoCaoThap.UseVisualStyleBackColor = true;
            rdoCaoThap.CheckedChanged += rdoCaoThap_CheckedChanged;
            // 
            // rdoThapCao
            // 
            rdoThapCao.AutoSize = true;
            rdoThapCao.Location = new Point(631, 75);
            rdoThapCao.Name = "rdoThapCao";
            rdoThapCao.Size = new Size(133, 24);
            rdoThapCao.TabIndex = 15;
            rdoThapCao.TabStop = true;
            rdoThapCao.Text = "Giá Thấp > Cao";
            rdoThapCao.UseVisualStyleBackColor = true;
            rdoThapCao.CheckedChanged += rdoThapCao_CheckedChanged;
            // 
            // rdoTangGia
            // 
            rdoTangGia.AutoSize = true;
            rdoTangGia.Location = new Point(631, 105);
            rdoTangGia.Name = "rdoTangGia";
            rdoTangGia.Size = new Size(157, 24);
            rdoTangGia.TabIndex = 16;
            rdoTangGia.TabStop = true;
            rdoTangGia.Text = "Sản Phẩm Tăng Giá";
            rdoTangGia.UseVisualStyleBackColor = true;
            rdoTangGia.CheckedChanged += rdoTangGia_CheckedChanged;
            // 
            // rdoGiamGia
            // 
            rdoGiamGia.AutoSize = true;
            rdoGiamGia.Location = new Point(630, 135);
            rdoGiamGia.Name = "rdoGiamGia";
            rdoGiamGia.Size = new Size(158, 24);
            rdoGiamGia.TabIndex = 17;
            rdoGiamGia.TabStop = true;
            rdoGiamGia.Text = "Sản Phẩm giảm giá";
            rdoGiamGia.UseVisualStyleBackColor = true;
            rdoGiamGia.CheckedChanged += rdoGiamGia_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rdoGiamGia);
            Controls.Add(rdoTangGia);
            Controls.Add(rdoThapCao);
            Controls.Add(rdoCaoThap);
            Controls.Add(btnXoa);
            Controls.Add(btnHienThi);
            Controls.Add(btnSua);
            Controls.Add(btnadd);
            Controls.Add(txtQuantity);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvProduct);
            Controls.Add(txtPrice);
            Controls.Add(cboCategory);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboCategory;
        private TextBox txtPrice;
        private DataGridView dgvProduct;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtName;
        private TextBox txtQuantity;
        private Button btnadd;
        private Button btnSua;
        private Button btnXoa;
        private Button btnHienThi;
        private RadioButton rdoCaoThap;
        private RadioButton rdoThapCao;
        private RadioButton rdoTangGia;
        private RadioButton rdoGiamGia;
    }
}
