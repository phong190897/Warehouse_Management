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
using Microsoft.VisualBasic;
using QuanLyKhoHang.Report;

namespace QuanLyKhoHang.GiaoDien
{
    public partial class frmPhieuNhap : Form
    {

        PhieuNhap pn;
        DataTable dt;
        bool themmoi = true;
        public string tendn = "";

        public frmPhieuNhap(string HoTenNV, string ID)
        {
            InitializeComponent();
            pn = new PhieuNhap();
            dt = new DataTable();
            tendn = ID;
            lblHoTen.Text = HoTenNV;
        }

        public void SetButton(bool value)
        {
            btnThem.Enabled = value;
            btnXoa.Enabled = value;
            btnSua.Enabled = value;
            btnLuuLai.Enabled = !value;
            btnHuy.Enabled = !value;
            btnChiTietPN.Enabled = !value;
            btnThoat.Enabled = value;
        }

        public void SetTextBox(bool value)
        {
            txtMaPN.Enabled = value;
            DTPNgayNhap.Enabled = value;
            txtSoLuong.Enabled = value;
            txtDonGiaNhap.Enabled = value;
            cbb_TenMatHang.Enabled = value;
        }

        void clearForm()
        {
            txtMaPN.Text = "";
            DTPNgayNhap.Value = DateTime.Now;
            txtSoLuong.Text = "";
            txtDonGiaNhap.Text = "";
            cbb_TenMatHang.SelectedIndex = 0;
            txtMaPN.Focus();
        }

