<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Mobile_Menu" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>智能移动办公平台</title>
    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="index,follow" name="robots" />
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <link href="../Mobile/Style/Mobile/pics/homescreen.gif" rel="apple-touch-icon" />
    <meta content="minimum-scale=1.0, width=device-width, maximum-scale=0.6667, user-scalable=no"
        name="viewport" />

    <link href="../Mobile/Style/Mobile/css/Style.css" rel="stylesheet" media="screen" type="text/css" />

    <link href="../Mobile/Style/Mobile/pics/startup.png" rel="apple-touch-startup-image" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="topbar">
        <div id="title">
            智能移动办公平台</div>
        <div id="leftbutton">
            <a href="Index.aspx" class="noeffect">主页</a>
        </div>
        <div id="rightbutton">
            <a href="LoginOut.aspx" class="noeffect" onclick="return confirm('您确实要安全退出吗？')">注销</a>
        </div>
    </div>
    <div id="tributton">
        <div class="links">
            <a id="pressed" href="Menu.aspx">功能菜单</a><a href="Users/User_OnLine.aspx">在线用户</a><a href="Users/User_PwdEdit.aspx">修改密码</a></div>
    </div>
    <div id="content">
        <span class="graytitle">基本功能菜单</span>
        <ul class="pageitem">
            <li class="textbox"><span class="header">欢迎,<%=RealName %></span><p>
                >> 基本功能菜单</p>
            </li>

<li class="menu"><a href="Users/UserMenu.aspx" id="A0">
<img  src="Style/Mobile/thumbs/contacts.png"/>
<span  class="name">个人设置</span>
<span class="arrow"></span></a></li>

<li class="menu"><a href="AddrBook/Menu.aspx" id="A1">
<img  src="Style/Mobile/thumbs/telephone.png"/>
<span  class="name">单位通讯录</span>
<span class="arrow"></span></a></li>

<li class="menu"><a href="News/NewsMenu.aspx" id="A2">
<img  src="Style/Mobile/thumbs/basics.png"/>
<span  class="name">我的资讯</span>
<span class="arrow"></span></a></li>

<li class="menu"><a href="Mails/MailMenu.aspx" id="A4">
<img  src="Style/Mobile/thumbs/rmail.png"/>
<span  class="name">内部邮件</span>
<span class="arrow"></span></a></li>

<li class="menu"><a href="Flows/FlowMenu.aspx" id="A5">
<img  src="Style/Mobile/thumbs/stocks.png"/>
<span  class="name">工作流程</span>
<span class="arrow"></span></a></li>

<li class="menu"><a href="GovApp/AppMenu.aspx" id="A6">
<img  src="Style/Mobile/thumbs/video.png"/>
<span  class="name">公文批阅</span>
<span class="arrow"></span></a></li>

<li class="menu"><a href="GovRec/RecMenu.aspx" id="A7">
<img  src="Style/Mobile/thumbs/safari.png"/>
<span  class="name">公文签收</span>
<span class="arrow"></span></a></li>

<li class="menu"><a href="Tasks/TaskMenu.aspx" id="A3">
<img  src="Style/Mobile/thumbs/appstore.png"/>
<span  class="name">工作任务</span>
<span class="arrow"></span></a></li>

<li class="menu"><a href="Files/FileMenu.aspx" id="A8">
<img  src="Style/Mobile/thumbs/notepad.png"/>
<span  class="name">我的文档</span>
<span class="arrow"></span></a></li>

<li class="menu"><a href="WorkLog/WorkLogMenu.aspx" id="A9">
<img  src="Style/Mobile/thumbs/accessibility.png"/>
<span  class="name">工作汇报</span>
<span class="arrow"></span></a></li>
        </ul>
    </div>
    </form>
</body>
</html>
