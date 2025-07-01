using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KycApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["Account_no"])))
            {
                Response.Redirect("Default.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }

            SqlConnection con = new SqlConnection(strcon);
            string acc_no = Convert.ToString(Session["Account_no"]);

            string kycid = Convert.ToString(Session["kycid"]); 


            Acknowlodge_no.Text = kycid;

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            string acc_no = Convert.ToString(Session["Account_no"]);
            string kycid = Convert.ToString(Session["kycid"]);

            SqlCommand cmd = new SqlCommand("UPDATE [dbo].[kycdetail] SET[Create_at] = CURRENT_TIMESTAMP WHERE Kycid ='" + kycid + "'",con);
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("https://www.abhyudayabank.co.in/english/home.aspx");
        }
    }
}