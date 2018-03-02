using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using AuthenticationBase.Models.Authentication;

namespace AuthenticationBase
{
    public class AuthenticationPermittedAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public virtual void OnAuthentication(System.Web.Mvc.Filters.AuthenticationContext filterContext)
        {
            var currentUser = filterContext.HttpContext.Session["user"] as Account;
            if (currentUser != null)
            {
                filterContext.Principal = new LocalPrincipal(new LocalIdentity(currentUser.Username, currentUser.EmailAddress));
            }
        }

        public virtual void OnAuthenticationChallenge(System.Web.Mvc.Filters.AuthenticationChallengeContext filterContext)
        {
        }
    }
}
