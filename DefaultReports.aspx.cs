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

namespace UAL.Web
{
	/// <summary>
	/// Summary description for DefaultReports.
	/// </summary>
	public class DefaultReports : PageTemplate
	{
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.PageName = "DefaultReports";
			this.PageTitle = "REPORTS";
         //   Response.Redirect(((UAL.Web.BasePage)Page).ApplicationBaseURL + "Dashboard.aspx");
		}
		#endregion Page_Load

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
