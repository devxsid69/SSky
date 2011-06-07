<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Tickets_Default" Theme="Default"%>

<%@ Register src="../UserControls/Tickets/Browse.ascx" tagname="Browse" tagprefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:Browse ID="Browse1" runat="server" />

</asp:Content>

