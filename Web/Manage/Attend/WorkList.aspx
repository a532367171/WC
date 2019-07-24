﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkList.aspx.cs" Inherits="Manage_Attend_WorkList" %>
<%@ Register Src="~/Controls/Page.ascx" TagName="Page" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Page.ascx" TagName="Page" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Page.ascx" TagName="Page" TagPrefix="uc3" %>
<%@ Register Src="~/Controls/Page.ascx" TagName="Page" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>考勤数据管理</title>
<link type="text/css" href="../../Manage/Style/InterFace.Css" rel="stylesheet" rev="stylesheet" media="all" />
<link type="text/css" href="../../Manage/style.css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../Manage/include/common.js"></script>
<link type="text/css" href="../../DK_Css/page_css.css" rel="stylesheet" />

<script type="text/javascript" src="../../js/formV/datepicker/WdatePicker.js"></script>
<script type="text/javascript" src="../../js/validator.js"></script> 
<script type="text/javascript" src="../../js/popup/popup.js"></script>
<script type="text/javascript">
    function depView(id) {
        var pop = new Popup({ contentType: 1, scrollType: 'yes', isReloadOnClose: false, width: 460, height: 300 });
        pop.setContent("contentUrl", '/manage/Attend/WorkAttendView.aspx?wid=' + id);
        pop.setContent("title", "查看考勤信息");
        pop.build();
        pop.show();
    }
</script> 
</head>
<body>
    <form id="form1" runat="server" onsubmit="return Validator.Validate(this.form,1);">
<div id="interface_inside">
  <div id="interface_quick">
    <div class="interface_quick_left">您现在的操作 >> 系统管理 >> 考勤统计<%=TypeStr() %></div>
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

        <table width="98%" border="0" cellspacing="0" cellpadding="0" >
          <tr>
            <td>
            
  <div id="config_basic1" class="tabs_wrapper">
<div class="tabs_main" align="left">  
<div id="PanelConfig">

<table class="table subsubmenu">
  <thead>
	<tr>
	  <td>
<a href='WorkList.aspx?type=1'>上下班统计</a>
<a href='WorkList.aspx?type=2'>外出统计</a>
<a href='WorkList.aspx?type=3'>请假统计</a>
<a href='WorkList.aspx?type=4'>出差统计</a>
<a href='WorkList.aspx?del=true'>批量删除</a>
	  </td>
	  <td style="text-align:right;">
<asp:Panel runat=server ID=search1 Visible=true>      
<input type=button name="s_bt" value="搜索/导出" id="s_bt" onclick="javascript: $('#s_div').slideToggle('fast');" class="textbutton" />
</asp:Panel>	  
      </td>
	</tr>
  </thead>
</table>
<br />           

<div id="PanelDefault">
<asp:Panel runat=server ID=search2 Visible=true>
<div id=s_div style="display:none">
<asp:Panel ID="panLogin" runat="server" DefaultButton="search_bt">
<table class="table">
<thead>
<tr>
	<td><a href="#" class="helpall">[?]</a></td>
	<td>
		<asp:Button runat=server class="button" ID=search_bt Text='搜 索' OnClick=Search_Btn  />
         &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp; 
          &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;
        <asp:Button runat=server class="button" ID=dc_bt Text='导 出' OnClick=DC_Btn  />
	</td>
</tr>
</thead>

<tr>
	<th style="width:140px; font-weight:bold;">&nbsp;* 考勤类型：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 需要查询的考勤类型.</span>
	<asp:DropDownList runat=server ID=AttendType >
    <asp:ListItem Value='1' Text='上下班考勤'></asp:ListItem>
    <asp:ListItem Value='2' Text='外出'></asp:ListItem>
    <asp:ListItem Value='3' Text='请假'></asp:ListItem>
    <asp:ListItem Value='4' Text='出差'></asp:ListItem>
    </asp:DropDownList>
	</td>
</tr>

