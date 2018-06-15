using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UAL.ApplicationServices.Security;
using UAL.ApplicationServices;
using UAL.ApplicationServices.Profile;

namespace UAL.Web
{
	/// <summary>
	/// Summary description for TermsAndConditions.
	/// </summary>
	public class TermsAndConditions : PageTemplate
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			LoggedUser oLoggedUser=(LoggedUser)HttpContext.Current.User;
			long UserID=oLoggedUser.Profile.UserID;
			string strSessionId=oLoggedUser.Profile.SessionID;
			//********Remove MenuITems from Cache*************
			Session["ApplicationMode"]=null;
			HttpContext.Current.Cache.Remove("MenuApplicationDropdown_" + UserID + "_" + strSessionId);
			HttpContext.Current.Cache.Remove("MenuBar_" + UserID + "_" + strSessionId);
			//**************************************************
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
	}
}
