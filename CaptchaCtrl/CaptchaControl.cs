using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;


/// <summary>
/// CAPTCHA ASP.NET 2.0 user control
/// </summary>
/// <remarks>
/// add a reference to this DLL and add the CaptchaControl to your toolbox;
/// then just drag and drop the control on a web form and set properties on it.
///
/// Jeff Atwood
/// http://www.codinghorror.com/
/// </remarks>
namespace CaptchaCtrl
{

    [DefaultProperty("Text")]
    public class CaptchaControl : System.Web.UI.WebControls.WebControl, INamingContainer, IPostBackDataHandler, IValidator
    {

        public enum Layout
        {
            Horizontal,
            Vertical
        }

        public enum CacheType
        {
            HttpRuntime,
            Session
        }

        private int _timeoutSecondsMax = 90;
        private int _timeoutSecondsMin = 0;
        private bool _userValidated = true;
        private string _text = "Enter the code shown  ";
        private string _font = "";
        private CaptchaImage _captcha = new CaptchaImage();
        private Layout _layoutStyle = Layout.Horizontal;
        private string _prevguid;
        private string _errorMessage = "";       

        private CacheType _cacheStrategy = CacheType.HttpRuntime;
        #region "  Public Properties"

        [Browsable(false), 
        Bindable(true), 
        Category("Appearance"), 
        DefaultValue("The text you typed does not match the text in the image."), 
        Description("Message to display in a Validation Summary when the CAPTCHA fails to validate.")]
        public string ErrorMessage
        {
            get
            {
                if (!_userValidated)
                {
                    return _errorMessage;
                }
                else
                {
                    return "";
                }
            }
            set { _errorMessage = value; }
        }

        [Browsable(false), 
        Category("Behavior"), 
        DefaultValue(true), 
        Description("Is Valid"), 
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsValid
        {
            get { return _userValidated; }
            set { }
        }

        public override bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                // When a validator is disabled, generally, the intent is not to
                // make the page invalid for that round trip.
                if (!value)
                {
                    _userValidated = true;
                }
            }
        }


