using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServicesLibrary.Entities;
using System.Security.Authentication;

namespace CoreLibrary.CommonUtils
{
    public class EmailOperations
    {
        public static bool SendEmail(MailMessage mail, List<GlobalAttribute> listGlobalAttributes)
        {
            mail.IsBodyHtml = true;
            SmtpClient client = GetSmtpClient(listGlobalAttributes);

            try
            {
                client.Send(mail);
            }
            catch (SmtpFailedRecipientException)
            {
                return false;
            }
            catch (SmtpException)
            {
                return false;
            }
            catch (AuthenticationException)
            {
                return false;
            }
            
            return true;
        }

        private static SmtpClient GetSmtpClient(List<GlobalAttribute> listGlobalAttributes)
        {

            SmtpClient client = new SmtpClient(listGlobalAttributes.Where(s => s.Name == "server").FirstOrDefault().Value);

            client.UseDefaultCredentials = false;
            NetworkCredential theCredential = new System.Net.NetworkCredential(
                listGlobalAttributes.Where(s => s.Name == "user").FirstOrDefault().Value, listGlobalAttributes.Where(s => s.Name == "password").FirstOrDefault().Value);

            client.Credentials = theCredential;
            client.EnableSsl = true;
            client.Port = Convert.ToInt32(listGlobalAttributes.Where(s => s.Name == "port").FirstOrDefault().Value);
            
            return client;            
        }
    }
}
