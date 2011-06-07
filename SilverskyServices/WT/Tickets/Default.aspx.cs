using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Tickets_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CoreLibrary.Security.RoleController roleController = new CoreLibrary.Security.RoleController();
        if ((HttpContext.Current.Session["CurrentUser"] == null) || (!HttpContext.Current.User.IsInRole(roleController.GetRoleCodeByURL(Request.AppRelativeCurrentExecutionFilePath))))
            FormsAuthentication.RedirectToLoginPage();
    }
}
