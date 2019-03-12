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
    public partial class frmSua_CTPX : Form
    {
        DataTable dt;
        Sua_CTPX sua_ctpx;

        public frmSua_CTPX(string MaPN, DateTime ngay)
        {
            InitializeComponent();
            dt = new DataTable();
            sua_ctpx = new Sua_CTPX();
            txtMaPX.Text = MaPN;
            DTP_NgayXuat.Value = ngay;
        }

        public void HienThiDS_HH()
        {
            DataTable dt_hh = sua_ctpx.LayDS_HH();
            cbb_TenHang.DataSource = dt_hh;
            cbb_TenHang.DisplayMember = "TenHang";
            cbb_TenHang.ValueMember = "MaHang";
            if (cbb_TenHang.Items.Count > 0)
                cbb_TenHang.SelectedIndex = 0;
        }

        public void HienDS_CTPX(string ma)
        {
            dt = sua_ctpx.LayDS_CTPX(ma);
            lsvCTPX.Items.Clear();
            lsvCTPX.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvCTPX.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        private void frmSua_CTPX_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dt = sua_ctpx.LayDS_TenKH(txtMaPX.Text);
            if (dt.Rows.Count > 0)
            {
                txtTenKH.Text = dt.Rows[0][0].ToString();
            }
            else
                txtTenKH.Text = "";
            HienThiDS_HH();
            HienDS_CTPX(txtMaPX.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            sua_ctpx.ThemCTPX(txtMaPX.Text, cbb_TenHang.SelectedValue.ToString(), txtSoLuong.Text, txtDonGiaXuat.Text);
            MessageBox.Show("Thêm Chi Tiết Phiếu Nhập Thành Công", "Thông báo");
            HienDS_CTPX(txtMaPX.Text);
            txtSoLuong.Text = "";
            txtDonGiaXuat.Text = "";
            cbb_TenHang.SelectedIndex = 0;
            cbb_TenHang.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "")
            {
                if (txtDonGiaXuat.Text != "")
                {
                    sua_ctpx.CapNhat_CTPX(txtMaPX.Text, cbb_TenHang.SelectedValue.ToString(), txtSoLuong.Text, txtDonGiaXuat.Text);
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienDS_CTPX(txtMaPX.Text);
                    btnSua.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Đơn giá nhập không được để trống", "Thông báo");
                    txtDonGiaXuat.Focus();
                }

            }
            else
            {
                MessageBox.Show("Số lượng không được để trống");
                txtSoLuong.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            sua_ctpx.XoaPX(txtMaPX.Text, lsvCTPX.SelectedItems[0].Text);
            MessageBox.Show("Xóa Thành Công", "Thông báo");
            HienDS_CTPX(txtMaPX.Text);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsvCTPX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvCTPX.SelectedItems.Count > 0)
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                cbb_TenHang.SelectedIndex = cbb_TenHang.FindString(lsvCTPX.SelectedItems[0].SubItems[1].Text);
            }
            else
            {
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if(e.KeyChar == 13)
            {
                txtDonGiaXuat.Focus();
            }
        }

        private void txtDonGiaXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
