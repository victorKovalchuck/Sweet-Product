<%@ Page Language="C#" MasterPageFile="~/BE/BeMaster.Master" AutoEventWireup="true" CodeBehind="NewPosting.aspx.cs" Inherits="Honey.BE.NewPosting" %>
<%@ Register TagPrefix="honey" TagName="NewPostingsContol" Src="~/Controls/NewPostingControl.ascx" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="cntTitle"> 
   NewPosting
</asp:Content>
<asp:Content ID="content2" runat="server" ContentPlaceHolderID="cntBody"> 
    <honey:NewPostingsContol ID="cntrlPost" runat="server" />
</asp:Content>
