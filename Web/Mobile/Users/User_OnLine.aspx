<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_OnLine.aspx.cs" Inherits="Mobile_Users_User_OnLine" %>

<%@ Register Src="~/Controls/Page.ascx" TagName="Page" TagPrefix="uc1" %>
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
    <link type="text/css" href="/DK_Css/page_css.css" rel="stylesheet" />
</head>
<body class="applist">

    <div id="topbar">
        <div id="title">
            在线用户</div>
        <div id="leftbutton">
            <a href="../Index.aspx" class="noeffect">主页</a>
        </div>
        <div id="rightnav">
            <a href="../LoginOut.aspx" onclick="return confirm('您确实要安全退出吗？')">注销</a>
        </div>
    </div>
    <div id="tributton">
        <div class="links">
            <a href="../Menu.aspx">功能菜单</a><a id="pressed" href="../Users/User_OnLine.aspx">在线用户</a><a href="UserMenu.aspx">上级菜单</a></div>
    </div>
    <div class="searchbox" style='display:none'>
        <form action=''>
        <fieldset>
            <input name="keyword" id="searchbox" placeholder="查找人员" type="text" />
        </fieldset>
        </form>
    </div>
<form id="form1" runat="server">
    <div id="content">
        <ul>
            <asp:Repeater runat=server ID=rpt_person EnableViewState=false><ItemTemplate>
            <li><a class="effect" href='User_Veiw.aspx?uid=<%#Eval("id") %>'>
            <span class="image" style="background-image: url('../Style/Mobile/thumbs/contacts.png')"></span>
                <span class="comment"><%#Eval("DepName")%></span> 
                <span class="name">
                <%# Convert.ToBoolean(Eval("IsOnline")) ? "<strong style='color:#006600; '>" + Eval("RealName") + " (活动) </strong>" : "<strong style='color:#999999;'>" + Eval("RealName") + " (离开) </strong>"%>
                </span> 
                <span class="stars4">
                <%# Convert.ToBoolean(Eval("IsOnline")) ? "<div style='color:#ff3300;'>" + WC.Tool.Utils.ConvertDate5(Eval("LastLoginTime")) + "</div>" : "<div style='color:#999999;'>" + WC.Tool.Utils.ConvertDate5(Eval("LastLoginTime")) + "</div>"%>
                </span>
                <span class="arrow"></span>
                <span class="price"></span></a> </li>
            </ItemTemplate>
            </asp:Repeater>

        </ul>
    </div>

<div id="footer">
<span style="float:left;" id=num runat=server></span><br><br>
<uc1:Page ID="Page1" runat="server" />
</div>
</form>
</body>
</html>

