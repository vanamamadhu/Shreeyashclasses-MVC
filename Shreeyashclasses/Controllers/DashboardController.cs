﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shreeyashclasses.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [HttpGet]
        public ActionResult UserDashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminDashboard()
        {
            return View();
        }
    }
}