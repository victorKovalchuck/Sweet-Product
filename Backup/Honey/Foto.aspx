<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Foto.aspx.cs" Inherits="Honey.Foto" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<style type="text/css">
    
.Panel
{	
	text-align:center;
}
        	
.Image
{
	width:40%;
	height:200px;
	padding:10;
	margin:0;			
}
</style>
<asp:Panel ID="pnlImages" runat="server" CssClass="Panel"></asp:Panel>
</asp:Content>