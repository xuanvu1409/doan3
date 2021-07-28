using DoAn3_Vietravel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoAn3_Vietravel.Areas.Admin.Models
{
    public class ChiTietDonDatVe
    {
        public string IDDonDatVe { get; set; }
        public string IDKhachHang { get; set; }
        public int SoKhach { get; set; }
        public int PhuThu { get; set; }
        public int DonGia { get; set; }
    }

    public class ChiTietDonDatVeModel
    {
        DataConnection db = new DataConnection();

        public List<ChiTietDonDatVe> LayDanhSach()
        {
            DataTable dt = db.LayDuLieu("Select * from ChiTietDonDatVe");
            List<ChiTietDonDatVe> li = new List<ChiTietDonDatVe>();
            foreach (DataRow dr in dt.Rows)
            {
                ChiTietDonDatVe ctdh = new ChiTietDonDatVe();
                ctdh.IDDonDatVe = dr[0].ToString();
                ctdh.IDKhachHang = dr[1].ToString();
                ctdh.SoKhach = int.Parse(dr[2].ToString());
                ctdh.PhuThu = int.Parse(dr[3].ToString());
                ctdh.DonGia = int.Parse(dr[4].ToString());
                li.Add(ctdh);
            }
            return li;
        }

        public ChiTietDonDatVe Lay1ChiTietDon(string id)
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM ChiTietDonDatVe WHERE IDDonDatVe ='" + id + "'");
            ChiTietDonDatVe dd = new ChiTietDonDatVe();
            dd.IDDonDatVe = dt.Rows[0][0].ToString();
            dd.IDKhachHang = dt.Rows[0][1].ToString();
            dd.SoKhach = int.Parse(dt.Rows[0][2].ToString());
            dd.PhuThu = int.Parse(dt.Rows[0][3].ToString());
            dd.DonGia = int.Parse(dt.Rows[0][4].ToString());
            return dd;
        }

        public void Xoa1DonChiTiet(string id)
        {
            db.GhiDuLieu("DELETE FROM ChiTietDonDatVe WHERE IDDonDatVe ='" + id + "'");
        }
        public void Them1DonDatVe(ChiTietDonDatVe dd)
        {
            string sql = "INSERT INTO ChiTietDonDatVe VALUES('" + dd.IDDonDatVe + "', '" + dd.IDKhachHang + "', '" + dd.SoKhach + "', '" + dd.PhuThu + "', '" + dd.DonGia + "')";
            db.GhiDuLieu(sql);
        }

        public void Sua1DonChiTiet(ChiTietDonDatVe dd)
        {
            string sql = "UPDATE ChiTietDonDatVe SET IDKhachHang = '" + dd.IDKhachHang + "', SoKhach = '" + dd.SoKhach + "', PhuThu = '" + dd.PhuThu + "', DonGia = '" + dd.DonGia + "' WHERE IDDonDatVe = '" + dd.IDDonDatVe + "'";
            db.GhiDuLieu(sql);
        }
    }
}