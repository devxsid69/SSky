using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServicesLibrary.Entities;
using CoreLibrary;

public partial class UserControls_Roles_View : System.Web.UI.UserControl
{
    private RoleInfo _EntRole;

    public RoleInfo EntRole
    {
        get {
            _EntRole = (RoleInfo)ViewState["_EntRole"];
            if (_EntRole == null)
                _EntRole = new RoleInfo();
            return _EntRole; }
        set { ViewState["_EntRole"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblError.Visible = false;
            CoreLibrary.Security.RoleController roleController = new CoreLibrary.Security.RoleController();
            int IdRole = int.Parse(Request.Params["IdRole"]);
            
            if (IdRole > 0)
            {
                EntRole = roleController.GetRoleByID(IdRole);
                SetDataToForm();
            }
            else
            {
                EntRole = new RoleInfo();
                
            }
            EntRole.EntListSiteMap = new List<ServicesLibrary.Entities.SiteMap>();

            BuidlRolesTree();
            tbxName.Focus();
        }
        tvSiteMap.Attributes.Add("onclick", "client_OnTreeNodeChecked();");
        Page.ClientScript.RegisterClientScriptInclude("role", Page.ResolveUrl("~/js/Roles.js"));
        
        //TreeNode tnItem = new TreeNode();
        //tnItem.
     
        //TreeView2.Nodes.Add(
    }
    private void SetDataToForm()
    {
        tbxName.Text = EntRole.Name;
        tbxDescription.Text = EntRole.Description;
        tbxCode.Text = EntRole.RoleCode;
        ddlStatus.SelectedValue = EntRole.EntStatus.IdStatus.ToString();
    }
    private void GetDataFromForm()
    {
        EntRole.Name = tbxName.Text;
        EntRole.Description = tbxDescription.Text;
        EntRole.RoleCode = tbxCode.Text;
        EntRole.EntStatus = new Status() { IdStatus = Convert.ToInt32(ddlStatus.SelectedValue), Name = ddlStatus.SelectedItem.Text };
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblError.Visible = false;
        CoreLibrary.Security.RoleController roleController = new CoreLibrary.Security.RoleController();
        Dictionary<int, int> rolesitemap = new Dictionary<int, int>();
        rolesitemap = CheckParentThatHasCheckedChildren(tvSiteMap.Nodes[0], rolesitemap);
        GetDataFromForm();
        if (roleController.Save(EntRole, rolesitemap))
        {


            Response.Redirect("Default.aspx");
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Error al guardar la información";
        }
    }
    public void BuidlRolesTree()
    {
        CoreLibrary.SiteMap.Controller smController = new CoreLibrary.SiteMap.Controller();
        List<ServicesLibrary.Entities.SiteMap> sitemapList = smController.GetAll().OrderBy(c => c.IdParent).ToList();
        List<SiteMapTree> smtList = new List<SiteMapTree>();

        int ilLevel = 0;
        int? ilParent = 0;
        string slParentKey ="";
        foreach (ServicesLibrary.Entities.SiteMap smItem in sitemapList)
        {
            if (ilParent != smItem.IdParent)
            {                
                ilLevel = smtList.Where(c => c.IdSiteMap == smItem.IdParent).FirstOrDefault().Level + 1;
                ilParent = smItem.IdParent.Value;
            }
            slParentKey =String.Format("{0}",smtList.Where(c=>c.IdSiteMap == (ilParent==null?null :ilParent) ).Select(c=> c.OrderKey).FirstOrDefault());

            
            SiteMapTree smtItem = new SiteMapTree()
            {
                Level = ilLevel,
                IdSiteMap = smItem.IdSiteMap,
                IdParent = smItem.IdParent,
                Description = smItem.Description,
                EntStatus = smItem.EntStatus,
                IsBrowsable = smItem.IsBrowsable,
                Name = smItem.Name,
                RoleCode = smItem.RoleCode,
                URL = smItem.URL,
                OrderKey = String.Format("{0}{1}", slParentKey != "" ? slParentKey + "," : "", ilLevel.ToString())
                //OrderKey = String.Format("{0}", slParentKey != "" ? slParentKey + "," : slParentKey)
            };
            //OrderKey = String.Format("{0}-{1}-{2}",ilLevel,smItem.IdSiteMap,smItem.IdParent)
            smtList.Add(smtItem);
        }
         smtList = smtList.OrderBy(c => c.OrderKey).ToList();

         tvSiteMap.Nodes.Clear();
         
         BuildTreeView(null, smtList, 0);

         //return smtList;
    }
    private TreeNode BuildTreeView(TreeNode node, List<SiteMapTree> smtList, int ilItem)
    {
        CoreLibrary.Security.RoleController roleController = new CoreLibrary.Security.RoleController();
        Dictionary<int, int> Roles = roleController.GetRolesSiteMapByIdRole(EntRole.IdRole);
        if (ilItem < smtList.Count)
        {
            
            SiteMapTree smtItem = smtList[ilItem];
            ilItem= ilItem+1;
            if (node != null)
            {
                if (node.Value == smtItem.IdParent.ToString())
                {
                    TreeNode tnItem = new TreeNode();
                    int ilValue=Roles.Where(s => s.Key == smtItem.IdSiteMap).FirstOrDefault().Value;
                    tnItem.Value = smtItem.IdSiteMap.ToString();
                    tnItem.Text = smtItem.Name;
                    tnItem.SelectAction = TreeNodeSelectAction.None;
                    if (ilValue != 0)
                        tnItem.Checked = true;

                    tnItem = BuildTreeView(tnItem, smtList, ilItem);
                    node.ChildNodes.Add(tnItem);
                    
                }
                
                node = BuildTreeView(node, smtList, ilItem);
            }
            else
            {
                node = new TreeNode();
                int ilValue = Roles.Where(s => s.Key == smtItem.IdSiteMap).FirstOrDefault().Value;
                node.Value = smtItem.IdSiteMap.ToString();
                node.Text = smtItem.Name;
                node.SelectAction = TreeNodeSelectAction.None;
                node.Checked = true;                
                node = BuildTreeView(node, smtList, ilItem);
                tvSiteMap.Nodes.Add(node);
            }
        }
        return node;
        
    }
    protected Dictionary<int,int> CheckParentThatHasCheckedChildren(TreeNode treeNode,Dictionary<int,int> rolesitemap)
    {
        foreach (TreeNode childNode in treeNode.ChildNodes)
            rolesitemap = CheckParentThatHasCheckedChildren(childNode, rolesitemap);

        if (treeNode.Parent != null)
        {
            treeNode.Parent.Checked = treeNode.Checked | treeNode.Parent.Checked;
            if (treeNode.Parent.Checked)
            {
                KeyValuePair<int, int> parentkey = rolesitemap.Where(c => c.Key == int.Parse(treeNode.Parent.Value)).FirstOrDefault();
                if (parentkey.Key == 0)
                {
                    rolesitemap.Add(int.Parse(treeNode.Parent.Value), EntRole.IdRole);
                    EntRole.EntListSiteMap.Add(new ServicesLibrary.Entities.SiteMap() { IdSiteMap = int.Parse(treeNode.Parent.Value) });
                }

                if (treeNode.Checked)
                {
                    KeyValuePair<int, int> nodekey = rolesitemap.Where(c => c.Key == int.Parse(treeNode.Value)).FirstOrDefault();
                    if (nodekey.Key == 0)
                    {
                        rolesitemap.Add(int.Parse(treeNode.Value), EntRole.IdRole);
                        EntRole.EntListSiteMap.Add(new ServicesLibrary.Entities.SiteMap() { IdSiteMap = int.Parse(treeNode.Value) });
                    }
                }

            }
        }
        return rolesitemap;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }


    protected void tvSiteMap_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        
    }
}
public class SiteMapTree : ServicesLibrary.Entities.SiteMap
{
    private int _Level;

    public int Level
    {
        get { return _Level; }
        set { _Level = value; }
    }
    private string _OrderKey;

    public string OrderKey
    {
        get { return _OrderKey; }
        set { _OrderKey = value; }
    }
}
