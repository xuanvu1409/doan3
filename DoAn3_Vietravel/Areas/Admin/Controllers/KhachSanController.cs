using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Areas.Admin.Controllers
{
    public class KhachSanController : Controller
    {
        KhachSanModel db = new KhachSanModel();
        // GET: Admin/KhachSan
        public ActionResult Index()
        {
            List<KhachSan> dsks = db.LayDanhSach();
            return View(dsks);
        }

        public ActionResult Lay1KhachSan(string id)
        {
            var ks = db.Lay1KhachSan(id);
            return Json(ks, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Them1KhachSan(string aoe, string MKS, string TKS, string DC, string SDT, string WS)
        {
            KhachSan ks = new KhachSan();
            ks.IDKhachSan = MKS;
            ks.TenKhachSan = TKS;
            ks.DiaChi = DC;
            ks.SoDienThoai = SDT;
            ks.Website = WS;
            if (aoe == "1")
            {
                db.Them1KhachSan(ks);
            }
            else
            {
                db.Sua1KhachSan(ks);
            }
            return Redirect("~/Admin/KhachSan/Index");
        }

        public ActionResult Xoa1KhachSan(string id)
        {
            db.Xoa1KhachSan(id);
            return Redirect("~/Admin/KhachSan/Index");
        }
    }
}