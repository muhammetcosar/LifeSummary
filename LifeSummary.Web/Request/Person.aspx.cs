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
            EntityFilter();
        }
        public void EntityFilter()
        {
            this.dlcity.DataSource = Manager.Instance.List<City>().Records;
            dlcity.DataBind();
            this.dlTitle.DataSource = Manager.Instance.List<Title>().Records;
            dlTitle.DataBind();
        }
        public void EntitySave()
        {
            PersonModel pr = new PersonModel();
            pr.Name = txtName.Text;
            pr.Surname = txtSurname.Text;
            pr.PDescription = txtDescription.Text;
            pr.Title = txtTitle.Text;
            pr.FMCity = Convert.ToInt32(dlcity.SelectedValue);
            pr.FMDate = itarih.SelectedDate;
            pr.LMDate = atarih.SelectedDate;
            Manager.Instance.SaveScalarE(pr, true);
            EntityFilter();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EntitySave();
        }
    }
}