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
using System.Web.Caching;

namespace UAL.Web
{
    public partial class IntermediateMenuBar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.Now);
            if (Request.QueryString["Key"] != null && Request.QueryString["Value"] != null)
            {
                string key = Convert.ToString(Request.QueryString["Key"]);
                string Value = Convert.ToString(Request.QueryString["Value"]);
                AddToCache(key, Value);
                Response.Clear();
                Response.Write("1");
                Response.End();
            }
            else
            {
                Response.Clear();
                Response.Write("0");
                Response.End();
            }
        }

        /// Adds an item to cache with default setting(expiration time etc.) for this system
        private void AddToCache(string key, object objectToStore)
        {
            //add to cache with sliding expiration set to time equal to Session timeout
            Session[key] = objectToStore;
            Cache[key] = objectToStore;
        }
    }
}
