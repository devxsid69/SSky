using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServicesLibrary.Entities;
using CoreLibrary.Security;

public partial class UserControls_Users_View : System.Web.UI.UserControl
{
    private UserInfo _EntUser;

    public UserInfo EntUser
    {
        get {
            _EntUser = (UserInfo)ViewState["_EntUser"];
            if (_EntUser == null)
                _EntUser = new UserInfo();
            return _EntUser; }
        set { ViewState["_EntUser"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!Page.IsPostBack)
        {
            MembershipController membershipCntrllr = new MembershipController();
            int IdUser = int.Parse(Request.Params["IdUser"]);
            if (IdUser > 0)
            {
                EntUser = membershipCntrllr.GetUserById(IdUser);
                rfvConfirmPassword.Enabled = false;
                rfvPassword.Enabled = false;
                SetDataToForm();
                tbxUserName.Focus();
            }
            else
            {
                EntUser = new UserInfo();
            }
            tbxUserName.Focus();
        }
    }
    private void SetDataToForm()
    {
        tbxUserName.Text = EntUser.UserName;
        tbxFirstName.Text = EntUser.FirstName;
        tbxLastName.Text = EntUser.LastName;
        tbxPassword.Text = EntUser.Password;
        tbxPasswordConfirm.Text = tbxPasswordConfirm.Text;
        ddlCompany.SelectedValue = EntUser.EntCompany.IdCompany.ToString();
        ddlStatus.SelectedValue = EntUser.EntStatus.IdStatus.ToString();
        ddlRoles.SelectedValue = EntUser.EntRole.IdRole.ToString();
        tbxEmail.Text = EntUser.Email;
    }    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    private void GetDataFromForm()
    {
        EntUser.UserName = tbxUserName.Text;
        EntUser.FirstName = tbxFirstName.Text;
        EntUser.LastName = tbxLastName.Text;
        if (tbxPassword.Text != "")
        {
            EntUser.Password = tbxPassword.Text;
            tbxPasswordConfirm.Text = tbxPasswordConfirm.Text;
        }
        EntUser.EntStatus = new Status() { IdStatus = Convert.ToInt32(ddlStatus.SelectedValue), Name = ddlStatus.SelectedItem.Text };
        EntUser.EntRole = new CoreLibrary.Security.RoleController().GetRoleByID(Convert.ToInt32(ddlRoles.SelectedValue));

        EntUser.EntCompany = new CoreLibrary.Company.Controller().GetByID(Convert.ToInt32(ddlCompany.SelectedValue));
        EntUser.Email = tbxEmail.Text;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        MembershipController membershipCntrllr = new MembershipController();
        GetDataFromForm();

        if (membershipCntrllr.Save(EntUser))
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Error al guardar la información";
        }
        

    }
}
