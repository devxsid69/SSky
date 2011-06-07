using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using CoreLibrary;
using ServicesLibrary.Entities;

public partial class MB_UserControls_FormQuestions : System.Web.UI.UserControl
{
    bool SubmitClick;
    private static bool CaptchaEnabled;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            SubmitClick = false;
        }

        CaptchaEnabled = bool.Parse(ConfigurationManager.AppSettings["CaptchaEnabled"].ToString());
        CaptchaControl1.Enabled = CaptchaEnabled;
        CaptchaControl1.Visible = CaptchaEnabled;

    }

    protected void Page_PreRender()
    {
        if (CaptchaEnabled)
        {
            if ((Session["isValidCaptcha"] != null) && SubmitClick)
                if (Convert.ToBoolean(Session["isValidCaptcha"]))
                {
                    Session.Remove("isValidCaptcha");
                    SaveInformation();
                }
        }
        else
        {
            if(SubmitClick)
                SaveInformation();
        }
    }

    private void SaveInformation()
    {
        SubmitClick = false;
        lblCustomMessage.Text = "";

        CoreLibrary.Comment.Controller controller = new CoreLibrary.Comment.Controller();
        Comment entComment = new Comment()
        {
            Email = tbxeMail.Text,
            Name = tbxName.Text,
            CompanyWorking = ddlCompany.SelectedValue,
            SupervisorRating = rblSupervisorRating.SelectedValue,
            CompanyOpinionRating = rblCompanyOpinionRating.SelectedValue,
            WorkEnviromentRating = rblWorkEnviromentRating.SelectedValue,
            GroupDirectorRating = rblGroupDirectorRating.SelectedValue,
            SecurityRating = rblSecurityAnswer.SelectedValue,
            Subject = tbxSubject.Text,
            CommentSuggestion = tbxComment.Text
        };
        if (controller.Save(entComment))
        {
            if (NewCommentSendMail(entComment))
                ScriptManager.RegisterStartupScript(this, this.GetType(), "GlobalAttributes", " alert('La información se envio correctamente');", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "GlobalAttributes", " alert('La información guarda correctamente, pero hubo problemas en el envio de correo');", true);
            //Response.Redirect("http://vamsaags.com/");
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        SubmitClick = true;
    }
    private bool NewCommentSendMail(Comment entComment)
    {
        List<GlobalAttribute> listGlobalAttributes = new CoreLibrary.Configuration.Controller().GetConfiguration(3);
        string PortalAddress = string.Empty;
        PortalAddress = String.Format("{0}://{1}:{2}{3}",
            HttpContext.Current.Request.Url.Scheme,
            HttpContext.Current.Request.Url.Host,
            HttpContext.Current.Request.Url.Port,
            Request.ApplicationPath != "/" ? Request.ApplicationPath : "");

        StringBuilder sbBody = new StringBuilder();
        sbBody.AppendLine("<p>");
        //sbBody.AppendLine("<IMG src=\"Logo.jpg\"><br/>");
        sbBody.AppendLine("<strong>Nuevo Comentario</strong>");
        sbBody.AppendLine("<br/>");
        sbBody.AppendLine(String.Format("Para ver la información da clic aqui:<a href=\"{0}/LoginPage.aspx\" >Ingresar</a>", PortalAddress));
        sbBody.AppendLine("</p>");
        //string slImagePath = Server.MapPath(@"~/App_Themes/Default/Images/Logo.jpg");

        MailMessage mail = new MailMessage(listGlobalAttributes.Where(s => s.Name == "from").FirstOrDefault().Value, listGlobalAttributes.Where(s => s.Name == "to").FirstOrDefault().Value);
        //mail.Attachments.Add(new Attachment(slImagePath));
        
        
        mail.Subject = "Nuevo Mensaje";
        mail.Body = sbBody.ToString();
        return CoreLibrary.CommonUtils.EmailOperations.SendEmail(mail, listGlobalAttributes);
    }
}
