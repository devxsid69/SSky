using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;

using ServicesLibrary.Entities;
using CoreLibrary.Security;
using CoreLibrary.Ticket;

public partial class UserControls_Tickets_Close : System.Web.UI.UserControl
{
    private Ticket _EntTicket;

    public Ticket EntTicket
    {
        get
        {
            _EntTicket = (Ticket)ViewState["_EntTicket"];
            if (_EntTicket == null)
                _EntTicket = new Ticket();
            return _EntTicket;
        }
        set { ViewState["_EntTicket"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!Page.IsPostBack)
        {
            int IdTicket = int.Parse(Request.Params["IdTicket"]);
            if (IdTicket > 0)
            {
                Controller tcontroller = new Controller();
                EntTicket = tcontroller.SelectByID(IdTicket);
                SetDataToForm();
                tbxCloseDescription.Focus();
            }
        }
    }
    private void SetDataToForm()
    {
        lblCategoryTxt.Text = EntTicket.Category.Name;
        lblOpenedByTxt.Text = EntTicket.CreatedBy.UserCompleteName;
        lblOpenedOnTxt.Text = String.Format("{0:d}", EntTicket.CreatedOn);
        tbxDescription.Text = EntTicket.Description;
    }
    private void GetDataFromForm()
    {
        EntTicket.CloseDescription = tbxCloseDescription.Text;
        EntTicket.TicketStatus = Ticket.TicketStatusEnum.Cerrado;
        EntTicket.ClosedOn = DateTime.Now;
        EntTicket.ClosedOnByUser = DateTime.Now;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {          
        Controller tcontroller = new Controller();        
        GetDataFromForm();
        int ilResult =tcontroller.Save(EntTicket);
        if (ilResult!=-1)
        {
            
            Ticket lastTicket = EntTicket;
            Category EntCategory = EntTicket.Category;
            TicketCloseSendMail(EntCategory, lastTicket);
            btnSave.Visible = false;
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Error al guardar la información";
        }
    }
    private void TicketCloseSendMail(Category EntCategory, Ticket lastTicket)
    {
        User entCurrenUser = (User)Session["currentUser"];
        List<GlobalAttribute> listGlobalAttributes = new CoreLibrary.Configuration.Controller().GetConfiguration(entCurrenUser.IdApplication);
        StringBuilder sbBody = new StringBuilder();
        sbBody.AppendLine("<p>");
        sbBody.AppendLine("<IMG src=\"Logo.jpg\"><br/>");
        sbBody.AppendFormat("<strong>Ticket No: {0}</strong>", lastTicket.IdTicket);
        sbBody.AppendLine("<br/>");
        sbBody.AppendFormat("<strong>Cerradp por: {0} el {1:d} </strong>", lastTicket.AssignedTo.UserCompleteName, lastTicket.ClosedOn);
        sbBody.AppendLine("<br/>");
        sbBody.AppendLine("<strong>Descripción:</strong>");
        sbBody.AppendFormat("<i>{0}</i>", lastTicket.Description);
        sbBody.AppendLine("<br/>");
        sbBody.AppendLine("<strong>Descripción de Cierre:</strong>");
        sbBody.AppendFormat("<i>{0}</i>", lastTicket.CloseDescription);
        sbBody.AppendLine("<br/>");        
        sbBody.AppendLine("</p>");
        string slImagePath = Server.MapPath(@"~/App_Themes/Default/Images/Logo.jpg");

        MailMessage mail = new MailMessage(listGlobalAttributes.Where(s => s.Name == "from").FirstOrDefault().Value, EntCategory.DefaultMail);
        //MailMessage mail = new MailMessage("leonardoruiz82@gmail.com", EntCategory.DefaultMail);
        mail.Attachments.Add(new Attachment(slImagePath));
        if (EntCategory.AlternativeMail != "")
            mail.To.Add(EntCategory.AlternativeMail);
        mail.Subject = "Ticket Cerrado";
        mail.Body = sbBody.ToString();
        CoreLibrary.CommonUtils.EmailOperations.SendEmail(mail, listGlobalAttributes);
    }
}
