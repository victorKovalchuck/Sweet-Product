<%@ Page Title="Продукти" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Honey.Products"
Meta_Keywords="Сезонний Мед,Якісний,Дешевий,Свіжий, Мед, Львів, Броди, Сезонний, Гречаний, Липовий, Різнотрав'я"
Meta_Description="На нашій пасіці завжди свіжий мед, який характеризується добрими харчовими якостями за низьку ціну"
%>
<%@ Register TagPrefix="honey" Namespace="Honey.Controls" Assembly="Honey" %>
<%@ Register TagPrefix="honey" TagName="JqueryLightBoxControl" Src="~/Controls/JqueryLightBoxControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
<span class="Заголовок">Мед</span><br />
<asp:Repeater ID="rptPrices" runat="server" 
        onitemdatabound="rptPrices_ItemDataBound">
    <ItemTemplate>
    <div class='<%#DataBinder.Eval(Container.DataItem,"IsDefault")%>' runat="server">
    <div runat="server" id="outlineDiv" class="Buy" data='<%# DataBinder.Eval(Container.DataItem, "Name")%>'>
       <div class="OuterWraperAnimate"> 
            <div runat="server" id="divAnimate" class="Animate"></div>
       </div>
    <table class="OuterTableHover">
    <tr>
        <td style="width:50%;vertical-align:bottom">    
        <table class="ProductData">
        <tr>
            <td class="ProductName">Назва:     <%# DataBinder.Eval(Container.DataItem, "Name")%></td>                
        </tr>
        <tr>
            <td> 
                 <asp:Label id="oldPrice"  CssClass="ProductNewPrice" runat="server">Ціна:<%# DataBinder.Eval(Container.DataItem, "Cost")%>грн/л</asp:Label> <br />
                 <asp:Label ID="newPrice" CssClass="ProductNewPrice" runat="server"></asp:Label>  
            </td> 
            <td> <span runat="server" id="spnEmptyBottle" class="EmptyBottle" style="color:Red;font-size:24px;font-family:Cursive; position:absolute;right:550px;"></span></td>  
        </tr>
      
        <tr>
            <td>Вироблений:<%# DataBinder.Eval(Container.DataItem, "ProductedDate","{0:d}")%></td>
        </tr>          
        <tr>
            <td><honey:JqueryLightBoxControl ID="cntrlJqueryLightBox" runat="server" SetUrl='<%# DataBinder.Eval(Container.DataItem, "Name","~/Pictures/{0}.jpg")%>'></honey:JqueryLightBoxControl></td>                          
            <td style="text-align:center;">
                <honey:MyHyperLink ID="myHyperLink" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/NewProduct.aspx?ID={0}")%>' Secured="true" Visible="true" Text="Edit"></honey:MyHyperLink>                
            </td>  
            <td style="text-align:right;">
                <honey:MyHyperLink ID="myHyperLink1" runat="server"  onclick="return confirm('Are you sure?')" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/NewProduct.aspx?DeleteID={0}")%>' Secured="true" Visible="true" Text="Delete"></honey:MyHyperLink>                                  
            </td>            
        </tr>               
        </table>
         </td>
         <td align="right" style="vertical-align:bottom">        
        <table>             
        <tr>            
          <td>
            <asp:Image ID="imgDiscount" runat="server" />
            </td>       
            <td style="vertical-align:bottom">
                Залишилось:<%# DataBinder.Eval(Container.DataItem, "Remains","{0:0.##}")%>Л
            </td>
            <td style="vertical-align:bottom">
                <asp:Image runat="server" CssClass="Barrel" ID="imgBarrel"></asp:Image>
            </td>        
        </tr>
        </table>  
        </td>
    </tr>
    </table>
    </div>
    <hr />
    </div>         
    </ItemTemplate>           
</asp:Repeater>   

</asp:Content>
