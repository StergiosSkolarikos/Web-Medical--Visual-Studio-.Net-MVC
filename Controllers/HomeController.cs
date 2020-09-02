using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;
using EatrikiVideoCall;

namespace WebMedicalNew
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your login page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your Register page.";

            return View();
        }
        public ActionResult OpenChat()
        {
           
            return Index();
        }


        public ActionResult MainPage()
        {
            ViewBag.Message = "Your application main page.";

            return View();
        }
    }
}