using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Caching;
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
    public partial class Dashboard : PageTemplate
    {
        #region Private Variables

        private long iUserID = 0;
        private bool blnShowPanel;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedUser oLoggedUser = (LoggedUser)HttpContext.Current.User;
            iUserID = oLoggedUser.Profile.UserID;
            
            if (!IsPostBack)
            { 
                this.PageName = "UADashboard";
                this.PageTitle = "UA Dashboard";
                MetaTag.Attributes.Add("Content", ((UAL.Web.BasePage)Page).getAppSettings("REFRESH_TIME"));
                              
            }

            bool bIsPanelDisplay = GetShowHidePreferences();

            if (bIsPanelDisplay)
            {
                hidIsPanelVisible.Value = "1"; 
            }
            else
            {
                hidIsPanelVisible.Value = "0"; 
            }


            ShowGadgets();
        }
                
        #endregion

        #region User Defined Functions

        private void ShowGadgets()
		{
            tblGadgets.Rows.Clear();
            HtmlTableCell objTableCell;
            HtmlTableRow objTableRow = new HtmlTableRow();
           
            Gadgets.Gadgets oGadgets = new Gadgets.Gadgets();
            DataTable dtGadgets = oGadgets.GetAllGadgets(iUserID,1);
                   
            int iNoOfColums = 2, iNoOfRows = 1,  iGadgetID, iPrevNoOfColums = -1, iPrevNoOfRows = -1, icolspan = 0;

            for (int iRowCount = 0; iRowCount < dtGadgets.Rows.Count; iRowCount++)
            {
                iGadgetID = Convert.ToInt32(dtGadgets.Rows[iRowCount]["Gadget_Idx"]);
                GetGadgetPreferences(ref iNoOfColums,ref iNoOfRows,  iGadgetID);
                
                GadgetControl objGadgetControl = (GadgetControl)Page.LoadControl("GadgetControl.ascx");
                switch (iGadgetID)
                {
                    case 1: objGadgetControl.RemoteGadgetUrl = ApplicationBaseURL + "Gadgets/MyToDo.aspx?GadgetID=" + iGadgetID;
                        break;
                    case 2: objGadgetControl.RemoteGadgetUrl = ApplicationBaseURL + "Gadgets/StatusOfMyRequests.aspx?GadgetID=" + iGadgetID;
                        break;
                    case 3: objGadgetControl.RemoteGadgetUrl = ApplicationBaseURL + "Gadgets/MyAlerts.aspx?GadgetID=" + iGadgetID;
                        break;
                }
                objGadgetControl.EditPreferenceURL = ApplicationBaseURL + "Gadgets/GadgetPreferences.aspx?GadgetID=" + iGadgetID;
                objGadgetControl.GadgetHeaderName = dtGadgets.Rows[iRowCount]["Gadget_Name"].ToString();
                objGadgetControl.UserId = (int)(iUserID);
                objGadgetControl.GadgetID = iGadgetID;
                objGadgetControl.ImagesLocation = ImagesLocation;
                objGadgetControl.Attributes.Remove("CommandName");
                objGadgetControl.Attributes.Add("CommandName", "Remove");
                objGadgetControl.Remove += new System.EventHandler(this.removegadget);
                objGadgetControl.irowSpan = iNoOfRows;
                
                if (iNoOfColums == 1 && iPrevNoOfColums == 1 && iNoOfColums == iPrevNoOfColums && icolspan != 2)
                {
                    icolspan++;
                }
                else
                {
                    objTableRow = new HtmlTableRow();
                    icolspan = 1;
                }

                objTableCell = new HtmlTableCell();
                objTableCell.ID = "GadgetHolder" + iRowCount;
                objTableCell.Controls.Add(objGadgetControl);
                objTableCell.ColSpan = iNoOfColums;
                objTableCell.RowSpan = 1;// iNoOfRows;
                objTableCell.VAlign = "Top";
                objTableCell.Align = "Center";

                objTableRow.Cells.Add(objTableCell);
                if (iRowCount < dtGadgets.Rows.Count - 1 && icolspan == 1 && iNoOfColums == 1)
                {
                   int iNewGadgetID = Convert.ToInt32(dtGadgets.Rows[iRowCount + 1]["Gadget_Idx"]);
                   int iNewNoOfRows = 1, iNewNoOfColums = 1;
                   GetGadgetPreferences(ref iNewNoOfColums, ref iNewNoOfRows, iNewGadgetID);
                   if (iNewNoOfColums == 2)
                   {
                       objTableCell = new HtmlTableCell();
                       objTableCell.Width = "50%";
                       objTableRow.Cells.Add(objTableCell);
                   }
                }
                else if (iRowCount == dtGadgets.Rows.Count - 1 && icolspan == 1 && iNoOfColums == 1)
                {
                    if (dtGadgets.Rows.Count > 1)
                    {
                        int iNewGadgetID = Convert.ToInt32(dtGadgets.Rows[iRowCount - 1]["Gadget_Idx"]);
                        int iNewNoOfRows = 1, iNewNoOfColums = 1;
                        GetGadgetPreferences(ref iNewNoOfColums, ref iNewNoOfRows, iNewGadgetID);
                        if (iNewNoOfColums == 2)
                        {
                            objTableCell = new HtmlTableCell();
                            objTableCell.Width = "50%";
                            objTableRow.Cells.Add(objTableCell);
                        }
                    }
                    else if (dtGadgets.Rows.Count == 1)
                    {
                        objTableCell = new HtmlTableCell();
                        objTableCell.Width = "50%";
                        objTableRow.Cells.Add(objTableCell);
                    }
                }
                tblGadgets.Rows.Add(objTableRow);
                iPrevNoOfColums = iNoOfColums;
                iPrevNoOfRows = iNoOfRows;
            }

            if (dtGadgets.Rows.Count == 0)
            {
                tblNoGadgets.Visible = true;
                tblGadgets.Visible = false;
            }
            else
            {
                tblNoGadgets.Visible = false;
                tblGadgets.Visible = true;
            }
            DataBind();
        }

        private void removegadget(object sender, EventArgs e)
        {
            //tblGadgets.Controls.Clear();
            //ShowGadgets();
            Response.Redirect(ApplicationBaseURL + "Dashboard.aspx");
        }

        private void GetGadgetPreferences(ref int iNoOfColums, ref int iNoOfRows,  int iGadgetID)
        {
            clsGadgetPreferences objGadgetPreferences = new clsGadgetPreferences();
            if (Context.Cache.Get("CurrentPreferences_" + Session.SessionID + "_" + iGadgetID + "_" + iUserID) != null)
            {
                objGadgetPreferences = (clsGadgetPreferences)(Context.Cache.Get("CurrentPreferences_" + Session.SessionID + "_" + iGadgetID + "_" + iUserID));
            }
            else
            {
                objGadgetPreferences.UserId = iUserID;
                objGadgetPreferences.EntityId = iGadgetID;
                objGadgetPreferences.GetPreferenceData(objGadgetPreferences);
                Context.Cache.Insert("CurrentPreferences_" + Session.SessionID + "_" + iGadgetID + "_" + iUserID, objGadgetPreferences, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }

            iNoOfColums = objGadgetPreferences.No_Of_Cols;
            iNoOfRows = objGadgetPreferences.No_Of_Rows;
        }
        
        private bool GetShowHidePreferences()
        {
            clsGadgetPreferences objGadgetPreferences = new clsGadgetPreferences();
            
            objGadgetPreferences.UserId = iUserID;
            objGadgetPreferences.EntityId = -1;
            objGadgetPreferences.GetPreferenceData(objGadgetPreferences);

            blnShowPanel = objGadgetPreferences.ShowPanel;
            return blnShowPanel;
                
        }        

        #endregion
    }
}
