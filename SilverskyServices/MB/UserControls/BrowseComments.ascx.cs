using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class MB_UserControls_BrowseComments : System.Web.UI.UserControl
{

    public DateTime dtStartRange
    {
        get
        {
            return Session["DateStart"] == null ? DateTime.Now.AddDays((DateTime.Now.Day - 1) * -1) : (DateTime)Session["DateStart"];
        }
        set
        {
            Session["DateStart"] = value;

        }
    }

    public DateTime dtEndRange
    {
        get
        {
            return Session["DateEnd"] == null ? DateTime.Now : (DateTime)Session["DateEnd"];
        }
        set
        {
            Session["DateEnd"] = value;

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            ceStartDate.SelectedDate = dtStartRange;
            ceEndDate.SelectedDate = dtEndRange;
            tbxStartDate.Text = ceStartDate.SelectedDate.Value.ToShortDateString();
            tbxEndDate.Text = ceEndDate.SelectedDate.Value.ToShortDateString();
        }
        
    }
    protected void imgbtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        dtStartRange = Convert.ToDateTime(tbxStartDate.Text);
        dtEndRange = Convert.ToDateTime(tbxEndDate.Text);
        ceStartDate.SelectedDate = dtStartRange;
        ceEndDate.SelectedDate = dtEndRange;
        tbxStartDate.Text = ceStartDate.SelectedDate.Value.ToShortDateString();
        tbxEndDate.Text = ceEndDate.SelectedDate.Value.ToShortDateString();
        lvMessagesList.DataBind();
    }
  
    protected void imbtnExport_Click(object sender, ImageClickEventArgs e)
    {

        string url = String.Format("../Comments/ViewReport.aspx?Company={0}&StartDate={1}&EndDate={2}&IsRead={3}", ddlCompany.SelectedValue,tbxStartDate.Text,tbxEndDate.Text,rblEstate.SelectedValue);
        string openScript = String.Format("<script>var hwnd=window.open('{0}', '_blank', 'Scrollbars=yes,Left=0px,Top=0px,Height=700,Width=900'); hwnd.focus(); </script>", url);
        if (!Page.ClientScript.IsStartupScriptRegistered("openWindow"))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "openWindow", openScript);
        }
    }
}
