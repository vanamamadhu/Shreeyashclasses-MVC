using Shreeyashclasses.Models;
using Shreeyashclasses.Shreeyash.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shreeyashclasses.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestions _questions;
        public QuestionsController(IQuestions question)
        {
            _questions = question;
        }
        // GET: Questions
        [HttpGet]
        public ActionResult CreateQuestion()
        {
            TempData["Status"] = "";
            TempData["Message"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult CreateQuestion(Question newQuestions)
        {
            if (ModelState.IsValid) {
                newQuestions.CreatedDate = DateTime.Now;
                newQuestions.ModifiedDate = DateTime.Now;
                bool IsSuccess = _questions.InsertNewQuestion(newQuestions);
                if (IsSuccess)
                {
                    TempData["Status"] = "Success";
                    TempData["Message"] = "New question added successfully";
                    newQuestions = null;
                }
                else {
                    TempData["Status"] = "Error";
                    TempData["Message"] = "Somthing went wrong!";
                }
            }
            return View(newQuestions);
        }

        [HttpGet]
        public ActionResult ViewQuestion()
        {
            List<Question> viewallQuestions = _questions.GetQuestions();
            return View(viewallQuestions);
        }
    }
}