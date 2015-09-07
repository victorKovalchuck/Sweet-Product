<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/BE/BeMaster.Master" AutoEventWireup="true" CodeBehind="Topics.aspx.cs" Inherits="Honey.BE.Topics" %>
<%@ Register TagPrefix="honey" TagName="NewTopicControl" Src="~/Controls/NewTopicControl.ascx"%>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="cntTitle"> 
    Topics
</asp:Content>
<asp:Content ID="content2" runat="server" ContentPlaceHolderID="cntBody">     
<div>
    <honey:NewTopicControl runat="server" ID="cntrlNewTopic" Visible="false"></honey:NewTopicControl>
    <asp:HyperLink ID="lnkAdd" CssClass="NewTopicLnc" runat="server" Text="Add New Topic" NavigateUrl="~/BE/NewTopic.aspx"></asp:HyperLink>
    <asp:Repeater ID="rptr" runat="server">
    <HeaderTemplate>    
    <table class="rptTable">
    </HeaderTemplate>
        <ItemTemplate>        
            <tr>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "Content") %>
                </td>
                 <td>
                    <%# DataBinder.Eval(Container.DataItem, "Code") %>
                </td>
                <td>
                    <asp:HyperLink ID="hpLink" runat="server"  NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/Topics.aspx?ID={0}")%>' Text="Edit"></asp:HyperLink> <br />
                </td>        
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/Topics.aspx?DeleteID={0}")%>' onclick="return confirm('Are you shure?')" Text="Delete"></asp:HyperLink> <br />
                </td>               
            </tr>                
        </ItemTemplate>
        <SeparatorTemplate>
        <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        </tr>
       
        </SeparatorTemplate>
    <FooterTemplate>
    </table>    
    </FooterTemplate>
    </asp:Repeater>  
    </div>  
</asp:Content>