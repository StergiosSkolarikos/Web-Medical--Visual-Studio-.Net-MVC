using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMedicalNew.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index(Register reg)
        {
            if (ModelState.IsValid)
            {
              int status = reg.Insert(reg.Username, reg.Password, reg.ConfirmPassword, reg.FirstName, reg.LastName, reg.Email, reg.ConfirmEmail,reg.DateOfBirth,reg.City,reg.StreetName,reg.StreetNumber,reg.ZipCode);
                switch (status)
                {
                    case 0:
                    ModelState.AddModelError("", "Username must not be empty");
                    break;
                    case 1:
                    return RedirectToAction("Index", "Home");
                    case 2:
                    ModelState.AddModelError("", "Email or password is null or doesnt match");
                    break;
                    case 3:
                    ModelState.AddModelError("", "Account already exists");
                    break;

                }
            }
                return View();
        }
    }
}