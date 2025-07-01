using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace KycApplication
{
    public partial class occupation_join : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(Convert.ToString(Session["Account_no1"])))
            //{
            //    Response.Redirect("Default.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            //}

            string Name = Convert.ToString(Session["name"]);
           
           
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string acc_no = Convert.ToString(Session["Account_no1"]);

            string kycid = Convert.ToString(Session["kycid"]);


            SqlConnection con = new SqlConnection(strcon);

            if (incometypeA.SelectedValue == "")
            {
                lblmsg.Text = "Please Select Source Of Income. A/C Holder A";
                incometypeA.Focus();
            }
            else if (incometypeB.SelectedValue == "")
            {
                lblmsg.Text = "Please Select Source Of Income. A/C Holder B";
                incometypeB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(empnameA.Text))
            {
                lblmsg.Text = "Please Enter Employee. A/C Holder A";
                empnameA.Focus();
            }
            else if (string.IsNullOrWhiteSpace(empnameB.Text))
            {
                lblmsg.Text = "Please Enter Employee. A/C Holder B";
                empnameB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(indutypeA.Text))
            {
                lblmsg.Text = "Please Enter industry type/ Bussiness type.  A/C Holder A";
                indutypeA.Focus();
            }
            else if (string.IsNullOrWhiteSpace(indutypeB.Text))
            {
                lblmsg.Text = "Please Enter industry type/ Bussiness type.  A/C Holder B";
                indutypeB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(YearsOfServiceBusinessHA.Text))
            {
                lblmsg.Text = "Please Enter No of years of service / business A/C Holder A";
                YearsOfServiceBusinessHA.Focus();
            }
            else if (!string.IsNullOrEmpty(YearsOfServiceBusinessHA.Text.Trim()) && !Regex.IsMatch(YearsOfServiceBusinessHA.Text.Trim(), "^[0-9]+$"))
            {
                lblmsg.Text = "Special Character are not allowed Enter No of years of service / business A/C Holder A";
                YearsOfServiceBusinessHA.Focus();
            }
            else if (string.IsNullOrWhiteSpace(YearsOfServiceBusinessHB.Text))
            {
                lblmsg.Text = "Please Enter No of years of service / business A/C Holder B";
                YearsOfServiceBusinessHB.Focus();
            }
            else if (!string.IsNullOrEmpty(YearsOfServiceBusinessHB.Text.Trim()) && !Regex.IsMatch(YearsOfServiceBusinessHB.Text.Trim(), "^[0-9]+$"))
            {
                lblmsg.Text = "Special Character are not allowed Enter No of years of service / business A/C Holder B";
                YearsOfServiceBusinessHB.Focus();
            }

            else if (fromA.SelectedValue == "")
            {
                lblmsg.Text = "Please Select Amount income range (in lakhs) A/C Holder A";
                fromA.Focus();
            }
            else if (fromB.SelectedValue == "")
            {
                lblmsg.Text = "Please Select Amount income range (in lakhs) A/C Holder B";
                fromB.Focus();
            }
            //else if (toA.SelectedValue == "")
            //{
            //    lblmsg.Text = "Please Select To Value. A/C Holder A";
            //    toA.Focus();
            //}
            //else if (toB.SelectedValue == "")
            //{
            //    lblmsg.Text = "Please Select To Value. A/C Holder B";
            //    toB.Focus();
            //}
            else
            {
                

                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[kycdetail] SET[IncomeSource_HA] = '" + incometypeA.SelectedValue + "',[IncomeSource_HB] = '" + incometypeB.SelectedValue + "',[empbussname_HA] = '" + empnameA.Text + "',[empbussname_HB] = '" + empnameB.Text + "',[worktype_HA] = '" + indutypeA.Text + "',[worktype_HB] = '" + indutypeB.Text + "',[Incomefrom_HA] = '" + fromA.SelectedValue + "',[Incomefrom_HB] = '" + fromB.SelectedValue + "',[YearsOfServiceBusinessHA]='"+ YearsOfServiceBusinessHA.Text + "' ,[YearsOfServiceBusinessHB]='" + YearsOfServiceBusinessHB.Text + "' where Kycid='" + kycid + "' ", con);
                //SqlCommand cmd = new SqlCommand("UPDATE [dbo].[kycdetail] SET[IncomeSource_HA] = '" + incometypeA.SelectedValue + "',[IncomeSource_HB] = '" + incometypeB.SelectedValue + "',[empbussname_HA] = '" + empnameA.Text + "',[empbussname_HB] = '" + empnameB.Text + "',[worktype_HA] = '" + indutypeA.Text + "',[worktype_HB] = '" + indutypeB.Text + "',[Incomefrom_HA] = '" + fromA.SelectedValue + "',[Incomefrom_HB] = '" + fromB.SelectedValue + "',[YearsOfServiceBusinessHA]='" + YearsOfServiceBusinessHA.Text + "' ,[YearsOfServiceBusinessHB]='" + YearsOfServiceBusinessHB.Text + "' where Kycid='KYCRos2214' ", con);

                con.Open();
                cmd.ExecuteNonQuery();
                Session["Account_no"] = acc_no;
                Session["kycid"] = kycid;
                Response.Redirect("acknowledgement.aspx");


            }




        }
    }
}