        [DefaultValue("Enter the code shown above:"), Description("Instructional text displayed next to CAPTCHA image."), Category("Appearance")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        [DefaultValue(typeof(CaptchaControl.Layout), "Horizontal"), Description("Determines if image and input area are displayed horizontally, or vertically."), Category("Captcha")]
        public Layout LayoutStyle
        {
            get { return _layoutStyle; }
            set { _layoutStyle = value; }
        }

        [DefaultValue(typeof(CaptchaControl.CacheType), "HttpRuntime"), Description("Determines if CAPTCHA codes are stored in HttpRuntime (fast, but local to current server) or Session (more portable across web farms)."), Category("Captcha")]
        public CacheType CacheStrategy
        {
            get { return _cacheStrategy; }
            set { _cacheStrategy = value; }
        }

        [Description("Returns True if the user was CAPTCHA validated after a postback."), Category("Captcha")]
        public bool UserValidated
        {
            get { return _userValidated; }
        }


        [DefaultValue(""), Description("Font used to render CAPTCHA text. If font name is blank, a random font will be chosen."), Category("Captcha")]
        public string CaptchaFont
        {
            get { return _font; }
            set
            {
                _font = value;
                _captcha.Font = _font;
            }
        }

        [DefaultValue(""), Description("Characters used to render CAPTCHA text. A character will be picked randomly from the string."), Category("Captcha")]
        public string CaptchaChars
        {
            get { return _captcha.TextChars; }
            set { _captcha.TextChars = value; }
        }

        [DefaultValue(5), Description("Number of CaptchaChars used in the CAPTCHA text"), Category("Captcha")]
        public int CaptchaLength
        {
            get { return _captcha.TextLength; }
            set { _captcha.TextLength = value; }
        }

        [DefaultValue(2), Description("Minimum number of seconds CAPTCHA must be displayed before it is valid. If you're too fast, you must be a robot. Set to zero to disable."), Category("Captcha")]
        public int CaptchaMinTimeout
        {
            get { return _timeoutSecondsMin; }
            set
            {
                if (value > 15)
                {
                    throw new ArgumentOutOfRangeException("CaptchaTimeout", "Timeout must be less than 15 seconds. Humans aren't that slow!");
                }
                _timeoutSecondsMin = value;
            }
        }

        [DefaultValue(90), Description("Maximum number of seconds CAPTCHA will be cached and valid. If you're too slow, you may be a CAPTCHA hack attempt. Set to zero to disable."), Category("Captcha")]
        public int CaptchaMaxTimeout
        {
            get { return _timeoutSecondsMax; }
            set
            {
                if (value < 15 & value != 0)
                {
                    throw new ArgumentOutOfRangeException("CaptchaTimeout", "Timeout must be greater than 15 seconds. Humans can't type that fast!");
                }
                _timeoutSecondsMax = value;
            }
        }

        [DefaultValue(50), Description("Height of generated CAPTCHA image."), Category("Captcha")]
        public int CaptchaHeight
        {
            get { return _captcha.Height; }
            set { _captcha.Height = value; }
        }

        [DefaultValue(180), Description("Width of generated CAPTCHA image."), Category("Captcha")]
        public int CaptchaWidth
        {
            get { return _captcha.Width; }
            set { _captcha.Width = value; }
        }

        [DefaultValue(typeof(CaptchaImage.FontWarpFactor), "Low"), Description("Amount of random font warping used on the CAPTCHA text"), Category("Captcha")]
        public CaptchaImage.FontWarpFactor CaptchaFontWarping
        {
            get { return _captcha.FontWarp; }
            set { _captcha.FontWarp = value; }
        }

        [DefaultValue(typeof(CaptchaImage.BackgroundNoiseLevel), "Low"), Description("Amount of background noise to generate in the CAPTCHA image"), Category("Captcha")]
        public CaptchaImage.BackgroundNoiseLevel CaptchaBackgroundNoise
        {
            get { return _captcha.BackgroundNoise; }
            set { _captcha.BackgroundNoise = value; }
        }

        [DefaultValue(typeof(CaptchaImage.LineNoiseLevel), "None"), Description("Add line noise to the CAPTCHA image"), Category("Captcha")]
        public CaptchaImage.LineNoiseLevel CaptchaLineNoise
        {
            get { return _captcha.LineNoise; }
            set { _captcha.LineNoise = value; }
        }
        #endregion
        public void Validate()
        {
            //-- a no-op, since we validate in LoadPostData
            
        }

        private CaptchaImage GetCachedCaptcha(string guid)
        {
            if (_cacheStrategy == CacheType.HttpRuntime)
            {
                return (CaptchaImage)HttpRuntime.Cache.Get(guid);
            }
            else
            {
                return (CaptchaImage)HttpContext.Current.Session[guid];
            }
        }

        private void RemoveCachedCaptcha(string guid)
        {
            if (_cacheStrategy == CacheType.HttpRuntime)
            {
                HttpRuntime.Cache.Remove(guid);
            }
            else
            {
                HttpContext.Current.Session.Remove(guid);
            }
        }

        /// <summary>
        /// are we in design mode?
        /// </summary>
        private bool IsDesignMode
        {
            get { return HttpContext.Current == null; }
        }

        /// <summary>
        /// Validate the user's text against the CAPTCHA text
        /// </summary>
        private void ValidateCaptcha(string userEntry)
        {
            HttpContext.Current.Session["isValidCaptcha"] = true;
            if (!Visible | !Enabled)
            {
                _userValidated = true;

                return;
            }

            //-- retrieve the previous captcha from the cache to inspect its properties
            CaptchaImage ci = GetCachedCaptcha(_prevguid);
            if (ci == null)
            {
                this.ErrorMessage = "El codigo ingresado expiro despues " + this.CaptchaMaxTimeout + " segundos.";
                HttpContext.Current.Session["isValidCaptcha"] = false;
                _userValidated = false;
                return;
            }

            //--  was it entered too quickly?
            if (this.CaptchaMinTimeout > 0)
            {
                if ((ci.RenderedAt.AddSeconds(this.CaptchaMinTimeout) > DateTime.Now))
                {
                    _userValidated = false;
                    this.ErrorMessage = "El codigo fue ingresado muy pronto. Espera al menos " + this.CaptchaMinTimeout + " segundos.";
                    
                    RemoveCachedCaptcha(_prevguid);
                    return;
                }
            }

            if (string.Compare(userEntry, ci.Text, true) != 0)
            {
                this.ErrorMessage = "El codigo ingresado no corresponde con el que se muestra en la imagen.";
                HttpContext.Current.Session["isValidCaptcha"] = false;
                _userValidated = false;
                RemoveCachedCaptcha(_prevguid);
                return;
            }

            _userValidated = true;
            RemoveCachedCaptcha(_prevguid);
        }

        /// <summary>
        /// returns HTML-ized color strings
        /// </summary>
        private string HtmlColor(System.Drawing.Color color)
        {
            if (color.IsEmpty)
                return "";
            if (color.IsNamedColor)
            {
                return color.ToKnownColor().ToString();
            }
            if (color.IsSystemColor)
            {
                return color.ToString();
            }
            return "#" + color.ToArgb().ToString("x").Substring(2);
        }

      

        /// <summary>
        /// render raw control HTML to the page
        /// </summary>
        protected override void Render(HtmlTextWriter Output)
        {
            var _with2 = Output;
            //-- master DIV
            _with2.Write("<div");
            //if (!string.IsNullOrEmpty(CssClass))
            //{
            //    _with2.Write(" class='" + CssClass + "'");
            //}
            //_with2.Write(CssStyle());
            _with2.Write(">");


            //-- text input and submit button DIV/SPAN
            if (this.LayoutStyle == Layout.Vertical)
            {
                _with2.Write("<div'>");
            }
            else
            {
                _with2.Write("<span>");
            }
            if (_text.Length > 0)
            {
                _with2.Write(_text);
            }
            _with2.Write("&nbsp; <input name=" + UniqueID + " type=text size=");
            _with2.Write(_captcha.TextLength.ToString());
            _with2.Write(" maxlength=");
            _with2.Write(_captcha.TextLength.ToString());
            if (AccessKey.Length > 0)
            {
                _with2.Write(" accesskey=" + AccessKey);
            }
            if (!Enabled)
            {
                _with2.Write(" disabled=\"disabled\"");
            }
            if (TabIndex > 0)
            {
                _with2.Write(" tabindex=" + TabIndex.ToString());
            }
            _with2.Write(" value=''>");
            //if (this.LayoutStyle == Layout.Vertical)
            //{
            //    _with2.Write("</div>");
            //}
            //else
            //{
            //    _with2.Write("</span>");
            //    _with2.Write("<br clear='all'>");
            //}



            ////-- image DIV/SPAN
            //if (this.LayoutStyle == Layout.Vertical)
            //{
            //    _with2.Write("<div><br/> ");
            //}
            //else
            //{
            //    _with2.Write("<span>");
            //}
            //-- this is the URL that triggers the CaptchaImageHandler
            _with2.Write("<img src=\"CaptchaImage.aspx");
            if (!IsDesignMode)
            {
                _with2.Write("?guid=" + Convert.ToString(_captcha.UniqueId));
            }
            if (this.CacheStrategy == CacheType.Session)
            {
                _with2.Write("&s=1");
            }
            _with2.Write("\" border='0'");
            if (ToolTip.Length > 0)
            {
                _with2.Write(" alt='" + ToolTip + "'");
            }
            _with2.Write(" width=" + _captcha.Width);
            _with2.Write(" height=" + _captcha.Height);
            _with2.Write(">");
            if (this.LayoutStyle == Layout.Vertical)
            {
                _with2.Write("</div>");
            }
            else
            {
                _with2.Write("</span>");
            }

            

            //-- closing tag for master DIV
            _with2.Write("</div>");
        }

        /// <summary>
        /// generate a new captcha and store it in the ASP.NET Cache by unique GUID
        /// </summary>
        private void GenerateNewCaptcha()
        {
            if (!IsDesignMode)
            {
                if (_cacheStrategy == CacheType.HttpRuntime)
                {
                    HttpRuntime.Cache.Add(_captcha.UniqueId, _captcha, null, DateTime.Now.AddSeconds(Convert.ToDouble((this.CaptchaMaxTimeout == 0 ? 90 : this.CaptchaMaxTimeout))), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                }
                else
                {
                    HttpContext.Current.Session.Add(_captcha.UniqueId, _captcha);
                }
            }
        }

        /// <summary>
        /// Retrieve the user's CAPTCHA input from the posted data
        /// </summary>
        public bool LoadPostData(string PostDataKey, NameValueCollection Values)
        {
            ValidateCaptcha(Convert.ToString(Values[this.UniqueID]));
            return false;
        }

        public void RaisePostDataChangedEvent()
        {
        }

        protected override object SaveControlState()
        {
            return (object)_captcha.UniqueId;
        }

        protected override void LoadControlState(object state)
        {
            if (state != null)
            {
                _prevguid = Convert.ToString(state);
            }
        }

        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
            Page.Validators.Add(this);

        }

        protected override void OnUnload(System.EventArgs e)
        {
            if ((Page != null))
            {
                Page.Validators.Remove(this);
            }
            base.OnUnload(e);
        }

        protected override void OnPreRender(System.EventArgs e)
        {
            if (this.Visible)
            {
                GenerateNewCaptcha();
            }
            base.OnPreRender(e);
        }

    }


}




