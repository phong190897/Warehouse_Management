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
    public partial class frmDMHH : Form
    {

        DanhMucHangHoa DMHH;
        DataTable dt;
        bool themmoi = true;

        public frmDMHH()
        {
            InitializeComponent();
            DMHH = new DanhMucHangHoa();
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
            txtMaDM.Enabled = value;
            txtTenDanhMuc.Enabled = value;
        }

        void clearForm()
        {
            txtMaDM.Text = "";
            txtTenDanhMuc.Text = "";
            txtMaDM.Focus();
        }

        private void frmDMHH_Load(object sender, EventArgs e)
        {
            HienThiDSDMHH();
            SetTextBox(false);
            SetButton(true);
        }

        public void HienThiDSDMHH()
        {
            dt = DMHH.LayDanhSachDMHH();
            lsvDMHH.Items.Clear();
            lsvDMHH.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvDMHH.Items.Add(dt.Rows[i]["MaDanhMuc"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            themmoi = true;
            SetButton(false);
            SetTextBox(true);
            clearForm();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    DMHH.XoaDMHH(txtMaDM.Text);
                    lsvDMHH.Items.RemoveAt(lsvDMHH.SelectedIndices[0]);
                    clearForm();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn mẫu tin để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(lsvDMHH.SelectedItems.Count > 0)
            {
                themmoi = false;
                SetButton(false);
                txtTenDanhMuc.Enabled = true;
            }
            else
            {
                MessageBox.Show("Bạn cần chọn mẫu tin để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuuLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (themmoi)
            {
                DMHH.ThemDMHH(txtMaDM.Text, txtTenDanhMuc.Text);
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                DMHH.CapNhatDMHH(txtMaDM.Text, txtTenDanhMuc.Text);
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }
            HienThiDSDMHH();
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
            HienThiDSDMHH();
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
                    sheet.Name = "Danh Mục Hàng Hóa";
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, lsvDMHH.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách nhà cung cấp";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //Sinh tiêu đề
                    for (int i = 1; i <= lsvDMHH.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = lsvDMHH.Columns[i - 1].Text;
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    //Sinh dữ liệu
                    for (int i = 1; i <= lsvDMHH.Items.Count; i++)
                    {
                        ListViewItem item = lsvDMHH.Items[i - 1];
                        sheet.Cells[i + 2, 1] = item.Text;
                        sheet.Cells[i + 2, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for (int j = 2; j <= lsvDMHH.Columns.Count; j++)
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

        private void lsvDMHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDMHH.SelectedIndices.Count > 0)
            {
                txtMaDM.Text  = lsvDMHH.SelectedItems[0].Text;
                txtTenDanhMuc.Text = lsvDMHH.SelectedItems[0].SubItems[1].Text;
            }
            else
            {
                SetTextBox(false);
                clearForm();
            }
        }

        public void HienThiDS_TimKiem(string ten)
        {
            if (txtTimKiem.Text != "")
            {
                dt = DMHH.LayDSTenDM(ten);
                lsvDMHH.Items.Clear();
                lsvDMHH.View = View.Details;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvi;
                    lvi = lsvDMHH.Items.Add(dt.Rows[i]["MaDanhMuc"].ToString());
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                }
                if(lsvDMHH.Items.Count > 0)
                {
                    lsvDMHH.Items[0].Selected = true;
                    lsvDMHH.Items[0].ForeColor = Color.RoyalBlue;
                }
            }
            else
            {
                clearForm();
                if (lsvDMHH.Items.Count > 0)
                {
                    lsvDMHH.Items[0].ForeColor = Color.Black;
                }
                HienThiDSDMHH();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            HienThiDS_TimKiem(txtTimKiem.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }
    }
}
