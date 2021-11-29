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
            if (ModelState.IsValid) {
                bool IsSuccess = false;
                if (newQuestions.Id > 0)
                {
                    IsSuccess = UpdateQuestion(newQuestions);
                    ViewBag.IsUpdate = true;
                }
                else {
                    IsSuccess = AddNewQuestion(newQuestions);
                    ViewBag.IsUpdate = false;
                }
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

        [HttpGet]
        public Question GetQuestion(int Id)
        {
            Question viewQuestions = _questions.GetQuestion(Id);
            return viewQuestions;
        }
        [HttpGet]
        public void DeleteQuestion(int Id)
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