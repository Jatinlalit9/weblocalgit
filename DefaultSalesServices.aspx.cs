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
using UAL.ApplicationServices; 
using UAL.Constants;
using UAL.UserManagement;
using UAL.ApplicationServices.Security;

namespace UAL.Web
{
	/// <summary>
	/// Summary description for DefaultSalesServices.
	/// </summary>
	public class DefaultSalesServices : PageTemplate
	{
        private void Page_Load(object sender, System.EventArgs e)
        {
            //this.PageName = "DefaultSalesServices";
            this.PageTitle = "SALES";
            // Put user code to initialize the page here
        }

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			this.ApplicationID = eApplicationID.Sales  ;
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

		#region private helper function
		/// <summary>
		/// Function to check Access on module
		/// </summary>
		/// <param name="moduleId">Id of the Module</param></param>
	
		public bool CheckModuleAccessOverLoad(eModule moduleId)
		{
			//GlobalConstants.cAccessPermissionKey is the access permission key for all the modules
			//PermissionEntity oPermissionEntity=new PermissionEntity((long)moduleId,-1,-1,-1);
			PermissionEntity oPermissionEntity=new PermissionEntity();
			oPermissionEntity.Module=(long)moduleId;
			oPermissionEntity.Instance=-1;
			oPermissionEntity.Entity=-1;
			oPermissionEntity.SubEntity=-1;
			
			//IdentityGroup oIdentityGroup=new IdentityGroup(User.Profile.UserID,-1,IdentityType.User);
			IdentityGroup oIdentityGroup=new IdentityGroup();
			oIdentityGroup.User = User.Profile.UserID;
			oIdentityGroup.Group=-1;
			oIdentityGroup.Type=IdentityType.User;
			
			return FwkApplication.GetInstance().AuthorizationManager.CheckPermissionDetails(oPermissionEntity,oIdentityGroup,GlobalConstants.cAccessPermissionKey);
		
		}
		#endregion
	}
}
