using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVCPL.Infrastructure.ModelValidatorProviders;

namespace MVCPL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Response.Clear();

            var httpException = exception as HttpException;
            if (httpException != null)
            {
                var action = string.Empty;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        action = "NotFound";
                        break;
                    case 500:
                        action = "ServerError";
                        break;
                    default:
                        action = "ServerError";
                        break;
                }
                Response.Redirect($"~/Error/{action}");
                ///?message={exception.Message}
            }
        }
    }
}
