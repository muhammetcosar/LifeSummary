using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LifeSummary
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            login("muhammet", "cosar");
            list();
        }

        public void list()
        {
            
        }
        public void login(string uname, string upass)
        {
            var login = Db.Login(uname, upass);
            if (login.SUCCESS)
            {
                SessionManager.Login = login;
                if (Request.Params["ReturnUrl"] != null)
                {
                    Response.Redirect(Request.Params["ReturnUrl"]);
                }
                else
                {
                    if (login.ISADMIN)
                        Response.Redirect("Request/Category.aspx");

                    else
                        Response.Redirect("Default");
                }
               
            }
            else
                Response.Redirect("~/Login");
        }
        protected void giris_Click(object sender, EventArgs e)
        {
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            txtgiris.Visible = false;
            txtkayit.Visible = true;
        }

        protected void Giris_Click1(object sender, EventArgs e)
        {
            txtgiris.Visible = true;
            txtkayit.Visible = false;
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            

        }

       
    }
}