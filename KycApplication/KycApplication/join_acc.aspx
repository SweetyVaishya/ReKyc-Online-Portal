<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="join_acc.aspx.cs" Inherits="KycApplication.join_acc" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- <div style="text-align: right;">

        <asp:Label ID="username" runat="server" Text="" class="ml-auto pr-5" Style="color: #0056ae;"></asp:Label>
    </div>--%>

    <div class="card m-3 p-3 mb-5" style="background-color: #fdf69e">
     <div class="row text-center mt-3">
                    <div class="col-md-12">
                        <span style="color:#0056ae; font-size:150%;">Joint Account</span>
                        <br />
                        
                <%-- <span style="color: red;">*</span>--%><asp:Label ID="Label6" runat="server" Text="All fields are mandatory." ></asp:Label>     
                        <br />
                        <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>

    <div class="row mt-3">

         <!---A/C Holder A--->
       <div class="col-md-1 "></div>
         <div class="col-md-5 ">
            <span  style="color:#0056ae; font-size:120%;"> First Account Holder</span>
                <div class="container  ">
                     <asp:Label ID="lblpanverify"  runat="server" Text=""></asp:Label><br />
                      <span style="color: #0056ae;  font-size:120%;"><asp:Label ID="panname1" runat="server" Text="" ></asp:Label></span>
                    <div class="row mt-2">
                        <div class="col-md-8">
                            Pan Card Number 
                            <asp:TextBox ID="pannoA" AutoComplete="off" MaxLength="10" MinLength="10" data-toggle="tooltip" data-placement="top" title="Enter Pan Card No." placeholder="Enter Pan Card No." class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="panverifyA" class="btn text-light " style="background-color:#0056ae; margin-top:27%; height:50% !important;" runat="server" Text="Verify" OnClick="panverifyA_Click" />
                        <asp:Button ID="panverifiedA" class="  btn-success" style=" height:50% !important; margin-top:27%;" runat="server" Text="Verified" Visible="false" />
                        </div>
                    </div>

                    <div class="row ">

                        <div class="col-md-8">
                           <%-- <span style="color: red;">*</span>
                            <asp:Label ID="aadharno1A" runat="server" Text="Aadhar No."></asp:Label><br />--%>
                            Aadhar Card Number
                            <asp:TextBox ID="aadharnoA" AutoComplete="off" MaxLength="12" MinLength="12" placeholder="Enter Aadhar Card No." class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="aadharverifyA" class="btn text-light " style="background-color:#0056ae; height:50% !important; margin-top:27%;" runat="server" Text="Verify" OnClick="aadharverifyA_Click" />
                             <asp:Button ID="adhaarverifiedA" class="  btn-success" style=" height:50% !important; margin-top:27%;" runat="server" Text="Verified" Visible="false"/>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-10">

                            <div id="ConsentLetterHA" visible="false" runat="server" class="text-justify">
                                I, the holder of Aadhaar No.xxxx xxxx <asp:Label ID="getadharnotextHA" runat="server" Text=""></asp:Label>
                                , hereby give my consent to Abhyudaya Coop.
                                Bank Ltd for OTP based online Aadhaar based authentication for Re-KYC purpose.
                                Abhyudaya Coop. Bank Ltd. has informed me that my identity information would only be used for Re-KYC purpose.
                            </div>

                        </div>

                    </div>

                      <div class="row ">
                        <div class="col-md-8">

                       <asp:TextBox ID="adhaarotpA" class=" form-control mt-2" MaxLength="6" placeholder="Enter otp" runat="server" Visible="false"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="adhaarverifiedotpA" class=" form-control mt-2 btn-info" style=" height:68% !important; background-color:#0056ae" runat="server" Text="Submit" Visible="false"  OnClick="adhaarverifiedotpA_Click" />
                        </div>
                        </div>

                    <div class="row">

                        <div class="col-md-8">
                        <%--    <span style="color: red;">*</span>
                            <asp:Label ID="mobno1A" runat="server" Text="Alternate Mobile No."></asp:Label><br />--%>
                            Alternate Mobile Number
                            <asp:TextBox ID="mobnoA" AutoComplete="off" MaxLength="10" MinLength="10" placeholder="Enter Alternate mobile No." class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-8">
                            <%--<span style="color: red;">*</span>
                            <asp:Label ID="email1A" runat="server" Text="E-Mail ID"></asp:Label><br />--%>
                            E-Mail id
                            <asp:TextBox ID="emailA" type="email" AutoComplete="off" placeholder="Enter E-Mail ID" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-8">
                            <%--<span style="color: red;">*</span>
                            <asp:Label ID="address1A" runat="server" Text="Current Address"></asp:Label><br />
                          --%>
                            Current Address
                            <textarea id="addressA" placeholder="Enter Current Address (max 250 character)" runat="server" class="form-control" cols="20" rows="2"></textarea>
                        </div>
                    </div>

                </div>
        </div>

        <!---A/C Holder B--->
         <div class="col-md-1 "></div>
        <div class="col-md-5 ">
            <span style="color:#0056ae; font-size:120%;"> Second Account Holder</span>
                <div class="container ">
                     <asp:Label ID="lblpanno2B" runat="server" Text=""></asp:Label><br />
                      <span style="color: #0056ae;  font-size:120%;"><asp:Label ID="panname2" runat="server" Text="" ></asp:Label></span>
                    <div class="row mt-2 ">
                        <div class="col-md-8">
                            Pan Card Number
                            <asp:TextBox ID="pannoB" AutoComplete="off" MaxLength="10" MinLength="10" placeholder="Enter Pan Card No." class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="panverifyB" class="btn text-light " style="background-color:#0056ae;  height:50% !important; margin-top:27%;" runat="server" Text="Verify" OnClick="panverifyB_Click" />
                       <asp:Button ID="panverifiedB" class=" btn-success" style="  height:50% !important; margin-top:27%;" runat="server" Text="Verified" Visible="false" />
                            </div>
                    </div>
                  
                    <div class="row">
                        <div class="col-md-8">
                           <%-- <span style="color: red;">*</span>
                            <asp:Label ID="aadhar2B" runat="server" Text="Aadhar No."></asp:Label><br />--%>
                            Aadhar Card Number
                            <asp:TextBox ID="aadharnoB" AutoComplete="off" MaxLength="12" MinLength="12" placeholder="Enter Aadhar Card No." class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="addharverifyB" class="btn text-light " style="background-color:#0056ae;  height:50% !important; margin-top:27%;" runat="server" Text="Verify" OnClick="addharverifyB_Click" />
                        <asp:Button ID="adhaarverifiedB" class="  btn-success" style=" height:50% !important; margin-top:27%;" runat="server" Text="Verified" Visible="false"/>
                            </div>
                    </div>

                    <div class="row">
                        <div class="col-md-10">

                            <div id="ConsentLetterHB" visible="false" runat="server" class="text-justify">
                                I, the holder of Aadhaar No.xxxx xxxx <asp:Label ID="getadharnotextHB" runat="server" Text=""></asp:Label>
                                , hereby give my consent to Abhyudaya Coop.
                                Bank Ltd for OTP based online Aadhaar based authentication for Re-KYC purpose.
                                Abhyudaya Coop. Bank Ltd. has informed me that my identity information would only be used for Re-KYC purpose.
                            </div>

                        </div>

                    </div>

                      <div class="row ">
                        <div class="col-md-8">
                       <asp:TextBox ID="adhaarotpB" class=" form-control mt-2" MaxLength="6" placeholder="Enter otp" runat="server" Visible="false"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="adhaarverifiedotpB" class=" form-control mt-2 btn-info" style=" height:68% !important; background-color:#0056ae" runat="server" Text="Submit" Visible="false" OnClick="adhaarverifiedotpB_Click"  />
                        </div>
                        </div>


                    <div class="row">

                        <div class="col-md-8">
                            <%--<span style="color: red;">*</span>
                            <asp:Label ID="mobno2B" runat="server" Text="Alternate Mobile No."></asp:Label><br />--%>
                            Alternate Mobile Number
                            <asp:TextBox ID="mobnoB" AutoComplete="off" MaxLength="10" MinLength="10" placeholder="Enter Alternate Mobile No." class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-8">
                            <%--<span style="color: red;">*</span>
                            <asp:Label ID="email2B" runat="server" Text="E-Mail ID"></asp:Label><br />--%>
                            E-Mail id
                            <asp:TextBox ID="emailB" type="email" placeholder="Enter E-Mail ID" AutoComplete="off" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-8">
                            <%--<span style="color: red;">*</span>
                            <asp:Label ID="address2B" runat="server" Text="Current Address"></asp:Label><br />--%>
                            Current Address
                            <textarea id="addressB" runat="server" placeholder="Enter Current Address" class="form-control" cols="20" rows="2"></textarea>
                        </div>
                    </div>

                </div>
        </div>

         
    </div>


    <div class="row  my-3">
            <div class="col-md-12 text-center ">
                <asp:Button ID="Submit" runat="server" Text="Next" class="btn text-light" style="background-color:#0056ae;" OnClick="Submit_Click"   />

            </div>
        </div>

          <div class="row">
               <div class="col-md-2"></div>
                <div class="col-md-10" style="font-size: medium; color: #0056ae;">
                     <p class="mt-4 ml-4" >
                <b>Note:</b>  </p>
                <ul class="text-justify">
                    <li>You have to go to the next page to complete the submission process.</li>
                    <li>Your alternate mobile number is just for additional stand by communication channel with bank.<br />
                Your verification will be on the basis of your registered mobile number as provided earlier.</li>
                </ul>
                </div>
               
           </div>
           

        </div>


   
</asp:Content>
