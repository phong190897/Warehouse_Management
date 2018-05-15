using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyKhoHang.XuLi
{
    class LoaiSP
    {
        Database db;

        public LoaiSP()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName
                , frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDanhSachNCC()
        {
            return db.Execute("SELECT MaLoai, TenLoai, MaDanhMuc " +
                "FROM LoaiSP");
        }

        public void ThemNCC(string MaLoai, string TenLoai, string MaDanhMuc)
        {
            string sql = string.Format("INSERT INTO LoaiSP " +
                "VALUES('{0}', N'{1}', N'{2}')",
                MaLoai, TenLoai, MaDanhMuc);
            db.ExecuteNonQuery(sql);
        }

        public void XoaNhaCC(string MaLoai)
        {
            string sql = string.Format("DELETE FROM LoaiSP WHERE " +
                "MaLoai = '" + MaLoai + "'");
            db.ExecuteNonQuery(sql);
        }

        public void CapNhatNhaCC(string MaLoai, string TenLoai, string MaDanhMuc)
        {
            string sql = string.Format("UPDATE LoaiSP SET TenLoai = N'{0}'," +
                " MaDanhMuc = N'{1}'" +
                " WHERE MaLoai = '{2}'", TenLoai, MaDanhMuc, MaLoai);
            db.ExecuteNonQuery(sql);
        }

        public DataTable TimTenLoai(string ten)
        {
            string sql = String.Format("SELECT MaLoai, TenLoai, MaDanhMuc " +
                "FROM LoaiSP " +
                "WHERE TenLoai LIKE N'%{0}%'", ten);
            return db.Execute(sql);
        }

    }
}
