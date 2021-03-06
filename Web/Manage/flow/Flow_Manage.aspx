﻿<%@ Page Language="C#" validateRequest="false" AutoEventWireup="true" CodeFile="Flow_Manage.aspx.cs" Inherits="Manage_flow_Flow_Manage" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>创建工作流程</title>   
<script type="text/javascript" src="../../js/validator.js"></script>
<link type="text/css" href="../../Manage/Style/InterFace.Css" rel="stylesheet" rev="stylesheet" media="all" />
<link type="text/css" href="../../Manage/style.css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../Manage/include/common.js"></script>

<script type="text/javascript" src="../../js/formV/datepicker/WdatePicker.js"></script>

<script type="text/javascript">
    function keyDown()
    {
        var keycode=event.keyCode;
        var keyChar=String.fromCharCode(keycode);
        if(event.keyCode==13 && event.srcElement.type!='button' && event.srcElement.type!='submit' && event.srcElement.type!='reset' && event.srcElement.type!=''&& event.srcElement.type!='textarea')
        {
            event.keyCode=9;
        }
    };
    document.onkeydown=keyDown;
</script>

<script type="text/javascript" src="../../js/popup/popup.js"></script>
<script type="text/javascript">
    function ShowIframe(obj)
    {
        var users = document.getElementById("userlist"+obj);
        var pop=new Popup({ contentType:1,scrollType:'no',isReloadOnClose:false,width:468,height:395});
        pop.setContent("contentUrl","../../Manage/Utils/SelectPeople_r.aspx?obj="+obj);
        pop.setContent("title","工作流程 - 审批人员选择");
        pop.build();
        pop.show();
    }             
    function ShowIframe1()
    {
        var users = document.getElementById("userlist");
        var pop=new Popup({ contentType:1,scrollType:'no',isReloadOnClose:false,width:468,height:395});
        pop.setContent("contentUrl","../../Manage/Utils/SelectPeople_rt.aspx");
        pop.setContent("title","工作流程 - 抄送人员选择");
        pop.build();
        pop.show();
    }              
             
</script>    
    
<script type="text/javascript">
    function fAddAttach()
    {
        var gAttchHTML='<div><input type="file" name="attachfile"><input type="button" name="Submit" value=" 删除 " id="btnDeleteReadAttach" /></div><span></span>';
        var Attach=document.getElementById("dvReadAttach");
        var spnList=Attach.getElementsByTagName("SPAN");
        var spn=document.createElement("DIV");
        spn.innerHTML=gAttchHTML;
        spn.childNodes[0].name="attachfile[]" + spnList.length;
        Attach.appendChild(spn); //增加gAttchHTML
        fGetObjInputById(spn,"btnDeleteReadAttach").onclick=function(){fDeleteAttach(this);};
        document.getElementById("aAddAttach").innerHTML="继续添加审批附件";
        Attach.style.display="";
    }

    function fGetObjInputById(obj,id)
    {
        var inputList=obj.getElementsByTagName("INPUT");
        for(var i=0;i<inputList.length;i++)
        {
            if(inputList[i].id==id)
            {
                return inputList[i];
            }
        }
        return null;
    }

    function fDeleteAttach(obj)
    {
        obj.parentNode.parentNode.parentNode.removeChild(obj.parentNode.parentNode);
        var Attach=document.getElementById("dvReadAttach");
        var spnList=Attach.getElementsByTagName("SPAN");
        if(spnList.length==0)
        {
            document.getElementById("aAddAttach").innerHTML="添加审批附件";
            Attach.style.display="none";
        }
        else
        {
            document.getElementById("aAddAttach").innerHTML="继续添加审批附件";
        }
    }

    function SaveDoc() {
        if (document.myform.Model_Type.value == "-1") {
            alert("您还没有选择分类！");
            document.myform.Model_Type.focus();
            return false;
        } 	 
        if(document.myform.ModelFlowList.value=="")
        {
            alert("您还没有选择流程模型！");
            document.myform.ModelFlowList.focus();
            return false;
        } 	            
        if(document.myform.Flow_Name.value=="")
        {
            alert("流程标题不能为空！");
            document.myform.Flow_Name.focus();
            return false;
        } 	
        if(document.myform.FlowRemark.value=="")
        {
            alert("流程说明不能为空！");
            document.myform.FlowRemark.focus();
            return false;
        }								
        if(confirm("流程发起后不可更改，您确定要正式发起流程吗?")){	
            return true;
        }
        else{
            return false;
        }
    }

    function select_btn() {
        var s = document.myform.se.value;
        if (s != '0') {
            var td = new Date();
            td.setDate(td.getDate() + parseInt(s));
            var n = td.getMonth() + 1;
            if (n < 10)
                n = '0' + n;
            document.myform.ValidTime.value = td.getFullYear() + '-' + n + '-' + td.getDate();
        }
        else
            document.myform.ValidTime.value = '';
    }

