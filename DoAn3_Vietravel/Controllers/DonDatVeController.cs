using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Controllers
{
    public class DonDatVeController : Controller
    {
        DonDatVeModel db = new DonDatVeModel();
        ChiTietDonDatVeModel ddv = new ChiTietDonDatVeModel();
        VeModel ve = new VeModel();
        // GET: DonDatVe
        public ActionResult Index(string id)
        {
            Ve v = ve.Lay1Ve(id);
            return View(v);
        }

        public ActionResult DatVe(string MV,int pt, int sc, int gb)
        {
            string id = null;
            if (Session["TaiKhoan"] != null)
            {
                id = ((KhachHang)Session["TaiKhoan"]).IDKhachHang;
            }
            DonDatVe dv = new DonDatVe();
            dv.IDVe = MV;
            dv.TrangThai = "Chưa Thanh Toán";
            db.Them1DonDatVe(dv);

            string ID = db.layMaVuaThem();

            ChiTietDonDatVe ct = new ChiTietDonDatVe();
            ct.IDDonDatVe = ID;
            ct.IDKhachHang = id;
            ct.SoKhach = sc;
            ct.PhuThu = pt;
            ct.DonGia = gb;
            ddv.Them1DonDatVe(ct);

            ve.capNhatSoCho(MV, sc);

            return View();
        }
    }
}