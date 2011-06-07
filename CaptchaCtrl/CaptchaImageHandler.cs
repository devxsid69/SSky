using System;
using System.Drawing;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace CaptchaCtrl
{
    /// <summary>
    /// Captcha image stream HttpModule. Retrieves CAPTCHA objects from cache, renders them to memory, 
    /// and streams them to the browser.
    /// </summary>
    /// <remarks>
    /// You *MUST* enable this HttpHandler in your web.config, like so:
    ///
    ///	  &lt;httpHandlers&gt;
    ///		  &lt;add verb="GET" path="CaptchaImage.aspx" type="WebControlCaptcha.CaptchaImageHandler, WebControlCaptcha" /&gt;
    ///	  &lt;/httpHandlers&gt;
    ///
    /// Jeff Atwood
    /// http://www.codinghorror.com/
    ///</remarks>
    public class CaptchaImageHandler : IHttpHandler
    {

        public void ProcessRequest(System.Web.HttpContext context)
        {
            HttpApplication app = context.ApplicationInstance;

            //-- get the unique GUID of the captcha; this must be passed in via the querystring
            string guid = app.Request.QueryString["guid"];
            CaptchaImage ci = null;

            if (!string.IsNullOrEmpty(guid))
            {
                if (string.IsNullOrEmpty(app.Request.QueryString["s"]))
                {
                    ci = (CaptchaImage)HttpRuntime.Cache.Get(guid);
                }
                else
                {
                    ci = (CaptchaImage)HttpContext.Current.Session[guid];
                }

            }

            if (ci == null)
            {
                app.Response.StatusCode = 404;
                context.ApplicationInstance.CompleteRequest();
                return;
            }

            //-- write the image to the HTTP output stream as an array of bytes
            Bitmap b = ci.RenderImage();
            b.Save(app.Context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            b.Dispose();
            app.Response.ContentType = "image/jpeg";
            app.Response.StatusCode = 200;
            context.ApplicationInstance.CompleteRequest();
        }

        public bool IsReusable
        {
            get { return true; }
        }

    }
}
