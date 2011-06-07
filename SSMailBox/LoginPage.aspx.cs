using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using SecurityProvider;
using CoreLibrary.Security;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Login1.Focus();
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        string username = Request.Form["UserID"];
        string password = Request.Form["Password"];

        if (username != null)
        {
            MembershipController mbsController = new MembershipController();
            if (mbsController.ValidateUser(username, password))
            {
                FormsAuthentication.RedirectFromLoginPage(username, false);
            }
            else
            {

            }
        }
    }
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {

    }
    protected void Login1_LoginError(object sender, EventArgs e)
    {

    }
}