<tr>
	<th style="width:140px; font-weight:bold;">&nbsp;* 登记时间：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 发起时间区域. </span>
	<INPUT runat=server id=BeginTime_S name=BeginTime_S type=text class="Wdate" dataType="Require" msg="登记开始时间不能为空!"  readonly onClick="WdatePicker()"> 至
<INPUT runat=server id=EndTime_S name=EndTime_S type=text class="Wdate" dataType="Require" msg="登记截止时间不能为空!"  readonly onClick="WdatePicker()"> 当天请输入 当天日期 至 下一天日期
	</td>
</tr>

<tr>
	<th style="width:140px; font-weight:bold;">&nbsp;* 考勤人员：<a href="#" class="help">[?]</a></th>
	<td><span class="note">可输入 你要搜索的考勤人员(可输入真实姓名 或 部门名称).</span>
	<input runat=server name="keyword"  maxlength=30  dataType="Require" msg="考勤人员不能为空" type="text" value="" id="keyword" size=50 /> (可输入真实姓名 或 部门名称)
    </td>
</tr>

</table>
</asp:Panel>
<br />
</div>
</asp:Panel>

<asp:Panel runat=server ID=list1 Visible=false> 	
<table class="table">
<thead>
	<tr>
		<th width="40">
		<input type="checkbox" name=ckb class="checkall">
		</th>
		<td width="50"><span style="margin-left:15px;">序</span></td>
			<td width="100">考勤日期</td>
			<td width="175">考勤类别</td>
			<td width="175">考勤数据</td>
            <td >备注</td>
			<td width="80">登记人</td>
			<td width="125">管理</td>
	</tr>
