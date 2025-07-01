<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ContinueKYCForm.aspx.cs" Inherits="KycApplication.ContinueKYCForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="card m-3 p-3 " style="background-color: #fdf69e; height: 80%;">

          <div class="text-center m-2 p-1 shadow-lg" style="font-size: 22px; background-color: #0056ae;color:white;">
            <span >Continue Re-KYC Form</span>
            <br />
           
        </div>

        <div class="text-center m-2 " style="font-size: 22px;color: #0056ae;">
            <span >Individual Account & Occupation Details</span>
        </div>

          <div class="text-center m-2 " style="font-size: 18px;color: #0056ae;">
            <span >( You had already submitted incomplete application. please complete it now. )</span>
        </div>


        <div class="text-center mt-1">
             <span class="text-danger" style="font-size: 16px;">All fields are mandatory.</span><br />

            
            <asp:Label ID="text" runat="server" Text="" ForeColor="Red"></asp:Label><br />

                 <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                 <asp:Label ID="lblpanverify" runat="server" Text="" ForeColor="red"></asp:Label>
        </div>


        <div class="row">
            <div class="col-md-1"></div>


             <div class="col-md-10">

                   <div class="text-left mt-2">
                           <span style="color: black; font-size:110%; font-weight:600;" >KYCID : <asp:Label ID="kycidNo" runat="server" Text="" ></asp:Label></span><br /><br />
                         <span style="color: #0056ae;  font-size:110%;"><asp:Label ID="panname" runat="server" Text="" ></asp:Label></span>
                      </div>


                  <div class="row">


            <div class="col-md-6">
                  <div class="row">
                    
                      <br />
                        <div class="col-md-9 mt-2 ">
                            Pan Card Number 
                            <asp:TextBox ID="pen_no" AutoComplete="off" MaxLength="10" MinLength="10" placeholder="Enter Pan Card No." class="form-control"  runat="server" OnTextChanged="pen_no_TextChanged1" ></asp:TextBox>
                        </div>

                        <div class="col-md-3 mt-2">
                              
                            <asp:Button ID="pen_verify" class="btn text-light " Style="background-color: #0056ae; height: 50% !important; margin-top:30px;" runat="server" Text="Verify" title="Click Here to verify your PAN Card " OnClick="pen_verify_Click" />
                            <asp:Button ID="verified" class="  btn btn-success" Style="height: 50% !important; margin-top:30px;" runat="server" Text="Verified" Visible="false" title="Your PAN Card is verified"  />
                           
                        </div>
                    </div>

            </div>


            <div class="col-md-6">
                     <div class="row">
                        <asp:Label ID="lblAadharverify" runat="server" Text=""></asp:Label>
                        <div class="col-md-9  mt-2">
                            Aadhar Card Number 
                            <asp:TextBox ID="aadhar_no" AutoComplete="off" MaxLength="12" MinLength="12" placeholder="Enter Aadhar Card No." class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3  mt-2">
                        
                            <asp:Button ID="aadhar_verify" class="btn text-light" Style="background-color: #0056ae; height: 50%; margin-top:30px;" runat="server" Text="Verify" title="Click Here to verify your Aadhar Card " OnClick="aadhar_verify_Click"  />
                            <asp:Button ID="aadhar_Verified" class="  btn btn-success" Style="height: 50% !important; margin-top:30px;" runat="server" Text="Verified" Visible="false"  title="Your Aadhar Card is verified" />
                        </div>
                    </div>

                 <div class="row">
                        <div class="col-md-10">

                            <div id="ConsentLetter" visible="false" runat="server" class="text-justify">
                                I, the holder of Aadhaar No.xxxx xxxx <asp:Label ID="getadharnotext" runat="server" Text=""></asp:Label>
                                , hereby give my consent to Abhyudaya Coop.
                                Bank Ltd for OTP based online Aadhaar based authentication for Re-KYC purpose.
                                Abhyudaya Coop. Bank Ltd. has informed me that my identity information would only be used for Re-KYC purpose only.
                            </div>

                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-8">
                            <asp:TextBox ID="enterotp" AutoComplete="off" MaxLength="6" MinLength="6" placeholder="Enter otp" Visible="false" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">

                            <asp:Button ID="submitotp" class="btn text-light mt-2" Style="background-color: #0056ae; height: 68% !important;" Visible="false" runat="server" Text="Submit" OnClick="submitotp_Click"  />
                            
                        </div>
                    </div>
            </div>
        </div>

                 <div class="row">
                         <div class="col-md-5 mt-2">
                         
                    <asp:Label ID="mobileno" runat="server"  Text="Alternate Mobile Number"></asp:Label><br />

                            <asp:TextBox ID="mob_no" AutoComplete="off" MaxLength="10" MinLength="10" placeholder="Enter Alternate Mobile No." class="form-control" runat="server"></asp:TextBox>
                        </div>
                     <div class="col-md-1"></div>

                          <div class="col-md-5 mt-2">
                          
                    <asp:Label ID="email" runat="server" Text="E-Mail ID"></asp:Label><br />
                            <asp:TextBox ID="emailid" AutoComplete="off" placeholder="Enter E-mail ID" class="form-control" runat="server"></asp:TextBox>
                        </div>
                 </div>

                 <div class="row">
                           <div class="col-md-5 mt-2">
                      
                    <asp:Label ID="Label5" runat="server" Text="Current Address"></asp:Label><br />

                            <textarea id="address" autocomplete="off" maxlength="250" runat="server" placeholder="Enter Current Address (max 250 characters)" class="form-control" cols="20" rows="2"></textarea>

                        </div>

                     <div class="col-md-1"></div>

                     <div class="col-md-5 mt-2">
                            <div class="row">

                        <div class="col-md-12">
                             <span ><asp:Label ID="Label3" runat="server" Text="Occupation :"></asp:Label></span>
                            <asp:DropDownList ID="incomesource" runat="server" class="form-control">
                                <asp:ListItem Value="">---select--- </asp:ListItem>
                                <asp:ListItem>SALARIED EMPLOYEE</asp:ListItem>
                                 <asp:ListItem>HOUSEWIFE</asp:ListItem>
                                 <asp:ListItem>SMALL BUSINESS</asp:ListItem>
                                 <asp:ListItem>ARTISANS AND CRAFTSMAN</asp:ListItem>
                                 <asp:ListItem>DOCTOR</asp:ListItem>
                                 <asp:ListItem>ADVOCATE</asp:ListItem>
                                 <asp:ListItem>CONSULTANT</asp:ListItem>
                                 <asp:ListItem>ARCHITECT</asp:ListItem>
                                 <asp:ListItem>TRANSPORT OPERATOR</asp:ListItem>
                                 <asp:ListItem>SOFTWARE CONSULTANT</asp:ListItem>
                                 <asp:ListItem>BUSINESSMAN</asp:ListItem>
                                 <asp:ListItem>SELF EMPLOYED</asp:ListItem>
                                 <asp:ListItem>SPORTSMAN</asp:ListItem>
                                <asp:ListItem>DRIVER</asp:ListItem>
                                <asp:ListItem>BUSINESSWOMAN</asp:ListItem>
                                <asp:ListItem>CONTRACTOR</asp:ListItem> 
                                 <asp:ListItem>RETIRED</asp:ListItem> 
                                 <asp:ListItem>STUDENT</asp:ListItem> 
                                 <asp:ListItem> INTERNATIONAL FIGURE</asp:ListItem> 
                                 <asp:ListItem>OTHERS</asp:ListItem> 
                                 <asp:ListItem>CONDUCTOR</asp:ListItem> 
                                  <asp:ListItem>GOVT AGENCY</asp:ListItem> 
                                  <asp:ListItem>ANTIQUE DEALERS</asp:ListItem> 
                                  <asp:ListItem>MONEY SERVICE BUREAU</asp:ListItem> 
                                  <asp:ListItem>DEALERS IN ARMS</asp:ListItem> 
                                  <asp:ListItem>BULLION TRADERS</asp:ListItem> 
                                  <asp:ListItem>POLITICALLY EXPOSED PERSONS(FORIEGN)</asp:ListItem> 
                                  <asp:ListItem>PROFESSIONAL</asp:ListItem> 
                                  <asp:ListItem>Service-Pvt Sector</asp:ListItem> 
                                  <asp:ListItem>Service-Public Sector</asp:ListItem> 
                                  <asp:ListItem>Service-Govt Sector</asp:ListItem> 
                            </asp:DropDownList>
                        </div>
                       
                    </div>


                 </div>

             </div>

                 <div class="row">

                      <div class="col-md-5 mt-2">
                <asp:Label ID="employename1" runat="server" Text="Employer / Business Details"></asp:Label>
                            <asp:TextBox ID="employename" class="form-control" AutoComplete="off" placeholder="Name of Employer/Business/Industry" runat="server"></asp:TextBox>
                        </div>

                      <div class="col-md-1"></div>

                      <div class="col-md-5 mt-2">
                      
                            <asp:Label ID="industrytype1" runat="server" Text="Industry/ Bussiness Type"></asp:Label>

                            <asp:TextBox ID="industrytype"  class="form-control" AutoComplete="off" placeholder="Enter Industry/ Bussiness Type" runat="server"></asp:TextBox>
                     
                        </div>

                 </div>

                 <div class="row">

                     <div class="col-md-5 mt-2">
                <asp:Label ID="yearsfServiceBusiness" runat="server" Text="Number of years in service / business :"></asp:Label>
                            <asp:TextBox ID="YearsOfServiceBusiness" class="form-control" AutoComplete="off" placeholder="Number of years in service / business" runat="server"></asp:TextBox>
                        </div>

                     <div class="col-md-1"></div>

                      <div class="col-md-5 mt-2">
                            <asp:Label ID="Label2" runat="server" Text="Gross Annual Income"></asp:Label>
                            <asp:DropDownList ID="from" runat="server" class="form-control">
                                <asp:ListItem Value="">---select--- </asp:ListItem>
                                <asp:ListItem>Up to Rs. 1 Lakh</asp:ListItem>
                                <asp:ListItem>Above 1 Lakh to Rs. 5 Lakh</asp:ListItem>
                                <asp:ListItem>Above 5 Lakh to Rs. 10 Lakh</asp:ListItem>
                                <asp:ListItem>Above 10 Lakh to Rs. 20 Lakh</asp:ListItem>
                                <asp:ListItem>Above Rs. 20 Lakh</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                 </div>

                 <hr />

                    <div class="row mt-3 mb-3">
                        <div class="col-md-8">
                    <asp:Label ID="AuthorizationTiltle"  runat="server" Text="Do you want to upload latest Aadhaar Card for updating the OVDs in the Bank ?  "></asp:Label>
                          
                            </div>

                     <div class="col-md-4">
                           <asp:RadioButtonList ID="AuthorizeAadhar" RepeatDirection="Horizontal" runat="server">
                                <asp:ListItem Value="Yes">&nbsp;Yes&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                  <asp:ListItem Value="No">&nbsp;&nbsp;No</asp:ListItem>
                            </asp:RadioButtonList>

                     </div>
                 </div>
             
                 <hr />

                 
                    <div class="row mt-3 mb-3">
                        <div class="col-md-8">
                    <asp:Label ID="AuthorizationTiltlePan"  runat="server" Text="Kindly update my PAN number in bank records as per attached PAN card details  "></asp:Label>
                          
                            </div>

                     <div class="col-md-4">
                           <asp:RadioButtonList ID="AuthorizePan" RepeatDirection="Horizontal" runat="server">
                                <asp:ListItem Value="Yes">&nbsp;Yes&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                  <asp:ListItem Value="No">&nbsp;&nbsp;No</asp:ListItem>
                            </asp:RadioButtonList>

                     </div>
                 </div>
             
                 <hr />



                 <div class="row" runat="server" visible="true" id="documentid">

                        <div class="col-md-5 mt-2">
                <asp:Label ID="Label1" runat="server" Text="Upload Pan Card :"></asp:Label>
                            <asp:FileUpload ID="PanCard" class="form-control" style="height:45px;" runat="server" />
                                <asp:Label ID="PrebPanNm" class="mt-1 " runat="server" Text=""></asp:Label>
                        </div>

                     <div class="col-md-1"></div>   

                      <div class="col-md-5 mt-2">
                            <asp:Label ID="Label4" runat="server" Text="Upload Aadhar Card"></asp:Label>
                            <asp:FileUpload ID="AadharCard" class="form-control" style="height:45px;" runat="server" />
                            <asp:Label ID="PrevAadharNm" class="mt-1 " runat="server" Text=""></asp:Label>
                        </div>

                 </div>

                   <div class="row mt-3" runat="server" visible="false" id="confirmationmsg">
                       <div class="col-md-12">
                             <asp:Label ID="ConfMsg" class="mt-2 " style="font-size:18px;" runat="server" Text="You have already uploaded Pan Card or Aadhar Card documents."></asp:Label>
                       </div>
                        
                       </div>

                      <div class="row mt-3" runat="server" visible="false" id="confirmationmsg1">
                       <div class="col-md-12">
                              <asp:Label ID="ConfMsg1" class="mt-2 " style="font-size:18px;" runat="server" Text="User has not uploaded the Pan Card / Aadhar Card documents."></asp:Label>
                       </div>
                       </div>


             <div class="col-md-1"></div>
        </div>

    </div>
        <div class="row">
               <div class="col-md-2"></div>
                <div class="col-md-10" style="font-size: medium; color: #0056ae;">
                     <p class="mt-4 ml-4" ">
                <b>Note:</b>  </p>
                <ul class="text-justify">
                    <li>You have to go to the next page to complete the submission process.</li>
                    <li>Your alternate mobile number is just for additional stand by communication channel with  .<br />
                Your verification will be on the basis of your registered mobile number as provided earlier.</li>
                    <li>Once you complete this page the submission process gets over.</li>
                </ul>
                </div>
               
           </div>

         <div class="text-center mt-4 mb-5">
                    
                            <asp:Button ID="Submit" runat="server" Text="Submit" class="btn text-light" Style="background-color: #0056ae;" OnClick="submit_Click" />
                        
                    </div>

      


</asp:Content>





