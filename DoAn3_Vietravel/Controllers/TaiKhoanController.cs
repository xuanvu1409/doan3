using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Controllers
{
    public class TaiKhoanController : Controller
    {
        KhachHangModel tk = new KhachHangModel();
        // GET: TaiKhoan
        public ActionResult TaiKhoan()
        {
            return View();
        }

        public ActionResult actionDangNhap(string TK, string MK)
        {
            var dn = tk.LayDanhSach();
            int code = 0;

            var ise = dn.Find(mtk => mtk.TaiKhoan.ToLower() == TK.ToLower());
            var pas = dn.Find(mmk => mmk.MatKhau.ToLower() == MK.ToLower());
            if (ise != null)
            {
                Session["TaiKhoan"] = ise;
                code = 1;
            }
            return Json(new { Code = code }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DangKy()
        {
            return View();
        }

        public ActionResult actionDangKy(string MKH, string TKH, string NS, string EM, string SDT, string DC, string TK, string MK, string QT)
        {
            var dk = tk.LayDanhSach();

            int code = 0;
            var ise = dk.Find(mtk => mtk.TaiKhoan.ToLower() == TK.ToLower());
            if (ise == null)
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
                tk.Them1KhachHang(kh);
                code = 1;
            }
            return Json(new { Code = code }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return Redirect("~/Home/Index");
        }

        public ActionResult checkLogin()
        {
            int Code = 0;
            if (Session["TaiKhoan"] != null)
            {
                Code = 1;
            }
            return Json(new { code = Code}, JsonRequestBehavior.AllowGet);
        }
    }
}