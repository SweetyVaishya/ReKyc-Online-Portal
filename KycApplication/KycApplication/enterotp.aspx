<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="enterotp.aspx.cs" Inherits="KycApplication.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
 <div class="card mt-3 p-3" style="background-color: #fdf69e">
     <span class="text-center mt-5" style="color:#0056ae; font-size:140%;"> OTP sent to xxxxxx<asp:Label ID="mobno" runat="server" Text=""></asp:Label></span><br />
        <div class="row text-center mt-2">
            <div class="col-md-12">
             
                 
                </div>
        </div>

        <div class="row ">
             <div class="col-md-4"></div>
            <div class="col-md-4 text-center">
                <asp:TextBox ID="otp" CssClass="form-control" MaxLength="6" MinLength="6" placeholder="Enter OTP"  AutoComplete="off" runat="server" ></asp:TextBox>
            </div>
            <div class="col-md-4"></div>
        </div>

     <asp:ScriptManager ID="ScriptManager1" runat="server" />
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>

             <div class="col-md-12 text-center mt-2 mb-5">
                 <%--<span style="color:#0056ae; font-size:140%;"> OTP Countdown:</span>--%>
                    <asp:Label ID="lbleror" runat="server" ForeColor="Red"></asp:Label><br />
                 <asp:Label ID="timerLabel" style="color:#0056ae; font-size:140%;" runat="server" />
                 <asp:Timer ID="Timer1" runat="server"  Interval="1000" OnTick="Timer1_Tick" /><br />

                 <asp:Button ID="Submit" runat="server" Text="Next" class="btn text-light mt-3" Style="background-color: #0056ae; width: 113px;" OnClick="Submit_Click" />&nbsp;&nbsp;&nbsp;
              <asp:Button ID="resendotp" runat="server" Text="Resend OTP" class="btn text-light  mt-3" Visible="false" Style="background-color: #0056ae;" OnClick="resendotp_Click" />
            
                 </div>
         </ContentTemplate>
         <Triggers>
             <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick"/>
         </Triggers>
     </asp:UpdatePanel>

    </div>

</asp:Content>
