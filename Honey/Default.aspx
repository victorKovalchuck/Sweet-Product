<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Honey._Default"
Meta_Keywords="Сезонний Мед,Якісний,Дешевий,Свіжий, Мед, Львів, Броди, Сезонний, Гречаний, Липовий, Різнотрав'я"
Meta_Description="На нашій пасіці завжди свіжий мед, який характеризується добрими харчовими якостями за низьку ціну"
Title="Свіжий мед- Львів"%>
<%@ Register TagPrefix="honey" TagName="SubscriberControl" Src="~/Controls/SubscriberControl.ascx" %>
<%@ Register  TagPrefix="honey" TagName="TopicControl" Src="~/Controls/TopicControl.ascx"%>
<%@ Register TagPrefix="honey" TagName="MasterIsSuccessShowControl" Src="~/Controls/MasterIsSuccessShowControl.ascx" %>
<%@ Register TagPrefix="honey" TagName="SliderControl" Src="~/Controls/Slider.ascx" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">    

<style type="text/css">
        
.Panel
{	
	text-align:center;
}
.ImageHome
{
    width:30%;
    margin:10px;
    float:left;
    clear:left;  
}        	

.ControlToRight
{
    padding:10px;
    text-align:left;
    margin:10px;  
    border:2px solid orange;  
    font-style:oblique;
    width:30%;
    float:right;
    clear:right;
}

.Description
{
    font-size:14px;
      vertical-align:top;
}

#cntrTopic
{
    width:100%;
}

@keyframes blink {
  from { opacity: 1; color:Orange }
  to   { opacity: 0; color:Blue }
}
@-webkit-keyframes blink {
  from { opacity: 1; color:Orange }
  to   { opacity: 0; color:Blue }
}
</style>

<honey:MasterIsSuccessShowControl ID="masterIsSuccessShowControl" runat="server" />
<table style="width:100%;height:100%; vertical-align:top; font-size:12px">
<tr>
    <td style="width:70%; vertical-align:top;">        
      <div class="ControlToRight">
        <span style="color:#c00000; font-size:13px; font-weight:300">Вкажіть електронну адресу для отримання новин про відкачування меду</span><br />
            <honey:SubscriberControl runat="server" ID="contrl" ></honey:SubscriberControl>
        </div>
        <div class="ControlToLeft">         
            <asp:Image ID="imgDefault" runat="server" ImageUrl="Pictures/honey_on_a_spoon_by_jfschmit.jpg" CssClass="ImageHome" /> 
        </div>       
    <div class="ControlToRight">
        <honey:TopicControl ID="cntrTopic" runat="server" Code="DefaultLeftUp" />
    </div>
    <div class="ControlToRight">
        <asp:Repeater ID="rptData" runat="server" 
            onitemdatabound="rptData_ItemDataBound">        
        <HeaderTemplate>
        <table cellspacing="4" width="100%" style="font-size:small">           
       </HeaderTemplate>
        <ItemTemplate>
            <tr>                           
                <td style="text-align:left;">
                   <%# DataBinder.Eval(Container.DataItem, "UserName")%>
                   _
                   <%# DataBinder.Eval(Container.DataItem, "PostedDate","{0:d}")%>
                </td>  
                 <td colspan="2" style="text-align:right;">
                 IP  <%# DataBinder.Eval(Container.DataItem, "IPAddress")%>
                </td>                               
            </tr> 
            <tr>
                <td>
                    <%# SetShortComment(DataBinder.Eval(Container.DataItem, "Description"))%>                               
                </td>  
                <td style="text-align:right;">
                    <asp:HyperLink ID="hplnkReadMore" runat="server" Text="Детальніше" style="text-decoration:none;" NavigateUrl="<%#NavigateToPostings()%>"></asp:HyperLink>
                </td>                       
            </tr>
            <tr>
                <td colspan="3">
                     <asp:Literal ID="litHr" runat="server"></asp:Literal>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
           </table> 
        </FooterTemplate>           
        </asp:Repeater>
     </div>            
    <span class="Description">
        Бджолиний мед - одні з найперших ліків, використовуваних людиною.<br />
        Бджола є не тільки єдиною комахою, але і єдиною живою істотою, мабуть, що корисно абсолютно. Вона одна з деяких, живучих не за рахунок когось або чогось, а винятково за рахунок нектару й пилка, які рослини віддають їй замість запилення<br />
        Всі продукти життєдіяльності бджолиної сім'ї, без винятку, мають харчову й лікувальну цінність. Навіть страшна бджолина отрута є ефективними ліками. Навіть після своєї смерті бджола приносить людям користь: із бджолиного подмора (загиблих бджіл) роблять ліки <br />
    </span>     
    </td>    
</tr>
</table>

</asp:Content>