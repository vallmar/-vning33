<%@ Page Title="" Language="C#" MasterPageFile="~/Contactslist.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Övning_29.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="ContentMenu" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
 
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    
       <div class="menu">
    <asp:Menu ID="MenuContact" runat="server">
        <Items>
            <asp:MenuItem Text="ADD" Value="ADD"></asp:MenuItem>
            <asp:MenuItem Text="DELETE" Value="DELETE"></asp:MenuItem>
            <asp:MenuItem Text="UPDATE" Value="UPDATE"></asp:MenuItem>
        </Items>
        </asp:Menu>
        </div>
    
<div class="container">
    
  <h2>Table</h2>
  <p>The .table-responsive class creates a responsive table which will scroll horizontally on small devices (under 768px). When viewing on anything larger than 768px wide, there is no difference:</p>                                                                                      
  <div class="table-responsive">          
  <asp:Table class="table" id="personTable" runat="server">
      <asp:TableHeaderRow>
          <asp:TableHeaderCell>Firstname</asp:TableHeaderCell>
          <asp:TableHeaderCell>Lastname</asp:TableHeaderCell>
          <asp:TableHeaderCell>SSN</asp:TableHeaderCell>
         <asp:TableHeaderCell> Adresses </asp:TableHeaderCell>
          <asp:TableHeaderCell>Street</asp:TableHeaderCell>
          <asp:TableHeaderCell>Zip</asp:TableHeaderCell>
          <asp:TableHeaderCell>City</asp:TableHeaderCell>
      </asp:TableHeaderRow>
      
  </asp:Table>
  </div>
</div>
        <asp:ListBox ID="ListBoxAdressPerson" runat="server" OnSelectedIndexChanged="ListBoxAdressPerson_SelectedIndexChanged" AutoPostBack="True" enableEventValidation="false"></asp:ListBox>
    </asp:Content>