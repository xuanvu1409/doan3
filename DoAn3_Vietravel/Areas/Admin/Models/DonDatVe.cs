using DoAn3_Vietravel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoAn3_Vietravel.Areas.Admin.Models
{
    public class DonDatVe
    {
        public int IDDonDatVe { get; set; }
        public string IDVe { get; set; }
        public string NgayDat { get; set; }
        public string TrangThai { get; set; }
    }

    public class DonDatVeModel
    {
        DataConnection db = new DataConnection();

        public List<DonDatVe> LayDanhSach()
        {
            DataTable dt = db.LayDuLieu("Select * from DonDatVe");
            List<DonDatVe> li = new List<DonDatVe>();
            foreach (DataRow dr in dt.Rows)
            {
                DonDatVe dd = new DonDatVe();
                dd.IDDonDatVe = int.Parse(dr[0].ToString());
                dd.IDVe = dr[1].ToString();
                dd.NgayDat = dr[2].ToString();
                dd.TrangThai = dr[3].ToString();
                li.Add(dd);
            }
            return li;
        }

        public DonDatVe Lay1DonDatVe(string id)
        {
            DataTable dt = db.LayDuLieu("SELECT * FROM DonDatVe WHERE IDDonDatVe ='" + id + "'");
            DonDatVe dd = new DonDatVe();
            dd.IDDonDatVe = int.Parse(dt.Rows[0][0].ToString());
            dd.IDVe = dt.Rows[0][1].ToString();
            dd.NgayDat = dt.Rows[0][2].ToString();
            dd.TrangThai = dt.Rows[0][3].ToString();
            return dd;
        }

        public void Xoa1DonDatVe(string id)
        {
            db.GhiDuLieu("DELETE FROM DonDatVe WHERE IDDonDatVe ='" + id + "'");
        }
        public void Them1DonDatVe(DonDatVe dd)
        {
            string sql = "INSERT INTO DonDatVe(IDVe, NgayDat, TrangThai) VALUES('" + dd.IDVe + "', '" + LayNgay(dd.NgayDat) + "', N'" + dd.TrangThai + "')";
            db.GhiDuLieu(sql);
        }

        public void Sua1DonDatVe(DonDatVe dd)
        {
            string sql = "UPDATE DonDatVe SET IDVe = '" + dd.IDVe + "', NgayDat = '" + LayNgay(dd.NgayDat) + "', TrangThai = N'" + dd.TrangThai + "' WHERE IDDonDatVe = '" + dd.IDDonDatVe + "'";
            db.GhiDuLieu(sql);
        }

        public string layMaVuaThem()
        {
            string ID = "1";
            try
            {
                DataTable dt = db.LayDuLieu("SELECT TOP 1 IDDonDatVe FROM DonDatVe ORDER BY IDDonDatVe DESC");
                ID = dt.Rows[0][0].ToString();
            }
            catch (Exception) { }
            return ID;
        }

        public string LayNgay(string t)
        {
            DateTime dt = DateTime.Now;
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }
    }
}