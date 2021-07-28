using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoAn3_Vietravel.Models
{
    public class ChiTietVe
    {
        DataConnection db = new DataConnection();

        public KhachSan LayThongTinKhachSan(string id)
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM KhachSan KS INNER JOIN Ve V ON KS.IDKhachSan = V.IDKhachSan  WHERE KS.IDKhachSan = '" + id + "'");
            KhachSan ks = new KhachSan();
            ks.IDKhachSan = dt.Rows[0][0].ToString();
            ks.TenKhachSan = dt.Rows[0][1].ToString();
            ks.DiaChi = dt.Rows[0][2].ToString();
            ks.SoDienThoai = dt.Rows[0][3].ToString();
            ks.Website = dt.Rows[0][4].ToString();
            return ks;
        }

        public NhanVien LayThongTinNhanVien(string id)
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM NhanVien nv INNER JOIN Ve V ON v.IDNhanVien = nv.IDNhanVien WHERE nv.IDNhanVien = '" + id + "'");
            NhanVien nv = new NhanVien();
            nv.IDNhanVien = dt.Rows[0][0].ToString();
            nv.TenNhanVien = dt.Rows[0][1].ToString();
            nv.SoDienThoai = dt.Rows[0][2].ToString();
            nv.DiaChi = dt.Rows[0][3].ToString();
            nv.CongViec = dt.Rows[0][4].ToString();
            return nv;
        }
    }
}