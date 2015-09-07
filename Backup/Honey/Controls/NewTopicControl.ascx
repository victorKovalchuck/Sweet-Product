<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewTopicControl.ascx.cs" Inherits="Honey.Controls.NewTopicControl" %>
    Code:    
    <asp:TextBox ID="txtbxCode" CssClass="txt" runat="server"></asp:TextBox><br />
    Content:    
    <asp:TextBox ID="txtbxContent" runat="server" CssClass="txt" TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox><br />
    <asp:Button ID="btnSubmit" runat="server" CssClass="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" /><br /><hr />