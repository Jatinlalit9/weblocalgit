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
	/// Summary description for DefaultShipping.
	/// </summary>
	public class DefaultShipping : PageTemplate
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.PageName = "DefaultShipping";
			this.PageTitle = "SHIPPING";
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
            this.ApplicationID = Constants.eApplicationID.Shipping;
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
            this.Unload +=new EventHandler(Page_Unload);
		}

        void Page_Unload(object sender, EventArgs e)
        {
            this.ApplicationID = Constants.eApplicationID.Shipping;
        }

        
		#endregion
	}
}
