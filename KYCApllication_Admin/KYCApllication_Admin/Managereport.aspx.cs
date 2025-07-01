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
    public partial class Managereport : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["userid"])))
            {
                Response.Redirect("Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }
        }

        protected void ViewAll_Click(object sender, EventArgs e)
        {
            Session["viewaall"] = "viewall";
            Response.Redirect("viewall.aspx");
        }

        protected void submit_Click(object sender, EventArgs e)
        {

            //search by name and date 
            if ((DropDownList1.SelectedValue == "name") && (From.Text != "" && To.Text != ""))
            {
                if(searchinput.Text=="")
                {
                    lbleror.Text = "please enter the name";
                    searchinput.Focus();
                }
                else if (!string.IsNullOrEmpty(searchinput.Text.Trim()) && !Regex.IsMatch(searchinput.Text.Trim(), "^[a-zA-Z]+$"))

                {
                    lbleror.Text = "Special Character are not allowed";
                    searchinput.Focus();
                }
                else
                {
                    Session["Name"] = searchinput.Text;
                    Session["From"] = From.Text;
                    Session["To"] = To.Text;
                    Response.Redirect("namefromto.aspx");
                }

                    
            }
            //search by name 
            else if (DropDownList1.SelectedValue == "name")
            {
                if (searchinput.Text == "")
                {
                    lbleror.Text = "please enter the name";
                    searchinput.Focus();
                }
                else if (!string.IsNullOrEmpty(searchinput.Text.Trim()) && !Regex.IsMatch(searchinput.Text.Trim(), "^[a-zA-Z]+$"))
                {
                    lbleror.Text = "Special Character are not allowed";
                    searchinput.Focus();
                }
                else
                {
                    Session["Name"] = searchinput.Text;
                    Response.Redirect("name_report.aspx");
                }
            }
            //search by account no and date 
            else if ((DropDownList1.SelectedValue == "account")&& (From.Text != "" && To.Text != ""))
            {
                if (searchinput.Text == "")
                {
                    lbleror.Text = "please enter the account no.";
                    searchinput.Focus();
                }
					else if (!string.IsNullOrEmpty(searchinput.Text.Trim()) && !Regex.IsMatch(searchinput.Text.Trim(), "^[0-9]+$"))
                {
                    lbleror.Text = "Special Character are not allowed";
                    searchinput.Focus();
                }
                else
                {
                    Session["acoount_no"] = searchinput.Text;
                    Session["From"] = From.Text;
                    Session["To"] = To.Text;
                    Response.Redirect("accnofromto.aspx");
                }

            }
            //search by account no and date 
            else if (DropDownList1.SelectedValue == "account")
            {
                if (searchinput.Text == "")
                {
                    lbleror.Text = "please enter the account no.";
                    searchinput.Focus();
                }
                else if (!string.IsNullOrEmpty(searchinput.Text.Trim()) && !Regex.IsMatch(searchinput.Text.Trim(), "^[0-9]+$"))
                {
                    lbleror.Text = "Special Character are not allowed";
                    searchinput.Focus();
                }
                else
                {
                    Session["acoount_no"] = searchinput.Text;
                    Response.Redirect("accountno_report.aspx");
                }
                
            }
            //search by kycid and date 
            else if ((DropDownList1.SelectedValue == "kycid") && (From.Text != "" && To.Text != ""))
            {
                if (searchinput.Text == "")
                {
                    lbleror.Text = "please enter the KYC id";
                    searchinput.Focus();
                }
                else if (!string.IsNullOrEmpty(searchinput.Text.Trim()) && !Regex.IsMatch(searchinput.Text.Trim(), "^[a-zA-Z0-9 ]+$"))
                {
                    lbleror.Text = "Special Character are not allowed";
                    searchinput.Focus();
                }
                else
                {
                    Session["kycid"] = searchinput.Text;
                    Session["From"] = From.Text;
                    Session["To"] = To.Text;
                    Response.Redirect("kycidfromto.aspx");
                }

            }
            //search by kycid 
            else if (DropDownList1.SelectedValue == "kycid")
            {
                if (searchinput.Text == "")
                {
                    lbleror.Text = "please enter the Kyc id";
                    searchinput.Focus();
                }
                else if (!string.IsNullOrEmpty(searchinput.Text.Trim()) && !Regex.IsMatch(searchinput.Text.Trim(), "^[a-zA-Z0-9 ]+$"))
                {
                    lbleror.Text = "Special Character are not allowed";
                    searchinput.Focus();
                }
                else
                {
                    Session["Kycid"] = searchinput.Text;
                    Response.Redirect("kycid_report.aspx");
                }
                
            }
            //search by valid and date 
            else if ((DropDownList2.SelectedValue == "approved") && (From.Text != "" && To.Text != ""))
            {
                Session["approved"] = DropDownList2.SelectedValue;
                Session["From"] = From.Text;
                Session["To"] = To.Text;
                Response.Redirect("validfromto.aspx");

            }
            //search by valid
            else if (DropDownList2.SelectedValue == "approved")
            {
               
                     Response.Redirect("validkyc.aspx");
            }
            //search by invalid and date 
            else if ((DropDownList2.SelectedValue == "rejected") && (From.Text != "" && To.Text != ""))
            {
                Session["rejected"] = DropDownList2.SelectedValue;
                Session["From"] = From.Text;
                Session["To"] = To.Text;
                Response.Redirect("invalidfromto.aspx");

            }
            //search by invalid 
            else if (DropDownList2.SelectedValue == "rejected")
            {
                Response.Redirect("Invalid.aspx");
            }
            //search by replied and date 
            else if ((DropDownList2.SelectedValue == "replied") && (From.Text != "" && To.Text != ""))
            {
                Session["replied"] = DropDownList2.SelectedValue;
                Session["From"] = From.Text;
                Session["To"] = To.Text;
                Response.Redirect("repliedfromto.aspx");

            }
            //search by replied
            else if (DropDownList2.SelectedValue == "replied")
            {
                Response.Redirect("Replied.aspx");
            }
            //search by notreplied and date 
            else if ((DropDownList2.SelectedValue == "notreplied") && (From.Text != "" && To.Text != ""))
            {
                Session["notreplied"] = DropDownList2.SelectedValue;
                Session["From"] = From.Text;
                Session["To"] = To.Text;
                Response.Redirect("notrepliedfromto.aspx");

            }
            //search by notreplied and date 
            else if (DropDownList2.SelectedValue == "notreplied")
            {
                Response.Redirect("Notreplied.aspx");
            }
            //search by  date from to 
            else if (From.Text != "" && To.Text != "")
            {
                Session["From"] = From.Text;
                Session["To"] = To.Text;
                Response.Redirect("Generatereport.aspx");
            }
            else
            {
                lbleror.Text = "Please select any one option";
            }
        }
    }
}