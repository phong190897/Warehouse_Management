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
    public partial class frmLoaiSP : Form
    {

        LoaiSP lsp;
        DataTable dt;
        bool themmoi = true;

        public frmLoaiSP()
        {
            InitializeComponent();
            lsp = new LoaiSP();
            dt = new DataTable();
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

        void clearForm()
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtMaDanhMuc.Text = "";
            txtMaLoai.Focus();
        }

        public void SetTextBox(bool value)
        {
            txtMaLoai.Enabled    = value;
            txtTenLoai.Enabled   = value;
            txtMaDanhMuc.Enabled = value;
        }

        private void frmLoaiSP_Load(object sender, EventArgs e)
        {
            HienThiDanhSachLsp();
            SetButton(true);
            SetTextBox(false);
        }

        public void HienThiDanhSachLsp()
        {
            dt = lsp.LayDanhSachNCC();
            lsvLoaiSP.Items.Clear();
            lsvLoaiSP.View = View.Details;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvLoaiSP.Items.Add(dt.Rows[i]["MaLoai"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaLoai.Text != "")
            {
                themmoi = true;
                SetButton(false);
                SetTextBox(true);
                clearForm();
            }
            else
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống!!", "Thông báo");
                txtMaLoai.Focus();
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (lsvLoaiSP.SelectedItems.Count > 0)
                    {
                        lsp.XoaNhaCC(txtMaLoai.Text);
                        lsvLoaiSP.Items.RemoveAt(lsvLoaiSP.SelectedIndices[0]);
                        clearForm();
                        MessageBox.Show("Xóa thành công", "Thông báo");
                    }
                    else
                        MessageBox.Show("Bạn cần chọn mẫu tin cần xóa");
                }

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lsvLoaiSP.SelectedIndices.Count > 0)
            {
                themmoi = false;
                SetButton(false);
                txtMaLoai.Enabled    = false;
                txtTenLoai.Enabled   = true;
                txtMaDanhMuc.Enabled = true;
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cần cập nhật", "Sửa mẫu tin");
        }

        private void btnLuuLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (themmoi)
            {
                lsp.ThemNCC(txtMaLoai.Text, txtTenLoai.Text, txtMaDanhMuc.Text);
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                lsp.CapNhatNhaCC(txtMaLoai.Text, txtTenLoai.Text, txtMaDanhMuc.Text);
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }
            HienThiDanhSachLsp();
            clearForm();
            SetButton(true);
            SetTextBox(false);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetButton(true);
            SetTextBox(false);
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HienThiDanhSachLsp();
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
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, lsvLoaiSP.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách nhà cung cấp";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //Sinh tiêu đề
                    for (int i = 1; i <= lsvLoaiSP.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = lsvLoaiSP.Columns[i - 1].Text;
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    //Sinh dữ liệu
                    for (int i = 1; i <= lsvLoaiSP.Items.Count; i++)
                    {
                        ListViewItem item = lsvLoaiSP.Items[i - 1];
                        sheet.Cells[i + 2, 1] = item.Text;
                        sheet.Cells[i + 2, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for (int j = 2; j <= lsvLoaiSP.Columns.Count; j++)
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

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát form?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Close();
            }
        }

        private void lsvLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvLoaiSP.SelectedIndices.Count > 0)
            {
                txtMaLoai.Text = lsvLoaiSP.SelectedItems[0].Text;
                txtTenLoai.Text = lsvLoaiSP.SelectedItems[0].SubItems[1].Text;
                txtMaDanhMuc.Text = lsvLoaiSP.SelectedItems[0].SubItems[2].Text;
            }
            else
            {
                SetTextBox(false);
                clearForm();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if(txtTimKiem.Text != "")
            {
                dt = lsp.TimTenLoai(txtTimKiem.Text);
                lsvLoaiSP.Items.Clear();
                lsvLoaiSP.View = View.Details;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvi;
                    lvi = lsvLoaiSP.Items.Add(dt.Rows[i]["MaLoai"].ToString());
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                }
                if(lsvLoaiSP.Items.Count > 0)
                {
                    lsvLoaiSP.Items[0].Selected = true;
                    lsvLoaiSP.Items[0].ForeColor = Color.RoyalBlue;
                }
            }
            else
            {
                clearForm();
                if(lsvLoaiSP.Items.Count > 0)
                {
                    lsvLoaiSP.Items[0].ForeColor = Color.Black;
                }
                HienThiDanhSachLsp();
            }
        }
    }
}
