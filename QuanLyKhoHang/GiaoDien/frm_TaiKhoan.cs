using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhoHang.XuLi;
using Excel = Microsoft.Office.Interop.Excel;


namespace QuanLyKhoHang.GiaoDien
{
    public partial class frm_TaiKhoan : Form
    {

        TaiKhoan tk;
        DataTable dt;
        bool themmoi;

        public frm_TaiKhoan()
        {
            InitializeComponent();
            tk = new TaiKhoan();
            dt = new DataTable();
            themmoi = true;
        }

        public void LayDS_TaiKhoan()
        {
            dt = tk.LayDanhSachTK();
            lsvTaiKhoan.Items.Clear();
            lsvTaiKhoan.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvTaiKhoan.Items.Add(dt.Rows[i]["TenTK"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        public void LayDS_QuyenDN()
        {
            dt = tk.Lay_DS_QuyenDN();
            cbb_QuyenDN.DataSource = dt;
            cbb_QuyenDN.DisplayMember = "TenQuyenDN";
            cbb_QuyenDN.ValueMember = "QuyenDN";
            if (cbb_QuyenDN.Items.Count > 0)
                cbb_QuyenDN.SelectedIndex = 0;
        }

        public void SetTextBox(bool value)
        {
            txtTenTK.Enabled = value;
            txtMatKhau.Enabled = value;
            txtHoTen.Enabled = value;
            cbb_QuyenDN.Enabled = value;
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

        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            LayDS_TaiKhoan();
            LayDS_QuyenDN();
            SetTextBox(false);
            SetButton(true);
        }

        public void ClearForm()
        {
            txtTenTK.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            cbb_QuyenDN.SelectedIndex = 0;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            themmoi = true;
            SetButton(false);
            SetTextBox(true);
            lsvTaiKhoan.Enabled = false;
            ClearForm();
            txtHoTen.Focus();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lsvTaiKhoan.SelectedItems.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (lsvTaiKhoan.SelectedItems.Count > 0)
                    {
                        tk.XoaTaiKhoan(txtTenTK.Text);
                        lsvTaiKhoan.Items.RemoveAt(lsvTaiKhoan.SelectedIndices[0]);
                        ClearForm();
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
            if (lsvTaiKhoan.SelectedIndices.Count > 0)
            {
                themmoi = false;
                SetButton(false);
                txtTenTK.Enabled = false;
                txtMatKhau.Enabled = true;
                txtHoTen.Enabled = true;
                cbb_QuyenDN.Enabled = true;
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cần cập nhật", "Sửa mẫu tin");
        }

        private void btnLuuLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (themmoi)
            {
                tk.ThemTaiKhoan(txtTenTK.Text, sha256_hash(txtMatKhau.Text), cbb_QuyenDN.SelectedValue.ToString(), txtHoTen.Text);
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                tk.CapNhatTaiKhoan(txtTenTK.Text, sha256_hash(txtMatKhau.Text), cbb_QuyenDN.SelectedValue.ToString(), txtHoTen.Text);
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }
            LayDS_TaiKhoan();
            ClearForm();
            SetTextBox(false);
            SetButton(true);
            lsvTaiKhoan.Enabled = true;
        }

        public static String sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
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
                    sheet.Name = "Danh Sách Nhân Viên";
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, lsvTaiKhoan.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách nhà cung cấp";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //Sinh tiêu đề
                    for (int i = 1; i <= lsvTaiKhoan.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = lsvTaiKhoan.Columns[i - 1].Text;
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    //Sinh dữ liệu
                    for (int i = 1; i <= lsvTaiKhoan.Items.Count; i++)
                    {
                        ListViewItem item = lsvTaiKhoan.Items[i - 1];
                        sheet.Cells[i + 2, 1] = item.Text;
                        sheet.Cells[i + 2, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for (int j = 2; j <= lsvTaiKhoan.Columns.Count; j++)
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

        private void lsvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTaiKhoan.SelectedIndices.Count > 0)
            {
                txtTenTK.Text = lsvTaiKhoan.SelectedItems[0].Text;
                txtMatKhau.Text = lsvTaiKhoan.SelectedItems[0].SubItems[1].Text;
                cbb_QuyenDN.SelectedIndex = cbb_QuyenDN.FindString(lsvTaiKhoan.SelectedItems[0].SubItems[2].Text);
                txtHoTen.Text = lsvTaiKhoan.SelectedItems[0].SubItems[3].Text;
            }
            else
            {
                ClearForm();
                SetTextBox(false);
            }
        }

        private void txtTimKiem_HoTen_TextChanged(object sender, EventArgs e)
        {
            if(txtTimKiem_HoTen.Text != "")
            {
                dt = tk.Tim_NV(txtTimKiem_HoTen.Text);
                lsvTaiKhoan.Items.Clear();
                lsvTaiKhoan.View = View.Details;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvi;
                    lvi = lsvTaiKhoan.Items.Add(dt.Rows[i]["TenTK"].ToString());
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                    lvi.SubItems.Add(dt.Rows[i][3].ToString());
                }
                if (lsvTaiKhoan.Items.Count > 0)
                {
                    lsvTaiKhoan.Items[0].Selected = true;
                    lsvTaiKhoan.Items[0].ForeColor = Color.RoyalBlue;
                }
            }
            else
            {
                LayDS_TaiKhoan();
                ClearForm();
                if (lsvTaiKhoan.Items.Count > 0)
                {
                    lsvTaiKhoan.Items[0].ForeColor = Color.Black;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTimKiem_HoTen.Text = "";
        }
    }
}
