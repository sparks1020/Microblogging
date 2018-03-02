using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Microblogging.Controllers
{
    public class FollowingController : Controller
    {
        public ActionResult Index()
        {
            return View("MyFollowers");
        }
    }
}
