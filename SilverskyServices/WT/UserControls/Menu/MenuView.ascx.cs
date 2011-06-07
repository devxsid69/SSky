using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CoreLibrary;
using DataAccessLibrary.Services;
using ServicesLibrary.Entities;

public partial class UserControls_Menu_MenuView : System.Web.UI.UserControl
{
    //ServicesLibrary.Entities.SiteMap as EntSiteMap;

    protected void Page_Load(object sender, EventArgs e)
    {
        BuildMenu();
    }

    private void BuildMenu() {
        CoreLibrary.SiteMap.Controller smController = new CoreLibrary.SiteMap.Controller();
        User entCurrenUser = (User)Session["currentUser"];
        List<ServicesLibrary.Entities.SiteMap> MenuItemsList = smController.GetMenuByIdRole(entCurrenUser.EntRole.IdRole);
        
        StringBuilder sbItemMenuLink = new StringBuilder();
        sbItemMenuLink.Append("<table class=\"menuTable\">");
        foreach(ServicesLibrary.Entities.SiteMap mItem in MenuItemsList)
        {
            
            string controlID = String.Format(" ID =\"itemLink{0} \"", System.Guid.NewGuid().ToString().Replace("-", ""));
            string runatServer = " runat=\"server\" ";
            string classproperty = " class=\"menu_link\" ";
            string hrefURL = String.Format(" href=\"{0}\"", this.ResolveClientUrl(mItem.URL));
            sbItemMenuLink.Append("<tr>");
            sbItemMenuLink.Append("<td >");//class=\"menu_link1\"
            
            sbItemMenuLink.Append("<a ");
            sbItemMenuLink.Append(controlID);
            sbItemMenuLink.Append(runatServer);
            //sbItemMenuLink.Append(classproperty);
            sbItemMenuLink.Append(hrefURL);
            sbItemMenuLink.Append(">");            
            sbItemMenuLink.Append(mItem.Name);            
            sbItemMenuLink.Append("</a>");            
            sbItemMenuLink.Append("</td>");
            
            sbItemMenuLink.Append("</tr>");
        }
        sbItemMenuLink.Append("</table>");
        this.Controls.Add(new LiteralControl(sbItemMenuLink.ToString()));
    }
}
