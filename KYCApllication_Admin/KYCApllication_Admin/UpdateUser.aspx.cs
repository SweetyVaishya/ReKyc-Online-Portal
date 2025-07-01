using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KYCApllication_Admin
{
    public partial class UpdateUser : System.Web.UI.Page
    {


        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    ViewState["PreviousPage"] = Request.UrlReferrer.ToString();
                }
            }


            if (string.IsNullOrEmpty(Convert.ToString(Session["userid"])))
            {
                Response.Redirect("Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }

            string UserName = Request.QueryString["username"];

            //lblmsg.Text = UserName;


            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT  [id]
                  ,[username]
                  ,[password]
                  ,[craete_at]
                  ,[status]
                  ,[name]
              FROM [kyclogin] where username ='" + UserName + "'  ", con);

            con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            con.Close();
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            string UserName = Request.QueryString["username"];

            SqlConnection con = new SqlConnection(strcon);
            if (password.Text == "")
            {
                lbleror.Text = "Please enter password";
            }
            else if (confirmpassword.Text == "")
            {
                lbleror.Text = "Please enter confirm password";
            }
            else if (password.Text != confirmpassword.Text)
            {
                lbleror.Text = "Your entered password and confirm password does not match";
            }
            else if (status.SelectedValue == "")
            {
                lbleror.Text = "please select one option";
            }
            else
            {
                SqlCommand cmd = new SqlCommand(@"update kyclogin set status = '" + status.SelectedValue + "', password = '" + password.Text + "' where username ='" + UserName + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblmsg.Text = "updated successfully";
            }


        }

        protected void delete_Click(object sender, EventArgs e)
        {
            string UserName = Request.QueryString["username"];

            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd = new SqlCommand(@"delete from kyclogin where username ='" + UserName + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("UpdateUser.aspx");
            lblmsg.Text = "deleted successfully";
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"] != null)
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());
            }
        }

    }
}