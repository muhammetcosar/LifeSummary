using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LifeSummary.Request
{
    public partial class Person : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            City();
            Tille();
        }
        public void City()
        {
            int? id = null;
            dlcity.DataSource = Db.CityListGet(id);
            dlcity.DataBind();
        }
        public void Tille()
        {
            dlTitle.DataSource = Db.TitleListGet();
            dlTitle.DataBind();
        }

      
        public void personSave()
        {
            Db.PersonSave(txtName.Text, txtSurname.Text, txtDescription.Text,dlTitle.SelectedItem.ToString() , Convert.ToInt32(dlcity.SelectedValue), itarih.SelectedDate, atarih.SelectedDate,Convert.ToInt32(dlTitle.SelectedValue));
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            personSave();
        }
    }
}