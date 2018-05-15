using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.XuLi
{
    class Sua_CTPN
    {
        Database db;

        public Sua_CTPN()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName
                , frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDS_HH()
        {
            return db.Execute("SELECT MaHang, TenHang " +
                "FROM HangHoa");
        }

        public DataTable LayDS_CTPN(string maPN)
        {
            string sql = string.Format("SELECT A.MaHang, TenHang, A.SoLuong, A.DonGiaNhap " +
                "FROM CT_Nhap A, HangHoa B " +
                "WHERE A.MaHang = B.MaHang " +
                "AND MaPhieuNhap = '{0}'", maPN);

            return db.Execute(sql);
        }

        public void CapNhatPN(string MaPN, string NgayNhap)
        {
            string sql = string.Format("UPDATE PhieuNhap SET NgayNhap = '{0}'," +
                " WHERE MaPhieuNhap = '{1}'", NgayNhap, MaPN);
            db.ExecuteNonQuery(sql);
        }

        public void CapNhat_CTPN(string MaPN, string mahh, string soluong, string dongia)
        {
            string sql = string.Format("UPDATE CT_Nhap SET  SoLuong = '{0}', DonGiaNhap = '{1}'" +
                " WHERE MaPhieuNhap = '{2}' " +
                "AND MaHang = N'{3}'", soluong, dongia, MaPN, mahh);
            db.ExecuteNonQuery(sql);
        }

        public void XoaPN(string MaPN, string MaHang)
        {
            string sql = string.Format("DELETE FROM CT_Nhap WHERE MaPhieuNhap = '{0}', MaHang = N'{1}'", MaPN, MaHang);

            db.ExecuteNonQuery(sql);
        }

        public void ThemCTPN(string ma, string mahh, string soluong, string dongianhap)
        {
            string sql = string.Format("INSERT INTO CT_Nhap VALUES('{0}', N'{1}', '{2}', '{3}')"
                , ma, mahh, soluong, dongianhap);
            db.ExecuteNonQuery(sql);
        }

    }
}
