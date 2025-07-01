<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Managereport.aspx.cs" Inherits="KYCApllication_Admin.Managereport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div id="cards" class="card shadow-lg  mt-3" style="background-color: #fdf69e; padding: 4%;" runat="server" visible="true">
        <h5 style="color: #016CB2;">Submitted data!</h5>

        <asp:Label ID="lbleror" runat="server" Text="" Class="text-center" ForeColor="Red"></asp:Label>

        <div class="row">

            <div class="col-md-6">

                <!---name DropDownList-->
                <div class="row mt-3">
                    <div class="col-md-8">
                        <asp:Label ID="Label2" runat="server" class="text-center" Text="Request category:"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" class="form-control pl-2 text-center" runat="server" AutoPostBack="True">
                            <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                            <asp:ListItem Text="Name" Value="name"></asp:ListItem>
                            <asp:ListItem Text="Account Number" Value="account"></asp:ListItem>
                            <asp:ListItem Text="KYC id" Value="kycid"></asp:ListItem>
                           
                        </asp:DropDownList>
                    </div>
                </div>

                <!---Input type-->
                <div class="row mt-3">
                    <div class="col-md-8">
                        <asp:TextBox ID="searchinput" class="form-control" Autocomplete="off" placeholder="Input here..." runat="server"></asp:TextBox>
                    </div>
                </div>

                <!---status DropDownList-->
                <div class="row mt-3">
                    <div class="col-md-8">
                        <asp:Label ID="Selectstatus" runat="server" class="text-center" Text="Select status :"></asp:Label>
                        <asp:DropDownList ID="DropDownList2" class="form-control mt-1 text-center" runat="server">
                            <asp:ListItem Text="---Select---"></asp:ListItem>
                            <asp:ListItem Text="Approved" Value="approved"></asp:ListItem>
                            <asp:ListItem Text="Rejected" Value="rejected"></asp:ListItem>
                            <asp:ListItem Text="Replied" Value="replied"></asp:ListItem>
                            <asp:ListItem Text="Not-replied" Value="notreplied"></asp:ListItem>

                        </asp:DropDownList>
                    </div>
                </div>

            </div>


    <div class="col-md-6 text-center">

        <!---from date-->
        <div class="row mt-3">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-3 ">
                        <asp:Label ID="label3" runat="server" Text="From : "></asp:Label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="From" type="date" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <!---to date-->
        <div class="row mt-3">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="label4" runat="server" Text="To : "></asp:Label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="To" type="date" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>

    </div>


        <!--button--->
    <div class=" row text-center mt-5">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <asp:Button ID="submit" class="btn" Style="background-color: #016CB2; color: white;" runat="server" Text="Submit" OnClick="submit_Click" />

            &nbsp;
                         <asp:Button ID="ViewAll" class="btn" Style="background-color: #016CB2; color: white;" runat="server" Text="View all" OnClick="ViewAll_Click" />
           <%-- &nbsp;
                        <asp:Button ID="excelexport" class="btn" Style="background-color: #016CB2; color: white;" runat="server" Text="Export to excel" />--%>
        </div>
        <div class="col-md-2"></div>

    </div>

    </div>

    <div class="row text-center mt-3">
    <asp:Label ID="search_results" runat="server"  Text="" ForeColor="Red" style="font-size:small;"></asp:Label>
        </div>
    <!--Gridview display data -->
 <div class="container mt-2">

        <div class=" table-responsive-lg mt-3">
            <table id="dtBasicExample" class="table table-striped table-bordered table-sm" cellspacing="0" width="100%">
                <asp:Repeater ID="Repeater2" runat="server">

                    <HeaderTemplate>
                        <thead style="background-color: #0056ae; color: white;">
                            <tr>
                                <th scope="col">Sr No.</th>
                                <th scope="col">KYC Id</th>
                                <th scope="col">Name</th>
                                <th scope="col">Acc Type</th>
                                <th scope="col">Pan Card</th>
                                <th scope="col">Aadhar Card</th>
                                <th scope="col">email</th>
                                <th scope="col">Submitted on</th>
                                <th scope="col">Status</th>
                                  <th scope="col">Remark</th>
                            </tr>
                        </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td class="text-center"><%#  (Container.ItemIndex + 1 ) %></td>
                                <td><%# Eval("Kycid")%></td>
                                <td><%#Eval("Name")%></td>
                                <td><%# Eval("accout_type")%></td>
                                <td><%# Eval("pancardverify_HA")%></td>
                                <td><%# Eval("Aadharcardverify_HA")%></td>
                                <td><%# Eval("Email_HA")%></td>
                                <td><%# Eval("Create_at")%></td>
                                <td>
                                    <button class="btn text-light" style="background-color: #0056ae"><a class="text-light" href="UpdateStatus.aspx?Kycid=<%# Eval("Kycid")%>">Update</a></button>
                                </td>
                                 <td><%# Eval("status")%></td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </table>

            <asp:Panel runat="server" ID="paginationPanel" class="text-right"></asp:Panel>


        </div>

     </div>


    
</div>

</asp:Content>
