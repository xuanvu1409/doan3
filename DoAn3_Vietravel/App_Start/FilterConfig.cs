﻿using System.Web;
using System.Web.Mvc;

namespace DoAn3_Vietravel
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
