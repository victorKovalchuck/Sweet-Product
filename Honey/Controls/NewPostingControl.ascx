<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewPostingControl.ascx.cs" Inherits="Honey.Controls.NewPostingControl" %>
<%@ Register TagPrefix="honey" Namespace="Honey.Controls" Assembly="Honey"%>

<asp:TextBox ID="txtUserName" placeholder="Ім'я" CssClass="inputBE" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="reqiedtxtUserName" ControlToValidate="txtUserName" ErrorMessage="Відсутнє Ім'я" ValidationGroup="newPostingGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
<asp:RequiredFieldValidator ID="reqiedtxtDescription" ControlToValidate="txtDescription" ErrorMessage="Відсутній опис" ValidationGroup="newPostingGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<asp:TextBox ID="txtDescription" placeholder="Опис" CssClass="inputBE" Width="99%" runat="server" TextMode="MultiLine" Height="90px"></asp:TextBox>
<br />
    <honey:MyCheckBox Secured="true" ID="checkShow" runat="server" Text="Show" />
<asp:Button ID="btnSubmit" CssClass="btnSubmit" ValidationGroup="newPostingGroup" runat="server" Text="Залишити відгук" OnClick="btnSubmit_Click" />

