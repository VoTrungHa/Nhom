using System.Web.Mvc;

namespace Nhom.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
     "Admin_default",
     "Admin/{controller}/{action}/{id}",
     new { action = "Index", id = UrlParameter.Optional },
     new[] { "Nhom.Areas.admin.Controllers" }
 );
        }
    }
}