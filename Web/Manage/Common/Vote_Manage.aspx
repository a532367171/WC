﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vote_Manage.aspx.cs" Inherits="Manage_Common_Vote_Manage" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>新建投票</title>
<script type="text/javascript" src="../../js/validator.js"></script>
<link type="text/css" href="../../Manage/Style/InterFace.Css" rel="stylesheet" rev="stylesheet" media="all" />
<link type="text/css" href="../../Manage/style.css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../Manage/include/common.js"></script>    
<script type="text/javascript" src="../../js/popup/popup.js"></script>
<script type="text/javascript">
    function ShowIframe() {
        var users = document.getElementById("userlist");
        var pop = new Popup({ contentType: 1, scrollType: 'no', isReloadOnClose: false, width: 468, height: 395 });
        pop.setContent("contentUrl", "../../Manage/Utils/SelectPeople.aspx");
        pop.setContent("title", "投票管理 - 参与投票人员选择");
        pop.build();
        pop.show();
    }
</script>
</head>
<body >
    <form id="form1" runat="server" onsubmit="return Validator.Validate(this.form,1);" >
<div id="interface_inside">
  <div id="interface_quick">
    <div class="interface_quick_left">您现在的操作 >> 我的投票 >> 新建投票</div>
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
<a href="Vote_List.aspx">投票列表</a>
<a href="Vote_Manage.aspx">新建投票</a>
	  </td>
	  <td style="text-align:right">

	  </td>
	</tr>
  </thead>
</table>
<br />            
            

<table class="table">
<thead>
<tr>
	<td><a href="#" class="helpall">[?]</a></td>
	<td>&nbsp;
	<asp:Button runat=server class="button" ID=Button1 Text='保存' OnClick=Save_Btn OnClientClick="return Validator.Validate(this.form,1);" />&nbsp;&nbsp;
	<input type="reset" class="button" value='重置' />
	</td>
</tr>
</thead>
<tr>
	<th style="width:140px;font-weight:bold;">* 投票主题&nbsp;<a href="#" class="help">[?]</a></th>
	<td><span class="note">请填写 投票主题的名称</span>
    <input runat=server name="VoteTitle" type="text" dataType="Require" msg="投票主题不能为空" id="VoteTitle" style="width:504px;" />
	</td>
</tr>
<tr>
	<th style="width:140px;font-weight:bold;">* 投票项目&nbsp;<a href="#" class="help">[?]</a></th>
	<td><span class="note">请在这里输入投票项目 不同的投票项目间 请用回车换行表示</span>
	<span style="color:#ff0000">[提示] 不同的投票项目间 请用回车换行表示 </span>(建议勿超过12个选项)<br>
	<textarea runat=server name=VoteContent id=VoteContent style="width:504px;height:120px;BACKGROUND-IMAGE: url(/img/line.gif); LINE-HEIGHT: 22px; padding-left:10px; background-repeat:repeat; font-weight:bold; color:#000; font-size:10pt;" dataType="Require" msg="投票项目不能为空!"></textarea>
	</td>
</tr>
<tr>
	<th style="width:140px; font-weight:bold;">&nbsp;投票参与人：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 投票人员：点击右侧 [投票人员] 按钮.</span>
	<input runat=server type=hidden id=userlist name=userlist value="" />
	<textarea runat=server id=namelist name=namelist readonly=readonly 
	rows=3 cols=55 dataType="Require" msg="投票参与人不能为空!"></textarea>
	<input type=button value=投票人员 class="textbutton" onclick=ShowIframe() />
	</td>
</tr>
<tr>
    <th style="width:140px;font-weight:bold;">投票属性&nbsp;<a href="#" class="help">[?]</a></th>
    <td><span class="note">请在这里选择投票属性 完毕点击保存</span>
    <asp:DropDownList runat=server ID='IsMultiple'>
    <asp:ListItem Text='单选投票' Value='0'></asp:ListItem>
    <asp:ListItem Text='多选投票' Value='1'></asp:ListItem>
    </asp:DropDownList>
    
    <asp:DropDownList runat=server ID='ShowUser'>
    <asp:ListItem Text='匿名投票' Value='0'></asp:ListItem>
    <asp:ListItem Text='公开投票' Value='1'></asp:ListItem>
    </asp:DropDownList>  
    
    <asp:DropDownList runat=server ID='IsValide'>
    <asp:ListItem Text='投票启用' Value='1'></asp:ListItem>
    <asp:ListItem Text='投票停止' Value='0'></asp:ListItem>
    </asp:DropDownList>      
    </td>
</tr>
<tr>
	<th  style="width:140px;">&nbsp;</th>
	<td>&nbsp;
	<asp:Button runat=server class="button" ID=save_bt Text='保存' OnClick=Save_Btn OnClientClick="return Validator.Validate(this.form,1);" />&nbsp;&nbsp;
	<input type="reset" class="button" value='重置' />
	</td>
</tr>
</table>

              </div></div></div>
               </td>
          </tr>
        </table>

      <!-- 模块 -->

    </div>
  </div>
</div>
    </form>
</body>
</html>

