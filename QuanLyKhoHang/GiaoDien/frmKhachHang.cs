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
    public partial class frmKhachHang : Form
    {
        KhachHang kh;
        DataTable dt;
        bool themmoi = true;

        public frmKhachHang()
        {
            InitializeComponent();
            kh = new KhachHang();
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

        public void SetTextBox(bool value)
        {
            txtMaKH.Enabled = value;
            txtTenKH.Enabled = value;
            txtEmail.Enabled = value;
            txtDiaChi.Enabled = value;
            txtDienThoai.Enabled = value;
        }

        void clearForm()
        {
            txtMaKH.Text      = "";
            txtTenKH.Text     = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text    = "";
            txtEmail.Text     = "";
            txtMaKH.Focus();
        }

        public void HienThiDSKH()
        {
            dt = kh.LayDanhSachNCC();
            lsvKhachHang.Items.Clear();
            lsvKhachHang.View = View.Details;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvKhachHang.Items.Add(dt.Rows[i]["MaKH"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            HienThiDSKH();
            SetButton(true);
            SetTextBox(false);
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaKH.Text != "")
            {
                themmoi = true;
                SetButton(false);
                SetTextBox(true);
                clearForm();
            }
            else
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống!!", "Thông báo");
                txtMaKH.Focus();
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lsvKhachHang.SelectedItems.Count > 0)
            {
                dt = kh.KiemTraTonTai(lsvKhachHang.SelectedItems[0].Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Không thể xóa Khách Hàng này vì xuất hiện trong Phiếu XUất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa Khách Hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        if (lsvKhachHang.SelectedItems.Count > 0)
                        {
                            kh.XoaKH(txtMaKH.Text);
                            lsvKhachHang.Items.RemoveAt(lsvKhachHang.SelectedIndices[0]);
                            clearForm();
                            MessageBox.Show("Xóa thành công", "Thông báo");
                        }
                        else
                            MessageBox.Show("Bạn cần chọn mẫu tin cần xóa");
                    }
                }
            }
            else
                MessageBox.Show("Bạn cần chọn mẫu tin cần xóa!!", "Thông báo");
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lsvKhachHang.SelectedIndices.Count > 0)
            {
                themmoi = false;
                SetButton(false);
                txtMaKH.Enabled = false;
                txtTenKH.Enabled     = true;
                txtEmail.Enabled     = true;
                txtDiaChi.Enabled    = true;
                txtDienThoai.Enabled = true;
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cần cập nhật", "Sửa mẫu tin");
        }

        private void btnLuuLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (themmoi)
            {
                kh.ThemKH(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text);
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                kh.CapNhatKH(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text);
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }
            HienThiDSKH();
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
            HienThiDSKH();
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
                    sheet.Name = "Danh Sách Khách Hàng";
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, lsvKhachHang.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách hàng hóa";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //Sinh tiêu đề
                    for (int i = 1; i <= lsvKhachHang.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = lsvKhachHang.Columns[i - 1].Text;
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    //Sinh dữ liệu
                    for (int i = 1; i <= lsvKhachHang.Items.Count; i++)
                    {
                        ListViewItem item = lsvKhachHang.Items[i - 1];
                        sheet.Cells[i + 2, 1] = item.Text;
                        sheet.Cells[i + 2, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for (int j = 2; j <= lsvKhachHang.Columns.Count; j++)
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

        private void lsvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvKhachHang.SelectedIndices.Count > 0)
            {
                txtMaKH.Text      = lsvKhachHang.SelectedItems[0].Text;
                txtTenKH.Text     = lsvKhachHang.SelectedItems[0].SubItems[1].Text;
                txtDiaChi.Text    = lsvKhachHang.SelectedItems[0].SubItems[2].Text;
                txtDienThoai.Text = lsvKhachHang.SelectedItems[0].SubItems[3].Text;
                txtEmail.Text     = lsvKhachHang.SelectedItems[0].SubItems[4].Text;
            }
            else
            {
                SetTextBox(false);
                clearForm();
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                HienDSTimKiem(txtTimKiem.Text);
                if(lsvKhachHang.Items.Count > 0)
                {
                    lsvKhachHang.Items[0].Selected = true;
                    lsvKhachHang.Items[0].ForeColor = Color.RoyalBlue;
                }
            }
            else
            {
                clearForm();
                if (lsvKhachHang.Items.Count > 0)
                {
                    lsvKhachHang.Items[0].ForeColor = Color.Black;
                }
                HienThiDSKH();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }


        public void HienDSTimKiem(string ten)
        {
            dt = kh.TimKhachHang(ten);
            lsvKhachHang.Items.Clear();
            lsvKhachHang.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvKhachHang.Items.Add(dt.Rows[i]["MaKH"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
            }
        }
    }
    
}
