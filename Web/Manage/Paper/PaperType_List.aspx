﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaperType_List.aspx.cs" Inherits="Manage_Paper_PaperType_List" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>分类列表</title>
<link type="text/css" href="../../Manage/Style/InterFace.Css" rel="stylesheet" rev="stylesheet" media="all" />
<link type="text/css" href="../../Manage/style.css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../Manage/include/common.js"></script>
<script type="text/javascript" src="../../js/validator.js"></script>     
</head>
<body >
    <form id="form1" runat="server">
    <div id="interface_inside">
  <div id="interface_quick">
    <div class="interface_quick_left">您现在的操作 >> 电子档案 >> 分类列表</div>
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
    
<div id="PanelDefault">
	
<table class="table">
<thead>
	<tr>
		
		<td width="70"><span style="margin-left:25px;">序</span></td>
			<td>档案分类名称</td>
			<td width="50">排序</td>			
		  <td width="150">管理</td>	
	</tr>
</thead>

<asp:Repeater runat=server ID=rpt><ItemTemplate>
<tr>
<td><span style="margin-left:25px;"><%# Container.ItemIndex+1 %></span></td>
<td><%# Eval("Ch")+"<strong>"+Eval("TypeName")+"</strong>"%></td>
<td><%#Eval("Orders")%></td>
<td class="manage">
<a href=PaperType_Manage.aspx?tid=<%#Eval("id") %> class="show">编辑</a>
<asp:LinkButton runat=server CommandArgument=<%#Eval("id") %> ID=lb_del OnClick=Del_Btn class="delete" title="要删除该分类及该分类下所有电子档案吗?">删除</asp:LinkButton>
</tr>
</ItemTemplate></asp:Repeater>

</table>
<table class="table">
<tr>
	<td class="page"></td>
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

