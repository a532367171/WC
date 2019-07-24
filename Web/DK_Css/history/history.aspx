
<%@ Page Language="C#" ContentType="text/html"%>
<%@ Import Namespace="System.Data" %>
<%@ Import NameSpace="System.Data.OleDb" %>
<script runat="server">
void mGetContent(string strMonth,string strDay){
string strDate=strMonth+"-"+strDay;
string strDb=Server.MapPath("db-access/history.mdb");//�����ֵ�λ�ã����Ҫ��ֹ���أ���.mdb��׺���������������޸�
//Response.Write(strDb);
string strAuth="PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA Source=";
OleDbConnection db=new OleDbConnection(strAuth+strDb);

//strKey=Regex.Replace(strKey,"[=\\s\"\'!,.����~@#��%����&*(){}`+����<>?/]","",RegexOptions.IgnoreCase).Trim();//��ֹSQLע��

string strSql="SELECT TOP 200 * FROM louhome WHERE dateandtime LIKE '%-"+strDate+"' order by DAY(dateandtime) ASC, MONTH(dateandtime) ASC,YEAR(dateandtime) ASC"; 


OleDbCommand cmd=new OleDbCommand(strSql,db);
try{
db.Open();

dl.DataSource=cmd.ExecuteReader();
dl.DataBind();


db.Close();

//cmd.Dispose();
//db.Dispose();

    
    
    
    
labCount.Text=dl.Items.Count.ToString();
if(dl.Items.Count==0)
labError.Text="û���ҵ��κ�������ݣ������������ٲ�ѯ��";
else labError.Text="";
}
catch(Exception ee){
labError.Text=ee.ToString();
}
finally
{
    if (cmd != null)
        cmd.Dispose();
    if (db != null)
        db.Dispose();
    
} 
    
    
    
    
    
}
string strGet(string strInput){
string strResult=strInput;
string strRex="\\s{2,}";
strResult=Regex.Replace(strResult,strRex,"<br>", RegexOptions.IgnoreCase);
strResult=strResult.Replace("��",@"""").Replace("��",@"""");
//strResult=strResult.Replace(tbKey.Text.Trim(),"<font style='background:yellow;color:red'>"+tbKey.Text.Trim()+"</font>");
return strResult;
}


void mSearch(object sender,EventArgs e){
mGetContent(ddlMonth.SelectedItem.Text.Replace("ȫ��","%"),ddlDay.SelectedItem.Text.Replace("ȫ��","%"));

}
void Page_Load(){
if(!Page.IsPostBack){

mGetContent(System.DateTime.Now.Month.ToString(),System.DateTime.Now.Day.ToString());

}
}
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8"/><title>��ʷ�ϵĽ���</title>
</head>
<body>
<form id="Form1" runat="server" style="width:90%; margin:0px auto;">
  <asp:Label ID="labError" runat="server" Font-Size="8pt" ForeColor="#999999"/>
  <br />
  �鿴�ض����� 
  <asp:DropDownList ID="ddlMonth" runat="server">
  <asp:ListItem>1</asp:ListItem>
  <asp:ListItem>2</asp:ListItem>
  <asp:ListItem>3</asp:ListItem>
  <asp:ListItem>4</asp:ListItem>
  <asp:ListItem>5</asp:ListItem>
  <asp:ListItem>6</asp:ListItem>
  <asp:ListItem>7</asp:ListItem>
  <asp:ListItem>8</asp:ListItem>
  <asp:ListItem>9</asp:ListItem>
  <asp:ListItem>10</asp:ListItem>
  <asp:ListItem>11</asp:ListItem>
  <asp:ListItem>12</asp:ListItem>
  <asp:ListItem>ȫ��</asp:ListItem>
  </asp:DropDownList>��
  <asp:DropDownList ID="ddlDay" runat="server">
  <asp:ListItem>1</asp:ListItem>
  <asp:ListItem>2</asp:ListItem>
  <asp:ListItem>3</asp:ListItem>
  <asp:ListItem>4</asp:ListItem>
  <asp:ListItem>5</asp:ListItem>
  <asp:ListItem>6</asp:ListItem>
  <asp:ListItem>7</asp:ListItem>
  <asp:ListItem>8</asp:ListItem>
  <asp:ListItem>9</asp:ListItem>
  <asp:ListItem>10</asp:ListItem>
  <asp:ListItem>11</asp:ListItem>
  <asp:ListItem>12</asp:ListItem>
  <asp:ListItem>13</asp:ListItem>
  <asp:ListItem>14</asp:ListItem>
  <asp:ListItem>15</asp:ListItem>
  <asp:ListItem>16</asp:ListItem>
  <asp:ListItem>17</asp:ListItem>
  <asp:ListItem>18</asp:ListItem>
  <asp:ListItem>19</asp:ListItem>
  <asp:ListItem>20</asp:ListItem>
  <asp:ListItem>21</asp:ListItem>
  <asp:ListItem>22</asp:ListItem>
  <asp:ListItem>23</asp:ListItem>
  <asp:ListItem>24</asp:ListItem>
  <asp:ListItem>25</asp:ListItem>
  <asp:ListItem>26</asp:ListItem>
  <asp:ListItem>27</asp:ListItem>
  <asp:ListItem>28</asp:ListItem>
  <asp:ListItem>29</asp:ListItem>
  <asp:ListItem>30</asp:ListItem>
  <asp:ListItem>31</asp:ListItem>
  <asp:ListItem>ȫ��</asp:ListItem>
  </asp:DropDownList>�� &nbsp;&nbsp;<asp:Button ID="btn" runat="server" OnClick="mSearch" Text=" �� �� "/>
  <br />
  <br style="height:8px"/>
  <div style="background:#75CBFF; color:#666666; width:47%; height:20px; padding-top:4px; float:left; text-align:left; vertical-align:middle">&nbsp;&nbsp; ��ʷ�ϵĽ���</div>
  <div style="background:#75CBFF; color:#666666; width:50%; height:20px; padding-top:4px; float:left; text-align:right">����
      <asp:Label ID="labCount" runat="server" Text="0" ForeColor="#FF0000"/>  
    ����ؽ��&nbsp;&nbsp;</div>
  <br style="height:8px"/>
  <br style="height:8px"/>
  <asp:DataList ID="dl" EnableViewState=false runat="server" Width="98%">
    <itemtemplate>
      <div style="background:#016392; color:#FFFFFF; width:80px; clear:both;"><i>&middot;��� <%#(Container.ItemIndex+1).ToString()%></i></div>
      <div style="width:99%; border:1px solid #016392;">
        <div style="background:#E2E3D7; font-weight:bold; padding:2px;">
          <asp:Label ID="labCity" runat="server" Text=<%#(DataBinder.Eval(Container.DataItem,"dateandtime","{0:D}").ToString()) %> />
        </div>
        <div style=" padding:10px;">
          <asp:Label ID="labContent1" runat="server" Text=<%#"<font style='font-weight:bold;'>"+DataBinder.Eval(Container.DataItem,"History_title").ToString()+"</font>"%>/><br />
		  <asp:Label id="labContent2" runat="server" Text=<%#"<font style='color:#0000ff;'>"+strGet(DataBinder.Eval(Container.DataItem,"History_content").ToString())+"</font>"%> />   <br style="height:4px"/> <br style="height:6px"/>
        </div>
      </div>
	
    </itemtemplate>
  </asp:DataList>
</form>
</body>
</html>
