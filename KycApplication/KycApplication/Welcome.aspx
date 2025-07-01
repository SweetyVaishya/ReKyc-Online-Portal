<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="KycApplication.Welcome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div class="card m-3 p-3" style="background-color: #fdf69e">
                <div class="row">
                    <div class="ml-3">
                        <img src="Content/img/logoabhudaya.png" class="mb-3" style="height: 60%; width: 60%;"/>
                    </div>
                </div>
                 <%--<h6 class="ml-5" ><span > Entered OTP has been successfully submitted.</span></h6>--%>
                <h6 class="ml-5" ><span >OTP has been successfully submitted.</span></h6>
                <div class="mt-2 ml-5" >
                    <p>Dear 
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>

                    <p>
                        Welcome to our Re-KYC portal.<br />
                        Wish you will be able to complete the verification process without any hastel.
                        Incase you come across any difficulty, please contact  us at aml@abhyudayabank.net
                    </p>

                    <p>Thanking you  <br />
                        Abhyudaya Bank. <br />
                        Centralize KYC / AML department, Nerul

                    </p>
                </div>
                <div class="text-center mb-2">
                    <asp:Button ID="continue" class="btn text-light my-3" Style="background-color: #0056ae" runat="server" Text="Continue" OnClick="continue_Click" />
                </div>
            </div>
        </div>
        <div class="col-md-3"></div>

    </div>


</asp:Content>
