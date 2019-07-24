<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_Veiw.aspx.cs" Inherits="Mobile_Users_User_Veiw" %>

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
            查看个人资料</div>
        <div id="leftbutton">
            <a href="../Index.aspx" class="noeffect">主页</a>
        </div>
        <div id="rightnav">
            <a href="../LoginOut.aspx" class="noeffect" onclick="return confirm('您确实要安全退出吗？')">注销</a>
        </div>
    </div>

    <div id="tributton">
        <div class="links">
            <a href="../Menu.aspx">功能菜单</a><a href="../Users/User_OnLine.aspx">在线用户</a><a href="UserMenu.aspx">上级菜单</a></div>
    </div>

     <div id="content">
        <span class="graytitle">
            <span id="Label1">
            用户名/真实姓名： 
            <span runat=server ID=UUserName5></span> <span runat=server ID=URealName5></span>
            </span>
        </span>

        <ul class="pageitem">
            <li class="textbox">
            <span class="header">职能部门：<span runat=server ID=UDepName5 style=' color:#000;'></span></span>
            <span class="header">职务名称：<span runat=server ID=PositionName5 style=' color:#000'></span></span>
            <span class="header">上司领导：<span runat=server ID=DirectSupervisor5 style=' color:#000'></span></span>
            <span class="header">入职时间：<span runat=server ID=JoinTime5 style=' color:#000'></span></span>
            <span class="header">性别/年龄：<span runat=server ID=Sex5 style=' color:#000'></span><span runat=server ID=Birthday5 style=' color:#000'></span></span>

            <span class="header">移动电话：<span runat=server ID=Phone5 style=' color:#000'></span> </span>
            <span class="header">固定电话：<span runat=server ID=Tel5 style=' color:#000'></span></span>
            <span class="header">电子邮件：<span runat=server ID=Email5 style=' color:#000'></span></span>
            <span class="header">腾讯QQ：<span runat=server ID=QQ5 style=' color:#000'></span></span>
            <span class="header">居住地址：<span runat=server ID=HomeAddress5 style=' color:#000'></span></span>
            <span class="header">状态：<span runat=server ID=Status5 style=' color:#000'></span></span>
            </li>
        </ul>      
        
        <ul class="pageitem">
            <li class="textbox"><span class="header">档案文件：</span>
            <div style="font-weight:bold;"><%=fjs %></div>
            </li>
        </ul> 
        
        <ul class="pageitem">
            <li class="textbox">
            <span class="header">备注：</span>
                    <p><div runat=server ID=Notes5 style=' font-size:13pt'></div></p>
            </li>
        </ul>  
        
        <ul class="pageitem">
            <li class="textbox"><span class="header">个人图片：</span>
                <asp:Image runat="server" ImageUrl="~/Manage/images/touxiang.jpg" ID='PerPic' 
                Width='259px' Height='194px' style="border:solid 1px #999999" />
            </li>
        </ul>





    </div>

    </form>
</body>
</html>
