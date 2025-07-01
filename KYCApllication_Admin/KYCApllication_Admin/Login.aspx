<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KYCApllication_Admin._Default" %>

<%--MasterPageFile="~/Site.Master"--%>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="Content/css/bootstrap.css" rel="stylesheet" />
    <link href="Content/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Content/js/bootstrap.js"></script>
    <script src="Content/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <nav class="navbar navbar-expand-lg sticky-top navbar-light " style="background-color: #ffe600;">

            <a class="navbar-brand" href="https://www.abhyudayabank.co.in/english/home.aspx">
                <img src="Content/img/logoabhudaya.png" class="pl-5" /></a>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav ml-auto pr-5">

                    <span style="color: #0056ae; font-size: 250%;">Online Re-KYC Portal</span>


                </ul>

            </div>
        </nav>
        <nav class="navbar sticky navbar-expand-lg  " style="background-color: #016CB2; color: black;">

            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon">
                    <img src="Content/img/menu7666.png" style="height: 100%; width: 100%;" />
                </span>
            </button>

            <div class="collapse navbar-collapse " id="navbarSupportedContent">
            </div>
        </nav>

        <div class="container mb-5 mt-5">


            <div class="row  ">

                <div class="col-md-3">
                </div>

                <div class="col-md-6 px-5">
                    <div class="card shadow-lg p-5 " style="background-color: #fdf69e;">

                        <span class="text-center" style="color: #0056ae; font-size: 170%;">
                            <img src="Content/img/lockimg3.png" style="height: 20%; width: 10%;" />
                            Login</span>

                        <asp:Label ID="lbleror" runat="server" ForeColor="Red" Text=""></asp:Label>

                        <div class="row mt-1">
                            <asp:Label ID="Label1" runat="server" Text="User Name : "></asp:Label>
                            <asp:TextBox ID="Username" MaxLength="10" class="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>

                        <div class="row mt-2">
                            <asp:Label ID="Label2" runat="server" Text="Password : "></asp:Label>
                            <asp:TextBox ID="Password" Type="password" MaxLength="11" AutoComplete="off" class="form-control" runat="server"></asp:TextBox>

                        </div>

                        <div class="row mt-2">
                            <asp:Label ID="captcha" runat="server" Text="Captcha : "></asp:Label>
                            <asp:TextBox ID="txtcaptcha" class="form-control " MaxLength="6"
                                EnableViewState="False" runat="server"></asp:TextBox>
                        </div>
                        <div class="row mt-2">
                            <div class="col-md-5">
                                <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="Low"
                                CaptchaLength="6" CaptchaHeight="31" CaptchaWidth="140" CaptchaLineNoise="None"
                                CaptchaMinTimeout="5" CaptchaMaxTimeout="240" Height="31px" Width="140px" BorderColor="#E7E4D3"
                                BackColor="#E7E4D3" BorderStyle="Solid" BorderWidth="1px" Font-Italic="true" ForeColor="#7A6802" CssClass="mt-3" />
                            </div>
                            <div class="col-md-6 pt-2" style="margin-top:5%; margin-left:2%;">


                                <asp:LinkButton ID="LinkButton1" runat="server" ImageUrl="Content/img/refresh-icon.png" ToolTip="Refresh Captcha" TabIndex="23" height="100%" >
                                    <img src="Content/img/refresh-icon.png" style="width:100%; height:100%;" />
                                </asp:LinkButton>

                            </div>
                            
                        </div>

                        <div class=" row text-center mt-5">
                            <asp:Button ID="Button1" class="btn text-light form-control" Style="background-color: #0056ae" runat="server" Text="Submit" OnClick="Button1_Click1" />
                        </div>

                    </div>
                </div>

                <div class="col-md-3">
                </div>

            </div>

        </div>

        <footer class="fixed-bottom" style="background-color: #ffffff;">
            <hr />
            <img src="Content/img/chiclogo-bg.jpg" style="height: 50px; width: 145px" class="ml-5" />
        </footer>
    </form>
</body>
</html>
