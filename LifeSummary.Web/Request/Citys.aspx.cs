using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LifeSummary.Request
{
    public partial class sehirler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                var list = Manager.Instance.List<Country>();
                this.Dlcountry.DataSource = list.Records;
                Dlcountry.DataBind();
            }
            
        }
        public void List()
        {
            var countrid =Convert.ToInt32( Dlcountry.SelectedValue);
            var list = Manager.Instance.List<City>(new City() { CountryId = countrid });
            this.lbCity.DataSource = list.Records;
            lbCity.DataBind();
        }
        protected void Dlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            duzen.Visible = true;
            txtCity.Text = " ";
            List();

        }
        public void CitySave()
        {
            City rq = new City();
            rq.CountryId = Convert.ToInt32(Dlcountry.SelectedValue);
            rq.CityName = txtCity.Text;
            var saved = Manager.Instance.SaveScalarE(rq, true);
            List();
        }
        public void CityUpdate()
        {
            City rq = new City();
            rq.CityId = Convert.ToInt32(lbCity.SelectedValue);
            rq.CountryId = Convert.ToInt32(Dlcountry.SelectedValue);
            rq.CityName = txtCity.Text;
            Manager.Instance.Save(rq, false, null, "ST_SP_CITY_UPDATE");
            List();
        }
        public void sil()
        {
            //City rq = new City();
            //rq.CityId = Convert.ToInt32(lbCity.SelectedValue);
            //Manager.Instance.Delete(rq, false, null, "ST_SP_CITY_DELETE");
            //List();
            
        }
        protected void ekle_Click(object sender, EventArgs e)
        {
            CitySave();
        }
       
        protected void lbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            duzen.Visible = true;
            txtCity.Text = lbCity.SelectedItem.ToString();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            sil();
        }
        protected void edit_Click(object sender, EventArgs e)
        {
            CityUpdate();
        }
    }
}