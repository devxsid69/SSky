<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="MB_Default" Theme="DefaultVamsa" %>

<%@ Register Assembly="CaptchaCtrl" Namespace="CaptchaCtrl" TagPrefix="cc1" %>
<%@ Register src="UserControls/FormQuestions.ascx" tagname="FormQuestions" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../App_Themes/DefaultVamsa/DefaultVamsa.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableComment">
        <tr>
            <td>
                <uc1:FormQuestions ID="FormQuestions1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
