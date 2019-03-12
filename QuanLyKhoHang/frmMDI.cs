using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QuanLyKhoHang.GiaoDien;
using System.Windows.Forms;
using System.Threading;
using QuanLyKhoHang.GiaoDien_Report;
using QuanLyKhoHang.XuLi;

namespace QuanLyKhoHang
{
    public partial class frmMDI : DevExpress.XtraEditors.XtraForm
    {

        public static string svrName = ".\\SQLEXPRESS";
        public static string dbName = "DoAnCoSo";
        public static bool intergratedMode = true;
        public static string usrName = "";
        public static string pwd = "";
        public string ID_DangNhap = "";
        DataTable dt;
        HangHoa hh;
        public static string Quyendn;

        public frmMDI(string hoten, string quyendn, string TG_DN, string tentk)
        {
            InitializeComponent();
            lb_TenTK.Text = hoten;
            lb_TG_DN.Text = TG_DN;
            ID_DangNhap = tentk;
            Quyendn = quyendn;
            hh = new HangHoa();
            dt = new DataTable();
            //Thread t = new Thread(new ThreadStart(StartForm));
            //t.Start();
            //Thread.Sleep(5000);
            //t.Abort();
        }

        public void SetButton(bool value)
        {
            btnDangNhap.Enabled  = value;
            btnDangXuat.Enabled  = !value;
            btnDMHH.Enabled      = !value;
            btnHangHoa.Enabled   = !value;
            btnKhachHang.Enabled = !value;
            btnLoaiSP.Enabled    = !value;
            btnNhaCC.Enabled     = !value;
            btnPhieuNhap.Enabled = !value;
            btnPhieuXuat.Enabled = !value;
        }

        private Form KiemTraTonTai(Type fType)
        {
            foreach(Form f in this.MdiChildren)
            {
                if(f.GetType() == fType) // Nếu form được truyền đã được mở
                {
                    return f;
                }
            }
            return null;
        }

        private void btnNhaCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmNCC = this.KiemTraTonTai(typeof(frmNhaCC));
            if(frmNCC != null)
            {
                frmNCC.Activate();
            }
            else
            {
                frmNhaCC fncc = new frmNhaCC();
                fncc.MdiParent = this;
                fncc.Show();
            }
        }

