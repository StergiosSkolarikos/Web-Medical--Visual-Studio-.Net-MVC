using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMedicalNew.Controllers
{
    public class MainPageController : Controller
    {
        // GET: MainPage
        public ActionResult Index()
        {
            MainPage mp = new MainPage();
            mp.announcements = mp.GetAnnouncements();
            return View(mp);
        }
        [HttpPost]
        public ActionResult Index(MainPage mp)
        {
            mp.InsertAnnouncements(Login.id, mp.announcement_title, mp.announcement);
            mp.announcements = mp.GetAnnouncements();
            return View(mp);
        }
    }
}