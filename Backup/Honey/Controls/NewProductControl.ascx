<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewProductControl.ascx.cs" Inherits="Honey.Controls.NewProductControl" %>
<asp:TextBox ID="txtbxPrice" CssClass="txt" runat="server" PlaceHolder="Price"></asp:TextBox>
<asp:RequiredFieldValidator ID="reqiedtxtDescription" ControlToValidate="txtbxPrice" ErrorMessage="Price is required" ValidationGroup="newProductGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="txtbxName" CssClass="txt" runat="server" PlaceHolder="Name"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtbxName" ErrorMessage="Name is required" ValidationGroup="newProductGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="txtbxRecived" CssClass="txt" runat="server" PlaceHolder="Recieved"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtbxRecived" ErrorMessage="RecivedValue is required" ValidationGroup="newProductGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="txtbxRemains" CssClass="txt" runat="server" PlaceHolder="Remains"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtbxRemains" ErrorMessage="RemainsValue is required" ValidationGroup="newProductGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
<asp:CheckBox ID="chckDefault" runat="server" Text="IsDefault" /><br />
<asp:Button ID="btnSubmit" CssClass="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="newProductGroup" /><br /><hr />

