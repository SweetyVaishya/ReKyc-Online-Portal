using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KYCApllication_Admin
{
    public partial class AddnewUser : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["userid"])))
            {
                Response.Redirect("Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter sqladapter = new SqlDataAdapter("select * from kyclogin where username='" + username.Text + "'", con);
            DataTable dt = new DataTable();
            sqladapter.Fill(dt);


            if (names.Text == "")
            {
                lbleror.Text = "please enter the name..!!";
                names.Focus();
            }
			  else if (!string.IsNullOrEmpty(names.Text.Trim()) && !Regex.IsMatch(names.Text.Trim(), "^[a-z.A-Z]+$"))
            {
                lbleror.Text = "Special Character are not allowed";
                username.Focus();
            }
			
            else if (username.Text == "")
            {
                lbleror.Text = "please enter the User name..!!";
                username.Focus();
            }
            else if (!string.IsNullOrEmpty(username.Text.Trim()) && !Regex.IsMatch(username.Text.Trim(), "^[a-z.A-Z]+$"))
            {
                lbleror.Text = "Special Character are not allowed";
                username.Focus();
            }
            else if (password.Text == "")
            {
                lbleror.Text = "please enter the password..!!";
                password.Focus();
            }
            else if (confirmpass.Text == "")
            {
                lbleror.Text = "please enter the confirm password..!!";
                confirmpass.Focus();
            }
            else if (status.SelectedValue == "")
            {
                lbleror.Text = "please select status..!!";
                status.Focus();
            }
            else if (confirmpass.Text != password.Text)
            {
                lbleror.Text = "Your entered password and confirm password does not match..!!";
                confirmpass.Focus();
                password.Focus();
            }
            else if (dt.Rows.Count > 0)
            {
                lbleror.Text = "Your entered user name is already used, please use another user name....!";
                username.Focus();
            }
            else
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[kyclogin]
               ([username]
               ,[password]
               ,[status]
               ,[name])
             VALUES
                   ('" + username.Text + "','" + confirmpass.Text + "','" + status.SelectedValue + "','" + names.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblmsg.Text = "New User Added Successecfully";

            }
        }
    }
}