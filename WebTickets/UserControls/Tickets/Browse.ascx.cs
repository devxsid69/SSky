using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServicesLibrary.Entities;

public partial class UserControls_Tickets_Browse : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HiddenIdCompany.Value = ((User)(HttpContext.Current.Session["currentUser"])).Company.IdCompany.ToString();
    }
    protected string FormatCategory(object entCategory)
    {
        Category EntCategory = (Category)entCategory;
        return EntCategory.Name;
    }
    protected string FormatAssignedTo(object entUserInfo)
    {
        UserInfo EntAssignedTo = (UserInfo)entUserInfo;
        return EntAssignedTo.UserCompleteName;
    }
}
