using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KYCApllication_Admin
{
    public partial class UpdateStatus : System.Web.UI.Page
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


            string Kycid = Request.QueryString["Kycid"];

 

            SqlConnection con = new SqlConnection(strcon);

            if (string.IsNullOrEmpty(Convert.ToString(Session["userid"])))
            {
                Response.Redirect("Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }

            SqlCommand getacctype = new SqlCommand("SELECT [accout_type] FROM [kycdetail] where kycid='" + Kycid + "'", con);

            SqlCommand getaccnumber = new SqlCommand("SELECT [acoount_no] FROM [kycdetail] where kycid='" + Kycid + "'", con);

            //kycapplication SqlDataAdapter
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
                          FROM [kycdetail] where kycid='" + Kycid + "'", con);


            //Aadhar api SqlDataAdapter
            SqlDataAdapter Aadhardata = new SqlDataAdapter(@"SELECT [id]
              ,[kycid]
              ,[fullname]
              ,[care_of]
              ,[aadhar_card]
              ,[client_id]
              ,[DOB]
              ,[address]
              ,[status_code]
              ,[message]
              ,[success]
              ,[Create_at]
              ,[fullname2]
              ,[care_of2]
              ,[aadhar_card2]
              ,[client_id2]
              ,[DOB2]
              ,[address2]
              ,[status_code2]
              ,[message2]
              ,[success2]
          FROM [AadharApi_data] where kycid='" + Kycid + "'", con);


            //Pancarddata Api SqlDataAdapter
            SqlDataAdapter Pancarddata = new SqlDataAdapter(@"SELECT TOP (1000) [id]
                  ,[kyc_id]
                  ,[fullname]
                  ,[Pan_number]
                  ,[client_id]
                  ,[category]
                  ,[status_code]
                  ,[success_result]
                  ,[msg_result]
                  ,[msg_code]
                  ,[Create_at]
                  ,[fullname2]
                  ,[Pan_number2]
                  ,[client_id2]
                  ,[category2]
                  ,[status_code2]
                  ,[success_result2]
                  ,[msg_result2]
                  ,[msg_code2]
              FROM [PanApi_data] where kyc_id='" + Kycid + "'", con);
            con.Open();
            //bank priovide accountdata SqlDataAdapter

            string accnumber = (string)getaccnumber.ExecuteScalar();

            SqlDataAdapter bankdata = new SqlDataAdapter(@"SELECT  [id]
              ,[AccountNo]
              ,[Name]
              ,[Mob_no]
              ,[cust_no]
              ,[Address]
              ,[Address2]
              ,[Address3]
              ,[pin_code]
          FROM [TblOmtDetail] where AccountNo='" + accnumber + "'", con);

            

           string  acctype = (string)getacctype.ExecuteScalar();

            ///bank priovide accountdata DataBind

            DataTable Bankdata = new DataTable();
            bankdata.Fill(Bankdata);
            Repeater7.DataSource = Bankdata;
            Repeater7.DataBind();
           

            //kycapplication DataBind

            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Repeater4.DataSource = dt;
            Repeater4.DataBind();


            //Aadhar api DataBind

            DataTable aadhardt = new DataTable();
            Aadhardata.Fill(aadhardt);
            Repeater2.DataSource = aadhardt;
            Repeater2.DataBind();
            Repeater5.DataSource = aadhardt;
            Repeater5.DataBind();



            //Pancarddata Api DataBind

            DataTable Pandt = new DataTable();
            Pancarddata.Fill(Pandt);
            Repeater3.DataSource = Pandt;
            Repeater3.DataBind();
            Repeater6.DataSource = Pandt;
            Repeater6.DataBind();

            

            con.Close();

            if (acctype == "Join")
            {
                holder2.Visible = true;
            }

        }

        protected void Submit_Click1(object sender, EventArgs e)
        {


            if (remark.SelectedValue == "")
            {
                lblmsg.Text = "Please update status";
                lblmsg.ForeColor = Color.Red;
            }
            else if (remark.SelectedValue == "Approved")
            {
                reason.Visible = false;

                string userid1 = Convert.ToString(Session["userid"]);

                SqlConnection con = new SqlConnection(strcon);
                string Kycid = Request.QueryString["Kycid"];

                con.Open(); // Open the connection here.

                SqlCommand getaccnumber = new SqlCommand("SELECT [acoount_no] FROM [kycdetail] where kycid='" + Kycid + "'", con);
                string accnumber = (string)getaccnumber.ExecuteScalar();

                SqlCommand cmd1 = new SqlCommand(@"select name from kyclogin where username = '" + userid1 + "'", con);
                string username = (string)cmd1.ExecuteScalar();

                SqlCommand getMobnumber = new SqlCommand("SELECT [mobail_no] FROM [kycdetail] where kycid='" + Kycid + "'", con);
                string getmobno = (string)getMobnumber.ExecuteScalar();

                SqlCommand cust = new SqlCommand(@"select [cust_no] from [TblOmtDetail] where AccountNo='" + accnumber + "'", con);
                string custNo = (string)cust.ExecuteScalar();

                string adminName = username;

                // Construct the SQL update statement with the admin's name.
                //SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET status = @Status, reply_date = GETDATE() WHERE Kycid = @Kycid", con);
                //cmd.Parameters.AddWithValue("@Status", remark.SelectedValue);
                //cmd.Parameters.AddWithValue("@Kycid", Kycid);

                SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET status = @Status, reply_date = GETDATE(), approved_by = @AdminName WHERE Kycid = @Kycid", con);
                cmd.Parameters.AddWithValue("@Status", remark.SelectedValue);
                cmd.Parameters.AddWithValue("@AdminName", adminName);
                cmd.Parameters.AddWithValue("@Kycid", Kycid);


                cmd.ExecuteNonQuery();

                con.Close(); // Close the connection after executing the queries.

                lblmsg.Text = "Remark updated successfully...!!";
                lblmsg.ForeColor = Color.Blue;


                string wurl = "https://app.helo.ai/vivasmpp/sms/submit";
                string api = "372c1aa03a87638462dbb6653b6e6602";  // Replace with your actual API key
                string number = getmobno;
                string senderId = "ACBLBK";
                string dlt_templateid = "1107172674343354150";

                string dlt_peid = "1101551980000015619";
                //string msg = "Dear Customer, your online Re-KYC details for Customer No. " + custNo + " is approved and same will be updated in the systen within 24 hours (on working day) - Abhyudaya Bank";
                string msg = "Dear Customer, your online Re-KYC details for Customer No.  " + custNo + " is Approved & your Re-KYC records will be updated within 24 working hours - Abhyudaya Bank";

                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(wurl);
                    request.Method = "POST";
                    request.ContentType = "application/json";

                    // Set the API key in the Authorization header
                    //request.Headers["Authorization"] = "Bearer " + api;     // roshan 
                    request.Headers["apikey"] = api;

                    var data = new
                    {

                        msg_type = 2,
                        list = new[]
                        {
            new
            {
                d = number,
                s = senderId,
                m = msg,
                dlt_templateid = dlt_templateid,
                dlt_peid = dlt_peid
            }
        }
                    };

                    string json = JsonConvert.SerializeObject(data);


                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }


                    var response = (HttpWebResponse)request.GetResponse();

                    string result;
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                        lblmsg.Text = "Remark updated successfully...!! ";
                        lblmsg.ForeColor = Color.Blue;
                    }



                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., network errors, API errors) and log them
                    lblmsg.Text = "An error occurred while sending the SMS: " + ex.Message;
                    lblmsg.ForeColor = Color.Red;
                }
            }


            else if (remark.SelectedValue == "Rejected")
            {
                // reason.Visible = true;
                string userid1 = Convert.ToString(Session["userid"]);

                if (txtreason.Text == "")
                {
                    lblmsg.Text = "Please fill reasons";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    SqlConnection con = new SqlConnection(strcon);
                    string Kycid = Request.QueryString["Kycid"];
                    SqlCommand getaccnumber = new SqlCommand("SELECT [acoount_no] FROM [kycdetail] where kycid='" + Kycid + "'", con);
                    SqlCommand getMobnumber = new SqlCommand("SELECT [mobail_no] FROM [kycdetail] where kycid='" + Kycid + "'", con);
                    SqlCommand cmd1 = new SqlCommand(@"select name from kyclogin where username = '" + userid1 + "'", con);

                    string custNo = null;

                    //string getmobno = "mobail_no";
                    con.Open(); // Open the connection here
                    string getmobno = (string)getMobnumber.ExecuteScalar();
                    string accnumber = (string)getaccnumber.ExecuteScalar();
                    string username = (string)cmd1.ExecuteScalar();


                    string adminName = username;



                    // Retrieve the custNo first
                    SqlCommand cust = new SqlCommand(@"select [cust_no] from [TblOmtDetail] where AccountNo='" + accnumber + "'", con);
                    custNo = (string)cust.ExecuteScalar();

                    // Update the status and reasons
                    SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET status ='" + remark.SelectedValue + "', Reasons = '" + txtreason.Text + "', reply_date = GETDATE(),approved_by = @AdminName WHERE Kycid = '" + Kycid + "'", con);
                    cmd.Parameters.AddWithValue("@AdminName", adminName);
                    cmd.ExecuteNonQuery();

                    // Close the connection
                    con.Close();

                   

                    // Send SMS here
                    //Random generator = new Random();
                    //String getotp = generator.Next(0, 1000000).ToString("D6");

                    //Random generator1 = new Random();
                    //String id = generator1.Next(0, 1000000).ToString("D6");

                    //Rest of your SMS sending code


                    //send otp start

                    string wurl = "https://app.helo.ai/vivasmpp/sms/submit";
                    string api = "372c1aa03a87638462dbb6653b6e6602";  // Replace with your actual API key
                    string number = getmobno;
                    string senderId = "ACBLBK";
                    //string dlt_templateid = "1107169380722288081";
                    string dlt_templateid = "1107170030640606695";

                    string dlt_peid = "1101551980000015619";
                    //string custNo = "12345";  // Replace with the actual customer number

                    //string msg = "Dear Customer, your online KYC details for Customer No. " + custNo + " is not processed. Kindly contact the branch and submit the required details for KYC updation - Abhyudaya Bank";
                    //string msg = "Dear Customer,your online KYC details for Customer No. " + custNo + " is not processed.Kindly contact branch and submit required details for KYC updation-Abhyudaya Bank";

                    string msg = "Dear Customer, your online Re-KYC details for Customer No. " + custNo + " is not approved due to mismatch with Bank records. Kindly contact branch and submit required details for Re-KYC - Abhyudaya Bank";

                    try
                    {
                        var request = (HttpWebRequest)WebRequest.Create(wurl);
                        request.Method = "POST";
                        request.ContentType = "application/json";

                        // Set the API key in the Authorization header
                        //request.Headers["Authorization"] = "Bearer " + api;     // roshan 
                        request.Headers["apikey"] = api;

                        var data = new
                        {
                            
                            msg_type = 2,
                            list = new[]
                            {
            new
            {
                d = number,
                s = senderId,
                m = msg,
                dlt_templateid = dlt_templateid,
                dlt_peid = dlt_peid
            }
        }
                        };

                        string json = JsonConvert.SerializeObject(data);


                        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        {
                            streamWriter.Write(json);
                            streamWriter.Flush();
                            streamWriter.Close();
                        }


                        var response = (HttpWebResponse)request.GetResponse();

                        string result;
                        using (var streamReader = new StreamReader(response.GetResponseStream()))
                        {
                            result = streamReader.ReadToEnd();
                            lblmsg.Text = "Remark updated successfully...!! ";
                            lblmsg.ForeColor = Color.Blue;
                        }


                       
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions (e.g., network errors, API errors) and log them
                        lblmsg.Text = "An error occurred while sending the SMS: " + ex.Message;
                        lblmsg.ForeColor = Color.Red;
                    }


                }
            }


         
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"] != null)
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());
            }
        }

        protected void remark_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (remark.SelectedValue == "Rejected")
            {
                reason.Visible = true;
                reasonlbl.Text = "Reason";
            }
            else
            {
                reason.Visible = false;
            }
        }
    }
}