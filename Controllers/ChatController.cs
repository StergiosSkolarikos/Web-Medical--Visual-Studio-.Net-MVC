using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;
using EatrikiVideoCall;

namespace WebMedicalNew.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            Thread th = new Thread(new ThreadStart(EatrikiVideoCall.Program.Main));
            th.Start();
            return RedirectToAction("Index","Home");
        }
    }
}