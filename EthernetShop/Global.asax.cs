using EthernetShop.BLL.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EthernetShop
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
        protected void Session_Start(object sender, EventArgs e)
        {
            /*Session["IsAuthorized"] = "False";
            Session["Id"] = null;
            Session["Login"] = null;
            Session["Role"] = "User";
            Session["ShoppingBasket"] = new ShoppingBasket();*/
            Session["IsAuthorized"] = "True";
            Session["Id"] = "8";
            Session["Login"] = "COOLer_overclock";
            Session["Role"] = "Developer";
            Session["ShoppingBasket"] = new ShoppingBasket();
        }
    }
}
