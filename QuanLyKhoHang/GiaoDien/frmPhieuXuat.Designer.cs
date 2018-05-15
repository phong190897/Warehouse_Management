namespace QuanLyKhoHang.GiaoDien
{
    partial class frmPhieuXuat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuXuat));
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuuLai = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.btnXuatExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnInReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnLamMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnChiTietPhieuXuat = new DevExpress.XtraBars.BarButtonItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDonGiaXuat = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.cbb_TenHang = new System.Windows.Forms.ComboBox();
            this.cbb_TenKhachHang = new System.Windows.Forms.ComboBox();
            this.DTPNgayXuat = new System.Windows.Forms.DateTimePicker();
            this.txtMaPX = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.MaPhieuXuat = new DevExpress.XtraLayout.LayoutControlItem();
            this.NgayXuat = new DevExpress.XtraLayout.LayoutControlItem();
            this.TenKhachHang = new DevExpress.XtraLayout.LayoutControlItem();
            this.TenHang = new DevExpress.XtraLayout.LayoutControlItem();
            this.SoLuong = new DevExpress.XtraLayout.LayoutControlItem();
            this.DonGiaXuat = new DevExpress.XtraLayout.LayoutControlItem();
            this.lsvPhieuXuat = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsvCTPX = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dtpTimKiem = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPhieuXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonGiaXuat)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(109, 135);
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3,
            this.bar4});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnXoa,
            this.btnSua,
            this.btnLuuLai,
            this.btnHuy,
            this.btnLamMoi,
            this.btnXuatExcel,
            this.btnInReport,
            this.btnThoat,
            this.btnChiTietPhieuXuat});
            this.barManager1.MainMenu = this.bar3;
            this.barManager1.MaxItemId = 10;
            this.barManager1.StatusBar = this.bar4;
            // 
            // bar3
            // 
            this.bar3.BarName = "Main menu";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuuLai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHuy, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXuatExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnInReport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 1;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 2;
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.Name = "btnSua";
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnLuuLai
            // 
            this.btnLuuLai.Caption = "Lưu Lại";
            this.btnLuuLai.Id = 3;
            this.btnLuuLai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuLai.ImageOptions.Image")));
            this.btnLuuLai.Name = "btnLuuLai";
            this.btnLuuLai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuuLai_ItemClick);
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Hủy";
            this.btnHuy.Id = 4;
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.ImageOptions.Image")));
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHuy_ItemClick);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Caption = "Xuất Excel";
            this.btnXuatExcel.Id = 6;
            this.btnXuatExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.ImageOptions.Image")));
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXuatExcel_ItemClick);
            // 
            // btnInReport
            // 
            this.btnInReport.Caption = "In Report";
            this.btnInReport.Id = 7;
            this.btnInReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInReport.ImageOptions.Image")));
            this.btnInReport.Name = "btnInReport";
            this.btnInReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInReport_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 8;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // bar4
            // 
            this.bar4.BarName = "Status bar";
            this.bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar4.OptionsBar.AllowQuickCustomization = false;
            this.bar4.OptionsBar.DrawDragBorder = false;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1219, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 427);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1219, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 387);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1219, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 387);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Caption = "Làm Mới";
            this.btnLamMoi.Id = 5;
            this.btnLamMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.ImageOptions.Image")));
            this.btnLamMoi.Name = "btnLamMoi";
            // 
            // btnChiTietPhieuXuat
            // 
            this.btnChiTietPhieuXuat.Caption = "Chi Tiết Phiếu Xuất";
            this.btnChiTietPhieuXuat.Id = 9;
            this.btnChiTietPhieuXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChiTietPhieuXuat.ImageOptions.Image")));
            this.btnChiTietPhieuXuat.Name = "btnChiTietPhieuXuat";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtDonGiaXuat);
            this.layoutControl1.Controls.Add(this.txtSoLuong);
            this.layoutControl1.Controls.Add(this.cbb_TenHang);
            this.layoutControl1.Controls.Add(this.cbb_TenKhachHang);
            this.layoutControl1.Controls.Add(this.DTPNgayXuat);
            this.layoutControl1.Controls.Add(this.txtMaPX);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 40);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1219, 121);
            this.layoutControl1.TabIndex = 9;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDonGiaXuat
            // 
            this.txtDonGiaXuat.Location = new System.Drawing.Point(695, 86);
            this.txtDonGiaXuat.Name = "txtDonGiaXuat";
            this.txtDonGiaXuat.Size = new System.Drawing.Size(512, 20);
            this.txtDonGiaXuat.TabIndex = 11;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(97, 86);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(509, 20);
            this.txtSoLuong.TabIndex = 10;
            // 
            // cbb_TenHang
            // 
            this.cbb_TenHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TenHang.FormattingEnabled = true;
            this.cbb_TenHang.Location = new System.Drawing.Point(97, 61);
            this.cbb_TenHang.Name = "cbb_TenHang";
            this.cbb_TenHang.Size = new System.Drawing.Size(1110, 21);
            this.cbb_TenHang.TabIndex = 9;
            // 
            // cbb_TenKhachHang
            // 
            this.cbb_TenKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TenKhachHang.FormattingEnabled = true;
            this.cbb_TenKhachHang.Location = new System.Drawing.Point(97, 36);
            this.cbb_TenKhachHang.Name = "cbb_TenKhachHang";
            this.cbb_TenKhachHang.Size = new System.Drawing.Size(1110, 21);
            this.cbb_TenKhachHang.TabIndex = 8;
            // 
            // DTPNgayXuat
            // 
            this.DTPNgayXuat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPNgayXuat.Location = new System.Drawing.Point(695, 12);
            this.DTPNgayXuat.Name = "DTPNgayXuat";
            this.DTPNgayXuat.Size = new System.Drawing.Size(512, 20);
            this.DTPNgayXuat.TabIndex = 7;
            // 
            // txtMaPX
            // 
            this.txtMaPX.Location = new System.Drawing.Point(97, 12);
            this.txtMaPX.MenuManager = this.barManager1;
            this.txtMaPX.Name = "txtMaPX";
            this.txtMaPX.Size = new System.Drawing.Size(509, 20);
            this.txtMaPX.StyleController = this.layoutControl1;
            this.txtMaPX.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.MaPhieuXuat,
            this.NgayXuat,
            this.TenKhachHang,
            this.TenHang,
            this.SoLuong,
            this.DonGiaXuat});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1219, 121);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // MaPhieuXuat
            // 
            this.MaPhieuXuat.Control = this.txtMaPX;
            this.MaPhieuXuat.Location = new System.Drawing.Point(0, 0);
            this.MaPhieuXuat.Name = "MaPhieuXuat";
            this.MaPhieuXuat.Size = new System.Drawing.Size(598, 24);
            this.MaPhieuXuat.Text = "Mã Phiếu Xuất";
            this.MaPhieuXuat.TextSize = new System.Drawing.Size(82, 13);
            // 
            // NgayXuat
            // 
            this.NgayXuat.Control = this.DTPNgayXuat;
            this.NgayXuat.Location = new System.Drawing.Point(598, 0);
            this.NgayXuat.Name = "NgayXuat";
            this.NgayXuat.Size = new System.Drawing.Size(601, 24);
            this.NgayXuat.Text = "Ngày Xuất";
            this.NgayXuat.TextSize = new System.Drawing.Size(82, 13);
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.Control = this.cbb_TenKhachHang;
            this.TenKhachHang.Location = new System.Drawing.Point(0, 24);
            this.TenKhachHang.Name = "TenKhachHang";
            this.TenKhachHang.Size = new System.Drawing.Size(1199, 25);
            this.TenKhachHang.Text = "Tên Khách Hàng:";
            this.TenKhachHang.TextSize = new System.Drawing.Size(82, 13);
            // 
            // TenHang
            // 
            this.TenHang.Control = this.cbb_TenHang;
            this.TenHang.Location = new System.Drawing.Point(0, 49);
            this.TenHang.Name = "TenHang";
            this.TenHang.Size = new System.Drawing.Size(1199, 25);
            this.TenHang.Text = "Tên Hàng Hóa:";
            this.TenHang.TextSize = new System.Drawing.Size(82, 13);
            // 
            // SoLuong
            // 
            this.SoLuong.Control = this.txtSoLuong;
            this.SoLuong.Location = new System.Drawing.Point(0, 74);
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Size = new System.Drawing.Size(598, 27);
            this.SoLuong.Text = "Số Lượng:";
            this.SoLuong.TextSize = new System.Drawing.Size(82, 13);
            // 
            // DonGiaXuat
            // 
            this.DonGiaXuat.Control = this.txtDonGiaXuat;
            this.DonGiaXuat.Location = new System.Drawing.Point(598, 74);
            this.DonGiaXuat.Name = "DonGiaXuat";
            this.DonGiaXuat.Size = new System.Drawing.Size(601, 27);
            this.DonGiaXuat.Text = "Đơn Giá Xuất:";
            this.DonGiaXuat.TextSize = new System.Drawing.Size(82, 13);
            // 
            // lsvPhieuXuat
            // 
            this.lsvPhieuXuat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvPhieuXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvPhieuXuat.FullRowSelect = true;
            this.lsvPhieuXuat.GridLines = true;
            this.lsvPhieuXuat.Location = new System.Drawing.Point(3, 16);
            this.lsvPhieuXuat.MultiSelect = false;
            this.lsvPhieuXuat.Name = "lsvPhieuXuat";
            this.lsvPhieuXuat.Size = new System.Drawing.Size(454, 244);
            this.lsvPhieuXuat.TabIndex = 10;
            this.lsvPhieuXuat.UseCompatibleStateImageBehavior = false;
            this.lsvPhieuXuat.View = System.Windows.Forms.View.Details;
            this.lsvPhieuXuat.SelectedIndexChanged += new System.EventHandler(this.lsvPhieuXuat_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Phiếu Xuất";
            this.columnHeader1.Width = 98;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ngày Xuất";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên Khách Hàng";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Họ Tên Nhân Viên";
            this.columnHeader4.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsvPhieuXuat);
            this.groupBox1.Location = new System.Drawing.Point(0, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 263);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phiếu Xuất:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvCTPX);
            this.groupBox2.Location = new System.Drawing.Point(466, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(750, 263);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi Tiết Phiếu Xuất:";
            // 
            // lsvCTPX
            // 
            this.lsvCTPX.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lsvCTPX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvCTPX.Enabled = false;
            this.lsvCTPX.FullRowSelect = true;
            this.lsvCTPX.GridLines = true;
            this.lsvCTPX.Location = new System.Drawing.Point(3, 16);
            this.lsvCTPX.MultiSelect = false;
            this.lsvCTPX.Name = "lsvCTPX";
            this.lsvCTPX.Size = new System.Drawing.Size(744, 244);
            this.lsvCTPX.TabIndex = 0;
            this.lsvCTPX.UseCompatibleStateImageBehavior = false;
            this.lsvCTPX.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Mã Phiếu Xuất";
            this.columnHeader7.Width = 146;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tên Hàng";
            this.columnHeader8.Width = 312;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Số Lượng";
            this.columnHeader9.Width = 159;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Đơn Giá Xuất";
            this.columnHeader10.Width = 112;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTongTien);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblHoTen);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnTimKiem);
            this.groupBox3.Controls.Add(this.dtpTimKiem);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 161);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1219, 45);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm Kiếm:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(956, 19);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(132, 20);
            this.txtTongTien.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(890, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tổng Tiền:";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(692, 22);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(35, 13);
            this.lblHoTen.TabIndex = 4;
            this.lblHoTen.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(571, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Họ Tên Nhân Viên:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(403, 17);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Xóa";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(322, 16);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dtpTimKiem
            // 
            this.dtpTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTimKiem.Location = new System.Drawing.Point(12, 16);
            this.dtpTimKiem.Name = "dtpTimKiem";
            this.dtpTimKiem.Size = new System.Drawing.Size(294, 20);
            this.dtpTimKiem.TabIndex = 0;
            // 
            // frmPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmPhieuXuat";
            this.Text = "frmPhieuXuat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhieuXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPhieuXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonGiaXuat)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnLuuLai;
        private DevExpress.XtraBars.BarButtonItem btnHuy;
        private DevExpress.XtraBars.BarButtonItem btnLamMoi;
        private DevExpress.XtraBars.BarButtonItem btnXuatExcel;
        private DevExpress.XtraBars.BarButtonItem btnInReport;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private System.Windows.Forms.ListView lsvPhieuXuat;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.DateTimePicker DTPNgayXuat;
        private DevExpress.XtraEditors.TextEdit txtMaPX;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem MaPhieuXuat;
        private DevExpress.XtraLayout.LayoutControlItem NgayXuat;
        private DevExpress.XtraBars.BarButtonItem btnChiTietPhieuXuat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lsvCTPX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TextBox txtDonGiaXuat;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ComboBox cbb_TenHang;
        private System.Windows.Forms.ComboBox cbb_TenKhachHang;
        private DevExpress.XtraLayout.LayoutControlItem TenKhachHang;
        private DevExpress.XtraLayout.LayoutControlItem TenHang;
        private DevExpress.XtraLayout.LayoutControlItem SoLuong;
        private DevExpress.XtraLayout.LayoutControlItem DonGiaXuat;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DateTimePicker dtpTimKiem;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}