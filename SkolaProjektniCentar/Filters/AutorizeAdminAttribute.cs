using SkolaProjektniCentar;
using System;
using System.Web;

namespace Filters
{
    public class AutorizeAdmin : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {
        //private SkolaContext _context;

        //public AutorizeAdmin()
        //{
        //    _context = new SkolaContext();
        //}
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext fc)
        {
            if (HttpContext.Current.Session["PravoPristupa"] == null )
            {
                fc.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"Controller", "Login" },
                    {"Action", "Index" }
                });
            }
            
            base.OnActionExecuting(fc);
        }
    }
}