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

namespace QuanLyKhoHang.GiaoDien
{
    public partial class frmDangKyTK : Form
    {

        TaiKhoan tk;
        DataTable dt;

        public frmDangKyTK()
        {
            InitializeComponent();
            tk = new TaiKhoan();
            dt = new DataTable();
        }

        public void Hien_Quyen()
        {
            DataTable dt_qdn = tk.Lay_DS_QuyenDN();
            cbb_QuyenDN.DataSource = dt_qdn;
            cbb_QuyenDN.DisplayMember = "TenQuyenDN";
            cbb_QuyenDN.ValueMember = "QuyenDN";
            if (cbb_QuyenDN.Items.Count > 0)
                cbb_QuyenDN.SelectedIndex = 0;
        }

        private void frmDangKyTK_Load(object sender, EventArgs e)
        {
            Hien_Quyen();
            txt_TenTK.Focus();
        }

        public void clearForm()
        {
            txt_TenTK.Text = "";
            txt_MatKhau.Text = "";
            txt_MK2.Text = "";
            cbb_QuyenDN.SelectedIndex = 0;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            dt = tk.KiemTra_TK_TonTai(txt_TenTK.Text);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Tên tài khoản đã tồn tại", "Thông báo");
                txt_TenTK.Focus();
            }
            else
            {
                if (txt_TenTK.Text == "")
                    MessageBox.Show("Tên tài khoản ko được để trống", "Thông báo");
                else if (txt_MatKhau.Text == "")
                    MessageBox.Show("Mật khẩu ko được để trống", "Thông báo");
                else if (txt_MatKhau.Text != txt_MK2.Text)
                    MessageBox.Show("Mật khẩu ko trùng nhau", "Thông báo");
                else if (txtHoTen.Text == "")
                    MessageBox.Show("Họ tên không được để trống", "Thông báo");
                else
                {
                    try
                    {
                        tk.ThemTaiKhoan(txt_TenTK.Text, sha256_hash(txt_MatKhau.Text), cbb_QuyenDN.SelectedValue.ToString(), txtHoTen.Text);
                        MessageBox.Show("Tạo tài khoản thành công", "Thông báo");
                        clearForm();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo");
                    }
                }
            }
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_TenTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txt_TenTK.Text == "")
                    MessageBox.Show("Tên tài khoản không được để trống", "Thông báo");
                else
                    txt_MatKhau.Focus();
            }
        }

        private void txt_MatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txt_MatKhau.Text == "")
                    MessageBox.Show("Mật khẩu không được để trống", "Thông báo");
                else
                    txt_MK2.Focus();
            }
        }

        private void txt_MK2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txt_MK2.Text == "")
                    MessageBox.Show("Mật khẩu không được để trống", "Thông báo");
                else
                    txtHoTen.Focus();
            }
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txt_MK2.Text == "")
                    MessageBox.Show("Mật khẩu không được để trống", "Thông báo");
                else
                    btnDangKy_Click(sender, e);
            }
        }
    }
}
