using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Areas.Admin.Controllers
{
    public class LoaiVeController : Controller
    {
        LoaiVeModel lv = new LoaiVeModel();
        // GET: Admin/LoaiVe
        public ActionResult Index()
        {
            List<LoaiVe> dslv = lv.LayDanhSach();
            return View(dslv);
        }

        public ActionResult Lay1Loai(string id)
        {
            var ll = lv.Lay1Loai(id);
            return Json(ll, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Them1LoaiVe(string aoe, string MLoai, string TLoai, string MTa)
        {
            LoaiVe l = new LoaiVe();
            l.IDLoaiVe = MLoai;
            l.TenLoaiVe = TLoai;
            l.MoTa = MTa;
            if (aoe == "1")
            {
                lv.ThemLoaiVe(l);
            }
            else
            {
                lv.Sua1LoaiVe(l);
            }
            return Redirect("~/Admin/LoaiVe/Index");
        }

        public ActionResult Xoa1LoaiVe(string id)
        {
            lv.Xoa1LoaiVe(id);
            return Redirect("~/Admin/LoaiVe/Index");
        }
    }
}