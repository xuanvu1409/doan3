using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Areas.Admin.Controllers
{
    // GET: Admin/DonDatVe
    public class DonDatVeController : Controller
    {
        VeModel ve = new VeModel();
        NhanVienModel nv = new NhanVienModel();
        DonDatVeModel hd = new DonDatVeModel();
        public ActionResult Index()
        {
            var lv = ve.LayDanhSach();
            ViewBag.listv = lv;
            var lnv = nv.LayDanhSach();
            ViewBag.listnv = lnv;
            List<DonDatVe> dshd = hd.LayDanhSach();
            return View(dshd);
        }

        public ActionResult Lay1DonDatVe(string id)
        {
            var ll = hd.Lay1DonDatVe(id);
            return Json(ll, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Them1DonDatVe(string aoe, int MDD, string MV,  string ND, string TT)
        {
            DonDatVe h = new DonDatVe();
            h.IDDonDatVe = MDD;
            h.IDVe = MV;
            h.NgayDat = ND;
            h.TrangThai = TT;
            if (aoe == "1")
            {
                hd.Them1DonDatVe(h);
            }
            else
            {
                hd.Sua1DonDatVe(h);
            }
            return Redirect("~/Admin/DonDatVe/Index");
        }

        public ActionResult Xoa1DonDatVe(string id)
        {
            hd.Xoa1DonDatVe(id);
            return Redirect("~/Admin/DonDatVe/Index");
        }
    }

}