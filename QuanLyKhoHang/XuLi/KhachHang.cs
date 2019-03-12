using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyKhoHang.XuLi
{
    class KhachHang
    {

        Database db;

        public KhachHang()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName
                , frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDanhSachNCC()
        {
            return db.Execute("SELECT MaKH, TenKH, DiaChi, DienThoai, Email " +
                "FROM KhachHang");
        }

        public void ThemKH(string MaKH, string TenKH, string DiaChi, string dt, string email)
        {
            string sql = string.Format("INSERT INTO KhachHang " +
                "VALUES('{0}', N'{1}', N'{2}', '{3}', '{4}')",
                MaKH, TenKH, DiaChi, dt, email);
            db.ExecuteNonQuery(sql);
        }

        public void XoaKH(string maKH)
        {
            string sql = string.Format("DELETE FROM KhachHang WHERE " +
                "MaKH = '" + maKH + "'");
            db.ExecuteNonQuery(sql);
        }

        public DataTable KiemTraTonTai(string makh)
        {
            return db.Execute("SELECT DISTINCT A.MaKH " +
                "FROM PhieuXuat A, KhachHang B " +
                "WHERE A.MaKH = B.MaKH " +
                "AND A.MaKH = N'" + makh + "'");
        }

        public void CapNhatKH(string MaKH, string TenKH, string DiaChi, string dt, string email)
        {
            string sql = string.Format("UPDATE KhachHang SET TenKH = N'{0}'," +
                " DiaChi = N'{1}', DienThoai = '{2}', Email = '{3}'" +
                " WHERE MaKH = '{4}'", TenKH, DiaChi, dt, email, MaKH);
            db.ExecuteNonQuery(sql);
        }

        public DataTable TimKhachHang(string tenkh)
        {
            string sql = String.Format("SELECT MaKH, TenKH, DiaChi ,DienThoai, Email " +
                "FROM KhachHang " +
                "WHERE TenKH LIKE N'%{0}%'", tenkh);
            return db.Execute(sql);
        }

    }
}
