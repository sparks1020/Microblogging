using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microblogging.Models;
using Microblogging.Database_files;
using AuthenticationBase.Models.Authentication;
using AuthenticationBase;

namespace Microblogging.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Index()
        {
            Login handle = (Login)Session["userhandle"];
            return View();
        }

        [AuthenticationRequired]
        public ActionResult Post()
        {
            return View();
        }
        
        [HttpPost]
        [AuthenticationRequired]
        public ActionResult Post(Post_ViewModel microblogs)
        {

            using (var db = new PostsContext())
            {

                db.Posts.Add(new Microblog
                {
                    Author = ControllerContext.HttpContext.User.Identity.Name,
                    Content = microblogs.Content,
                    Published = DateTime.Now
                });
                db.SaveChanges();
                return View("Index");
            }
        }
            [AuthenticationRequired]
            public ActionResult History(Post_ViewModel microblogs)
            {
                using (var db = new PostsContext())
                {
                var microblog = db.Posts.Where(p=>p.Author == ControllerContext.HttpContext.User.Identity.Name).ToList().OrderByDescending(b=>b.Id);
                    return View(microblog);
                }
            }

         
        }
    }

