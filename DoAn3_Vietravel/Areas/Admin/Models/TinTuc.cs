using DoAn3_Vietravel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoAn3_Vietravel.Areas.Admin.Models
{
    public class TinTuc
    {
        public string IDTinTuc { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string AnhDaiDien { get; set; }
        public string NoiDung { get; set; }
        public string Tags { get; set; }
        public string TacGia { get; set; }
        public string NgayViet { get; set; }
        public int LuotXem { get; set; }
        public string IDLoaiTin { get; set; }
        public string TrangThai { get; set; }
        public string IDNhanVien { get; set; }
    }

    public class TinTucModel
    {
        DataConnection db = new DataConnection();

        public List<TinTuc> LayDanhSach()
        {
            DataTable dt = db.LayDuLieu("Select * from TinTuc");
            List<TinTuc> li = new List<TinTuc>();
            foreach (DataRow dr in dt.Rows)
            {
                TinTuc tt = new TinTuc();
                tt.IDTinTuc = dr[0].ToString();
                tt.TieuDe = dr[1].ToString();
                tt.MoTa = dr[2].ToString();
                tt.AnhDaiDien = dr[3].ToString();
                tt.NoiDung = dr[4].ToString();
                tt.Tags = dr[5].ToString();
                tt.TacGia = dr[6].ToString();
                tt.NgayViet = dr[7].ToString();
                tt.LuotXem = int.Parse(dr[8].ToString());
                tt.IDLoaiTin = dr[9].ToString();
                tt.TrangThai = dr[10].ToString();
                tt.IDNhanVien = dr[11].ToString();
                li.Add(tt);
            }
            return li;
        }

        public TinTuc Lay1TinTuc(string id)
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM TinTuc WHERE IDTinTuc ='" + id + "'");
            TinTuc tt = new TinTuc();
            tt.IDTinTuc = dt.Rows[0][0].ToString();
            tt.TieuDe = dt.Rows[0][1].ToString();
            tt.MoTa = dt.Rows[0][2].ToString();
            tt.AnhDaiDien = dt.Rows[0][3].ToString();
            tt.NoiDung = dt.Rows[0][4].ToString();
            tt.Tags = dt.Rows[0][5].ToString();
            tt.TacGia = dt.Rows[0][6].ToString();
            tt.NgayViet = dt.Rows[0][7].ToString();
            tt.LuotXem = int.Parse(dt.Rows[0][8].ToString());
            tt.IDLoaiTin = dt.Rows[0][9].ToString();
            tt.TrangThai = dt.Rows[0][10].ToString();
            tt.IDNhanVien = dt.Rows[0][11].ToString();
            return tt;
        }

        public void Xoa1TinTuc(string id)
        {
            db.GhiDuLieu("DELETE FROM TinTuc WHERE IDTinTuc ='" + id + "'");
        }
        public void Them1TinTuc(TinTuc tt)
        {
            string sql = "INSERT INTO TinTuc(TieuDe, MoTa, AnhDaiDien, NoiDung, Tags, TacGia, NgayViet, LuotXem, IDLoaiTin, TrangThai, IDNhanVien) VALUES(N'" + tt.TieuDe + "', N'" + tt.MoTa + "','" + tt.AnhDaiDien + "', N'" + tt.NoiDung + "', '" + tt.Tags + "', '" + tt.TacGia + "', '" + LayNgay(tt.NgayViet) + "', '" + tt.LuotXem + "', '" + tt.IDLoaiTin + "', N'" + tt.TrangThai + "', '" + tt.IDNhanVien + "')";
            db.GhiDuLieu(sql);
        }

        public void Sua1TinTuc(TinTuc tt)
        {
            string sql = "UPDATE TinTuc SET TieuDe = N'" + tt.TieuDe + "', MoTa = N'" + tt.MoTa + "', AnhDaiDien = '" + tt.AnhDaiDien + "', NoiDung = N'" + tt.NoiDung + "', Tags = '" + tt.Tags + "', TacGia = N'" + tt.TacGia + "', NgayViet = '" + LayNgay(tt.NgayViet) + "', LuotXem = '" + tt.LuotXem + "', IDLoaiTin = '" + tt.IDLoaiTin + "', TrangThai = N'" + tt.TrangThai + "', IDNhanVien = '" + tt.IDNhanVien + "' WHERE IDTinTuc = '" + tt.IDTinTuc + "'";
            db.GhiDuLieu(sql);
        }

        public string LayNgay(string t)
        {
            DateTime dt = DateTime.Now;
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
    }
}