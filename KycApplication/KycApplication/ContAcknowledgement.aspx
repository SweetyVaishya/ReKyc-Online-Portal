<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContAcknowledgement.aspx.cs" Inherits="KycApplication.ContAcknowledgement" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="card m-3 p-3" style="background-color: #fdf69e">

        <div class="row text-center mt-5">
            <div class="col-md-12">
               <%-- <h1> Thank You </h1>--%>
                <asp:Label ID="lbleror" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>

                <div class="row  mt-2">
                    
                    <div class="col-md-1"></div>
                    <div class="col-md-11">
                        <img src="Content/img/logoabhudaya.png" class="mb-5" style="height:20%;" />
                        <h5>

                            Dear Customer,<br /><br />

                            Thank you very much for successfully completing the application for <br />Re-KYC under Acknowledgement ID :&nbsp;<asp:Label ID="Acknowlodge_no" runat="server" Text=""></asp:Label>, <br />which is subject to Approval by the Bank.<br />
                            <br />
                            Thanking you, <br />
Abhyudaya Bank, Centralised KYC/AML Department"


                   

                        </h5>
                        <%-- <h4>Acknowlodge No:<asp:Label ID="Acknowlodge_no" runat="server" Text=""></asp:Label></h4>

                <h6>Dear Customer</h6>
                <h6>you self declaration E-kyc submitted succesfully</h6>--%>
                
                    </div>
                </div>
           
        <div class="text-center">
            <asp:Button ID="Submit" runat="server" Text="Close" class="btn text-light my-3" style="background-color:#0056ae; " OnClick="Submit_Click"  />
        </div>

    </div>

</asp:Content>