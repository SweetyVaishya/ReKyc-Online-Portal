using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using Twilio.TwiML.Voice;
using Newtonsoft.Json;

namespace KycApplication
{
    public partial class _Default : Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            

            SqlConnection con = new SqlConnection(strcon);
            SqlCommand otpexpire = new SqlCommand("UPDATE [otp] SET status = 2 WHERE DATEDIFF(MINUTE, [created_at], CURRENT_TIMESTAMP) > 2", con);
            con.Open();
            otpexpire.ExecuteNonQuery();
            con.Close();
        }

        protected void Submit_Click1(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(Account_no.Text.Trim()) && !Regex.IsMatch(Account_no.Text.Trim(), "^[0-9]+$"))
            {
                lbleror.Text = "Special Character are not allowed enter valid account no. or customer no. ";
                Account_no.Focus();
            }
            else { 
  

            SqlConnection con = new SqlConnection(strcon);
            SqlCommand accno = new SqlCommand(@" select AccountNo  FROM [dbo].[TblOmtDetail] where AccountNo='" + Account_no.Text + "' or cust_no='" + Account_no.Text + "'", con);
            SqlCommand acchname = new SqlCommand(@" select Name  FROM [dbo].[TblOmtDetail] where AccountNo='" + Account_no.Text + "' or cust_no='" + Account_no.Text + "'", con);
            //SqlCommand mobno = new SqlCommand(@" select Mob_no  FROM [dbo].[TblOmtDetail] where AccountNo='" + Account_no.Text + "'", con);
            SqlCommand mobno = new SqlCommand(@" select Mob_no  FROM [dbo].[TblOmtDetail] where AccountNo='" + Account_no.Text + "' or cust_no='" + Account_no.Text + "'", con);
            SqlCommand countid = new SqlCommand("select count (*) FROM [TblOmtDetail] where AccountNo='" + Account_no.Text + "' or cust_no='" + Account_no.Text + "'", con);

            //SqlCommand Custid = new SqlCommand(@"select cust_no FROM [TblOmtDetail] where cust_no='" + Account_no.Text + "", con);

                SqlCommand Custid = new SqlCommand("SELECT cust_no FROM [dbo].[TblOmtDetail] where AccountNo='" + Account_no.Text + "' or cust_no='" + Account_no.Text + "'", con);
                //Custid.Parameters.AddWithValue("@CustNo", Account_no.Text);

                con.Open();
            string getaccno = (string)accno.ExecuteScalar();
            string getacchname = (string)acchname.ExecuteScalar();
            string getmobno = (string)mobno.ExecuteScalar();
                string getcustid = Custid.ExecuteScalar()?.ToString();
                
                string count = countid.ExecuteScalar().ToString();
              

            int accCount = Convert.ToInt32(count);

                SqlCommand checkstatus = new SqlCommand(@"select COUNT(*)  FROM [kycdetail]  where acoount_no='" + getaccno + "' and status='Approved'", con);
                string checkstatuscount = checkstatus.ExecuteScalar().ToString();
                int CheckStatusCount = Convert.ToInt32(checkstatuscount);

                
                SqlCommand kycsub = new SqlCommand(@"select top(1) COUNT(*)  FROM[kycdetail]  where acoount_no = '" + getaccno + "' and YearsOfServiceBusinessHA!= '' and status='' ", con);
             string subkyc = kycsub.ExecuteScalar().ToString();
             int kycSubCount = Convert.ToInt32(subkyc);

                //new_22062024 

                SqlCommand checalrfill = new SqlCommand(@"SELECT COUNT(*) FROM[kycdetail]
          WHERE(acoount_no = @accountNo OR cust_no = @CustNo) AND (YearsOfServiceBusinessHA IS NULL OR YearsOfServiceBusinessHA = '')", con);

                checalrfill.Parameters.AddWithValue("@accountNo", Account_no.Text);
                checalrfill.Parameters.AddWithValue("@CustNo", Account_no.Text);

                string checkcustcount = checalrfill.ExecuteScalar().ToString();
                int alrformfill = Convert.ToInt32(checkcustcount);

                string bank = "KYC";
            string status = "";

            //generate otp
            Random generator = new Random();
            String getotp = generator.Next(0, 1000000).ToString("D6");

            Random generator1 = new Random();
            String id = generator1.Next(0, 1000000).ToString("D6");

            if (accCount < 0)
            {
                lbleror.Text = "Please enter valid account no. or customer no.";
                    Account_no.Focus();
            }
             else  if (accCount == 0)
            {
                lbleror.Text = "Please enter valid account no. or customer no.";
                    Account_no.Focus();
            }

             else if (kycSubCount > 0)
            {
                    Submit.Visible = false;
                    verifyRekyc.Text = "Your kyc application is already submitted, wait for bank responce .";
                    verifyRekyc.ForeColor = System.Drawing.Color.Red;
                    Account_no.Focus();
            }

            else if (CheckStatusCount > 0)
            {
                    
                    SqlCommand risk = new SqlCommand("select [Risk] FROM [TblOmtDetail] where AccountNo='" + getaccno + "'", con);
                    string riskname = risk.ExecuteScalar().ToString();
                    //int cmdfxy = Convert.ToInt32(cmdfx);

                    if (riskname == "High")
                    {
                        // SqlCommand year = new SqlCommand("select count(Create_at) from [kycdetail] WHERE acoount_no ='" + getaccno + "'and DATEDIFF(DAY, Create_at, CURRENT_TIMESTAMP) > 730", con);
                        SqlCommand year = new SqlCommand(" select  Top(1) Create_at FROM[kycdetail] where acoount_no='" + getaccno + "' or DATEDIFF(DAY, Create_at, CURRENT_TIMESTAMP) > 730 order by id desc", con);
                        string yearcount = year.ExecuteScalar().ToString();

                        SqlCommand daetkyc = new SqlCommand(" select top(1) Create_at FROM[kycdetail] where acoount_no = '" + getaccno + "' and YearsOfServiceBusinessHA!= '' order by id desc", con);
                        string kycdate = daetkyc.ExecuteScalar().ToString();

                        DateTime createDate;

                        if (DateTime.TryParse(yearcount, out createDate))
                        {
                            DateTime currentDate = DateTime.Now;

                            TimeSpan difference = currentDate - createDate;


                            if (difference.TotalDays > 730) // 730 days is approximately 2 years
                            {
                                

                                string Kycid = bank.Substring(0, 3) + getacchname.Substring(0, 3) + id.Substring(id.Length - 4);  //kyc-name-uniqueno

                                SqlCommand cmd1 = new SqlCommand(@"INSERT INTO[dbo].[otp]
                            ([mobile] ,[otp_gen],[status])
                           VALUES('" + getmobno + "','" + getotp + "','" + 1 + "')", con);

                                //Save data on database
                                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[kycdetail]
                               ([Kycid]
                               ,[Name]
                               ,[acoount_no]
                               ,[cust_no]
                               ,[mobail_no]
                               ,[accout_type]
                               ,[status])
                             VALUES
                                   ('" + Kycid + "','" + getacchname + "','" + getaccno + "','" + getcustid + "','" + getmobno + "','  ','" + status + "')", con);

                                cmd.ExecuteNonQuery();
                                cmd1.ExecuteNonQuery();


                                Session["Account_no"] = getaccno;
                                Session["Mob_no"] = getmobno;
                                Session["kycid"] = Kycid;
                                Session["cust_no"] = getcustid;

                                

                                con.Close();

                                //send otp start

                                string wurl = "https://app.helo.ai/vivasmpp/sms/submit";
                                string api = "372c1aa03a87638462dbb6653b6e6602";
                                string number = getmobno;
                                string senderId = "ACBLBK";
                                string dlt_templateid = "1107173019434153223";
                                string dlt_peid = "1101551980000015619";
                              
                                string otp = getotp;

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

                                Response.Redirect("enterotp.aspx");

                            }
                            else if (alrformfill > 0)
                            {

                                SqlConnection con1 = new SqlConnection(strcon);
                                SqlCommand KYCID = new SqlCommand(@"  SELECT TOP (1) Kycid  FROM [dbo].[kycdetail]  WHERE (acoount_no = '" + Account_no.Text + "' OR cust_no = '" + Account_no.Text + "') AND (YearsOfServiceBusinessHA IS NULL OR YearsOfServiceBusinessHA = '') ORDER BY id DESC ", con);
                                string kycnum = KYCID.ExecuteScalar().ToString();


                                //generate new kyc id
                                string Kycid = kycnum;  //kyc-name-uniqueno

                                SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [otp]
                ([mobile] ,[otp_gen],[status])
               VALUES('" + getmobno + "','" + getotp + "','" + 1 + "')", con);

                                cmd1.ExecuteNonQuery();

                                Session["contform"] = "contform";
                                Session["Account_no"] = getaccno;
                                Session["Mob_no"] = getmobno;
                                Session["kycid"] = Kycid;
                                Session["cust_no"] = getcustid;

                                con.Close();

                                //send otp start

                                string wurl = "https://app.helo.ai/vivasmpp/sms/submit";
                                string api = "372c1aa03a87638462dbb6653b6e6602";
                                string number = getmobno;
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

                                Response.Redirect("enterotp.aspx");
                            }
                            else
                            {
                                Submit.Visible = false;
                                verifyRekyc.Text = "Your kyc application is already submitted on " + kycdate + " so you don't need to think anything about it. " +
                                    "To apply for kyc again try after 2 years from the date of your earlier submitted KYC application";
                                Account_no.Focus();
                            }
                        }
                        else
                        {
                            lbleror.Text = "Invalid date format.";
                        }





                    }
                    else if (riskname == "Medium")
                    {
                        // SqlCommand year = new SqlCommand("select count(Create_at) from [kycdetail] WHERE acoount_no ='" + getaccno + "'and DATEDIFF(DAY, Create_at, CURRENT_TIMESTAMP) > 730", con);
                        SqlCommand year = new SqlCommand(" select  Top(1) Create_at FROM[kycdetail] where acoount_no='" + getaccno + "' or DATEDIFF(DAY, Create_at, CURRENT_TIMESTAMP) > 2920 order by id desc", con);
                        string yearcount = year.ExecuteScalar().ToString();

                        SqlCommand daetkyc = new SqlCommand(" select top(1) Create_at FROM[kycdetail] where acoount_no = '" + getaccno + "' and YearsOfServiceBusinessHA!= '' order by id desc", con);
                        string kycdate = daetkyc.ExecuteScalar().ToString();

                        DateTime createDate;

                        if (DateTime.TryParse(yearcount, out createDate))
                        {
                            DateTime currentDate = DateTime.Now;
                            TimeSpan difference = currentDate - createDate;

                            if (difference.TotalDays > 2920) // 2920 days is approximately 8 years
                            {

                                string Kycid = bank.Substring(0, 3) + getacchname.Substring(0, 3) + id.Substring(id.Length - 4);  //kyc-name-uniqueno

                                SqlCommand cmd1 = new SqlCommand(@"INSERT INTO[dbo].[otp]
                            ([mobile] ,[otp_gen],[status])
                           VALUES('" + getmobno + "','" + getotp + "','" + 1 + "')", con);

                                //Save data on database
                                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[kycdetail]
                               ([Kycid]
                               ,[Name]
                               ,[acoount_no]
                               ,[cust_no]
                               ,[mobail_no]
                               ,[accout_type]
                               ,[status])
                             VALUES
                                   ('" + Kycid + "','" + getacchname + "','" + getaccno + "','" + getcustid + "','" + getmobno + "','  ','" + status + "')", con);

                                cmd.ExecuteNonQuery();
                                cmd1.ExecuteNonQuery();


                                Session["Account_no"] = getaccno;
                                Session["Mob_no"] = getmobno;
                                Session["kycid"] = Kycid;
                                Session["cust_no"] = getcustid;

                               

                                con.Close();

                                //send otp start

                                string wurl = "https://app.helo.ai/vivasmpp/sms/submit";
                                string api = "372c1aa03a87638462dbb6653b6e6602";
                                string number = getmobno;
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

                                Response.Redirect("enterotp.aspx");

                            }
                            else if (alrformfill > 0)
                            {

                                SqlConnection con1 = new SqlConnection(strcon);
                                SqlCommand KYCID = new SqlCommand(@"  SELECT TOP (1) Kycid  FROM [dbo].[kycdetail]  WHERE (acoount_no = '" + Account_no.Text + "' OR cust_no = '" + Account_no.Text + "') AND (YearsOfServiceBusinessHA IS NULL OR YearsOfServiceBusinessHA = '') ORDER BY id DESC ", con);
                                string kycnum = KYCID.ExecuteScalar().ToString();


                                //generate new kyc id
                                string Kycid = kycnum;  //kyc-name-uniqueno

                                SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [otp]
                ([mobile] ,[otp_gen],[status])
               VALUES('" + getmobno + "','" + getotp + "','" + 1 + "')", con);

                                cmd1.ExecuteNonQuery();

                                Session["contform"] = "contform";
                                Session["Account_no"] = getaccno;
                                Session["Mob_no"] = getmobno;
                                Session["kycid"] = Kycid;
                                Session["cust_no"] = getcustid;



                                con.Close();

                                //send otp start

                                string wurl = "https://app.helo.ai/vivasmpp/sms/submit";
                                string api = "372c1aa03a87638462dbb6653b6e6602";
                                string number = getmobno;
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

                                Response.Redirect("enterotp.aspx");
                            }
                            else
                            {
                                Submit.Visible = false;
                                verifyRekyc.Text = "Your kyc application is already submitted on " + kycdate + " so you don't need to think anything about it. " +
                                    "To apply for kyc again try after 8 years from the date of your earlier submitted KYC application";
                                Account_no.Focus();
                            }
                        }
                        else
                        {
                            lbleror.Text = "Invalid date format.";
                        }
                    }
                    else if (riskname == "Low")
                    {

                        SqlCommand year = new SqlCommand(" select  Top(1) Create_at FROM[kycdetail] where acoount_no='" + getaccno + "' or DATEDIFF(DAY, Create_at, CURRENT_TIMESTAMP) > 3650 order by id desc", con);
                        string yearcount = year.ExecuteScalar().ToString();

                        SqlCommand daetkyc = new SqlCommand(" select top(1) Create_at FROM[kycdetail] where acoount_no = '" + getaccno + "' and YearsOfServiceBusinessHA!= '' order by id desc", con);
                        string kycdate = daetkyc.ExecuteScalar().ToString();

                        DateTime createDate;

                        if (DateTime.TryParse(yearcount, out createDate))
                        {
                            DateTime currentDate = DateTime.Now;
                            TimeSpan difference = currentDate - createDate;

                            if (difference.TotalDays > 3650) // 3650 days is approximately 10 years
                            {

                                string Kycid = bank.Substring(0, 3) + getacchname.Substring(0, 3) + id.Substring(id.Length - 4);  //kyc-name-uniqueno

                                SqlCommand cmd1 = new SqlCommand(@"INSERT INTO[dbo].[otp]
                            ([mobile] ,[otp_gen],[status])
                           VALUES('" + getmobno + "','" + getotp + "','" + 1 + "')", con);

                                //Save data on database
                                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[kycdetail]
                               ([Kycid]
                               ,[Name]
                               ,[acoount_no]
                               ,[cust_no]
                               ,[mobail_no]
                               ,[accout_type]
                               ,[status])
                             VALUES
                                   ('" + Kycid + "','" + getacchname + "','" + getaccno + "','" + getcustid + "','" + getmobno + "','  ','" + status + "')", con);

                                cmd.ExecuteNonQuery();
                                cmd1.ExecuteNonQuery();


                                Session["Account_no"] = getaccno;
                                Session["Mob_no"] = getmobno;
                                Session["kycid"] = Kycid;
                                Session["cust_no"] = getcustid;

                                //Response.Redirect("enterotp.aspx");
                                //lbleror.Text = "Data submited succ";

                                con.Close();

                                //send otp start

                                string wurl = "https://app.helo.ai/vivasmpp/sms/submit";
                                string api = "372c1aa03a87638462dbb6653b6e6602";
                                string number = getmobno;
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

                                Response.Redirect("enterotp.aspx");

                            }
                            else if (alrformfill > 0)
                            {

                                SqlConnection con1 = new SqlConnection(strcon);
                                SqlCommand KYCID = new SqlCommand(@"  SELECT TOP (1) Kycid  FROM [dbo].[kycdetail]  WHERE (acoount_no = '" + Account_no.Text + "' OR cust_no = '" + Account_no.Text + "') AND (YearsOfServiceBusinessHA IS NULL OR YearsOfServiceBusinessHA = '') ORDER BY id DESC ", con);
                                string kycnum = KYCID.ExecuteScalar().ToString();


                                //generate new kyc id
                                string Kycid = kycnum;  //kyc-name-uniqueno

                                SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [otp]
                ([mobile] ,[otp_gen],[status])
               VALUES('" + getmobno + "','" + getotp + "','" + 1 + "')", con);

                                cmd1.ExecuteNonQuery();

                                Session["contform"] = "contform";
                                Session["Account_no"] = getaccno;
                                Session["Mob_no"] = getmobno;
                                Session["kycid"] = Kycid;
                                Session["cust_no"] = getcustid;



                                con.Close();

                                //send otp start

                                string wurl = "https://app.helo.ai/vivasmpp/sms/submit";
                                string api = "372c1aa03a87638462dbb6653b6e6602";
                                string number = getmobno;
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

                                Response.Redirect("enterotp.aspx");
                            }
                            else
                            {
                                Submit.Visible = false;
                                verifyRekyc.Text = "Your kyc application is already submitted on " + kycdate + " so you don't need to think anything about it. " +
                                    "To apply for kyc again try after 10 years from the date of your earlier submitted KYC application";
                                Account_no.Focus();
                            }
                        }
                        else
                        {
                            lbleror.Text = "Invalid date format.";
                        }
                    }
                }
                else if (alrformfill > 0)
                {

                    SqlConnection con1 = new SqlConnection(strcon);
                    SqlCommand KYCID = new SqlCommand(@"  SELECT TOP (1) Kycid  FROM [dbo].[kycdetail]  WHERE (acoount_no = '" + Account_no.Text + "' OR cust_no = '" + Account_no.Text + "') AND (YearsOfServiceBusinessHA IS NULL OR YearsOfServiceBusinessHA = '') ORDER BY id DESC ", con);
                    string kycnum = KYCID.ExecuteScalar().ToString();
                   

                    //generate new kyc id
                    string Kycid = kycnum;  //kyc-name-uniqueno

                    SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [otp]
                ([mobile] ,[otp_gen],[status])
               VALUES('" + getmobno + "','" + getotp + "','" + 1 + "')", con);

                    cmd1.ExecuteNonQuery();

                    Session["contform"] = "contform";
                    Session["Account_no"] = getaccno;
                    Session["Mob_no"] = getmobno;
                    Session["kycid"] = Kycid;
                    Session["cust_no"] = getcustid;

                   

                    con.Close();

                    //send otp start

                    string wurl = "https://app.helo.ai/vivasmpp/sms/submit";
                    string api = "372c1aa03a87638462dbb6653b6e6602";
                    string number = getmobno;
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

                    Response.Redirect("enterotp.aspx");
                }
            
                else
                {
                    //generate new kyc id
                    //string Kycid = bank.Substring(0, 3) + getacchname.Substring(0, 3) + getaccno.Substring(getaccno.Length - 4);
                    //string Kycid = bank.Substring(0, 3) + getacchname.Substring(0, 3).ToUpper() + id.Substring(id.Length - 4);       //kyc-name-uniqueno

                    string Kycid = bank.Substring(0, 3).ToUpper() + getacchname.Substring(0, 3).ToUpper() + id.Substring(id.Length - 4);


                    //string Kycid = bank.Substring(0, 3) + DateTime.Now.Year.ToString().Substring(0, 4) + id.Substring(id.Length - 4);    //kyc-year-uniqueno

                    //string Kycid = bank.Substring(0, 3) + DateTime.Now.ToString("yyyyMM") + id.Substring(id.Length - 2);       //kyc-year & month-uniqueno


                    SqlCommand cmd1 = new SqlCommand(@"INSERT INTO[dbo].[otp]
                ([mobile] ,[otp_gen],[status])
               VALUES('" + getmobno + "','" + getotp + "','" + 1 + "')", con);


                    //Save data on database

                    SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[kycdetail]
                       ([Kycid]
                       ,[Name]
                       ,[acoount_no]
                       ,[cust_no]
                       ,[mobail_no]
                       ,[accout_type]
                       ,[status])
                 VALUES
                       ('" + Kycid + "','" + getacchname + "','" + getaccno + "','" + getcustid + "','" + getmobno + "','  ','" + status + "')", con);

                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();


                    Session["Account_no"] = getaccno;
                    Session["Mob_no"] = getmobno;
                    Session["kycid"] = Kycid;
                    Session["cust_no"] = getcustid;

                    //Response.Redirect("enterotp.aspx");
                    //lbleror.Text = "Data submited succ";

                    con.Close();

                    //send otp start

                    string wurl = "https://app.helo.ai/vivasmpp/sms/submit";
                    string api = "372c1aa03a87638462dbb6653b6e6602";
                    string number = getmobno;
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

                    Response.Redirect("enterotp.aspx");
                }


            }

        }
    }
}