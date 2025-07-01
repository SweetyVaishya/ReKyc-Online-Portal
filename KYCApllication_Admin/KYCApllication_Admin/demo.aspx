<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="KYCApllication_Admin.demo" %>

 <%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-3">
        <div class="card shadow-lg  mt-3" style="background-color: #fdf69e;">




            <!--label count -->
            <div class="text-center mt-3">
                <asp:Label ID="lblfromto" runat="server" type="date" Style="font-size: 130%;" Text=""></asp:Label>
                <br />
                <asp:Label ID="search_results" runat="server" Style="font-size: medium;" Text="" ForeColor="Red"></asp:Label>

            </div>
            <div class="row">
                <div class="col-md-7">
                    <%--    <asp:TextBox ID="search" type="search" class="form-control" placeholder="Search here" runat="server"></asp:TextBox>
               <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" Text="Search" OnClick="btnSearch_Click"  />--%>
                </div>
                <div class="col-md-3">
                    <p class="text-right">
                        <a href="Managereport.aspx">
                            <asp:Label ID="Viewfurtherreport" Style="color: #016CB2;" runat="server" Text="View further report"></asp:Label></a>
                        &nbsp;&nbsp;
                    </p>
                </div>
                <div class="col-md-2">
                 
                        <asp:LinkButton ID="excelexport" Style="color: #016CB2;" runat="server" >Export to excel</asp:LinkButton>
                    
                </div>
            </div>
        </div>

        <!--Gridview display data -->
        <div class=" table-responsive-lg mt-3 mb-5" style="background-color: #fdf69e;">
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
                                <td><%# Eval("Create_at", "{0:dd/MM/yyyy}")%></td>
                                <td>
                                    <button class="btn text-light" style="background-color: #0056ae"><a class="text-light" href="UpdateStatus.aspx?Kycid=<%# Eval("Kycid")%>">Update</a></button>
                                </td>
                                <td>
                               <span><%# Eval("status")%></span><br />
                                  <span style="font-size:small;" type="date">   <%# Eval("reply_date", "{0:dd/MM/yyyy}")%></span>
            
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </table>

            <asp:Panel runat="server" ID="paginationPanel" class="text-center"></asp:Panel>


        </div>
    </div>

    </form>
</html>


