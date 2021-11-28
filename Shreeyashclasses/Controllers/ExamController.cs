using Shreeyashclasses.Models;
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
        public ActionResult AddQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddQuestion(Questions newQuestion)
        {
            return View();
        }

        [HttpGet]
        public ActionResult viewQuestion()
        {
            List<Questions> listofQuestions = new List<Questions>();
            return View(listofQuestions);
        }

        [HttpPost]
        public bool UpdateQuestion(Questions newQuestion)
        {
            return true;
        }

        [HttpPost]
        public bool DeleteQuestion(Questions newQuestion)
        {
            return true;
        }
    }
}