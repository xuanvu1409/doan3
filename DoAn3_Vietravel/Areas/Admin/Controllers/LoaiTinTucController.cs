using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Areas.Admin.Controllers
{
    public class LoaiTinTucController : Controller
    {
        LoaiTinTucModel lt = new LoaiTinTucModel();
        // GET: Admin/LoaiTinTuc
        public ActionResult Index()
        {
            List<LoaiTinTuc> dslt = lt.LayDanhSach();
            return View(dslt);
        }

        public ActionResult Lay1Loai(string id)
        {
            var ll = lt.Lay1Loai(id);
            return Json(ll, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Them1LoaiTin(string aoe, string MLoai, string TLoai, string MTa)
        {
            LoaiTinTuc l = new LoaiTinTuc();
            l.IDLoaiTinTuc = MLoai;
            l.TenLoaiTin = TLoai;
            l.MoTa = MTa;
            if (aoe == "1")
            {
                lt.Them1LoaiTin(l);
            }
            else
            {
                lt.Sua1LoaiTin(l);
            }
            return Redirect("~/Admin/LoaiTinTuc/Index");
        }

        public ActionResult Xoa1LoaiTin(string id)
        {
            lt.Xoa1LoaiTin(id);
            return Redirect("~/Admin/LoaiTinTuc/Index");
        }
    }
}