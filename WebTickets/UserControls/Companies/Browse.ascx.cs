using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServicesLibrary.Entities;

public partial class UserControls_Companies_Browse : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected string FormatStatus(object entStatus)
    {
        string slStatus = ((Status)entStatus).Name;
        return slStatus;
    }
}
