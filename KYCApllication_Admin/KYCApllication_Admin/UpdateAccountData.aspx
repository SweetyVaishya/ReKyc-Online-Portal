<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateAccountData.aspx.cs" Inherits="KYCApllication_Admin.UpdateAccountData" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


     <div class="container">
    
        <div class="card shadow-lg  mt-3" style="background-color: #fdf69e; padding:5%;">

         <span class="text-center" style="color:#0056ae; font-size:140%;">Add New Accounts</span><br />

              <span class="text-right" style="color:#0056ae; font-size:120%;"><a href="SearchDetails.aspx">Search Accounts</a></span><br />
             <span class="text-center" style="color:#0056ae;"> <asp:Label ID="lblerror" runat="server" Text=""></asp:Label></span>

            <div class="row mt-2">
                <div class="col-md-2"></div>
                <div class="col-md-3 text-right mt-2">
                    <asp:Label ID="Label1" runat="server" Text="Upload excel file  : "></asp:Label>
                </div>
                <div class="col-md-4">
                        <asp:FileUpload ID="FileUpload1"  class=" form-control " style="padding-bottom:12%;" runat="server" />
                </div>
            </div>

            <div class="text-center" style="margin-top:5%;">
                <asp:Button ID="insert" class="btn" style="background-color: #0056ae; width:100px; color:white;" runat="server" Text="Insert" OnClick="insert_Click" />
                &nbsp;&nbsp;<asp:button id="delete" style="background-color: #0056ae; width:100px; color:white;" class="btn" runat="server" text="delete" onclick="delete_click" />
            </div>

           </div>
       
    </div>
    </asp:content>