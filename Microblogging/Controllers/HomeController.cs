using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Microblogging.Models;

namespace Microblogging.Controllers
{
    public class HomeController : Controller
    {
        /*public ActionResult Index()
        {
            var identity = ControllerContext.HttpContext.User.Identity;

            return View(identity);
        }*/


        public ActionResult Index()
        {
            ViewData["Intro"] = "Start posting and start socializing!";
            return View();
        }

        [HttpPost]
        public ActionResult Loggedin(Login handle)
        {
            Session["userhandle"] = handle;
            return RedirectToAction("Index", "Post");
        }
    }
}
