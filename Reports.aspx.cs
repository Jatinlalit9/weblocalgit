using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UAL.Web
{
    public partial class Reports : PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strFolderPath = "UAL_BusinessReports";
                if (Request.QueryString["ReportName"] != "WipLogReport")
                {
                    strFolderPath = "UALReports";
                }
                MyReportViewer.ProcessingMode = ProcessingMode.Remote;
                MyReportViewer.ServerReport.ReportServerUrl = new Uri(GetMessageString("REPORT_SERVER_URL"));
                MyReportViewer.ServerReport.ReportPath = @"/" + strFolderPath + "/" + Request.QueryString["ReportName"];
                MyReportViewer.ServerReport.ReportServerCredentials = new ReportServerCredentials("Administrator", "ggN@12345", "122.160.229.6");
                MyReportViewer.ServerReport.Refresh();
            }
        }
    }

    /// <summary>
    /// Local implementation of IReportServerCredentials
    /// </summary>
    [Serializable]
    public class ReportServerCredentials : IReportServerCredentials
    {
        private string _userName;
        private string _password;
        private string _domain;

        public ReportServerCredentials(string userName, string password, string domain)
        {
            _userName = userName;
            _password = password;
            _domain = domain;
        }

        public WindowsIdentity ImpersonationUser
        {
            get
            {
                // Use default identity.
                return null;
            }
        }

        public ICredentials NetworkCredentials
        {
            get
            {
                // Use default identity.
                return new NetworkCredential(_userName, _password, _domain);
            }
        }

        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {
            // Do not use forms credentials to authenticate.
            authCookie = null;
            user = password = authority = null;
            return false;
        }
    }
}