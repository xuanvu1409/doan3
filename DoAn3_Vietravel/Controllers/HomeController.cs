using DoAn3_Vietravel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel.Controllers
{
    public class HomeController : Controller
    {
        VeModel ve = new VeModel()
;        public ActionResult Index()
        {

            return View();
        }

        public ActionResult TimKiem(string find, int lc)
        {
            ViewBag.TuKhoa = find;

            List<Ve> result = new List<Ve>();

            if (find.Length <= 0)
                return View(result);

            var list = ve.LayDanhSach();

            foreach (var sp in list)
            {
                // kiểm tra tên vé
                if (sp.TenVe.ToLower().IndexOf(find.ToLower()) != -1 && !result.Contains(sp))
                    result.Add(sp);

                // kiểm tra kiểu vé
                if (sp.KieuVe.ToLower().IndexOf(find.ToLower()) != -1 && !result.Contains(sp))
                    result.Add(sp);

                //if((lc == 1 && sp.Gia < 1000000) || (lc == 2 && sp.Gia >= 1000000 && sp.Gia < 2000000) || (lc == 3 && sp.Gia >= 2000000 && sp.Gia < 4000000) || (lc == 4 && sp.Gia >= 4000000 && sp.Gia < 6000000) || (lc == 5 && sp.Gia >= 6000000 && sp.Gia < 1000000) || (lc == 6 && sp.Gia < 10000000))
                //    result.Add(sp);
            }
            return View(result);
        }
    }
}