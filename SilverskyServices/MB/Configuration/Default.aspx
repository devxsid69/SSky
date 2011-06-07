<%@ Page Title="" Language="C#" MasterPageFile="~/MB/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="MB_Configuration_Default" Theme="DefaultVamsa"%>


<%@ Register Src="../UserControls/Configuration.ascx" TagName="Configuration" TagPrefix="uc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tableComment">
        <tr>
            <td>
                <uc1:Configuration ID="Configuration1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
