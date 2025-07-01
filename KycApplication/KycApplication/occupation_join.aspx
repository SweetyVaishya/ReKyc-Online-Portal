<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="occupation_join.aspx.cs" Inherits="KycApplication.occupation_join" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <%-- <div style="text-align: right;">

        <asp:Label ID="username" runat="server" Text="" class="ml-auto pr-5" Style="color: #0056ae;"></asp:Label>
    </div>--%>

    <div class="card m-3 p-3" style="background-color: #fdf69e">

        <div class="row mt-3">
            <div class="col-md-12 text-center">
                <span class="text-center" style="color: #0056ae; font-size:160%;">Occupation</span><br />
                <%-- <span style="color: red;">*</span>--%><asp:Label ID="Label1" runat="server" Text="All fields are mandatory."></asp:Label><br />
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>

        <div class="row mt-3">

            <!---A/C Holder A--->
            <div class="col-md-1"></div>
            <div class="col-md-5">
                <div class="container">
                    <span style="color: #0056ae; font-size:110%;">First Account Holder</span>
                    <div class="row mt-2">
                        <div class="col-md-10">
                            <%-- <span style="color: red;">*</span>--%>
                           <span ><asp:Label ID="from1" runat="server" Text="Source of income :"></asp:Label></span>
                            <asp:DropDownList ID="incometypeA" runat="server" class="form-control">
                                <asp:ListItem Value="">---select--- </asp:ListItem>
                                <asp:ListItem>Salaried</asp:ListItem>
                                <asp:ListItem>Business</asp:ListItem>
                                <asp:ListItem>Self Employed</asp:ListItem>
                                <asp:ListItem>Retired / Housewife/Students </asp:ListItem> 
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-10">
                            <%--<span style="color: red;">*</span>--%>
                <asp:Label ID="empname1A" runat="server" Text="Name of Employer / Business / Industry"></asp:Label>
                            <asp:TextBox ID="empnameA" class="form-control" AutoComplete="off" placeholder="Name of Employer / Business / Industry" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-10">
                            <%-- <span style="color: red;">*</span>--%>
                            <asp:Label ID="indutype1A" runat="server" Text="Industry/Bussiness Type"></asp:Label>

              <asp:TextBox ID="indutypeA"  class="form-control" AutoComplete="off" placeholder="Enter Industry/ Bussiness Type" runat="server"></asp:TextBox>

                          <%--  <asp:DropDownList ID="indutypeA" class="form-control" runat="server">
                                <asp:ListItem Value="">select </asp:ListItem>
                                <asp:ListItem>IT</asp:ListItem>
                                <asp:ListItem>MARKETING</asp:ListItem>
                                <asp:ListItem>FARMING</asp:ListItem>
                                <asp:ListItem>OTHER</asp:ListItem>
                            </asp:DropDownList>--%>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-10">
                            <%--<span style="color: red;">*</span>--%>
                <asp:Label ID="yearsfServiceBusinessHA" runat="server" Text="Number of years in service / business :"></asp:Label>
                            <asp:TextBox ID="YearsOfServiceBusinessHA" class="form-control" AutoComplete="off" placeholder="Number of years in service / business" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <%--<span style="color: red;">*</span>--%>
                    <asp:Label ID="incomerengeA" runat="server" Text="Amount income range  (in lakhs)"></asp:Label>
                    <div class="row">

                        <div class="col-md-10">


                            <%--<span ><asp:Label ID="Label6" runat="server" Text="From"></asp:Label></span>--%>
                            <asp:DropDownList ID="fromA" runat="server" class="form-control">
                                 <asp:ListItem Value="">---select--- </asp:ListItem>
                                <asp:ListItem>Up to Rs. 1 Lakh</asp:ListItem>
                                <asp:ListItem>Above 1 Lakh to Rs. 5 Lakh</asp:ListItem>
                                <asp:ListItem>Above 5 Lakh to Rs. 10 Lakh</asp:ListItem>
                                <asp:ListItem>Above 10 Lakh to Rs. 20 Lakh</asp:ListItem>
                                <asp:ListItem>Above Rs. 20 Lakh</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                       <%-- <div class="col-md-5">
                    
                            <asp:DropDownList ID="toA" runat="server" class="form-control">
                                <asp:ListItem Value="">To  select </asp:ListItem>
                                <asp:ListItem>5 </asp:ListItem>
                                <asp:ListItem>10 </asp:ListItem>
                                <asp:ListItem>15 </asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>
                    </div>
                </div>
            </div>



            <!-- A/C Holder B-->
            <div class="col-md-1"></div>
            <div class="col-md-5">
                <div class="container">
                    <span style="color: #0056ae; font-size:110%;">Second Account Holder</span>

                    <div class="row mt-2">
                        <div class="col-md-10">
                            <%--  <span style="color: red;">*</span>--%>
                            <span ><asp:Label ID="Label2" runat="server" Text="Source of income :"></asp:Label></span>
                            <asp:DropDownList ID="incometypeB" runat="server" class="form-control">
                                <asp:ListItem Value="">---select--- </asp:ListItem>
                                <asp:ListItem>Salaried</asp:ListItem>
                                <asp:ListItem>Business</asp:ListItem>
                                <asp:ListItem>Self Employed</asp:ListItem>
                                <asp:ListItem>Retired / Housewife/Students </asp:ListItem> 
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-10">
                            <%--<span style="color: red;">*</span>--%>
                <asp:Label ID="empname2B" runat="server" Text="Name of Employer / Business / Industry"></asp:Label>
                            <asp:TextBox ID="empnameB" class="form-control" runat="server" AutoComplete="off" placeholder="Name of Employer / Business / Industry"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-10">
                            <%--                <span style="color: red;">*</span>--%>
                            <asp:Label ID="indutype2B" runat="server" Text="Industry/Bussiness Type"></asp:Label>

      <asp:TextBox ID="indutypeB"  class="form-control" AutoComplete="off" placeholder="Enter Industry/ Bussiness Type" runat="server"></asp:TextBox>



                           <%-- <asp:DropDownList ID="indutypeB" class="form-control" runat="server">
                                <asp:ListItem Value="">select </asp:ListItem>
                                <asp:ListItem>IT</asp:ListItem>
                                <asp:ListItem>MARKETING</asp:ListItem>
                                <asp:ListItem>FARMING</asp:ListItem>
                                <asp:ListItem>OTHER</asp:ListItem>
                            </asp:DropDownList>--%>
                        </div>
                    </div>

                     <div class="row">
                        <div class="col-md-10">
                            <%--<span style="color: red;">*</span>--%>
                <asp:Label ID="yearsfServiceBusinessHB" runat="server" Text="Number of years in service / business :"></asp:Label>
                            <asp:TextBox ID="YearsOfServiceBusinessHB" class="form-control" AutoComplete="off" placeholder="Number of years in service / business" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <%-- <span style="color: red;">*</span>--%>
                    <asp:Label ID="incomerengeB" runat="server" Text="Amount income range (in lakhs)"></asp:Label>
                    <div class="row">

                        <div class="col-md-10">


                            <%-- <span ><asp:Label ID="Label12" runat="server" Text="From"></asp:Label></span>--%>
                            <asp:DropDownList ID="fromB" runat="server" class="form-control">
                                <asp:ListItem Value="">---select--- </asp:ListItem>
                                <asp:ListItem>Up to Rs. 1 Lakh</asp:ListItem>
                                <asp:ListItem>Above 1 Lakh to Rs. 5 Lakh</asp:ListItem>
                                <asp:ListItem>Above 5 Lakh to Rs. 10 Lakh</asp:ListItem>
                                <asp:ListItem>Above 10 Lakh to Rs. 20 Lakh</asp:ListItem>
                                <asp:ListItem>Above Rs. 20 Lakh</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%--<div class="col-md-5">

                            <asp:DropDownList ID="toB" runat="server" class="form-control">
                                <asp:ListItem Value="">To  select </asp:ListItem>
                                <asp:ListItem>5 </asp:ListItem>
                                <asp:ListItem>10 </asp:ListItem>
                                <asp:ListItem>15 </asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>


        <div class="row my-3">
            <div class="col-md-12 text-center">
                <asp:Button ID="Submit" runat="server" Text="Submit" class="btn text-light" Style="background-color: #0056ae;" OnClick="Submit_Click" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8" style="font-size: medium; color: #0056ae;">
                <p class="mt-4 text-center">
                    <b>Note:</b>
                    Once you complete this page the submission process gets over.
                </p>
            </div>
        </div>

    </div>

</asp:Content>
