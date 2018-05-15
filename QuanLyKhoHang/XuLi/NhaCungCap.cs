using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyKhoHang.XuLi
{
    class NhaCungCap
    {
        Database db;

        public NhaCungCap()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName
                , frmMDI.intergratedMode, frmMDI.usrName, frmMDI.pwd);
        }

        public DataTable LayDanhSachNCC()
        {
            return db.Execute("SELECT MaNhaCC, TenNhaCC, DiaChi, DienThoai " +
                "FROM NhaCC");
        }

        public void ThemNCC(string MaNhaCC, string TenNCC, string DiaChi, string dt)
        {
            string sql = string.Format("INSERT INTO NhaCC " +
                "VALUES('{0}', N'{1}', N'{2}', '{3}')",
                MaNhaCC, TenNCC, DiaChi, dt);
            db.ExecuteNonQuery(sql);
        }

        public void XoaNhaCC(string maNhaCC)
        {
            string sql = string.Format("DELETE FROM NhaCC WHERE " +
                "MaNhaCC = '" + maNhaCC + "'");
            db.ExecuteNonQuery(sql);
        }

        public void CapNhatNhaCC(string MaNhaCC, string TenNCC, 
            string DiaChi, string dt)
        {
            string sql = string.Format("UPDATE NhaCC SET TenNhaCC = N'{0}'," +
                " DiaChi = N'{1}', DienThoai = '{2}'" +
                " WHERE MaNhaCC = '{3}'", TenNCC, DiaChi, dt, MaNhaCC);
            db.ExecuteNonQuery(sql);
        }

        public DataTable TimTenNhaCC(string ten)
        {
            string sql = String.Format("SELECT MaNhaCC, TenNhaCC, DiaChi, DienThoai " +
                "FROM NhaCC " +
                "WHERE TenNhaCC = N'{0}'", ten);
            return db.Execute(sql);
        }
    }
}
