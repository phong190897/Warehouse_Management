namespace QuanLyKhoHang.GiaoDien
{
    partial class frmSua_CTPN
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
            this.txtSoLuong = new DevExpress.XtraEditors.TextEdit();
            this.txtDonGiaNhap = new DevExpress.XtraEditors.TextEdit();
            this.cbb_TenHang = new System.Windows.Forms.ComboBox();
            this.DTP_NgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtMaPN = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.MaPN = new DevExpress.XtraLayout.LayoutControlItem();
            this.TenHang = new DevExpress.XtraLayout.LayoutControlItem();
            this.NgayNhap = new DevExpress.XtraLayout.LayoutControlItem();
            this.DonGiaNhap = new DevExpress.XtraLayout.LayoutControlItem();
            this.SoLuong = new DevExpress.XtraLayout.LayoutControlItem();
            this.lsvSua_CTPN = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGiaNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonGiaNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoLuong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtSoLuong);
            this.layoutControl1.Controls.Add(this.txtDonGiaNhap);
            this.layoutControl1.Controls.Add(this.cbb_TenHang);
            this.layoutControl1.Controls.Add(this.DTP_NgayNhap);
            this.layoutControl1.Controls.Add(this.txtMaPN);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(800, 100);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(90, 61);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(308, 20);
            this.txtSoLuong.StyleController = this.layoutControl1;
            this.txtSoLuong.TabIndex = 1;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // txtDonGiaNhap
            // 
            this.txtDonGiaNhap.Location = new System.Drawing.Point(480, 61);
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Size = new System.Drawing.Size(308, 20);
            this.txtDonGiaNhap.StyleController = this.layoutControl1;
            this.txtDonGiaNhap.TabIndex = 9;
            this.txtDonGiaNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGiaNhap_KeyPress);
            // 
            // cbb_TenHang
            // 
            this.cbb_TenHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TenHang.FormattingEnabled = true;
            this.cbb_TenHang.Location = new System.Drawing.Point(90, 36);
            this.cbb_TenHang.Name = "cbb_TenHang";
            this.cbb_TenHang.Size = new System.Drawing.Size(698, 21);
            this.cbb_TenHang.TabIndex = 8;
            // 
            // DTP_NgayNhap
            // 
            this.DTP_NgayNhap.Enabled = false;
            this.DTP_NgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_NgayNhap.Location = new System.Drawing.Point(480, 12);
            this.DTP_NgayNhap.Name = "DTP_NgayNhap";
            this.DTP_NgayNhap.Size = new System.Drawing.Size(308, 20);
            this.DTP_NgayNhap.TabIndex = 5;
            // 
            // txtMaPN
            // 
            this.txtMaPN.Enabled = false;
            this.txtMaPN.Location = new System.Drawing.Point(90, 12);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.Size = new System.Drawing.Size(308, 20);
            this.txtMaPN.StyleController = this.layoutControl1;
            this.txtMaPN.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.MaPN,
            this.TenHang,
            this.NgayNhap,
            this.DonGiaNhap,
            this.SoLuong});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 100);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // MaPN
            // 
            this.MaPN.Control = this.txtMaPN;
            this.MaPN.Location = new System.Drawing.Point(0, 0);
            this.MaPN.Name = "MaPN";
            this.MaPN.Size = new System.Drawing.Size(390, 24);
            this.MaPN.Text = "Mã Phiếu Nhập:";
            this.MaPN.TextSize = new System.Drawing.Size(75, 13);
            // 
            // TenHang
            // 
            this.TenHang.Control = this.cbb_TenHang;
            this.TenHang.Location = new System.Drawing.Point(0, 24);
            this.TenHang.Name = "TenHang";
            this.TenHang.Size = new System.Drawing.Size(780, 25);
            this.TenHang.Text = "Tên Hàng:";
            this.TenHang.TextSize = new System.Drawing.Size(75, 13);
            // 
            // NgayNhap
            // 
            this.NgayNhap.Control = this.DTP_NgayNhap;
            this.NgayNhap.Location = new System.Drawing.Point(390, 0);
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.Size = new System.Drawing.Size(390, 24);
            this.NgayNhap.Text = "Ngày Nhập: ";
            this.NgayNhap.TextSize = new System.Drawing.Size(75, 13);
            // 
            // DonGiaNhap
            // 
            this.DonGiaNhap.Control = this.txtDonGiaNhap;
            this.DonGiaNhap.Location = new System.Drawing.Point(390, 49);
            this.DonGiaNhap.Name = "DonGiaNhap";
            this.DonGiaNhap.Size = new System.Drawing.Size(390, 31);
            this.DonGiaNhap.Text = "Đơn Giá Nhập:";
            this.DonGiaNhap.TextSize = new System.Drawing.Size(75, 13);
            // 
            // SoLuong
            // 
            this.SoLuong.Control = this.txtSoLuong;
            this.SoLuong.Location = new System.Drawing.Point(0, 49);
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Size = new System.Drawing.Size(390, 31);
            this.SoLuong.Text = "Số Lượng:";
            this.SoLuong.TextSize = new System.Drawing.Size(75, 13);
            // 
            // lsvSua_CTPN
            // 
            this.lsvSua_CTPN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvSua_CTPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsvSua_CTPN.FullRowSelect = true;
            this.lsvSua_CTPN.GridLines = true;
            this.lsvSua_CTPN.Location = new System.Drawing.Point(0, 148);
            this.lsvSua_CTPN.MultiSelect = false;
            this.lsvSua_CTPN.Name = "lsvSua_CTPN";
            this.lsvSua_CTPN.Size = new System.Drawing.Size(800, 302);
            this.lsvSua_CTPN.TabIndex = 1;
            this.lsvSua_CTPN.UseCompatibleStateImageBehavior = false;
            this.lsvSua_CTPN.View = System.Windows.Forms.View.Details;
            this.lsvSua_CTPN.SelectedIndexChanged += new System.EventHandler(this.lsvSua_CTPN_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Hàng";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Hàng";
            this.columnHeader2.Width = 289;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số Lượng";
            this.columnHeader3.Width = 116;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn Giá Nhập";
            this.columnHeader4.Width = 168;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 52);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnThem
            // 
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThem.Location = new System.Drawing.Point(12, 19);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Location = new System.Drawing.Point(255, 19);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoa.Location = new System.Drawing.Point(174, 19);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSua.Location = new System.Drawing.Point(93, 19);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // frmSua_CTPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsvSua_CTPN);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmSua_CTPN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa Chi Tiết Phiếu Nhập";
            this.Load += new System.EventHandler(this.frmSua_CTPN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGiaNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonGiaNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoLuong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtSoLuong;
        private DevExpress.XtraEditors.TextEdit txtDonGiaNhap;
        private System.Windows.Forms.ComboBox cbb_TenHang;
        private System.Windows.Forms.DateTimePicker DTP_NgayNhap;
        private DevExpress.XtraEditors.TextEdit txtMaPN;
        private DevExpress.XtraLayout.LayoutControlItem MaPN;
        private DevExpress.XtraLayout.LayoutControlItem TenHang;
        private DevExpress.XtraLayout.LayoutControlItem NgayNhap;
        private DevExpress.XtraLayout.LayoutControlItem DonGiaNhap;
        private DevExpress.XtraLayout.LayoutControlItem SoLuong;
        private System.Windows.Forms.ListView lsvSua_CTPN;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
    }
}