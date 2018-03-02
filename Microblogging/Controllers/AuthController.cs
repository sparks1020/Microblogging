using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using AuthenticationBase.Models;

namespace AuthenticationBase.Controllers
{
    //[AuthenticationPermitted]
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            var identity = ControllerContext.HttpContext.User.Identity;

            return View(identity);
        }
    }
}
