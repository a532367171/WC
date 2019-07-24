﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_List.aspx.cs" Inherits="Manage_sys_User_List" %>

<%@ Register Src="~/Controls/Page.ascx" TagName="Page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>员工列表</title>
<link type="text/css" href="../../DK_Css/page_css.css" rel="stylesheet" />
<link type="text/css" href="../../manage/Style/InterFace.Css" rel="stylesheet" rev="stylesheet" media="all" />
<link type="text/css" href="../../manage/style.css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../manage/include/common.js"></script>  

<script type="text/javascript" src="../../js/popup/popup.js"></script>
<script type="text/javascript">
    function personView(ud) {
        var pop = new Popup({ contentType: 1, scrollType: 'yes', isReloadOnClose: false, width: 585, height: 465 });
        pop.setContent("contentUrl", 'User_View.aspx?type=1&uid=' + ud);
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
    <div class="interface_quick_left">您现在的操作 >> 系统管理 >> 用户管理</div>
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
<div id="PanelConfig">

<table class="table subsubmenu">
  <thead>
	<tr>
	  <td>
<a href="User_List.aspx" class="selected">用户列表</a>
	  </td>
	  <td style="text-align:right">
   <asp:Panel ID="panLogin" runat="server" DefaultButton="search_bt">
	  <input type="text" name="keyword"  maxlength=10  id="keyword" />
	  <asp:Button runat=server ID=search_bt CssClass="textbutton" OnClick=Search_Btn Text=搜索 /></asp:Panel>   
	  </td>
	</tr>
  </thead>
</table>
<br />           

<div id="PanelDefault">
	
<table class="table">
<thead>
	<tr>
		<th width="50">
		<asp:LinkButton ID="LinkButton1" runat=server  OnClientClick="javascript:return checkValues('您确定要批量删除数据吗？')" OnClick=Del_All>删除</asp:LinkButton>
		<input type="checkbox" name=ckb class="checkall">
		</th>
		<td width="70"><span style="margin-left:25px;">ID</span></td>
			<td width="100">用户名</td>
			<td width="100">真实姓名</td>
			<td width="138">职能部门</td>
			<td width="55">性别</td>
			<td width="130">生日</td>
			<td width="60">状态</td>
			<td width="165">管理</td>
	</tr>
</thead>
 
 <asp:Repeater runat=server ID=rpt><ItemTemplate>
	<tr>
		<th width="50"><input runat=server id=chk type="checkbox" value=<%#Eval("id") %> class="checkdelete"></th>
		<td><span style="margin-left:25px;"><%# Eval("id")%></span></td>
		<td>
			<%#Eval("UserName") %>
		</td>	
		<td style="font-weight:bold;">
			<%#Eval("RealName") %>
		</td>	
		<td>
			<%#Eval("DepName") %>
		</td>	
		<td>
			<%# Eval("Sex")+""=="0"?"男":"女" %>
		</td>	
		<td>
			<%#Eval("Birthday")%><%#GetAges(Eval("Birthday"))%>
		</td>	
		<td>
			<%# Eval("Status") + "" == "0" ? "<span style='color:#ff0000;'>在职</span>" : "<span style='color:Blue;'>离职</span>"%>
		</td>									
		<td class="manage">
		    <a href='#@' onclick='personView(<%#Eval("id")%>)' class="show">查看</a>
			<a href=User_Manage.aspx?uid=<%#Eval("id") %> class="show">编辑</a>
			<asp:LinkButton runat=server ID=lb_del OnClick=Del_Btn class="delete" title="你确定要删除这一项吗？">删除</asp:LinkButton>
		</td>
	</tr>
 </ItemTemplate></asp:Repeater>
 
</table>
<table class="table">
<tr>
	<td class="page">
	<span style="float:left;" id=num runat=server></span>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<uc1:Page ID="Page2" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;</td>
</tr>
</table>
<br />
 
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

