﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Memo_SubList.aspx.cs" Inherits="Manage_Common_Memo_SubList" %>

<%@ Register Src="~/Controls/Page.ascx" TagName="Page" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>下属工作日程</title>
<link type="text/css" href="../../Manage/Style/InterFace.Css" rel="stylesheet" rev="stylesheet" media="all" />
<link type="text/css" href="../../Manage/style.css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../Manage/include/common.js"></script>
<script type="text/javascript" src="../../js/validator.js"></script>    
<script type="text/javascript" src="../../js/formV/datepicker/WdatePicker.js"></script> 
<script type="text/javascript" src="../../js/popup/popup.js"></script>
<script type="text/javascript">

    function subView(uid, st) {
        var pop = new Popup({ contentType: 1, scrollType: 'yes', isReloadOnClose: false, width: 800, height: 420 });
        pop.setContent("contentUrl", '/manage/common/Memo_SubView.aspx?uid=' + uid + '&st=' + st);
        pop.setContent("title", '<%=uname %>' + ' 的工作日程');
    pop.build();
    pop.show();
}

function checkValues() {
    var objs = document.getElementsByTagName("input");
    var nums = 0;
    for (var i = 0; i < objs.length; i++) {
        if (objs[i].type == "checkbox" && objs[i].name != 'ckb') {
            if (objs[i].checked) {
                nums++;
                break;
            }
        }
    }
    if (nums == 0) {
        alert('您还没选择 任何要导出的 日程!');
        return false;
    }
    else {
        if (confirm('确实要批量导出日程吗?'))
            return true;
        else return false;
    }
}
</script>
</head>
<body >
    <form id="form1" runat="server">
    <div id="interface_inside">
  <div id="interface_quick">
    <div class="interface_quick_left">您现在的操作 >> 下属日程汇报>> 查看下属日程</div>
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

<table class="table subsubmenu">
  <thead>
	<tr>
	  <td>
<a href="/Manage/CalendarMemo/CalendarMemo.aspx" >我的日程</a>
<a href="/Manage/Common/Memo_General.aspx">导出我的日程</a>
<a href="/Manage/Common/MyMemo.aspx" >下属日程汇报</a>
	  </td>
	  <td style="text-align:right">
<input type=button name="s_bt" value="高级搜索" id="s_bt" onclick="javascript: $('#s_div').slideToggle('fast');" class="textbutton" />
	  </td>
	</tr>
  </thead>
</table>
<br />            
    
<div id="PanelConfig">
 
<div id=s_div style="display:none">
<asp:Panel ID="panLogin" runat="server" DefaultButton="search_bt">
<table class="table">
<thead>
<tr>
	<td><a href="#" class="helpall">[?]</a></td>
	<td>
		<asp:Button runat=server class="button" ID=search_bt Text='搜 索' OnClick=Search_Btn  />
	</td>
</tr>
</thead>
<tr>
	<th style="width:140px; font-weight:bold;">&nbsp; 搜寻日期：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 开始和截止日期.  留空不填 表示今天.</span>
	<INPUT runat=server id=StartTime name=StartTime type=text class="Wdate"   readonly onClick="WdatePicker()"> 到
<INPUT runat=server id=EndTime name=EndTime type=text class="Wdate"   readonly onClick="WdatePicker()">
	</td>
</tr>

</table>
</asp:Panel>
<br />
</div> 
 
<table class="table">
<thead>
	<tr>
		<th width="65">
		<asp:LinkButton ID="LinkButton1" runat=server OnClick=DownLoad OnClientClick='return checkValues()'>导出</asp:LinkButton>
		<input type="checkbox" name=ckb class="checkall">
		</th>
		<td width="80"><span style="margin-left:25px;">序</span></td>
			<td width="130">下属(部门)</td>
			<td width="305">日期</td>
			<td width="30"></td>
			<td width="155">操作</td>
	</tr>
</thead>
 
 <asp:Repeater runat=server ID=rpt><ItemTemplate>
	<tr>
		<th width="50"><input runat=server id=chk type="checkbox" value='<%#Eval("s") %>' class="checkdelete"></th>
		<td><span style="margin-left:25px;"><%# Container.ItemIndex+1 %></span></td>
		<td style="color:#333;font-weight:bold;">
		<%=uname %>
		</td>
		<td >
			<span style="color:#006600; font-weight:bold;"><%# GetDate(Eval("s")) %></span>
		</td>		
		<td>
		</td>
        <td class="manage">
 			<a href='#@' onclick='subView(<%=Request.QueryString["uid"] %>,<%#Eval("s") %>)' class='show'>查看当天日程</a>
        </td>
	</tr>
 </ItemTemplate></asp:Repeater>
 
</table>
    
<table class="table">
<tr>
	<td class="page">
	<span style="float:left;" id=num runat=server></span>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<uc1:Page ID="Page1" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;</td>
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
