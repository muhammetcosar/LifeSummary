using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Whe.Data;

namespace LifeSummary
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
        }
        
        public void login()
        {
            List<WDbParameter> prms = new List<WDbParameter>();
            prms.Add(new WDbParameter("USERNAME", txtUsername.Text));
            prms.Add(new WDbParameter("PASSWORD", txtPassword.Text));
            var sonuc = Manager.Instance.Get<LoginResult>(prms, "ST_SP_USER_LOGIN");
            if (sonuc.IsValid && sonuc.ReturnObject != null)
            {
                if (sonuc.ReturnObject.ISADMIN)
                    Response.Redirect("Request/Category.aspx");

                else
                    Response.Redirect("Default");

            }
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

       
    }
}