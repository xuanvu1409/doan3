using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Areas.Admin.Controllers
{
    public class ChiTietDonDatVeController : Controller
    {
        ChiTietDonDatVeModel ctdd = new ChiTietDonDatVeModel();
        DonDatVeModel dd = new DonDatVeModel();
        KhachHangModel kh = new KhachHangModel();
        // GET: Admin/ChiTietDonDatVe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadDonDat()
        {
            List<ChiTietDonDatVe> gh = null;
            if (Session["chitietdondatve"] != null)
            {
                gh = (List<ChiTietDonDatVe>)Session["chitietdondatve"];
            }
            int tongtien = 0;
            int soluong = 0;
            if (gh != null)
            {
                foreach (ChiTietDonDatVe x in gh)
                {
                    tongtien += x.PhuThu + x.DonGia;
                }
                soluong = gh.Count;
            }
            return Json(new { giohang = gh, TongTien = tongtien, SoLuong = soluong }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Xoa1KhachHang(string id)
        {
            List<ChiTietDonDatVe> gh = null;
            gh = (List<ChiTietDonDatVe>)Session["chitietdondatve"];
            var test = gh.Find(s => s.IDDonDatVe.ToString().Trim() == id.Trim());
            if (test != null)
                gh.Remove(test);
            Session["chitietdondatve"] = gh;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ThanhToan()
        {
            int tongtien = 0;
            List<ChiTietDonDatVe> gh = null;
            ViewBag.tongtien = null;
            int count = 0;
            if (Session["chitietdondatve"] != null)
            {
                gh = (List<ChiTietDonDatVe>)Session["chitietdondatve"];
                foreach (ChiTietDonDatVe a in gh)
                {
                    tongtien += a.PhuThu + a.DonGia;
                }
                count = gh.Count;
            }
            ViewBag.count = count;
            ViewBag.tongtien = tongtien;
            return View(gh);
        }
    }
}