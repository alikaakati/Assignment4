﻿using System.Web;
using System.Web.Mvc;

namespace Assignment4_ALI_K_MOHAMAD.N
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
