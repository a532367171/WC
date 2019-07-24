﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Doc_Manage.aspx.cs" Inherits="Manage_Doc_Doc_Manage" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>资讯编辑</title>
<script type="text/javascript" src="../../js/validator.js"></script>
<link type="text/css" href="../../Manage/Style/InterFace.Css" rel="stylesheet" rev="stylesheet" media="all" />
<link type="text/css" href="../../Manage/style.css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../Manage/include/common.js"></script> 
    
    <script type="text/javascript" src="../../js/popup/popup.js"></script>
    <script type="text/javascript">
        function fAddAttach() {
            var gAttchHTML = '<div><input type="file" name="attachfile"><input type="button" name="Submit" value=" 删除 " id="btnDeleteReadAttach" /></div><span></span>';
            var Attach = document.getElementById("dvReadAttach");
            var spnList = Attach.getElementsByTagName("SPAN");
            var spn = document.createElement("DIV");
            spn.innerHTML = gAttchHTML;
            spn.childNodes[0].name = "attachfile[]" + spnList.length;
            Attach.appendChild(spn); //增加gAttchHTML
            fGetObjInputById(spn, "btnDeleteReadAttach").onclick = function () { fDeleteAttach(this); };
            document.getElementById("aAddAttach").innerHTML = "继续添加附件";
            Attach.style.display = "";
        }

        function fGetObjInputById(obj, id) {
            var inputList = obj.getElementsByTagName("INPUT");
            for (var i = 0; i < inputList.length; i++) {
                if (inputList[i].id == id) {
                    return inputList[i];
                }
            }
            return null;
        }

        function fDeleteAttach(obj) {
            obj.parentNode.parentNode.parentNode.removeChild(obj.parentNode.parentNode);
            var Attach = document.getElementById("dvReadAttach");
            var spnList = Attach.getElementsByTagName("SPAN");
            if (spnList.length == 0) {
                document.getElementById("aAddAttach").innerHTML = "添加附件";
                Attach.style.display = "none";
            }
            else {
                document.getElementById("aAddAttach").innerHTML = "继续添加附件";
            }
        }

        function ShowIframe() {
            var users = document.getElementById("userlist");
            var pop = new Popup({ contentType: 1, scrollType: 'no', isReloadOnClose: false, width: 468, height: 395 });
            pop.setContent("contentUrl", "../../Manage/Utils/SelectPeople.aspx");
            pop.setContent("title", "文档共享 - 共享人员选择");
            pop.build();
            pop.show();
        }
</script>     
    
    
</head>
<body >
    <form id="form1" runat="server" onsubmit="return Validator.Validate(this.form,1);" enctype="multipart/form-data">
<div id="interface_inside">
  <div id="interface_quick">
    <div class="interface_quick_left">您现在的操作 >> 我的文档 >> 新建上传文件</div>
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

<table class="table1">
<thead>
<tr>
	<td><a href="#" class="helpall">[?]</a></td>
	<td>
		<asp:Button runat=server class="button" ID=Button1 Text='保存' OnClick=Save_Btn OnClientClick="return Validator.Validate(this.form,1);" />
	&nbsp;&nbsp;<input type="reset" class="button" value='重置' />
	</td>
</tr>
</thead>
<tr>
	<th style="width:140px; font-weight:bold;">&nbsp;* 文档标题：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请输入 文档标题.</span>
	<input runat=server name="DocTitle" dataType="Require" msg="文档标题不能为空" type="text" value="" id="DocTitle" size=97 /></td>
</tr>
<tr>
	<th style="width:140px; font-weight:bold;">&nbsp;* 文档分类：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 文档分类. (您可以在 文件分类 中添加自己的分类)</span>
	<asp:DropDownList runat=server ID=doctype style="width:610px;" EnableViewState=false></asp:DropDownList>
	</td>
</tr>
<tr>
	<th style="width:140px; font-weight:bold;">&nbsp;是否共享：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 是否要 共享该文档</span>
	<select runat=server id=IsShare style="width:610px;" onchange='javascript:if(this.value=="1"){document.getElementById("tr").style.display=""}else{document.getElementById("tr").style.display="none";document.getElementById("userlist").value="";document.getElementById("namelist").value="";} '>
	<option value=0 selected>这是个人文档 不需要共享</option>
	<option value=1>我要将该文档 共享给其他同事</option> 
	</select>   
	</td>
</tr>
<tr id=tr runat=server style="display:none;">
	<th style="width:140px; font-weight:bold;">&nbsp;共享人员：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 共享人员：点击右侧 [共享人员] 按钮.</span>
	<input runat=server type=hidden id=userlist name=userlist value="" />
	<textarea runat=server id=namelist name=namelist readonly=readonly 
	rows=3 cols=70 ></textarea>
	<input type=button value=共享人员 class="textbutton" onclick=ShowIframe() />
	</td>
</tr>
<tr>
	<th style="width:140px; font-weight:bold;">备注&nbsp;<a href="#" class="help">[?]</a></th>
	<td>
	<span class="note">请输入 该文档的备注. </span>
	<textarea runat=server style="BACKGROUND-IMAGE: url(/img/line.gif); LINE-HEIGHT: 22px; padding-left:3px; background-repeat:repeat;" name=Notes id=Notes rows=3 cols=70></textarea>
	</td>
</tr>
<tr >
	<th style="width:140px; font-weight:bold;">* 附件&nbsp;<a href="#" class="help">[?]</a></th>
	<td>
	<span class="note">可批量添加附件,附件总大小上限 50M. </span>
		&nbsp;&nbsp;<span style="font-weight:bold;"><a href="javascript:fAddAttach();" id="aAddAttach">添加附件</a></span>
		<br />
		<div runat=server id="dvReadAttach" style="float:left;"></div>
	</td>
</tr>

<asp:Panel ID="Attachword" runat="server" Visible="false">
<tr >
	<th style="width:140px; font-weight:bold;">已添加附件&nbsp;<a href="#" class="help">[?]</a></th>
	<td>
	<span class="note">勾选复选框 编辑已添加附件 </span>
		&nbsp;&nbsp;<div style="text-align:left; float:left;">
		<asp:Repeater runat=server ID=rpt><ItemTemplate>
		<input runat=server id=chk type="checkbox" checked=checked value=<%#Eval("Tmp1") %> />
		<%#Eval("Tmp2") %> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName=<%# Server.UrlEncode(Eval("Tmp3")+"") %>' ><img src='/img/mail_attachment.gif' />下载附件</a>
		 
		<br>
	    </ItemTemplate></asp:Repeater></div>
	</td>
</tr>
</asp:Panel>

<tr>
	<th>&nbsp;</th>
	<td>
	<asp:Button runat=server class="button" ID=save_bt Text='保存' OnClick=Save_Btn OnClientClick="return Validator.Validate(this.form,1);" />
	&nbsp;&nbsp;<input type="reset" class="button" value='重置' />
</td>
</tr>

</table>

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

