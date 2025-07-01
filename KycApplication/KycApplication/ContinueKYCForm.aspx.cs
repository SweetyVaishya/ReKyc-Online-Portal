using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace KycApplication
{
    public partial class ContinueKYCForm : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        string clientId;
        string panstatus;
        string aadharstatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (string.IsNullOrEmpty(Convert.ToString(Session["Account_no1"])))
                {
                    Response.Redirect("Default.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
                }


                string accountNo = Convert.ToString(Session["Account_no1"]);
                string kycId = Convert.ToString(Session["kycid"]);
           

                kycidNo.Text = kycId;

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    // Assuming GetFullNameFromPanApiData and GetPanCardNoFromTblOmtDetail 
                    // are methods that do not affect the state of the connection

                    //string fullname = GetFullNameFromPanApiData(con, kycId);
                    string pancardNo = GetPanCardNoFromTblOmtDetail(accountNo);

                    string PanName = GetPancardName(kycId);

                    string query = "SELECT * FROM kycdetail WHERE Kycid = @kycid";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@kycid", kycId);
                        con.Open(); // Open the connection here
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                AuthorizePan.SelectedValue = reader["AuthorizePan"].ToString();
                                AuthorizeAadhar.SelectedValue = reader["AuthorizeAadhar"].ToString();
                                pen_no.Text = reader["pancardno_HA"].ToString();
                                aadhar_no.Text = reader["Aadharcardno_HA"].ToString();
                                mob_no.Text = reader["mobail_no"].ToString();
                                emailid.Text = reader["Email_HA"].ToString();
                                address.Value = reader["CurrentAdd_HA"].ToString();
                                incomesource.SelectedValue = reader["IncomeSource_HA"].ToString();
                                employename.Text = reader["empbussname_HA"].ToString();
                                industrytype.Text = reader["worktype_HA"].ToString();
                                YearsOfServiceBusiness.Text = reader["YearsOfServiceBusinessHA"].ToString();
                                from.SelectedValue = reader["Incomefrom_HA"].ToString();
                                PrebPanNm.Text = reader["PancardFileNm"].ToString();
                                PrevAadharNm.Text = reader["AadharcardFileNm"].ToString();

                                bool isAadharAuthorizedNo = AuthorizeAadhar.SelectedValue == "No";
                                bool isPanAuthorizedNo = AuthorizePan.SelectedValue == "No";

                                if (!string.IsNullOrEmpty(pen_no.Text) )
                                {
                                    verified.Visible = true;
                                    pen_verify.Visible = false;
                                    panname.Text = PanName;
                                    pen_no.ReadOnly = true;
                                    
                                }
                                if ( !string.IsNullOrEmpty(aadhar_no.Text))
                                {
                                    
                                    aadhar_Verified.Visible = true;
                                    aadhar_verify.Visible = false;
                                    aadhar_no.ReadOnly = true;
                                }

                                if (!string.IsNullOrEmpty(PrevAadharNm.Text))
                                {
                                    documentid.Visible = false;
                                    AadharCard.Visible = false;
                                    confirmationmsg.Visible = true;
                                }
                                if (!string.IsNullOrEmpty(PrebPanNm.Text))
                                {
                                    documentid.Visible = false;
                                    PanCard.Visible = false;
                                    confirmationmsg.Visible = true;
                                }

                                else if (isAadharAuthorizedNo && isPanAuthorizedNo)
                                {
                                    documentid.Visible = false;
                                    confirmationmsg1.Visible = true;
                                }
                            }
                            con.Close(); // Close the connection after reading
                        }
                    }
                }
            }
        }

        private string GetPanCardNoFromTblOmtDetail(string accountNo)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT pancard FROM [TblOmtDetail] WHERE AccountNo = @accountNo", con))
                {
                    cmd.Parameters.AddWithValue("@accountNo", accountNo);
                    con.Open();
                    string result = cmd.ExecuteScalar() as string;
                    return result;
                }
            }
        }

        private string GetPancardName(string kycId)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT fullname FROM [PanApi_data] WHERE kyc_id = @kycid", con))
                {
                    cmd.Parameters.AddWithValue("@kycid", kycId);
                    con.Open();
                    string result = cmd.ExecuteScalar() as string;
                    return result;
                }
            }
        }

        //protected void pen_verify_Click(object sender, EventArgs e)
        //{
        //    string accountNo = Convert.ToString(Session["Account_no1"]);
        //    using (SqlConnection con = new SqlConnection(strcon))
        //    {
        //        string pancardNo = GetPanCardNoFromTblOmtDetail(accountNo);
        //        if (pancardNo == pen_no.Text)
        //        {
        //            try
        //            {
        //                string panCardNumber = pen_no.Text;
        //                string pattern = "[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}";

        //                if (string.IsNullOrWhiteSpace(pen_no.Text))
        //                {
        //                    lblmsg.Text = "Please Enter Pan Card No.!!";
        //                    pen_no.Focus();
        //                    return;
        //                }
        //                else if (!Regex.IsMatch(panCardNumber, pattern))
        //                {
        //                    lblmsg.Text = "Invalid PAN card number";
        //                    return;
        //                }
        //                else
        //                {
        //                    var data = new
        //                    {
        //                        id_number = pen_no.Text
        //                    };

        //                    var json = JsonConvert.SerializeObject(data);
        //                    var token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6ZmFsc2UsImlhdCI6MTY3ODY5NDQzOCwianRpIjoiMmI5YjA0YjAtMmU1ZS00NjhkLTg3YzYtZTdmZWY4YjFhZWFiIiwidHlwZSI6ImFjY2VzcyIsImlkZW50aXR5IjoiZGV2LmNoaWNpbmZvdGVjaEBzdXJlcGFzcy5pbyIsIm5iZiI6MTY3ODY5NDQzOCwiZXhwIjoxOTk0MDU0NDM4LCJ1c2VyX2NsYWltcyI6eyJzY29wZXMiOlsidXNlciJdfX0._bKp9D4CltjpwqFkZo0t2YZFTry6e3aRq9sdk8PDYYc";

        //                    var panReq = "api/v1/pan/pan";
        //                    var reqUrl = "https://kyc-api.surepass.io/";

        //                    var url = reqUrl + panReq;

        //                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        //                    httpWebRequest.ContentType = "application/json";
        //                    httpWebRequest.Method = "POST";
        //                    httpWebRequest.Headers.Add("Authorization", token);

        //                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //                    {
        //                        streamWriter.Write(json);
        //                        streamWriter.Flush();
        //                        streamWriter.Close();
        //                    }

        //                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //                    {
        //                        var responseText = streamReader.ReadToEnd();

        //                        var responseObject = JObject.Parse(responseText);

        //                        var statuscode = (string)responseObject["status_code"] ?? string.Empty;
        //                        var successresult = (string)responseObject["success"] ?? string.Empty;
        //                        var messageresult = (string)responseObject["message"] ?? string.Empty;
        //                        var msgcode = (string)responseObject["message_code"] ?? string.Empty;

        //                        var dataObject = JObject.Parse(responseObject["data"].ToString());
        //                        var clientId = (string)dataObject["client_id"] ?? string.Empty;
        //                        var panNumber = (string)dataObject["pan_number"] ?? string.Empty;
        //                        var fullName = (string)dataObject["full_name"] ?? string.Empty;
        //                        var category = (string)dataObject["category"] ?? string.Empty;

        //                        panstatus = (string)responseObject["status_code"] ?? string.Empty;

        //                        string kycId = Convert.ToString(Session["kycid"]);


        //                            con.Open();
        //                            string query = @"INSERT INTO [dbo].[PanApi_data]
        //                            ([kyc_id], [fullname], [Pan_number], [client_id], [category], [status_code], [success_result], [msg_result], [msg_code])
        //                            VALUES (@kycid, @fullname, @panNumber, @clientId, @category, @statusCode, @successResult, @messageResult, @msgCode)";

        //                            using (SqlCommand cmd = new SqlCommand(query, con))
        //                            {
        //                                cmd.Parameters.AddWithValue("@kycid", kycId);
        //                                cmd.Parameters.AddWithValue("@fullname", fullName);
        //                                cmd.Parameters.AddWithValue("@panNumber", panNumber);
        //                                cmd.Parameters.AddWithValue("@clientId", clientId);
        //                                cmd.Parameters.AddWithValue("@category", category);
        //                                cmd.Parameters.AddWithValue("@statusCode", statuscode);
        //                                cmd.Parameters.AddWithValue("@successResult", successresult);
        //                                cmd.Parameters.AddWithValue("@messageResult", messageresult);
        //                                cmd.Parameters.AddWithValue("@msgCode", msgcode);

        //                                cmd.ExecuteNonQuery();

        //                                using (SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET [pancardno_HA]='" + panNumber + "',[pancardverify_HA] = 'verified' WHERE Kycid = @kycid", con))
        //                                {
        //                                    cmd1.Parameters.AddWithValue("@kycid", kycId);
        //                                    cmd1.ExecuteNonQuery();
        //                                }
        //                            }


        //                        pen_verify.Visible = false;
        //                        verified.Visible = true;
        //                        panname.Text = fullName;
        //                        pen_no.ReadOnly = true;

        //                    }
        //                }
        //            }
        //            catch (WebException ex)
        //            {
        //                lblpanverify.Text = "Invalid PAN card number// catching";
        //            }
        //        }
        //        else
        //        {
        //            lblmsg.Text = "The entered Pan Card number is mismatched, please check and re-enter.";
        //        }
        //    }
        //}

        protected void pen_verify_Click(object sender, EventArgs e)
        {
            //string Accountno = "048011100000426";
            string Accountno = Convert.ToString(Session["Account_no1"]);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand pancount = new SqlCommand(@"select count(*) FROM [TblOmtDetail] where AccountNo = '" + Accountno + "' and (pancard IS  NULL or   pancard!='')", con);


            SqlCommand pancmd = new SqlCommand(@"select pancard FROM [TblOmtDetail] where AccountNo = '" + Accountno + "'", con);

            con.Open();
            object result = pancmd.ExecuteScalar();
            string pancardno = result == DBNull.Value ? null : (string)result;
            int pancardnoCount = Convert.ToInt32(pancount.ExecuteScalar());
            con.Close();

            string panCardNumber = pen_no.Text;
            string pattern = "[a-z.A-Z]{5}[0-9]{4}[a-z.A-Z]{1}";

            if (pancardnoCount == 1)
            {
                if (pen_no.Text == "")
                {
                    lblmsg.Text = "Plese Enter Pan Card No.!!";
                    pen_no.Focus();
                }
                else if (!Regex.IsMatch(panCardNumber, pattern))
                {
                    lblmsg.Text = "Invalid PAN card number";
                }
                else if (pancardno == pen_no.Text)
                {
                    // lblmsg.Text = "pan card veryfy plz procced api pan card";
                    try
                    {
                        if (pen_no.Text == "")
                        {
                            lblmsg.Text = "Plese Enter Pan Card No.!!";
                            pen_no.Focus();
                        }
                        else if (!Regex.IsMatch(panCardNumber, pattern))
                        {
                            lblmsg.Text = "Invalid PAN card number";
                        }
                        else
                        {
                            var data = new
                            {
                                id_number = pen_no.Text
                            };

                            var json = JsonConvert.SerializeObject(data);
                            var token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6ZmFsc2UsImlhdCI6MTY3ODY5NDQzOCwianRpIjoiMmI5YjA0YjAtMmU1ZS00NjhkLTg3YzYtZTdmZWY4YjFhZWFiIiwidHlwZSI6ImFjY2VzcyIsImlkZW50aXR5IjoiZGV2LmNoaWNpbmZvdGVjaEBzdXJlcGFzcy5pbyIsIm5iZiI6MTY3ODY5NDQzOCwiZXhwIjoxOTk0MDU0NDM4LCJ1c2VyX2NsYWltcyI6eyJzY29wZXMiOlsidXNlciJdfX0._bKp9D4CltjpwqFkZo0t2YZFTry6e3aRq9sdk8PDYYc";

                            var panReq = "api/v1/pan/pan";
                            var reqUrl = "https://kyc-api.surepass.io/";

                            var url = reqUrl + panReq;

                            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Method = "POST";
                            httpWebRequest.Headers.Add("Authorization", token);

                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                streamWriter.Write(json);
                                streamWriter.Flush();
                                streamWriter.Close();
                            }

                            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                var responseText = streamReader.ReadToEnd();

                                var responseObject = JObject.Parse(responseText);

                                var statuscode = (string)responseObject["status_code"];
                                var successresult = (string)responseObject["success"];
                                var messageresult = (string)responseObject["message"];
                                var msgcode = (string)responseObject["message_code"];

                                var dataObject = JObject.Parse(responseObject["data"].ToString());
                                var clientId = (string)dataObject["client_id"];
                                var panNumber = (string)dataObject["pan_number"];
                                var fullName = (string)dataObject["full_name"];
                                var category = (string)dataObject["category"];

                                panstatus = (string)responseObject["status_code"];

                                if (statuscode == "200")
                                {
                                    string acc_no = Convert.ToString(Session["Account_no"]);
                                    string kycid = Convert.ToString(Session["kycid"]);

                                    con.Open();
                                    SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[PanApi_data]
                                ([kyc_id]
                                ,[fullname]
                                ,[Pan_number]
                                ,[client_id]
                                ,[category]
                                ,[status_code]
                                ,[success_result]
                                ,[msg_result]
                                ,[msg_code])
                          VALUES
                ('" + kycid + "','" + fullName + "','" + panNumber + "','" + clientId + "','" + category + "','" + statuscode + "','" + successresult + "','" + messageresult + "','" + msgcode + "')", con);



                                    SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET [pancardno_HA]='" + panNumber + "',[pancardverify_HA] ='verified'  WHERE Kycid='" + kycid + "' ", con);

                                    cmd1.ExecuteNonQuery();

                                    cmd.ExecuteNonQuery();

                                    pen_verify.Visible = false;
                                    verified.Visible = true;
                                    panname.Text = fullName;
                                    con.Close();

                                }

                                else
                                {
                                    lblpanverify.Text = "Invalid PAN card number";
                                }


                            }


                        }

                    }
                    catch (WebException ex)
                    {
                        lblpanverify.Text = "Invalid PAN card number";
                    }


                }
                else
                {

                    lblmsg.Text = "The entered Pan Card number is missmatched please check and re-enter";
                }
            }
            else if (pancardnoCount == 0)
            {
                if (pen_no.Text == "")
                {
                    lblmsg.Text = "Plese Enter Pan Card No.!!";
                    pen_no.Focus();

                }
                else if (!Regex.IsMatch(panCardNumber, pattern))
                {
                    lblmsg.Text = "Invalid PAN card number";
                }
                else
                {
                    lblmsg.Text = "Your PAN card was not available in the Bank's existing records. We have added your newly verified PAN card to your account.";
                    lblmsg.ForeColor = System.Drawing.Color.DeepSkyBlue;
                }

                try
                {

                    if (pen_no.Text == "")
                    {
                        lblmsg.Text = "Plese Enter Pan Card No.!!";
                        pen_no.Focus();
                    }
                    else if (!Regex.IsMatch(panCardNumber, pattern))
                    {
                        lblmsg.Text = "Invalid PAN card number";
                    }
                    else
                    {
                        var data = new
                        {
                            id_number = pen_no.Text
                        };

                        var json = JsonConvert.SerializeObject(data);
                        var token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6ZmFsc2UsImlhdCI6MTY3ODY5NDQzOCwianRpIjoiMmI5YjA0YjAtMmU1ZS00NjhkLTg3YzYtZTdmZWY4YjFhZWFiIiwidHlwZSI6ImFjY2VzcyIsImlkZW50aXR5IjoiZGV2LmNoaWNpbmZvdGVjaEBzdXJlcGFzcy5pbyIsIm5iZiI6MTY3ODY5NDQzOCwiZXhwIjoxOTk0MDU0NDM4LCJ1c2VyX2NsYWltcyI6eyJzY29wZXMiOlsidXNlciJdfX0._bKp9D4CltjpwqFkZo0t2YZFTry6e3aRq9sdk8PDYYc";

                        var panReq = "api/v1/pan/pan";
                        var reqUrl = "https://kyc-api.surepass.io/";

                        var url = reqUrl + panReq;

                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        httpWebRequest.Headers.Add("Authorization", token);

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            streamWriter.Write(json);
                            streamWriter.Flush();
                            streamWriter.Close();
                        }

                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var responseText = streamReader.ReadToEnd();

                            var responseObject = JObject.Parse(responseText);

                            var statuscode = (string)responseObject["status_code"];
                            var successresult = (string)responseObject["success"];
                            var messageresult = (string)responseObject["message"];
                            var msgcode = (string)responseObject["message_code"];

                            var dataObject = JObject.Parse(responseObject["data"].ToString());
                            var clientId = (string)dataObject["client_id"];
                            var panNumber = (string)dataObject["pan_number"];
                            var fullName = (string)dataObject["full_name"];
                            var category = (string)dataObject["category"];


                            panstatus = (string)responseObject["status_code"];


                            if (statuscode == "200")
                            {
                                string acc_no = Convert.ToString(Session["Account_no"]);
                                string kycid = Convert.ToString(Session["kycid"]);

                                con.Open();
                                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[PanApi_data]
                                ([kyc_id]
                                ,[fullname]
                                ,[Pan_number]
                                ,[client_id]
                                ,[category]
                                ,[status_code]
                                ,[success_result]
                                ,[msg_result]
                                ,[msg_code])
                          VALUES
                ('" + kycid + "','" + fullName + "','" + panNumber + "','" + clientId + "','" + category + "','" + statuscode + "','" + successresult + "','" + messageresult + "','" + msgcode + "')", con);



                                SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET [pancardno_HA]='" + panNumber + "',[pancardverify_HA] ='verified'  WHERE Kycid='" + kycid + "' ", con);


                                cmd1.ExecuteNonQuery();

                                cmd.ExecuteNonQuery();

                                pen_verify.Visible = false;
                                verified.Visible = true;
                                panname.Text = fullName;

                                con.Close();

                            }

                            else
                            {
                                lblpanverify.Text = "Invalid PAN card number";
                            }


                        }


                    }

                }
                catch (WebException ex)
                {
                    using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string errorResponse = reader.ReadToEnd();
                        lblmsg.Text = "Error during PAN card verification: " + ex.Message + "<br>" + errorResponse;
                    }
                }
            }
            else
            {
                lblmsg.Text = "";
            }

        }

        protected void aadhar_verify_Click(object sender, EventArgs e)
        {
            if (aadhar_no.Text == "")
            {
                lblmsg.Text = "Please Enter Aadhar Card No.!!";
                aadhar_no.Focus();
            }
            else
            {
               
                var data = new
                {
                    id_number = aadhar_no.Text
                };

                string url = "https://kyc-api.surepass.io/api/v1/aadhaar-v2/generate-otp";
                string token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6ZmFsc2UsImlhdCI6MTY3ODY5NDQzOCwianRpIjoiMmI5YjA0YjAtMmU1ZS00NjhkLTg3YzYtZTdmZWY4YjFhZWFiIiwidHlwZSI6ImFjY2VzcyIsImlkZW50aXR5IjoiZGV2LmNoaWNpbmZvdGVjaEBzdXJlcGFzcy5pbyIsIm5iZiI6MTY3ODY5NDQzOCwiZXhwIjoxOTk0MDU0NDM4LCJ1c2VyX2NsYWltcyI6eyJzY29wZXMiOlsidXNlciJdfX0._bKp9D4CltjpwqFkZo0t2YZFTry6e3aRq9sdk8PDYYc";

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                // Send request
                var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", token);
                request.ContentLength = json.Length;

                using (var streamWriter = new System.IO.StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                string responseContent = null;
                using (var response = (System.Net.HttpWebResponse)request.GetResponse())
                {
                    using (var streamReader = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        responseContent = streamReader.ReadToEnd();
                    }
                }

                var responseObject = JObject.Parse(responseContent);

                var status_code = (string)responseObject["status_code"];
                var message = (string)responseObject["message"];
                var success = (string)responseObject["success"];

                var dataObject = JObject.Parse(responseObject["data"].ToString());
                var otp_sent = (string)dataObject["otp_sent"];
                var valid_aadhaar = (string)dataObject["valid_aadhaar"];
                var status = (string)dataObject["status"];

                string client_id = (string)dataObject["client_id"];
                Session["client_id"] = client_id; // set the session variable


                //----------dend otp request---------stop--------//
                string textadharno = aadhar_no.Text;
                getadharnotext.Text = textadharno.Substring(textadharno.Length - 4);
                ConsentLetter.Visible = true;
                aadhar_verify.Visible = false;
                enterotp.Visible = true;
                submitotp.Visible = true;
              
            }
        }

        protected void submitotp_Click(object sender, EventArgs e)
        {
            try
            {
                if (enterotp.Text == "")
                {
                    lblmsg.Text = "Please enter OTP...";
                }
                else
                {


                    string id = Session["client_id"] as string; // get the value from the session variable


                    string url = "https://kyc-api.surepass.io/api/v1/aadhaar-v2/submit-otp";
                    string token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6ZmFsc2UsImlhdCI6MTY3ODY5NDQzOCwianRpIjoiMmI5YjA0YjAtMmU1ZS00NjhkLTg3YzYtZTdmZWY4YjFhZWFiIiwidHlwZSI6ImFjY2VzcyIsImlkZW50aXR5IjoiZGV2LmNoaWNpbmZvdGVjaEBzdXJlcGFzcy5pbyIsIm5iZiI6MTY3ODY5NDQzOCwiZXhwIjoxOTk0MDU0NDM4LCJ1c2VyX2NsYWltcyI6eyJzY29wZXMiOlsidXNlciJdfX0._bKp9D4CltjpwqFkZo0t2YZFTry6e3aRq9sdk8PDYYc";

                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.Headers.Add("Authorization", token);

                    var data = new
                    {
                        client_id = id,
                        otp = enterotp.Text
                    };
                    string json = JsonConvert.SerializeObject(data);

                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                    var httpResponse = (HttpWebResponse)request.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        //  Response.Write(result);
                        //otpmsg.Text = result;

                        var responseObject = JObject.Parse(result);

                        //Label10.Text = result;

                        var status_code = (string)responseObject["status_code"];
                        var message = (string)responseObject["message"];
                        var success = (string)responseObject["success"];

                        var dataObject = JObject.Parse(responseObject["data"].ToString());

                        var gender = (string)dataObject["gender"];
                        var aadhaar_number = (string)dataObject["aadhaar_number"];
                        var dob = (string)dataObject["dob"];
                        var client_id = (string)dataObject["client_id"];
                        var full_name = (string)dataObject["full_name"];
                        var zip = (string)dataObject["zip"];
                        var care_of = (string)dataObject["care_of"];
                        var profile_image = (string)dataObject["profile_image"];
                        var raw_xml = (string)dataObject["raw_xml"];
                        var zip_data = (string)dataObject["zip_data"];
                        var share_code = (string)dataObject["share_code"];

                        var addressObject = JObject.Parse(dataObject["address"].ToString());

                        var loc = (string)addressObject["loc"];
                        var country = (string)addressObject["country"];
                        var house = (string)addressObject["house"];
                        var subdist = (string)addressObject["subdist"];
                        var vtc = (string)addressObject["vtc"];
                        var po = (string)addressObject["po"];
                        var state = (string)addressObject["state"];
                        var street = (string)addressObject["street"];
                        var dist = (string)addressObject["dist"];


                        var Fulladdress = $"{house}, {street}, {loc}, {subdist}, {vtc}, {po}, {dist}, {state}, {country},{zip}.";


                        aadharstatus = (string)responseObject["status_code"];

                        //----------submit otp request---------stop--------//

                        if (status_code == "200")
                        {

                            string acc_no = Convert.ToString(Session["Account_no"]);

                            string kycid = Convert.ToString(Session["kycid"]);

                            SqlConnection con = new SqlConnection(strcon);
                            con.Open();

                            string textadharno = aadhar_no.Text;
                            string getaadharno = textadharno.Substring(textadharno.Length - 4);

                            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[AadharApi_data]
                               ([kycid]
                               ,[fullname]
                               ,[care_of]
                               ,[aadhar_card]
                               ,[client_id]
                               ,[DOB]
                               ,[address]
                               ,[status_code]
                               ,[message]
                               ,[success]
                               ,[ConsentLetterHA])
                         VALUES
                       ('" + kycid + "','" + full_name + "','" + care_of + "','" + aadhaar_number + "','" + client_id + "','" + dob + "','" + Fulladdress + "','" + status_code + "','" + message + "','" + success + "','I, the holder of Aadhaar No.xxxx xxxx '+'" + getaadharno + "'+', hereby give my consent to Abhyudaya Coop.Bank Ltd for OTP based online Aadhaar based authentication for Re - KYC purpose.Abhyudaya Coop.Bank Ltd.has informed me that my identity information would only be used for Re - KYC purpose.')", con);

                            SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET [Aadharcardno_HA]='" + aadhaar_number + "', [Aadharcardverify_HA] ='verified'  WHERE Kycid='" + kycid + "' ", con);

                            cmd1.ExecuteNonQuery();

                            cmd.ExecuteNonQuery();

                            aadhar_Verified.Visible = true;
                            enterotp.Visible = false;
                            submitotp.Visible = false;
                            ConsentLetter.Visible = false;
                            aadhar_no.ReadOnly = true;
                        }
                        else
                        {
                            lblAadharverify.Text = "Invalid Aadhar card number";
                        }

                    }
                }
            }
            catch (WebException ex)
            {
                lblpanverify.Text = "Sorry, there may be an issue at the Aadhar portal which will be addressed soon. ";


            }
        }


        protected void submit_Click(object sender, EventArgs e)
        {
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };


            string panCardNumber = pen_no.Text;
            string pattern = "[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}";

            SqlConnection con = new SqlConnection(strcon);
            string acc_no = Convert.ToString(Session["Account_no"]);
            string kycid = Convert.ToString(Session["kycid"]);



            if (string.IsNullOrWhiteSpace(pen_no.Text))
            {
                lblmsg.Text = "Please enter PAN card No.!!";
                pen_no.Focus();
            }
            else if (pen_verify.Visible == true)
            {
                lblmsg.Text = "Please verify PAN card No.!!";
            }
            else if (string.IsNullOrWhiteSpace(aadhar_no.Text))
            {
                lblmsg.Text = "Please enter Aadhar card No.!!";
                aadhar_no.Focus();
            }
            else if (!Regex.IsMatch(aadhar_no.Text.Trim(), "^[0-9]+$"))
            {
                lblmsg.Text = "Please enter valid Aadhar card No.!!";
                aadhar_no.Focus();
            }
            else if (aadhar_verify.Visible == true)
            {
                lblmsg.Text = "Please verify Aadhar card No.!!";
            }
            else if (string.IsNullOrWhiteSpace(mob_no.Text))
            {
                lblmsg.Text = "Please enter mobile No.!!";
                mob_no.Focus();
            }
            else if (!Regex.IsMatch(mob_no.Text.Trim(), "^[0-9]+$"))
            {
                lblmsg.Text = "Please enter valid mobile No.!!";
                mob_no.Focus();
            }
            else if (string.IsNullOrWhiteSpace(emailid.Text))
            {
                lblmsg.Text = "Please enter email address !!";
                emailid.Focus();
            }
            else if (!Regex.IsMatch(emailid.Text.Trim(), @"^([\w\.\-]+)@([\w\-]+)((\.([a-zA-Z]){2,7})+)$"))
            {
                lblmsg.Text = "Please enter valid email address !!";
                emailid.Focus();
            }

            else if (string.IsNullOrWhiteSpace(address.InnerHtml))
            {
                lblmsg.Text = "Please enter address.!!";
                address.Focus();
            }

            else if (incomesource.SelectedValue == "")
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
            else if (string.IsNullOrEmpty(AuthorizeAadhar.SelectedValue))
            {
                lblmsg.Text = "Please select Aadhar authorization.!!";
                AuthorizeAadhar.Focus();
            }
            else if (string.IsNullOrEmpty(AuthorizePan.SelectedValue))
            {
                lblmsg.Text = "Please select PAN authorization.!!";
                AuthorizePan.Focus();
            }
            else
            {
                string panFileName;
                string aadharFileName;

                bool isAadharAuthorized = AuthorizeAadhar.SelectedValue == "Yes";
                bool isPanAuthorized = AuthorizePan.SelectedValue == "Yes";

                string kycId = Convert.ToString(Session["kycid"]);

                SqlCommand countaadhar = new SqlCommand(@"select count(AuthorizeAadhar) from kycdetail where kycid = '"+kycId+"'", con);
                SqlCommand countpan= new SqlCommand(@"select count(AuthorizePan) from kycdetail where kycid = '" + kycId + "'", con);


                SqlCommand Doccount = new SqlCommand(@"SELECT COUNT(*) FROM[kycdetail] WHERE Kycid = '" + kycId + "' AND AuthorizeAadhar IS NOT NULL AND AuthorizePan IS NOT NULL", con);

                string Bothdoccount = Convert.ToString(Doccount);
                string adharcount = Convert.ToString(countaadhar);
                string pancount = Convert.ToString(countpan);

                if (Bothdoccount == "0")
                {
                     panFileName = Path.GetFileName(PanCard.PostedFile.FileName);
                     aadharFileName = Path.GetFileName(AadharCard.PostedFile.FileName);
                }
                else
                {
                     panFileName = PrebPanNm.Text;
                     aadharFileName = PrevAadharNm.Text;
                }
               

                if (isAadharAuthorized && !AadharCard.HasFile && adharcount=="0")
                {
                    lblmsg.Text = "Please upload Aadhar Card document!!";
                    AadharCard.Focus();
                }
                else if (isAadharAuthorized && !ValidateFileExtension(aadharFileName, allowedExtensions) && adharcount == "0")
                {
                    lblmsg.Text = "Only image files (.jpg, .jpeg, .png, .gif) are allowed for Aadhar Card.";
                    AadharCard.Focus();
                }
                else if (isPanAuthorized && !PanCard.HasFile && pancount == "0")
                {
                    lblmsg.Text = "Please upload Pan Card document!!";
                    PanCard.Focus();
                }
                else if (isPanAuthorized && !ValidateFileExtension(panFileName, allowedExtensions) && pancount == "0")
                {
                    lblmsg.Text = "Only image files (.jpg, .jpeg, .png, .gif) are allowed for Pan Card.";
                    PanCard.Focus();
                }

                else if (!verified.Visible)
                {
                    lblmsg.Text = "Please verify PAN card No.!!";
                }
                else if (!aadhar_Verified.Visible)
                {
                    lblmsg.Text = "Please verify Aadhar card No.!!";
                }
                else
                {


                    //string Address = address.Value;
                    string textadharno = aadhar_no.Text;
                    string getaadharno = textadharno.Substring(textadharno.Length - 4);

                    //SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET [accout_type]="individual", [pancardno_HA] ='" + pen_no.Text + "'  ,[pancardverify_HA] ='verified' ,[Aadharcardno_HA] ='" + aadhar_no.Text + "' ,[Alternativmob_HA] = '" + mob_no.Text + "',[Email_HA] ='" + emailid.Text + "' ,[CurrentAdd_HA] ='" + address.InnerText + "',[ConsentLetterHA] ='I, the holder of Aadhaar No.xxxx xxxx '+'" + getaadharno + "'+', hereby give my consent to Abhyudaya Coop.Bank Ltd for OTP based online Aadhaar based authentication for Re - KYC purpose.Abhyudaya Coop.Bank Ltd.has informed me that my identity information would only be used for Re - KYC purpose.',IncomeSource_HA='" + incomesource.SelectedValue + "' ,empbussname_HA= '" + employename.Text + "',worktype_HA= '" + industrytype.Text + "',Incomefrom_HA='" + from.SelectedValue + "',YearsOfServiceBusinessHA='" + YearsOfServiceBusiness.Text + "',AuthorizationTitle='" + AuthorizationTiltle.Text + "',AuthorizeAadhar='" + AuthorizeAadhar.SelectedValue + "',PancardFileNm='" + panFileName + "',AadharcardFileNm='" + aadharFileName + "'  where Kycid='" + kycid + "'", con);

                    SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET [accout_type] = @accountType, [pancardno_HA] = @pancardNo, [pancardverify_HA] = 'verified', [Aadharcardno_HA] = @aadharNo, [Alternativmob_HA] = @mobileNo, [Email_HA] = @email, [CurrentAdd_HA] = @currentAddress, [ConsentLetterHA] = 'I, the holder of Aadhaar No. xxxx xxxx ' + @aadharNo + ', hereby give my consent to Abhyudaya Coop.Bank Ltd for OTP based online Aadhaar based authentication for Re - KYC purpose.Abhyudaya Coop.Bank Ltd.has informed me that my identity information would only be used for Re - KYC purpose.', IncomeSource_HA = @incomeSource, empbussname_HA = @employerName, worktype_HA = @industryType, Incomefrom_HA = @incomeFrom, YearsOfServiceBusinessHA = @yearsOfService, AuthorizationTitle = @authorizationTitle, AuthorizeAadhar = @authorizeAadhar,AuthorizationTitlePan = @AuthorizationTitlePan, AuthorizePan = @AuthorizePan, PancardFileNm = @pancardFileName, AadharcardFileNm = @aadharcardFileName WHERE Kycid = @kycid", con);

                    // Add parameters
                    cmd.Parameters.AddWithValue("@accountType", "individual");
                    cmd.Parameters.AddWithValue("@pancardNo", pen_no.Text);
                    cmd.Parameters.AddWithValue("@aadharNo", aadhar_no.Text);
                    cmd.Parameters.AddWithValue("@mobileNo", mob_no.Text);
                    cmd.Parameters.AddWithValue("@email", emailid.Text);
                    //cmd.Parameters.AddWithValue("@currentAddress", address.Value);
                    cmd.Parameters.AddWithValue("@currentAddress", address.InnerHtml);
                    cmd.Parameters.AddWithValue("@incomeSource", incomesource.SelectedValue);
                    cmd.Parameters.AddWithValue("@employerName", employename.Text);
                    cmd.Parameters.AddWithValue("@industryType", industrytype.Text);
                    cmd.Parameters.AddWithValue("@incomeFrom", from.SelectedValue);
                    cmd.Parameters.AddWithValue("@yearsOfService", YearsOfServiceBusiness.Text);
                    cmd.Parameters.AddWithValue("@authorizationTitle", AuthorizationTiltle.Text);
                    cmd.Parameters.AddWithValue("@authorizeAadhar", AuthorizeAadhar.SelectedValue);
                    cmd.Parameters.AddWithValue("@AuthorizationTitlePan", AuthorizationTiltlePan.Text);
                    cmd.Parameters.AddWithValue("@AuthorizePan", AuthorizePan.SelectedValue);
                    cmd.Parameters.AddWithValue("@pancardFileName", panFileName);
                    cmd.Parameters.AddWithValue("@aadharcardFileName", aadharFileName);
                    cmd.Parameters.AddWithValue("@kycid", kycid);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    SqlCommand getname = new SqlCommand("select [Name] from [kycdetail] where [acoount_no] = '" + acc_no + "'", con);
                    string Name = (string)getname.ExecuteScalar();
                    getname.ExecuteNonQuery();

                    string email = emailid.Text;


                    Session["name"] = Name;
                    Session["kycid"] = kycid;
                    Session["Account_no1"] = acc_no;

                    //if (!string.IsNullOrEmpty(PrebPanNm.Text) && !string.IsNullOrEmpty(PrevAadharNm.Text))
                    if (Bothdoccount!="0")
                    {
                        // do not run email email alreay sent 
                    }
                    else
                    {
                        //  SendEmail(Name, kycid, email, panFileName, aadharFileName, fileData);
                        var panMemoryStream = new MemoryStream();
                        PanCard.PostedFile.InputStream.CopyTo(panMemoryStream);
                        byte[] panFileData = panMemoryStream.ToArray();


                        var aadharMemoryStream = new MemoryStream();
                        AadharCard.PostedFile.InputStream.CopyTo(aadharMemoryStream);
                        byte[] aadharFileData = aadharMemoryStream.ToArray();


                        SendEmail(Name, kycid, email, panFileName, aadharFileName, panFileData, aadharFileData);
                    }



                    Response.Redirect("ContAcknowledgement.aspx");
                }


            }
        }

        private bool ValidateFileExtension(string fileName, string[] allowedExtensions)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            return Array.Exists(allowedExtensions, ext => ext == extension);
        }

        private void SendEmail(string Name, string kycID, string email, string panFileName, string aadharFileName, byte[] panFileData, byte[] aadharFileData)
        {
            //string bankEmail = "roshan@chicinfotech.com";

            string bankEmail = "kyc@abhyudayabank.net";

            string subject = "New KYC Submission";
            string currentDate = DateTime.Now.ToString("MMMM dd, yyyy");

            string body = $@"
<html>
<body style='font-family: Century Gothic, Arial, sans-serif; background-color: #f4f4f4; padding: 20px;'>
    <div style='max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 10px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); overflow: hidden;'>
        <div style='background-color: #ffe600; padding: 20px; '>
            <img src='https://www.abhyudayabank.co.in/images/logo.png' alt='logo' style='max-width: 150px;'/>
        </div>
        <div style='padding: 30px;'>
            <h2 style='color: #004080; text-align: center; margin-bottom: 20px;'>New KYC Submission</h2>
            <p style='margin: 0 0 10px 10px;'><strong>Date:</strong> {currentDate}</p>
            <p style='margin: 0 0 10px 10px;'><strong>Name:</strong> {Name}</p>
            <p style='margin: 0 0 10px 10px;'><strong>KYC ID:</strong> {kycID}</p>
            <p style='margin: 0 0 10px 10px;'><strong>Email ID:</strong>{email} </p>
        </div>
        <div style='padding: 15px; background-color: #f9f9f9; text-align: center; border-top: 1px solid #dddddd;'>
            <p style='font-size: 12px; color: black;'>Please do not reply to this email. For further assistance, contact support.</p>
        </div>
    </div>
</body>
</html>";

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["SmtpEmail"]);
            mailMessage.To.Add(bankEmail);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            // Attach PAN and Aadhar files separately
            MemoryStream panAttachmentStream = new MemoryStream(panFileData);
            MemoryStream aadharAttachmentStream = new MemoryStream(aadharFileData);
            Attachment panAttachment = new Attachment(panAttachmentStream, panFileName);
            Attachment aadharAttachment = new Attachment(aadharAttachmentStream, aadharFileName);
            mailMessage.Attachments.Add(panAttachment);
            mailMessage.Attachments.Add(aadharAttachment);

            SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"]);
            smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
            smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SmtpEmail"], ConfigurationManager.AppSettings["SmtpPassword"]);
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                panAttachmentStream.Close();
                aadharAttachmentStream.Close();
            }
        }

        

        protected void pen_no_TextChanged1(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            pen_no.Text = textBox.Text.ToUpper();
        }

     
    }
}
