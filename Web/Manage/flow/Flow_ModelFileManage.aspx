<%@ Page Language="C#" validateRequest="false" AutoEventWireup="true"   CodeFile="Flow_ModelFileManage.aspx.cs" Inherits="Manage_flow_Flow_ModelFileManage" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>编辑模板表单</title>
<script type="text/javascript" src="../../js/validator.js"></script>
<link type="text/css" href="../../manage/Style/InterFace.Css" rel="stylesheet" rev="stylesheet" media="all" />
<link type="text/css" href="../../manage/style.css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../manage/include/common.js"></script>
 
<script type="text/javascript" src="../../KindEditor/kindeditor.js"></script>
<script type="text/javascript">
    KE.show({
        id: 'DocBody',
        resizeMode: 2, //0 : 禁止拖动; 1 : 可拖动高度; 2 可拖动;
        imageUploadJson: '/KindEditor/upload_json.aspx',
        fileManagerJson: '/KindEditor/file_manager_json.aspx',
        allowFileManager: false,
        afterCreate: function (id) {
            KE.event.ctrl(document, 13, function () {
                KE.util.setData(id);
                document.forms['form1'].submit();
            });
            KE.event.ctrl(KE.g[id].iframeDoc, 13, function () {
                KE.util.setData(id);
                document.forms['form1'].submit();
            });
        }
    });
</script>
 
</head>
<body >
    <form id="form1" runat="server" onsubmit="return Validator.Validate(this.form,3);" enctype="multipart/form-data">
<div id="interface_inside">
  <div id="interface_quick">
    <div class="interface_quick_left">您现在的操作 >> 系统管理 >> 流程管理</div>
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
	  <a href="Flow_ModelFileManage.aspx">新增模板表单</a>	  
	  </td>
	  <td style="text-align:right">

	  </td>
	</tr>
  </thead>
</table>
<br />

<div id="PanelManage">
	
<table class="table1">
<thead>
<tr>
	<td> 编辑模板表单&nbsp;<a href="#" title='查看所有帮助' class="helpall">[?]</a></td>
	<td>&nbsp;
	<asp:Button runat=server class="button" ID=Button1 Text='保存' OnClick=Save_Btn OnClientClick="return Validator.Validate(this.form,3);" />
	&nbsp;&nbsp;<input type="reset" class="button" value='重置' />
	</td>	
</tr>
</thead>

<tr >
	<th style="width:135px;">* 模板表单名称&nbsp;<a href="#" class="help">[?]</a></th>
	<td>
	<span class="note">请输入模板表单的名称 如：财务报销流程表单</span>
			<input runat=server size=50 dataType="Require" maxlength=50
			msg="模板表单名称不能为空" name="FormTitle" type="text" id="FormTitle" />
	</td>
</tr>

<tr >
	<th style="width:135px;">编辑表单&nbsp;<a href="#" class="help">[?]</a></th>
	<td>
	<span class="note">支持HTML自定义编辑丰富的Web表单. (编辑器大小可拖拉自如) </span>
		<div id="dvReadAttach" style="float:left; margin-top:6px; color:#ff0000">
		<strong>新手提示</strong>- 如对编辑器不熟 简便方法: 1、先在Word(或其他排版工具)中绘制好表单 2、然后复制粘贴至下方编辑器。
		</div>
		<textarea id="DocBody" style="width:735px;height:735px;visibility:hidden;" 
		runat="server" enableviewstate=false></textarea>
		<br>
	</td>
</tr>

<tr>
	<th>&nbsp;</th>
	<td>
	<asp:Button runat=server class="button" ID=Button2 Text='保存' OnClick=Save_Btn OnClientClick="return Validator.Validate(this.form,3);" />
	&nbsp;&nbsp;<input type="reset" class="button" value='重置' />
	<br>
</td>
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
