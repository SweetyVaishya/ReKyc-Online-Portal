<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="KYCApllication_Admin.ManageUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <div class="container mt-3 mb-5">
        <div class="card shadow-lg p-3 mt-3" style="background-color: #fdf69e;">

            <!--label count -->
            <div class="text-center mt-3">
                 <span class="text-center" style="color: #0056ae; font-size: 140%;">Manage User</span><br />
            </div>

                    <span class="text-right">
                        <a href="AddnewUser.aspx">
                            <asp:Label ID="Viewfurtherreport" Style="color: #016CB2;" runat="server" Text="Add new user"></asp:Label></a>
                        &nbsp;&nbsp;
                    </span>
                
               
           
        </div>
         <div class="text-center">
           <asp:Label ID="search_results"  runat="server" Style="font-size: small;" Text="" ForeColor="Red"></asp:Label>
             </div>
        <!--Gridview display data -->
        <div class=" table-responsive-lg mt-3" style="background-color: #fdf69e;">
            <table id="dtBasicExample" class="table table-striped table-bordered table-sm" cellspacing="0" width="100%">
                <asp:Repeater ID="Repeater2" runat="server">

                    <HeaderTemplate>
                        <thead style="background-color: #0056ae; color: white;">
                            <tr class="text-center">
                                <th scope="col">&nbsp;&nbsp;Sr No.</th>
                                <th scope="col">Name</th>
                                <th scope="col">username</th>
                                <th scope="col">Status</th>
                                <th scope="col">Created on</th>
                                <th scope="col">Action</th>
                            </tr>
                        </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="text-center">
                                  <td class="text-center"><%#Eval("SrNo") %></td>
                                <td><%#Eval("name")%></td>
                                <td><%# Eval("username")%></td>
                                <td><%# Eval("status")%></td>
                                <td><%# Eval("craete_at" , "{0:dd/MM/yyyy}")%></td>
                                <td class="text-center">
                                    <button class="btn text-light" style="background-color: #0056ae"><a class="text-light" href="UpdateUser.aspx?username=<%# Eval("username")%>">Update</a></button>
                                   
                                </td>
                                
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </table>

            <asp:Panel runat="server" ID="paginationPanel" class="text-center"></asp:Panel>


        </div>


         
    </div></asp:Content>

