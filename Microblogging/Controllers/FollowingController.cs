using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticationBase;
using AuthenticationBase.Models.Authentication;
using Microblogging.Database_files;

namespace Microblogging.Controllers
{
    public class FollowingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AuthenticationRequired]
        public ActionResult Find()
        {
            return View();
        }

        /*[HttpPost]
        [AuthenticationRequired]
        public ActionResult Search(Account name)
        {
            using (var db = new PostsContext())
            {
                var names = db.Accounts.Where(n => n.Username == user).ToList();
                return View("Index");
            }
        }*/

        [AuthenticationRequired]
        public ActionResult MatchUser(string user)
        {
            using (var db = new PostsContext())
            {
                var users = db.Accounts.Where(u => u.Username == user).ToList();
                return View(users);
            }
        }
    }
}
