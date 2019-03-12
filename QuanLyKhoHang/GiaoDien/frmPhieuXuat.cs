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
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyKhoHang.GiaoDien
{
    public partial class frmPhieuXuat : Form
    {

        PhieuXuat px;
        DataTable dt;
        public string tendn = "";
        bool themmoi = true;

        public frmPhieuXuat(string hoten, string ID)
        {
            InitializeComponent();
            px = new PhieuXuat();
            lblHoTen.Text = hoten;
            tendn = ID;
            dt = new DataTable();
        }

        public void SetButton(bool value)
        {
            btnThem.Enabled = value;
            btnXoa.Enabled = value;
            btnSua.Enabled = value;
            btnLuuLai.Enabled = !value;
            btnHuy.Enabled = !value;
            btnChiTietPhieuXuat.Enabled = !value;
            btnThoat.Enabled = value;
        }

        public void SetTextBox(bool value)
        {
            txtMaPX.Enabled          = value;
            cbb_TenHang.Enabled      = value;
            cbb_TenKhachHang.Enabled = value;
            DTPNgayXuat.Enabled      = value;
            txtSoLuong.Enabled       = value;
            txtDonGiaXuat.Enabled    = value;
        }

        void clearForm()
        {
            txtMaPX.Text = "";
            DTPNgayXuat.Value = DateTime.Now;
            cbb_TenHang.SelectedIndex = 0;
            txtMaPX.Focus();
        }

        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            HienThiDSPX();
            HienThi_HH();
            HienThi_TenKH();
            SetButton(true);
            SetTextBox(false);
        }

        public void HienThiDSPX()
        {
            dt = px.LayDanhSachPX();
            lsvPhieuXuat.Items.Clear();
            lsvPhieuXuat.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvPhieuXuat.Items.Add(dt.Rows[i]["MaPhieuXuat"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
            }
        }

        public void HienThi_CTPX()
        {
            dt = px.LayDS_CTPX(lsvPhieuXuat.SelectedItems[0].Text);
            lsvCTPX.Items.Clear();
            lsvCTPX.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvCTPX.Items.Add(dt.Rows[i]["MaPhieuXuat"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        public void HienThi_TenKH()
        {
            DataTable dt_kh = px.LayDS_KH();
            cbb_TenKhachHang.DataSource = dt_kh;
            cbb_TenKhachHang.ValueMember = "MaKH";
            cbb_TenKhachHang.DisplayMember = "TenKH";
            if (cbb_TenKhachHang.Items.Count > 0)
                cbb_TenKhachHang.SelectedIndex = 0;
        }

        public void HienThi_HH()
        {
            DataTable dt_hh = px.LayDS_HH();
            cbb_TenHang.DataSource = dt_hh;
            cbb_TenHang.ValueMember = "MaHang";
            cbb_TenHang.DisplayMember = "TenHang";
            if (cbb_TenHang.Items.Count > 0)
                cbb_TenHang.SelectedIndex = 0;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Bạn muốn thêm phiếu xuất mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dr == DialogResult.Yes)
            //{
            //    themmoi = true;
            //    SetButton(false);
            //    SetTextBox(true);
            //    clearForm();
            //}
            //else
            //{
            //    MessageBox.Show("Bạn hãy chọn phiếu xuất muốn thêm hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtMaPX.Enabled = false;
            //    DTPNgayXuat.Enabled = false;
            //    txtSoLuong.Enabled = true;
            //    txtDonGiaXuat.Enabled = true;
            //    cbb_TenHang.Enabled = true;
            //    cbb_TenKhachHang.Enabled = false;
            //    SetButton(false);
            //    txtMaPX.Text = lsvPhieuXuat.SelectedItems[0].Text;
            //    DTPNgayXuat.Value = DateTime.Parse(lsvPhieuXuat.SelectedItems[0].SubItems[1].Text);
            //}
            frmThem_CTPX them_cptx = new frmThem_CTPX(tendn);
            them_cptx.ShowDialog();
            HienThiDSPX();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if(lsvPhieuXuat.SelectedItems.Count > 0)
            {
                dt = px.Is_CTPX(txtMaPX.Text);
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if(dt.Rows.Count > 0)
                    {
                        px.Xoa_CTPX(txtMaPX.Text);
                        px.XoaPX(txtMaPX.Text);
                        lsvPhieuXuat.Items.RemoveAt(lsvPhieuXuat.SelectedIndices[0]);
                        HienThiDSPX();
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        px.XoaPX(txtMaPX.Text);
                        lsvPhieuXuat.Items.RemoveAt(lsvPhieuXuat.SelectedIndices[0]);
                        HienThiDSPX();
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            else
                MessageBox.Show("Bạn cần chọn mẫu tin đễ xóa", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lsvPhieuXuat.SelectedIndices.Count > 0)
            {
                //themmoi = false;
                //SetButton(false);
                //txtMaPX.Enabled = false;
                //cbb_TenKhachHang.Enabled = true;
                //cbb_TenHang.Enabled = true;
                //txtSoLuong.Enabled = true;
                //txtDonGiaXuat.Enabled = true;
                //DTPNgayXuat.Enabled = true;
                //DTPNgayXuat.Value = DateTime.Now;
                DateTime ngay = DateTime.Parse(lsvPhieuXuat.SelectedItems[0].SubItems[1].Text);
                frmSua_CTPX sua_ctpx = new frmSua_CTPX(txtMaPX.Text, ngay);
                sua_ctpx.ShowDialog();
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cần cập nhật", "Sửa mẫu tin");
        }

        private void btnLuuLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}", DTPNgayXuat.Value);
            dt = px.LayDS_MaPX(txtMaPX.Text);
            if (themmoi)
            {
                if(dt.Rows.Count > 0)
                {
                    px.ThemCTPX(txtMaPX.Text, cbb_TenHang.SelectedValue.ToString(), txtSoLuong.Text, txtDonGiaXuat.Text);
                    MessageBox.Show("Thêm mới thành công");
                    HienThi_CTPX();
                }
                else
                {
                    px.ThemPX(txtMaPX.Text, ngay, cbb_TenKhachHang.SelectedValue.ToString());
                    px.ThemCTPX(txtMaPX.Text, cbb_TenHang.SelectedValue.ToString(), txtSoLuong.Text, txtDonGiaXuat.Text);
                    MessageBox.Show("Thêm mới thành công");
                    HienThiDSPX();
                    lsvPhieuXuat.SelectedItems[lsvPhieuXuat.Columns.Count - 1].Selected = true;
                    HienThi_CTPX();
                }              
            }
            else
            {
                px.CapNhatPX(txtMaPX.Text, ngay, cbb_TenKhachHang.SelectedValue.ToString());
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                HienThiDSPX();
            }

            SetTextBox(false);
            clearForm();
            SetButton(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetButton(true);
            SetTextBox(false);
        }

        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Tạo đối tượng lưu tệp tin
            SaveFileDialog fsave = new SaveFileDialog();
            //Chỉ ra đuôi ở đây là .xlsx
            fsave.Filter = "(Tất cả các tệp)|*.*|(Các tệp excel)|*.xlsx";
            fsave.ShowDialog();
            //Xử lý
            if (fsave.FileName != "")
            {
                //Tạo Excel App
                Excel.Application app = new Excel.Application();
                //Tạo Workbook
                Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                //Tạo Worksheet
                Excel._Worksheet sheet = null;
                try
                {
                    //Đọc dữ liệu từ ListView xuất ra file excel có định dạng
                    sheet = wb.ActiveSheet;
                    sheet.Name = "Danh Sách Nhà Cung Cấp";
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, lsvPhieuXuat.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách nhà cung cấp";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //Sinh tiêu đề
                    for (int i = 1; i <= lsvPhieuXuat.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = lsvPhieuXuat.Columns[i - 1].Text;
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    //Sinh dữ liệu
                    for (int i = 1; i <= lsvPhieuXuat.Items.Count; i++)
                    {
                        ListViewItem item = lsvPhieuXuat.Items[i - 1];
                        sheet.Cells[i + 2, 1] = item.Text;
                        sheet.Cells[i + 2, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for (int j = 2; j <= lsvPhieuXuat.Columns.Count; j++)
                        {
                            sheet.Cells[i + 2, j] = item.SubItems[j - 1].Text;
                            sheet.Cells[i + 2, j].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        }
                    }
                    //Ghi lại
                    wb.SaveAs(fsave.FileName);
                    MessageBox.Show("Ghi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    app.Quit();
                    wb = null;
                }
            }
        }

        private void btnInReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmShowRP_PX rp_px = new frmShowRP_PX();
            rp_px.ShowDialog();
        }

        private void btnChiTietPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmCTPX frmctpx = new frmCTPX(txtMaPX.Text);
            //frmctpx.ShowDialog();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát form?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Close();
            }
        }

        private void lsvPhieuXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhieuXuat.SelectedIndices.Count > 0)
            {
                txtMaPX.Text = lsvPhieuXuat.SelectedItems[0].Text;
                DTPNgayXuat.Value = DateTime.Parse(lsvPhieuXuat.SelectedItems[0].SubItems[1].Text);
                cbb_TenKhachHang.SelectedIndex = cbb_TenKhachHang.FindString(lsvPhieuXuat.SelectedItems[0].SubItems[2].Text);
                HienThi_CTPX();
                if(lsvCTPX.Items.Count > 0)
                {
                        lsvCTPX.Items[0].Focused = true;
                        lsvCTPX.Items[0].Selected = true;
                        cbb_TenHang.SelectedIndex = cbb_TenHang.FindString(lsvCTPX.SelectedItems[0].SubItems[1].Text);
                        txtSoLuong.Text = lsvCTPX.SelectedItems[0].SubItems[2].Text;
                        txtDonGiaXuat.Text = lsvCTPX.SelectedItems[0].SubItems[3].Text;                   
                }
                TongTien_CTPX();
                btnChiTietPhieuXuat.Enabled = true;
            }
            else
            {
                clearForm();
                SetTextBox(false);
                cbb_TenHang.SelectedIndex = 0;
                cbb_TenKhachHang.SelectedIndex = 0;
                btnChiTietPhieuXuat.Enabled = false;
            }
        }

        public void TimPX(string ngay, string thang, string nam)
        {
            dt = px.TimNgayXuat_PX(ngay, thang, nam);
            lsvPhieuXuat.Items.Clear();
            lsvPhieuXuat.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvPhieuXuat.Items.Add(dt.Rows[i]["MaPhieuXuat"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
            }
        }

        public void TimCTPX(string ngay, string thang, string nam)
        {
            dt = px.TimNgayXuat_CTPX(ngay, thang, nam);
            lsvCTPX.Items.Clear();
            lsvCTPX.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvCTPX.Items.Add(dt.Rows[i]["MaPhieuXuat"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ngay = dtpTimKiem.Value.Day.ToString();
            string thang = dtpTimKiem.Value.Month.ToString();
            string nam = dtpTimKiem.Value.Year.ToString();
            TimPX(ngay, thang, nam);
            TimCTPX(ngay, thang, nam);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpTimKiem.Value = DateTime.Now;
            HienThiDSPX();
        }
        
        private void TongTien_CTPX()
        {
            float tong = 0;
            if (lsvPhieuXuat.SelectedItems.Count > 0)
            {
                if (lsvCTPX.Items.Count > 0)
                {
                    for (int i = 0; i < lsvCTPX.Items.Count; i++)
                    {
                        tong += float.Parse(lsvCTPX.Items[i].SubItems[2].Text) * float.Parse(lsvCTPX.Items[i].SubItems[3].Text);
                    }

                    txtTongTien.Text = tong.ToString("#,000.00") + " vnđ";
                }
                else
                {
                    txtTongTien.Text = "0 vnđ";
                }
            }
        }
    }
}
