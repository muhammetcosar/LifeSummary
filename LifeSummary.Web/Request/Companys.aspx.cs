using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LifeSummary.Request
{
    public partial class sirket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var list = Manager.Instance.List<City>();
                this.DlCity.DataSource = list.Records;
                DlCity.DataBind();
            }
        }
        public void List()
        {
            var city = Convert.ToInt32(DlCity.SelectedValue);
            var list = Manager.Instance.List<Company>(new Company() { CityId = city });
            this.lbCompany.DataSource = list.Records;
            lbCompany.DataBind();
        }

        public void CompanyUpdate()
        {
            Company rq = new Company();
            rq.CompanyId= Convert.ToInt32(lbCompany.SelectedValue);
            rq.CompanyTitle = txtCompany.Text;
            Manager.Instance.Save(rq, false, null, "ST_SP_COMPANY_UPDATE");
            List();
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            CompanyUpdate();
        }

        protected void DlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            duzen.Visible = true;
            List();
        }

        protected void ekle_Click(object sender, EventArgs e)
        {
            Company rq = new Company();
            rq.CityId =Convert.ToInt32( DlCity.SelectedValue);
            rq.CompanyTitle = txtCompany.Text;
            var saved = Manager.Instance.SaveScalarE(rq, true);
            List();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            sil();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
        public void sil()
        {
            int CompanyId = Convert.ToInt32(lbCompany.SelectedValue);
            Db.CompanyDelete(CompanyId);
        }

        protected void lbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

            duzen.Visible = true;
            txtCompany.Text = lbCompany.SelectedItem.ToString();
        }

    }
}