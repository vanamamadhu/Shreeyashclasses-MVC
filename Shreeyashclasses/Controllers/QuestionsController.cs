using Shreeyashclasses.Common;
using Shreeyashclasses.Models;
using Shreeyashclasses.Shreeyash.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shreeyashclasses.Controllers
{
    [UserAuthenticationFilter]
    public class QuestionsController : Controller
    {
        private readonly IQuestions _questions;
        public QuestionsController(IQuestions question)
        {
            _questions = question;
        }
        // GET: Questions
        [HttpGet]
        public ActionResult CreateQuestion(int Id = 0)
        {
            TempData["Status"] = "";
            TempData["Message"] = "";
            
            ViewBag.IsUpdate = false;
            if (Id != 0) {
                Question viewQuestion = new Question();
                ViewBag.IsUpdate = true;
                viewQuestion = _questions.GetQuestion(Id);
                return View(viewQuestion);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateQuestion(Question newQuestions)
        {
            ViewBag.IsUpdate = false;
            if (ModelState.IsValid)
            {
                bool IsSuccess = false;
                string message;
                if (newQuestions.Id > 0)
                {
                    IsSuccess = UpdateQuestion(newQuestions);
                    ViewBag.IsUpdate = true;
                    message = "Question updated successfully";
                }
                else
                {
                    IsSuccess = AddNewQuestion(newQuestions);
                    message = "New question added successfully";
                }
                if (IsSuccess)
                {
                    TempData["Status"] = "Success";
                    TempData["Message"] = message;
                    return RedirectToAction("ViewQuestion", "Questions");
                }
                else
                {
                    TempData["Status"] = "Error";
                    TempData["Message"] = "Somthing went wrong!";
                }
            }
            else {
                TempData["Status"] = "Error";
                TempData["Message"] = "Fields marked with an asterisk * are required";
            }
            return View(newQuestions);
        }

        [HttpGet]
        public ActionResult ViewQuestion()
        {
            List<Question> viewallQuestions = _questions.GetQuestions();
            return View(viewallQuestions);
        }

        [HttpGet]
        public Question GetQuestion(int Id)
        {
            Question viewQuestions = _questions.GetQuestion(Id);
            return viewQuestions;
        }
        [HttpGet]
        public ActionResult DeleteQuestion(int Id)
        {
            bool IsSuccess = _questions.DeleteQuestion(Id);
            if (IsSuccess)
            {
                TempData["Status"] = "Success";
                TempData["Message"] = "Record deleted successfully";
            }
            else {
                TempData["Status"] = "Error";
                TempData["Message"] = "Somthing went wrong!";
            }
            return RedirectToAction("ViewQuestion", "Questions");
        }

        private bool AddNewQuestion(Question newQuestions) {
            newQuestions.CreatedDate = DateTime.Now;
            newQuestions.ModifiedDate = DateTime.Now;
            return _questions.InsertNewQuestion(newQuestions);
        }

        private bool UpdateQuestion(Question newQuestions)
        {
            newQuestions.ModifiedDate = DateTime.Now;
            return _questions.UpdateQuestion(newQuestions);
        }
    }
}