﻿using Shreeyashclasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shreeyashclasses.Controllers
{
    public class ExamController : Controller
    {
        // GET: Exam
        [HttpGet]
        public ActionResult ScheduleExam()
        {
            return View();
        }
    }
}