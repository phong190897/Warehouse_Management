using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.XuLi
{
    class Them_CTPX
    {

        Database db;

        public Them_CTPX()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName
                , frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDS_HH()
        {
            return db.Execute("SELECT MaHang, TenHang " +
                "FROM HangHoa");
        }

        public DataTable LayDS_KH()
        {
            return db.Execute("SELECT MaKH, TenKH " +
                "FROM KhachHang");
        }

        public void ThemPX(string MaPX, string NgayXuat, string MaKH, string TenTK)
        {
            string sql = string.Format("INSERT INTO PhieuXuat " +
                "VALUES('{0}', N'{1}', N'{2}', N'{3}')",
                MaPX, NgayXuat, MaKH, TenTK);
            db.ExecuteNonQuery(sql);
        }

        public void ThemCTPX(string ma, string mahh, string soluong, string dongiaxuat)
        {
            string sql = string.Format("INSERT INTO CT_Nhap VALUES('{0}', N'{1}', '{2}', '{3}')"
                , ma, mahh, soluong, dongiaxuat);
            db.ExecuteNonQuery(sql);
        }

        public DataTable LayMaPX_Cuoi()
        {
            return db.Execute("SELECT TOP 1 MaPhieuXuat FROM PhieuXuat " +
                "ORDER BY MaPhieuXuat desc");
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
