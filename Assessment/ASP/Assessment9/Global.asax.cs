using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Assessment9
{
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Existing Code
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Application State Variables
            Application["TotalVisitors"] = 0;
            Application["ActiveUsers"] = 0;
        }

        void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();

            Application["TotalVisitors"] =
                (int)Application["TotalVisitors"] + 1;

            Application["ActiveUsers"] =
                (int)Application["ActiveUsers"] + 1;

            Application.UnLock();
        }

        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();

            Application["ActiveUsers"] =
                (int)Application["ActiveUsers"] - 1;

            Application.UnLock();
        }
    }
}