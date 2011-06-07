using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CoreLibrary;
using ServicesLibrary.Entities;

public partial class WT_UserControls_Configuration_Configuration : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void GetFromUI()
    {


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CoreLibrary.Configuration.Controller controller = new CoreLibrary.Configuration.Controller();

        List<GlobalAttribute> listEntAttributes = new List<GlobalAttribute>();
        foreach (var item in lvGlobalAttributes.Items)
        { 
            GlobalAttribute entAttribute = new GlobalAttribute();
            entAttribute.IdGlobalAttribute = Convert.ToInt32(((Label)(item.FindControl("lblIdGlobalAttribute"))).Text);
            entAttribute.Name = ((Label)(item.FindControl("lblName"))).Text;
            entAttribute.Value = ((TextBox)(item.FindControl("tbxValue"))).Text;
            entAttribute.Description = ((Label)(item.FindControl("lblDescription"))).Text;
            listEntAttributes.Add(entAttribute);
        }
        User entCurrenUser = (User)Session["currentUser"];
        if (controller.Save(listEntAttributes, entCurrenUser.IdApplication))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "GlobalAttributes", " alert('La información se guardo correctamente');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "GlobalAttributes", " alert('Error al guardar la información.');", true);
        }
    }
    
}
