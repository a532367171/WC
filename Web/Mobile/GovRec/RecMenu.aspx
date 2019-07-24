<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecMenu.aspx.cs" Inherits="Mobile_GovRec_RecMenu" %>


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

    <link href="../Style/Mobile/pics/startup.png" rel="apple-touch-startup-image" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="topbar">
        <div id="title">
            智能移动办公平台</div>
        <div id="leftbutton">
            <a href="../Index.aspx" class="noeffect">主页</a>
        </div>
        <div id="rightbutton">
            <a href="../LoginOut.aspx" class="noeffect" onclick="return confirm('您确实要安全退出吗？')">注销</a>
        </div>
    </div>
    <div id="tributton">
        <div class="links">
            <a href="../Menu.aspx">功能菜单</a><a href="../Users/User_OnLine.aspx">在线用户</a><a href="../Menu.aspx">上级菜单</a></div>
    </div>
    <div id="content">
        <span class="graytitle">基本菜单</span>
        <ul class="pageitem">
            <li class="textbox"><span class="header">欢迎,<%=RealName %></span><p>
                公文签收 >> 功能菜单</p>
            </li>

<li class="menu"><a href="RecList.aspx?action=verify" id="A0">
<img  src="../Style/Mobile/thumbs/safari.png"/>
<span  class="name">公文签收( <span id=wdpy runat=server style="color:#ff0000;">0</span> )</span>
<span class="arrow"></span></a></li>

<li class="menu"><a href="RecList.aspx?action=verified" id="A1">
<img  src="../Style/Mobile/thumbs/appstore.png"/>
<span  class="name">已签收公文( <span id=yjpy runat=server>0</span> )</span>
<span class="arrow"></span></a></li>

<li class="menu"><a href="RecList.aspx?action=archived" id="A2">
<img  src="../Style/Mobile/thumbs/start.png"/>
<span  class="name">已归档公文( <span id=wdsq runat=server>0</span> )</span>
<span class="arrow"></span></a></li>


        </ul>
    </div>
    </form>
</body>
</html>
