using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using Newtonsoft.Json;

namespace KycApplication
{
    public partial class Contact : Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        private DateTime endTime;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["Account_no"])))
            {
                Response.Redirect("Default.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }
            string Mob_no = Convert.ToString(Session["Mob_no"]);

            mobno.Text = Mob_no.Substring(Mob_no.Length - 4);
            lbleror.Text = string.Empty;

            if (!IsPostBack)
            {
                // Set the end time to 5 minutes from now
                endTime = DateTime.Now.AddMinutes(1);
                Session["EndTime"] = endTime;

                // Initialize the timer label
                UpdateTimerLabel();
                Timer1.Enabled = true; // Enable the timer
            }
            else
            {
                // Retrieve the end time from the session
                endTime = (DateTime)Session["EndTime"];
                UpdateTimerLabel();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            // Calculate the remaining time
            TimeSpan remainingTime = endTime - DateTime.Now;

            if (remainingTime.TotalSeconds > 0)
            {
                // Update the timer label
                timerLabel.Text = $"{remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}";
            }
            else
            {
                // Disable the timer and update the label when time is up
                Timer1.Enabled = false;
                timerLabel.Text = "00:00";
                // Make the "Resend OTP" button visible
                resendotp.Visible = true;
                timerLabel.Visible = false;

               
            }
        }

        private void UpdateTimerLabel()
        {
            TimeSpan remainingTime = endTime - DateTime.Now;
            timerLabel.Text = $"{remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}";
        }

        protected void resendotp_Click(object sender, EventArgs e)
        {
            //string Mob_no = "9137379173";
            string Mob_no = Convert.ToString(Session["Mob_no"]);
            timerLabel.Visible = true;
            //generate otp
            Random generator = new Random();
            String getotp = generator.Next(0, 1000000).ToString("D6");

            SqlConnection con = new SqlConnection(strcon);

            SqlCommand otpexpire = new SqlCommand("UPDATE [dbo].[otp] SET status = 2 WHERE mobile='" + Mob_no + "'", con);



            SqlCommand cmd1 = new SqlCommand(@"INSERT INTO[dbo].[otp]
                ([mobile] ,[otp_gen],[status])
               VALUES('" + Mob_no + "','" + getotp + "','" + 1 + "')", con);
            con.Open();

            otpexpire.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            con.Close();

            //send otp start

            string wurl = "https://app.helo.ai/vivasmpp/sms/submit";
            string api = "372c1aa03a87638462dbb6653b6e6602";
            string number = Mob_no;
            string senderId = "ACBLBK";
            string dlt_templateid = "1107173019434153223";
            string dlt_peid = "1101551980000015619";

            string otp = getotp;

            //string msg = "Dear Customer, " + otp + " is your OTP to access Abhyudaya Bank KYC Updation Portal. OTP is confidential and valid for 10 minute. For security reasons, DO NOT share this OTP with anyone.-Abhyudaya Bank";

            string msg = "OTP to access Abhyudaya Bank KYC Updation Portal is " + otp + ", valid for 10 minutes. Don't share it with anyone - Abhyudaya Bank";

            var request = (HttpWebRequest)WebRequest.Create(wurl);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["apikey"] = api;

            var data = new
            {
                msg_type = 1,
                list = new[] {
            new {
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
            }

            // Set the end time to 5 minutes from now
            endTime = DateTime.Now.AddMinutes(1);
            Session["EndTime"] = endTime;

            // Initialize the timer label
            UpdateTimerLabel();
            Timer1.Enabled = true; // Enable the timer
            resendotp.Visible = false;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            string contform = Convert.ToString(Session["contform"]);

            if (!string.IsNullOrEmpty(otp.Text.Trim()) && !Regex.IsMatch(otp.Text.Trim(), "^[0-9]+$"))
            {
                lbleror.Text = "Special Character are not allowed enter valid OTP ";
                otp.Focus();
            }
            else if (contform == "contform")
            {

               

                     string cust_no = Convert.ToString(Session["cust_no"]);
                string kycid = Convert.ToString(Session["kycid"]);

                SqlConnection con = new SqlConnection(strcon);
                string acc_no = Convert.ToString(Session["Account_no"]);
                string Mob_no = Convert.ToString(Session["Mob_no"]);

                SqlCommand valotp = new SqlCommand("select count(otp_gen) from [dbo].[otp] where mobile='" + Mob_no + "' and otp_gen='" + otp.Text + "' and status='1'", con);
                con.Open();
                string count = valotp.ExecuteScalar().ToString();
                int otpCount = Convert.ToInt32(count);

                if (otpCount <= 0)
                {
                    lbleror.Text = "please enter valid OTP No.!!";
                    otp.Focus();
                }
                else
                {
                    SqlCommand updateststus = new SqlCommand("UPDATE [dbo].[otp] SET  [status] = 2,otp_receive='" + otp.Text + "' WHERE [mobile]='" + Mob_no + "' and otp_gen='" + otp.Text + "'", con);

                    updateststus.ExecuteNonQuery();
                    Session["Account_no1"] = acc_no;
                    Session["kycid"] = kycid;
                    Session["cust_no"] = cust_no;

                    Response.Redirect("ContinueKYCForm.aspx");
                }
            }
            else
            {


                SqlConnection con = new SqlConnection(strcon);
                string acc_no = Convert.ToString(Session["Account_no"]);
                string Mob_no = Convert.ToString(Session["Mob_no"]);
                string kycid = Convert.ToString(Session["kycid"]);
                string cust_no = Convert.ToString(Session["cust_no"]);


                SqlCommand valotp = new SqlCommand("select count(otp_gen) from [dbo].[otp] where mobile='" + Mob_no + "' and otp_gen='" + otp.Text + "' and status='1'", con);
                con.Open();
                string count = valotp.ExecuteScalar().ToString();
                int otpCount = Convert.ToInt32(count);



                if (otpCount <= 0)
                {
                    lbleror.Text = "please enter valid OTP No.!!";
                    otp.Focus();
                }
                else
                {
                    SqlCommand updateststus = new SqlCommand("UPDATE [dbo].[otp] SET  [status] = 2,otp_receive='" + otp.Text + "' WHERE [mobile]='" + Mob_no + "' and otp_gen='" + otp.Text + "'", con);

                    updateststus.ExecuteNonQuery();
                    Session["Account_no1"] = acc_no;
                    Session["kycid"] = kycid;
                    Session["cust_no"] = cust_no;
                    Response.Redirect("Welcome.aspx");
                }
            }
            
        }
    }
}