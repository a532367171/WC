﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaperManage.aspx.cs" Inherits="Manage_Paper_PaperManage" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>电子档案编辑</title>
<script type="text/javascript" src="../../js/validator.js"></script>
<link type="text/css" href="../../Manage/Style/InterFace.Css" rel="stylesheet" rev="stylesheet" media="all" />
<link type="text/css" href="../../Manage/style.css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../Manage/include/common.js"></script> 
<script type="text/javascript" src="../../js/formV/datepicker/WdatePicker.js"></script> 
    
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
            document.getElementById("aAddAttach").innerHTML = "继续添加档案附件";
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
                document.getElementById("aAddAttach").innerHTML = "添加档案附件";
                Attach.style.display = "none";
            }
            else {
                document.getElementById("aAddAttach").innerHTML = "继续添加档案附件";
            }
        }

        function ShowIframe() {
            var users = document.getElementById("userlist_dep");
            var pop = new Popup({ contentType: 1, scrollType: 'yes', isReloadOnClose: false, width: 468, height: 395 });
            if (users.value == "") {
                pop.setContent("contentUrl", "../../Manage/Utils/SelectDep.aspx");
            }
            else {
                var ids = "";
                var objs = users.value.split(',');
                for (var i = 0; i < objs.length; i++) {
                    if (objs[i].replace(/^\s*(.*?)[\s\n]*$/g, '$1') != "") {
                        ids += objs[i].split('#')[1] + ";";
                    }
                }

                pop.setContent("contentUrl", "../../Manage/Utils/SelectDep.aspx?v=" + ids);
            }
            pop.setContent("title", "电子档案 - 部门选择");
            pop.build();
            pop.show();
        }
</script>     
        
</head>
<body >
    <form id="form1" runat="server" onsubmit="return Validator.Validate(this.form,1);" enctype="multipart/form-data">
<div id="interface_inside">
  <div id="interface_quick">
    <div class="interface_quick_left">您现在的操作 >> 电子档案 >> 编辑电子档案</div>
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
    &nbsp;&nbsp; <input type="reset" class="button" value='重置' />
	</td>
</tr>
</thead>
<tr>
	<th style="width:140px; font-weight:bold;">&nbsp;* 档案标题：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请输入 档案标题.</span>
	<input runat=server name="PaperName" dataType="Require" msg="档案标题不能为空" type="text" value="" id="PaperName" size=82 /></td>
</tr>
<tr>
	<th style="width:140px; font-weight:bold;">&nbsp;* 档案分类：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 档案类别. (您可以在 档案类别管理 中添加自己的分类)</span>
	<asp:DropDownList runat=server ID=TypeID dataType="Require" msg="您还没选择任何档案分类" style="width:500px;" EnableViewState=false></asp:DropDownList>
	</td>
</tr>
<tr>
	<th style="width:140px; font-weight:bold;">&nbsp; 来文单位：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请输入 来文单位.</span>
	<input runat=server name="SendDep" type="text" value="" id="SendDep" size=60 /></td>
</tr>
<tr>
	<th style="width:140px; font-weight:bold;">&nbsp; 文号：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请输入 文号.</span>
	<input runat=server name="PaperSymbol" type="text" value="" id="PaperSymbol" size=60 /></td>
</tr>
<tr>
	<th style="width:140px; font-weight:bold;">&nbsp; 密级：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请输入 密级.</span>
	<input runat=server name="PaperGrade" type="text" value="" id="PaperGrade" size=60 /></td>
</tr>
<tr>
	<th style="width:140px; font-weight:bold;">&nbsp; 档案日期：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请输入 档案日期.</span>
	<input runat=server name="PaperDate" type="text" dataType="Custom" regexp="^(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12]\d|3[01])$" msg="档案日期格式不正确" value="" id="PaperDate" class="Wdate" onclick="WdatePicker({ dateFmt: 'yyyyMMdd' })" maxlength=30 size=60 /></td>
</tr>
<tr>
	<th style="width:140px; font-weight:bold;">&nbsp;发布范围：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 发布范围</span>
	<select runat=server id=sel style="width:500px;" onchange='javascript:if(this.value=="1"){document.getElementById("tr").style.display=""}else{document.getElementById("tr").style.display="none";document.getElementById("userlist_dep").value="";document.getElementById("namelist_dep").value="";} '>
	<option value=0 selected>发送全体人员</option>
	<option value=1>我要自行选择接收部门</option>
	</select>
	</td>
</tr>
<tr id=tr runat=server style="display:none;">
	<th style="width:140px; font-weight:bold;">&nbsp;接收部门：<a href="#" class="help">[?]</a></th>
	<td><span class="note">请选择 接收人：点击右侧 [接收部门] 按钮, 发送全体人员请留空.</span>
	<input runat=server type=hidden id=userlist_dep name=userlist_dep value="" />
	<input runat=server size=71 name="namelist_dep" type="text" id="namelist_dep" readonly=readonly  />	
	<input type=button value=接收部门 class="textbutton" onclick=ShowIframe() />
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
	<th style="width:140px; font-weight:bold;">* 档案附件&nbsp;<a href="#" class="help">[?]</a></th>
	<td>
	<span class="note">可批量添加档案附件,档案附件总大小上限 50M. </span>
		&nbsp;&nbsp;<span style="font-weight:bold;"><a href="javascript:fAddAttach();" id="aAddAttach">添加档案附件</a></span>
		<br />
		<div runat=server id="dvReadAttach" style="float:left;"></div>
	</td>
</tr>

<asp:Panel ID="Attachword" runat="server" Visible="false">
<tr >
	<th style="width:140px; font-weight:bold;">已添加档案附件&nbsp;<a href="#" class="help">[?]</a></th>
	<td>
	<span class="note">勾选复选框 编辑已添加档案附件 </span>
		&nbsp;&nbsp;<div style="text-align:left; float:left;">
		<asp:Repeater runat=server ID=rpt><ItemTemplate>
		<input runat=server id=chk type="checkbox" checked=checked value=<%#Eval("Tmp1") %> />
		<%#Eval("Tmp2") %> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName=<%# Server.UrlEncode(Eval("Tmp3")+"") %>' ><img src='/img/mail_attachment.gif' />下载档案附件</a>
		 
		<br>
	    </ItemTemplate></asp:Repeater></div>
	</td>
</tr>
</asp:Panel>

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

