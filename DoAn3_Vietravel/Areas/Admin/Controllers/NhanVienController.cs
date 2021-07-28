using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: Admin/NhanVien
        NhanVienModel db = new NhanVienModel();
        public ActionResult Index()
        {
            List<NhanVien> dsnv = db.LayDanhSach();
            return View(dsnv);
        }

        public ActionResult Lay1NhanVien(string id)
        {
            var nv = db.Lay1NhanVien(id);
            return Json(nv, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Them1NhanVien(string aoe, string MNV ,string TNV, string SDT, string DC, string CV, string TK, string MK)
        {
            NhanVien nv = new NhanVien();
            nv.IDNhanVien = MNV;
            nv.TenNhanVien = TNV;
            nv.SoDienThoai = SDT;
            nv.DiaChi = DC;
            nv.CongViec = CV;
            nv.TaiKhoan = TK;
            nv.MatKhau = MK;
            if (aoe == "1")
            {
                db.Them1NhanVien(nv);
            }
            else
            {
                db.Sua1NhanVien(nv);
            }
            return Redirect("~/Admin/NhanVien/Index");
        }

        public ActionResult Xoa1NhanVien(string id)
        {
            db.Xoa1NhanVien(id);
            return Redirect("~/Admin/NhanVien/Index");
        }
    }
}