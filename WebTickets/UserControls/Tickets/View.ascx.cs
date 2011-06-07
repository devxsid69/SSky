using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using ServicesLibrary.Entities;
using System.Text;

using CoreLibrary.Security;
using CoreLibrary.Ticket;

public partial class UserControls_Tickets_View : System.Web.UI.UserControl
{
    private Ticket _EntTicket;

    public Ticket EntTicket
    {
        get {
            _EntTicket = (Ticket)ViewState["_EntTicket"];
            if (_EntTicket == null)
                _EntTicket = new Ticket();
            return _EntTicket; }
        set { ViewState["_EntTicket"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MembershipController mcontroller = new MembershipController();
            User entCurrenUser = (User)Session["currentUser"];
            EntTicket = new Ticket();
            EntTicket.CreatedBy = mcontroller.GetUserById(entCurrenUser.IdUser);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    private void GetDataFromForm()
    {
        
        EntTicket.CloseDescription = "";
        EntTicket.CreatedOn = DateTime.Now;
        EntTicket.Description = tbxDescription.Text;
        EntTicket.IdPrioriy = int.Parse(ddlCategory.SelectedValue.ToString());
        EntTicket.TicketStatus = Ticket.TicketStatusEnum.Abierto;
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CoreLibrary.Category.Controller ccontroller = new CoreLibrary.Category.Controller();
        Controller tcontroller = new Controller();
        int idCategory = int.Parse(ddlCategory.SelectedValue.ToString());
        GetDataFromForm();
        if (tcontroller.Save(EntTicket))
        {
            int IdTicket = tcontroller.GetLastID();
            Category EntCategory = ccontroller.GetByID(idCategory);
            Ticket lastTicket =tcontroller.SelectByID(IdTicket);
            TicketOpenSendMail(EntCategory, lastTicket);
            Response.Redirect("Default.aspx");
        }
    }

    private void TicketOpenSendMail(Category EntCategory, Ticket lastTicket)
    {
        string PortalAddress = string.Empty;
        PortalAddress = String.Format("{0}://{1}:{2}{3}",
            HttpContext.Current.Request.Url.Scheme,
            HttpContext.Current.Request.Url.Host,
            HttpContext.Current.Request.Url.Port,
            Request.ApplicationPath != "/" ? Request.ApplicationPath : "");

        StringBuilder sbBody = new StringBuilder();
        sbBody.AppendLine("<p>");
        sbBody.AppendLine("<IMG src=\"Logo.png\"><br/>");
        sbBody.AppendFormat("<strong>Ticket No: {0}</strong>", lastTicket.IdTicket);
        sbBody.AppendLine("<br/>");
        sbBody.AppendFormat("<strong>Creado por: {0} el {1:d} </strong>", lastTicket.CreatedBy.UserCompleteName, lastTicket.CreatedOn);
        sbBody.AppendLine("<br/>");
        sbBody.AppendLine("<strong>Descripción:</strong>");
        sbBody.AppendFormat("<i>{0}</i>", lastTicket.Description);
        sbBody.AppendLine("<br/>");
        sbBody.AppendLine(String.Format("Para cerrar el ticket da clic aqui:<a href=\"{0}/Tickets/Close.aspx?IdTicket={1}\" >Cerrar Ticket</a>",PortalAddress, lastTicket.IdTicket));
        sbBody.AppendLine("</p>");
        string slImagePath = Server.MapPath(@"~/App_Themes/Default/Images/Logo.png");

        MailMessage mail = new MailMessage("leonardoruiz82@gmail.com", EntCategory.DefaultMail);
        mail.Attachments.Add(new Attachment(slImagePath));
        if (EntCategory.AlternativeMail != "")
            mail.To.Add(EntCategory.AlternativeMail);
        mail.Subject = "Ticket Abierto";
        mail.Body = sbBody.ToString();
        CoreLibrary.CommonUtils.EmailOperations.SendEmail(mail);
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {        
        CoreLibrary.Category.Controller ccontroller = new CoreLibrary.Category.Controller();
        int idCategory = int.Parse(ddlCategory.SelectedValue.ToString());
        if (idCategory > 0)
        {
            Category EntCategory = ccontroller.GetByID(idCategory);
            EntTicket.Category = EntCategory;
            EntTicket.AssignedTo = EntCategory.AssignedTo;
            tbxAssignedTo.Text = EntCategory.AssignedTo.UserCompleteName;
        }
    }
}
