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

namespace QuanLyKhoHang.GiaoDien
{
    public partial class frmThem_CTPX : Form
    {
        DataTable dt;
        Them_CTPX them_ctpx;
        frmLogin lg;
        public string px_Moi = "";
        public string TenTk = "";

        public frmThem_CTPX(string ID_DangNhap)
        {
            InitializeComponent();
            dt = new DataTable();
            lg = new frmLogin();
            them_ctpx = new Them_CTPX();
            TenTk = ID_DangNhap;
        }

        public void HienThiDS_HH()
        {
            DataTable dt_hh = them_ctpx.LayDS_HH();
            cbb_TenHang.DataSource = dt_hh;
            cbb_TenHang.DisplayMember = "TenHang";
            cbb_TenHang.ValueMember = "MaHang";
            if (cbb_TenHang.Items.Count > 0)
                cbb_TenHang.SelectedIndex = 0;
        }

        public void HienThiDS_KH()
        {
            DataTable dt_kh = them_ctpx.LayDS_KH();
            cbb_TenKH.DataSource = dt_kh;
            cbb_TenKH.DisplayMember = "TenKH";
            cbb_TenKH.ValueMember = "MaKH";
            if (cbb_TenHang.Items.Count > 0)
                cbb_TenHang.SelectedIndex = 0;
        }

        private void frmThem_CTPX_Load(object sender, EventArgs e)
        {
            HienThiDS_HH();
            HienThiDS_KH();
            dt = them_ctpx.LayMaPX_Cuoi();
            string maPN = dt.Rows[0][0].ToString();
            string s = maPN.Substring(2);
            int a = int.Parse(s);
            if (a <= 99)
            {
                if (a < 10)
                    px_Moi = "PX00" + (a + 1);
                else
                    px_Moi = "PX0" + (a + 1);
            }
            else
            {
                px_Moi = "PX" + (a + 1);
            }
            txtMaPX.Text = px_Moi;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvThem_CTPX.SelectedItems.Count > 0)
            {
                lsvThem_CTPX.Items.RemoveAt(lsvThem_CTPX.SelectedIndices[0]);
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
            string ngay = String.Format("{0:MM/dd/yyyy}", DTP_NgayXuat.Value);
            them_ctpx.ThemPX(txtMaPX.Text, ngay, cbb_TenKH.SelectedValue.ToString(), TenTk);

            for (int i = 0; i < lsvThem_CTPX.Items.Count; i++)
            {
                them_ctpx.ThemCTPX(px_Moi, lsvThem_CTPX.Items[i].Text, lsvThem_CTPX.Items[i].SubItems[4].Text, lsvThem_CTPX.Items[i].SubItems[5].Text);
                dt = them_ctpx.LaySoLuong_HH(lsvThem_CTPX.Items[i].Text);
                int soluong = int.Parse(dt.Rows[0][0].ToString()) - int.Parse(lsvThem_CTPX.Items[i].SubItems[2].Text);                  
                them_ctpx.CapNhatSoLuong_HH(lsvThem_CTPX.Items[i].Text, soluong.ToString());                      
            }
            MessageBox.Show("Thêm Hàng Vào Kho Thành Công", "Thông báo");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "")
            {
                if (txtDonGiaXuat.Text != "")
                {
                    dt = them_ctpx.LaySoLuong_HH(cbb_TenHang.SelectedValue.ToString());
                    int soluong = int.Parse(dt.Rows[0][0].ToString()) - int.Parse(txtSoLuong.Text);
                    if (soluong > 0)
                    {
                        string ngay = String.Format("{0:MM/dd/yyyy}", DTP_NgayXuat.Value);
                        string mahang = cbb_TenHang.SelectedValue.ToString();
                        ListViewItem lvi;
                        lvi = lsvThem_CTPX.Items.Add(cbb_TenHang.SelectedValue.ToString());
                        lvi.SubItems.Add(cbb_TenHang.Text);
                        lvi.SubItems.Add(cbb_TenKH.Text);
                        lvi.SubItems.Add(txtSoLuong.Text);
                        lvi.SubItems.Add(txtDonGiaXuat.Text);
                        txtSoLuong.Text = "";
                        txtDonGiaXuat.Text = "";
                        cbb_TenHang.SelectedIndex = 0;
                        cbb_TenHang.Focus();
                    }
                    else
                        MessageBox.Show("KHÔNG ĐỦ HÀNG TRONG KHO ĐỂ XUẤT HÀNG\n\n" +
                            "Tên Hàng Hóa: " + cbb_TenHang.Text +"\n\n" +
                            "Số lượng hàng còn lại trong kho là: " + dt.Rows[0][0].ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đơn giá nhập không được để trống", "Thông Báo");
                    txtDonGiaXuat.Focus();
                }
            }
            else
            {
                MessageBox.Show("Số lượng không được để trống", "Thông Báo");
                txtSoLuong.Focus();
            }
        }
    }
}
