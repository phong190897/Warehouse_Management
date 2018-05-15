namespace QuanLyKhoHang.GiaoDien
{
    partial class frmThem_CTPN
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
            this.txtDonGiaNhap = new DevExpress.XtraEditors.TextEdit();
            this.txtSoLuong = new DevExpress.XtraEditors.TextEdit();
            this.DTP_NgayNhap = new System.Windows.Forms.DateTimePicker();
            this.cbb_TenHang = new System.Windows.Forms.ComboBox();
            this.txtMaPN = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.MaPN = new DevExpress.XtraLayout.LayoutControlItem();
            this.TenHang = new DevExpress.XtraLayout.LayoutControlItem();
            this.NgayNhap = new DevExpress.XtraLayout.LayoutControlItem();
            this.SoLuong = new DevExpress.XtraLayout.LayoutControlItem();
            this.DonGiaNhap = new DevExpress.XtraLayout.LayoutControlItem();
            this.lsvThemPN_CTPN = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuuLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGiaNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonGiaNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtDonGiaNhap);
            this.layoutControl1.Controls.Add(this.txtSoLuong);
            this.layoutControl1.Controls.Add(this.DTP_NgayNhap);
            this.layoutControl1.Controls.Add(this.cbb_TenHang);
            this.layoutControl1.Controls.Add(this.txtMaPN);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(800, 97);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDonGiaNhap
            // 
            this.txtDonGiaNhap.Location = new System.Drawing.Point(480, 61);
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Properties.MaxLength = 15;
            this.txtDonGiaNhap.Size = new System.Drawing.Size(308, 20);
            this.txtDonGiaNhap.StyleController = this.layoutControl1;
            this.txtDonGiaNhap.TabIndex = 3;
            this.txtDonGiaNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGiaNhap_KeyPress);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(90, 61);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Properties.MaxLength = 5;
            this.txtSoLuong.Size = new System.Drawing.Size(308, 20);
            this.txtSoLuong.StyleController = this.layoutControl1;
            this.txtSoLuong.TabIndex = 2;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // DTP_NgayNhap
            // 
            this.DTP_NgayNhap.Enabled = false;
            this.DTP_NgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_NgayNhap.Location = new System.Drawing.Point(480, 12);
            this.DTP_NgayNhap.Name = "DTP_NgayNhap";
            this.DTP_NgayNhap.Size = new System.Drawing.Size(308, 20);
            this.DTP_NgayNhap.TabIndex = 6;
            // 
            // cbb_TenHang
            // 
            this.cbb_TenHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TenHang.FormattingEnabled = true;
            this.cbb_TenHang.Location = new System.Drawing.Point(90, 36);
            this.cbb_TenHang.Name = "cbb_TenHang";
            this.cbb_TenHang.Size = new System.Drawing.Size(698, 21);
            this.cbb_TenHang.TabIndex = 1;
            // 
            // txtMaPN
            // 
            this.txtMaPN.Enabled = false;
            this.txtMaPN.Location = new System.Drawing.Point(90, 12);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.Size = new System.Drawing.Size(308, 20);
            this.txtMaPN.StyleController = this.layoutControl1;
            this.txtMaPN.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.MaPN,
            this.TenHang,
            this.NgayNhap,
            this.SoLuong,
            this.DonGiaNhap});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 97);
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
            this.NgayNhap.Text = "Ngày Nhập:";
            this.NgayNhap.TextSize = new System.Drawing.Size(75, 13);
            // 
            // SoLuong
            // 
            this.SoLuong.Control = this.txtSoLuong;
            this.SoLuong.Location = new System.Drawing.Point(0, 49);
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Size = new System.Drawing.Size(390, 28);
            this.SoLuong.Text = "Số Lượng:";
            this.SoLuong.TextSize = new System.Drawing.Size(75, 13);
            // 
            // DonGiaNhap
            // 
            this.DonGiaNhap.Control = this.txtDonGiaNhap;
            this.DonGiaNhap.Location = new System.Drawing.Point(390, 49);
            this.DonGiaNhap.Name = "DonGiaNhap";
            this.DonGiaNhap.Size = new System.Drawing.Size(390, 28);
            this.DonGiaNhap.Text = "Đơn Giá Nhập:";
            this.DonGiaNhap.TextSize = new System.Drawing.Size(75, 13);
            // 
            // lsvThemPN_CTPN
            // 
            this.lsvThemPN_CTPN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lsvThemPN_CTPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.lsvThemPN_CTPN.FullRowSelect = true;
            this.lsvThemPN_CTPN.GridLines = true;
            this.lsvThemPN_CTPN.Location = new System.Drawing.Point(0, 97);
            this.lsvThemPN_CTPN.MultiSelect = false;
            this.lsvThemPN_CTPN.Name = "lsvThemPN_CTPN";
            this.lsvThemPN_CTPN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lsvThemPN_CTPN.Size = new System.Drawing.Size(800, 164);
            this.lsvThemPN_CTPN.TabIndex = 2;
            this.lsvThemPN_CTPN.UseCompatibleStateImageBehavior = false;
            this.lsvThemPN_CTPN.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã Hàng";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tên Hàng";
            this.columnHeader6.Width = 280;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Số Lượng";
            this.columnHeader7.Width = 142;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Đơn Giá Nhập";
            this.columnHeader8.Width = 190;
            // 
            // btnThoat
            // 
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Location = new System.Drawing.Point(698, 276);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 29);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThem
            // 
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThem.Location = new System.Drawing.Point(21, 276);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 29);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoa.Location = new System.Drawing.Point(113, 276);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 29);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuuLai
            // 
            this.btnLuuLai.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLuuLai.Location = new System.Drawing.Point(608, 276);
            this.btnLuuLai.Name = "btnLuuLai";
            this.btnLuuLai.Size = new System.Drawing.Size(75, 29);
            this.btnLuuLai.TabIndex = 7;
            this.btnLuuLai.Text = "Lưu Lại";
            this.btnLuuLai.UseVisualStyleBackColor = true;
            this.btnLuuLai.Click += new System.EventHandler(this.btnLuuLai_Click);
            // 
            // frmThem_CTPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 319);
            this.Controls.Add(this.btnLuuLai);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lsvThemPN_CTPN);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmThem_CTPN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Vào Chi Tiết Phiếu Nhập";
            this.Load += new System.EventHandler(this.frmThem_CTPN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGiaNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonGiaNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.ComboBox cbb_TenHang;
        private DevExpress.XtraEditors.TextEdit txtMaPN;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem MaPN;
        private DevExpress.XtraLayout.LayoutControlItem TenHang;
        private System.Windows.Forms.DateTimePicker DTP_NgayNhap;
        private DevExpress.XtraLayout.LayoutControlItem NgayNhap;
        private DevExpress.XtraEditors.TextEdit txtDonGiaNhap;
        private DevExpress.XtraEditors.TextEdit txtSoLuong;
        private DevExpress.XtraLayout.LayoutControlItem SoLuong;
        private DevExpress.XtraLayout.LayoutControlItem DonGiaNhap;
        private System.Windows.Forms.ListView lsvThemPN_CTPN;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnLuuLai;
    }
}