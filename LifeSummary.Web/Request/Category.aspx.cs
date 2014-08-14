using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LifeSummary.Request
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var list = Manager.Instance.List<Country>();
                this.lbCategory.DataSource = list.Records;
                lbCategory.DataBind();
               
            }
        }
        protected void ekle_Click(object sender, EventArgs e)
        {
            duzen.Visible = true;
        }
        public void CategorySave()
        {
            Db.CategorySave(txtCategory.Text);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            CategorySave();
        }
        protected void lbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
                duzen.Visible = true;
                txtCategory.Text = lbCategory.SelectedValue;
        }
        protected void btnYeni_Click(object sender, EventArgs e)
        {
            txtCategory.Text = "";
        }
    }
}