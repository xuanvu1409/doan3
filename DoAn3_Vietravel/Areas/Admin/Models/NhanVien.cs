using DoAn3_Vietravel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoAn3_Vietravel.Areas.Admin.Models
{
    public class NhanVien
    {
        public string IDNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string CongViec { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }

    }

    public class NhanVienModel
    {
        DataConnection db = new DataConnection();

        public List<NhanVien> LayDanhSach()
        {
            DataTable dt = db.LayDuLieu("Select * from NhanVien");
            List<NhanVien> li = new List<NhanVien>();
            foreach (DataRow dr in dt.Rows)
            {
                NhanVien nv = new NhanVien();
                nv.IDNhanVien = dr[0].ToString();
                nv.TenNhanVien = dr[1].ToString();
                nv.SoDienThoai = dr[2].ToString();
                nv.DiaChi = dr[3].ToString();
                nv.CongViec = dr[4].ToString();
                nv.TaiKhoan = dr[5].ToString();
                nv.MatKhau = dr[6].ToString();
                li.Add(nv);
            }
            return li;
        }

        public NhanVien Lay1NhanVien(string id)
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM NhanVien WHERE IDNhanVien ='" + id + "'");
            NhanVien nv = new NhanVien();
            nv.IDNhanVien = dt.Rows[0][0].ToString();
            nv.TenNhanVien = dt.Rows[0][1].ToString();
            nv.SoDienThoai = dt.Rows[0][2].ToString();
            nv.DiaChi = dt.Rows[0][3].ToString();
            nv.CongViec = dt.Rows[0][4].ToString();
            nv.TaiKhoan = dt.Rows[0][5].ToString();
            nv.MatKhau = dt.Rows[0][6].ToString();
            return nv;
        }

        public void Xoa1NhanVien(string id)
        {
            db.GhiDuLieu("DELETE FROM NhanVien WHERE IDNhanVien ='" + id + "'");
        }
        public void Them1NhanVien(NhanVien nv)
        {
            string sql = "INSERT INTO NhanVien(TenNhanVien, SoDienThoai, DiaChi, CongViec, TaiKhoan, MatKhau) VALUES(N'" + nv.TenNhanVien + "', '" + nv.SoDienThoai + "', N'" + nv.DiaChi + "', N'" + nv.CongViec + "', '" + nv.TaiKhoan + "', '" + nv.MatKhau + "')";
            db.GhiDuLieu(sql);
        }

        public void Sua1NhanVien(NhanVien nv)
        {
            string sql = "UPDATE NhanVien SET TenNhanVien = N'" + nv.TenNhanVien + "', SoDienThoai = '" + nv.SoDienThoai + "', DiaChi = N'" + nv.DiaChi + "', CongViec = N'" + nv.CongViec + "', TaiKhoan = '" + nv.TaiKhoan + "', MatKhau = '" + nv.MatKhau + "' WHERE IDNhanVien = '" + nv.IDNhanVien + "'";
            db.GhiDuLieu(sql);
        }

    }
}