<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubscriberControl.ascx.cs" Inherits="Honey.Controls.SubscriberControl" %>

<asp:RequiredFieldValidator ID="RequiredFieldValidator" ControlToValidate="txtEmailAddress" runat="server" ErrorMessage="Email Address is required" ValidationGroup="subscriberGroup" Display="Dynamic"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmailAddress" runat="server" ValidationGroup="subscriberGroup" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Wrong Email Input" Display="Dynamic"></asp:RegularExpressionValidator><br />
<asp:TextBox id="txtEmailAddress" CssClass="txtEmailAddress" placeholder="Email" runat="server"></asp:TextBox><br /><br />

<asp:Button ID="btnSubmit" CssClass="btnSubmit" ValidationGroup="subscriberGroup" runat="server" Text="Підписатись" 
    onclick="btnSubmit_Click"/><br /><br />