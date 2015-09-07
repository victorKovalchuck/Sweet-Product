<%@ Page Language="C#" MasterPageFile="~/BE/BeMaster.Master" AutoEventWireup="true" CodeBehind="Subscribers.aspx.cs" Inherits="Honey.BE.Subscribers" %>
<%@ Register TagPrefix="honey" TagName="EditSubscriberControl" Src="~/Controls/EditSubscriberControl.ascx" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="cntTitle"> 
   Subscribers
</asp:Content>
<asp:Content ID="content2" runat="server" ContentPlaceHolderID="cntBody">
        <honey:EditSubscriberControl ID="editSubscriber" runat="server"/>
    <div>   
    <asp:Repeater ID="rptSubscribers" runat="server">
    <HeaderTemplate>
    <table class="rptTable">
    <tr>
        <td style="color:Red">Email</td>    
        <td style="color:Red">IsActive</td>
        <td style="color:Red">CreatedAt</td>
        <td style="color:Red">UpdatedAt</td>      
    </tr>
    </HeaderTemplate>
    <ItemTemplate>   
    <tr style="width:100%">
        <td><%# DataBinder.Eval(Container.DataItem, "EmailAddress")%></td>
        <td><%# DataBinder.Eval(Container.DataItem, "IsActive")%></td>
        <td><%# DataBinder.Eval(Container.DataItem, "CreatedAt", "{0:d}")%></td>
        <td><%# DataBinder.Eval(Container.DataItem, "UpdatedAt","{0:d}")%></td>       
        <td><asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/Subscribers.aspx?ID={0}")%>' Text="edit"></asp:HyperLink></td>
        <td><asp:HyperLink ID="lnkDelete" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/Subscribers.aspx?DeleteID={0}")%>' Text="delete" onclick="return confirm('Are you sure?')"></asp:HyperLink></td>
    </tr>        
    </ItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>    
    </asp:Repeater>    
    </div>
</asp:Content>
