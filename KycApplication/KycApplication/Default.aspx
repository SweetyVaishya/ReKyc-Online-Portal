<%@ Page Title="Re-kyc application" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KycApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

    <div class="card m-3 p-3 mb-5" style="background-color: #fdf69e; height:80%;" >

        <div class="row text-center mt-5"  >
            <div class="col-md-12">
            <span style="color:#0056ae; font-size:140%;">
               <%-- <span style="color:red;">*</span>--%>
                 Input Account Number or Customer Id </span><br />
                <asp:Label ID="lbleror" runat="server" ForeColor="Red"></asp:Label>
                </div>
        </div>
         
        <div class="row mt-2">
             <div class="col-md-4"></div>
            <div class="col-md-4 text-center">    
                <asp:TextBox ID="Account_no" AutoComplete="off" MaxLength="15"  class="form-control" placeholder="Please enter Account number" runat="server" ></asp:TextBox>
            </div>
            <div class="col-md-4"></div>
        </div>

        <div class="row text-center " >
            <div class="col-md-12">
                <asp:Label ID="verifyRekyc" runat="server" style="color:#0056ae; "></asp:Label>
            </div>
        </div>

        <div class="row  mt-3">
            <div class="col-md-12 text-center ">
                <asp:Button ID="Submit" runat="server" Text="Next" class="btn text-light" style="background-color:#0056ae;" OnClick="Submit_Click1"  />
            </div>
        </div>

        

         <div class="row">
               <div class="col-md-2"></div>
                <div class="col-md-10" style="font-size: small; color: #0056ae;">
                     <p class="mt-4 ml-4" ">
                <b>Note:</b>  </p>
                <ul class="text-justify">
                    <li>Kindly enter your customer id or account number as available on first page of pass book.</li>
                    <li> On submission of your account number or customer id,an OTP will be sent to your registered mobile number.</li>
                </ul>
                </div>
               
           </div>

    </div>
</asp:Content>
