<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Install.aspx.cs" Inherits="install_Install" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>懒人工作通管理软件 - 安装向导 - 数据库安装</title>
    <link href="Images/install.css" rel="stylesheet" type="text/css" />
    <%--    <script type="text/javascript" src="../js/validator.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    
       <div class="leftform">
            <div class="conLeftForm">
                <div class="alterform">
                    <ul>
                        <li class="installtitle">
                            基于最新WEB2.0开发(.Net3.5+SqlServer)
                        </li>
                        <li>
                            使您在同行业中提升管理/竞争力,遥遥领先,轻松超越对手!</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="rightform">
            <div class="conRightForm">
                <div class="dataForm">
                    
                    
                    <table cellspacing="0" cellpadding="0" border="0" id="wizardInstaller" style="width:100%;border-collapse:collapse;">
	<tr style="height:100%;">
		<td>
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="2">
                                            <div style="color: Red">
                                                <b>
                                                    <span id="wizardInstaller_lblErrMessage"></span>
                                                </b>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dataTitle" colspan="2" style="height: 23px">
                                            安装向导二：数据库连接信息设置
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 23px">
                                            <strong><asp:Literal runat=server ID=lt></asp:Literal></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="inputstyle" style="height: 23px">
                                            <span>
                                                数据库服务器地址：
                                            </span>
                                        </td>
                                        <td style="height: 23px">
                                            <input dataType="Require" msg="数据库服务器地址不能为空" name="addr" type="text" value="LINJIE-PC\SQLEXPRESSSB" id="addr" style="width: 200px" /></td>
                                    </tr>
                                    <tr>
                                        <td class="inputstyle" style="height: 23px">
                                            <span>
                                                空数据库名称：
                                            </span>
                                        </td>
                                        <td>
                                            <input dataType="Require" msg="数据库名称不能为空" name="name" type="text" id="name" style="width: 200px" value="kong" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="inputstyle" style="height: 23px">
                                            <span>
                                                数据库登录名：
                                            </span>
                                        </td>
                                        <td>
                                            <input dataType="Require" msg="数据库登录名不能为空" name="sa" type="text" id="sa" value='sa' style="width: 200px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="inputstyle" style="height: 23px">
                                            <span>
                                                数据库登录密码：
                                            </span>
                                        </td>
                                        <td>
                                            
                                            <input name="pwd" type="password" id="pwd" style="width: 200px" value="113356965" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
	</tr><tr>
		<td align="center"><table cellspacing="5" cellpadding="5" border="0">
			<tr>
				<td align="right">
<%--				<asp:Button runat=server ID=bt1 Text='完成安装' CssClass="inp_L1" OnClick=Complete_btn />--%>
                    <asp:Button ID="bt" runat="server" CssClass="inp_L1" Text="完成安装" OnClick="bt_Click" />
				</td>
			</tr>
		</table></td>
	</tr>
</table>
                </div>
            </div>
        </div>
    
<div></div>    

    </form>
</body>
</html>
