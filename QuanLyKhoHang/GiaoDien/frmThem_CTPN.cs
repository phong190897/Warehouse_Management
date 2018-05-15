using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhoHang.XuLi;
using QuanLyKhoHang.GiaoDien;

namespace QuanLyKhoHang.GiaoDien
{
    public partial class frmThem_CTPN : Form
    {
        Them_CTPN them;
        PhieuNhap pn;
        frmLogin lg;
        frmPhieuNhap frm_pn;
        DataTable dt;
        public string pn_Moi = "";
        public string tenTK = "";

        public frmThem_CTPN(string ID_DangNhap)
        {
            InitializeComponent();
            pn = new PhieuNhap();
            dt = new DataTable();
            them = new Them_CTPN();
            frm_pn = new frmPhieuNhap("", "");
            lg = new frmLogin();
            tenTK = ID_DangNhap;
        }

        public void HienThiDS_HH()
        {
            DataTable dt_hh = pn.LayDS_HH();
            cbb_TenHang.DataSource = dt_hh;
            cbb_TenHang.DisplayMember = "TenHang";
            cbb_TenHang.ValueMember = "MaHang";
            if (cbb_TenHang.Items.Count > 0)
                cbb_TenHang.SelectedIndex = 0;
        }

        public void ThemHang_VaoListView()
        {
            if (txtSoLuong.Text != "")
            {
                if (txtDonGiaNhap.Text != "")
                {
                    string ngay = String.Format("{0:MM/dd/yyyy}", DTP_NgayNhap.Value);
                    string mahang = cbb_TenHang.SelectedValue.ToString();
                    ListViewItem lvi;
                    lvi = lsvThemPN_CTPN.Items.Add(cbb_TenHang.SelectedValue.ToString());
                    lvi.SubItems.Add(cbb_TenHang.Text);
                    lvi.SubItems.Add(txtSoLuong.Text);
                    lvi.SubItems.Add(txtDonGiaNhap.Text);
                    txtSoLuong.Text = "";
                    txtDonGiaNhap.Text = "";
                    cbb_TenHang.SelectedIndex = 0;
                    cbb_TenHang.Focus();
                }
                else
                {
                    MessageBox.Show("Đơn giá nhập không được để trống", "Thông Báo");
                    txtDonGiaNhap.Focus();
                }                    
            }
            else
            {
                MessageBox.Show("Số lượng không được để trống", "Thông Báo");
                txtSoLuong.Focus();
            }
        }

        private void txtDonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
                ThemHang_VaoListView();
            }
        }



        private void frmThem_CTPN_Load(object sender, EventArgs e)
        {
            HienThiDS_HH();
            dt = them.LayMaPN_Cuoi();
            string maPN = dt.Rows[0][0].ToString();
            string s = maPN.Substring(2);
            int a = int.Parse(s);
            if (a <= 99)
            {
                if (a < 10)
                    pn_Moi = "PN00" + (a + 1);
                else
                    pn_Moi = "PN0" + (a + 1);
            }
            else
            {
                pn_Moi = "PN" + (a + 1);
            }
            txtMaPN.Text = pn_Moi;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemHang_VaoListView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lsvThemPN_CTPN.SelectedItems.Count > 0)
            {
                lsvThemPN_CTPN.Items.RemoveAt(lsvThemPN_CTPN.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("Bạn cần chọn phiếu nhập cần xóa");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}", DTP_NgayNhap.Value);
            them.ThemPN(pn_Moi, ngay, tenTK);

            for (int i = 0; i < lsvThemPN_CTPN.Items.Count; i++)
            {
                them.ThemCTPN(pn_Moi, lsvThemPN_CTPN.Items[i].Text, lsvThemPN_CTPN.Items[i].SubItems[2].Text, lsvThemPN_CTPN.Items[i].SubItems[3].Text);
                dt = them.LaySoLuong_HH(lsvThemPN_CTPN.Items[i].Text);
                int soluong = int.Parse(dt.Rows[0][0].ToString()) + int.Parse(lsvThemPN_CTPN.Items[i].SubItems[2].Text);
                them.CapNhatSoLuong_HH(lsvThemPN_CTPN.Items[i].Text, soluong.ToString());
            }
            MessageBox.Show("Thêm Hàng Vào Kho Thành Công", "Thông báo");
            this.Close();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if(e.KeyChar == 13)
            {
                ThemHang_VaoListView();
            }
        }

    }
}
