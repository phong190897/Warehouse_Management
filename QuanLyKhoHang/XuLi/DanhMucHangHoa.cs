using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyKhoHang.XuLi
{
    class DanhMucHangHoa
    {
        Database db;

        public DanhMucHangHoa()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName
                , frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDanhSachDMHH()
        {
            return db.Execute("SELECT MaDanhMuc, TenDanhMuc " +
                                "FROM NganhHang");
        }

        public void ThemDMHH(string MaDM, string TenDM)
        {
            string sql = string.Format("INSERT INTO NganhHang " +
                "VALUES('{0}', N'{1}'",
                MaDM, TenDM);
            db.ExecuteNonQuery(sql);
        }

        public void XoaDMHH(string MaDanhMuc)
        {
            string sql = string.Format("DELETE FROM NganhHang WHERE " +
                "MaDanhMuc = '" + MaDanhMuc + "'");
            db.ExecuteNonQuery(sql);
        }

        public void CapNhatDMHH(string MaDanhMuc, string TenDanhMuc)
        {
            string sql = string.Format("UPDATE NganhHang SET TenDanhMuc = N'{0}'," +
                " WHERE MaDanhMuc = '{1}'", TenDanhMuc, MaDanhMuc);
            db.ExecuteNonQuery(sql);
        }

        public DataTable LayDSTenDM(string ten)
        {
            string sql = string.Format("SELECT MaDanhMuc, TenDanhMuc " +
                "FROM NganhHang " +
                "WHERE TenDanhMuc LIKE N'%{0}%'", ten);
            return db.Execute(sql);
        }
    }
}
