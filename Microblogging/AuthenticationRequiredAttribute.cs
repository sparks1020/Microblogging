using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using AuthenticationBase.Models.Authentication;

namespace AuthenticationBase
{
    public class AuthenticationRequiredAttribute : AuthenticationPermittedAttribute
    {
        public override void OnAuthenticationChallenge(System.Web.Mvc.Filters.AuthenticationChallengeContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/User/Login");
            }
        }
    }
}