</script> 

<asp:Literal runat=server ID=kind_show Visible=false>
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
                document.forms['myform'].submit();
            });
            KE.event.ctrl(KE.g[id].iframeDoc, 13, function () {
                KE.util.setData(id);
                document.forms['myform'].submit();
            });
        }
    });
</script>
 </asp:Literal>  
 
</head>
<body >
    <form id="myform" name="myform" runat="server" onkeypress=keyDown() enctype="multipart/form-data">
<div id="interface_inside">
  <div id="interface_quick">
    <div class="interface_quick_left">您现在的操作 >> 工作流程 >> 新建流程 </div>
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
<a href="Flow_Manage.aspx" >新建流程</a>
<a href="TypeList_ForView.aspx">分类导航</a>
<a href="Flow_List.aspx?action=verify" >我的批阅( <span id=wdpy runat=server style="color:#ff0000; font-weight:bold;">0/0</span> )</a>
<a href="Flow_List.aspx?action=verified" >已经批阅( <span id=yjpy runat=server style="font-weight:bold;">0</span> )</a>
<a href="Flow_List.aspx?action=apply" >我的申请( <span id=wdsq runat=server style="font-weight:bold;">0</span> )</a>
<a href="Flow_List.aspx?action=view">抄送呈报( <span id=view runat=server style="font-weight:bold;">0</span> )</a>
	  </td>
	  <td style="text-align:right">

	  </td>
	</tr>
  </thead>
</table>
<br />            

<table class="table1">
<thead>
<tr>
	<td colspan="2"><a href="#" class="helpall">[?]</a></td>
</tr>
</thead>
<tr>
	<th style="width:95px; color:#ff0000; font-weight:bold;">* 流程分类&nbsp;</th>
	<td>
	<asp:DropDownList runat=server ID=Model_Type AutoPostBack=true OnSelectedIndexChanged=ModelType_btn style="width:520px;"></asp:DropDownList>
	</td>
</tr>
<tr>
	<th style="width:95px; color:#ff0000; font-weight:bold;">* 流程模型&nbsp;</th>
	<td>
	<asp:DropDownList runat=server ID=ModelFlowList AutoPostBack=true OnSelectedIndexChanged=Select_btn  dataType="Require" msg="您还没 选择流程模型" style="width:520px;"></asp:DropDownList>
	<span runat=server enableviewstate=false id=nts visible=false style="font-weight:bold">(说明)</span>
	</td>
</tr>
<tr>
	<th style="width:95px; color:blue; font-weight:bold;">* 流程名称&nbsp;</th>
	<td>
	<input runat=server name="Flow_Name" type="text" dataType="Require" msg="流程名称不能为空" id="Flow_Name" size=82 />
	</td>
</tr>
<tr>
	<th style="width:95px;">流程有效期&nbsp;<a href="#" class="help">[?]</a></th>
	<td><span class="note">1、可不填 表示永不过期 2、如果填写日期 流程过期则自动作废</span>
    <select name=se id=se onclick="select_btn()">
    <option value=0>自己选择日期</option>
    <option value=7>一星期</option>
    <option value=30>一个月</option>
    <option value=90>三个月</option>
    <option value=180>六个月</option>
    <option value=365>一年</option>
    </select> &nbsp; &nbsp; 
	<input runat=server name="ValidTime" type="text" class="Wdate"   readonly onClick="WdatePicker()" id="ValidTime" />
	</td>
</tr>
<tr>
	<th style="width:95px;">* 说明&nbsp;</th>
	<td>
	<textarea runat=server dataType="Require" msg="说明不能为空" style="BACKGROUND-IMAGE: url(/img/line.gif); LINE-HEIGHT: 22px; padding-left:10px; background-repeat:repeat;" name=FlowRemark id=FlowRemark rows=4 cols=70></textarea>
	</td>
</tr>
<tr>
	<th style="width:95px; font-weight:bold">* 流程步骤&nbsp;<a href="#" class="help">[?]</a></th>
	<td><span class="note">该流程流转的 审批步骤</span>
