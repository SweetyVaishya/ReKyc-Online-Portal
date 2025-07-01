<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SearchDetails.aspx.cs" Inherits="KYCApllication_Admin.SearchDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container mt-4">

       
            <div class="card shadow-lg p-4" style="background-color: #fdf69e; padding:5%;">
                 <div class="row">
            <div class="col-md-2"></div>

            <div class="col-md-8 p-5">

                <div class="text-center"><sapn style="color:#0056ae; font-size:140%;">Search Details</sapn></div>

                <div class="row mt-4">

                    <asp:Label ID="lbleror" runat="server" Text=""></asp:Label>

                    <div class="col-md-6">
                        <asp:Label ID="Label1" runat="server" Text="From "></asp:Label>
                        <asp:TextBox ID="srchfrom" type="date" class="form-control" runat="server"></asp:TextBox>
                    </div>

                       <div class="col-md-6">
                        <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
                        <asp:TextBox ID="srchto" type="date" class="form-control" runat="server"></asp:TextBox>
                    </div>

                </div>

                <div class="text-center mt-4">
                    <asp:Button ID="srch" class="btn" Style="background-color: #016CB2; color: white;" runat="server" Text="Search" OnClick="srch_Click"  />
                </div>


            </div>

            <div class="col-md-2"></div>
        </div>
            </div>

    </div>







    </asp:Content>