using System;
using System.Web;
using UAL.ApplicationServices.Profile;
using UAL.Authentication;
//using UAL.ApplicationServices.Preferences.Profile;

namespace UAL.Web
{
    /// <summary>
    /// Summary description for _default.
    /// </summary>
    public class _default : PageTemplate
    {
        private void Page_Load(object sender, System.EventArgs e)
        {

            LoggedUser oLoggedUser = (LoggedUser)HttpContext.Current.User;
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(LoggedUser));
            //StringWriter stringWriter = new StringWriter();
            //XmlWriter xmlWriter = XmlWriter.Create(stringWriter);
            //xmlSerializer.Serialize(xmlWriter, oLoggedUser);
            //var xml = stringWriter.ToString(); // Your xml
            LoggedUserDTO loggedUserDTO = FillLogeedUserDTO(oLoggedUser);
            Session["LoggedUser"] = loggedUserDTO;
            long UserID = oLoggedUser.Profile.UserID;
            string strSessionId = Session.SessionID;
            Session["UserInfo"] = oLoggedUser.Profile.FirstName;
            //********Remove MenuITems from Cache*************
            Session["ApplicationMode"] = null;
            HttpContext.Current.Cache.Remove("MenuApplicationDropdown_" + UserID + "_" + strSessionId);
            HttpContext.Current.Cache.Remove("MenuBar_" + UserID + "_" + strSessionId);
            HttpContext.Current.Cache.Remove("ApplicationMode_" + UserID + "_" + strSessionId);
            //**************************************************
            string strRedirectToURL = string.Empty;
            if (Session["ReturnUrl"] != null && Session["ReturnUrl"].ToString() != String.Empty)
            {
                strRedirectToURL = Session["ReturnUrl"].ToString();
                //string strt = Session["Type"].ToString();
                if (Session["Type"] != null && Session["Type"].ToString().ToUpper() == "NEW")
                {
                    Response.Redirect(strRedirectToURL);
                    Session["Type"] = null;
                    return;
                }
                else
                {
                    strRedirectToURL = strRedirectToURL.Replace(strRedirectToURL.Substring(strRedirectToURL.IndexOf('/'), strRedirectToURL.IndexOf("/", 1)), String.Empty);
                }

            }
            if (strRedirectToURL != string.Empty && strRedirectToURL.ToLower() != "/default.aspx" && strRedirectToURL.ToLower().IndexOf("security") < 0 && strRedirectToURL.Trim() != "/")
            {
                Response.Redirect(ApplicationBaseURL + strRedirectToURL);
            }
            else
            {
                Response.Redirect(ApplicationBaseURL + "Dashboard.aspx");
            }
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion

        private LoggedUserDTO FillLogeedUserDTO(LoggedUser oLoggedUser)
        {
            LoggedUserDTO loggedUserDTO = new LoggedUserDTO();

            loggedUserDTO.identity = oLoggedUser.Identity;
            loggedUserDTO.Email = oLoggedUser.Profile.Email;
            loggedUserDTO.FirstName = oLoggedUser.Profile.FirstName;
            loggedUserDTO.MiddleName = oLoggedUser.Profile.MiddleName;
            loggedUserDTO.UserName = oLoggedUser.Profile.UserName;
            loggedUserDTO.FullName = oLoggedUser.Profile.FullName;
            loggedUserDTO.LastName = oLoggedUser.Profile.LastName;
            loggedUserDTO.SessionId = oLoggedUser.Profile.SessionID;
            loggedUserDTO.IPAddress = oLoggedUser.Profile.IPAddress;
            loggedUserDTO.UserID = oLoggedUser.Profile.UserID;
            loggedUserDTO.IsBatchNumberLogin = oLoggedUser.Profile.IsBatchNumberLogin;
            loggedUserDTO.TimeZone = oLoggedUser.UserSettings.TimeZone;
            loggedUserDTO.DateFormat = oLoggedUser.UserSettings.DateFormat;
            loggedUserDTO.PreferredCSS = oLoggedUser.UserSettings.PreferredCSS;
            loggedUserDTO.PreferredLanguage = oLoggedUser.UserSettings.PreferredLanguage;

            return loggedUserDTO;
        }
    }
}
