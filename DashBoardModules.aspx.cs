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
    /// <summary>
    /// Summary description for DashBoardModules.
    /// </summary>
    public partial class DashBoardModules : PageTemplate
    {
        #region Private Variables
        private long iUserID = -1;
        private bool blnShowPanel;
        #endregion
        #region Page Load
        private void Page_Load(object sender, System.EventArgs e)
        {
            LoggedUser oLoggedUser = (LoggedUser)HttpContext.Current.User;
            iUserID = oLoggedUser.Profile.UserID;
            if (!IsPostBack)
            {
                this.PageName = "UADashboardModules";
                this.PageTitle = "UA Dashboard Modules";
                
                rollBtnSave.ImageUrl = this.ImagesLocation + "Common/Buttons/save.gif";
                rollBtnSave.RollOverImageUrl = this.ImagesLocation + "Common/Buttons/save_over.gif";
                rollBtnSave.Attributes.Add("OnClick", "return OnSave_Click();");

                rollBtnCancel.ImageUrl = this.ImagesLocation + "Common/Buttons/cancel.gif";
                rollBtnCancel.RollOverImageUrl = this.ImagesLocation + "Common/Buttons/cancel_over.gif";
                rollBtnCancel.Attributes.Add("OnClick", "return OnCancel_Click();");
                SetDualListProperties();
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

        }
        #endregion

        #region Private Methods
        /// <summary>
       /// Function SetDualListProperties sets all properties of Dualist
       /// </summary>
        private void SetDualListProperties()
        {
            dashboardDualList.RightBtnImagePath = this.ImagesLocation + "Common/Buttons/btn_add_long.gif";
            dashboardDualList.LeftBtnImagePath = this.ImagesLocation + "Common/Buttons/btn_remove_long.gif";

            dashboardDualList.ShowMoveUpButton = true;
            dashboardDualList.ShowMoveDownButton = true;

            dashboardDualList.MoveDownBtnImagePath = this.ImagesLocation + "Common/Buttons/btn_move_down.gif";
            dashboardDualList.MoveUpBtnImagePath = this.ImagesLocation + "Common/Buttons/btn_move_up.gif";

            dashboardDualList.ListBoxHeight = Unit.Pixel(340);
            FillListBox();
        }

        /// <summary>
        /// Function FillListBox binds data in duallist
        /// </summary>
        private void FillListBox()
        {
            Gadgets.Gadgets oGadgets = new UAL.Gadgets.Gadgets();

            DataTable dtLeftGadgets = oGadgets.GetAllGadgets(iUserID,0);
            DataTable dtRightGadgets = oGadgets.GetAllGadgets(iUserID,1);

            dashboardDualList.lstLeftListBox.Items.Clear();
            dashboardDualList.lstRightListBox.Items.Clear();

            dashboardDualList.LeftBoxDataSource = dtLeftGadgets;
            dashboardDualList.LeftBoxDataTextField = "Gadget_Name";
            dashboardDualList.LeftBoxDataValueField = "Gadget_Idx";
            dashboardDualList.LeftBoxDataBind();

            dashboardDualList.RightBoxDataSource = dtRightGadgets;
            dashboardDualList.RightBoxDataTextField = "Gadget_Name";
            dashboardDualList.RightBoxDataValueField = "Gadget_Idx";
            dashboardDualList.RightBoxDataBind();
            oGadgets = null;
        }
        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>)
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
            this.rollBtnSave.Click += new EventHandler(rollBtnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

        #region Protected Methods
        protected void rollBtnSave_Click(object sender, EventArgs e)
        {
            GadgetsUser objGadgetsUser = new GadgetsUser();
            objGadgetsUser.UserID = (int)(iUserID);
            objGadgetsUser.InsertUpdateUserGadgets(hidListBoxCollection.Value);
            objGadgetsUser = null;
            dashboardDualList.RestoreDualList();
            Response.Redirect(ApplicationBaseURL + "Dashboard.aspx");
            
        #region Old Code
        /*clsDashBoardModule objDashBoardModule = new clsDashBoardModule();
        objDashBoardModule.UserId = iUserID;
        objDashBoardModule.SelectedColumns = hidListBoxCollection.Value;
        if (objDashBoardModule.SelectedColumns == null)
            objDashBoardModule.SelectedColumns = "";
        objDashBoardModule.SetPreferenceData(objDashBoardModule);*/
        #endregion Old Code
        }
        
        protected void rollBtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(ApplicationBaseURL + "Dashboard.aspx");
        }
         
        #endregion

        #region User Defined Functions

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
