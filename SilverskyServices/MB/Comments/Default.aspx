<%@ Page Title="" Language="C#" MasterPageFile="~/MB/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="MB_Comments_Default" Theme="DefaultVamsa"%>


<%@ Register src="../UserControls/BrowseComments.ascx" tagname="BrowseComments" tagprefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <%--<link href="../App_Themes/DefaultVamsa/DefaultVamsa.css" stylesheet" type="text/css" />--%>
    <table class="tableComment">
        <tr>
            <td>
                <uc1:BrowseComments ID="BrowseComments1" runat="server" />
            </td>
        </tr>
    </table>
    
    
</asp:Content>

