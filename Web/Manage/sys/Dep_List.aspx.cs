using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.DK;

public partial class Manage_sys_Dep_List : ModulePages
{
    private int i = 1;
    private List<Sys_DepInfo> li = new List<Sys_DepInfo>();
    //protected HtmlHead Head1;
    //protected HtmlForm form1;
    //protected Repeater rpt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.Show();
        }
    }
    private void Show()
    {
        this.GetFirtNode();
        this.rpt.DataSource = this.li;
        this.rpt.DataBind();
    }
    protected void Del_Btn(object sender, EventArgs e)
    {
        LinkButton linkButton = sender as LinkButton;
        string commandArgument = linkButton.CommandArgument;
        Sys_DepInfo byId = Sys_Dep.Init().GetById(Convert.ToInt32(commandArgument));
        if (byId.ParentID != 0)
        {
            this.DeleteDep(byId);
            this.Show();
        }
        else
        {
            base.Response.Write("<script>alert('根节点不可删除!');window.location='Dep_List.aspx';</script>");
        }
    }
    private void DeleteDep(Sys_DepInfo sdi)
    {
        IList all = Sys_Dep.Init().GetAll("ParentID=" + sdi.id, null);
        for (int i = 0; i < all.Count; i++)
        {
            Sys_DepInfo sdi2 = all[i] as Sys_DepInfo;
            this.DeleteDep(sdi2);
        }
        this.DeleteUser(sdi.id);
        this.DeleteModule(sdi.id);
        Sys_Dep.Init().Delete(sdi.id);
    }
    private void DeleteUser(int did)
    {
        IList all = Sys_User.Init().GetAll("DepID=" + did, null);
        for (int i = 0; i < all.Count; i++)
        {
            Sys_UserInfo sys_UserInfo = all[i] as Sys_UserInfo;
           // Help.DeleteIMUser(sys_UserInfo.id);
            Sys_User.Init().Delete(sys_UserInfo.id);
        }
    }
    private void DeleteModule(int did)
    {
        string cmdText = "delete from Sys_Dep_Module where DepID=" + did;
        MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, null);
    }
    private void GetFirtNode()
    {
        DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Sys_Dep order by orders asc", null);
        dataSet.Relations.Add("sort", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["ParentID"], false);
        foreach (DataRow dataRow in dataSet.Tables[0].Rows)
        {
            if (dataRow["ParentID"].ToString() == "0")
            {
                Sys_DepInfo sys_DepInfo = this.SetPram(dataRow);
                sys_DepInfo.Ch = "<img src=../images/ico_system.gif />";
                this.li.Add(sys_DepInfo);
                this.PopulateSubTree(dataRow, this.i);
            }
        }
        dataSet.Dispose();
    }
    private void PopulateSubTree(DataRow dbRow, int depth)
    {
        depth++;
        DataRow[] childRows = dbRow.GetChildRows("sort");
        for (int i = 0; i < childRows.Length - 1; i++)
        {
            int num = i;
            for (int j = i + 1; j < childRows.Length; j++)
            {
                if (Convert.ToInt32(childRows[num]["orders"]) > Convert.ToInt32(childRows[j]["orders"]))
                {
                    num = j;
                }
            }
            if (num != i)
            {
                object obj = childRows[i];
                childRows[i] = childRows[num];
                childRows[num] = (DataRow)obj;
            }
        }
        DataRow[] array = childRows;
        for (int k = 0; k < array.Length; k++)
        {
            DataRow dataRow = array[k];
            Sys_DepInfo sys_DepInfo = this.SetPram(dataRow);
            string text;
            if (sys_DepInfo.IsPosition == 0)
            {
                text = "<img src=../images/ico_jingpin.gif />";
            }
            else
            {
                text = "<img src=../images/group.gif />";
            }
            if (depth == 2)
            {
                if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
                {
                    sys_DepInfo.Ch = "\u3000└ " + text;
                }
                else
                {
                    sys_DepInfo.Ch = "\u3000├ " + text;
                }
            }
            else
            {
                if (depth > 2)
                {
                    if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
                    {
                        for (int l = 1; l < depth - 1; l++)
                        {
                            sys_DepInfo.Ch = "\u3000│" + sys_DepInfo.Ch;
                        }
                        Sys_DepInfo expr_166 = sys_DepInfo;
                        expr_166.Ch = expr_166.Ch + "\u3000└ " + text;
                    }
                    else
                    {
                        for (int l = 1; l < depth - 1; l++)
                        {
                            sys_DepInfo.Ch = "\u3000│" + sys_DepInfo.Ch;
                        }
                        Sys_DepInfo expr_1AD = sys_DepInfo;
                        expr_1AD.Ch = expr_1AD.Ch + "\u3000├ " + text;
                    }
                }
            }
            this.li.Add(sys_DepInfo);
            this.PopulateSubTree(dataRow, depth);
        }
    }
    private Sys_DepInfo SetPram(DataRow dbRow)
    {
        return new Sys_DepInfo
        {
            id = Convert.ToInt32(dbRow["id"]),
            DepName = Convert.ToString(dbRow["DepName"]),
            ParentID = Convert.ToInt32(dbRow["ParentID"]),
            Orders = Convert.ToInt32(dbRow["Orders"]),
            IsPosition = Convert.ToInt32(dbRow["IsPosition"]),
            Phone = Convert.ToString(dbRow["Phone"])
        };
    }
    protected string getstr(object a, object b)
    {
        return Convert.ToString(a) + "<strong>" + Convert.ToString(b) + "</strong>";
    }
    protected string gettype(object a, object b)
    {
        string result;
        if (string.Concat(b) == "0")
        {
            result = "";
        }
        else
        {
            if (string.Concat(a) == "0")
            {
                result = "<span style='color:blue;'>职位</span>";
            }
            else
            {
                result = "部门";
            }
        }
        return result;
    }
}