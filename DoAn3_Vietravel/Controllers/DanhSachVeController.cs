using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Controllers
{
    public class DanhSachVeController : Controller
    {
        VeModel v = new VeModel();
        LoaiVeModel lv = new LoaiVeModel();

        // GET: DanhSachVe
        public ActionResult Index(string id)
        {
            List<Ve> dsv = v.DSVeCungLoai(id);

            LoaiVe lvm = lv.Lay1Loai(id);
            ViewBag.TieuDe = lvm.TenLoaiVe;
            ViewBag.MoTa = lvm.MoTa;
            return View(dsv);
        }
    }
}