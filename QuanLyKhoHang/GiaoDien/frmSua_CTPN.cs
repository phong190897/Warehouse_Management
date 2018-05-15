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
    public partial class frmSua_CTPN : Form
    {
        DataTable dt;
        Sua_CTPN sua_ctpn;

        public frmSua_CTPN(string MaPN, DateTime ngay)
        {
            InitializeComponent();
            txtMaPN.Text = MaPN;
            DTP_NgayNhap.Value = ngay;
            dt = new DataTable();
            sua_ctpn = new Sua_CTPN();
        }

        public void HienThiDS_HH()
        {
            DataTable dt_hh = sua_ctpn.LayDS_HH();
            cbb_TenHang.DataSource = dt_hh;
            cbb_TenHang.DisplayMember = "TenHang";
            cbb_TenHang.ValueMember = "MaHang";
            if (cbb_TenHang.Items.Count > 0)
                cbb_TenHang.SelectedIndex = 0;
        }

        public void HienDS_CTPN(string ma)
        {
            dt = sua_ctpn.LayDS_CTPN(ma);
            lsvSua_CTPN.Items.Clear();
            lsvSua_CTPN.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvSua_CTPN.Items.Add(dt.Rows[i]["MaHang"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        private void frmSua_CTPN_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnThoat.Enabled = false;
            btnXoa.Enabled = false;
            HienThiDS_HH();
            HienDS_CTPN(txtMaPN.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            sua_ctpn.ThemCTPN(txtMaPN.Text, cbb_TenHang.SelectedValue.ToString(), txtSoLuong.Text, txtDonGiaNhap.Text);
            MessageBox.Show("Thêm Chi Tiết Phiếu Nhập Thành Công", "Thông báo");
            HienDS_CTPN(txtMaPN.Text);
            txtSoLuong.Text = "";
            txtDonGiaNhap.Text = "";
            cbb_TenHang.SelectedIndex = 0;
            cbb_TenHang.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtSoLuong.Text != "")
            {
                if (txtDonGiaNhap.Text != "")
                {
                    sua_ctpn.CapNhat_CTPN(txtMaPN.Text, cbb_TenHang.SelectedValue.ToString(), txtSoLuong.Text, txtDonGiaNhap.Text);
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienDS_CTPN(txtMaPN.Text);
                    btnSua.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Đơn giá nhập không được để trống", "Thông báo");
                    txtDonGiaNhap.Focus();
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
            sua_ctpn.XoaPN(txtMaPN.Text, lsvSua_CTPN.SelectedItems[0].Text);
            MessageBox.Show("Xóa Thành Công", "Thông báo");
            HienDS_CTPN(txtMaPN.Text);
        }

        private void lsvSua_CTPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lsvSua_CTPN.SelectedItems.Count > 0)
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                cbb_TenHang.SelectedIndex = cbb_TenHang.FindString(lsvSua_CTPN.SelectedItems[0].SubItems[1].Text);
            }
            else
            {
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
        }
    }
}
