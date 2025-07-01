<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="accout_type.aspx.cs" Inherits="KycApplication.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<div style="text-align: right;">

        <asp:Label ID="username" runat="server" Text="" class="ml-auto pr-5" Style="color: #0056ae;"></asp:Label>
    </div>--%>

    <div class="card m-3 p-3" style="background-color: #fdf69e">

        <div class="row text-center mt-5">
            <div class="col-md-12">
                <%-- <h6 ><span style="color:#0056ae"> Entered OTP has been successfully submitted.</span></h6>--%>
                <span class="mt-3" style="color: #0056ae; font-size:150%;"><%--<span style="color:red;">*</span> --%>Select Account type </span><br />
                <asp:Label ID="lbleror" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>



        <div class="row mt-3  mb-5">
            <div class="col-md-12 text-center ">
                <asp:Button ID="individual" runat="server" Text="Individual Account" class="btn text-light" Style="background-color: #0056ae" OnClick="individual_Click" />&nbsp;&nbsp;&nbsp;
             <%--   <asp:Button ID="Join" runat="server" Text="Joint Account" class="btn text-light" Style="background-color: #0056ae;" OnClick="Join_Click" />--%>

            </div>
        </div>

    </div>

</asp:Content>
