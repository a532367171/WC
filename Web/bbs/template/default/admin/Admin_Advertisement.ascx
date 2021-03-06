﻿<%@ Import Namespace="DXBBS.Components"%>
<%@ Control Language="C#" AutoEventWireup="true"%>
<%@ Register TagPrefix="DXBBS" Namespace="DXBBS.Controls" Assembly="DXBBS.Controls" %>
<script language="javascript">
//全选全不选
function SelectAll(obj)
{
    var aspnetForm=document.getElementById("aspnetForm");
    if (aspnetForm.SelectID != null)
    {
        if (aspnetForm.SelectID.length == null)
        {
            aspnetForm.SelectID.checked=obj.checked;
        }
        else
        {
            for (i=0;i<aspnetForm.SelectID.length;i++)
            {
                if(aspnetForm.SelectID[i].checked!=obj.checked)
                {
                    aspnetForm.SelectID[i].checked=obj.checked;
                }
            }
        }
    }
}
//检查操作
function CheckSelect()
{
    var aspnetForm=document.getElementById("aspnetForm");
    var checked=false;
    if (aspnetForm.SelectID != null)
    {
        if (aspnetForm.SelectID.length == null)
        {
            if (aspnetForm.SelectID.checked == true)
            {
                checked=true;
            }
        }
        else
        {
            for (i=0;i<aspnetForm.SelectID.length;i++)
            {
                if(aspnetForm.SelectID[i].checked == true)
                {
                    checked=true;
                }
            }
        }
    }
    if (checked == false)
    {
        alert("请选择要操作的记录");
        return false;
    }
    else
    {
        if (!confirm("注意：请问确定要操作吗"))
        {
            return false;
        }
    }
    return true;
}
</script>
<div class="BodyBlock PTB5">
	<div class="Block Hidden">
		<div class="Title H22 LH22 TC">
			综合管理-->帖间广告管理
		</div>
		<ul class="Header TC">
			<li class="Left" style="width:50px">ID</li>
			<li class="Right" style="width:30px">选择</li>
			<li class="Right" style="width:100px">移动</li>
			<li class="Right" style="width:120px">添加时间</li>
			<li>公告标题</li>
		</ul>
		<asp:Repeater ID="AdvertisementList" runat="server">
		<ItemTemplate>
		<ul class="TC Hidden">
			<li class="Left" style="width:50px"><%# Eval("ID") %></li>
			<li class="Right" style="width:30px"><input type="checkbox" name="SelectID" value="<%# Eval("ID") %>" /></li>
			<li class="Right" style="width:100px"><input type="button" class="Button" value="上移" onclick="window.location.href='?Action=Up&ID=<%# Eval("ID") %>&Orders=<%# Eval("Orders") %>'" /><input type="button" class="Button" value="下移" onclick="window.location.href='?Action=Down&ID=<%# Eval("ID") %>&Orders=<%# Eval("Orders") %>'" /></li>
			<li class="Right" style="width:120px"><%# Eval("AddTime") %></li>
			<li class="TL"><a href='Admin_AdvertisementAdd.aspx?ID=<%# Eval("ID") %>'><%# Eval("Title") %></a></li>
		</ul>
		</ItemTemplate>
		</asp:Repeater>
		<div class="Footer PTB5 TC">
			<input type="button" class="Button" value="添加广告" onclick="window.location.href='Admin_AdvertisementAdd.aspx'" />&nbsp;<asp:Button CssClass="Button" ID="DeleteButton" Text="确定删除" OnClientClick="return CheckSelect()" runat="server" />&nbsp;<input type="checkbox" name="All" onclick="SelectAll(this)" />全选/全不选
		</div>
	</div>
    <div class="BlankBlock Hidden">
        <DXBBS:ForumPager ID="CommonPager" runat="server" />
    </div>
</div>