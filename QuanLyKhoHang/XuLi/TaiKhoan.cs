using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyKhoHang.XuLi
{
    class TaiKhoan
    {

        Database db;

        public TaiKhoan()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName, frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDanhSachTK()
        {
            return db.Execute("SELECT TenTk, MatKhau, TenQuyenDN, HoTen FROM TaiKhoan A, QuyenDN B " +
                "WHERE A.QuyenDN = B.QuyenDN");
        }

        public DataTable Lay_QuyenDN(string tentk, string mk)
        {
            return db.Execute("SELECT QuyenDN FROM TaiKhoan WHERE TenTK = '" + tentk + "' AND MatKhau = '" + mk + "'");
        }

        public DataTable Lay_MK(string tentk, string mk)
        {
            return db.Execute("SELECT MatKhau FROM TaiKhoan WHERE TenTK = '" + tentk + "' AND MatKhau = '" + mk + "'");
        }

        public DataTable Lay_DS_QuyenDN()
        {
            return db.Execute("SELECT QuyenDN, TenQuyenDN FROM QUYENDN WHERE QuyenDN != 'AD'");
        }

        public DataTable QuyenDN()
        {
            return db.Execute("SELECT * FROM QuyenDN WHERE QuyenDN = 'AD'");
        }

        public void ThemTaiKhoan(string tenTK, string mk, string quyen, string hoten)
        {
            string sql = string.Format("INSERT INTO TaiKhoan VALUES('{0}', '{1}', '{2}', N'{3}')", tenTK, mk, quyen, hoten);
            db.ExecuteNonQuery(sql);
        }

        public void XoaTaiKhoan(string tenTK)
        {
            db.ExecuteNonQuery("DELETE FROM TaiKhoan WHERE TenTK = '" + tenTK + "'");
        }

        public void CapNhatTaiKhoan(string tenTK, string mk, string quyen, string hoten)
        {
            string sql = string.Format("UPDATE TaiKhoan SET MatKhau = '{0}', QuyenDN = '{1}', HoTen = N'{2}' WHERE  TenTK = '{3}'", mk, quyen, hoten, tenTK);
            db.ExecuteNonQuery(sql);
        }

        public DataTable LayTenTK(string tentk)
        {
            return db.Execute("SELECT TenTK FROM TaiKhoan WHERE TenTK = '" + tentk + "'");
        }

        public DataTable layHoTen(string tentk, string mk)
        {
            return db.Execute("SELECT HoTen FROM TaiKhoan WHERE TenTK = '" + tentk + "' AND MatKhau = '" + mk + "'");
        }

        public DataTable Tim_NV(string hoten)
        {
            return db.Execute("SELECT TenTK, MatKhau, TenQuyenDN, HoTen " +
                "FROM TaiKhoan A, QuyenDN B " +
                "WHERE A.QuyenDN = B.QuyenDN " +
                "AND HoTen LIKE N'%" + hoten + "%'");
        }

        public DataTable KiemTra_TK_TonTai(string tentk)
        {
            return db.Execute("SELECT * FROM TaiKhoan WHERE TenTK = '" + tentk + "'");
        }

    }
}
