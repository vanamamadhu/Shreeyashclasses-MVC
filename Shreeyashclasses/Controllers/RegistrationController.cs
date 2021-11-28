using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shreeyashclasses.Controllers
{
    public class RegistrationController : Controller
    {
        public RegistrationController() { 
        
        }
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
    }
}