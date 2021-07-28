using DoAn3_Vietravel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoAn3_Vietravel.Areas.Admin.Models
{
    public class LoaiVe
    {
        public string IDLoaiVe { get; set; }
        public string TenLoaiVe { get; set; }
        public string MoTa { get; set; }
    }

    public class LoaiVeModel
    {
        // khởi tạo một đối tượng thuộc lớp dataconnection
        DataConnection db = new DataConnection();

        //lấy tất cả nhân viên trong bảng loại vé

        public List<LoaiVe> LayDanhSach()
        {
            DataTable dt = db.LayDuLieu("Select * from LoaiVe");
            List<LoaiVe> li = new List<LoaiVe>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiVe lv = new LoaiVe();
                lv.IDLoaiVe = dr[0].ToString();
                lv.TenLoaiVe = dr[1].ToString();
                lv.MoTa = dr[2].ToString();
                li.Add(lv);
            }
            return li;
        }

        public LoaiVe Lay1Loai(string id)
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM LoaiVe WHERE IDLoaiVe ='" + id + "'");
            LoaiVe lv = new LoaiVe();
            lv.IDLoaiVe = dt.Rows[0][0].ToString();
            lv.TenLoaiVe = dt.Rows[0][1].ToString();
            lv.MoTa = dt.Rows[0][2].ToString();
            return lv;
        }

        public void Xoa1LoaiVe(string id)
        {
            db.GhiDuLieu("DELETE FROM LoaiVe WHERE IDLoaiVe ='" + id + "'");
        }
        public void ThemLoaiVe(LoaiVe lv)
        {
            string sql = "INSERT INTO LoaiVe(TenLoaiVe, MoTa) VALUES(N'" + lv.TenLoaiVe + "', N'" + lv.MoTa + "')";
            db.GhiDuLieu(sql);
        }

        public void Sua1LoaiVe(LoaiVe lv)
        {
            string sql = "UPDATE LoaiVe SET TenLoaiVe = N'" + lv.TenLoaiVe + "', MoTa = N'" + lv.MoTa + "' WHERE IDLoaiVe = '" + lv.IDLoaiVe + "'";
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