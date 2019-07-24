<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddWorkLog.aspx.cs" Inherits="Mobile_WorkLog_AddWorkLog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>智能移动办公平台</title>
    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="index,follow" name="robots" />
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <link href="../Style/Mobile/pics/homescreen.gif" rel="apple-touch-icon" />
    <meta content="minimum-scale=1.0, width=device-width, maximum-scale=0.6667, user-scalable=no"
        name="viewport" />

    <link href="../Style/Mobile/css/Style.css" rel="stylesheet" media="screen" type="text/css" />
    <link href="../Style/Mobile/css/developer-style.css" rel="stylesheet" type="text/css" />

    <link href="../Style/Mobile/pics/startup.png" rel="apple-touch-startup-image" />
    <script type="text/javascript" src="/js/formV/datepicker/WdatePicker.js"></script> 
    <script type="text/javascript" src="/js/popup/popup.js"></script>
    <script type="text/javascript">
        var w = window.innerWidth * 0.95;
        function ShowIframe() {
            var users = document.getElementById("userlist");
            var pop = new Popup({ contentType: 1, scrollType: 'no', isReloadOnClose: false, width: w, height: 500 });
            pop.setContent("contentUrl", "/Mobile/Utils/SelectPeople_r.aspx");
            pop.setContent("title", "工作汇报 - 汇报领导选择");
            pop.build();
            pop.show();
        }

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
    </script> 
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div id="topbar">
        <div id="title">
            新增工作汇报</div>
        <div id="leftbutton">
            <a href="../Index.aspx" class="noeffect">主页</a>
        </div>
        <div id="rightnav">
            <a href="../LoginOut.aspx" class="noeffect" onclick="return confirm('您确实要安全退出吗？')">注销</a>
        </div>
    </div>
    <div id="tributton">
        <div class="links">
            <a href="../Menu.aspx">功能菜单</a><a href="../Users/User_OnLine.aspx">在线用户</a><a href="WorkLogMenu.aspx">上级菜单</a></div>
    </div>

    <div id="content">
        <fieldset>
            <span class="graytitle">* 汇报标题：</span>
            <ul class="pageitem">
                <li class="bigfield">
                    <input runat=server name="LogTitle" type="text" id="LogTitle" placeholder="汇报标题 (不能为空)" style="width:100%;" />
                </li>
            </ul>
            <span class="graytitle">* 汇报日期：</span>
            <ul class="pageitem">
                <li class="bigfield">
                    <input runat=server name="addTime" type="text" id="addTime" placeholder="汇报日期 (不能为空)" readonly=readonly onClick="WdatePicker()" style="width:100%;" />
                </li>
            </ul>
            <span class="graytitle">* 接收人： </span>
            <ul class="pageitem">
                <li class="textbox">
                    <input runat=server type=hidden id=userlist name=userlist value="" />
                    <textarea runat=server type=text id=namelist name=namelist readonly=readonly placeholder="接收人 (不能为空)" rows=3 style="width:100%;"></textarea>
                </li>
                <li class="button" style="text-align: center;">
                <input type=button id=bt8 name=bt8 onclick=ShowIframe() value=' 选择人员 ' /></li>
            </ul>

            <span class="graytitle">* 汇报内容：</span>
            <ul class="pageitem">
                <li class="textbox">
                    <textarea runat="server" name="Bodys" id="Bodys" placeholder="汇报内容 (不能为空)" rows="10" style="width:100%;"></textarea>
                </li>
            </ul>

            <span class="graytitle">添加附件：</span>
            <ul class="pageitem">
                <li class="textbox">
		        <span style="font-weight:bold;"><a href="javascript:fAddAttach();" id="aAddAttach">添加附件</a></span>
                </li>
                <li class="textbox">
                <div runat=server id="dvReadAttach" style="float:left;"></div>
                </li>
            </ul>

            <asp:Panel ID="Attachword" runat="server" Visible="false">
            <span class="graytitle">已添加附件：</span>
             <ul class="pageitem">
             
                <li class="textbox">
                <asp:Repeater runat=server ID=rpt><ItemTemplate>
                 <div style="text-align:left; float:left;">
		<input runat=server id=chk type="checkbox" checked=checked value=<%#Eval("Tmp1") %> />
		<%#Eval("Tmp2") %> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName=<%# Server.UrlEncode(Eval("Tmp3")+"") %>' ><img src='/img/mail_attachment.gif' />下载附件</a>   
        <br></ItemTemplate></asp:Repeater>
                </li>
            </ul>
            </asp:Panel>

            <ul class="pageitem">
                <li class="button" style="text-align: center;">
                    <asp:Button ID="bt5" runat="server" OnClientClick='javascript:return confirm("您确定吗?")' Text="确定保存" OnClick="Save_Btn" />
                </li>
            </ul>
        </fieldset>
    </div>
    </form>
</body>
</html>
