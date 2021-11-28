using Shreeyashclasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shreeyashclasses.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: Questions
        [HttpGet]
        public ActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQuestion(Questions newQuestions)
        {
            if (ModelState.IsValid) {
                
            }
            return View();
        }

        [HttpGet]
        public ActionResult ViewQuestion()
        {
            List<Questions> viewallQuestions = new List<Questions>();
            return View(viewallQuestions);
        }
    }
}