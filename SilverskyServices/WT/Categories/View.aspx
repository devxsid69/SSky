<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Categories_View" Theme="Default"%>


<%@ Register src="../UserControls/Categories/View.ascx" tagname="View" tagprefix="uc1" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" EnableViewState="true">
    <uc1:View ID="View1" runat="server" />
</asp:Content>

