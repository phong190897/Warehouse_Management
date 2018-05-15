using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhoHang.XuLi;

namespace QuanLyKhoHang.GiaoDien
{
    public partial class frmLogin : Form
    {
        public static string tg_dn;
        DataTable dt;
        TaiKhoan Login;
        frmMDI frmmdi;
        frmDangKyTK dk;

        public frmLogin()
        {
            InitializeComponent();
            dt = new DataTable();
            Login = new TaiKhoan();
            dk = new frmDangKyTK();
        }

        //Băm chuỗi thành chuỗi SHA256
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

        private void linklb_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dk.ShowDialog();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            tg_dn = DateTime.Now.ToLocalTime().ToString();
            DataTable dt_qdn, dt_mk, dt_tk, dt_hoten = new DataTable();
            string hash_pw = sha256_hash(txtPWD.Text);

            dt_qdn = Login.Lay_QuyenDN(txtID.Text, hash_pw);
            dt_mk = Login.Lay_MK(txtID.Text, hash_pw);
            dt_tk = Login.LayTenTK(txtID.Text);
            dt_hoten = Login.layHoTen(txtID.Text, hash_pw);

            string hoten = dt_hoten.Rows[0][0].ToString();

            if(dt_tk.Rows.Count > 0)
            {
                if (dt_mk.Rows.Count > 0 && dt_qdn.Rows[0].ItemArray[0].Equals("AD") && dt_mk.Rows[0].ItemArray[0].Equals(hash_pw))
                {
                    frmmdi = new frmMDI(hoten, "Admin", tg_dn, txtID.Text);
                    this.Hide();
                    frmmdi.Show();
                    frmmdi.SetButton(false);
                }
                else if (dt_mk.Rows.Count > 0 && dt_qdn.Rows[0].ItemArray[0].Equals("QK") && dt_mk.Rows[0].ItemArray[0].Equals(hash_pw))
                {
                    frmmdi = new frmMDI(hoten, "Quản Kho", tg_dn, txtID.Text);
                    this.Hide();
                    frmmdi.Show();
                    frmmdi.SetButton(false);
                }
                else
                    MessageBox.Show("Sai Mật Khẩu!!!!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!!!!", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void ck_HienMK_CheckedChanged(object sender, EventArgs e)
        {
            txtPWD.PasswordChar = ck_HienMK.Checked ? '\0' : '*';
        }

        public void StartForm()
        {
            Application.Run(new frmSplashScreen());
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            t.Abort();
            this.Focus();
            txtID.Focus();
        }
    }
}
