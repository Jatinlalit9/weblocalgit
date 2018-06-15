<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Dashboard.aspx.cs" Inherits="UAL.Web.Dashboard"  EnableEventValidation="false"%>

<head>
    <meta id="MetaTag" runat="server" http-equiv="refresh"/>
</head>

<form runat="server" id="frmDashboard">
    <table align="center" class="UAL-background-semidark" cellspacing="1" cellpadding="1"
        width="98%" border="0" height="95%">
        <tr class="UAL-background-content">
            <td valign="top" width="15%" height="22" id="tdLeftPannel">
                <table align="center" class="UAL-background-content" cellspacing="1" cellpadding="1"
                    width="100%" border="0" height="76%">
                    <tr class="UAL-background-content">
                        <strong class="UAL-channel-table-row-even"><a href="DashBoardModules.aspx">Edit</a></strong>
                    </tr>
                </table>
            </td>
            <td>
                <table id="tblGadgets" align="center" class="UAL-background-content" cellspacing="1"
                    cellpadding="1" width="100%" border="1" height="100%" runat="server">
                </table>
                <table align="center" id="tblNoGadgets" runat="server" cellspacing="1" cellpadding="1"
                    width="100%" border="0" height="76%">
                    <tr>
                        <td align="center" valign="top">
                            <font class="UAL-text-small-blue">
                                <br>
                                <br>
                                <br>
                                For accessing any application, please select the application segment from the dropdown.</font></td>
                    </tr>
                    <tr>
                        <td align="center" valign="bottom">
                            <a href="TermsAndConditions.aspx" class="UAL-navigation-channel"><u>Terms And Conditions</u></a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <input type="hidden" id="hidIsPanelVisible" runat="server" />
    <input type="hidden" id='btnRefreshDashboard' onclick="javascript:RefreshDashboard()"
														NAME="btnRefreshDashboard"> 
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
    window.location.href = window.location.href;
}

function DisplayPanel()
{
    if(document.getElementById('hidIsPanelVisible').value == "1")
    {
        document.getElementById('tdLeftPannel').style.display = "";
        document.getElementById('hrefShowHidePannel').innerHTML = "<strong>Hide Panel</strong>";
    }
    else
    {
        document.getElementById('tdLeftPannel').style.display = "none";
        document.getElementById('hrefShowHidePannel').innerHTML = "<strong>Show Panel</strong>";
    }
}


function NewWindow(mypage,myname,w,h)
 {    
    h = 200, w = 500;
	LeftPosition = (screen.width) ? (screen.width-600)/2 : 0;
	TopPosition = (screen.height) ? (screen.height-500)/2 : 0;
	settings ='height=' + h + ',width=' + w + ',top='+TopPosition+',left='+LeftPosition+',resizable=0'
	win = window.open(mypage,myname,settings);
	win.focus();	
}

function RefreshDashboard()
{
     document.frmDashboard.action = "Dashboard.aspx";
     document.frmDashboard.submit();
}


</script>

