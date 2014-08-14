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
        protected void Gonder_Click(object sender, EventArgs e)
        {
           
        }
        public void CitySave()
        {
            int cityid = Convert.ToInt32(lbCity.SelectedValue);
            int country = Convert.ToInt32(Dlcountry.SelectedValue);
            var CityName = txtCity.Text;
            Db.CitySave(CityName, country, cityid);
            List();
        }
        public void sil()
        {
            int cityid = Convert.ToInt32(lbCity.SelectedValue);
            Db.CityDelete(cityid);
            
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

            CitySave();
        }
    }
}