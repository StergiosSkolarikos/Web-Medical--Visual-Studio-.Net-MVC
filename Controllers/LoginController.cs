using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using EatrikiVideoCall;

namespace WebMedicalNew.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                String message = login.getCredentials(login.UserName, login.Password);
                if (message.Equals("1") || message.Equals("2"))
                {
                    ConnectToDatabase.cnn.Close();
                    //Application.Run(new ChatLogin());
                    return RedirectToAction("Index", "MainPage");
                    

                }
                else if(message.Equals("Invalid Credentials") && login.UserName!=null&& login.Password!=null)
                {
                    //ViewBag.ErrorMessage = message;
                    ConnectToDatabase.cnn.Close();
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            return View();
        }




    }
}