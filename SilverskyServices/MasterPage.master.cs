using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using ServicesLibrary.Entities;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User entCurrenUser = (User)Session["currentUser"];
        if (entCurrenUser != null)
        {
            lblUserCompleteName.Text = entCurrenUser.UserCompleteName;
        }
        /*else
            FormsAuthentication.RedirectToLoginPage();*/

        string slPath = Server.MapPath("~/App_Themes/Default/Images/Logo.jpg");
        //imgLogo. = slPath;


        lblFecha.Text = String.Format("Hoy es {0:D}", DateTime.Now);
    }
    public string SetTitle
    {
        set { lblTitlePageMaster.Text = value; }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        
    }
    protected override void OnPreRender(EventArgs e)
    { 
        base.OnPreRender(e);
        if (Context.Session != null)
        {
            if (Context.Session.IsNewSession)
            {
                string sCookieHeader = Page.Request.Headers["Cookie"];
                if ((null != sCookieHeader) && (sCookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
                {
                    if (Page.Request.IsAuthenticated)
                    {
                        FormsAuthentication.SignOut();
                    }
                    Page.Response.Redirect(@"~/Default.aspx");
                }
            }
        }
    }
    protected override void OnInit(EventArgs e)
    {
        if (Session.IsNewSession)
            Response.Redirect(@"~/LoginPage.aspx");

        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5));
    }
    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Session.Remove("currentUser");        
        FormsAuthentication.RedirectToLoginPage();
        //Session["LoggingOut"] = true;        
    }
}
