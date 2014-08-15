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
                List();
            }
        }
        public void List()
        {
            var list = Manager.Instance.List<CategoryModel>();
            this.lbCategory.DataSource = list.Records;
            lbCategory.DataBind();
        }
        protected void ekle_Click(object sender, EventArgs e)
        {
            duzen.Visible = true;
        }
        public void CategorySave()
        {
            CategoryModel cq = new CategoryModel();
            cq.CategoryName = txtCategory.Text;
            var saved = Manager.Instance.SaveScalarE(cq, true);
            List();

        }
        public void CategoryUpdate()
        {
            CategoryModel cq = new CategoryModel();
            cq.CategoryId = Convert.ToInt32(lbCategory.SelectedValue);
            cq.CategoryName = txtCategory.Text;
            Manager.Instance.Save(cq, false, null, "ST_SP_CATEGORY_UPDATE");
            List();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            CategorySave();
        }
        protected void lbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            duzen.Visible = true;
            txtCategory.Text = lbCategory.SelectedItem.ToString();
            btnDuzen.Visible = true;
            btnSave.Visible = false;
        }
        protected void btnYeni_Click(object sender, EventArgs e)
        {
            txtCategory.Text = "";
            btnSave.Visible = true;
            btnDuzen.Visible = false;
        }
        protected void btnDuzen_Click(object sender, EventArgs e)
        {
            CategoryUpdate();
        }
    }
}