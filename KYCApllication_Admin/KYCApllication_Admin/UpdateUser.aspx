<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="KYCApllication_Admin.UpdateUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <div class="card shadow-lg  mt-3" style="background-color: #fdf69e; padding: 5%;">
         <%--   <img src="Content/img/logoabhudaya.png"  />--%>

             <div class="text-right mr-5">
                        <asp:Button ID="Button1" Style="font-size: 100%; font-weight: 500; color: #0056ae;"   runat="server" Text="Back" OnClick="Button1_Click1" />
                    </div>

            <span class="text-center" style="color: #0056ae; font-size: 140%;">Update User</span><br />
            <asp:Label ID="lbleror" class="text-center" ForeColor="Red" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblmsg" class="text-center" runat="server" ForeColor="Blue"></asp:Label>

            <%--<asp:Button ID="Button1" runat="server" Text="Back" />--%>

            <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div runat="server">

                                <%--1st row--%>
                                <div class="row mt-3">
                                    <div class="col-md-4">
                                        <label>
                                           Name
                                        </label>
                                        <asp:TextBox ID="name" CssClass="form-control" runat="server" Text='<%# Eval("name") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                           User Name
                                        </label>
                                        <asp:TextBox ID="username" CssClass="form-control" runat="server" Text='<%# Eval("username") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                           Satus
                                        </label>
                                        <asp:TextBox ID="status" CssClass="form-control" runat="server" Text='<%# Eval("status") %>'></asp:TextBox>
                                    </div>
                                </div>

                              

                               

                            </div>
                        </ItemTemplate>

                    </asp:Repeater>

            <div class="row mt-2">

                  <div class="col-md-4">
                    <label>
                        Status
                    </label>
                    <asp:DropDownList ID="status" class="form-control pl-2 text-center" runat="server" AutoPostBack="True">
                        <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                        <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                        <asp:ListItem Text="Super Admin" Value="SuperAdmin"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-md-4">
                    <label>
                        Password
                    </label>
                    <asp:TextBox ID="password" CssClass="form-control" runat="server" ></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <label>
                        Confirm Password
                    </label>
                    <asp:TextBox ID="confirmpassword" CssClass="form-control" runat="server" ></asp:TextBox>
                </div>


             </div>

          

            <div class="text-center" style="margin-top: 5%;">
                <asp:Button ID="insert" class="btn" Style="background-color: #0056ae; color: white;" runat="server" Text="Update" OnClick="insert_Click"  />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="delete" class="btn" Style="background-color: #0056ae; color: white;" runat="server" Text="Delete" OnClick="delete_Click"  />

            </div>

        </div>
    </div>



</asp:Content>