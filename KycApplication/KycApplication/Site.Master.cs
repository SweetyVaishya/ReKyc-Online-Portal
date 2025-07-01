using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KycApplication
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.Date.ToString("dddd") + ", " + DateTime.Now.Date.ToString("dd MMM yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss") + " " + DateTime.Now.ToString("tt");

            string name = Convert.ToString(Session["name"]);
            if(!string.IsNullOrEmpty(Convert.ToString(Session["name"])))
            {
                userid.Text = " Welcome  " + name;
            }
           
        }
    }
}