        public void HienThiDSPN()
        {
            dt = pn.LayDanhSachPN();
            lsvPhieuNhap.Items.Clear();
            lsvPhieuNhap.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvPhieuNhap.Items.Add(dt.Rows[i]["MaPhieuNhap"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
            }
        }

        public void HienThiDS_HH()
        {
            DataTable dt_hh = pn.LayDS_HH();
            cbb_TenMatHang.DataSource = dt_hh;
            cbb_TenMatHang.DisplayMember = "TenHang";
            cbb_TenMatHang.ValueMember = "MaHang";
            if (cbb_TenMatHang.Items.Count > 0)
                cbb_TenMatHang.SelectedIndex = 0;
        }

        public void HienThi_CTPN()
        {
            dt = pn.LayDS_CTPN(lsvPhieuNhap.SelectedItems[0].Text);
            lsvCTPN.Items.Clear();
            lsvCTPN.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvCTPN.Items.Add(dt.Rows[i]["MaPhieuNhap"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        public static string soluongHang = "1";
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Bạn muốn thêm phiếu nhập mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dr == DialogResult.Yes)
            //{
            //    themmoi = true;
            //    SetButton(false);
            //    SetTextBox(true);
            //    DTPNgayNhap.Value = DateTime.Now;
            //    clearForm();
            //}
            //else
            //{
            //    MessageBox.Show("Bạn hãy chọn phiếu nhập muốn thêm hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtMaPN.Enabled = false;
            //    DTPNgayNhap.Enabled = false;
            //    txtSoLuong.Enabled = true;
            //    txtDonGiaNhap.Enabled = true;
            //    cbb_TenMatHang.Enabled = true;
            //    SetButton(false);
            //    txtMaPN.Text = lsvPhieuNhap.SelectedItems[0].Text;
            //    DTPNgayNhap.Value = DateTime.Parse(lsvPhieuNhap.SelectedItems[0].SubItems[1].Text);
            //}
            frmThem_CTPN them_ctpn = new frmThem_CTPN(tendn);
            them_ctpn.ShowDialog();
            HienThiDSPN();
        }

        public void abc()
        {
            HienThiDSPN();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lsvPhieuNhap.SelectedItems.Count > 0)
            {
                dt = pn.Is_CTPN(txtMaPN.Text);
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if(dt.Rows.Count > 0)
                    {
                        pn.Xoa_CTPN(txtMaPN.Text);
                        pn.XoaPN(txtMaPN.Text);
                        lsvPhieuNhap.Items.RemoveAt(lsvPhieuNhap.SelectedIndices[0]);
                        HienThiDSPN();
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        pn.XoaPN(txtMaPN.Text);
                        lsvPhieuNhap.Items.RemoveAt(lsvPhieuNhap.SelectedIndices[0]);
                        HienThiDSPN();
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            else
                MessageBox.Show("Bạn cần chọn mẫu tin đễ xóa", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (lsvPhieuNhap.SelectedIndices.Count > 0)
            //{
            //    themmoi = false;
            //    SetButton(false);
            //    txtMaPN.Enabled = false;
            //    DTPNgayNhap.Enabled = true;
            //    txtSoLuong.Enabled = true;
            //    txtDonGiaNhap.Enabled = true;
            //    cbb_TenMatHang.Enabled = true;
            //}
            //else
            //    MessageBox.Show("Bạn phải chọn mẫu tin cần cập nhật", "Sửa mẫu tin");
            if(lsvPhieuNhap.SelectedItems.Count > 0)
            {
                DateTime ngay = DateTime.Parse(lsvPhieuNhap.SelectedItems[0].SubItems[1].Text);
                frmSua_CTPN sua_ctpn = new frmSua_CTPN(lsvPhieuNhap.SelectedItems[0].Text, ngay);
                sua_ctpn.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn phải chọn 1 dòng trong bảng Phiếu Nhập", "Thông báo");
            }
        }

        private void btnLuuLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}", DTPNgayNhap.Value);
            dt = pn.LayDS_MaPN(txtMaPN.Text);
            if (themmoi)
            {
                if(dt.Rows.Count > 0)
                {
                    pn.ThemCTPN(txtMaPN.Text, cbb_TenMatHang.SelectedValue.ToString(), txtSoLuong.Text, txtDonGiaNhap.Text);
                    MessageBox.Show("Thêm mới thành công");
                    HienThi_CTPN();
                }
                else
                {
                    pn.ThemPN(txtMaPN.Text, ngay);
                    pn.ThemCTPN(txtMaPN.Text, cbb_TenMatHang.SelectedValue.ToString(), txtSoLuong.Text, txtDonGiaNhap.Text);
                    MessageBox.Show("Thêm mới thành công");
                    HienThiDSPN();
                    lsvPhieuNhap.Items[lsvPhieuNhap.Columns.Count - 1].Selected = true;
                    HienThi_CTPN();
                }

            }
            else
            {
                pn.CapNhatPN(txtMaPN.Text, ngay);
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                HienThiDSPN();
            }
            clearForm();
            SetTextBox(false);
            SetButton(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetButton(true);
            SetTextBox(false);
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HienThiDSPN();
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
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, lsvPhieuNhap.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách nhà cung cấp";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //Sinh tiêu đề
                    for (int i = 1; i <= lsvPhieuNhap.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = lsvPhieuNhap.Columns[i - 1].Text;
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    //Sinh dữ liệu
                    for (int i = 1; i <= lsvPhieuNhap.Items.Count; i++)
                    {
                        ListViewItem item = lsvPhieuNhap.Items[i - 1];
                        sheet.Cells[i + 2, 1] = item.Text;
                        sheet.Cells[i + 2, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for (int j = 2; j <= lsvPhieuNhap.Columns.Count; j++)
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
            frmShowRP_PN pn_rp = new frmShowRP_PN();
            pn_rp.ShowDialog();
            
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát form?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Close();
            }
        }

        public void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            HienThiDSPN();
            SetButton(true);
            SetTextBox(false);
            lsvCTPN.Enabled = true;
            HienThiDS_HH();
        }

        private void lsvPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhieuNhap.SelectedIndices.Count > 0)
            {
                txtMaPN.Text = lsvPhieuNhap.SelectedItems[0].Text;
                DTPNgayNhap.Value = DateTime.Parse(lsvPhieuNhap.SelectedItems[0].SubItems[1].Text);
                HienThi_CTPN();
                if (lsvCTPN.Items.Count > 0)
                {
                    lsvCTPN.Items[0].Focused = true;
                    lsvCTPN.Items[0].Selected = true;
                    cbb_TenMatHang.SelectedIndex = cbb_TenMatHang.FindString(lsvCTPN.SelectedItems[0].SubItems[1].Text);
                    txtSoLuong.Text = lsvCTPN.SelectedItems[0].SubItems[2].Text;
                    txtDonGiaNhap.Text = lsvCTPN.SelectedItems[0].SubItems[3].Text;
                }
                TongTien_CTPN();
            }
            else
            {
                clearForm();
                lsvCTPN.Items.Clear();
                if(btnLuuLai.Enabled == false)
                {
                    SetTextBox(false);
                }
            }
        }

        public void TimPN(string nam, string thang, string ngay)
        {
            dt = pn.TimNgayNhap_PN(ngay, thang, nam);
            lsvPhieuNhap.Items.Clear();
            lsvPhieuNhap.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvPhieuNhap.Items.Add(dt.Rows[i]["MaPhieuNhap"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
            }
        }

        public void TimCTPN(string nam, string thang, string ngay)
        {
            dt = pn.TimNgayNhap_CTPN(ngay, thang, nam);
            lsvCTPN.Items.Clear();
            lsvCTPN.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvCTPN.Items.Add(dt.Rows[i]["MaPhieuNhap"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ngay = dtp_TimKiem.Value.Day.ToString();
            string thang = dtp_TimKiem.Value.Month.ToString();
            string nam = dtp_TimKiem.Value.Year.ToString();
            TimPN(nam, thang, ngay);
            TimCTPN(nam, thang, ngay);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtp_TimKiem.Value = DateTime.Now;
            HienThiDSPN();
        }

        private void TongTien_CTPN()
        {
            float tong = 0;
            if(lsvPhieuNhap.SelectedItems.Count > 0)
            {
                if(lsvCTPN.Items.Count > 0)
                {
                    for (int i = 0; i < lsvCTPN.Items.Count; i++)
                    {
                        tong += float.Parse(lsvCTPN.Items[i].SubItems[2].Text) * float.Parse(lsvCTPN.Items[i].SubItems[3].Text);
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
