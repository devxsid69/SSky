<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Users_Default" Theme="Default" %>

<%@ Register Src="../UserControls/Users/Browse.ascx" TagName="Browse" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/Users/View.ascx" TagName="View" TagPrefix="uc2" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">        
    <uc1:Browse ID="Browse1" runat="server" />
</asp:Content>
