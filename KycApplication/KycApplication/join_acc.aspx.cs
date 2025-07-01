using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KycApplication
{
    public partial class join_acc : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        string clientId;
        string aadharstatusA;
        string aadharstatusB;
        string PanstatusA;
        string PanstatusB;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["Account_no"])))
            {
                Response.Redirect("Default.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }

            string Name = Convert.ToString(Session["name"]);

            
        }


        //Pan card  Halder A start
        protected void panverifyA_Click(object sender, EventArgs e)
        {

            try
            {
                string panCardNumberA = pannoA.Text;
               
                string pattern = "[a-z.A-Z]{5}[0-9]{4}[a-z.A-Z]{1}";

                //--------pan data validation api start--------------------
                SqlConnection con = new SqlConnection(strcon);

                if (pannoA.Text == "")
                {

                    lblmsg.Text = "Plese Enter Pan Card No. A/C Holder A!!";
                    pannoA.Focus();
                }
                else if (!Regex.IsMatch(panCardNumberA, pattern))
                {
                    lblmsg.Text = "Invalid PAN card number";
                }
                else
                {
                    var data = new
                    {
                        id_number = pannoA.Text
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

                        //lblpanverify.Text = "pan card valideted ";
                        //Label2.Text = msgcode;
                        //Label3.Text = clientId;
                        //Label4.Text = panNumber;
                        //Label5.Text = fullName;
                        //Label7.Text = category;

                        PanstatusA = (string)responseObject["status_code"];


                        if (statuscode == "200")
                        {
                            string acc_no = Convert.ToString(Session["Account_no"]);

                            string kycid = Convert.ToString(Session["kycid"]);


                            //SqlCommand kycid = new SqlCommand(@"select Kycid  FROM [dbo].[kycdetail] where acoount_no='" + acc_no + "'", con);
                           
                            //string getkycid = (string)kycid.ExecuteScalar();

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

                            SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET  [pancardverify_HA] = 'verified'  WHERE Kycid='" + kycid + "' ", con);
                            cmd1.ExecuteNonQuery();


                            cmd.ExecuteNonQuery();
                            //lblpanverify.Text = "pan card valideted....!";
                            panverifyA.Visible = false;
                            panverifiedA.Visible = true;
                            panname1.Text = fullName;
                            con.Close();
                        }
                        else
                        {
                            lblpanverify.Text = "Invalid Pan card number";
                        }
                    }
                }
                //--------pan data validation api stop --------------------
            }
            catch (WebException ex)
            {
                lblpanverify.Text = "Invalid PAN card number";
            }
        }

        //Pan card  Halder A stop

        //Pan card  Halder B start
        protected void panverifyB_Click(object sender, EventArgs e)
        {
            try
            {
                string panCardNumberB = pannoB.Text;
            //string pattern = "[A-Z]{5}[0-9]{4}[A-Z]{1}";
            string pattern = "[a-z.A-Z]{5}[0-9]{4}[a-z.A-Z]{1}";

            //--------pan data validation api start--------------------
            SqlConnection con = new SqlConnection(strcon);

            if (pannoB.Text == "")
            {
                lblmsg.Text = "Plese Enter Pan Card No. A/C Holder B!!";
                pannoB.Focus();
            }
            else if (!Regex.IsMatch(panCardNumberB, pattern))
            {
                lblmsg.Text = "Invalid PAN card number";
            }
            else
            {
                var data = new
                {
                    id_number = pannoB.Text
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

                    PanstatusB = (string)responseObject["status_code"];

                    if (statuscode == "200")
                    {

                        string acc_no = Convert.ToString(Session["Account_no"]);
                        string kycid = Convert.ToString(Session["kycid"]);

                            con.Open();

                            //SqlCommand kycid = new SqlCommand(@"select Kycid  FROM [dbo].[kycdetail] where acoount_no='" + acc_no + "'", con);
                            // string getkycid = (string)kycid.ExecuteScalar();

                        SqlCommand cmd = new SqlCommand(@"UPDATE[dbo].[PanApi_data]
                     SET [fullname2] = '" + fullName + "',[Pan_number2] = '" + panNumber + "',[client_id2] = '" + clientId + "',[category2] = '" + category + "',[status_code2] ='" + statuscode + "',[success_result2] ='" + successresult + "' ,[msg_result2] ='" + messageresult + "' ,[msg_code2] ='" + msgcode + "' WHERE kyc_id = '" + kycid + "'", con);


                        SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET   [pancardverify_HB] = 'verified' WHERE Kycid='" + kycid + "' ", con);
                            cmd1.ExecuteNonQuery();

                        cmd.ExecuteNonQuery();
                        //lblpanno2B.Text = "pan card validated....!";

                        panverifyB.Visible = false;
                        panverifiedB.Visible = true;
                        panname2.Text = fullName;

                        con.Close();
                    }
                    else
                    {
                        lblpanno2B.Text = "Invalid Pan card number";
                    }


                }
            }
                //--------pan data validation api stop --------------------
            }
            catch (WebException ex)
            {
                lblpanverify.Text = "Invalid PAN card number";
            }

        }

        //Pan card  Halder B stop

        //Aadhar Halder A start
        protected void aadharverifyA_Click(object sender, EventArgs e)
        {
            try 
            { 
            if (aadharnoA.Text == "")
            {
                lblmsg.Text = "Please Enter Aadhar Card No. A/C Holder A";
                aadharnoA.Focus();
            }
            else
            {

                //----------send otp request---------start--------//
                // Set request data
                var data = new
                {
                    id_number = aadharnoA.Text
                    //id_number = "740987105041"

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

                // Display response
                //Response.Write(responseContent);
                //Label1.Text = responseContent;

                var responseObject = JObject.Parse(responseContent);

                var status_code = (string)responseObject["status_code"];
                var message = (string)responseObject["message"];
                var success = (string)responseObject["success"];

                var dataObject = JObject.Parse(responseObject["data"].ToString());
                //var client_id = (string)dataObject["client_id"];
                var otp_sent = (string)dataObject["otp_sent"];
                var valid_aadhaar = (string)dataObject["valid_aadhaar"];
                var status = (string)dataObject["status"];

                //// extract client_id value
                //clientId = (string)dataObject["client_id"];

                string client_id = (string)dataObject["client_id"];
                Session["client_id"] = client_id; // set the session variable

                //Label1.Text = responseContent;
                //Label2.Text = status_code;
                //Label3.Text = message;
                //Label4.Text = success;
                //Label5.Text = client_id;
                //Label10.Text = otp_sent;
                //Label7.Text = valid_aadhaar;
                //Label8.Text = status;


                //----------send otp request---------stop--------//
                string textadharnoHA = aadharnoA.Text;
                getadharnotextHA.Text = textadharnoHA.Substring(textadharnoHA.Length - 4);
                ConsentLetterHA.Visible = true;

                aadharverifyA.Visible = false;
                adhaarotpA.Visible = true;
                adhaarverifiedotpA.Visible = true;
            }
             }
            catch (WebException ex)
            {
                lblpanverify.Text = "Sorry, there may be an issue at the Aadhar portal which will be addressed soon. ";


            }
}

        protected void adhaarverifiedotpA_Click(object sender, EventArgs e)
        {
            try
            {
                if (adhaarotpA.Text == "")
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
                    otp = adhaarotpA.Text
                    //client_id = "aadhaar_v2_eBIMGPnJPlAqVQgsEyZB",
                    //otp = "203040"
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



                    // Label2.Text = Fulladdress;
                    //Label3.Text = country;
                    //Label4.Text = house;
                    //Label5.Text = subdist;
                    //Label7.Text = po;
                    //Label8.Text = state;
                    //Label9.Text = dist;
                    aadharstatusA = (string)responseObject["status_code"];
                    //----------submit otp request---------stop--------//

                    if (status_code == "200")
                    {

                        string acc_no = Convert.ToString(Session["Account_no"]);
                        string kycid = Convert.ToString(Session["kycid"]);

                        SqlConnection con = new SqlConnection(strcon);
                        //SqlCommand kycid = new SqlCommand(@"select Kycid  FROM [dbo].[kycdetail] where acoount_no='" + acc_no + "'", con);
                        //con.Open();
                        //string getkycid = (string)kycid.ExecuteScalar();

                        con.Open();

                        string textadharnoHA = aadharnoA.Text;
                       string getaadharnoHA = textadharnoHA.Substring(textadharnoHA.Length - 4);

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
                       ('" + kycid + "','" + full_name + "','" + care_of + "','" + aadhaar_number + "','" + client_id + "','" + dob + "','" + Fulladdress + "','" + status_code + "','" + message + "','" + success + "','I, the holder of Aadhaar No.xxxx xxxx '+'" + getaadharnoHA + "'+', hereby give my consent to Abhyudaya Coop.Bank Ltd for OTP based online Aadhaar based authentication for Re - KYC purpose.Abhyudaya Coop.Bank Ltd.has informed me that my identity information would only be used for Re - KYC purpose.')", con);


                        SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET [Aadharcardverify_HA] = 'verified'  WHERE Kycid='" + kycid + "' ", con);
                        cmd1.ExecuteNonQuery();

                        cmd.ExecuteNonQuery();
                        adhaarverifiedA.Visible = true;
                        adhaarotpA.Visible = false;
                        adhaarverifiedotpA.Visible = false;
                        ConsentLetterHA.Visible = false;

                    }
                    else
                    {
                        lblmsg.Text = "Invalid Aadhar card number 1st Holder";
                    }
                }
            }
            }
            catch (WebException ex)
            {
                lblpanverify.Text = "Sorry, there may be an issue at the Aadhar portal which will be addressed soon. ";


            }

        }

        //Aadhar Halder A Stop

        //Aadhar Halder B start

        protected void addharverifyB_Click(object sender, EventArgs e)
        {
            try { 
            if (aadharnoB.Text == "")
            {
                lblmsg.Text = "Please Enter Aadhar Card No. A/C Holder B!!";
                aadharnoB.Focus();
            }
            else
            {
                //----------dend otp request---------start--------//
                // Set request data
                var data = new
                {
                    id_number = aadharnoB.Text
                    //id_number = "740987105041"

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

                // Display response
                //Response.Write(responseContent);
                //Label1.Text = responseContent;

                var responseObject = JObject.Parse(responseContent);

                var status_code = (string)responseObject["status_code"];
                var message = (string)responseObject["message"];
                var success = (string)responseObject["success"];

                var dataObject = JObject.Parse(responseObject["data"].ToString());
                //var client_id = (string)dataObject["client_id"];
                var otp_sent = (string)dataObject["otp_sent"];
                var valid_aadhaar = (string)dataObject["valid_aadhaar"];
                var status = (string)dataObject["status"];

                // extract client_id value
                string client_id = (string)dataObject["client_id"];
                Session["client_id2"] = client_id; // set the session variable

                //Label1.Text = responseContent;
                //Label2.Text = status_code;
                //Label3.Text = message;
                //Label4.Text = success;
                //Label5.Text = client_id;
                //Label10.Text = otp_sent;
                //Label7.Text = valid_aadhaar;
                //Label8.Text = status;


                //----------dend otp request---------stop--------//
                string textadharnoHB = aadharnoB.Text;
                getadharnotextHB.Text = textadharnoHB.Substring(textadharnoHB.Length - 4);
                ConsentLetterHB.Visible = true;
                addharverifyB.Visible = false;
                adhaarotpB.Visible = true;
                adhaarverifiedotpB.Visible = true;
            }
            }
            catch (WebException ex)
            {
                lblmsg.Text = "Sorry, there may be an issue at the Aadhar portal which will be addressed soon. ";


            }

}

        protected void adhaarverifiedotpB_Click(object sender, EventArgs e)
        {
            try
            {
                if (adhaarotpB.Text == "")
                {
                    lblmsg.Text = "Please enter OTP...";
                }
                else
                {
                    string id = Session["client_id2"] as string; // get the value from the session variable

                    string url = "https://onotechnology.in/api/v1/aadhaar-v2/submit-otp/";
                    //string url = "https://kyc-api.surepass.io/api/v1/aadhaar-v2/submit-otp";
                    string token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6ZmFsc2UsImlhdCI6MTY3ODY5NDQzOCwianRpIjoiMmI5YjA0YjAtMmU1ZS00NjhkLTg3YzYtZTdmZWY4YjFhZWFiIiwidHlwZSI6ImFjY2VzcyIsImlkZW50aXR5IjoiZGV2LmNoaWNpbmZvdGVjaEBzdXJlcGFzcy5pbyIsIm5iZiI6MTY3ODY5NDQzOCwiZXhwIjoxOTk0MDU0NDM4LCJ1c2VyX2NsYWltcyI6eyJzY29wZXMiOlsidXNlciJdfX0._bKp9D4CltjpwqFkZo0t2YZFTry6e3aRq9sdk8PDYYc";

                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.Headers.Add("Authorization", token);

                    var data = new
                    {
                        client_id = id,
                        otp = adhaarotpB.Text
                        //client_id = "aadhaar_v2_eBIMGPnJPlAqVQgsEyZB",
                        //otp = "203040"
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

                        aadharstatusB = (string)responseObject["status_code"];
                        // Label2.Text = Fulladdress;
                        //Label3.Text = country;
                        //Label4.Text = house;
                        //Label5.Text = subdist;
                        //Label7.Text = po;
                        //Label8.Text = state;
                        //Label9.Text = dist;

                        //----------submit otp request---------stop--------//

                        if (status_code == "200")
                        {
                            string acc_no = Convert.ToString(Session["Account_no"]);

                            string kycid = Convert.ToString(Session["kycid"]);

                            SqlConnection con = new SqlConnection(strcon);
                            //SqlCommand kycid = new SqlCommand(@"select Kycid  FROM [dbo].[kycdetail] where acoount_no='" + acc_no + "'", con);
                            //con.Open();
                            //string getkycid = (string)kycid.ExecuteScalar();

                            con.Open();

                            string textadharnoHB = aadharnoB.Text;
                            string getaadharnoHB = textadharnoHB.Substring(textadharnoHB.Length - 4);

                            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[AadharApi_data]
                    SET[fullname2] = '" + full_name + "',[care_of2] ='" + care_of + "',[aadhar_card2] = '" + aadhaar_number + "',[client_id2] = '" + client_id + "',[DOB2] = '" + dob + "',[address2] ='" + Fulladdress + "' ,[status_code2] ='" + status_code + "' ,[message2] ='" + message + "' ,[success2] = '" + success + "',[ConsentLetterHB]='I, the holder of Aadhaar No.xxxx xxxx '+'" + getaadharnoHB + "'+', hereby give my consent to Abhyudaya Coop.Bank Ltd for OTP based online Aadhaar based authentication for Re - KYC purpose.Abhyudaya Coop.Bank Ltd.has informed me that my identity information would only be used for Re - KYC purpose.' WHERE [kycid] = '" + kycid + "'", con);

                            SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET  [Aadharcardverify_HB] = 'verified' WHERE Kycid='" + kycid + "' ", con);
                            cmd1.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();

                            adhaarverifiedB.Visible = true;
                            adhaarotpB.Visible = false;
                            adhaarverifiedotpB.Visible = false;
                            ConsentLetterHB.Visible = false;
                        }
                        else
                        {
                            lblmsg.Text = "Invalid Aadhar card number 2st Holder";
                        }


                    }

                }
            }
            catch (WebException ex)
            {
                lblmsg.Text = "Sorry, there may be an issue at the Aadhar portal which will be addressed soon.";


            }
        }

        //Aadhar Halder B Stop

        protected void Submit_Click(object sender, EventArgs e)
        {

            string panCardNumberA = pannoA.Text;
            string panCardNumberB = pannoB.Text;
            string pattern = "[A-Z]{5}[0-9]{4}[A-Z]{1}";

            string acc_no = Convert.ToString(Session["Account_no"]);
            string kycid = Convert.ToString(Session["kycid"]);
            SqlConnection con = new SqlConnection(strcon);

            //if (pannoA.Text == "")
            //{
            //    lblmsg.Text = "Please Enter Pan Card No. A/C Holder A";
            //    pannoA.Focus();
            //}
            //else if (panverifyA.Visible == true)
            //{
            //    lblmsg.Text = "Please verify holder A pan card No. !!";
            //}
            //else if (pannoB.Text == "")
            //{
            //    lblmsg.Text = "Please Enter Pan Card No. A/C Holder B";
            //    pannoB.Focus();
            //}
            //else if (panverifyB.Visible == true)
            //{
            //    lblmsg.Text = "Please verify holder B pan card No. !!";
            //}
            //else if (aadharnoA.Text == "")
            //{
            //    lblmsg.Text = "Please Enter Aadhar Card No. A/C Holder A";
            //    aadharnoA.Focus();
            //}
            //else if (!Regex.IsMatch(aadharnoA.Text.Trim(), "^[0-9]+$"))
            //{
            //    lblmsg.Text = "Please Enter valid Aadhar Card No. A/C Holder A";
            //    aadharnoA.Focus();
            //}
            //else if (aadharverifyA.Visible == true)
            //{
            //    lblmsg.Text = "Please verify holder A Aadhar card No. !!";
            //}
            //else if (aadharnoB.Text == "")
            //{
            //    lblmsg.Text = "Please Enter Aadhar Card No. A/C Holder B";
            //    aadharnoB.Focus();
            //}
            ////else if (!Regex.IsMatch(aadharnoA.Text.Trim(), "^[0-9]+$"))
            ////{
            ////    lblmsg.Text = "Please Enter valid Aadhar Card No. A/C Holder A";
            ////    aadharnoA.Focus();
            ////}
            //else if (!Regex.IsMatch(aadharnoB.Text.Trim(), "^[0-9]+$"))
            //{
            //    lblmsg.Text = "Please Enter valid Aadhar Card No. A/C Holder B";
            //    aadharnoB.Focus();
            //}
            //else if (addharverifyB.Visible == true)
            //{
            //    lblmsg.Text = "Please verify holder B Aadhar card No. !!";
            //}

            //else if (mobnoA.Text != "" && !Regex.IsMatch(mobnoA.Text.Trim(), "^[0-9]+$"))
            //{
            //    lblmsg.Text = "Please Enter valid Mobile No.";
            //    mobnoA.Focus();
            //}
            //else if (mobnoB.Text!="" && !Regex.IsMatch(mobnoB.Text.Trim(), "^[0-9]+$"))
            //{
            //    lblmsg.Text = "Please Enter valid Mobile No.";
            //    mobnoB.Focus();
            //}
            //else if (emailA.Text != "" && !Regex.IsMatch(emailA.Text.Trim(), @"^([\w\.\-]+)@([\w\-]+)((\.([a-zA-Z]){2,7})+)$"))
            //{
            //    lblmsg.Text = "Please enter valid email address ";
            //    emailA.Focus();

            //}
            //else if (emailB.Text != "" && !Regex.IsMatch(emailB.Text.Trim(), @"^([\w\.\-]+)@([\w\-]+)((\.([a-zA-Z]){2,7})+)$"))
            //{
            //    lblmsg.Text = "Please enter valid email address ";
            //    emailB.Focus();

            //}
            //else if (addressA.InnerHtml == "")
            //{
            //    lblmsg.Text = "Please Address A/C Holder A";
            //    addressA.Focus();
            //}
            //else if (addressB.InnerHtml == "")
            //{
            //    lblmsg.Text = "Please Address A/C Holder B";
            //    addressB.Focus();
            //}
            //else if (!Regex.IsMatch(panCardNumberA, pattern))
            //{
            //    lblmsg.Text = "Invalid PAN card number A/C Holder A";
            //}
            //else if (!Regex.IsMatch(panCardNumberB, pattern))
            //{
            //    lblmsg.Text = "Invalid PAN card number A/C Holder B";
            //  }
            if (string.IsNullOrWhiteSpace(pannoA.Text))
            {
                lblmsg.Text = "Please Enter Pan Card No. A/C Holder A";
                pannoA.Focus();
            }
            else if (panverifyA.Visible == true)
            {
                lblmsg.Text = "Please verify holder A PAN card No. !!";
            }
            else if (string.IsNullOrWhiteSpace(pannoB.Text))
            {
                lblmsg.Text = "Please Enter Pan Card No. A/C Holder B";
                pannoB.Focus();
            }
            else if (panverifyB.Visible == true)
            {
                lblmsg.Text = "Please verify holder B PAN card No. !!";
            }
            else if (string.IsNullOrWhiteSpace(aadharnoA.Text))
            {
                lblmsg.Text = "Please Enter Aadhar Card No. A/C Holder A";
                aadharnoA.Focus();
            }
            else if (!Regex.IsMatch(aadharnoA.Text.Trim(), "^[0-9]+$"))
            {
                lblmsg.Text = "Please Enter valid Aadhar Card No. A/C Holder A";
                aadharnoA.Focus();
            }
            else if (aadharverifyA.Visible == true)
            {
                lblmsg.Text = "Please verify holder A Aadhar card No. !!";
            }
            else if (string.IsNullOrWhiteSpace(aadharnoB.Text))
            {
                lblmsg.Text = "Please Enter Aadhar Card No. A/C Holder B";
                aadharnoB.Focus();
            }
            else if (!Regex.IsMatch(aadharnoB.Text.Trim(), "^[0-9]+$"))
            {
                lblmsg.Text = "Please Enter valid Aadhar Card No. A/C Holder B";
                aadharnoB.Focus();
            }
            else if (addharverifyB.Visible == true)
            {
                lblmsg.Text = "Please verify holder B Aadhar card No. !!";
            }
            else if (!string.IsNullOrWhiteSpace(mobnoA.Text) && !Regex.IsMatch(mobnoA.Text.Trim(), "^[0-9]+$"))
            {
                lblmsg.Text = "Please Enter valid Mobile No. A/C Holder A";
                mobnoA.Focus();
            }
            else if (!string.IsNullOrWhiteSpace(mobnoB.Text) && !Regex.IsMatch(mobnoB.Text.Trim(), "^[0-9]+$"))
            {
                lblmsg.Text = "Please Enter valid Mobile No. A/C Holder B";
                mobnoB.Focus();
            }
            else if (!string.IsNullOrWhiteSpace(emailA.Text) && !Regex.IsMatch(emailA.Text.Trim(), @"^([\w\.\-]+)@([\w\-]+)((\.([a-zA-Z]){2,7})+)$"))
            {
                lblmsg.Text = "Please enter valid email address A/C Holder A";
                emailA.Focus();
            }
            else if (!string.IsNullOrWhiteSpace(emailB.Text) && !Regex.IsMatch(emailB.Text.Trim(), @"^([\w\.\-]+)@([\w\-]+)((\.([a-zA-Z]){2,7})+)$"))
            {
                lblmsg.Text = "Please enter valid email address A/C Holder B";
                emailB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(addressA.InnerHtml))
            {
                lblmsg.Text = "Please Address A/C Holder A";
                addressA.Focus();
            }
            else if (string.IsNullOrWhiteSpace(addressB.InnerHtml))
            {
                lblmsg.Text = "Please Address A/C Holder B";
                addressB.Focus();
            }
            else if (!Regex.IsMatch(panCardNumberA, pattern))
            {
                lblmsg.Text = "Invalid PAN card number A/C Holder A";
            }
            else if (!Regex.IsMatch(panCardNumberB, pattern))
            {
                lblmsg.Text = "Invalid PAN card number A/C Holder B";
            }

            else
            {
                string textadharnoHA = aadharnoA.Text;
                string getaadharnoHA = textadharnoHA.Substring(textadharnoHA.Length - 4);

                string textadharnoHB = aadharnoB.Text;
                string getaadharnoHB = textadharnoHB.Substring(textadharnoHB.Length - 4);

                //SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET [pancardno_HA] = '" + pannoA.Text + "',[pancardno_HB] = '" + pannoB.Text + "', [Aadharcardno_HA] = '" + aadharnoA.Text + "', [Aadharcardno_HB] = '" + aadharnoB.Text + "', [Alternativmob_HA] = '" + mobnoA.Text + "', [Alternativmob_HB] = '" + mobnoB.Text + "', [Email_HA] = '" + emailA.Text + "', [Email_HB] = '" + emailB.Text + "', [CurrentAdd_HA] = '" + addressA.InnerText + "', [CurrentAdd_HB] = '" + addressB.InnerText + "',[ConsentLetterHA] ='I, the holder of Aadhaar No.xxxx xxxx '+'" + getaadharnoHA + "'+', hereby give my consent to Abhyudaya Coop.Bank Ltd for OTP based online Aadhaar based authentication for Re - KYC purpose.Abhyudaya Coop.Bank Ltd.has informed me that my identity information would only be used for Re - KYC purpose.',[ConsentLetterHB] ='I, the holder of Aadhaar No.xxxx xxxx '+'" + getaadharnoHB + "'+', hereby give my consent to Abhyudaya Coop.Bank Ltd for OTP based online Aadhaar based authentication for Re - KYC purpose.Abhyudaya Coop.Bank Ltd.has informed me that my identity information would only be used for Re - KYC purpose.' WHERE Kycid='" + kycid + "' ", con);

                SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[kycdetail] SET [pancardno_HA] = '" + pannoA.Text + "',[pancardno_HB] = '" + pannoB.Text + "', [Aadharcardno_HA] = '" + aadharnoA.Text + "', [Aadharcardno_HB] = '" + aadharnoB.Text + "', [Alternativmob_HA] = '" + mobnoA.Text + "', [Alternativmob_HB] = '" + mobnoB.Text + "', [Email_HA] = '" + emailA.Text + "', [Email_HB] = '" + emailB.Text + "', [CurrentAdd_HA] = '" + addressA.InnerText + "', [CurrentAdd_HB] = '" + addressB.InnerText + "',[ConsentLetterHA] ='I, the holder of Aadhaar No.xxxx xxxx '+'" + getaadharnoHA + "'+', hereby give my consent to Abhyudaya Coop.Bank Ltd for OTP based online Aadhaar based authentication for Re - KYC purpose.Abhyudaya Coop.Bank Ltd.has informed me that my identity information would only be used for Re - KYC purpose.',[ConsentLetterHB] ='I, the holder of Aadhaar No.xxxx xxxx '+'" + getaadharnoHB + "'+', hereby give my consent to Abhyudaya Coop.Bank Ltd for OTP based online Aadhaar based authentication for Re - KYC purpose.Abhyudaya Coop.Bank Ltd.has informed me that my identity information would only be used for Re - KYC purpose.' WHERE Kycid='KYCKRI7540' ", con);

                con.Open();
                cmd.ExecuteNonQuery();
                Session["Account_no1"] = acc_no;
                Session["kycid"] = kycid;
                Response.Redirect("occupation_join.aspx");

            }

        }
    }
}
