<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DtlsReport.aspx.cs" Inherits="KYCApllication_Admin.DtlsReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row mt-3 mb-5">

        <div class="col-md-1"></div>

           <div class="col-md-10">

        <div class="card shadow-lg p-3 mt-3" style="background-color: #fdf69e;" >




            <!--label count -->
            <div class="text-center mt-3">
                <asp:Label ID="lblfromto" runat="server" type="date" Style="font-size: 130%;" Text=""></asp:Label>
                <br />
                <asp:Label ID="search_results" runat="server"  Text="" ForeColor="Red" style="font-size:medium;"></asp:Label>
            </div>
             <div class="row">
                <div class="col-md-7">
                 
                </div>
                <div class="col-md-3">
                    <p class="text-right">
                        <a href="SearchDetails.aspx">
                            <asp:Label ID="Viewfurtherreport" Style="color: #016CB2;" runat="server" Text="View further report"></asp:Label></a>
                        &nbsp;&nbsp;
                    </p>
                </div>
                <div class="col-md-2">
                    
                        <asp:LinkButton ID="excelexport" Style="color: #016CB2;" runat="server" OnClick="excelexport_Click">Export to excel</asp:LinkButton>
                    
                </div>
            </div>
        </div>

        <!--Gridview display data -->
        <div class=" table-responsive-lg mt-3">
            <table id="dtBasicExample" class="table table-striped table-bordered table-sm" cellspacing="0" width="100%"  style="background-color: #fdf69e;">
                <asp:Repeater ID="Repeater2" runat="server">

                    <HeaderTemplate>
                        <thead style="background-color: #0056ae; color: white;">
                            <tr>
                                <th scope="col">Sr No.</th>
                                <th scope="col">Account Number</th>
                                <th scope="col">Name</th>
                                <th scope="col">Mobile No</th>
                                <th scope="col">Customer No</th>
                                <th scope="col">Address</th>
                                <th scope="col">Address1</th>
                                <th scope="col">Address2</th>
                                <th scope="col">Pincode</th>
                                  <th scope="col">Pancard</th>
                                  <th scope="col">Risk</th>
                            </tr>
                        </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                  <td class="text-center"><%#Eval("SrNo") %></td>
                                <td><%# Eval("AccountNo")%></td>
                                <td><%#Eval("Name")%></td>
                                <td><%# Eval("Mob_no")%></td>
                                <td><%# Eval("cust_no")%></td>
                                <td><%# Eval("Address")%></td>
                                <td><%# Eval("Address2")%></td>
                                <td><%# Eval("Address3")%></td>
                                <td><%# Eval("pin_code")%></td>
                                <td><%# Eval("pancard")%></td>
                                  <td><%# Eval("Risk")%></td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </table>

            <asp:Panel runat="server" ID="paginationPanel" class="text-center"></asp:Panel>


        </div>

                </div>
           <div class="col-md-1"></div>
    </div>





    </asp:Content>