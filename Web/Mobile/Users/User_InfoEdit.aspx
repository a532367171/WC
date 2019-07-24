<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_InfoEdit.aspx.cs" Inherits="Mobile_Users_User_InfoEdit" %>

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
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div id="topbar">
        <div id="title">
            个人资料编辑</div>
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
        <fieldset>
            <span class="graytitle">职务名称：</span>
            <ul class="pageitem">
                <li class="bigfield">
			<input runat=server size=30 maxlength=26
			 name="PositionName" type="text" id="PositionName" /> 
                </li>
            </ul>

            <span class="graytitle">性 别：</span>
            <ul class="pageitem">
                <li class="bigfield">
            <asp:DropDownList runat=server ID=Sex>
            <asp:ListItem Text='男' Value=0></asp:ListItem>
            <asp:ListItem Text='女' Value=1></asp:ListItem>
            </asp:DropDownList>
                </li>
            </ul>

            <span class="graytitle">出生日期：</span>
            <ul class="pageitem">
                <li class="bigfield">
<INPUT runat=server class="Wdate"   readonly onClick="WdatePicker()" 
id=Birthday name=Birthday type=text size=30>    
                </li>
            </ul>

            <span class="graytitle">腾讯QQ：</span>
            <ul class="pageitem">
                <li class="bigfield">
<INPUT runat=server
id=QQ name=QQ type=text size=30>   
                </li>
            </ul>

            <span class="graytitle">电子邮件：</span>
            <ul class="pageitem">
                <li class="bigfield">
<INPUT runat=server
id=Email name=Email type=text size=30>  
                </li>
            </ul>

            <span class="graytitle">移动电话：</span>
            <ul class="pageitem">
                <li class="bigfield">
<INPUT runat=server
id=Phone name=Phone type=text size=30>
                </li>
            </ul>

            <span class="graytitle">固定电话：</span>
            <ul class="pageitem">
                <li class="bigfield">
<INPUT runat=server
id=Tel name=Tel type=text size=30>    
                </li>
            </ul>

            <span class="graytitle">居住地址：</span>
            <ul class="pageitem">
                <li class="bigfield">
			<input runat=server size=30 maxlength=60
			 name="HomeAddress" type="text" id="HomeAddress" />
                </li>
            </ul>

            <span class="graytitle">入职日期：</span>
            <ul class="pageitem">
                <li class="bigfield">
<INPUT runat=server class="Wdate"   readonly onClick="WdatePicker()" 
id=JoinTime name=JoinTime size=30 type=text>    
                </li>
            </ul>

            <span class="graytitle">上传照片：</span>
            <ul class="pageitem">
                <li class="textbox">
                    <asp:FileUpload ID="Fup" runat="server" />  
                </li>
            </ul>

            <span class="graytitle">员工备注：</span>
            <ul class="pageitem">
                <li class="textbox">
                    <textarea runat=server name=Notes id=Notes rows=3 style='width:100%;'></textarea>
                </li>
            </ul>

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
