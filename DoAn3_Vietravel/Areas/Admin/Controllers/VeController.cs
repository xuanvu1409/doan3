using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Areas.Admin.Controllers
{
    public class VeController : Controller
    {
        VeModel db = new VeModel();
        KhachSanModel ks = new KhachSanModel();
        NhanVienModel nv = new NhanVienModel();
        LoaiVeModel lv = new LoaiVeModel();

        // GET: Admin/Ve
        public ActionResult Index(string id)
        {
            var dsks = ks.LayDanhSach();
            ViewBag.IDKS = dsks;
            var dsnv = nv.LayDanhSach();
            ViewBag.IDNV = dsnv;
            var dslv = lv.LayDanhSach();
            ViewBag.IDLV = dslv;
            var dsv = db.LayDanhSach();
            return View(dsv);
        }

        public ActionResult Lay1Ve(string id)
        {
            var lv = db.Lay1Ve(id);
            return Json(lv, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Them1Ve(string aoe, string MV, string TV, string KV, string NKH, string NKT, string NTT, int TG, string LT, int GB, int SC, string TT, HttpPostedFileBase HA, string VC, string MKS, string MNV, string LY, string GC, int PT, string MLV)
        {
            Ve v = new Ve();
            v.IDVe = MV;
            v.TenVe = TV;
            v.KieuVe = KV;
            v.NgayKhoiHanh = NKH;
            v.NgayKetThuc = NKT;
            v.NoiTapTrung = NTT;
            v.ThoiGian = TG;
            v.LichTrinh = LT;
            v.Gia = GB;
            v.SoCho = SC;
            v.TrangThai = TT;
            v.HinhThucVanChuyen = VC;
            v.IDKhachSan = MKS;
            v.IDNhanVien = MNV;
            v.LuuY = LY;
            v.GhiChu = GC;
            v.PhuThu = PT;
            v.IDLoaiVe = MLV;
            if (HA.ContentLength > 0)
            {
                string path = Server.MapPath("~/Assets/images/Tour") + "/" + HA.FileName;
                HA.SaveAs(path);
                v.HinhAnh = HA.FileName;
            }
            if (aoe == "1")
            {
                db.Them1Ve(v);
            }
            else
            {
                db.Sua1Ve(v);
            }
            return Redirect("~/Admin/Ve/Index");
        }

        public ActionResult Xoa1Ve(string id)
        {
            db.Xoa1Ve(id);
            return Redirect("~/Admin/Ve/Index");
        }
    }
}