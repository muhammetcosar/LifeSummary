using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LifeSummary.Layout
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionManager.Login != null)
            {
                lbuser.Text = SessionManager.Login.USERNAME;
                btnLogout.Visible = true;
            }
            else
                Response.Redirect("~/Login");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Login = null;
            Response.Redirect("~/Login");
        }
    }
}