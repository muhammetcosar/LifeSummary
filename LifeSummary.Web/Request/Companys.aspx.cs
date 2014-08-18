using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Whe;
namespace LifeSummary.Request
{
    public partial class sirket : System.Web.UI.Page
    {
        public int? CompanyId
        {
            get
            {
                if (ViewState["CompanyId"] != null)
                    return ViewState["CompanyId"].ToInt();
                else
                    return null;
            }
            set { ViewState["CompanyId"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                EntityFilter();
            }
        }
        public void EntityFilter()
        {
            this.DlCity.LoadResult(Manager.Instance.List<City>());
            if (this.DlCity.Items.Count > 0)
            {
                this.DlCity.SelectedIndex = 0;
                EntityList();
            }

        }
        public void EntityList()
        {
            this.lbCompany.LoadResult(Manager.Instance.List<Company>(new Company() { CityId = DlCity.SelectedValue.ToInt() }));
            EntityClear();
        }
        public void EntityDetail()
        {
            var CompanyId = lbCompany.SelectedValue.ToInt();
            if (CompanyId.HasValue)
            {
                this.duzen.Visible = true;
                this.txtCompany.Text = this.lbCompany.SelectedItem.Text;
            }
            else
            {
                txtCompany.Text = " ";
            }
        }
        public void EntityDelete()
        {
            var CompanyId = lbCompany.SelectedValue.ToInt();
            if (CompanyId.HasValue)
            {

                var deleted = Manager.Instance.Delete<Company>(new Company() { CompanyId = CompanyId });
                if (deleted.IsValid)
                    EntityList();
                else
                    Response.Write(deleted.Message);
            }
        }
        public void EntitySave()
        {
            bool isnew = true;
            var Company = new Company();
            Company.CityId = DlCity.SelectedValue.ToInt();
            Company.CompanyTitle = txtCompany.Text;
            var CompanyId = lbCompany.SelectedValue.ToInt();
            if (CompanyId.HasValue)
            {
                Company.CompanyId = CompanyId;
                isnew = false;
            }
            var saved = Manager.Instance.Save(Company, isnew);
            if (saved.IsValid)
                EntityList();
            else
                Response.Write(saved.Message);

        }
        public void EntityClear()
        {
            this.lbCompany.SelectedIndex = -1;
            this.CompanyId = null;
            this.txtCompany.Text = "";
        }
       

        protected void DlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            EntityList();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EntitySave();
        }
        protected void lbCompany_SelectedIndexChanged(object sender, EventArgs e)
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