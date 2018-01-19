﻿using AuditingMvcDemo.Filters;
using System.Web.Mvc;

namespace AuditingMvcDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuditFilter());
        }
    }
}