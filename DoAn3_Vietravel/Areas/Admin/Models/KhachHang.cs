using DoAn3_Vietravel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoAn3_Vietravel.Areas.Admin.Models
{
    public class KhachHang
    {
        public string IDKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string NgaySinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string QuocTich { get; set; }
    }

    public class KhachHangModel
    {
        DataConnection db = new DataConnection();

        public List<KhachHang> LayDanhSach()
        {
            DataTable dt = db.LayDuLieu("Select * from KhachHang");
            List<KhachHang> li = new List<KhachHang>();
            foreach (DataRow dr in dt.Rows)
            {
                KhachHang kh = new KhachHang();
                kh.IDKhachHang = dr[0].ToString();
                kh.TenKhachHang = dr[1].ToString();
                kh.NgaySinh = dr[2].ToString();
                kh.Email = dr[3].ToString();
                kh.SoDienThoai = dr[4].ToString();
                kh.DiaChi = dr[5].ToString();
                kh.TaiKhoan = dr[6].ToString();
                kh.MatKhau = dr[7].ToString();
                kh.QuocTich = dr[8].ToString();
                li.Add(kh);
            }
            return li;
        }

        public KhachHang Lay1KhachHang(string id)
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM KhachHang WHERE IDKhachHang ='" + id + "'");
            KhachHang kh = new KhachHang();
            kh.IDKhachHang = dt.Rows[0][0].ToString();
            kh.TenKhachHang = dt.Rows[0][1].ToString();
            kh.NgaySinh = dt.Rows[0][2].ToString();
            kh.Email = dt.Rows[0][3].ToString();
            kh.SoDienThoai = dt.Rows[0][4].ToString();
            kh.DiaChi = dt.Rows[0][5].ToString();
            kh.TaiKhoan = dt.Rows[0][6].ToString();
            kh.MatKhau = dt.Rows[0][7].ToString();
            kh.QuocTich = dt.Rows[0][8].ToString();
            return kh;
        }

        public void Xoa1KhachHang(string id)
        {
            db.GhiDuLieu("DELETE FROM KhachHang WHERE IDKhachHang ='" + id + "'");
        }
        public void Them1KhachHang(KhachHang kh)
        {
            string sql = "INSERT INTO KhachHang(TenKhachHang, NgaySinh, Email, SoDienThoai, DiaChi, TaiKhoan, MatKhau, QuocTich) VALUES(N'" + kh.TenKhachHang + "', '" + LayNgay(kh.NgaySinh) + "', '" + kh.Email + "', '" + kh.SoDienThoai + "', N'" + kh.DiaChi + "', '" + kh.TaiKhoan + "', '" + kh.MatKhau + "', N'" + kh.QuocTich + "')";
            db.GhiDuLieu(sql);
        }

        public void Sua1KhachHang(KhachHang kh)
        {
            string sql = "UPDATE KhachHang SET TenKhachHang = N'" + kh.TenKhachHang + "', NgaySinh = '" + LayNgay(kh.NgaySinh) + "', Email = '" + kh.Email + "', SoDienThoai = '" + kh.SoDienThoai + "', DiaChi = N'" + kh.DiaChi + "', TaiKhoan = '" + kh.TaiKhoan + "', MatKhau = '" + kh.MatKhau + "', QuocTich = N'" + kh.QuocTich + "' WHERE IDKhachHang = '" + kh.IDKhachHang + "'";
            db.GhiDuLieu(sql);
        }

        public string LayNgay(string t)
        {
            DateTime dt = Convert.ToDateTime(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
    }
}