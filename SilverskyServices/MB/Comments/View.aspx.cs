using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using System.Net.Mail;
using CoreLibrary;

using ServicesLibrary.Entities;

public partial class MB_Comments_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        CoreLibrary.Security.RoleController roleController = new CoreLibrary.Security.RoleController();
        if ((HttpContext.Current.Session["CurrentUser"] == null) || (!HttpContext.Current.User.IsInRole(roleController.GetRoleCodeByURL(Request.AppRelativeCurrentExecutionFilePath))))
            FormsAuthentication.RedirectToLoginPage();

        int IdComment = int.Parse(Request.Params["IdComment"]);
        sentToForm(IdComment);
    }

    private void sentToForm(int IdComment)
    {
        CoreLibrary.Comment.Controller commentController = new CoreLibrary.Comment.Controller();
        Comment entComment = commentController.GetCommentByID(IdComment);
        lblCreatedOnDate.Text = entComment.CreatedOn.ToShortDateString();
        tbxeMail.Text = entComment.Email;
        tbxName.Text = entComment.Name;
        rblSupervisorRating.SelectedValue = entComment.SupervisorRating.ToString();
        rblCompanyOpinionRating.Text = entComment.CompanyOpinionRating.ToString();
        rblWorkEnviromentRating.SelectedValue = entComment.WorkEnviromentRating.ToString();
        tbxCompanyWorking.Text = entComment.CompanyWorking;
        rblGroupDirectorRating.Text = entComment.GroupDirectorRating.ToString();
        rblSecurityAnswer.SelectedValue = entComment.SecurityRating.ToString();
        tbxSubject.Text = entComment.Subject;
        tbxComment.Text = entComment.CommentSuggestion;
        commentController.MarkAsRead(IdComment);
    }

    protected void btnForward_Click(object sender, EventArgs e)
    {       

        List<GlobalAttribute> listGlobalAttributes = new CoreLibrary.Configuration.Controller().GetConfiguration(3);
        string PortalAddress = string.Empty;
        PortalAddress = String.Format("{0}://{1}:{2}{3}",
            HttpContext.Current.Request.Url.Scheme,
            HttpContext.Current.Request.Url.Host,
            HttpContext.Current.Request.Url.Port,
            Request.ApplicationPath != "/" ? Request.ApplicationPath : "");

        string BuidMail = "";
        #region Replace Template Content 
        BuidMail = String.Format(ForwardMailTemplate,
            lblCreatedOnDate.Text,
            tbxName.Text,
            tbxeMail.Text,
            tbxCompanyWorking.Text,
            rblSecurityAnswer.SelectedValue,
            rblCompanyOpinionRating.SelectedValue,
            rblSupervisorRating.SelectedValue,
            rblGroupDirectorRating.SelectedValue,
            rblWorkEnviromentRating.SelectedValue,
            tbxSubject.Text,
            tbxComment.Text);

        //string ReplaceFor = "";
        //string ReplaceRB = "";
        //if (rblSecurityAnswer.SelectedValue != "")
        //{
        //    ReplaceFor = String.Format(@"name=""rblSecurityAnswer"" value=""{0}"" checked=""checked""/>", rblSecurityAnswer.SelectedValue);
        //    ReplaceRB = String.Format(@"name=""rblSecurityAnswer"" value=""{0}"" />", rblSecurityAnswer.SelectedValue);
        //    BuidMail = BuidMail.Replace(ReplaceRB, ReplaceFor);
        //}
        //if (rblCompanyOpinionRating.SelectedValue != "")
        //{            
        //    ReplaceFor = String.Format(@"name=""rblCompanyOpinionRating"" value=""{0}"" checked=""checked""/>", rblCompanyOpinionRating.SelectedValue);
        //    ReplaceRB = String.Format(@"name=""rblCompanyOpinionRating"" value=""{0}"" />", rblCompanyOpinionRating.SelectedValue);
        //    BuidMail = BuidMail.Replace(ReplaceRB, ReplaceFor);
        //}
        //if (rblSupervisorRating.SelectedValue != "")
        //{
        //    ReplaceFor = String.Format(@"name=""rblSupervisorRating"" value=""{0}"" checked=""checked""/>", rblSupervisorRating.SelectedValue);
        //    ReplaceRB = String.Format(@"name=""rblSupervisorRating"" value=""{0}"" />", rblSupervisorRating.SelectedValue);
        //    BuidMail = BuidMail.Replace(ReplaceRB, ReplaceFor);
        //}
        //if (rblGroupDirectorRating.SelectedValue != "")
        //{
        //    ReplaceFor = String.Format(@"name=""rblGroupDirectorRating"" value=""{0}"" checked=""checked""/>", rblGroupDirectorRating.SelectedValue);
        //    ReplaceRB = String.Format(@"name=""rblGroupDirectorRating"" value=""{0}"" />", rblGroupDirectorRating.SelectedValue);
        //    BuidMail = BuidMail.Replace(ReplaceRB, ReplaceFor);
        //}
        //if (rblWorkEnviromentRating.SelectedValue != "")
        //{
        //    ReplaceFor = String.Format(@"name=""rblWorkEnviromentRating"" value=""{0}"" checked=""checked""/>", rblWorkEnviromentRating.SelectedValue);
        //    ReplaceRB = String.Format(@"name=""rblWorkEnviromentRating"" value=""{0}"" />", rblWorkEnviromentRating.SelectedValue);
        //    BuidMail = BuidMail.Replace(ReplaceRB, ReplaceFor);
        //}
        #endregion

        StringBuilder sbBody = new StringBuilder();
        sbBody.AppendLine("<p>");
        //sbBody.AppendLine("<IMG src=\"Logo.jpg\"><br/>");        
        sbBody.AppendLine("<br/>");
        sbBody.AppendLine(BuidMail);
        //sbBody.AppendLine(String.Format("Para ver la información da clic aqui:<a href=\"{0}/LoginPage.aspx\" >Ingresar</a>", PortalAddress));
        sbBody.AppendLine("</p>");
        
        //string slImagePath = Server.MapPath(@"~/App_Themes/Default/Images/Logo.jpg");
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(listGlobalAttributes.Where(s => s.Name == "from").FirstOrDefault().Value);
        string[] eMails = tbxForward.Text.Split(';').ToArray();
        foreach (string sleMail in eMails)
        {
            string email = sleMail;
            email = email.Replace("\r", "");
            email = email.Replace("\n", "");
            email = email.Replace("\t", "");
            mail.To.Add(email);
        }
        //mail.Attachments.Add(new Attachment(slImagePath));
        
        mail.Subject = "Rv: Mensaje";
        mail.Body = sbBody.ToString();
        if(CoreLibrary.CommonUtils.EmailOperations.SendEmail(mail, listGlobalAttributes))
            ScriptManager.RegisterStartupScript(this, this.GetType(), "GlobalAttributes", " alert('La información se envio por email correctamente.');", true);

    }
    #region Template
    private string ForwardMailTemplate = @"
    <table class=""tableComment"">
        <tr>
            <td colspan=""2"">
                <h2>
                    Comentario</h2>
            </td>
        </tr>
        <tr>
            <td>
                <span id=""lblCommentCreatedOn"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">Enviado el:</span>
            </td>
            <td align=""right"">
                <span id=""lblCommentCreatedOnDate"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">{0}</span>
            </td>
        </tr>
        <tr>
            <td>
                <span id=""lblName"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">Nombre
                    :</span>
            </td>
            <td>
                <span id=""lblNameAnswer"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">{1}</span>
            </td>
        </tr>
        <tr>
            <td>
                <span id=""lbleMail"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">
                    Email :</span>
            </td>
            <td>
                <span id=""lbleMailAnswer"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">{2}</span>                
            </td>
        </tr>
        <tr>
            <td>
                <span id=""lblCompany"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">
                    ¿Empresa en la que laboras?</span>
            </td>
            <td>
                <span id=""lblCompanyAnswer"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">{3}</span>                
            </td>
        </tr>
        <tr>
            <td>
                <span id=""lblSecurityRating"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">
                    ¿Que tan seguro te sientes en la empresa?</span>
            </td>
            <td>
                <span id=""lblSecurityRatingAnswer"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">{4}</span>
            </td>
        </tr>
        <tr>
            <td>
                <span id=""lblCompanyRating"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">
                    ¿Cómo ves la Empresa?</span>
            </td>
            <td>
                <span id=""lblCompanyRatingAnswer"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">{5}</span>
            </td>
        </tr>
        <tr>
            <td>
                <span id=""lblSupervisorRating"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">
                    ¿Como calificarías a tu Jefe Directo?</span>
            </td>
            <td>
                <span id=""lblSupervisorRating"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">{6}</span>
            </td>
        </tr>
        <tr>
            <td>
                <span id=""lblGroupDirectorRating"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">
                    ¿Qué opinas del Director del Grupo?</span>
            </td>
            <td>
                <span id=""lblGroupDirectorRating"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">{7}</span>
            </td>
        </tr>
        <tr>
            <td>
                <span id=""lblWorkEnviromentRating"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">
                    ¿En general como calificas el<br />
                    ambiente laboral de la empresa?</span>
            </td>
            <td>
                <span id=""lblWorkEnviromentRating"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">{8}</span>
            </td>
        </tr>
        <tr>
            <td>
                <span id=""lblSubject"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">
                    Asunto:</span>
            </td>
            <td>
                <span id=""lblSubject"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">{9}</span>                
            </td>
        </tr>
        <tr>
            <td>
                <span id=""lblComment"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">
                    ¿Algún comentario o sugerencia
                    <br />
                    para la mejora del grupo?</span>
            </td>
            <td>
                <span id=""lblComment"" style=""color: #666666; font-family: Verdana; font-size: 0.7em;"">{10}</span>                
            </td>
        </tr>
    </table>
";

    #endregion
   }
