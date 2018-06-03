using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace OSBB.Filters
{
    public class MyAuthAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthentication(AuthorizationContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if(user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Accounte" }, { "action", "Login" } });
            }
        }
    }
}