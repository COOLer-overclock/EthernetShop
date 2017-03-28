using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthernetShop.Attributes
{
    class AuthorizedAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public new string Roles { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if ((httpContext.Session["IsAuthorized"] != null) && (httpContext.Session["IsAuthorized"] == "True"))
            {
                if ((Roles != null) && (Roles.Length > 0))
                {
                    return Roles.Trim(' ').Trim(',').ToLower().Contains(((string)httpContext.Session["Role"]).ToLower());
                }
                else
                    return true;
            }
            else
                return false;
        }

    }
}