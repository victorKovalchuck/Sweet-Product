<%@ Page Language="C#" MasterPageFile="~/BE/BeMaster.Master" AutoEventWireup="true" CodeBehind="NewPosting.aspx.cs" Inherits="Honey.BE.NewPosting" %>
<%@ Register TagPrefix="honey" TagName="NewPostingsContol" Src="~/Controls/NewPostingControl.ascx" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="cntTitle"> 
   NewPosting
</asp:Content>
<asp:Content ID="content2" runat="server" ContentPlaceHolderID="cntBody">  
     <asp:Repeater ID="rptPostings" runat="server">
    <HeaderTemplate>
    <table class="rptTable">
    <tr>
        <td style="color:Red">Name</td>    
        <td style="color:Red">Description</td>      
        <td style="color:Red">PostedDate</td> 
        <td style="color:Red">Show</td> 
    </tr>
    </HeaderTemplate>
    <ItemTemplate>   
    <tr style="width:100%">
        <td><%# DataBinder.Eval(Container.DataItem, "UserName")%></td>
        <td style="float:left; height:auto; word-break: break-all;"><%# DataBinder.Eval(Container.DataItem, "Description")%></td>
        <td><%# DataBinder.Eval(Container.DataItem, "PostedDate", "{0:d}")%></td>   
        <td><%# DataBinder.Eval(Container.DataItem, "Show")%></td>       
        <td><asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/NewPosting.aspx?ID={0}")%>' Text="edit"></asp:HyperLink></td>
        <td><asp:HyperLink ID="lnkDelete" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/NewPosting.aspx?DeleteID={0}")%>' Text="delete" onclick="return confirm('Are you sure?')"></asp:HyperLink></td>
    </tr>        
    </ItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>    
    </asp:Repeater>    

       <honey:NewPostingsContol ID="cntrlPost" runat="server" />
</asp:Content>
