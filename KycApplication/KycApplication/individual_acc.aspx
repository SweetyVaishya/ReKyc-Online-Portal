<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="individual_acc.aspx.cs" Inherits="KycApplication.individual_acc" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <%--<div style="text-align: right;">

        <asp:Label ID="username" runat="server" Text="" class="ml-auto pr-5" Style="color: #0056ae;"></asp:Label>
    </div>--%>

    <div class="card m-3 p-3" style="background-color: #fdf69e">

        <div class="row text-center mt-2">
            <div class="col-md-12">

                <span style="color: #0056ae; font-size:160%;">Individual Account</span><br />

               <%-- <asp:Label ID="Label1" runat="server" Text="Please fill in the form and proceed." Style="color: #0056ae;"></asp:Label><br />--%>
                <asp:Label ID="Label6" runat="server" Text="All fields are mandatory."></asp:Label><br />
                <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                 <asp:Label ID="lblpanverify" runat="server" Text="" ForeColor="red"></asp:Label>

            </div>
        </div>

        <div class="container">
            <div class="row">

                <div class="col-md-4"></div>

                <div class="col-md-8 mt-4">
                     <span style="color: #0056ae;  font-size:110%;"><asp:Label ID="panname" runat="server" Text="" ></asp:Label></span>
                    <div class="row">
                     
                        <div class="col-md-6 mt-2">
                            Pan Card Number 
                            <asp:TextBox ID="pen_no" AutoComplete="off" MaxLength="10" MinLength="10" placeholder="Enter Pan Card No." class="form-control" AutoPostBack="true" runat="server" OnTextChanged="pen_no_TextChanged"></asp:TextBox>
                        </div>

                        <div class="col-md-6 mt-2">
                            <asp:Button ID="pen_verify" class="btn text-light " Style="background-color: #0056ae; height: 50% !important; margin-top:9%;" runat="server" Text="Verify" OnClick="pen_verify_Click" />
                            <asp:Button ID="verified" class="  btn btn-success" Style="height: 50% !important; margin-top:9%;" runat="server" Text="Verified" Visible="false" />
                           
                        </div>
                    </div>

                    <div class="row">
                        <asp:Label ID="lblAadharverify" runat="server" Text=""></asp:Label>
                        <div class="col-md-6 ">
                            Aadhar Card Number 
                            <asp:TextBox ID="aadhar_no" AutoComplete="off" MaxLength="12" MinLength="12" placeholder="Enter Aadhar Card No." class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Button ID="aadhar_verify" class="btn text-light" Style="background-color: #0056ae; height: 50%; margin-top:9%;" runat="server" Text="Verify" OnClick="aadhar_verify_Click" />
                            <asp:Button ID="aadhar_Verified" class="  btn btn-success" Style="height: 50% !important; margin-top:9%;" runat="server" Text="Verified" Visible="false" />
                        </div>
                    </div>

                    <!--- validate aadhar otp start---->

                    <div class="row">
                        <div class="col-md-6">

                            <div id="ConsentLetter" visible="false" runat="server" class="text-justify">
                                I, the holder of Aadhaar No.xxxx xxxx <asp:Label ID="getadharnotext" runat="server" Text=""></asp:Label>
                                , hereby give my consent to Abhyudaya Coop.
                                Bank Ltd for OTP based online Aadhaar based authentication for Re-KYC purpose.
                                Abhyudaya Coop. Bank Ltd. has informed me that my identity information would only be used for Re-KYC purpose only.
                            </div>

                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <asp:TextBox ID="enterotp" AutoComplete="off" MaxLength="6" MinLength="6" placeholder="Enter otp" Visible="false" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6">

                            <asp:Button ID="submitotp" class="btn text-light mt-2" Style="background-color: #0056ae; height: 68% !important;" Visible="false" runat="server" Text="Submit" OnClick="submitotp_Click"  />
                            
                        </div>
                    </div>
                    <!--- validate aadhar otp start---->

                    <div class="row">

                        <div class="col-md-6">
                            <%-- <span style="color: red;">*</span>--%>
                    <asp:Label ID="mobileno" runat="server"  Text="Alternate Mobile Number"></asp:Label><br />

                            <asp:TextBox ID="mob_no" AutoComplete="off" MaxLength="10" MinLength="10" placeholder="Enter Alternate Mobile No." class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-6">
                    <asp:Label ID="email" runat="server" Text="E-Mail ID"></asp:Label><br />
                            <asp:TextBox ID="emailid" AutoComplete="off" placeholder="Enter E-mail ID" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-6">
                    <asp:Label ID="Label5" runat="server" Text="Current Address"></asp:Label><br />
                           
                            <textarea id="address" autocomplete="off" maxlength="250" runat="server" placeholder="Enter Current Address (max 250 characters)" class="form-control" cols="20" rows="2"></textarea>

                        </div>
                    </div>

                         <div class="row mt-2 mb-2 ">
                        <div class="col-md-6">
                               <asp:Label ID="AuthorizationTiltle"  runat="server" Text="Do you want to upload latest Aadhaar Card for updating the OVDs in the Bank ? : "></asp:Label>
                 <%--    <span style="font-size:18px;">You authorize the bank to change the address on your Aadhaar card   :   </span><br /><br />--%>
                           <asp:RadioButtonList ID="AuthorizeAadhar" RepeatDirection="Horizontal" runat="server">
                                <asp:ListItem Value="Yes">&nbsp;Yes&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                  <asp:ListItem Value="No">&nbsp;&nbsp;No</asp:ListItem>
                            </asp:RadioButtonList>
                            </div>
                 </div>

                          <div class="row mt-2 mb-2 ">
                        <div class="col-md-6">
                               <asp:Label ID="AuthorizationTiltlePan"  runat="server" Text="Kindly update my PAN number in bank records as per attached PAN card details : "></asp:Label>
                 <%--    <span style="font-size:18px;">You authorize the bank to change the address on your Aadhaar card   :   </span><br /><br />--%>
                           <asp:RadioButtonList ID="AuthorizePan" RepeatDirection="Horizontal" runat="server">
                                <asp:ListItem Value="Yes">&nbsp;Yes&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                  <asp:ListItem Value="No">&nbsp;&nbsp;No</asp:ListItem>
                            </asp:RadioButtonList>
                            </div>
                 </div>

                        <div class="row">
                           <div class="col-md-6 ">
                            <asp:Label ID="Label4" runat="server" Text="Upload Aadhar Card"></asp:Label>
                            <asp:FileUpload ID="AadharCard" class="form-control" style="height:45px;" runat="server" />
                        </div>
                    </div>

                 

                    <div class="row">
                        <div class="col-md-6 ">
                <asp:Label ID="Label1" runat="server" Text="Upload Pan Card :"></asp:Label>
                            <asp:FileUpload ID="PanCard" class="form-control" style="height:45px;" runat="server" />
                        </div>
                    </div>

                
                </div>

                <%-- <div class="col-md-1"></div>--%>
            </div>


            <div class="row mt-3 ">
                <div class="col-md-12 text-center">
                    <asp:Button ID="submit" class="btn text-light" Style="background-color: #0056ae;" runat="server" Text="Next" OnClick="submit_Click" />
                </div>

            </div>
             <div class="row">
               <div class="col-md-2"></div>
                <div class="col-md-10" style="font-size: medium; color: #0056ae;">
                     <p class="mt-4 ml-4" ">
                <b>Note:</b>  </p>
                <ul class="text-justify">
                    <li>You have to go to the next page to complete the submission process.</li>
                    <li>Your alternate mobile number is just for additional stand by communication channel with bank.<br />
                Your verification will be on the basis of your registered mobile number as provided earlier.</li>
                </ul>
                </div>
               
           </div>
           

        </div>
    </div>

    

</asp:Content>
