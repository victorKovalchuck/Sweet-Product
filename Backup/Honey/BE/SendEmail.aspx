<%@ Page Title="" Language="C#" MasterPageFile="~/BE/BeMaster.Master" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="Honey.BE.SendEmail" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="cntTitle"> 
    SendEmail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntBody" runat="server">
<asp:Label ID="lblAddresses" runat="server" Text=""></asp:Label><br /><br />
<asp:TextBox ID="txtSubject" CssClass="txt" Placeholder="Subject" runat="server" ValidationGroup="newProductGroup"></asp:TextBox>
<asp:RequiredFieldValidator ID="reqiedtxtDescription" ControlToValidate="txtEmail" ErrorMessage="Email is required" ValidationGroup="newProductGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="txtEmail" CssClass="txt" Placeholder="Email" TextMode="MultiLine" Width="100%" Height="100px" runat="server" ValidationGroup="newProductGroup"></asp:TextBox><br />
<asp:Button ID="btnSubmit" CssClass="btnSubmit" runat="server" Text="Вислати" OnClick="btnSend_OnClick" ValidationGroup="newProductGroup" /><br />
</asp:Content>
