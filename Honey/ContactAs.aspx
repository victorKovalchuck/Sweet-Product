<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" Title="Контакти" CodeBehind="ContactAs.aspx.cs" Inherits="Honey.ContactAs"
Meta_Keywords="Сезонний Мед,Якісний,Дешевий,Свіжий, Мед, Львів, Броди, Сезонний, Гречаний, Липовий, Різнотрав'я"
Meta_Description="На нашій пасіці завжди свіжий мед, який характеризується добрими харчовими якостями за низьку ціну"
%>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<style type="text/css">

#map-canvas
{
height:100%;    
}

.Delivery
{
    font-size:16px;
}
</style>

<table style=" width:100%;">
<tr>
<td style="vertical-align:top" align="left">
<span class="Заголовок">Режим Роботи</span><br />
<%--<span class="Інтернетом">Прийом замовлень інтернетом:</span><br />
<span class="Delivery">
    Доставка по Львову безкоштовна<br />
    З 18:00 до 21:00<br />    
</span><br />--%>
<span class="Потелефону">Прийом замовлень</span><br />
<span class="Delivery">
    Доставка по Львову безкоштовна<br />
    Будні з 18:00 до 21:00<br />
    Тел: 0507116375 Богдан<br />
</span><br />
<span class="НеділяВихідний">Неділя: Вихідний</span><br />
</td>
<td align="right"><div id="map-canvas" style="width:450px; height:300px;"></div></td>
</tr>
</table>

<br />
</asp:Content>
