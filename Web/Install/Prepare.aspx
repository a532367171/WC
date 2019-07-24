<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Prepare.aspx.cs" Inherits="install_Prepare" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>懒人工作通管理软件 - 安装向导 - 环境检测及数据库版本选择</title>
    <link href="Images/install.css" rel="stylesheet" type="text/css" />
    <%--<script type="text/javascript" src="../js/validator.js"></script>--%>
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
                                            安装向导一：环境检测及数据库版本选择。
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 23px">
                                            <strong><asp:Literal runat="server" ID="lt">推荐使用：SqlServer2005（或以上版本）以获取最优性能</asp:Literal></strong>
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
                                                检测 .net 版本：
                                            </span>
                                        </td>
                                        <td>
                                            <input runat="server" readonly="readonly" name="nf" type="text" id="nf" style="width: 285px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="inputstyle" style="height: 23px">
                                            <span>
                                                数据库版本选择：
                                            </span>
                                        </td>
                                        <td>
                                           <select name="sf">
                                           <option value='2005'>SqlServer2005及以上版本 （性能优越，强烈推荐） </option>
                                           <option value='2000'>SqlServer2000 （中小规模，建议150用户以下使用）</option>
                                           </select> 
                                            
                                        </td>
                                    </tr>
                                </table>
                            </td>
	</tr><tr>
		<td align="center"><table cellspacing="5" cellpadding="5" border="0">
			<tr>
				<td align="right">
                    <%--<asp:Button runat="server" ID=bt Text='继续安装' CssClass="inp_L1" OnClick=Next_btn />--%>
				
				    <asp:Button ID="bt" runat="server" CssClass="inp_L1" Text="继续安装" OnClick="bt_Click1" />
				
				</td>
			</tr>
		</table></td>
	</tr>
</table>
                </div>
            </div>
        </div>
    
<div>    



    </form>
</body>
</html>
