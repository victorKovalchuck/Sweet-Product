<%@ Page Language="C#" MasterPageFile="~/Master.Master"  AutoEventWireup="true" CodeBehind="Postings.aspx.cs" Title="Коментарі" Inherits="Honey.Postings"
Meta_Keywords="Сезонний Мед,Якісний,Дешевий,Свіжий, Мед, Львів, Броди, Сезонний, Гречаний, Липовий, Різнотрав'я"
Meta_Description="На нашій пасіці завжди свіжий мед, який характеризується добрими харчовими якостями за низьку ціну"
%>
<%@ Register TagPrefix="honey" TagName="NewPostingsContol" Src="~/Controls/NewPostingControl.ascx" %>
<%@ Register TagPrefix="honey" TagName="PagerControl" Src="~/Controls/PagerControl.ascx" %>
<%@ Register TagPrefix="honey" Namespace="Honey.Controls" Assembly="Honey" %>
<%@ Register TagPrefix="honey" TagName="MasterIsSuccessShowControl" Src="~/Controls/MasterIsSuccessShowControl.ascx" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">   
    <honey:MasterIsSuccessShowControl ID="cntrlMasterIsSuccessShow" runat="server" />
<span class="Заголовок">Відгуки</span><br />

       <asp:Repeater ID="rptData" runat="server">
       <HeaderTemplate>
           <table cellspacing="4" width="100%" style="font-size:small;">           
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
                <td colspan="3" style="float:left; height:auto; word-break: break-all;">                
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
        
       <div style="text-align:center;">
           <honey:PagerControl id="pagerCntrl" runat="server">       
           </honey:PagerControl>
       </div>           
            <asp:LinkButton ID="showCommentInput" runat="server" OnClick="ShowCommentInput">Додати відгук</asp:LinkButton>                       
       <div>
          <honey:NewPostingsContol runat="server" ID="cntrlPostings" Visible="false">
            </honey:NewPostingsContol> 
       </div>
       
</asp:Content>