<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Honey.Products" %>
<%@ Register TagPrefix="honey" Namespace="Honey.Controls" Assembly="Honey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Repeater ID="rptIsDefault" runat="server" 
        onitemdatabound="rptPrices_ItemDataBound">
    <ItemTemplate>
    <table style="font-size:18px">
    <tr>
        <td>Назва:     <%# DataBinder.Eval(Container.DataItem, "Name")%></td>    
        <td style="text-align:center;">
            <honey:MyHyperLink ID="myHyperLink" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/NewProduct.aspx?ID={0}")%>' Secured="true" Visible="true" Text="Edit"></honey:MyHyperLink>                
        </td>  
        <td style="text-align:right;">
            <honey:MyHyperLink ID="myHyperLink1" runat="server"  onclick="return confirm('Are you sure?')" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/NewProduct.aspx?DeleteID={0}")%>' Secured="true" Visible="true" Text="Delete"></honey:MyHyperLink>                                  
        </td>        
    </tr>
    <tr>
        <td>Ціна:      <%# DataBinder.Eval(Container.DataItem, "Cost", "{0:C}")%>/Л</td>   
    </tr>
    <tr>
        <td>Вироблений:<%# DataBinder.Eval(Container.DataItem, "ProductedDate","{0:d}")%></td>
    </tr>
    <tr>
        <td>Добуто:<%# DataBinder.Eval(Container.DataItem, "Recived")%>Л</td>              
    </tr>          
    <tr>
        <hr />
    </tr>
    </table>
    <table style="font-size:16px; margin-left:500px; margin-top:-110px">             
    <tr>            
        <td>Залишилось:<%# DataBinder.Eval(Container.DataItem, "Remains")%>Л
            <asp:Image runat="server" ID="imgBarrel" Width="120px" Height="120px" />
        </td>        
    </tr>
    </table>           
    </ItemTemplate>    
</asp:Repeater>    

<asp:Repeater ID="rptPrices" runat="server" 
        onitemdatabound="rptPrices_ItemDataBound">
    <ItemTemplate>
    <table style="font-size:12px">
    <tr>
        <td>Назва:     <%# DataBinder.Eval(Container.DataItem, "Name")%></td>    
        <td style="text-align:center;">
            <honey:MyHyperLink ID="myHyperLink" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/NewProduct.aspx?ID={0}")%>' Secured="true" Visible="true" Text="Edit"></honey:MyHyperLink>                
        </td>  
        <td style="text-align:right;">
            <honey:MyHyperLink ID="myHyperLink1" runat="server"  onclick="return confirm('Are you sure?')" NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Id","~/BE/NewProduct.aspx?DeleteID={0}")%>' Secured="true" Visible="true" Text="Delete"></honey:MyHyperLink>                                  
        </td>        
    </tr>
    <tr>
        <td>Ціна:      <%# DataBinder.Eval(Container.DataItem, "Cost", "{0:C}")%>/Л</td>   
    </tr>
    <tr>
        <td>Вироблений:<%# DataBinder.Eval(Container.DataItem, "ProductedDate","{0:d}")%></td>
    </tr>
    <tr>
        <td>Добуто:<%# DataBinder.Eval(Container.DataItem, "Recived")%>Л</td>              
    </tr>          
    <tr>
        <hr />
    </tr>
    </table>
    <table style="font-size:12px; margin-left:500px; margin-top:-90px">             
    <tr>            
        <td>Залишилось:<%# DataBinder.Eval(Container.DataItem, "Remains")%>Л
            <asp:Image runat="server" ID="imgBarrel" Width="80px" Height="80px" />
        </td>        
    </tr>
    </table>           
    </ItemTemplate>    
</asp:Repeater>   

</asp:Content>
