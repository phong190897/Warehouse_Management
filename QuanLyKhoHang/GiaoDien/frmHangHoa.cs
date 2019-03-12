using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhoHang.XuLi;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyKhoHang.GiaoDien
{
    public partial class frmHangHoa : Form
    {

        DataTable dt;
        HangHoa hh;
        bool themmoi = true;

        public frmHangHoa()
        {
            InitializeComponent();
            dt = new DataTable();
            hh = new HangHoa();
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
            txtMaHang.Enabled = value;
            txtTenHang.Enabled = value;
            txtSoLuong.Enabled = value;
            txtDonGia.Enabled = value;
            cb_MaNhaCC.Enabled = value;
            cb_MaLoai.Enabled = value;
            cb_DVT.Enabled = value;
            txtND_TomTat.Enabled = value;
            pic_HinhAnh.Enabled = value;
            
        }

        void clearForm()
        {
            txtMaHang.Text           = "";
            txtTenHang.Text          = "";
            txtSoLuong.Text          = "";
            txtDonGia.Text           = "";
            txtND_TomTat.Text        = "";
            cb_DVT.SelectedIndex     = 0;
            cb_MaLoai.SelectedIndex  = 0;
            cb_MaNhaCC.SelectedIndex = 0;
            pic_HinhAnh.Image = Properties.Resources.QLBH;
        }

        public void HienThiDS_HH()
        {
            dt = hh.LayDanhSachHangHoa();
            lsvHangHoa.Items.Clear();
            lsvHangHoa.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvHangHoa.Items.Add(dt.Rows[i]["MaHang"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
                lvi.SubItems.Add(dt.Rows[i][6].ToString());
                lvi.SubItems.Add(dt.Rows[i][7].ToString());
                //lvi.SubItems.Add(dt.Rows[i][8].ToString());
            }
        }

        public void HienThiDS_MaNhaCC()
        {
            DataTable dt_manhacc = hh.LayDS_NCC();
            cb_MaNhaCC.DataSource = dt_manhacc;
            cb_MaNhaCC.DisplayMember = "TenNhaCC";
            cb_MaNhaCC.ValueMember = "MaNhaCC";
            if (cb_MaNhaCC.Items.Count > 0)
                cb_MaNhaCC.SelectedIndex = 0;
        }

        public void HienThiDS_MaNganhHang()
        {
            DataTable dt_maloai = hh.LayDS_MaNganhHang();
            cb_MaLoai.DataSource = dt_maloai;
            cb_MaLoai.DisplayMember = "TenDanhMuc";
            cb_MaLoai.ValueMember = "MaDanhMuc";
            if (cb_MaLoai.Items.Count > 0)
                cb_MaLoai.SelectedIndex = 0;
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            SetButton(true);
            SetTextBox(false);
            HienThiDS_HH();
            HienThiDS_MaNganhHang();
            HienThiDS_MaNhaCC();
            cb_DVT.SelectedIndex = 0;
            cb_MaLoai.SelectedIndex = 0;
            cb_MaNhaCC.SelectedIndex = 0;
            btn_ChonHinh.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            themmoi = true;
            SetButton(false);
            SetTextBox(true);
            lsvHangHoa.Enabled = false;
            clearForm();
            btn_ChonHinh.Enabled = true;
            txtMaHang.Focus();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable KiemTra_PN, KiemTra_PX;
            if (lsvHangHoa.SelectedItems.Count > 0)
            {
                KiemTra_PN = hh.KiemTraTonTai_CTNhap(txtMaHang.Text);
                KiemTra_PX = hh.KiemTraTonTai_CTXuat(txtMaHang.Text);
                if(KiemTra_PN.Rows.Count > 0)
                {
                    MessageBox.Show("Hàng hóa này xuất hiện ở bảng phiếu nhập nên không thể xóa!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(KiemTra_PX.Rows.Count > 0)
                {
                    MessageBox.Show("Hàng hóa này xuất hiện ở bảng phiếu xuất nên không thể xóa!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        hh.XoaHangHoa(txtMaHang.Text);
                        lsvHangHoa.Items.RemoveAt(lsvHangHoa.SelectedIndices[0]);
                        clearForm();
                        MessageBox.Show("Xóa thành công!!!", "Thông báo");
                    }
                }
            }
            else
                MessageBox.Show("Bạn cần chọn mẫu tin để xóa!!", "Thông báo");
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lsvHangHoa.SelectedIndices.Count > 0)
            {
                themmoi = false;
                SetButton(false);
                txtMaHang.Enabled = false;
                txtTenHang.Enabled = true;
                txtSoLuong.Enabled = true;
                txtDonGia.Enabled = true;
                cb_MaNhaCC.Enabled = true;
                cb_MaLoai.Enabled = true;
                cb_DVT.Enabled = true;
                txtND_TomTat.Enabled = true;
                pic_HinhAnh.Enabled = true;
                btn_ChonHinh.Enabled = true;

            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cần cập nhật", "Sửa mẫu tin");
        }

        private void btnLuuLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(themmoi)
            {
                try
                {
                    if(pic_HinhAnh.Image != null)
                    {
                        hh.ThemHangHoa(txtMaHang.Text, txtTenHang.Text, txtSoLuong.Text, txtDonGia.Text,
                        cb_MaNhaCC.SelectedValue.ToString(), cb_MaLoai.SelectedValue.ToString(), txtND_TomTat.Text, cb_DVT.SelectedItem.ToString(), convertImageToBytes());
                        MessageBox.Show("Thêm thành công", "thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa thêm ảnh của hàng hóa", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                }
            }
            else
            {
                if (pic_HinhAnh.Image != null)
                {
                    hh.CapNhatHangHoa(txtMaHang.Text, txtTenHang.Text, txtSoLuong.Text, txtDonGia.Text,
                                           cb_MaNhaCC.SelectedValue.ToString(), cb_MaLoai.SelectedValue.ToString(), txtND_TomTat.Text, cb_DVT.SelectedItem.ToString(),
                                           convertImageToBytes());
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Bạn chưa thêm ảnh của hàng hóa", "Thông báo");
                }              
            }
            HienThiDS_HH();
            clearForm();
            SetTextBox(false);
            SetButton(true);
            btn_ChonHinh.Enabled = false;
            lsvHangHoa.Enabled = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetButton(true);
            SetTextBox(false);
            btn_ChonHinh.Enabled = false;
            lsvHangHoa.Enabled = true;
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HienThiDS_HH();
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
                    sheet.Name = "Danh Sách Hàng Hóa";
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, lsvHangHoa.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách hàng hóa";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //Sinh tiêu đề
                    for (int i = 1; i <= lsvHangHoa.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = lsvHangHoa.Columns[i - 1].Text;
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    //Sinh dữ liệu
                    for (int i = 1; i <= lsvHangHoa.Items.Count; i++)
                    {
                        ListViewItem item = lsvHangHoa.Items[i - 1];
                        sheet.Cells[i + 2, 1] = item.Text;
                        sheet.Cells[i + 2, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for (int j = 2; j <= lsvHangHoa.Columns.Count; j++)
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

        //Chọn hình từ đường dẫn 
        string imgLoc = "";
        private void btn_ChonHinh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "All Files (*.*)|*.*|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                dlg.Title = "Select Product Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    pic_HinhAnh.ImageLocation = imgLoc;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        //Cách 1 Đổi hình thành chuỗi byte[]
        private byte[] convertImageToBytes()
        {
            FileStream fs;
            fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }


        //Chuyển chuỗi byte lấy từ database trở lại thành hình ảnh
        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                //MemoryStream ms = new MemoryStream(byteArrayIn);
                //Image returnImage = Image.FromStream(ms);
                ImageConverter imageConverter = new System.Drawing.ImageConverter();
                Image image = imageConverter.ConvertFrom(byteArrayIn) as Image;
                return image;

                //using (var ms = new MemoryStream(byteArrayIn))
                //{
                //    return Image.FromStream(ms);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            return null;
        }

        

        private void lsvHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHangHoa.SelectedIndices.Count > 0)
            {
                //byte[] toBytes = Encoding.ASCII.GetBytes(lsvHangHoa.SelectedItems[0].SubItems[8].Text);
                txtMaHang.Text = lsvHangHoa.SelectedItems[0].Text;
                txtTenHang.Text = lsvHangHoa.SelectedItems[0].SubItems[1].Text;
                txtSoLuong.Text = lsvHangHoa.SelectedItems[0].SubItems[2].Text;
                txtDonGia.Text = lsvHangHoa.SelectedItems[0].SubItems[3].Text;
                cb_MaNhaCC.SelectedIndex = cb_MaNhaCC.FindString(lsvHangHoa.SelectedItems[0].SubItems[4].Text);
                cb_MaLoai.SelectedIndex = cb_MaLoai.FindString(lsvHangHoa.SelectedItems[0].SubItems[5].Text);
                txtND_TomTat.Text = lsvHangHoa.SelectedItems[0].SubItems[6].Text;
                cb_DVT.SelectedIndex = cb_DVT.FindString(lsvHangHoa.SelectedItems[0].SubItems[7].Text);
                pic_HinhAnh.Image = byteArrayToImage(hh.LayHinhANh(txtMaHang.Text));


            }
            else
                clearForm();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if(txtTimKiem.Text != "")
            {
                dt = hh.TimTenHang(txtTimKiem.Text);
                lsvHangHoa.Items.Clear();
                lsvHangHoa.View = View.Details;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvi;
                    lvi = lsvHangHoa.Items.Add(dt.Rows[i]["MaHang"].ToString());
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                    lvi.SubItems.Add(dt.Rows[i][3].ToString());
                    lvi.SubItems.Add(dt.Rows[i][4].ToString());
                    lvi.SubItems.Add(dt.Rows[i][5].ToString());
                    lvi.SubItems.Add(dt.Rows[i][6].ToString());
                    lvi.SubItems.Add(dt.Rows[i][7].ToString());
                }
                if (lsvHangHoa.Items.Count > 0)
                {
                    lsvHangHoa.Items[0].Selected = true;
                    lsvHangHoa.Items[0].ForeColor = Color.RoyalBlue;
                }
            }
            else
            {
                clearForm();
                if (lsvHangHoa.Items.Count > 0)
                {
                    lsvHangHoa.Items[0].ForeColor = Color.Black;
                }            
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
