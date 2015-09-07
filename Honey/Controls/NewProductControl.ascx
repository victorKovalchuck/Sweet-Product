<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewProductControl.ascx.cs" Inherits="Honey.Controls.NewProductControl" %>
<asp:TextBox ID="txtbxPrice" CssClass="inputBE" runat="server" PlaceHolder="Price"></asp:TextBox>
<asp:RequiredFieldValidator ID="reqiedtxtDescription" ControlToValidate="txtbxPrice" ErrorMessage="Price is required" ValidationGroup="newProductGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="txtbxName" CssClass="inputBE" runat="server" PlaceHolder="Name"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtbxName" ErrorMessage="Name is required" ValidationGroup="newProductGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="txtbxRecived" CssClass="inputBE" runat="server" PlaceHolder="Recieved"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtbxRecived" ErrorMessage="RecivedValue is required" ValidationGroup="newProductGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="txtbxRemains" CssClass="inputBE" runat="server" PlaceHolder="Remains"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtbxRemains" ErrorMessage="RemainsValue is required" ValidationGroup="newProductGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="txtDataTime" CssClass="inputBE" runat="server" PlaceHolder="txtDataTime"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtDataTime" ErrorMessage="DataTime is required" ValidationGroup="newProductGroup" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
<br />
<asp:DropDownList ID="listDiscount" CssClass="inputBE" runat="server">
    <asp:ListItem Text="None" Value="0" Selected="True"></asp:ListItem>
    <asp:ListItem Text="10%" Value="10"></asp:ListItem>
    <asp:ListItem Text="20%" Value="20"></asp:ListItem>
    <asp:ListItem Text="30%" Value="30"></asp:ListItem>
    <asp:ListItem Text="40%" Value="40"></asp:ListItem>
    <asp:ListItem Text="50%" Value="50"></asp:ListItem>
    <asp:ListItem Text="60%" Value="60"></asp:ListItem>
    <asp:ListItem Text="70%" Value="70"></asp:ListItem>
    <asp:ListItem Text="80%" Value="80"></asp:ListItem>
    <asp:ListItem Text="90%" Value="90" ></asp:ListItem>
    <asp:ListItem Text="100%" Value="100"></asp:ListItem>
</asp:DropDownList>
<br />
<asp:CheckBox ID="chckDefault" runat="server" Text="IsDefault" /><br />
<asp:Button ID="btnSubmit" CssClass="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="newProductGroup" /><br /><hr />

