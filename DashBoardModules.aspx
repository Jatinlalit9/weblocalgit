<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoardModules.aspx.cs" Inherits="UAL.Web.DashBoardModules" EnableEventValidation="false"%>
<%@ Register TagPrefix="uc1" TagName="DualList" Src="CommonControls/DualList.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="Framework.Controls" Assembly="Framework.Controls" %>
<form runat="server" id="frmDashboardModule">
    <table align="center" class="UAL-background-semidark" cellspacing="1" cellpadding="1"
        width="98%" border="0" height="95%">
        <tr class="UAL-background-content">
            <td valign=top width="15%" height="22" id="tdLeftPannel">
                <table align="center" class="UAL-background-content" cellspacing="1" cellpadding="1"
                    width="100%" border="0" height="76%">
                    <tr class="UAL-background-content">
                        <strong class="UAL-channel-table-row-even"><a href="DashBoardModules.aspx">Edit</a></strong>
                    </tr>
                </table>
            </td>
            <td width="82%" class=UAL-background-content valign="top">
                <table cellSpacing="1" width="100%" align="center" height="95%">
                    <tr>
                      <td>&nbsp;</td>
                    </tr>
                    <tr>
                      <td>
                        <table width="87%" border=0 align="center" cellPadding=2 cellSpacing=2 id=DualListProductionMethods_tblOuter class=UAL-background-semidark>					            
			                <tr class="UAL-background-dark">
				                <td align=right valign="top">&nbsp;</td>
			                </tr>					            
			                <tr class="UAL-background-content">
				                <td align=middle valign="top">
					                <table width="100%" align="center" bgColor="#ffffff" BORDER="0" height="100%">
						                <tr class="UAL-background-content">
							                <td align="center" class="UAL-channel-table-row-even" height="20" width="33%"><strong>Available Modules</strong></td>
							                <td height="20" width="10%">&nbsp;</td>
							                <td align="center" class="UAL-channel-table-row-even" height="20" width="33%"><strong>Selected Modules</strong></td>
						                </tr>
						                <tr>
							                <td colspan="3" align="center" width="100%"><uc1:DualList DualListWidth="100%" id="dashboardDualList" runat="server"></uc1:DualList></td>
						                </tr>
						                <tr>
						                    <td>&nbsp;</td>
							                <td>&nbsp;</td>
							                <td align="right"><cc1:RollOverButton id="rollBtnSave" tabIndex="1" runat="server" ToolTip="Save" OnClick="rollBtnSave_Click"></cc1:RollOverButton>&nbsp;&nbsp;&nbsp;<cc1:RollOverButton id="rollBtnCancel" tabIndex="2" runat="server" ToolTip="Cancel" CausesValidation="False" OnClick="rollBtnCancel_Click"></cc1:RollOverButton></td>
						                </tr>
					                </table>
				                 </td>
			                 </tr>
		                 </table>
                     </td>
                   </tr>
                 </table>
              </td>
          </tr>                       
          <input type="hidden" id="hidListBoxCollection" runat="server" />
          <input type="hidden" id="hidIsPanelVisible" runat="server" />
    </table>
</form>
<script language="javascript">
// get data tru XML Http
var oServerXMLHTTP=null;
var Url;
var ser;
var isPostBack = 0;

if(document.getElementById('hidIsPanelVisible').value=="1")
{
    document.getElementById('hidIsPanelVisible').value="0";
    document.getElementById('tdLeftPannel').style.display = "";
    document.getElementById('hrefShowHidePannel').innerHTML = "<strong>Hide Panel</strong>";
    
}
else
{
    document.getElementById('hidIsPanelVisible').value="1";
    document.getElementById('tdLeftPannel').style.display = "none";
    document.getElementById('hrefShowHidePannel').innerHTML = "<strong>Show Panel</strong>";
}

function ShowHidePannel()
{    
    isPostBack = 1;
    if(document.getElementById('hidIsPanelVisible').value == "0")
    {
        document.getElementById('hidIsPanelVisible').value="1";
        Url = 'DashBoardShowHide.aspx?ShowPanel=0';
        document.getElementById('tdLeftPannel').style.display = "none";
        document.getElementById('hrefShowHidePannel').innerHTML = "<strong>Show Panel</strong>";
    }
    else
    {
        document.getElementById('hidIsPanelVisible').value="0";
        Url = 'DashBoardShowHide.aspx?ShowPanel=1';
        document.getElementById('tdLeftPannel').style.display = "";
        document.getElementById('hrefShowHidePannel').innerHTML = "<strong>Hide Panel</strong>";
    }
    
    oServerXMLHTTP = new ActiveXObject("Microsoft.XMLHTTP");
	oServerXMLHTTP.open("GET", Url, true);
	oServerXMLHTTP.send(null)	
   
}
//function ShowHidePannel()
//{
//    if(document.getElementById('tdLeftPannel').style.display == "")
//    {
//        document.getElementById('tdLeftPannel').style.display = "none";
//        document.getElementById('hrefShowHidePannel').innerHTML = "<strong>Show Panel</strong>";
//    }
//    else
//    {
//        document.getElementById('tdLeftPannel').style.display = "";
//        document.getElementById('hrefShowHidePannel').innerHTML = "<strong>Hide Panel</strong>";
//    }
//}
function OnCancel_Click()
{
     if(vIsChanged == '1')
        {
            if(confirm("All the changes will be lost. Are you sure you want to continue?"))
            {
                 return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
}
function OnSave_Click()
{
    var strDualListRightValues = '';
    if(document.frmDashboardModule.dashboardDualList_lstRightListBox != null)
    {
        for(iCount = 0;iCount < document.frmDashboardModule.dashboardDualList_lstRightListBox.length ;iCount ++)
        {
            if(strDualListRightValues == '')
            {
                strDualListRightValues = document.frmDashboardModule.dashboardDualList_lstRightListBox.options[iCount].value ;
            }
            else
            {
                strDualListRightValues = strDualListRightValues + ',' + document.frmDashboardModule.dashboardDualList_lstRightListBox.options[iCount].value ;
           }
        } 
    }
    document.getElementById('hidListBoxCollection').value = strDualListRightValues;
    return true;
}

</script>
