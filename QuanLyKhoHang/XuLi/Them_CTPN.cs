using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.XuLi
{
    class Them_CTPN
    {
        Database db;

        public Them_CTPN()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName
                , frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDS_HH()
        {
            return db.Execute("SELECT MaHang, TenHang " +
                "FROM HangHoa");
        }

        public void ThemPN(string MaPN, string NgayNhap, string TenTK)
        {
            string sql = string.Format("INSERT INTO PhieuNhap " +
                "VALUES('{0}', N'{1}', N'{2}')",
                MaPN, NgayNhap, TenTK);
            db.ExecuteNonQuery(sql);
        }

        public void ThemCTPN(string ma, string mahh, string soluong, string dongianhap)
        {
            string sql = string.Format("INSERT INTO CT_Nhap VALUES('{0}', N'{1}', '{2}', '{3}')"
                , ma, mahh, soluong, dongianhap);
            db.ExecuteNonQuery(sql);
        }

        public DataTable LayMaPN_Cuoi()
        {
            return db.Execute("select TOP 1 MaPhieuNhap from PhieuNhap " +
                "ORDER BY MaPhieuNhap desc");
        }

        public DataTable LaySoLuong_HH(string mahang)
        {
            string sql = string.Format("SELECT SoLuong " +
                "FROM HangHoa " +
                "WHERE MaHang = N'{0}'", mahang);
            return db.Execute(sql);
        }

        public void CapNhatSoLuong_HH(string maHang, string soLuong)
        {
            string sql = string.Format("UPDATE HangHoa SET SoLuong = '{0}' WHERE MaHang = N'{1}'", soLuong, maHang);
            db.ExecuteNonQuery(sql);
        }
    }
}
