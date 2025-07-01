<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="KycApplication.Test" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cointainer">
       
        <div class="row">
            <div class="col-md-6">
                <asp:TextBox ID="Name" runat="server">name</asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="account_no" runat="server">account_no</asp:TextBox>
            </div>
        </div>

        <div class="row text-center">
            <asp:Button ID="submit" runat="server" Text="submit" Class="btn-info" OnClick="submit_Click" />

             <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>

</asp:Content>