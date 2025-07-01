<%@ Page EnableEventValidation="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateStatus.aspx.cs" Inherits="KYCApllication_Admin.UpdateStatus" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4 p-4">
        <div class="card shadow-lg " style="background-color: #fdf69e;">

            <div class="row p-5">


                <div class="col-md-12">

                    <img src="Content/img/logoabhudaya.png" class="mb-2" />

                    <div class="text-right mr-5">
                        <asp:Button ID="Button1" Style="font-size: 100%; font-weight: 500; color: #0056ae;"   runat="server" Text="Back" OnClick="Button1_Click1" />
                    </div>
                    <div class="text-center " style="font-size: 200%; font-weight: 500; color: #0056ae;">
                        Status of application submitted.
                    </div>
                    <hr />
                    <div class="my-4">
                        <asp:Label ID="lblmsg" runat="server" Text="" Style="font-size: 150%;" ForeColor="#016cb2"></asp:Label>
                    </div>


                    <%-- bank provided data --%>
                    <h5 class="mt-3">Bank record details :</h5>
                    <asp:Repeater ID="Repeater7" runat="server">
                        <ItemTemplate>
                            <div runat="server">

                                <%--1st row--%>
                                <div class="row mt-3">
                                    <div class="col-md-4">
                                        <label>
                                            Account number

                                        </label>
                                        <asp:TextBox ID="name" CssClass="form-control" runat="server" Text='<%# Eval("AccountNo") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Full name as per Bank detail 
                                        </label>
                                        <asp:TextBox ID="Careof" runat="server" CssClass="form-control" Text='<%# Eval("Name") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Customer id
                                        </label>
                                        <asp:TextBox ID="DOB" CssClass="form-control" runat="server" Text='<%# Eval("cust_no") %>'></asp:TextBox>
                                    </div>


                                </div>

                                <%--2nd row--%>
                                <div class="row mt-3">

                                    <div class="col-md-6">
                                        <label>
                                            Address
                                        </label>
                                        <%-- <asp:TextBox ID="address" CssClass="form-control" runat="server" Text='<%# Eval("CurrentAdd_HA") %>'></asp:TextBox>--%>
                                        <textarea id="address" class="form-control" cols="20" rows="1"><%# Eval("Address") %>,<%# Eval("Address2") %>,<%# Eval("Address3") %>,<%# Eval("pin_code") %>.</textarea>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Mobile number
                                        </label>
                                        <asp:TextBox ID="adharcard_no" runat="server" CssClass="form-control" Text='<%# Eval("Mob_no") %>'></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>
                    <hr />

                    <%--kycapplication data --%>
                    <h5>KYC details submitted :</h5>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div runat="server">

                                <%--1st row--%>
                                <div class="row mt-3">
                                    <div class="col-md-4">
                                        <label>
                                            KYC id
                                        </label>
                                        <asp:TextBox ID="kycid" CssClass="form-control" runat="server" Text='<%# Eval("Kycid") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Name
                                        </label>
                                        <asp:TextBox ID="name" CssClass="form-control" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Email
                                        </label>

                                        <asp:TextBox ID="email" CssClass="form-control" runat="server" Text='<%# Eval("Email_HA") %>'></asp:TextBox>

                                    </div>
                                </div>

                                <%--2nd row--%>
                                <div class="row mt-3">

                                    <div class="col-md-4">
                                        <label>
                                            Account number
                                        </label>

                                        <asp:TextBox ID="accountno" CssClass="form-control" runat="server" Text='<%# Eval("acoount_no") %>'></asp:TextBox>

                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Pan Card
                                        </label>
                                        <asp:TextBox ID="pancard" CssClass="form-control" runat="server" Text='<%# Eval("pancardverify_HA") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Aadhar Card
                                        </label>
                                        <asp:TextBox ID="adharcard" CssClass="form-control" runat="server" Text='<%# Eval("Aadharcardverify_HA") %>'></asp:TextBox>
                                    </div>


                                </div>

                                  <%--3nd row--%>
                                <div class="row mt-3">

                                    <div class="col-md-4">
                                        <label>
                                            Income Source
                                        </label>

                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Text='<%# Eval("IncomeSource_HA") %>'></asp:TextBox>

                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Industry/ Business name
                                        </label>
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Text='<%# Eval("empbussname_HA") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                           Income From
                                        </label>
                                        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" Text='<%# Eval("Incomefrom_HA") %>'></asp:TextBox>
                                    </div>


                                </div>

                                <%--4rd row--%>
                                <div class="row mt-3">

                                     <div class="col-md-4">
                                        <label>
                                            Work Type
                                        </label>

                                        <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" Text='<%# Eval("worktype_HA") %>'></asp:TextBox>

                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Address
                                        </label>
                                        <%-- <asp:TextBox ID="address" CssClass="form-control" runat="server" Text='<%# Eval("CurrentAdd_HA") %>'></asp:TextBox>--%>
                                        <textarea id="address" class="form-control" cols="20" rows="1"><%# Eval("CurrentAdd_HA") %></textarea>
                                    </div>

                                    
                                    <div class="col-md-4">
                                        <label>
                                            Submitted on
                                        </label>

                                        <asp:TextBox ID="Submittedon" CssClass="form-control" runat="server" Text='<%# Eval("Create_at","{0:dd/MM/yyyy}") %>'></asp:TextBox>

                                    </div>
                                </div>
                                <hr />
                                 <%--5 rd row--%>
                                 <h5 class="mt-3">Documents File Name:</h5>
                                <div class="row mt-3">
                                    <div class="col-md-4">
                                        <label>
                                            Pan Card File name
                                        </label>
                                        <asp:TextBox ID="panFile" CssClass="form-control" runat="server" Text='<%#Eval("PancardFileNm") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Aadhar Card File anme 
                                        </label>
                                        <asp:TextBox ID="AdharFile" CssClass="form-control" runat="server" Text='<%# Eval("AadharcardFileNm") %>'></asp:TextBox>
                                    </div>

                                </div>

                                 <div class="row mt-3">
                                        <div class="col-md-12">
                                            <label>
                               Do you want to upload latest Aadhaar Card for updating the OVDs in the Bank ?   &nbsp;  &nbsp; :
                                            </label>
                                              &nbsp;  &nbsp;  &nbsp;
                                            <asp:Label ID="Label1"  runat="server" Text='<%#Eval("AuthorizeAadhar") %>'></asp:Label>
                                            
                                        </div>
                                    </div>

                                  <div class="row mt-3">
                                        <div class="col-md-12">
                                            <label>
                                              Kindly update my PAN number in bank records as per attached PAN card details    &nbsp;  &nbsp; :
                                            </label>
                                            &nbsp;  &nbsp;  &nbsp;
                                            <asp:Label ID="Label2"  runat="server" Text='<%#Eval("AuthorizePan") %>'></asp:Label>
                                            
                                        </div>
                                    </div>
                                </div>
                        </ItemTemplate>

                    </asp:Repeater>
                    <hr />


                    <%--aadhar api data--%>
                    <h5 class="mt-3">Aadhar Card details :</h5>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <div runat="server">

                                <%--1st row--%>
                                <div class="row mt-3">
                                    <div class="col-md-4">
                                        <label>
                                            Full name as per Aadhar Card
                                        </label>
                                        <asp:TextBox ID="name" CssClass="form-control" runat="server" Text='<%# Eval("fullname") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Care of
                                        </label>
                                        <asp:TextBox ID="Careof" runat="server" CssClass="form-control" Text='<%# Eval("care_of") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Aadhar Card number
                                        </label>

                                        <%--<asp:TextBox ID="adharcard_no"  runat="server" Text='<%# Eval("aadhar_card") %>'></asp:TextBox>--%>
                                        <asp:Label ID="adharcard_no" CssClass="form-control" runat="server" Text='<%# "XXXX XXXX " + Eval("aadhar_card").ToString().Substring(Eval("aadhar_card").ToString().Length-4) %>'></asp:Label>

                                    </div>
                                </div>

                                <%--2nd row--%>
                                <div class="row mt-3">

                                    <div class="col-md-6">
                                        <label>
                                            Address
                                        </label>
                                        <%-- <asp:TextBox ID="address" CssClass="form-control" runat="server" Text='<%# Eval("CurrentAdd_HA") %>'></asp:TextBox>--%>
                                        <textarea id="address" class="form-control" cols="20" rows="1"><%# Eval("address") %></textarea>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Date of birth
                                        </label>
                                        <asp:TextBox ID="DOB" CssClass="form-control" runat="server" Text='<%# Eval("DOB") %>'></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>
                    <hr />

                    <%-- Pancard Api data--%>
                    <h5 class="mt-3">Pan Card details :</h5>
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                            <div runat="server">

                                <%--1st row--%>
                                <div class="row mt-3">
                                    <div class="col-md-4">
                                        <label>
                                            Full name as per Pan Card
                                        </label>
                                        <asp:TextBox ID="name" CssClass="form-control" runat="server" Text='<%# Eval("fullname") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Pan Card number
                                        </label>
                                        <asp:TextBox ID="adharcard" CssClass="form-control" runat="server" Text='<%# Eval("Pan_number") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Category
                                        </label>

                                        <asp:TextBox ID="acctype" runat="server" CssClass="form-control" Text='<%# Eval("category") %>'></asp:TextBox>

                                    </div>
                                </div>


                            </div>
                        </ItemTemplate>

                    </asp:Repeater>


                    <%-- Acccount holder 2 details --%>
                    <hr />
                    <div id="holder2" visible="false" runat="server">

                        <h5 class="text-center">Account Holder 2 details</h5>

                        <%--kycapplication data --%>
                        <h5>KYC details submitted :</h5>
                        <asp:Repeater ID="Repeater4" runat="server">
                            <ItemTemplate>
                                <div runat="server">

                                    <%--1st row--%>
                                    <div class="row mt-3">
                                        <div class="col-md-4">
                                            <label>
                                                Pan Card
                                            </label>
                                            <asp:TextBox ID="pancard" CssClass="form-control" runat="server" Text='<%# Eval("pancardverify_HB") %>'></asp:TextBox>
                                        </div>

                                        <div class="col-md-4">
                                            <label>
                                                Aadhar Card
                                            </label>
                                            <asp:TextBox ID="adharcard" CssClass="form-control" runat="server" Text='<%# Eval("Aadharcardverify_HB") %>'></asp:TextBox>
                                        </div>

                                        <div class="col-md-4">
                                            <label>
                                                Email
                                            </label>

                                            <asp:TextBox ID="email" CssClass="form-control" runat="server" Text='<%# Eval("Email_HB") %>'></asp:TextBox>

                                        </div>
                                    </div>


                                      <%--3nd row--%>
                                <div class="row mt-3">

                                    <div class="col-md-4">
                                        <label>
                                            Income Source
                                        </label>

                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Text='<%# Eval("IncomeSource_HB") %>'></asp:TextBox>

                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                            Industry/ Business name
                                        </label>
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Text='<%# Eval("empbussname_HB") %>'></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>
                                           Income From
                                        </label>
                                        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" Text='<%# Eval("Incomefrom_HB") %>'></asp:TextBox>
                                    </div>


                                </div>

                               



                                    <%--4rd row--%>
                                    <div class="row mt-3">
                                        <div class="col-md-4">
                                        <label>
                                            Work Type
                                        </label>

                                        <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server" Text='<%# Eval("worktype_HB") %>'></asp:TextBox>

                                    </div>
                                        <div class="col-md-4">
                                            <label>
                                                Address
                                            </label>
                                            <%-- <asp:TextBox ID="address" CssClass="form-control" runat="server" Text='<%# Eval("CurrentAdd_HA") %>'></asp:TextBox>--%>
                                            <textarea id="address" class="form-control" cols="20" rows="1"><%# Eval("CurrentAdd_HB") %></textarea>
                                        </div>


                                        <div class="col-md-4">
                                            <label>
                                                Submitted on
                                            </label>

                                            <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" Text='<%# Eval("Create_at","{0:dd/MM/yyyy}") %>'></asp:TextBox>

                                        </div>
                                    </div>

                                     


                                       
                                    </div>

                                </div>
                            </ItemTemplate>

                        </asp:Repeater>

                        <%--aadhar api data--%>
                        <h5>Aadhar Card details :</h5>
                        <asp:Repeater ID="Repeater5" runat="server">
                            <ItemTemplate>
                                <div runat="server">

                                    <%--1st row--%>
                                    <div class="row mt-3">
                                        <div class="col-md-4">
                                            <label>
                                                Full name as per Aadhar Card
                                            </label>
                                            <asp:TextBox ID="name" CssClass="form-control" runat="server" Text='<%# Eval("fullname2") %>'></asp:TextBox>
                                        </div>

                                        <div class="col-md-4">
                                            <label>
                                                Care of
                                            </label>
                                            <asp:TextBox ID="acctype" runat="server" CssClass="form-control" Text='<%# Eval("care_of2") %>'></asp:TextBox>
                                        </div>

                                        <div class="col-md-4">
                                            <label>
                                                Aadhar Card number
                                            </label>

                                            <asp:TextBox ID="adharcard" CssClass="form-control" runat="server" Text='<%#  Eval("aadhar_card2") %>'></asp:TextBox>

                                        </div>
                                    </div>

                                    <%--2nd row--%>
                                    <div class="row mt-3">

                                        <div class="col-md-6">
                                            <label>
                                                Address
                                            </label>

                                            <textarea id="address" class="form-control" cols="20" rows="1"><%# Eval("address2") %></textarea>
                                        </div>

                                        <div class="col-md-4">
                                            <label>
                                                Date of birth
                                            </label>
                                            <asp:TextBox ID="email" CssClass="form-control" runat="server" Text='<%# Eval("DOB2") %>'></asp:TextBox>
                                        </div>

                                    </div>

                                </div>
                            </ItemTemplate>

                        </asp:Repeater>

                        <%-- Pancard Api data--%>
                        <h5>Pan Card details :</h5>
                        <asp:Repeater ID="Repeater6" runat="server">
                            <ItemTemplate>
                                <div runat="server">

                                    <%--1st row--%>
                                    <div class="row mt-3">
                                        <div class="col-md-4">
                                            <label>
                                                Full name as per Pan Card
                                            </label>
                                            <asp:TextBox ID="name" CssClass="form-control" runat="server" Text='<%# Eval("fullname2") %>'></asp:TextBox>
                                        </div>

                                        <div class="col-md-4">
                                            <label>
                                                Pan Card number
                                            </label>
                                            <asp:TextBox ID="adharcard" CssClass="form-control" runat="server" Text='<%# Eval("Pan_number2") %>'></asp:TextBox>
                                        </div>

                                        <div class="col-md-4">
                                            <label>
                                                Category
                                            </label>

                                            <asp:TextBox ID="acctype" runat="server" CssClass="form-control" Text='<%# Eval("category2") %>'></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>

                        
                    </div>

                    <hr />

                    



                    <%-- remark textbox--%>

                    <div class="form-group row mt-3">
                        <label>
                            Remarks
                        </label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="remark" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="remark_SelectedIndexChanged" >
                                <asp:ListItem>---Select---</asp:ListItem>
                            <%--    <asp:ListItem>Valid</asp:ListItem>
                                <asp:ListItem>Invalid</asp:ListItem>--%>

                                  <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                            </asp:DropDownList>



                        </div>

                      
                        
                        <asp:Label ID="reasonlbl" runat="server" Text=""></asp:Label>

                        <div id="reason" class="col-md-6" Visible="false" runat="server">
                             
                              <asp:TextBox ID="txtreason" class="form-control" runat="server" TextMode="MultiLine" ></asp:TextBox>

                        </div>


                    </div>


                    <%--submit and back button--%>
                    <div class="form-group row text-center">

                        <div class="col-md-5"></div>
                        <div class="col-md-3 btn-center mt-2 text-center ">
                            <asp:Button ID="Submit" runat="server" Text="Done" class="btn text-light form-control" Style="background-color: #0056ae" OnClick="Submit_Click1" />
                        </div>

                        <div class="col-md-4"></div>
                    </div>




                </div>

            </div>

        </div>
    </div>




</asp:Content>
