<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Honey._Default" %>
<%@ Register TagPrefix="honey" TagName="SubscriberControl" Src="~/Controls/SubscriberControl.ascx" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">    

<style type="text/css">
        
.Panel
{	
	text-align:center;
}
        	
.Image
{
	width:100px;
	height:80px;
	padding:10;
	margin:0;			
}
</style>
<table style="width:100%">
<tr>    
    <td style=" width:60%;vertical-align:0px;">
        <asp:Panel ID="pnlImages" runat="server" CssClass="Panel"></asp:Panel>
    </td>
    <td>
    <div style="font-size:16px">Для отримання інформації про нові надходження меду зареєструйтесь </div>
        <honey:SubscriberControl runat="server" ID="contrl" ></honey:SubscriberControl>

        <asp:Repeater ID="rptData" runat="server">        
        <HeaderTemplate>
        <table cellspacing="4" width="100%" style="font-size:small">           
       </HeaderTemplate>
        <ItemTemplate>
            <tr>                           
                <td style="text-align:left;">
                   <%# DataBinder.Eval(Container.DataItem, "UserName")%>
                   _
                   <%# DataBinder.Eval(Container.DataItem, "PostedDate","{0:g}")%>
                </td>  
                 <td colspan="2" style="text-align:right;">
                 IP  <%# DataBinder.Eval(Container.DataItem, "IPAddress")%>
                </td>                               
            </tr> 
            <tr>
                <td>
                 <%#DataBinder.Eval(Container.DataItem, "Description")%>                    
                </td>                         
            </tr>
            <tr>
                <td colspan="3">
                 <hr />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
           </table> 
        </FooterTemplate>           
        </asp:Repeater>
    </td>    
</tr>
</table>
</asp:Content>