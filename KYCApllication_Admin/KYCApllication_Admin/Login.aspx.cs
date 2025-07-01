using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KYCApllication_Admin
{
    public partial class _Default : Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            string siteKey = "YOUR_SITE_KEY";
            ScriptManager.RegisterStartupScript(this, GetType(), "ReCaptchaScript", $"var onloadCallback = function() {{ grecaptcha.render('captcha', {{ 'sitekey' : '{siteKey}' }}); }};", true);

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string capcha = txtcaptcha.Text;
            ccJoin.ValidateCaptcha(capcha);


            if (Username.Text == "")
            {
                lbleror.Text = "Please enter username";
                Username.Focus();

            }
            else if (Password.Text == "")
            {
                lbleror.Text = "Please enter Password";
                Password.Focus();
            }
            else if (!string.IsNullOrEmpty(Username.Text.Trim()) && !Regex.IsMatch(Username.Text.Trim(), "^[a-z.A-Z]+$"))
            {
                lbleror.Text = "Special Character are not allowed";
                Username.Focus();
            }
            else if (txtcaptcha.Text == "") 
            {
                lbleror.Text = "Please Enter Valid Captcha";
                txtcaptcha.Focus();
            }
            else if (ccJoin.UserValidated == false)
            {
                lbleror.Text = "The text you typed as shown in the below image is incorrect !!";
            }

            else
            {
                SqlConnection con = new SqlConnection(strcon);

                //SqlCommand cmd = new SqlCommand("insert into kyclogin(username,password)values('" + Username.Text + "','" + Password.Text + "')", con);

                SqlDataAdapter sqladapter = new SqlDataAdapter("select * from kyclogin where username='" + Username.Text + "' and password='" + Password.Text + "' ", con);
                DataTable dt = new DataTable();
                sqladapter.Fill(dt);

                SqlCommand userstatus = new SqlCommand("select status from kyclogin where username='" + Username.Text + "' and password='" + Password.Text + "' ", con);
                con.Open();
                string UserStatus = (string)userstatus.ExecuteScalar();




                if (dt.Rows.Count > 0)
                {
                    string ReturnUrl = Convert.ToString(Request.QueryString["url"]);
                    Session["userid"] = Username.Text;
                    Session["userstatus"] = UserStatus;
                    Response.Redirect("home.aspx");
                   
                }
                else
                {
                    lbleror.Text = "Incorrect username or password !! " +
                        "please enter correct username and password ";
                }
            }
        }
    }
}