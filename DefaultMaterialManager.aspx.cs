using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using UAL.Constants;

namespace UAL.Web
{
    public partial class DefaultMaterialManager : PageTemplate
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            this.PageName = "DefaultMaterialManager";
            this.PageTitle = "MATERIAL MANAGER";
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            this.ApplicationID = eApplicationID.MaterialManager;
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