<%@ Page Title="" Language="C#" MasterPageFile="~/Contactslist.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Övning_29.WebForm1" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <body>
    

        <%--//DROPDOWN MENU--%>


        <nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav">
   
        <li class="dropdown">
          <a class="dropdown-toggle" data-toggle="dropdown" href="#">Add <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href ="#" data-toggle="modal" data-target="#myModalAdd">Contact</a></li>
            <li><a href="#">Adress</a></li>
          </ul>
        </li>
        <li><a href="#">Play Sims</a></li>
        <li><a href="#">Buy drugs<a href="http://www.cornify.com" onclick="cornify_add();return false;"><img src="http://www.cornify.com/assets/cornify.gif" width="61" height="16" border="0" alt="Cornify" /></a><script type="text/javascript" src="http://www.cornify.com/js/cornify.js"></script></a></li>
      </ul>
      <ul class="nav navbar-nav navbar-right">
        <li><a href="#"><span class="glyphicon glyphicon-user"></span> Sign Up</a></li>
        <li><a href="#"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>
      </ul>
    </div>
  </div>
</nav>
  





    <div class="bigBody">

        <!-- Modal -->
<div id = "myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type = "button" class="close" data-dismiss="modal">&times;</button>
         <h4 class="modal-title">
             <asp:Label ID="lblContactnameModal" runat="server" Text=""></asp:Label></h4>
      </div>
      <div class="modal-body">

          <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />

      </div>
      <div class="modal-footer">
          <asp:Button class="btn btn-default" id="btnDelete" data-dismiss="modal" onclick="btnDelete_Click" runat="server" Text="Delete"/>
          
          <asp:Button class="btn btn-default" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
        <button type = "button" class="btn btn-default" data-dismiss="modal">Close</button>
          <a href="http://www.cornify.com" onclick="cornify_add();return false;"><img src="http://www.cornify.com/assets/cornify.gif" width="61" height="16" border="0" alt="Cornify" /></a><script type="text/javascript" src="http://www.cornify.com/js/cornify.js"></script>
      </div>
    </div>

  </div>
</div>





        <!-- Second Modal -->
<div id = "myModalAdd" class="modal fade" role="dialog" >
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type = "button" class="close" data-dismiss="modal">&times;</button>
         <h4 class="modal-title">
             <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h4>
      </div>
      <div class="modal-body">
        
          <asp:Label ID="Label7" runat="server" Text="Firstname"></asp:Label>
        <asp:TextBox ID="TextBoxFirstnameADD" runat="server" CssClass="contactDetailTxt"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" Text="Lastname"></asp:Label>
        <asp:TextBox ID="TextBoxLastnameADD" runat="server" CssClass="contactDetailTxt"></asp:TextBox>
            <asp:Label ID="Label10" runat="server" Text="SSN"></asp:Label>
        <asp:TextBox ID="TextBoxSSNADD" runat="server" CssClass="contactDetailTxt"></asp:TextBox>
            <asp:Label ID="Label11" runat="server" Text="Street Adress"></asp:Label>
            <asp:TextBox ID="TextBoxStreetADD" runat="server"></asp:TextBox>
            <asp:Label ID="Label12" runat="server" Text="Zip-code"></asp:Label>
            <asp:TextBox ID="TextBoxZipADD" runat="server"></asp:TextBox>
            <asp:Label ID="Label13" runat="server" Text="City"></asp:Label>
            <asp:TextBox ID="TextBoxCityADD" runat="server"></asp:TextBox>
     

      </div>
      <div class="modal-footer">
           <asp:Button ID="ButtonAddContact" class="btn btn-default" runat="server" OnClick="btnAddContact_Click" Text="Add" />
         
        <button type = "button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>




        <%--Contact Main List--%>
        <div class="contacts">
          
                </div>
            <div class="listBox">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ContactsConnectionString1 %>" ProviderName="<%$ ConnectionStrings:ContactsConnectionString1.ProviderName %>" SelectCommand="SELECT [ID], [Firstname], [Lastname], [SSN] FROM [Contact]"></asp:SqlDataSource>
    <asp:ListBox ID="listBoxContacts" runat="server" Height="355px" Width="185px" OnSelectedIndexChanged="listBoxContacts_SelectedIndexChanged" AutoPostBack="True" Font-Names="Microsoft Sans Serif" Font-Size="Medium"></asp:ListBox>
                

<%--                Button for modal--%>
            </div><button type="button" class="btn btn-info btn-lg" id="viewContact"data-toggle="modal" data-target="#myModal" /> View contact</div> 

        <div class="contactDetails">
            <a href="#" onclick="window.location.href='./WebForm2.aspx?id='+$('#ContentPlaceHolderMain_listBoxContacts').val()">WebForm2.aspx</a>
            </div>
        
            
        
        
 
</body>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
    </asp:Content>