</thead>
 
 <asp:Repeater runat=server ID=rpt1 ><ItemTemplate>
	<tr>
		<th width="50"><input runat=server id=chk1 type="checkbox" value=<%#Eval("id") %> class="checkdelete"></th>
		<td><span style="margin-left:10px;"><%# Container.ItemIndex+1 %></span></td>
		<td style="font-weight:bold;">
        <%# Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd")%>
		</td>	
		<td>
        <%# Eval("StandardNames")%> <%# Eval("StandardTimes")%>
		</td>
		<td>
        <%# Eval("SignTimes")%> &nbsp; (<%# SignJudge(Eval("SignJudge"))%>)
		</td>
		<td class="vtip" title='<%# Eval("Notes") %>'>
        <%# WC.Tool.Utils.GetSubString2(Eval("Notes") + "", 20, "..") %>
		</td>
		<td >
        <%# Eval("RealName")%>
		</td>
	    <td class="manage">
        <a onclick=depView(<%#Eval("id") %>) href=# >查看</a>
		<a href='WorkList.aspx?type=1&delete=true&wid=<%#Eval("id") %>' class="delete" title="你确定要删除这一项吗？">删除</a>
        </td>	
	</tr>
 </ItemTemplate></asp:Repeater>
 
</table>

<table class="table">
<tr>
	<td class="page">
	<span style="float:left;" id=num1 runat=server></span>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<uc1:Page ID="Page1" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;</td>
</tr>
</table>
<br />
 </asp:Panel>

<asp:Panel runat=server ID=list2 Visible=false> 	
<table class="table">
<thead>
	<tr>
		<th width="40">
		<input type="checkbox" name=ckb class="checkall">
		</th>
		<td width="50"><span style="margin-left:15px;">序</span></td>
			<td width="100">登记日期</td>
			<td width="115">开始时间</td>
			<td width="115">结束时间</td>
			<td >备注</td>
			<td width="80">外出人</td>
			<td width="135">管理</td>
	</tr>
</thead>
 
 <asp:Repeater runat=server ID=rpt2 ><ItemTemplate>
	<tr>
		<th width="50"><input runat=server id=chk2 type="checkbox" value=<%#Eval("id") %> class="checkdelete"></th>
		<td><span style="margin-left:10px;"><%# Container.ItemIndex+1 %></span></td>
		<td style="font-weight:bold;">
        <%# Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd")%>
		</td>	
		<td>
        <%# WC.Tool.Utils.ConvertDate(Eval("BeginTime")) + " &nbsp;" + Eval("B1") + ":" + Eval("B2")%>
		</td>
		<td>
        <%# WC.Tool.Utils.ConvertDate(Eval("EndTime")) + " &nbsp;" + Eval("E1") + ":" + Eval("E2")%>
		</td>
		<td class="vtip" title='<%# Eval("Notes") %>'>
        <%# WC.Tool.Utils.GetSubString2(Eval("Notes") + "", 20, "..") %>
		</td>
		<td >
        <%# Eval("RealName")%>
		</td>
	    <td class="manage">
        <a onclick=depView(<%#Eval("id") %>) href=# >查看</a>
        <a href='WorkList.aspx?type=2&delete=true&wid=<%#Eval("id") %>' class="delete" title="你确定要删除这一项吗？">删除</a>
		</td>	
	</tr>
 </ItemTemplate></asp:Repeater>
 
</table>

<table class="table">
<tr>
	<td class="page">
	<span style="float:left;" id=num2 runat=server></span>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<uc2:Page ID="Page2" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;</td>
</tr>
</table>
<br />
 </asp:Panel>

<asp:Panel runat=server ID=list3 Visible=false> 	
<table class="table">
<thead>
	<tr>
		<th width="40">
		<input type="checkbox" name=ckb class="checkall">
		</th>
		<td width="50"><span style="margin-left:15px;">序</span></td>
			<td width="100">登记日期</td>
			<td width="110">开始时间</td>
			<td width="110">结束时间</td>
			<td >备注</td>
			<td width="80">请假人</td>
			<td width="135">管理</td>
	</tr>
</thead>
 
 <asp:Repeater runat=server ID=rpt3 ><ItemTemplate>
	<tr>
		<th width="50"><input runat=server id=chk3 type="checkbox" value=<%#Eval("id") %> class="checkdelete"></th>
		<td><span style="margin-left:10px;"><%# Container.ItemIndex+1 %></span></td>
		<td style="font-weight:bold;">
        <%# Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd")%>
		</td>	
		<td>
        <%# WC.Tool.Utils.ConvertDate(Eval("BeginTime")) + " &nbsp;" + Eval("B1") + ":" + Eval("B2")%>
		</td>
		<td>
        <%# WC.Tool.Utils.ConvertDate(Eval("EndTime")) + " &nbsp;" + Eval("E1") + ":" + Eval("E2")%>
		</td>
		<td class="vtip" title='<%# Eval("Notes") %>'>
        <%# WC.Tool.Utils.GetSubString2(Eval("Notes") + "", 20, "..") %>
		</td>
		<td >
        <%# Eval("RealName")%>
		</td>
	    <td class="manage">
        <a onclick=depView(<%#Eval("id") %>) href=# >查看</a>
        <a href='WorkList.aspx?type=3&delete=true&wid=<%#Eval("id") %>' class="delete" title="你确定要删除这一项吗？">删除</a>
		</td>	
	</tr>
 </ItemTemplate></asp:Repeater>
 
</table>

<table class="table">
<tr>
	<td class="page">
	<span style="float:left;" id=num3 runat=server></span>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<uc3:Page ID="Page3" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;</td>
</tr>
</table>
<br />
 </asp:Panel>

<asp:Panel runat=server ID=list4 Visible=false> 	
<table class="table">
<thead>
	<tr>
		<th width="40">
		<input type="checkbox" name=ckb class="checkall">
		</th>
		<td width="50"><span style="margin-left:15px;">序</span></td>
            <td width="100">登记日期</td>
			<td width="110">开始时间</td>
			<td width="110">结束时间</td>
			<td >备注</td>
			<td width="80">出差人</td>
            <td width="80">出差地点</td>
			<td width="135">管理</td>
	</tr>
</thead>
 
 <asp:Repeater runat=server ID=rpt4 ><ItemTemplate>
	<tr>
		<th width="50"><input runat=server id=chk4 type="checkbox" value=<%#Eval("id") %> class="checkdelete"></th>
		<td><span style="margin-left:10px;"><%# Container.ItemIndex+1 %></span></td>
		<td style="font-weight:bold;">
        <%# Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd")%>
		</td>
		<td>
        <%# WC.Tool.Utils.ConvertDate(Eval("BeginTime")) + " &nbsp;" + Eval("B1") + ":" + Eval("B2")%>
		</td>
		<td>
        <%# WC.Tool.Utils.ConvertDate(Eval("EndTime")) + " &nbsp;" + Eval("E1") + ":" + Eval("E2")%>
		</td>
		<td class="vtip" title='<%# Eval("Notes") %>'>
        <%# WC.Tool.Utils.GetSubString2(Eval("Notes") + "", 20, "..") %>
		</td>
		<td >
        <%# Eval("RealName")%>
		</td>
		<td>
        <%# Eval("TravelAddress")%>
		</td>
	    <td class="manage">
        <a onclick=depView(<%#Eval("id") %>) href=# >查看</a>
        <a href='WorkList.aspx?type=4&delete=true&wid=<%#Eval("id") %>' class="delete" title="你确定要删除这一项吗？">删除</a>
		</td>	
	</tr>
 </ItemTemplate></asp:Repeater>
 
</table>

<table class="table">
<tr>
	<td class="page">
	<span style="float:left;" id=num4 runat=server></span>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<uc4:Page ID="Page4" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;</td>
</tr>
</table>
<br />
 </asp:Panel>

 <asp:Panel runat=server ID=del5 Visible=false DefaultButton="del_bt"> 
 <table class="table">
 <tr>
	<th style="width:140px; font-weight:bold;">&nbsp;* 起始时间：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 需要删除的起始登记时间.</span>
    <INPUT runat=server id=BeginTime_D name=BeginTime_D type=text class="Wdate" dataType="Require" msg="起始登记时间不能为空!"  readonly onClick="WdatePicker()">
	</td>
 </tr>
  <tr>
	<th style="width:140px; font-weight:bold;">&nbsp;* 结束时间：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 需要删除的结束登记时间.</span>
    <INPUT runat=server id=EndTime_D name=EndTime_D type=text class="Wdate" dataType="Require" msg="结束登记时间不能为空!"  readonly onClick="WdatePicker()"> 当天请输入 当天日期 至 下一天日期
	</td>
 </tr>
  <tr>
	<th style="width:140px; font-weight:bold;">&nbsp;* 删除内容：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 需要删除的内容.</span>
    <asp:CheckBoxList runat=server ID=DeleteType RepeatDirection=Vertical>
    <asp:ListItem Text='上下班考勤' Value='1'></asp:ListItem>
    <asp:ListItem Text='外出' Value='2'></asp:ListItem>
    <asp:ListItem Text='请假' Value='3'></asp:ListItem>
    <asp:ListItem Text='出差' Value='4'></asp:ListItem>
    </asp:CheckBoxList>
	</td>
 </tr>
 <tr>
	<th style="width:140px; font-weight:bold;">&nbsp; 删除范围：<a href="#" class="help">[?]</a></th>
	<td><span class="note">可输入 你要搜索的删除范围(可输入真实姓名 或 部门名称).</span>
	<input runat=server name="delarea"  maxlength=30  type="text" value="" id="delarea" size=50 /> (可输入真实姓名 或 部门名称)
    </td>
</tr>
   <tr>
	<th style="width:140px; font-weight:bold;">&nbsp;</th>
	<td>
    <asp:Button runat=server class="button" ID=del_bt Text='删 除' OnClick=DelAll_Btn OnClientClick='return confirm("确实要删除选择的考勤数据吗?")'  />
	</td>
 </tr>
 </table>
 </asp:Panel>

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

