 <%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="occupation_individual.aspx.cs" Inherits="KycApplication.occupation" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <%-- <div style="text-align: right;">

        <asp:Label ID="username" runat="server" Text="" class="ml-auto pr-5" Style="color: #0056ae;"></asp:Label>
    </div>--%>



    <div class="card m-3 p-3" style="background-color: #fdf69e">

        <div class="row mt-5">
            <div class="col-md-12 text-center">
                <span class="text-center" style="color: #0056ae; font-size:140%;">Occupation</span><br />
                <asp:Label ID="Label6" runat="server" Text="All fields are mandatory."></asp:Label><br />
                <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
        </div>

        

        <div class="row">
            <div class="col-md-4"></div>

            <div class="col-md-8">
                <div class="container">

                    <div class="row mt-4">
                        <div class="col-md-6">
                            <%--<span style="color: red;">*</span>--%>

                            <div class="row">

                        <div class="col-md-12">
                             <span ><asp:Label ID="from1" runat="server" Text="Occupation :"></asp:Label></span>
                            <asp:DropDownList ID="incomesource" runat="server" class="form-control">
                                <asp:ListItem Value="">---select--- </asp:ListItem>
                                <asp:ListItem>SALARIED EMPLOYEE</asp:ListItem>
                                 <asp:ListItem>HOUSEWIFE</asp:ListItem>
                                 <asp:ListItem>SMALL BUSINESS</asp:ListItem>
                                 <asp:ListItem>ARTISANS AND CRAFTSMAN</asp:ListItem>
                                 <asp:ListItem>DOCTOR</asp:ListItem>
                                 <asp:ListItem>ADVOCATE</asp:ListItem>
                                 <asp:ListItem>CONSULTANT</asp:ListItem>
                                 <asp:ListItem>ARCHITECT</asp:ListItem>
                                 <asp:ListItem>TRANSPORT OPERATOR</asp:ListItem>
                                 <asp:ListItem>SOFTWARE CONSULTANT</asp:ListItem>
                                 <asp:ListItem>BUSINESSMAN</asp:ListItem>
                                 <asp:ListItem>SELF EMPLOYED</asp:ListItem>
                                 <asp:ListItem>SPORTSMAN</asp:ListItem>
                                <asp:ListItem>DRIVER</asp:ListItem>
                                <asp:ListItem>BUSINESSWOMAN</asp:ListItem>
                                <asp:ListItem>CONTRACTOR</asp:ListItem> 
                                 <asp:ListItem>RETIRED</asp:ListItem> 
                                 <asp:ListItem>STUDENT</asp:ListItem> 
                                 <asp:ListItem> INTERNATIONAL FIGURE</asp:ListItem> 
                                 <asp:ListItem>OTHERS</asp:ListItem> 
                                 <asp:ListItem>CONDUCTOR</asp:ListItem> 
                                  <asp:ListItem>GOVT AGENCY</asp:ListItem> 
                                  <asp:ListItem>ANTIQUE DEALERS</asp:ListItem> 
                                  <asp:ListItem>MONEY SERVICE BUREAU</asp:ListItem> 
                                  <asp:ListItem>DEALERS IN ARMS</asp:ListItem> 
                                  <asp:ListItem>BULLION TRADERS</asp:ListItem> 
                                  <asp:ListItem>POLITICALLY EXPOSED PERSONS(FORIEGN)</asp:ListItem> 
                                  <asp:ListItem>PROFESSIONAL</asp:ListItem> 
                                  <asp:ListItem>Service-Pvt Sector</asp:ListItem> 
                                  <asp:ListItem>Service-Public Sector</asp:ListItem> 
                                  <asp:ListItem>Service-Govt Sector</asp:ListItem> 
                            </asp:DropDownList>
                        </div>
                       
                    </div>
                      
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <%--<span style="color: red;">*</span>--%>
                <asp:Label ID="employename1" runat="server" Text="Employer / Business Details"></asp:Label>
                            <asp:TextBox ID="employename" class="form-control" AutoComplete="off" placeholder="Name of Employer/Business/Industry" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                       
                            <asp:Label ID="industrytype1" runat="server" Text="Industry/ Bussiness Type"></asp:Label>

                            <asp:TextBox ID="industrytype"  class="form-control" AutoComplete="off" placeholder="Enter Industry/ Bussiness Type" runat="server"></asp:TextBox>
                     
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                      
                <asp:Label ID="yearsfServiceBusiness" runat="server" Text="Number of years in service / business :"></asp:Label>
                            <asp:TextBox ID="YearsOfServiceBusiness" class="form-control" AutoComplete="off" placeholder="Number of years in service / business" runat="server"></asp:TextBox>
                        </div>
                    </div>

              
                    <asp:Label ID="Label1" runat="server" Text="Gross Annual Income"></asp:Label>
                    <div class="row">

                        <div class="col-md-6">

                            <asp:DropDownList ID="from" runat="server" class="form-control">
                                <asp:ListItem Value="">---select--- </asp:ListItem>
                                <asp:ListItem>Up to Rs. 1 Lakh</asp:ListItem>
                                <asp:ListItem>Above 1 Lakh to Rs. 5 Lakh</asp:ListItem>
                                <asp:ListItem>Above 5 Lakh to Rs. 10 Lakh</asp:ListItem>
                                <asp:ListItem>Above 10 Lakh to Rs. 20 Lakh</asp:ListItem>
                                <asp:ListItem>Above Rs. 20 Lakh</asp:ListItem>
                                
                            </asp:DropDownList>
                        </div>
                       
                    </div>

                    <div class="row mt-4">
                        <div class="col-md-6 text-center">
                            <asp:Button ID="Submit" runat="server" Text="Submit" class="btn text-light" Style="background-color: #0056ae;" OnClick="Submit_Click" />
                        </div>
                    </div>

                </div>
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