<asp:Repeater runat=server ID=rpt_steps OnItemDataBound=OnDataBind><ItemTemplate>
	<div style="height:26px;">
	<asp:Label ID='Step_Name' runat=server Text=<%#Eval("Step_Name") %> Visible=false ></asp:Label>
	<asp:Label ID='Step_Orders' runat=server Text=<%#Eval("Step_Orders") %> Visible=false ></asp:Label>
	<asp:Label ID='RightToFinish' runat=server Text=<%#Eval("RightToFinish") %> Visible=false ></asp:Label>
	<asp:Label ID='MailAlert' runat=server Text=<%#Eval("MailAlert") %> Visible=false ></asp:Label>
	<asp:Label ID='IsEnd' runat=server Text=<%#Eval("IsEnd") %> Visible=false ></asp:Label>
	<asp:Label ID='IsHead' runat=server Text=<%#Eval("IsHead") %> Visible=false ></asp:Label>
	<asp:Label ID='IsUserFile' runat=server Text=<%#Eval("IsUserFile") %> Visible=false ></asp:Label>
	
	<asp:Label ID='isuseredit' runat=server Text=<%#Eval("IsUserEdit") %> Visible=false ></asp:Label>
	<asp:Label ID='stepid' runat=server Text=<%#Eval("id") %> Visible=false ></asp:Label>
	
	<input type=hidden name='userlist<%#Eval("id") %>' id='userlist<%#Eval("id") %>' value='<%# GetStepUsers(Eval("userlist"), Eval("namelist"), Eval("userlist_dep"), Eval("step_type")) %>' />
     &nbsp;&nbsp;第 <%# Container.ItemIndex + 1%> 步 <%# GetStepNotes(Eval("Step_Remark")) %>： <%#Eval("Step_Name")%>   <input type=text size=40 dataType="Require" msg="审批者不能为空" readonly name='namelist<%#Eval("id") %>' id='namelist<%#Eval("id") %>' value='<%# GetStepNames(Eval("userlist"), Eval("namelist"), Eval("userlist_dep"), Eval("step_type")) %>' />
     <span runat=server id=isedit visible=false>
     <input type=button value=审核人员 class="textbutton" onclick=ShowIframe(<%#Eval("id") %>) />
     </span>
     </div> 	
	</ItemTemplate></asp:Repeater>
	<br />
	</td>
</tr>
<tr>
	<th style="width:95px;">抄送呈报&nbsp;<a href="#" class="help">[?]</a></th>
	<td><span class="note">抄送人可以全过程查阅流程信息 (如不需要 可不填)</span>
	<input runat=server type=hidden id=userlist name=userlist value="" />
	<textarea runat=server id=namelist name=namelist readonly=readonly 
	rows=3 cols=70 ></textarea>
	<input type=button value=抄送人员 class="textbutton" onclick=ShowIframe1() />
	</td>
</tr>
<asp:Panel ID="Attachword" runat="server" Visible="false">
<tr runat=server id=tr1 >
	<th style="width:95px; font-weight:bold;">流程正文&nbsp;<a href="#" class="help">[?]</a></th>
	<td><input type=hidden runat=server id=filepath name=filepath />
	<span class="note"><strong>新手提示</strong>- 如对编辑器不熟 简便方法: 1、先在Word(或其他排版工具)中绘制好内容 2、然后复制粘贴至下方编辑器。</span>
		<textarea id="DocBody" style="width:735px;height:735px;visibility:hidden;" 
		runat="server" enableviewstate=false></textarea>
		<br>
	</td>
</tr>
<tr >
	<th style="width:95px;">审批附件&nbsp;<a href="#" class="help">[?]</a></th>
	<td>
	<span class="note">请在这里 上传您需要 审批传递的文件 </span>
		&nbsp;&nbsp;<span style="font-weight:bold;"><a href="javascript:fAddAttach();" id="aAddAttach">添加审批附件</a></span>
		<br />
		<div runat=server id="dvReadAttach" style="float:left;"></div>
	</td>
</tr>

</asp:Panel>

</table>  
<br />

  
<br />

<div style="text-align:center;">
<asp:Button runat=server id=save1 OnClick=Save_Btn OnClientClick="return SaveDoc()" CssClass="buttoms" Text=' 发起流程 ' />&nbsp;&nbsp; 
&nbsp;&nbsp; 
<input class="buttoms" type=button onclick='history.back();' value=' 返回上页 ' />
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