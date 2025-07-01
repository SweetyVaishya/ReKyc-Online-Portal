<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddnewUser.aspx.cs" Inherits="KYCApllication_Admin.AddnewUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <div class="card shadow-lg  mt-3" style="background-color: #fdf69e; padding: 5%;">

            <span class="text-center" style="color: #0056ae; font-size: 140%;">Add New User</span><br />
            <asp:Label ID="lbleror" class="text-center" ForeColor="Red" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblmsg" class="text-center mb-3" runat="server" ForeColor="Blue"></asp:Label>


          
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lblname" runat="server" class="text-center" Text="Name:"></asp:Label>
                    <asp:TextBox ID="names" class="form-control" Autocomplete="off" placeholder="Input Name" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="username1" runat="server" class="text-center" Text="User Name:"></asp:Label>
                    <asp:TextBox ID="username" class="form-control" Autocomplete="off" placeholder="Input User Name" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row mt-2">
                <div class="col-md-6">
                    <asp:Label ID="password1" runat="server" class="text-center" Text="Password:"></asp:Label>
                    <asp:TextBox ID="password" Type="password" class="form-control" Autocomplete="off" placeholder="Input password" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="staus" runat="server" class="text-center" Text="Status:"></asp:Label>
                    <asp:DropDownList ID="status" class="form-control pl-2 text-center" runat="server" AutoPostBack="True">
                        <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                        <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                        <asp:ListItem Text="Super Admin" Value="SuperAdmin"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row mt-2">
                <div class="col-md-6">
                    <asp:Label ID="confirmpass1" runat="server" class="text-center" Text="Confirm Password:"></asp:Label>
                    <asp:TextBox ID="confirmpass" Type="password" class="form-control" Autocomplete="off" placeholder="Input password" runat="server"></asp:TextBox>
                </div>

            </div>

            <div class="text-center" style="margin-top: 5%;">
                <asp:Button ID="insert" class="btn" Style="background-color: #0056ae; color: white;" runat="server" Text="Add New User" OnClick="insert_Click" />

            </div>

        </div>
    </div>



</asp:Content>