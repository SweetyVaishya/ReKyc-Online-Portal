using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace KycApplication
{
    public partial class Welcome : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string acc_no = Convert.ToString(Session["Account_no1"]);

            if (string.IsNullOrEmpty(Convert.ToString(Session["Account_no1"])))
            {
                Response.Redirect("Default.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }

            SqlConnection con = new SqlConnection(strcon);
            string sql = "select [Name] from [kycdetail] where [acoount_no] = '" + acc_no + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
          string getname = (string)cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();

            Label1.Text = getname;
            //Session["name"] = getname;
        }

        protected void continue_Click(object sender, EventArgs e)
        {
            string acc_no = Convert.ToString(Session["Account_no1"]);
            Session["Account_no1"] = acc_no;
            //string Name = Convert.ToString(Session["name"]);
            //Session["name"] = Name;
             string kycid = Convert.ToString(Session["kycid"]);
            Session["kycid"] = kycid;
            Response.Redirect("accout_type.aspx");
        }
    }
}