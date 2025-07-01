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
    public partial class SearchDetails : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["userid"])))
            {
                Response.Redirect("Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }
        }

        protected void srch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);

            if(srchfrom.Text == "" && srchto.Text == "")
            {
                lbleror.Text = "Please select from and to date";
            }
            else
            {
                Session["from"] = srchfrom.Text;
                Session["to"] = srchto.Text;

                Response.Redirect("DtlsReport.aspx");
            }
        }
    }
}