<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecView.aspx.cs" Inherits="Mobile_GovRec_RecView" %>


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
</head>
<body>
    <form id="form1" runat="server">
    <div id="topbar">
        <div id="title">
            公文查看签收</div>
        <div id="leftbutton">
            <a href="../Index.aspx" class="noeffect">主页</a>
        </div>
        <div id="rightnav">
            <a href="../LoginOut.aspx" class="noeffect" onclick="return confirm('您确实要安全退出吗？')">注销</a>
        </div>
    </div>

    <div id="tributton">
        <div class="links">
            <a href="../Menu.aspx">功能菜单</a><a href="../Users/User_OnLine.aspx">在线用户</a><a href="RecMenu.aspx">上级菜单</a></div>
    </div>

    <div id="content">
        <span class="graytitle">
            <span id="Label1">
            标题： 
            <span style='color:#ff0000' runat=server ID=NewsTitle></span>
            </span>
        </span>

        <ul class="pageitem">
            <li class="textbox">
            <span class="header">拟稿人员：<span runat=server ID=Creator style=' color:#000;'></span></span>
            <span class="header">拟稿时间：<span runat=server ID=addtime style=' color:#000'></span></span>
            <span class="header"><span runat=server ID=top style=' color:#000'></span></span>
            </li>
        </ul>   

        <ul class="pageitem">
            <li class="textbox">
            <span class="header">公文正文：</span>
                    <p><div runat=server ID=DocBody style='overflow: auto; overflow-y:hidden;font-size:13pt'></div></p>
            </li>
        </ul> 

        <ul class="pageitem">
            <li class="textbox">
            <div>
             <%=sm %>
            <%=fjs %>
            <%=gd %>           
            </div>
            </li>
        </ul> 

        <asp:Panel runat=server ID=pal Visible=false>
        <span class="graytitle">签收公文：</span>
            <ul class="pageitem">
                <li class="textbox">
                    <textarea runat="server" name="FeedBack" id="FeedBack" placeholder="签收可以反馈意见" rows="3" style="width:100%;"></textarea>
                </li>
                <li class="button" style="text-align: center;">
                    <asp:Button ID="BtnOk" runat="server" OnClientClick='javascript:return confirm("您确定签收吗?")' Text="我要签收" OnClick=Save_Btn />
                </li>
                    
            </ul>
         </asp:Panel>
    </div>
    </form>
</body>
</html>


