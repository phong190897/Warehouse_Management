using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhoHang.GiaoDien;

namespace QuanLyKhoHang.XuLi
{
    class HangHoa
    {
        Database db;

        public HangHoa()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName, frmMDI.intergratedMode
                , frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDanhSachHangHoa()
        {
            return db.Execute("SELECT DISTINCT HangHoa.MaHang, HangHoa.TenHang, HangHoa.SoLuong, HangHoa.DonGia, " +
                "NhaCC.TenNhaCC, NganhHang.TenDanhMuc, HangHoa.NoiDungTomTat, HangHoa.DVT, HangHoa.HinhAnh " +
                "FROM            HangHoa INNER JOIN " +
                "NganhHang ON HangHoa.MaDanhMuc = NganhHang.MaDanhMuc INNER JOIN " +
                "NhaCC ON HangHoa.MaNhaCC = NhaCC.MaNhaCC");
        }

        public byte[] LayHinhANh(string mahang)
        {
            byte[] kq = null;
            String strConn = "server = " + ".\\SQLEXPRESS" + "; database = " + "DoAnCoSo"
                      + ";  Integrated Security = True"; 
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT HinhAnh FROM HangHoa  WHERE MaHang = N'" + mahang + "'", conn);
            SqlDataReader ddl = cmd.ExecuteReader();

            if (ddl.Read())
            {
                kq = (byte[])ddl.GetValue(0);
            }
            conn.Close();
            return kq;
        }



        public DataTable LayDS_NCC()
        {
            return db.Execute("SELECT MaNhaCC, TenNhaCC " +
                "FROM NhaCC");
        }

        public DataTable LayDS_MaNganhHang()
        {
            return db.Execute("SELECT MaDanhMuc, TenDanhMuc " +
                "FROM NganhHang");
        }

        public void ThemHangHoa(string mahh, string tenHang, string soLuong, string donGia,
            string maNhaCC, string maDM, string noiDungTomTat, string DVT, byte[] HinhAnh)
        {
            String strConn = "server = " + ".\\SQLEXPRESS" + "; database = " + "DoAnCoSo"
          + ";  Integrated Security = True";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = conn.CreateCommand();
            cmd.CommandText = "InsertInToHangHoa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaHang", SqlDbType.NVarChar, 10).Value   = mahh;
            cmd.Parameters.Add("@TenHang", SqlDbType.NVarChar, 100).Value = tenHang;
            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
            cmd.Parameters.AddWithValue("@DonGia", donGia);
            cmd.Parameters.AddWithValue("@MaNhaCC", maNhaCC);
            cmd.Parameters.Add("@MaDM", SqlDbType.NVarChar, 10).Value = maDM;
            cmd.Parameters.Add("@NoiDungTomTat", SqlDbType.NVarChar, 500).Value = noiDungTomTat;
            cmd.Parameters.Add("@DVT", SqlDbType.NVarChar, 70).Value = DVT;
            cmd.Parameters.AddWithValue("@HinhAnh", HinhAnh);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void XoaHangHoa(string mahh)
        {
            string sql = String.Format("DELETE FROM HangHoa " +
                "WHERE MaHang = '" + mahh + "'");
            db.ExecuteNonQuery(sql);
        }

        public void CapNhatHangHoa(string mahh, string tenHang, string soLuong, string donGia,
            string maNhaCC, string maDM, string noiDungTomTat, string DVT, byte[] HinhAnh)
        {
            String strConn = "server = " + ".\\SQLEXPRESS" + "; database = " + "DoAnCoSo"
          + ";  Integrated Security = True";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = conn.CreateCommand();
            cmd.CommandText = "UpdateHangHoa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaHang", SqlDbType.NVarChar, 10).Value = mahh;
            cmd.Parameters.Add("@TenHang", SqlDbType.NVarChar, 100).Value = tenHang;
            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
            cmd.Parameters.AddWithValue("@DonGia", donGia);
            cmd.Parameters.AddWithValue("@MaNhaCC", maNhaCC);
            cmd.Parameters.Add("@MaDM", SqlDbType.NVarChar, 10).Value = maDM;
            cmd.Parameters.Add("@NoiDungTomTat", SqlDbType.NVarChar, 500).Value = noiDungTomTat;
            cmd.Parameters.Add("@DVT", SqlDbType.NVarChar, 70).Value = DVT;
            cmd.Parameters.AddWithValue("@HinhAnh", HinhAnh);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable TimTenHang(string ten)
        {
            string sql = String.Format("SELECT DISTINCT HangHoa.MaHang, HangHoa.TenHang, HangHoa.SoLuong, HangHoa.DonGia, " +
                "NhaCC.TenNhaCC, NganhHang.TenDanhMuc, HangHoa.NoiDungTomTat, HangHoa.DVT, HangHoa.HinhAnh " +
                "FROM            HangHoa INNER JOIN " +
                "NganhHang ON HangHoa.MaDanhMuc = NganhHang.MaDanhMuc INNER JOIN " +
                "NhaCC ON HangHoa.MaNhaCC = NhaCC.MaNhaCC " +
                "WHERE TenHang LIKE N'%{0}%'", ten);
            return db.Execute(sql);
        }

        public DataTable KiemTraTonTai_CTNhap(string ma)
        {
            string sql = String.Format("SELECT *  " +
                "FROM CT_Nhap " +
                "WHERE MaHang = '{0}'",ma);
            return db.Execute(sql);
        }


        public DataTable KiemTraTonTai_CTXuat(string ma)
        {
            string sql = String.Format("SELECT *  " +
                "FROM CT_Xuat " +
                "WHERE MaHang = '{0}'", ma);
            return db.Execute(sql);
        }

        public DataTable KiemTraHang()
        {
            return db.Execute("SELECT MaHang, TenHang " +
                "FROM HangHoa " +
                "WHERE SoLuong <= 10");
        }
    }
}
