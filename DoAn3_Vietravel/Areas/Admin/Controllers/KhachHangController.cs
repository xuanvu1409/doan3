using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        KhachHangModel db = new KhachHangModel();
        // GET: Admin/KhachHang
        public ActionResult Index()
        {
            List<KhachHang> dskh = db.LayDanhSach();
            return View(dskh);
        }

        public ActionResult Lay1KhachHang(string id)
        {
            var lkh = db.Lay1KhachHang(id);
            return Json(lkh, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Them1KhachHang(string aoe, string MKH, string TKH, string NS, string EM, string SDT, string DC, string TK, string MK, string QT)
        {
            KhachHang kh = new KhachHang();
            kh.IDKhachHang = MKH;
            kh.TenKhachHang = TKH;
            kh.NgaySinh = NS;
            kh.Email = EM;
            kh.SoDienThoai = SDT;
            kh.DiaChi = DC;
            kh.TaiKhoan = TK;
            kh.MatKhau = MK;
            kh.QuocTich = QT;
            if (aoe == "1")
            {
                db.Them1KhachHang(kh);
            }
            else
            {
                db.Sua1KhachHang(kh);
            }
            return Redirect("~/Admin/KhachHang/Index");
        }

        public ActionResult Xoa1KhachHang(string id)
        {
            db.Xoa1KhachHang(id);
            return Redirect("~/Admin/KhachHang/Index");
        }
    }
}