<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditSubscriberControl.ascx.cs" Inherits="Honey.Controls.EditSubscriberControl" %>
Email:<br />
<asp:TextBox ID="txtEmail" placeholder="Email" CssClass="txt" runat="server"></asp:TextBox><br />
IsActive:<br />
<asp:TextBox ID="txtIsActive" placeholder="Email" CssClass="txt" runat="server"></asp:TextBox><br />
Created At:<br />
<asp:TextBox ID="txtCreatedAt" placeholder="Email" CssClass="txt" runat="server"></asp:TextBox><br />
Updated At:<br />
<asp:TextBox ID="txtUpdatedAt" placeholder="Email" CssClass="txt" runat="server"></asp:TextBox><br />

<asp:Button ID="btnSubmit" CssClass="btnSubmit" runat="server" Text="OK" OnClick="btnSubmit_Click" />
