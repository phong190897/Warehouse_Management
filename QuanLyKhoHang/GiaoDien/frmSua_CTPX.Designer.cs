namespace QuanLyKhoHang.GiaoDien
{
    partial class frmSua_CTPX
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtTenKH = new DevExpress.XtraEditors.TextEdit();
            this.txtSoLuong = new DevExpress.XtraEditors.TextEdit();
            this.cbb_TenHang = new System.Windows.Forms.ComboBox();
            this.DTP_NgayXuat = new System.Windows.Forms.DateTimePicker();
            this.txtMaPX = new DevExpress.XtraEditors.TextEdit();
            this.txtDonGiaXuat = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.MaPX = new DevExpress.XtraLayout.LayoutControlItem();
            this.NgayXuat = new DevExpress.XtraLayout.LayoutControlItem();
            this.TenHang = new DevExpress.XtraLayout.LayoutControlItem();
            this.SoLuong = new DevExpress.XtraLayout.LayoutControlItem();
            this.DonGia = new DevExpress.XtraLayout.LayoutControlItem();
            this.TenKh = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lsvCTPX = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGiaXuat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenKh)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtTenKH);
            this.layoutControl1.Controls.Add(this.txtSoLuong);
            this.layoutControl1.Controls.Add(this.cbb_TenHang);
            this.layoutControl1.Controls.Add(this.DTP_NgayXuat);
            this.layoutControl1.Controls.Add(this.txtMaPX);
            this.layoutControl1.Controls.Add(this.txtDonGiaXuat);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(800, 120);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Enabled = false;
            this.txtTenKH.Location = new System.Drawing.Point(97, 61);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(691, 20);
            this.txtTenKH.StyleController = this.layoutControl1;
            this.txtTenKH.TabIndex = 9;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(97, 85);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Properties.MaxLength = 5;
            this.txtSoLuong.Size = new System.Drawing.Size(302, 20);
            this.txtSoLuong.StyleController = this.layoutControl1;
            this.txtSoLuong.TabIndex = 8;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // cbb_TenHang
            // 
            this.cbb_TenHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TenHang.FormattingEnabled = true;
            this.cbb_TenHang.Location = new System.Drawing.Point(97, 36);
            this.cbb_TenHang.Name = "cbb_TenHang";
            this.cbb_TenHang.Size = new System.Drawing.Size(691, 21);
            this.cbb_TenHang.TabIndex = 7;
            // 
            // DTP_NgayXuat
            // 
            this.DTP_NgayXuat.Enabled = false;
            this.DTP_NgayXuat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_NgayXuat.Location = new System.Drawing.Point(488, 12);
            this.DTP_NgayXuat.Name = "DTP_NgayXuat";
            this.DTP_NgayXuat.Size = new System.Drawing.Size(300, 20);
            this.DTP_NgayXuat.TabIndex = 5;
            // 
            // txtMaPX
            // 
            this.txtMaPX.Enabled = false;
            this.txtMaPX.Location = new System.Drawing.Point(97, 12);
            this.txtMaPX.Name = "txtMaPX";
            this.txtMaPX.Size = new System.Drawing.Size(302, 20);
            this.txtMaPX.StyleController = this.layoutControl1;
            this.txtMaPX.TabIndex = 4;
            // 
            // txtDonGiaXuat
            // 
            this.txtDonGiaXuat.Location = new System.Drawing.Point(488, 85);
            this.txtDonGiaXuat.Name = "txtDonGiaXuat";
            this.txtDonGiaXuat.Properties.MaxLength = 15;
            this.txtDonGiaXuat.Size = new System.Drawing.Size(300, 20);
            this.txtDonGiaXuat.StyleController = this.layoutControl1;
            this.txtDonGiaXuat.TabIndex = 8;
            this.txtDonGiaXuat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGiaXuat_KeyPress);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.MaPX,
            this.NgayXuat,
            this.TenHang,
            this.SoLuong,
            this.DonGia,
            this.TenKh});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 120);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // MaPX
            // 
            this.MaPX.Control = this.txtMaPX;
            this.MaPX.Location = new System.Drawing.Point(0, 0);
            this.MaPX.Name = "MaPX";
            this.MaPX.Size = new System.Drawing.Size(391, 24);
            this.MaPX.Text = "Mã Phiếu Xuất:";
            this.MaPX.TextSize = new System.Drawing.Size(82, 13);
            // 
            // NgayXuat
            // 
            this.NgayXuat.Control = this.DTP_NgayXuat;
            this.NgayXuat.Location = new System.Drawing.Point(391, 0);
            this.NgayXuat.Name = "NgayXuat";
            this.NgayXuat.Size = new System.Drawing.Size(389, 24);
            this.NgayXuat.Text = "Ngày Xuất:";
            this.NgayXuat.TextSize = new System.Drawing.Size(82, 13);
            // 
            // TenHang
            // 
            this.TenHang.Control = this.cbb_TenHang;
            this.TenHang.Location = new System.Drawing.Point(0, 24);
            this.TenHang.Name = "TenHang";
            this.TenHang.Size = new System.Drawing.Size(780, 25);
            this.TenHang.Text = "Tên Hàng:";
            this.TenHang.TextSize = new System.Drawing.Size(82, 13);
            // 
            // SoLuong
            // 
            this.SoLuong.Control = this.txtSoLuong;
            this.SoLuong.Location = new System.Drawing.Point(0, 73);
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Size = new System.Drawing.Size(391, 27);
            this.SoLuong.Text = "Số Lượng:";
            this.SoLuong.TextSize = new System.Drawing.Size(82, 13);
            // 
            // DonGia
            // 
            this.DonGia.Control = this.txtDonGiaXuat;
            this.DonGia.CustomizationFormText = "txtDonGiaXuat";
            this.DonGia.Location = new System.Drawing.Point(391, 73);
            this.DonGia.Name = "DonGia";
            this.DonGia.Size = new System.Drawing.Size(389, 27);
            this.DonGia.Text = "Đơn Giá Xuất:";
            this.DonGia.TextSize = new System.Drawing.Size(82, 13);
            // 
            // TenKh
            // 
            this.TenKh.Control = this.txtTenKH;
            this.TenKh.Location = new System.Drawing.Point(0, 49);
            this.TenKh.Name = "TenKh";
            this.TenKh.Size = new System.Drawing.Size(780, 24);
            this.TenKh.Text = "Tên Khách Hàng:";
            this.TenKh.TextSize = new System.Drawing.Size(82, 13);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(255, 19);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(174, 19);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(93, 19);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 19);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lsvCTPX
            // 
            this.lsvCTPX.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.lsvCTPX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvCTPX.FullRowSelect = true;
            this.lsvCTPX.GridLines = true;
            this.lsvCTPX.Location = new System.Drawing.Point(0, 176);
            this.lsvCTPX.MultiSelect = false;
            this.lsvCTPX.Name = "lsvCTPX";
            this.lsvCTPX.Size = new System.Drawing.Size(800, 274);
            this.lsvCTPX.TabIndex = 2;
            this.lsvCTPX.UseCompatibleStateImageBehavior = false;
            this.lsvCTPX.View = System.Windows.Forms.View.Details;
            this.lsvCTPX.SelectedIndexChanged += new System.EventHandler(this.lsvCTPX_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Hàng";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Hàng";
            this.columnHeader2.Width = 239;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số Lượng";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Đơn Giá";
            this.columnHeader5.Width = 118;
            // 
            // frmSua_CTPX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lsvCTPX);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmSua_CTPX";
            this.Text = "Sua_CTPX";
            this.Load += new System.EventHandler(this.frmSua_CTPX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGiaXuat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenKh)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtMaPX;
        private DevExpress.XtraLayout.LayoutControlItem MaPX;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtSoLuong;
        private System.Windows.Forms.ComboBox cbb_TenHang;
        private System.Windows.Forms.DateTimePicker DTP_NgayXuat;
        private DevExpress.XtraLayout.LayoutControlItem NgayXuat;
        private DevExpress.XtraLayout.LayoutControlItem TenHang;
        private DevExpress.XtraLayout.LayoutControlItem SoLuong;
        private DevExpress.XtraEditors.TextEdit txtDonGiaXuat;
        private DevExpress.XtraLayout.LayoutControlItem DonGia;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ListView lsvCTPX;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private DevExpress.XtraEditors.TextEdit txtTenKH;
        private DevExpress.XtraLayout.LayoutControlItem TenKh;
    }
}