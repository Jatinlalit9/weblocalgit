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
using UAL.Gadgets;

namespace UAL.Web
{
    public partial class GadgetControl : System.Web.UI.UserControl
    {
        #region Privatevariable

        private string _remoteGadgetUrl;
        private string _editPreferenceURL;
        private string _GadgetHeaderName;
        private string _ImagesLocation;
        private int _gadgetID;
        private bool _gadgetPreference;
        private long _UserId;
        private int _irowSpan = 1;
        public string height;
        protected string strTableHeight = "230px";
        protected string strFrameHeight = "205px";

        #endregion

        #region Public Property

        public EventHandler Remove;
        public string RemoteGadgetUrl
        {
            get
            {
                return _remoteGadgetUrl;
            }
            set
            {
                _remoteGadgetUrl = value;
            }
        }
        public string EditPreferenceURL
        {
            get
            {
                return _editPreferenceURL;
            }
            set
            {
                _editPreferenceURL = value;
            }
        }
        public string GadgetHeaderName
        {
            get
            {
                return _GadgetHeaderName;
            }
            set
            {
                _GadgetHeaderName = value;
            }
        }

        public string ImagesLocation
        {
            get
            {
                return _ImagesLocation;
            }
            set
            {
                _ImagesLocation = value;
            }
        }
        
        public int GadgetID
        {
            get
            {
                return _gadgetID;
            }
            set
            {
                _gadgetID = value;
            }
        }

        public long UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }

        public bool GadgetPreference
        {
            set
            {
                _gadgetPreference = value;
            }
        }
        #endregion

        public int irowSpan
        {
            get
            {
                return _irowSpan;
            }
            set
            {
                _irowSpan = value;
            }
        }


        #region PageLoad
        private void Page_Load(object sender, System.EventArgs e)
        {        
            imgPrefernce.Src = this._ImagesLocation + "Common/Buttons/icon_preferences.gif";
            imgRemove.ImageUrl = this._ImagesLocation + "Common/Buttons/btn_cross.gif";
            imgRemove.Attributes.Add("onClick", "javascript: if(window.confirm('Are you sure want to delete this gadget')==1)return true; else return false;");
            strTableHeight = (230 * _irowSpan).ToString() + "px";
            strFrameHeight = (205 + (230 * (_irowSpan - 1))).ToString() + "px"; 
            this.DataBind();
        }
        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgRemove.Click += new System.Web.UI.ImageClickEventHandler(this.imgRemove_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region ImageButtonEvent
        private void imgRemove_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            GadgetsUser objGadgetUser = new GadgetsUser();
            objGadgetUser.UserID = (int)(UserId);
            objGadgetUser.GadgetIdx = _gadgetID;
            objGadgetUser.DeleteUserGadgets((int)(Constants.eModule.DashBoard));
            objGadgetUser = null;
            Context.Cache.Remove("CurrentPreferences_" + Session.SessionID + "_" + _gadgetID);
            Remove(this, e);
        }
        #endregion
    }
}