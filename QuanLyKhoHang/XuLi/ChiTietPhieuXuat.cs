using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.XuLi
{
    class ChiTietPhieuXuat
    {

        Database db;

        public ChiTietPhieuXuat()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName
                , frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDSHangHoa()
        {
            return db.Execute("SELECT MaHang, TenHang " +
                "FROM HangHoa");
        }

        public DataTable LayDanhSachCTPX()
        {
            return db.Execute("SELECT A.MaPhieuXuat, B.TenHang, A.SoLuong, DonGiaXuat " +
                "FROM CT_Xuat A, HangHoa B " +
                "WHERE A.MaHang = B.MaHang");
        }

        public DataTable LayThongTinCTPX(string mapx)
        {
            return db.Execute("SELECT A.MaPhieuXuat, B.TenHang, A.SoLuong, DonGiaXuat " +
                "FROM CT_Xuat A, HangHoa B " +
                "WHERE A.MaHang = B.MaHang " +
                "AND MaPhieuXuat = '" + mapx + "'");
        }

        public void ThemCTPX(string MaPhieuXuat, string MaHang, int SoLuong, Double DonGiaXuat)
        {
            string sql = string.Format("INSERT INTO CT_Xuat " +
                "VALUES('{0}', '{1}', '{2}', '{3}')",
                MaPhieuXuat, MaHang, SoLuong, DonGiaXuat);
            db.ExecuteNonQuery(sql);
        }

        public void XoaCTPX(string MaPX, string MaHang)
        {
            string sql = string.Format("DELETE FROM CT_Xuat WHERE " +
                "MaPhieuXuat = '" + MaPX + "'" + 
                "AND MaHang =  '" + MaHang + "'");
            db.ExecuteNonQuery(sql);
        }

        public void CapNhatCTPX(string MaPhieuXuat, string MaHang, int SoLuong, Double DonGiaXuat)
        {
            string sql = string.Format("UPDATE CT_Xuat SET SoLuong = '{0}'," +
                " DonGiaXuat = '{1}', " +
                " MaHang = '{2}'" +
                " WHERE MaPhieuXuat = '{3}' ", SoLuong, DonGiaXuat, MaHang, MaPhieuXuat);
            db.ExecuteNonQuery(sql);
        }
    }
}
