<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/BE/BeMaster.Master" AutoEventWireup="true" CodeBehind="NewTopic.aspx.cs" Inherits="Honey.BE.NewTopic" %>
<%@ Register TagPrefix="honey" TagName="NewTopicContol"  Src="~/Controls/NewTopicControl.ascx"%>
<%@ Register  TagPrefix="honey" TagName="TopicControl" Src="~/Controls/TopicControl.ascx"%>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="cntTitle"> 
    NewTopic
</asp:Content>
<asp:Content ID="content2" runat="server" ContentPlaceHolderID="cntBody">
    <div>
        <honey:NewTopicContol ID="cntrlNewTopic" runat="server" />
    </div>
</asp:Content>

