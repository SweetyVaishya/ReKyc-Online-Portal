using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KycApplication
{
    public partial class occupation : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Convert.ToString(Session["Account_no1"])))
            {
                Response.Redirect("Default.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }

            string Name = Convert.ToString(Session["name"]);
           
            
        }



        protected void Submit_Click(object sender, EventArgs e)
        { 
            string acc_no = Convert.ToString(Session["Account_no1"]);
            string kycid = Convert.ToString(Session["kycid"]);
            //string kycid = "KYCRos5091";

            SqlConnection con = new SqlConnection(strcon);
            if (incomesource.SelectedValue == "")
            {
                lblmsg.Text = "Please Select Source Of Income.";
                incomesource.Focus();
            }
            else if (string.IsNullOrWhiteSpace(employename.Text))
            {
                lblmsg.Text = "Please Enter Name of Employer/Business/Industry.";
                employename.Focus();
            }
            else if (string.IsNullOrWhiteSpace(industrytype.Text))
            {
                lblmsg.Text = "Please Enter industry type/ Bussiness type.";
                industrytype.Focus();
            }
            else if (string.IsNullOrWhiteSpace(YearsOfServiceBusiness.Text))
            {
                lblmsg.Text = "Please Enter No of years of service / business.";
                YearsOfServiceBusiness.Focus();
            }
            else if (!Regex.IsMatch(YearsOfServiceBusiness.Text.Trim(), "^[0-9]+$"))
            {
                lblmsg.Text = "Special Character are not allowed enter No of years of service / business. ";
                YearsOfServiceBusiness.Focus();
            }
            else if (from.SelectedValue == "")
            {
                lblmsg.Text = "Please Select Anual income range ( in lakhs)";
                from.Focus();
            }
            
            else {
                //SqlCommand cmd = new SqlCommand("update kycdetail set IncomeSource_HA='" + incomesource.SelectedValue + "' ,empbussname_HA= '" + employename.Text + "',worktype_HA= '" + industrytype.Text + "',Incomefrom_HA='" + from.SelectedValue + "' ,Incometo_HA='" + to.SelectedValue + "' where Kycid='" + kycid + "' ", con);

                SqlCommand cmd = new SqlCommand("update kycdetail set IncomeSource_HA='" + incomesource.SelectedValue + "' ,empbussname_HA= '" + employename.Text + "',worktype_HA= '" + industrytype.Text + "',Incomefrom_HA='" + from.SelectedValue + "',YearsOfServiceBusinessHA='"+ YearsOfServiceBusiness.Text + "'  where Kycid='" + kycid + "' ", con);

                con.Open();
                cmd.ExecuteNonQuery();
                Session["Account_no"] = acc_no;
                Session["kycid"] = kycid;
                Response.Redirect("acknowledgement.aspx");

            }




        }
    }
}