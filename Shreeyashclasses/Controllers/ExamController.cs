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
        public ActionResult AddQuestion(Question newQuestion)
        {
            return View();
        }

        [HttpGet]
        public ActionResult viewQuestion()
        {
            List<Question> listofQuestions = new List<Question>();
            return View(listofQuestions);
        }

        [HttpPost]
        public bool UpdateQuestion(Question newQuestion)
        {
            return true;
        }

        [HttpPost]
        public bool DeleteQuestion(Question newQuestion)
        {
            return true;
        }
    }
}