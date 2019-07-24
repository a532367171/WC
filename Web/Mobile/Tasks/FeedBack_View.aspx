<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeedBack_View.aspx.cs" Inherits="Mobile_Tasks_FeedBack_View" %>

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
    function pzs() {
        if (document.form1.pz.value == "") {
            alert("您还没有输入任何批注内容！");
            document.form1.pz.focus();
            return false;
        }
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="topbar">
        <div id="title">
            任务执行详情</div>
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
            <span style='color:#ff0000' runat=server ID=TaskName></span>
            </span>
        </span>

        <ul class="pageitem">
            <li class="textbox">
            <span class="header">执行人员：<span runat=server ID=TaskUser style=' color:#000;'></span></span>
            <span class="header">提交标题：<span runat=server ID=WorkTitle style=' color:#000'></span></span>
            <span class="header">提交时间：<span runat=server ID=AddTime style=' color:#000;'></span></span>
            </li>
        </ul>   

        <ul class="pageitem">
            <li class="textbox">
            <span class="header">提交内容：</span>
                    <p><div runat=server ID=Notes style='overflow: auto; overflow-y:hidden;font-size:13pt'></div></p>
            </li>
        </ul> 

        <ul class="pageitem">
            <li class="textbox"><span class="header">相关附件：</span>
            <div style="font-weight:bold;"><%=fjs %></div>
            </li>
        </ul>

        <ul class="pageitem">
            <li class="textbox">
            <span class="header">批注信息：</span>
                    <p><div runat=server ID=Instruction style='overflow: auto; overflow-y:hidden;font-size:13pt'></div></p>
            </li>
        </ul> 

        <asp:Panel runat=server ID=pizhu1 Visible=false>
        <span class="graytitle">添加批注：</span>
            <ul class="pageitem">
                <li class="textbox">
                    <textarea runat="server" name="pz" id="pz" placeholder="管理者批注的内容" rows="4" style="width:100%;"></textarea>
                </li>
                <li class="button" style="text-align: center;">
                    <asp:Button Visible=false ID="pizhu3" runat="server" OnClientClick='return pzs()' Text="添加批注" OnClick="Save_Btn" />
                </li>
            </ul>
            </asp:Panel>
    </div>
    </form>
</body>
</html>

