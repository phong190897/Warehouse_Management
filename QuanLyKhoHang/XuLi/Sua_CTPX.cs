using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.XuLi
{
    class Sua_CTPX
    {
        Database db;

        public Sua_CTPX()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName
                , frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDS_HH()
        {
            return db.Execute("SELECT MaHang, TenHang " +
                "FROM HangHoa");
        }

        public DataTable LayDS_TenKH(string mapx)
        {
            return db.Execute("SELECT TENKH " +
                "FROM KhachHang A, PhieuXuat B " +
                "WHERE A.MaKH = B.MaKH " +
                "AND MaPhieuXuat = '" + mapx + "'");
        }

        public DataTable LayDS_CTPX(string maPX)
        {
            string sql = string.Format("SELECT        PhieuXuat.MaPhieuXuat, HangHoa.TenHang, CT_Xuat.SoLuong, CT_Xuat.DonGiaXuat " +
                "FROM            CT_Xuat INNER JOIN " +
                "HangHoa ON CT_Xuat.MaHang = HangHoa.MaHang INNER JOIN " +
                "PhieuXuat ON CT_Xuat.MaPhieuXuat = PhieuXuat.MaPhieuXuat INNER JOIN " +
                "KhachHang ON PhieuXuat.MaKH = KhachHang.MaKH " +
                "WHERE(PhieuXuat.MaPhieuXuat = '{0}')", maPX);

            return db.Execute(sql);
        }

        public void CapNhatPX(string MaPX, string NgayXuat)
        {
            string sql = string.Format("UPDATE PhieuNhap SET NgayNhap = '{0}'," +
                " WHERE MaPhieuNhap = '{1}'", NgayXuat, MaPX);
            db.ExecuteNonQuery(sql);
        }

        public void CapNhat_CTPX(string MaPX, string mahh, string soluong, string dongia)
        {
            string sql = string.Format("UPDATE CT_Nhap SET  SoLuong = '{0}', DonGiaNhap = '{1}'" +
                " WHERE MaPhieuNhap = '{2}' " +
                "AND MaHang = N'{3}'", soluong, dongia, MaPX, mahh);
            db.ExecuteNonQuery(sql);
        }

        public void XoaPX(string MaPX, string MaHang)
        {
            string sql = string.Format("DELETE FROM CT_Nhap WHERE MaPhieuNhap = '{0}', MaHang = N'{1}'", MaPX, MaHang);

            db.ExecuteNonQuery(sql);
        }

        public void ThemCTPX(string ma, string mahh, string soluong, string dongianhap)
        {
            string sql = string.Format("INSERT INTO CT_Nhap VALUES('{0}', N'{1}', '{2}', '{3}')"
                , ma, mahh, soluong, dongianhap);
            db.ExecuteNonQuery(sql);
        }

    }
}
