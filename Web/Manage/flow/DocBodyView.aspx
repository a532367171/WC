<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocBodyView.aspx.cs" Inherits="Manage_flow_DocBodyView" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>查看打印</title>
<link type="text/css" href="../../manage/style.css" rel="stylesheet" rev="stylesheet" media="all" />   
<script type="text/javascript" src="../../KindEditor/kindeditor.js"></script>
<script type="text/javascript">
    KE.show({
        id: 'DocBody',
        resizeMode: 2, //0 : 禁止拖动; 1 : 可拖动高度; 2 可拖动;
        imageUploadJson: '/KindEditor/upload_json.aspx',
        fileManagerJson: '/KindEditor/file_manager_json.aspx',
        allowFileManager: false,
        afterCreate: function (id) {
            KE.readonly(id);
            KE.g[id].newTextarea.disabled = true;
        }
    });
</script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table class="table subsubmenu">
  <thead>
	<tr>
	  <td><a href="#">&gt;&gt;&nbsp;查看内容</a>
	  <a href=# onclick='javascript:window.close()'>关闭页面</a>
	  </td>
	  <td style="text-align:right">
	  </td>
	</tr>
  </thead>
</table>

<table class="table1">
<tr>
	<th style="width:1px; font-weight:bold;"></th>
	<td align=center>
	<span style="color:#0077ff">提示：工具栏最后第二个为打印按钮</span>
		<textarea id="DocBody" style="width:720px;height:735px;visibility:hidden;" 
		runat="server" enableviewstate=false></textarea>
	</td>
</tr>

</table>

    </div>
    </form>
</body>
</html>
