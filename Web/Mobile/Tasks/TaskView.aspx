<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaskView.aspx.cs" Inherits="Mobile_Tasks_TaskView" %>

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

        function check() {
            if (document.form1.Bodys.value == "") {
                alert("任务执行情况为空！");
                document.form1.Bodys.focus();
                return false;
            }
        }
    </script> 
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div id="topbar">
        <div id="title">
            工作任务详情</div>
        <div id="leftbutton">
            <a href="../Index.aspx" class="noeffect">主页</a>
        </div>
        <div id="rightnav">
            <a href="../LoginOut.aspx" class="noeffect" onclick="return confirm('您确实要安全退出吗？')">注销</a>
        </div>
    </div>

    <div id="tributton">
        <div class="links">
            <a href="../Menu.aspx">功能菜单</a><a href="../Users/User_OnLine.aspx">在线用户</a><a href="TaskMenu.aspx">上级菜单</a></div>
    </div>

    <div id="content">
        <span class="graytitle">
            <span id="Label1">
            标题： 
            <span style='color:#ff0000' runat=server ID=Subject></span>
            </span>
        </span>

        <ul class="pageitem">
            <li class="textbox">
            <span class="header">任务状态：<span runat=server ID=status style=' color:#009900;'></span></span>
            <span class="header">创建人员：<span runat=server ID=Creator style=' color:#000'></span></span>
            <span class="header">创建时间：<span runat=server ID=AddTime style=' color:#000;'></span></span>
            <span class="header">更新时间：<span runat=server ID=UpdateTime style=' color:#000'></span></span>
            <span class="header">管理人员：<span runat=server ID=ManageNameList style=' color:#000;'></span></span>
            </li>
        </ul>   

        <ul class="pageitem">
            <li class="textbox">
            <span class="header">任务内容：</span>
                    <p><div runat=server ID=bodys1 style='overflow: auto; overflow-y:hidden;font-size:13pt'></div></p>
                    <div style="font-weight:bold;"><%=fjs %></div>
            </li>
        </ul> 

        <ul>
            <asp:Repeater runat=server ID=rpt><ItemTemplate>
            <li>
                    <asp:LinkButton runat=server ID=lb CommandArgument=<%# Eval("WorkTag") + "," + Eval("UserID")%> Visible=false class="show">.</asp:LinkButton>

                    <span><%#Eval("RealName")%> (<%# GetWorkTag(Eval("WorkTag"))%>)</span> 
                <span>
                    <asp:Panel runat=server ID=pa Visible=false>
                            <asp:Panel runat=server ID=pa1 Visible=false>
                            </asp:Panel>
                    </asp:Panel>
                    <asp:Label runat=server ID=lab1 Visible=false></asp:Label>
                </span> <br>
                <span>
                    <%#Eval("AddTime")%>
                    <a class="effect" href='FeedBack_View.aspx?tuid=<%#Eval("id") %>'>查看详情</a>
                </span>
            </li>
            </ItemTemplate>
            </asp:Repeater>

        </ul>

        <ul class="pageitem">
            <li class="textbox">
            <span class="header">任务分类：<span runat=server ID=TypeName style=' color:#000;'></span></span>
            <span class="header">任务级别：<span runat=server ID=Important style=' color:#000;'></span></span>
            <span class="header">期待完成时间：<span runat=server ID=ExpectTime style=' color:#000;'></span></span>
            </li>
        </ul>  

        <asp:Panel runat=server ID=display Visible=false>
        <asp:Panel runat=server ID=exetable Visible=false>
        <span class="graytitle">反馈执行情况：</span>
            <ul class="pageitem">
                <li class="textbox">
                    <textarea runat="server" name="Bodys" id="Bodys" placeholder="任务执行情况" rows="3" style="width:100%;"></textarea>
                </li>
            </ul>
            <ul class="pageitem">
                <li class="textbox">
		        <span style="font-weight:bold;"><a href="javascript:fAddAttach();" id="aAddAttach">添加附件</a></span>
                </li>
                <li class="textbox">
                <div runat=server id="dvReadAttach" style="float:left;"></div>
                </li>
            </ul>
        </asp:Panel>

        <ul class="pageitem">
            <li class="button" style="text-align: center;">
            <asp:Button ID="s1" runat="server" OnClientClick='javascript:return check()' Text="提交执行情况" OnClick="Submit_Btn" Visible=false />
            </li>
        </ul> 

        <ul class="pageitem">
            <li class="button" style="text-align: center;">
            <asp:Button ID="s2" runat="server" OnClientClick='javascript:return confirm("确定接受任务吗")' Text="我要接收任务" OnClick="Accept_Btn" Visible=false />
            </li>
        </ul>

        <ul class="pageitem">
            <li class="button" style="text-align: center;">
            <asp:Button ID="b3" runat="server" OnClientClick='javascript:return confirm("确实完成整个任务吗")' Text="完成任务" OnClick="Complete_Btn" Visible=false />
            </li>
        </ul> 
        </asp:Panel>
    </div>
    </form>
</body>
</html>
