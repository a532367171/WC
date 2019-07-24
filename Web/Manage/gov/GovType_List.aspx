﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GovType_List.aspx.cs" Inherits="Manage_gov_GovType_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>公文模型分类</title>
<link type="text/css" href="../../manage/Style/InterFace.Css" rel="stylesheet" rev="stylesheet" media="all" />
<link type="text/css" href="../../manage/style.css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../manage/include/common.js"></script>
<script type="text/javascript" src="../../js/validator.js"></script>     
</head>
<body >
    <form id="form1" runat="server">
    <div id="interface_inside">
  <div id="interface_quick">
    <div class="interface_quick_left">您现在的操作 >> 公文管理 >> 公文模型分类</div>
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
		
		<td width="50"><span style="margin-left:10px;">序</span></td>
			<td>模型分类名称</td>			
		  <td width="250">管理</td>	
	</tr>
</thead>

<asp:Repeater runat=server ID=rpt><ItemTemplate>
<tr>
<td><span style="margin-left:10px;"><%# Container.ItemIndex+1 %></span></td>
<td><%# Eval("Ch")+"<strong>"+Eval("TypeName")+"</strong>"%></td>
<td class="manage">
<a href=GovType_Manage.aspx?tid=<%#Eval("id") %> class="show">编辑</a>
<asp:LinkButton runat=server CommandArgument=<%#Eval("id") %> ID=lb_del OnClick=Del_Btn class="delete" title="要删除该分类及该分类下所有公文模型吗?">删除</asp:LinkButton>
<a href=Gov_ModelList.aspx?td=<%#Eval("id") %> class="show">所属模型列表</a>
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

