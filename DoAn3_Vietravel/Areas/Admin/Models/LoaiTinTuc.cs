using DoAn3_Vietravel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoAn3_Vietravel.Areas.Admin.Models
{
    public class LoaiTinTuc
    {
        public string IDLoaiTinTuc { get; set; }
        public string TenLoaiTin { get; set; }
        public string MoTa { get; set; }
    }

    public class LoaiTinTucModel
    {
        DataConnection db = new DataConnection();

        public List<LoaiTinTuc> LayDanhSach()
        {
            DataTable dt = db.LayDuLieu("Select * from LoaiTinTuc");
            List<LoaiTinTuc> li = new List<LoaiTinTuc>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiTinTuc lt = new LoaiTinTuc();
                lt.IDLoaiTinTuc = dr[0].ToString();
                lt.TenLoaiTin = dr[1].ToString();
                lt.MoTa = dr[2].ToString();
                li.Add(lt);
            }
            return li;
        }

        public LoaiTinTuc Lay1Loai(string id)
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM LoaiTinTuc WHERE IDLoaiTinTuc ='" + id + "'");
            LoaiTinTuc lt = new LoaiTinTuc();
            lt.IDLoaiTinTuc = dt.Rows[0][0].ToString();
            lt.TenLoaiTin = dt.Rows[0][1].ToString();
            lt.MoTa = dt.Rows[0][2].ToString();
            return lt;
        }

        public void Xoa1LoaiTin(string id)
        {
            db.GhiDuLieu("DELETE FROM LoaiTinTuc WHERE IDLoaiTinTuc ='" + id + "'");
        }
        public void Them1LoaiTin(LoaiTinTuc lt)
        {
            string sql = "INSERT INTO LoaiTinTuc(TenLoaiTin, MoTa) VALUES(N'" + lt.TenLoaiTin + "', N'" + lt.MoTa + "')";
            db.GhiDuLieu(sql);
        }

        public void Sua1LoaiTin(LoaiTinTuc lt)
        {
            string sql = "UPDATE LoaiTinTuc SET TenLoaiTin = N'" + lt.TenLoaiTin + "', MoTa = N'" + lt.MoTa + "' WHERE IDLoaiTinTuc = '" + lt.IDLoaiTinTuc + "'";
            db.GhiDuLieu(sql);
        }
    }
}