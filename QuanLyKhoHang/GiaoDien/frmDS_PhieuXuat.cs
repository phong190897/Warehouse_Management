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
    public partial class frmDS_PhieuXuat : Form
    {

        DataTable dt;
        PhieuXuat px;

        public frmDS_PhieuXuat()
        {
            InitializeComponent();
            dt = new DataTable();
            px = new PhieuXuat();
        }

        public void HienThiDS_PX()
        {
            dt = px.LayDanhSachPX();
            lsvPhieuXuat.Items.Clear();
            lsvPhieuXuat.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvPhieuXuat.Items.Add(dt.Rows[i]["MaPhieuXuat"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
            }
        }

        private void frmDS_PhieuXuat_Load(object sender, EventArgs e)
        {
            HienThiDS_PX();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if(lsvPhieuXuat.SelectedItems.Count > 0)
            {
                px.BaoCao_CTPX_MaPX(lsvPhieuXuat.SelectedItems[0].Text);
                frm_rp_CTPX_MaPX a = new frm_rp_CTPX_MaPX();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mời bạn chọn phiếu nhập hàng muốn in ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
