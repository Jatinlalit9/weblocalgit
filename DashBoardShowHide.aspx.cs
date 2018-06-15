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
using UAL.ApplicationServices.Security;
using UAL.ApplicationServices;
using UAL.ApplicationServices.Profile;
using UAL.Preferences;
using UAL.Gadgets;

namespace UAL.Web
{
    public partial class DashBoardShowHide : PageTemplate
    {
        private long iUserID = 0;
        private int iShowPanel;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.Now);

            if (Request["ShowPanel"] != null)
            {
                iShowPanel = Convert.ToInt32(Request["ShowPanel"]);


                LoggedUser oLoggedUser = (LoggedUser)HttpContext.Current.User;
                iUserID = oLoggedUser.Profile.UserID;
                clsGadgetPreferences objGadgetPreferences = new clsGadgetPreferences();

                objGadgetPreferences.UserId = iUserID;
                objGadgetPreferences.EntityId = -1;
                if (iShowPanel == 1)
                {
                    objGadgetPreferences.ShowPanel = true;
                }
                else
                {
                    objGadgetPreferences.ShowPanel = false;
                }

                bool bSave = objGadgetPreferences.SetPreferenceData(objGadgetPreferences);

                if (bSave)
                {
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
            else
            {
                Response.Clear();
                Response.Write("0");
                Response.End();
            }          
            
        }      
    }
}
