<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="WT_Configuration_Default" Theme="Default"%>



<%@ Register src="../UserControls/Configuration/Configuration.ascx" tagname="Configuration" tagprefix="uc1" %>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Configuration ID="Configuration1" runat="server" />
</asp:Content>

