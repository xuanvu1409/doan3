using DoAn3_Vietravel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoAn3_Vietravel.Areas.Admin.Models
{
    public class KhachSan
    {
        public string IDKhachSan { get; set; }
        public string TenKhachSan { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Website { get; set; }
    }

    public class KhachSanModel
    {
        DataConnection db = new DataConnection();

        public List<KhachSan> LayDanhSach()
        {
            DataTable dt = db.LayDuLieu("Select * from KhachSan");
            List<KhachSan> li = new List<KhachSan>();
            foreach (DataRow dr in dt.Rows)
            {
                KhachSan ks = new KhachSan();
                ks.IDKhachSan = dr[0].ToString();
                ks.TenKhachSan = dr[1].ToString();
                ks.DiaChi = dr[2].ToString();
                ks.SoDienThoai = dr[3].ToString();
                ks.Website = dr[4].ToString();
                li.Add(ks);
            }
            return li;
        }

        public KhachSan Lay1KhachSan(string id)
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM KhachSan WHERE IDKhachSan ='" + id + "'");
            KhachSan ks = new KhachSan();
            ks.IDKhachSan = dt.Rows[0][0].ToString();
            ks.TenKhachSan = dt.Rows[0][1].ToString();
            ks.DiaChi = dt.Rows[0][2].ToString();
            ks.SoDienThoai = dt.Rows[0][3].ToString();
            ks.Website = dt.Rows[0][4].ToString();
            return ks;
        }

        public void Xoa1KhachSan(string id)
        {
            db.GhiDuLieu("DELETE FROM KhachSan WHERE IDKhachSan ='" + id + "'");
        }
        public void Them1KhachSan(KhachSan ks)
        {
            string sql = "INSERT INTO KhachSan(TenKhachSan, DiaChi, SoDienThoai, Website) VALUES(N'" + ks.TenKhachSan + "', N'" + ks.DiaChi + "', '" + ks.SoDienThoai + "', '" + ks.Website + "')";
            db.GhiDuLieu(sql);
        }

        public void Sua1KhachSan(KhachSan ks)
        {
            string sql = "UPDATE KhachSan SET TenKhachSan = N'" + ks.TenKhachSan + "', DiaChi = N'" + ks.DiaChi + "', SoDienThoai = '" + ks.SoDienThoai + "', Website = '" + ks.Website + "' WHERE IDKhachSan = '" + ks.IDKhachSan + "'";
            db.GhiDuLieu(sql);
        }

    }
}