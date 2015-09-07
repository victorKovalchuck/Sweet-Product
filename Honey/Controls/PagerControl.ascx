<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PagerControl.ascx.cs" Inherits="Honey.Controls.PagerControl" %>
<style type="text/css">
  
.Pager
{
    font-size:23px;
    font-family:Candara;
    text-decoration:none;
}

.Pager:hover
{
    color:Red;
}

</style>

<asp:HyperLink ID="lnkPrev" runat="server" Text="&lt;" Visible="false" CssClass="Pager"></asp:HyperLink>       
<asp:Repeater ID="rptPager" runat="server" onitemdatabound="rpt_ItemDataBound">
    <ItemTemplate>          
        <asp:HyperLink runat="server" ID="links" NavigateUrl='<%#string.Format("~/Postings.aspx?Page={0}",Container.DataItem)%>' Text="<%#Container.DataItem %>" CssClass="Pager"></asp:HyperLink>                      
    </ItemTemplate>                        
</asp:Repeater> 
<asp:HyperLink ID="lnkNext" runat="server" Text="&gt;" Visible="false" CssClass="Pager"></asp:HyperLink>                    
       