using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Whe;
namespace LifeSummary.Request
{
    public partial class sehirler : System.Web.UI.Page
    {
        public int? CityId
        {
            get
            {
                if (ViewState["CityId"] != null)
                    return ViewState["CityId"].ToInt();
                else
                    return null;
            }
            set { ViewState["CityId"] = value; }
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
            this.ddlCountry.LoadResult(Manager.Instance.List<Country>());
            if (this.ddlCountry.Items.Count > 0)
            {
                this.ddlCountry.SelectedIndex = 0;
                EntityList();
            }

        }
        public void EntityList()
        {
            this.lbCity.LoadResult(Manager.Instance.List<City>(new City() { CountryId = ddlCountry.SelectedValue.ToInt() }));
            EntityClear();
        }
        public void EntityDetail()
        {
            if (this.CityId.HasValue)
            {
                this.duzen.Visible = true;
                this.txtCity.Text = this.lbCity.SelectedItem.Text;
            }
            else
            {
                txtCity.Text = " ";
            }
        }
        public void EntityDelete()
        {
            if (this.CityId.HasValue)
            {

                var deleted = Manager.Instance.Delete<City>(new City() { CityId = this.CityId });
                if (deleted.IsValid)
                    EntityList(); 
                else
                    Response.Write(deleted.Message);
            }
        }
        public void EntitySave()
        {
            bool isnew = true;
            var city = new City();
            city.CountryId = ddlCountry.SelectedValue.ToInt();
            city.CityName = txtCity.Text;
            if (this.CityId.HasValue)
            {
                city.CityId = this.CityId;
                isnew = false;
            }
            var saved = Manager.Instance.Save(city, isnew);
            if (saved.IsValid)
                EntityList();
            else
                Response.Write(saved.Message);
             
        }
        public void EntityClear()
        {
            this.lbCity.SelectedIndex = -1;
            this.CityId = null;
            this.txtCity.Text = "";
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            EntityList();
        }
        protected void lbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CityId = this.lbCity.SelectedValue.ToInt();
            EntityDetail();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EntitySave();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            EntityDelete();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            EntityClear();
        }
    }
}