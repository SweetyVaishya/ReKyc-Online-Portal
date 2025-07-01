using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KYCApllication_Admin
{
    public partial class SiteMaster : MasterPage
    {

        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (string.IsNullOrEmpty(Convert.ToString(Session["userid"])))
            //{
            //    Response.Redirect("Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            //}
            lblDate.Text = DateTime.Now.Date.ToString("dddd") + ", " + DateTime.Now.Date.ToString("dd MMM yyyy") ;
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss") + " " + DateTime.Now.ToString("tt");

            string userid1 = Convert.ToString(Session["userid"]);
            string UserStatus = Convert.ToString(Session["userstatus"]);

            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd = new SqlCommand(@"select name from kyclogin where username = '"+ userid1 + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();

            string username = (string)cmd.ExecuteScalar();

            userid.Text ="User   "+ username;

            if (UserStatus == "SuperAdmin")
            {
                ManageUser.Visible = true;
            }
            con.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}