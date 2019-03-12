using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.XuLi
{
    class PhieuNhap
    {

        Database db;

        public PhieuNhap()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName
                , frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDanhSachPN()
        {
            return db.Execute("SELECT MaPhieuNhap, NgayNhap, HoTen " +
                "FROM PhieuNhap A, TaiKhoan B " +
                "WHERE A.TenTK = B.TenTK");
        }

        public DataTable LayDS_MaPN(string ma)
        {
            string sql = string.Format("SELECT MaPhieuNhap " +
                "FROM PhieuNhap " +
                "WHERE MaPhieuNhap = '{0}'", ma);
            return db.Execute(sql);
        }

        public DataTable Is_CTPN(string mapn)
        {
            return db.Execute("SELECT MaPhieuNhap, MaHang  " +
                "FROM CT_Nhap " +
                "WHERE MaPhieuNhap = '" + mapn + "'");
        }

        public DataTable LayDS_CTPN(string ma)
        {
           string sql = string.Format("SELECT MaPhieuNhap, TenHang, A.SoLuong, DonGiaNhap " +
                "FROM CT_Nhap A, HangHoa B " +
                "WHERE A.MaHang = B.MaHang " +
                "AND MaPhieuNhap = '{0}'", ma);
            return db.Execute(sql);
        }

        public DataTable LayDS_HH()
        {
            return db.Execute("SELECT MaHang, TenHang " +
                "FROM HangHoa");
        }

        public void ThemPN(string MaPN, string NgayNhap)
        {
            string sql = string.Format("INSERT INTO PhieuNhap " +
                "VALUES('{0}', N'{1}')",
                MaPN, NgayNhap);
            db.ExecuteNonQuery(sql);
        }

        public void BaoCao_CTPN_MaPN(string mapn)
        {
            string sql = string.Format("ALTER VIEW vw_DS_CTPNhap_TheoMaPN AS " +
                "SELECT A.MaPhieuNhap, A.NgayNhap, HoTen, C.TenHang, B.SoLuong, B.DonGiaNhap, B.SoLuong * B.DonGiaNhap AS 'Tổng Tiền' " +
                "FROM PhieuNhap A, CT_Nhap B, HangHoa C, TaiKhoan D " +
                "WHERE A.MaPhieuNhap = B.MaPhieuNhap " +
                "AND B.MaHang = C.MaHang " +
                "AND D.TenTK = A.TenTK " +
                "AND A.MaPhieuNhap = '{0}'", mapn);
            db.ExecuteNonQuery(sql);
        }

        public void ThemCTPN(string ma, string mahh, string soluong, string dongianhap)
        {
            string sql = string.Format("INSERT INTO CT_Nhap VALUES('{0}', N'{1}', '{2}', '{3}')"
                , ma, mahh, soluong, dongianhap);
            db.ExecuteNonQuery(sql);
        }

        public void XoaPN(string MaPN)
        {
            string sql = string.Format("DELETE FROM PhieuNhap WHERE " +
                "MaPhieuNhap = '" + MaPN + "'");
            db.ExecuteNonQuery(sql);
        }

        public void Xoa_CTPN(string mapn)
        {
            string sql = string.Format("DELETE FROM CT_Nhap WHERE " +
                "MaPhieuNhap = N'{0}'", mapn);
            db.ExecuteNonQuery(sql);
        }

        public void CapNhatPN(string MaPN, string NgayNhap)
        {
            string sql = string.Format("UPDATE PhieuNhap SET NgayNhap = '{0}',"  +
                " WHERE MaPhieuNhap = '{1}'", NgayNhap, MaPN);
            db.ExecuteNonQuery(sql);
        }

        public DataTable TimNgayNhap_CTPN(string ngay, string thang, string nam)
        {
            string sql = String.Format("SELECT MaPhieuNhap, TenHang, A.SoLuong, A.DonGiaNhap " +
                "FROM CT_Nhap A, HangHoa B " +
                "WHERE A.MaHang = B.MaHang " +
                "AND MaPhieuNhap IN(SELECT MaPhieuNhap " +
                "                   FROM PhieuNhap " +
                "                   WHERE NgayNhap LIKE '%{0}%-%{1}%-%{2}%')", nam, thang, ngay);
            return db.Execute(sql);
        }

        public DataTable TimNgayNhap_PN(string ngay, string thang, string nam)
        {
            string sql = String.Format("SELECT MaPhieuNhap, NgayNhap " +
                "FROM PhieuNhap " +
                "WHERE NgayNhap LIKE '%{0}%-%{1}%-%{2}%'", nam, thang, ngay);
            return db.Execute(sql);
        }
    }

}

