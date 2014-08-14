using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LifeSummary
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                //if (!SessionManager.Login.ISADMIN)
                //    Response.Redirect("~/Request/List");

                List();
            }
        }
        public void List()
        {
            //DlCategory.DataSource = Db.CategoryListGet();
            //DlCategory.DataBind();
        }

        public void CategoryList()
        {
            if (DlCategory.Text == "Diğer")
            {
                Cdiger.Visible = true;
            }
            else
            {
                Cdiger.Visible = false;
            }
        }

       
        protected void Search_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var category = txtdiger.Text;
            var ulke = txtUlke.Text;
            var sehir = txtSehir.Text;
            
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        protected void dgrList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (this.IsPostBack)
            {
                CategoryList();
            }
           
            
        }

       


    }
}
        
 
    