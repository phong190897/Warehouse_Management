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
    public partial class frmCTPX : Form
    {

        ChiTietPhieuXuat ctpx;
        DataTable dt;
        bool themmoi = true;

        public frmCTPX(string mapx)
        {
            InitializeComponent();
            ctpx = new ChiTietPhieuXuat();
            dt = new DataTable();
            txtMaPX.Text = mapx;
        }

        public void SetButton(bool value)
        {
            btnThem.Enabled = value;
            btnXoa.Enabled = value;
            btnSua.Enabled = value;
            btnLuuLai.Enabled = !value;
            btnHuy.Enabled = !value;
            btnThoat.Enabled = value;
        }

        public void clearForm()
        {
            cbbMaHang.SelectedIndex = 0;
            txtSoLuong.Text = "";
            txtDonGiaXuat.Text = "";
            cbbMaHang.Focus();
        }

        public void HienThiDSHH()
        {
            DataTable dt_kh = ctpx.LayDSHangHoa();
            cbbMaHang.DataSource = dt_kh;
            cbbMaHang.DisplayMember = "TenHang";
            cbbMaHang.ValueMember = "MaHang";
            if (cbbMaHang.Items.Count > 0)
                cbbMaHang.SelectedIndex = 0;
        }

        public void TongTien()
        {
            float tong = 0;
            for (int i = 0; i < lsvCTPX.Items.Count; i++)
            {
                double soluong = Convert.ToDouble(lsvCTPX.Items[i].SubItems[2].Text);
                double dongia  = Convert.ToDouble(lsvCTPX.Items[i].SubItems[3].Text);
                tong += (float)Convert.ToDouble(soluong * dongia);
            }
            txtTongTien.Text = tong.ToString();
        }

        private void frmCTPX_Load(object sender, EventArgs e)
        {
            LayDanhSachPX();
            SetButton(true);
            TongTien();
            HienThiDSHH();
        }

        public void LayDanhSachPX()
        {
            dt = ctpx.LayThongTinCTPX(txtMaPX.Text);
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

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            themmoi = true;
            SetButton(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lsvCTPX.SelectedItems.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    ctpx.XoaCTPX(txtMaPX.Text, cbbMaHang.SelectedValue.ToString());
                    lsvCTPX.Items.RemoveAt(lsvCTPX.SelectedIndices[0]);
                    MessageBox.Show("Xóa thành công!!!", "Thông báo");
                }
            }
            else
                MessageBox.Show("Bạn cần chọn mẫu tin để xóa!!", "Thông báo");

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lsvCTPX.SelectedIndices.Count > 0)
            {
                themmoi = false;
                SetButton(false);
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cần cập nhật", "Sửa mẫu tin");
        }

        private void btnLuuLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int soluong = Convert.ToInt32(txtSoLuong.Text);
            double dongia = Convert.ToDouble(txtDonGiaXuat.Text);

            if (themmoi)
            {
                ctpx.ThemCTPX(txtMaPX.Text, cbbMaHang.SelectedValue.ToString(), soluong, dongia);
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                ctpx.CapNhatCTPX(txtMaPX.Text, cbbMaHang.SelectedValue.ToString(), soluong, dongia);
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }
            LayDanhSachPX();
            clearForm();
            SetButton(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetButton(true);
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LayDanhSachPX();
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
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, lsvCTPX.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách nhà cung cấp";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //Sinh tiêu đề
                    for (int i = 1; i <= lsvCTPX.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = lsvCTPX.Columns[i - 1].Text;
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    //Sinh dữ liệu
                    for (int i = 1; i <= lsvCTPX.Items.Count; i++)
                    {
                        ListViewItem item = lsvCTPX.Items[i - 1];
                        sheet.Cells[i + 2, 1] = item.Text;
                        sheet.Cells[i + 2, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for (int j = 2; j <= lsvCTPX.Columns.Count; j++)
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

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát form?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Close();
            }
        }

        private void lsvCTPX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvCTPX.SelectedIndices.Count > 0)
            {
                cbbMaHang.SelectedIndex = cbbMaHang.FindString(lsvCTPX.SelectedItems[0].SubItems[1].Text);
                txtSoLuong.Text = lsvCTPX.SelectedItems[0].SubItems[2].Text;
                txtDonGiaXuat.Text = lsvCTPX.SelectedItems[0].SubItems[3].Text;
            }
            else
                clearForm();
        }
    }
}
