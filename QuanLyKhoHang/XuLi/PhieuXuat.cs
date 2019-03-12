using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyKhoHang.XuLi
{
    class PhieuXuat
    {
        Database db;

        public PhieuXuat()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName
                , frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDanhSachPX()
        {
            return db.Execute("SELECT MaPhieuXuat, NgayXuat, TenKH, HoTen " +
                "FROM PhieuXuat A, KhachHang B, TaiKhoan C " +
                "WHERE A.MaKH = B.MaKH " +
                "AND C.TenTK = A.TenTK");
        }

        public DataTable LayDS_KH()
        {
            return db.Execute("SELECT MaKH, TenKH " +
                " FROM KhachHang");
        }

        public DataTable LayDS_HH()
        {
            return db.Execute("SELECT MaHang, TenHang " +
                "FROM HangHoa");
        }

        public DataTable Is_CTPX(string mapx)
        {
            return db.Execute("SELECT MaPhieuXuat, MaHang  " +
                "FROM CT_Xuat " +
                "WHERE MaPhieuXuat = '" + mapx + "'");
        }

        public DataTable LayDS_MaPX(string ma)
        {
            string sql = string.Format("SELECT MaPhieuXuat " +
                    "FROM PhieuXuat " +
                    "WHERE MaPhieuXuat = '{0}'", ma);
            return db.Execute(sql);
        }

        public DataTable LayDS_CTPX(string ma)
        {
            string sql = string.Format("SELECT MaPhieuXuat, TenHang, A.SoLuong, DonGiaXuat " +
                "FROM CT_Xuat A, HangHoa B " +
                "WHERE A.MaHang = B.MaHang " +
                "AND MaPhieuXuat = '{0}'", ma);
            return db.Execute(sql);
        }

        public void ThemPX(string MaPX, string NgayXuat, string MaKH)
        {
            string sql = string.Format("INSERT INTO PhieuXuat " +
                "VALUES('{0}', N'{1}', N'{2}')",
                MaPX, NgayXuat, MaKH);
            db.ExecuteNonQuery(sql);
        }

        public void ThemCTPX(string ma, string mahh, string soluong, string dongiaxuat)
        {
            string sql = string.Format("INSERT INTO CT_Xuat VALUES('{0}', '{1}', '{2}', '{3}')", ma, mahh,
                soluong, dongiaxuat);
            db.ExecuteNonQuery(sql);
        }

        public void BaoCao_CTPX_MaPX(string mapx)
        {
            string sql = string.Format("ALTER VIEW vw_DS_CTPXuat_TheoMaPX AS " +
                "SELECT A.MaPhieuXuat, A.NgayXuat, HoTen, TenKH, C.TenHang, B.SoLuong, B.DonGiaXuat, B.SoLuong * B.DonGiaXuat AS 'Tổng Tiền' " +
                "FROM PhieuXuat A, CT_Xuat B, HangHoa C, TaiKhoan D, KhachHang E " +
                "WHERE A.MaPhieuXuat = B.MaPhieuXuat " +
                "AND B.MaHang = C.MaHang " +
                "AND D.TenTK = A.TenTK " +
                "AND E.MaKH = A.MaKH " +
                "AND A.MaPhieuXuat = '{0}'", mapx);

            db.ExecuteNonQuery(sql);
        }

        public void XoaPX(string MaPX)
        {
            string sql = string.Format("DELETE FROM PhieuXuat WHERE " +
                "MaPhieuXuat = '" + MaPX + "'");
            db.ExecuteNonQuery(sql);
        }

        public void Xoa_CTPX(string mapx)
        {
            string sql = string.Format("DELETE FROM CT_Xuat WHERE " +
                "MaPhieuXuat = N'{0}'", mapx);
            db.ExecuteNonQuery(sql);
        }

        public void CapNhatPX(string MaPX, string NgayXuat, string MaKH)
        {
            string sql = string.Format("UPDATE PhieuXuat SET NgayXuat = '{0}'," +
                " MaKH = '{1}'" +
                " WHERE MaPhieuXuat = '{2}'", NgayXuat, MaKH, MaPX);
            db.ExecuteNonQuery(sql);
        }

        public DataTable TimNgayXuat_CTPX(string ngay, string thang, string nam)
        {
            string sql = String.Format("SELECT MaPhieuXuat, TenHang, A.SoLuong, A.DonGiaXuat " +
                "FROM CT_Xuat A, HangHoa B " +
                "WHERE A.MaHang = B.MaHang " +
                "AND MaPhieuXuat IN(SELECT MaPhieuXuat " +
                "                   FROM PhieuXuat A, KhachHang B " +
                "                   WHERE A.MaKH = B.MaKH " +
                "                   AND NgayXuat LIKE '%{0}%-%{1}%-%{2}%')", nam, thang, ngay);
            return db.Execute(sql);
        }

        public DataTable TimNgayXuat_PX(string ngay, string thang, string nam)
        {
            string sql = String.Format("SELECT MaPhieuXuat, NgayXuat, TenKH " +
                "FROM PhieuXuat A, KhachHang B " +
                "WHERE A.MaKH = B.MaKH " +
                "AND NgayXuat LIKE '%{0}%-%{1}%-%{2}%'", nam, thang, ngay);
            return db.Execute(sql);
        }
    }
}
