<%@ Page Title="" Language="C#" MasterPageFile="~/BE/BeMaster.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="Honey.BE.Customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntTitle" runat="server">
Clients
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntBody" runat="server">
<asp:Repeater ID="rptClients" runat="server">
<HeaderTemplate>
<table class="rptTable">
 <tr>
        <td style="color:Red">Name</td>    
        <td style="color:Red">PurchaseDate</td>
        <td style="color:Red">Number</td>
        <td style="color:Red">HoneyType</td>  
        <td style="color:Red">Amount</td>     
        <td style="color:Red">Email</td>     
    </tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
   <td>   <%# DataBinder.Eval(Container.DataItem, "Name")%></td>
   <td>   <%# DataBinder.Eval(Container.DataItem, "PurchaseDate", "{0:d}")%></td>
   <td>   <%# DataBinder.Eval(Container.DataItem, "Number")%></td>
   <td>   <%# DataBinder.Eval(Container.DataItem, "HoneyType")%></td>
   <td>   <%# DataBinder.Eval(Container.DataItem, "Amount")%></td>
    <td>   <%# DataBinder.Eval(Container.DataItem, "Email")%></td>
    <td><asp:HyperLink ID="lnkDelete" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/Customers.aspx?DeleteID={0}")%>' Text="delete" onclick="return confirm('Are you sure?')"></asp:HyperLink></td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>
</asp:Content>