        private void btnKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmKH = this.KiemTraTonTai(typeof(frmKhachHang));
            if(frmKH != null)
            {
                frmKH.Activate();
            }
            else
            {
                frmKhachHang fkh = new frmKhachHang();
                fkh.MdiParent = this;
                fkh.Show();
            }
        }

        private void btnLoaiSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmLSP = this.KiemTraTonTai(typeof(frmLoaiSP));
            if (frmLSP != null)
            {
                frmLSP.Activate();
            }
            else
            {
                frmLoaiSP flsp = new frmLoaiSP();
                flsp.MdiParent = this;
                flsp.Show();
            }
        }

        private void btnDMHH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmDMHH = this.KiemTraTonTai(typeof(frmDMHH));
            if (frmDMHH != null)
            {
                frmDMHH.Activate();
            }
            else
            {
                frmDMHH fdmhh = new frmDMHH();
                fdmhh.MdiParent = this;
                fdmhh.Show();
            }
        }

        private void btnPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmPX = this.KiemTraTonTai(typeof(frmPhieuXuat));
            if (frmPX != null)
            {
                frmPX.Activate();
            }
            else
            {
                frmPhieuXuat fpx = new frmPhieuXuat(lb_TenTK.Text, ID_DangNhap);
                fpx.MdiParent = this;
                fpx.Show();
            }
        }

        private void btnPhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmPN = this.KiemTraTonTai(typeof(frmPhieuNhap));
            if (frmPN != null)
            {
                frmPN.Activate();
            }
            else
            {
                frmPhieuNhap fpn = new frmPhieuNhap(lb_TenTK.Text, ID_DangNhap);
                fpn.MdiParent = this;
                fpn.Show();
            }
        }

        public void skin()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel theme = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            theme.LookAndFeel.SkinName = "Office 2010 Blue";
        }

        //public void StartForm()
        //{
        //    Application.Run(new frmSplashScreen());
        //}

        private void frmMDI_Load(object sender, EventArgs e)
        {
            skin();
          
                dt = hh.KiemTraHang();
                System.Text.StringBuilder b = new System.Text.StringBuilder();
                foreach (System.Data.DataRow r in dt.Rows)
                {
                    
                    foreach (System.Data.DataColumn c in dt.Columns)
                    {
                        b.Append( c.ColumnName.ToString() + ":  " + r[c.ColumnName].ToString() + "\n");
                    }
                    b.Append("\n");
                }
                MessageBox.Show("\aCác mặt hàng sau cần phải nhập hàng: \n\n"  + b.ToString(), "Thông báo nhập hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //SetButton(true);
            
        }

        private void btnHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmHH = this.KiemTraTonTai(typeof(frmHangHoa));
            if (frmHH != null)
            {
                frmHH.Activate();
            }
            else
            {
                frmHangHoa fhh = new frmHangHoa();
                fhh.MdiParent = this;
                fhh.Show();
            }
        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLogin frmlogin = new frmLogin();
            frmlogin.ShowDialog();
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetButton(true);
            lb_TenTK.Text = "Chưa Đăng Nhập";
            lb_TG_DX.Text = DateTime.Now.ToLocalTime().ToString();
            frmLogin frmlogin = new frmLogin();
            frmlogin.Show();
            this.Close();
        }

        private void btn_RP_Nhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmDS_Nhap = this.KiemTraTonTai(typeof(frmDS_PhieuNhap));
            if (frmDS_Nhap != null)
            {
                frmDS_Nhap.Activate();
            }
            else
            {
                frmDS_PhieuNhap fdsn = new frmDS_PhieuNhap();
                fdsn.MdiParent = this;
                fdsn.Show();
            }
        }

        private void btn_RP_Xuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmDS_Xuat = this.KiemTraTonTai(typeof(frmDS_PhieuXuat));
            if (frmDS_Xuat != null)
            {
                frmDS_Xuat.Activate();
            }
            else
            {
                frmDS_PhieuXuat fdsx = new frmDS_PhieuXuat();
                fdsx.MdiParent = this;
                fdsx.Show();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm_TonKho = this.KiemTraTonTai(typeof(frm_rp_TonKho));
            if (frm_TonKho != null)
            {
                frm_TonKho.Activate();
            }
            else
            {
                frm_rp_TonKho f_rp_tk = new frm_rp_TonKho();
                f_rp_tk.MdiParent = this;
                f_rp_tk.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm_nhap_thang = this.KiemTraTonTai(typeof(frm_rp_Nhap_TrongThang));
            if (frm_nhap_thang != null)
            {
                frm_nhap_thang.Activate();
            }
            else
            {
                frm_rp_Nhap_TrongThang f_rp_tk = new frm_rp_Nhap_TrongThang();
                f_rp_tk.MdiParent = this;
                f_rp_tk.Show();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm_TonKho = this.KiemTraTonTai(typeof(frm_rp_Xuat_TrongThang));
            if (frm_TonKho != null)
            {
                frm_TonKho.Activate();
            }
            else
            {
                frm_rp_Xuat_TrongThang f_rp_tk = new frm_rp_Xuat_TrongThang();
                f_rp_tk.MdiParent = this;
                f_rp_tk.Show();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm_TK = this.KiemTraTonTai(typeof(frm_TaiKhoan));
            if (frm_TK != null)
            {
                frm_TK.Activate();
            }
            else
            {
                frm_TaiKhoan f_tk = new frm_TaiKhoan();
                f_tk.MdiParent = this;
                f_tk.Show();
            }
        }
    }
}
