<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewReport.aspx.cs" Inherits="MB_Comments_ViewReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana"
    Font-Size="8pt" Height="625px" Width="870px" Visible="true" 
            ShowDocumentMapButton="False" DocumentMapCollapsed="true" DocumentMapWidth="0">
    <LocalReport ReportPath="MB\Reports\MessageReport.rdlc">
        <DataSources >
            
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="Comment" />
            
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="GetAllCommentsByFilter" 
        TypeName="DataAccessLibrary.Services.CommentService">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="slCompany" 
                QueryStringField="Company" Type="String" />
            <asp:QueryStringParameter DefaultValue="1/1/2011" Name="StartDate" 
                QueryStringField="StartDate" Type="DateTime" />
            <asp:QueryStringParameter DefaultValue="1/1/2012" Name="EndDate" 
                QueryStringField="EndDate" Type="DateTime" />
            <asp:QueryStringParameter DefaultValue="Todos" Name="IsRead" 
                QueryStringField="IsRead" Type="String" />
    </SelectParameters>
    </asp:ObjectDataSource>

    </div>
    </form>
</body>
</html>
