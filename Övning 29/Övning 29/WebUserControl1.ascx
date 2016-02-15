<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="Övning_29.WebUserControl1" %>


<div class="headerUserControl">

</div>
<div class="mainUserControl">
<asp:Label ID="lblFirstnameUserControl" runat="server" Text="Firstname"></asp:Label>
        <asp:TextBox ID="txtBoxFirstnameUserControl" runat="server" CssClass="contactDetailTxt"></asp:TextBox>
            <asp:Label ID="lblnameUserControl" runat="server" Text="Lastname"></asp:Label>
        <asp:TextBox ID="txtBoxLastUserControl" runat="server" CssClass="contactDetailTxt"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="SSN"></asp:Label>
        <asp:TextBox ID="txtBoxSSNUserControl" runat="server" CssClass="contactDetailTxt"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Street Adress"></asp:Label>
            <asp:TextBox ID="txtBoxStreetUserControl" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Zip-code"></asp:Label>
            <asp:TextBox ID="txtBoxZipUserControl" runat="server"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="City"></asp:Label>
            <asp:TextBox ID="txtBoxCityUserControl" runat="server"></asp:TextBox>
          <asp:Label ID="Label8" runat="server" Text="All adresses"></asp:Label>
          <asp:ListBox ID="ListBoxAdresseUserControl" runat="server" AutoPostBack="True"></asp:ListBox>
</div>
<div class="footerUserControl"></div>
    
