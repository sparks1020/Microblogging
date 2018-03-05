using System;
using System.Web.Mvc;

namespace Microblogging.Models
{
    public class Followers : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
