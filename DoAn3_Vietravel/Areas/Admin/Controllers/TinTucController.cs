using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace DoAn3_Vietravel.Areas.Admin.Controllers
{
    public class TinTucController : Controller
    {
        TinTucModel db = new TinTucModel();
        LoaiTinTucModel ltt = new LoaiTinTucModel();
        NhanVienModel nv = new NhanVienModel();
        // GET: Admin/TinTuc
        public ActionResult Index()
        {
            var dsltt = ltt.LayDanhSach();
            ViewBag.IDLT = dsltt;
            var dsnv = nv.LayDanhSach();
            ViewBag.IDNV = dsnv;
            List<TinTuc> dstt = db.LayDanhSach();
            return View(dstt);
        }

        public ActionResult Lay1TinTuc(string id)
        {
            var tt = db.Lay1TinTuc(id);
            return Json(tt, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Them1TinTuc(string aoe, string MTT, string TD, string MT, HttpPostedFileBase ADD, string ND, string TS, string TG, string NV, int LX, string MLT, string TT, string MNV)
        {
            TinTuc tt = new TinTuc();
            tt.IDTinTuc = MTT;
            tt.TieuDe = TD;
            tt.MoTa = MT;
            tt.NoiDung = ND;
            tt.Tags = TS;
            tt.TacGia = TG;
            tt.NgayViet = NV;
            tt.LuotXem = LX;
            tt.IDLoaiTin = MLT;
            tt.TrangThai = TT;
            tt.IDNhanVien = MNV;
            if (ADD.ContentLength > 0)
            {
                string path = Server.MapPath("~/Assets/images/Tour") + "/" + ADD.FileName;
                ADD.SaveAs(path);
                tt.AnhDaiDien = ADD.FileName;
            }
            if (aoe == "1")
            {
                db.Them1TinTuc(tt);
            }
            else
            {
                db.Sua1TinTuc(tt);
            }
            return Redirect("~/Admin/TinTuc/Index");
        }

        public ActionResult Xoa1TinTuc(string id)
        {
            db.Xoa1TinTuc(id);
            return Redirect("~/Admin/TinTuc/Index");
        }
    }
}