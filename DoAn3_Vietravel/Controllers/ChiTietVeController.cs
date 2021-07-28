using DoAn3_Vietravel.Areas.Admin.Models;
using DoAn3_Vietravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Controllers
{
    public class ChiTietVeController : Controller
    {
        ChiTietVe lct = new ChiTietVe();
        VeModel ve = new VeModel();
        // GET: ChiTietVe
        public ActionResult Index(string id)
        {
            var ctv = ve.Lay1Ve(id);

            return View(ctv);
        }

        public ActionResult ThongTinKhachSan(string id)
        {
            KhachSan lks = lct.LayThongTinKhachSan(id);
            return View(lks);
        }

        public ActionResult ThongTinNhanVien(string id)
        {
            NhanVien lnv = lct.LayThongTinNhanVien(id);
            return View(lnv);
        }
    }
}