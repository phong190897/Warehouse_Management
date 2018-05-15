using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.XuLi
{
    class ChiTietPhieuNhap
    {

        Database db;

        public ChiTietPhieuNhap()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName
                , frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDSHangHoa()
        {
            return db.Execute("SELECT MaHang, TenHang " +
                "FROM HangHoa");
        }

        public DataTable LayDanhSachCTPN()
        {
            return db.Execute("SELECT A.MaPhieuNhap, B.TenHang, A.SoLuong, DonGiaNhap " +
                "FROM CT_Nhap A, HangHoa B " +
                "WHERE A.MaHang = B.MaHang");
        }

        public DataTable LayThongTinCTPN(string mapn)
        {
            return db.Execute("SELECT A.MaPhieuNhap, B.TenHang, A.SoLuong, DonGiaNhap " +
                "FROM CT_Nhap A, HangHoa B " +
                "WHERE A.MaHang = B.MaHang " +
                "AND MaPhieuNhap = '" + mapn + "'");
        }

        public void ThemCTPN(string MaPN, string MaHang, int SoLuong, Double DonGiaNhap)
        {
            string sql = string.Format("INSERT INTO CT_Nhap " +
                "VALUES('{0}', '{1}', '{2}', '{3}')",
                MaPN, MaHang, SoLuong, DonGiaNhap);
            db.ExecuteNonQuery(sql);
        }

        public void XoaCTPN(string MaPN, string MaHang)
        {
            string sql = string.Format("DELETE FROM CT_Nhap WHERE " +
                "MaPhieuNhap = '" + MaPN + "'" +
                "AND MaHang =  '" + MaHang + "'");
            db.ExecuteNonQuery(sql);
        }

        public void CapNhatCTPN(string MaPN, string MaHang, int SoLuong, Double DonGiaNhap)
        {
            string sql = string.Format("UPDATE CT_Nhap SET SoLuong = '{0}'," +
                " DonGiaNhap = '{1}', " +
                " MaHang = '{2}'" +
                " WHERE MaPhieuNhap = '{3}' ", SoLuong, DonGiaNhap, MaHang, MaPN);
            db.ExecuteNonQuery(sql);
        }
    }
}
