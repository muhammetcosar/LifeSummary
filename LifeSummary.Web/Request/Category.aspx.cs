using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Whe;

namespace LifeSummary.Request
{

    public partial class Category : System.Web.UI.Page
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                EntityFilter();
            }
        }
        public void EntityFilter()
        {
            var list = Manager.Instance.List<CategoryModel>();
            this.lbCategory.DataSource = list.Records;
            lbCategory.DataBind();
        }
        public void EntitySave()
        {
            bool isnew = true;
            var Category = new CategoryModel();
            Category.CategoryId = lbCategory.SelectedValue.ToInt();
            Category.CategoryName = txtCategory.Text;
            if (Category.CategoryId.HasValue)
            {
                isnew = false;
            }
            var saved = Manager.Instance.Save(Category, isnew);
            if (saved.IsValid)
                EntityFilter();
            else
                Response.Write(saved.Message);

        }
        public void EntityClear()
        {
            txtCategory.Text = "";
            lbCategory.SelectedIndex = -1;
         
         
        }
        public void EntityDetail()
        {
            var CategoryId=lbCategory.SelectedValue.ToInt();
            if (CategoryId.HasValue)
            {
                this.duzen.Visible = true;
                txtCategory.Text = lbCategory.SelectedItem.ToString();
            }
            else
            {
                txtCategory.Text = " ";
            }
        }
        public void EntityDelete()
        {
            var CategoryId = lbCategory.SelectedValue.ToInt();
            if (CategoryId.HasValue)
            {

                var deleted = Manager.Instance.Delete<CategoryModel>(new CategoryModel() { CategoryId = CategoryId });
                if (deleted.IsValid)
                    EntityFilter();
                else
                    Response.Write(deleted.Message);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EntitySave();
        }
        protected void lbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            EntityDetail();
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            EntityClear();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            EntityDelete();
        }
      
      
       
    }
}