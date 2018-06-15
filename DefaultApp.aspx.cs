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
using UAL.ApplicationServices.Profile;
using UAL.ApplicationServices.Interfaces;

namespace UAL.Web
{
	/// <summary>
	/// Summary description for DefaultApp.
	/// </summary>
	public class DefaultApp : PageTemplate
	{
		protected System.Web.UI.WebControls.Label app;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
           // Response.Redirect(((UAL.Web.BasePage)Page).ApplicationBaseURL + "Dashboard.aspx");
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			PageName = "";
			PageTitle = "";
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

		protected override void Render(HtmlTextWriter writer)
		{
			if(!IsPostBack)
			{
				string[]  arrValues;
				string[]  arrKeyValue;
			
				LoggedUser oLoggedUser=(LoggedUser)Context.User;
				long UserID=oLoggedUser.Profile.UserID;
				Hashtable hstTempValues = new Hashtable();
				string strKey = "ApplicationMode_" + UserID + "_" + Session.SessionID ;
				string strValues = Cache[ strKey].ToString() ;
				if(strValues !="-1")
				{
					hstTempValues =new Hashtable();
					arrValues=strValues.Split(',');
					
					// loop through array of values obtained by splitting selected value in rootMenuItems
					for (int i=0;i<=arrValues.GetUpperBound(0);i++)
					{	
						arrKeyValue=arrValues[i].Split('=');
						hstTempValues.Add(arrKeyValue[0],arrKeyValue[1]);  
					}
			
					int m_parentId = System.Convert.ToInt32(hstTempValues["ID"]); 
					app.Text =" Please select any "+ UAL.Menu.Admin.MenuItem.GetApplicationName(m_parentId) +" Application from the menu.";
				}
			}
			base.Render (writer);
		}

		#endregion
	}
}
