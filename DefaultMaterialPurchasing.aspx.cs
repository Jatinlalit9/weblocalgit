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
using UAL.Constants;

namespace UAL.Web
{
	/// <summary>
	/// Summary description for DefaultRerollReceipts.
	/// </summary>
	public class DefaultMaterialPurchasing : PageTemplate
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.PageName = "DefaultMaterialPurchasing";
			this.PageTitle = "MATERIAL PURCHASING";
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			this.ApplicationID = Constants.eApplicationID.MaterialPurchasing;
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
