<%@ Page Language="C#" MasterPageFile="~/Master.Master"  AutoEventWireup="true" CodeBehind="Postings.aspx.cs" Inherits="Honey.Postings" %>
<%@ Register TagPrefix="honey" TagName="NewPostingsContol" Src="~/Controls/NewPostingControl.ascx" %>
<%@ Register TagPrefix="honey" TagName="PagerControl" Src="~/Controls/PagerControl.ascx" %>
<%@ Register TagPrefix="honey" Namespace="Honey.Controls" Assembly="Honey" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">   
       <div style="height:200px;">
       <asp:Repeater ID="rptData" runat="server">
       <HeaderTemplate>
           <table cellspacing="4" width="100%" style="font-size:small">           
       </HeaderTemplate>
        <ItemTemplate>
            <tr>                           
                <td style="text-align:left;">
                 <b><%# DataBinder.Eval(Container.DataItem, "UserName")%></b>
                   _
                   <%# DataBinder.Eval(Container.DataItem, "PostedDate","{0:g}")%>
                </td>  
                 <td colspan="2" style="text-align:right;">
                <b> IP </b> <%# DataBinder.Eval(Container.DataItem, "IPAddress")%>
                </td>                               
            </tr> 
            <tr>
                <td>
                 <%#DataBinder.Eval(Container.DataItem, "Description")%>                    
                </td>
                <td style="text-align:center;">
                 <honey:MyHyperLink ID="myHyperLink" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/NewPosting.aspx?ID={0}")%>' Secured="true" Visible="true" Text="Edit"></honey:MyHyperLink>                
                </td>  
                  <td style="text-align:right;">
                 <honey:MyHyperLink ID="myHyperLink1" runat="server"  onclick="return confirm('Are you sure?')" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/NewPosting.aspx?DeleteID={0}")%>' Secured="true" Visible="true" Text="Delete"></honey:MyHyperLink>                
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
       </div>       
       <div style="text-align:center; margin-top:10px;">
       <honey:PagerControl id="pagerCntrl" runat="server">       
       </honey:PagerControl>
       </div>  <br />              
                           
       <div>
      <honey:NewPostingsContol runat="server" ID="cntrl">
        </honey:NewPostingsContol> 
       </div>
       
</asp:Content>