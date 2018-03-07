using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticationBase;
using AuthenticationBase.Models.Authentication;
using Microblogging.Database_files;
using Microblogging.Models;

namespace Microblogging.Controllers
{
    public class FollowingController : Controller
    {
        [AuthenticationRequired]
        public ActionResult Index(int Id)
        {
            using (var db = new PostsContext())
            {
                var connections = db.Follows.Where(l => l.Id == Id).ToList();
                var username = db.Accounts.Where(e => connections.Contains(e.Id));
                List<Follow> finalList = new List<Follow>();
                foreach (var id in connections)
                {
                    finalList.Add(db.Follows.FirstOrDefault(e => e.Id == id));
                }
                //At this point finalList has all the entries whose Ids appear in the list listOfIds
                return View();
            }

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

        [AuthenticationRequired]
        public ActionResult Follow (int Id)
        {
            using (var db = new PostsContext())
            {
                db.Follows.Add(new Follow
                {
                    Following = Id,
                    Followers = ((LocalIdentity)ControllerContext.HttpContext.User.Identity).Id
                });
            db.SaveChanges();
            }
            return View();                 
        }

    }
}
