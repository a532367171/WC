<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Mobile_Index" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>智能移动办公平台</title>
    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="index,follow" name="robots" />
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <link href="Style/Mobile/pics/homescreen.gif" rel="apple-touch-icon" />
    <meta content="minimum-scale=1.0, width=device-width, maximum-scale=0.6667, user-scalable=no"
        name="viewport" />

    <link href="Style/Mobile/css/Style.css" rel="stylesheet" media="screen" type="text/css" />

    <link href="Style/Mobile/pics/startup.png" rel="apple-touch-startup-image" />
<style type="text/css">
a {color:#222;text-decoration:none;font-weight:bold;}
a:hover { color:#ff0000; text-decoration:underline;}
    </style>

    <script type="text/javascript">
        function IsPC() {
            if (/AppleWebKit.*mobile/i.test(navigator.userAgent) || (/MIDP|SymbianOS|NOKIA|SAMSUNG|LG|NEC|TCL|Alcatel|BIRD|DBTEL|Dopod|PHILIPS|HAIER|LENOVO|MOT-|Nokia|SonyEricsson|SIE-|Amoi|ZTE/.test(navigator.userAgent))) { }
                //PC端
            else {
                alert('您目前是PC端!系统将自动转向到PC版系统');
                //window.location.href = '/manage/default1.aspx';
            }
        }
    </script>
</head>
<body onload=IsPC()>
    <form id="form1" runat="server">
    <div id="topbar">
        <div id="title">
            智能移动办公平台</div>
        <div id="leftbutton">
            <a href="#" class="noeffect">主页</a>
        </div>
        <div id="rightbutton">
            <a href="LoginOut.aspx" class="noeffect" onclick="return confirm('您确实要安全退出吗？')">注销</a>
        </div>
    </div>
    <div id="tributton">
        <div class="links">
            <a id="pressed" href="Index.aspx">主页</a><a href="Users/User_OnLine.aspx">在线用户</a><a href="Users/User_PwdEdit.aspx">修改密码</a></div>
    </div>
    <div id="content">
        <span class="graytitle">基本菜单</span>
        <ul class="pageitem">
            <li class="textbox"><span class="header">欢迎您,<%=RealName %></span><p>
                欢迎来到智能移动办公平台(移动版)!</p>
            </li>
<li class="menu"><a href='Menu.aspx'><img  src="Style/Mobile/thumbs/wordpress.png"/><span  class="name">我的办公桌-功能菜单</span><span class="arrow"></span></a></li>
        </ul>
        <span class="graytitle">待办事项/统计数据</span>

        <ul class="pageitem">
            <li class="textbox"><span class="header">点击下方数字进入详细内容!</span></li>

<li class="textbox"><a href="News/NewsList.aspx" title='最近三个月有 <%=news_num %> 条资讯'> 我的资讯:(<span style='color:#ff0000'> <%=news_num %> </span>)</a>   </li>

<li class="textbox"><a href="Mails/MailList.aspx?fid=0" title='未读邮件(<%=mails_num1 %>) / 所有收件(<%=mails_num2 %>)'> 
内部邮件:( <span style='color:#ff0000'><%=mails_num1 %></span>/<%=mails_num2 %> )</a>
 &nbsp; <a href='Mails/SendMail.aspx'  title='点击撰写新邮件'>发新邮件</a></li>
<li class="textbox"><a href="Flows/FlowList.aspx?action=verify"  title='待我批阅的流程(<%=flows_num1 %>) / 我申请的流程(<%=flows_num2 %>)'> 
工作流程:( <span style='color:#ff0000'><%=flows_num1 %></span>/<%=flows_num2 %> )</a></li>
<li class="textbox"><a href="GovApp/AppList.aspx?action=verify" title='总计有 <%=shared_num %> 件需要我批阅的公文'>公文批阅:( <span style='color:#ff0000'><%=shared_num %></span> )</a>
 &nbsp; <a href='GovRec/RecList.aspx?action=verify'  title='总计有 <%=shared_num2 %> 件需要我签收的公文'> 
公文签收:( <span style='color:#ff0000'><%=shared_num2 %></span> )</a> </li>
<li class="textbox"><a href="Tasks/TaskList.aspx?type=all" title='需执行的任务(<%=exe_num %>) / 需管理的任务(<%=man_num %>)'> 
工作任务:( <%=exe_num %>/<font color='#ff0000'><%=man_num%></font> )</a></li>
<li class="textbox">
<a href="Files/FileList.aspx?action=mydoc"   title='总计有 <%=mydoc_num %>个文档'> 
我的文档:( <span style='color:#ff0000'><%=mydoc_num %></span> )</a>
 </li>
<li class="textbox">
<a href='WorkLog/WorkLogList.aspx?action=mydoc'>工作汇报:( <span style='color:#ff0000'><%=work_num1 %> </span>)</a>&nbsp; 
<a href='WorkLog/WorkLogList.aspx?action=shared'>他人汇报:( <span style='color:#ff0000'><%=work_num2 %> </span>)</a>&nbsp; 
</li>
        </ul>

        <div id="divResult">
        </div>
    </div>
    <div id="footer">
        </div>
    </form>
</body>
</html>

