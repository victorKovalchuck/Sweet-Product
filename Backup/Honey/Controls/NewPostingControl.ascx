<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewPostingControl.ascx.cs" Inherits="Honey.Controls.NewPostingControl" %>
<%@ Register TagPrefix="honey" Namespace="Honey.Controls" Assembly="Honey"%>

<asp:TextBox ID="txtUserName" placeholder="Name" CssClass="txtUserName" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="reqiedtxtUserName" ControlToValidate="txtUserName" ErrorMessage="Name is required" ValidationGroup="newPostingGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="txtDescription" placeholder="Description" CssClass="txtDescription" runat="server" TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
<asp:RequiredFieldValidator ID="reqiedtxtDescription" ControlToValidate="txtDescription" ErrorMessage="Discription is required" ValidationGroup="newPostingGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
    <honey:MyCheckBox Secured="true" ID="checkShow" runat="server" Text="Show" /><br />
<asp:Button ID="btnSubmit" CssClass="btnSubmit" ValidationGroup="newPostingGroup" runat="server" Text="OK" OnClick="btnSubmit_Click" />

