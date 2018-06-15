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

namespace UAL.Web
{
    public partial class DefaultRejectShipment : PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageName = "DefaultRejectShipment";
            this.PageTitle = "REJECT SHIPMENT";
        }
    }
}
