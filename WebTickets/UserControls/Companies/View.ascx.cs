using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServicesLibrary.Entities;
using CoreLibrary.Company;

public partial class UserControls_Companies_View : System.Web.UI.UserControl
{
    private Company _EntCompany;

    public Company EntCompany
    {
        get
        {
            _EntCompany = (Company)ViewState["_EntCompany"];
            if (_EntCompany == null)
                _EntCompany = new Company();

            return _EntCompany;
        }
        set { ViewState["_EntCompany"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Controller controller = new Controller();
            int IdCompany = int.Parse(Request.Params["IdCompany"]);
            if (IdCompany > 0)
            {
                EntCompany = controller.GetByID(IdCompany);
                SetDataToForm();
            }
            else
            {
                EntCompany = new Company();
            }
            tbxName.Focus();
        }

    }
    private void SetDataToForm()
    {
        tbxName.Text = EntCompany.Name;
        tbxDescription.Text = EntCompany.Description;
        ddlStatus.SelectedValue = EntCompany.EntStatus.IdStatus.ToString();
    }
    private void GetDataFromForm()
    {
        EntCompany.Name = tbxName.Text;
        EntCompany.Description = tbxDescription.Text;
        EntCompany.EntStatus = new Status() { IdStatus = Convert.ToInt32(ddlStatus.SelectedValue), Name = ddlStatus.SelectedItem.Text };
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Controller controller = new Controller();
        GetDataFromForm();
        if (controller.Save(EntCompany))
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
