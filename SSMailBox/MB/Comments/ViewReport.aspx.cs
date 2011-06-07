using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class MB_Comments_ViewReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportViewer1.ShowDocumentMapButton = false;
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Comment", ObjectDataSource2));
        ReportViewer1.LocalReport.AddTrustedCodeModuleInCurrentAppDomain("CoreLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
        ReportViewer1.LocalReport.AddTrustedCodeModuleInCurrentAppDomain("CoreLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
        ReportViewer1.LocalReport.Refresh();
        #region Comentado conversion automatica a PDF
        //string reportType = "PDF";
        //string mimeType;
        //string encoding;
        //string fileNameExtension;

        ////The DeviceInfo settings should be changed based on the reportType
        ////http://msdn2.microsoft.com/en-us/library/ms155397.aspx
        //string deviceInfo =
        //"<DeviceInfo>" +
        //"  <OutputFormat>PDF</OutputFormat>" +
        //"  <PageWidth>8.5in</PageWidth>" +
        //"  <PageHeight>11in</PageHeight>" +
        //"  <MarginTop>0.1in</MarginTop>" +
        //"  <MarginLeft>0.1in</MarginLeft>" +
        //"  <MarginRight>0.1in</MarginRight>" +
        //"  <MarginBottom>0.1in</MarginBottom>" +
        //"</DeviceInfo>";
        ////ReportViewer1.LocalReport.DataSources.Add(ObjectDataSource2);
        //Microsoft.Reporting.WebForms.Warning[] warnings;
        //string[] streams;
        //byte[] renderedBytes;
        //renderedBytes = ReportViewer1.LocalReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
        //Response.Clear();
        //Response.ContentType = mimeType;
        //Response.AddHeader("content-disposition", "attachment; filename=foo." + fileNameExtension);
        //Response.BinaryWrite(renderedBytes);
        //Response.End();
        #endregion
    }
}
