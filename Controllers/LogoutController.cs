using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMedicalNew
{ 
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}