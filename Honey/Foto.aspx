<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" Title="Фото" CodeBehind="Foto.aspx.cs" Inherits="Honey.Foto"
Meta_Keywords="Сезонний Мед,Якісний,Дешевий,Свіжий, Мед, Львів, Броди, Сезонний, Гречаний, Липовий, Різнотрав'я"
Meta_Description="На нашій пасіці завжди свіжий мед, який характеризується добрими харчовими якостями за низьку ціну"
%>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<style type="text/css">
         	
.Image
{
	width:130px;
	height:100px;
	padding:5px;
	box-shadow:2px 2px 50px #F9AC08;

}

.Frame
{
	width:150px;
	height:115px;
	border:2px solid #bdbdbd;
	margin:5px;
	float:left;
	font-size:10px;
	text-align:center;
	background-color:#f6f6f6;
	
}
.Frame:hover
{
   border:2px outset orange;
}

</style>
 <span class="Заголовок">Фото</span>
<div id="gallery">
    <asp:Panel ID="pnlImages" runat="server" CssClass="Panel"></asp:Panel>
</div>
</asp:Content>