using Framework.DBServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using UAL.ApplicationServices;
using UAL.ApplicationServices.Interfaces;
using UAL.ApplicationServices.Preferences;
using UAL.ApplicationServices.Profile;

namespace UAL.Web 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

        private void updateLAT(long UserID, string SessionID)
        {
            Parameters oParameters = new Parameters();
            oParameters.Add("UserID", System.Data.DbType.Int32, UserID);
            oParameters.Add("SessionID", System.Data.DbType.String, SessionID);
            oParameters.Add("LATTime", System.Data.DbType.DateTime, System.DateTime.Now);
            FwkApplication.GetInstance().DBService.ExecSPReturnInteger("Security_UpdateLAT", oParameters);

        }

		protected void Application_Error(Object sender, EventArgs e)
		{
            Exception objErr = Server.GetLastError();
            //Done by Vineet Gaur for handling unhandled Deadlock and Timeout Exception
            if(objErr.InnerException != null)
            {
                if (objErr.InnerException.Message.ToUpper().Contains("DEADLOCK"))
                {
                    Response.Write("<script language='JavaScript'>if(window.confirm('Deadlock error occurred while performing the transaction. Do you want to retry?')) {window.location.reload();} else {window.close();}</script>");
                    Server.ClearError();                
                }
                else if (objErr.InnerException.Message.ToUpper().Contains("OUTOFMEMORYEXCEPTION"))
                {
                    Response.Write("<script language='JavaScript'>if(window.confirm('Out of Memory error occurred while performing the transaction. Do you want to retry?')) {window.location.reload();} else {window.close();}</script>");
                    Server.ClearError();   
                }
                else if (objErr.InnerException.Message.ToUpper().Contains("TIMEOUT"))
                {
                    Response.Write("<script language='JavaScript'>if(window.confirm('TimeOut error occurred while performing the transaction. Do you want to retry?')) {window.location.reload();} else {window.close();}</script>");
                    Server.ClearError();   
                }
            }
		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

