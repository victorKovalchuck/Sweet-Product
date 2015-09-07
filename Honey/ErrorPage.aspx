<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Honey.ErrorPage" %>
<%@ Register TagPrefix="honey" TagName="ErrorPage" Src="~/Controls/MasterIsSuccessShowControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <honey:ErrorPage ID="hey" runat="server"></honey:ErrorPage>
</asp:Content>
