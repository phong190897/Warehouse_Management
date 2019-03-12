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
    public partial class frmNhaCC : Form
    {

        NhaCungCap ncc;
        DataTable dt;
        bool themmoi = true;

        public frmNhaCC()
        {
            InitializeComponent();
            ncc = new NhaCungCap();
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
            txtMaNhaCC.Enabled = value;
            txtTenNhaCC.Enabled = value;
            txtDiaChi.Enabled = value;
            txtDienThoai.Enabled = value;
        }

        void clearForm()
        {
            txtMaNhaCC.Text = "";
            txtTenNhaCC.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtMaNhaCC.Focus();
        }

        private void frmNhaCC_Load(object sender, EventArgs e)
        {
            HienThiDSNCC();
            SetButton(true);
            SetTextBox(false);
        }

        public void HienThiDSNCC()
        {
            dt = ncc.LayDanhSachNCC();
            lsvNhaCC.Items.Clear();
            lsvNhaCC.View = View.Details;
            for(int i = 0; i< dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvNhaCC.Items.Add(dt.Rows[i]["MaNhaCC"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaNhaCC.Text != "")
            {
                themmoi = true;
                SetButton(false);
                SetTextBox(true);
                clearForm();
            }
            else
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống!!", "Thông báo");
                txtMaNhaCC.Focus();
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lsvNhaCC.SelectedItems.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (lsvNhaCC.SelectedItems.Count > 0)
                    {
                        ncc.XoaNhaCC(txtMaNhaCC.Text);
                        lsvNhaCC.Items.RemoveAt(lsvNhaCC.SelectedIndices[0]);
                        clearForm();
                        MessageBox.Show("Xóa thành công", "Thông báo");
                    }
                    else
                        MessageBox.Show("Bạn cần chọn mẫu tin cần xóa");
                }
            }
            else
                MessageBox.Show("Bạn cần chọn mẫu tin cần xóa!!", "Thông báo");
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lsvNhaCC.SelectedIndices.Count > 0)
            {
                themmoi = false;
                SetButton(false);
                txtMaNhaCC.Enabled   = false;
                txtTenNhaCC.Enabled  = true;
                txtDiaChi.Enabled    = true;
                txtDienThoai.Enabled = true;
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cần cập nhật", "Sửa mẫu tin");
        }

        private void btnLuuLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(themmoi)
            {
                ncc.ThemNCC(txtMaNhaCC.Text, txtTenNhaCC.Text, txtDiaChi.Text, txtDienThoai.Text);
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                ncc.CapNhatNhaCC(txtMaNhaCC.Text, txtTenNhaCC.Text, txtDiaChi.Text, txtDienThoai.Text);
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }
            HienThiDSNCC();
            clearForm();
            SetTextBox(false);
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
            if(fsave.FileName != "")
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
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, lsvNhaCC.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách nhà cung cấp";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //Sinh tiêu đề
                    for(int i = 1; i <= lsvNhaCC.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = lsvNhaCC.Columns[i - 1].Text;
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    //Sinh dữ liệu
                    for(int i = 1; i <= lsvNhaCC.Items.Count; i++)
                    {
                        ListViewItem item = lsvNhaCC.Items[i - 1];
                        sheet.Cells[i + 2, 1] = item.Text;
                        sheet.Cells[i + 2, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for(int j = 2; j <= lsvNhaCC.Columns.Count; j++)
                        {
                            sheet.Cells[i + 2, j] = item.SubItems[j - 1].Text;
                            sheet.Cells[i + 2, j].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        }
                    }
                    //Ghi lại
                    wb.SaveAs(fsave.FileName);
                    MessageBox.Show("Ghi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
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
            if(dr == DialogResult.Yes)
            {
                Close();
            }
        }

        //Binding data from ListView to TextEdit
        private void lsvNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhaCC.SelectedIndices.Count > 0)
            {
                txtMaNhaCC.Text = lsvNhaCC.SelectedItems[0].Text;
                txtTenNhaCC.Text = lsvNhaCC.SelectedItems[0].SubItems[1].Text;
                txtDiaChi.Text = lsvNhaCC.SelectedItems[0].SubItems[2].Text;
                txtDienThoai.Text = lsvNhaCC.SelectedItems[0].SubItems[3].Text;
            }
            else
            {
                clearForm();
                SetTextBox(false);
            }

        }

        //Avoid character button or special character in TextEdit txtDienThoai
        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HienThiDSNCC();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if(txtTimKiem.Text != "")
            {
                dt = ncc.TimTenNhaCC(txtTimKiem.Text);
                lsvNhaCC.Items.Clear();
                lsvNhaCC.View = View.Details;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvi;
                    lvi = lsvNhaCC.Items.Add(dt.Rows[i]["MaNhaCC"].ToString());
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                    lvi.SubItems.Add(dt.Rows[i][3].ToString());
                }
                if(lsvNhaCC.Items.Count > 0)
                {
                    lsvNhaCC.Items[0].Selected = true;
                    lsvNhaCC.Items[0].ForeColor = Color.RoyalBlue;
                }
            }
            else
            {
                clearForm();
                if (lsvNhaCC.Items.Count > 0)
                {
                    lsvNhaCC.Items[0].ForeColor = Color.RoyalBlue;
                }
                HienThiDSNCC();
            }
        }
    }
}
