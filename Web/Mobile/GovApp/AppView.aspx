<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppView.aspx.cs" Inherits="Mobile_GovApp_AppView" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>智能移动办公平台</title>
    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="index,follow" name="robots" />
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <link href="../Style/Mobile/pics/homescreen.gif" rel="apple-touch-icon" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" /> 
    <link href="../Style/Mobile/css/Style.css" rel="stylesheet" media="screen" type="text/css" />
    <link href="../Style/Mobile/css/developer-style.css" rel="stylesheet" type="text/css" />

    <link href="../Style/Mobile/pics/startup.png" rel="apple-touch-startup-image" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="topbar">
        <div id="title">
            公文签发审批</div>
        <div id="leftbutton">
            <a href="../Index.aspx" class="noeffect">主页</a>
        </div>
        <div id="rightnav">
            <a href="../LoginOut.aspx" class="noeffect" onclick="return confirm('您确实要安全退出吗？')">注销</a>
        </div>
    </div>

    <div id="tributton">
        <div class="links">
            <a href="../Menu.aspx">功能菜单</a><a href="../Users/User_OnLine.aspx">在线用户</a><a href="AppMenu.aspx">上级菜单</a></div>
    </div>

    <div id="content">
        <span class="graytitle">
            <span id="Label1">
            标题： 
            <span style='color:#ff0000' runat=server ID=Flow_Name1></span>
            </span>
        </span>

        <ul class="pageitem">
            <li class="textbox">
            <span class="header">签发状态：<span runat=server ID=status style=' color:#009900;'></span></span>
            <span class="header">拟稿人员：<span runat=server ID=creator style=' color:#000'></span></span>
            <span class="header">拟稿日期：<span runat=server ID=addtime style=' color:#000;'></span></span>
            <span class="header">当前环节：<span runat=server ID=currentstepname style=' color:#000'></span></span>
            <span class="header">当前审批者：<span runat=server ID=currentuserlist style=' color:#000;'></span></span>
            </li>
        </ul>   

        <ul class="pageitem">
            <li class="textbox">
            <span class="header">公文内容：</span>
                    <p>
                    <input type=hidden runat=server id=filepath name=filepath />
                    <div runat=server ID=DocBody style='overflow: auto; overflow-y:hidden;font-size:13pt'></div></p>
            </li>
        </ul> 

        <ul class="pageitem">
            <li class="textbox">
            <span class="header">公文说明：</span>
                    <div runat=server ID=bodys style='overflow: auto; overflow-y:hidden;font-size:13pt'></div>
            </li>
        </ul> 

            <span class="graytitle">相关附件：</span>
             <ul class="pageitem">
             
                <li class="textbox">
		<asp:Repeater runat=server ID=rpt><ItemTemplate>
        <span style='display:none'><input runat=server id=chk type="checkbox" disabled=disabled checked=checked value=<%#Eval("Tmp1") %> /></span>
		<%#Eval("Tmp2") %> &nbsp;<a href='/Manage/Utils/Download.aspx?destFileName=<%# Server.UrlEncode(Eval("Tmp3")+"") %>' ><img src='/img/mail_attachment.gif' />下载</a>
		<br><%#Eval("Tmp4") %>
		<br>
	    </ItemTemplate></asp:Repeater>
                </li>
            </ul>
        
        <ul class="pageitem">
            <li class="textbox">
            <span class="header">审批意见列表：</span>
                    <div style='overflow: auto; overflow-y:hidden;font-size:12pt'><%=yjs %></div>
            </li>
        </ul>
        
        <ul class="pageitem">
            <li class="textbox">
            <span class="header">归档日期：<span runat=server ID=vlidtime style=' color:#000'></span></span>
            <span class="header">公文密级：<span runat=server ID=secret style=' color:#000;'></span></span>
            <span class="header">发文字号：<span runat=server ID=DocNo style=' color:#000;'></span></span>
            <span class="header">公文分类：<span runat=server ID=ModelType style=' color:#000;'></span></span>
            </li>
        </ul>           

        <asp:Panel runat=server ID=display Visible=false>
        <span class="graytitle">审批操作：</span>
            <ul class="pageitem">
                <li class="textbox">
                    <textarea runat="server" name="FlowRemark" id="FlowRemark" placeholder="在这里输入审批意见" rows="2" style="width:100%;"></textarea>
                </li>
                <li class="button" style="text-align: center;">
                    <asp:Button ID="b1" runat="server" OnClientClick='javascript:return confirm("确实要批准吗?")' Text="我要批准" OnClick="VerifyStep_Btn" Enabled=false />
                </li>
            </ul>

        <ul class="pageitem">
            <li class="button" style="text-align: center;">
            <asp:Button ID="b2" runat="server" OnClientClick='javascript:return confirm("确实不同意审批吗？公文审核被打回上个环节")' Text="我不同意" OnClick="RefuseStep_Btn" Enabled=false />
            </li>
        </ul>  

        <ul class="pageitem">
            <li class="button" style="text-align: center;">
            <asp:Button ID="b3" runat="server" OnClientClick='javascript:return confirm("确实要强制签发吗")' Text="强制完成流程" OnClick="CompleteStep_Btn" Visible=false Enabled=false />
            </li>
        </ul>  
        </asp:Panel>
    </div>
    </form>
</body>
</html>


