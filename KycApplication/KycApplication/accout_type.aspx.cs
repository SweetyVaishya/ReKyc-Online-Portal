using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace KycApplication
{
    public partial class About : Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["Account_no1"])))
            {
                Response.Redirect("Default.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }
            string acc_no = Convert.ToString(Session["Account_no1"]);

            //string Name = Convert.ToString(Session["name"]);

            SqlConnection con = new SqlConnection(strcon);
            string sql = "select [Name] from [kycdetail] where [acoount_no] = '" + acc_no + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            string getname = (string)cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();

           // Label1.Text = getname;
            Session["name"] = getname;


        }

        protected void individual_Click(object sender, EventArgs e)
        {
            string acc_no = Convert.ToString(Session["Account_no1"]);
            string kycid = Convert.ToString(Session["kycid"]);

            SqlConnection con = new SqlConnection(strcon);
            //SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[kycdetail]
            //       SET[accout_type] = 'individual'
            //         WHERE acoount_no='"+ acc_no + "' ", con);

            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[kycdetail]
                   SET[accout_type] = 'individual'
                     WHERE Kycid='" + kycid + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();


            Session["Account_no"] = acc_no;
            string Name = Convert.ToString(Session["name"]);
            Session["name"] = Name;
            Session["kycid"] = kycid;
            Response.Redirect("individual_acc.aspx");
        }

        //protected void Join_Click(object sender, EventArgs e)
        //{
        //    string acc_no = Convert.ToString(Session["Account_no1"]);
        //    string kycid = Convert.ToString(Session["kycid"]);

        //    SqlConnection con = new SqlConnection(strcon);
        //    //SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[kycdetail]
        //    //       SET[accout_type] = 'Join'
        //    //         WHERE acoount_no='" + acc_no + "' ", con);

        //    SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[kycdetail]
        //           SET[accout_type] = 'Join'
        //             WHERE Kycid='" + kycid + "' ", con);

        //    con.Open();
        //    cmd.ExecuteNonQuery();

        //    Session["Account_no"] = acc_no;
        //    Session["kycid"] = kycid;
        //    string Name = Convert.ToString(Session["name"]);
        //    Session["name"] = Name;

        //    Response.Redirect("join_acc.aspx");
        //}
    }
}