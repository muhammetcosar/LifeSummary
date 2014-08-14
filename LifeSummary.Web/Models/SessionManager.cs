using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeSummary
{
    public class SessionManager
    {
        public static LoginResult Login
        {
            get
            {
                if (HttpContext.Current.Session["Login"] != null)
                    return (LoginResult)HttpContext.Current.Session["Login"];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["Login"] = value;
            }
        }
    }
}