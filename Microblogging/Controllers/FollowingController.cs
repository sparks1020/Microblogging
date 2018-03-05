using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticationBase;

namespace Microblogging.Controllers
{
    public class FollowingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AuthenticationRequired]
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult MatchUser()
        {
            
        }
    }
}
