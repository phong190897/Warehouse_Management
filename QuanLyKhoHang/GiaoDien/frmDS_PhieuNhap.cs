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
using QuanLyKhoHang.GiaoDien_Report;

namespace QuanLyKhoHang.GiaoDien
{
    public partial class frmDS_PhieuNhap : Form
    {

        DataTable dt;
        PhieuNhap pn;

        public frmDS_PhieuNhap()
        {
            InitializeComponent();
            dt = new DataTable();
            pn = new PhieuNhap();
        }

        public void HienThiDS_PN()
        {
            dt = pn.LayDanhSachPN();
            lsvPhieuNhap.Items.Clear();
            lsvPhieuNhap.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvPhieuNhap.Items.Add(dt.Rows[i]["MaPhieuNhap"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
            }
        }

        private void frmDS_PhieuNhap_Load(object sender, EventArgs e)
        {
            HienThiDS_PN();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if(lsvPhieuNhap.SelectedItems.Count > 0)
            {
                pn.BaoCao_CTPN_MaPN(lsvPhieuNhap.SelectedItems[0].Text);
                frm_rp_CTPN_MaPN a = new frm_rp_CTPN_MaPN();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mời bạn chọn phiếu nhập hàng muốn in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
