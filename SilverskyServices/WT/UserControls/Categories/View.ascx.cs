using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServicesLibrary.Entities;
using CoreLibrary.Category;
using CoreLibrary.Security;

public partial class UserControls_Categories_View : System.Web.UI.UserControl
{
    private Category _EntCategory;

    public Category EntCategory
    {
        get {
            _EntCategory = (Category)ViewState["_EntCategory"];
            if (_EntCategory == null)
                EntCategory = new Category();
            return _EntCategory; }
        set { ViewState["_EntCategory"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            Controller controller = new Controller();
            int IdCategory = int.Parse(Request.Params["IdCategory"]);
            if (IdCategory > 0)
            {
                EntCategory = controller.GetByID(IdCategory);
                SetDataToForm();
            }
            else
            {
                EntCategory = new Category();
                EntCategory.AssignedTo = new UserInfo();
            }
            tbxName.Focus();
        }        
    }
    private void SetDataToForm()
    {
        tbxName.Text = EntCategory.Name;
        tbxDefaultEmail.Text = EntCategory.AssignedTo.Email;
        tbxAlternativeEmail.Text = EntCategory.AlternativeMail;
        ddlAssignedTo.SelectedValue = EntCategory.AssignedTo.IdUser.ToString();
        ddlStatus.SelectedValue = EntCategory.EntStatus.IdStatus.ToString();
    }
    private void GetDataFromForm()
    {
        MembershipController membership = new MembershipController();
        EntCategory.Name = tbxName.Text;
        //EntCategory.AssignedTo = membership.GetUserById(Convert.ToInt32(ddlAssignedTo.SelectedValue));
        EntCategory.AlternativeMail = tbxAlternativeEmail.Text;
        EntCategory.EntStatus = new Status() { IdStatus = Convert.ToInt32(ddlStatus.SelectedValue), Name = ddlStatus.SelectedItem.Text };
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Controller controller = new Controller();
        GetDataFromForm();
        if (controller.Save(EntCategory))
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Error al guardar la información";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void ddlAssignedTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        MembershipController membership = new MembershipController();
        UserInfo assingto = membership.GetUserById(Convert.ToInt32(ddlAssignedTo.SelectedValue));
        EntCategory.AssignedTo = assingto;
        tbxDefaultEmail.Text = EntCategory.AssignedTo.Email;
        tbxAlternativeEmail.Focus();
    }
}
