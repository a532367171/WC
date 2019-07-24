﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_OnLine.aspx.cs" Inherits="Manage_Common_User_OnLine" %>


<%@ Register Src="~/Controls/Page.ascx" TagName="Page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>在线用户列表</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link type="text/css" href="../../Manage/Style/InterFace.Css" rel="stylesheet" rev="stylesheet" media="all" />
<link type="text/css" href="../../Manage/style.css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../Manage/include/common.js"></script>
<script type="text/javascript" src="../../js/validator.js"></script>

<script type="text/javascript" src="../../js/popup/popup.js"></script>
<script type="text/javascript">
    function personView(ud) {
        var pop = new Popup({ contentType: 1, scrollType: 'yes', isReloadOnClose: false, width: 585, height: 465 });
        pop.setContent("contentUrl", '../../Manage/Sys/User_View.aspx?uid=' + ud);
        pop.setContent("title", "个人资料预览");
        pop.build();
        pop.show();
    }
</script> 
</head>
<body >
    <form id="form1" runat="server">
<div id="interface_inside">
  <div id="interface_quick">
    <div class="interface_quick_left">您现在的操作 >> 在线用户列表</div>
    <div class="interface_quick_right">
    <a href="javascript:void(0)" onclick="javascript:window.location.replace(window.location.href);"><img style="vertical-align:middle;" src="../../Manage/images/reload.png" /><strong>刷新</strong></a>
    &nbsp; &nbsp;
    <a href="javascript:history.back();"><img style="vertical-align:middle;" src="../../Manage/images/ico_up1.gif" /><strong>后退</strong></a>  
    </div>
    <div class="clearboth"></div>
  </div>
  <div id="interface_main">
    <div id="tabs_config" class="tabsbox">
      

      <div class="clearboth"></div>
      
      
      <!-- 模块 -->

        <table width="100%" border="0" cellspacing="0" cellpadding="0" >
          <tr>
            <td>
  <div id="config_basic1" class="tabs_wrapper">
<div class="tabs_main" align="left">  
<div id="Div1">
    
<div id="PanelConfig">
<table class="table">
<thead>
	<tr>
		<th width="1">
		</th>
		<td width="50"><span style="margin-left:15px;">序</span></td>
			<td style="width:18%">姓名</td>
			<td style="width:19%">组织机构</td>
			<td style="width:30%">最近活动时间</td>
			<td style="width:17%">操作</td>			
			<td width="20"></td>
	</tr>
</thead>
 
 <asp:Repeater runat=server ID=rpt_person EnableViewState=false><ItemTemplate>
	<tr>
		<th></th>
		<td><span style="margin-left:10px;"><%# Container.ItemIndex+1 %></span></td>
		<td>
			<%# Convert.ToBoolean(Eval("IsOnline")) ? "<span style='color:#006600; font-weight:bold;'>" + Eval("RealName") + "</span>" : "<span style='color:#999999; font-weight:bold;'>" + Eval("RealName") + "</span>"%>
		</td>	
		<td>
		<%#Eval("DepName")%>
		</td>
		<td>
		<%# Convert.ToBoolean(Eval("IsOnline")) ? "<span style='color:#ff3300; font-weight:bold;'>" + WC.Tool.Utils.ConvertDate3(Eval("LastLoginTime")) + "</span>" : "<span style='color:#999999;'>" + WC.Tool.Utils.ConvertDate3(Eval("LastLoginTime")) + "</span>"%>
		</td>
		<td class="manage">
		<a href='#@' onclick='personView(<%#Eval("id")%>)'>查看资料</a>
		<a href='Mail_Manage.aspx?userlist=<%#Eval("id") %>' class="show">发送邮件</a>
		</td>		
        <td>      
        </td>
	</tr>
 </ItemTemplate></asp:Repeater>
 <tr>
	<td class="page" colspan=7>
	<span style="float:left;" id=num runat=server></span>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<uc1:Page ID="Page2" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;</td>
</tr>
</table>
   
</div>

              </div></div>
            </div></td>
          </tr>
        </table>

      <!-- 模块 -->

    </div>
  </div>
</div>
    </form>
</body>
</html>
