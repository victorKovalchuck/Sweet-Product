<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Honey.BE.Login" %>
<html>
<head id="Head1" runat="server">
<style type="text/css">
body,html
{
	padding:10;
	text-align:center;
}
#txtUsername,#txtPassword
{
margin:10;	
}

</style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div id="lblMessage" class="Error" runat="server" visible="false"/>
    <div>     
    <asp:TextBox ID="txtUsername" CssClass="txt" runat="server" Placeholder="UserName"></asp:TextBox> <br />
    <asp:TextBox ID="txtPassword" CssClass="txt" runat="server" Placeholder="Password" TextMode="Password"></asp:TextBox>  <br />
    <asp:Button ID="btnSubmit" CssClass="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Onclick" />
    </div>
    </form>
</body>    
</html>