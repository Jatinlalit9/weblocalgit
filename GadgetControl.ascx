<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GadgetControl.ascx.cs" Inherits="UAL.Web.GadgetControl" %>
<table border="0" cellpadding="0" cellspacing="1" width="100%" class="UAL-background-content" height="<%# strTableHeight %>">
	<tr class="UAL-background-semidark">
		<td style="HEIGHT:10px">
			<table style="WIDTH:100%" align="center" cellpadding="1" cellspacing="0" border="0">
				<tr style="HEIGHT:10px" class="UAL-channel-title">
					<td id='TdGadgetHeader_<%# GadgetID %>'  class="headingfontsmall" style="PADDING-LEFT:5px"><b><%# GadgetHeaderName %></b></td>
					<td align="right">
						<table cellpadding="0" cellspacing="0" border="0">
							<tr>
								<td align="right" valign="middle"><A href="javascript:NewWindow('<%#EditPreferenceURL%>',600,500);"><Img border="0" id="imgPrefernce" runat="server" title="Prefernces" style="CURSOR: pointer" ></A></td>
								<td width="1"></td>
								<td align="right" valign="middle"><asp:ImageButton id="imgRemove" runat="server" AlternateText="Close"></asp:ImageButton></td>
								<td width="2"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	
	<tr class="UAL-background-content" >
		<td>
			<table width="100%" align="center" cellpadding="0" cellspacing="1" border="0"  Class="UAL-background-content">
				<tr  Class="UAL-background-content">
					<td align="right">
						<table width="100%" Class="UAL-background-content" border="0" cellpadding="1" cellspacing="1">
							<tr style="HEIGHT:190px" >
								<td Class="UAL-background-content"><iframe id='Gadget_<%# GadgetID %>'  name='Gadget_<%# GadgetID %>' src="<%# RemoteGadgetUrl %>" style="BORDER-RIGHT:0px;BORDER-TOP:0px;OVERFLOW-Y:visible;OVERFLOW-X:visible;BORDER-LEFT:0px;WIDTH:100%;BORDER-BOTTOM:0px;HEIGHT:<%# strFrameHeight %>"></iframe>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>

