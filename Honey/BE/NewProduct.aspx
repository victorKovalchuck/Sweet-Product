<%@ Page Title="" Language="C#" MasterPageFile="~/BE/BeMaster.Master" AutoEventWireup="true" CodeBehind="NewProduct.aspx.cs" Inherits="Honey.BE.NewProduct" %>
<%@ Register TagPrefix="honey" TagName="NewProductControl" Src="~/Controls/NewProductControl.ascx" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="cntTitle"> 
    NewProduct
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntBody" runat="server">
    <honey:NewProductControl ID="newPrice" runat="server" />
</asp:Content>
