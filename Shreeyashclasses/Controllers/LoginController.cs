using Shreeyashclasses.Models;
using Shreeyashclasses.Shreeyash.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Shreeyashclasses.Controllers
{
    public class LoginController : Controller
    {
        private readonly IValidation _validate;
        private readonly IRegistration _registration;
        public LoginController(IValidation validate, IRegistration registration)
        { 
            _validate = validate;
            _registration = registration;
        }
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            TempData["Status"] = "";
            TempData["Message"] = "";
            Session["Role"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.UserName != null && user.Password != null)
            {
                User userDetails = new Models.User();
                userDetails = _validate.ValidateUser(user);

                if (userDetails != null)
                {
                    if (userDetails.Role == "Student") {
                        Session["Role"] = userDetails.Role;
                        return RedirectToAction("UserDashboard", "Dashboard");
                    }
                    if (userDetails.Role == "Teacher") {
                        Session["Role"] = userDetails.Role;
                        return RedirectToAction("AdminDashboard", "Dashboard");
                    }
                    return View();
                }
                else
                {
                    TempData["Status"] = "Error";
                    TempData["Message"] = "User Name and Password does not exist";
                    return View();
                }
            }
            else {
                TempData["Status"] = "Error";
                TempData["Message"] = "Please enter UserName/Password";
                return View();
            }
        }

        [HttpGet]
        public ActionResult NewUser()
        {
            TempData["Status"] = "";
            TempData["Message"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(User user)
        {
            if (ModelState.IsValid)
            {
                bool IsSuccess= _registration.CreateUser(user);
                if (IsSuccess) {
                    TempData["Status"] = "Error";
                    TempData["Message"] = "Somthing went wrong!";
                }
                else {
                    TempData["Status"] = "Success";
                    TempData["Message"] = "User created successfully";
                }
                return RedirectToAction("Login", "Login");
            }
            TempData["Status"] = "Error";
            TempData["Message"] = "Fields marked with an asterisk * are required";
            return View(user);
        }
    }
}