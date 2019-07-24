using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;

public partial class Manage_gov_gov_ModelManage : ModulePages
    {
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel ModelName;
        //protected HtmlInputText Flow_Name;
        //protected DropDownList Model_Type;
        //protected DropDownList ModelFileList;
        //protected HtmlTableRow tr;
        //protected HtmlInputHidden userlist_deps;
        //protected HtmlInputText namelist_deps;
        //protected HtmlTextArea FlowRemark;
        //protected Panel ModelStep;
        //protected HtmlGenericControl StepNo;
        //protected Label This_FolwName;
        //protected HtmlInputText Step_Name;
        //protected HtmlInputHidden userlist;
        //protected HtmlInputText namelist;
        //protected HtmlInputHidden userlist_dep;
        //protected HtmlInputText namelist_dep;
        //protected HtmlInputCheckBox IsUserEdit;
        //protected Panel display1;
        //protected HtmlInputCheckBox IsUserFile;
        //protected HtmlInputCheckBox RightToFinish;
        //protected Panel display2;
        //protected HtmlInputCheckBox MailAlert;
        //protected HtmlTextArea StepRemark;
        //protected Repeater rpt;
        //protected Button save1;
        //protected Button add1;
        //protected Button finish1;
        //protected Button cancer1;
        private int i = 1;
        private IList<Gov_Model_TypeInfo> li = new List<Gov_Model_TypeInfo>();
        protected string showobj = "-1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Show();
                if (!string.IsNullOrEmpty(base.Request.QueryString["fm"]))
                {
                    this.ViewState["fm"] = base.Request.QueryString["fm"];
                    this.ShowData(0);
                    this.BindRpt(base.Request.QueryString["fm"]);
                    this.save1.Enabled = true;
                    this.add1.Enabled = true;
                }
            }
        }
        protected void AddStep_Btn(object sender, EventArgs e)
        {
            if (this.ModelName.Visible)
            {
                this.ModelName.Visible = false;
                this.ModelStep.Visible = true;
            }
            this.save1.Enabled = true;
            this.add1.Enabled = false;
            int num = this.GetMaxIndex() + 1;
            this.ViewState["max count"] = num;
            this.ViewState["current count"] = num;
            this.StepNo.InnerText = "第 " + num + " 步骤";
            this.ClearStepViewData();
            this.BindRpt(string.Concat(this.ViewState["fm"]));
            this.ViewState["isadd"] = 0;
        }
        protected void SaveStep_Btn(object sender, EventArgs e)
        {
            string cmdText = "update Gov_Model set IsComplete=0 where id=" + this.ViewState["fm"];
            MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
            if (this.ModelName.Visible)
            {
                this.ModelName.Visible = true;
                this.ModelStep.Visible = false;
                this.SaveModelFlow();
            }
            else
            {
                this.SaveSetpFlow();
            }
            this.save1.Enabled = true;
            this.add1.Enabled = true;
            this.BindRpt(string.Concat(this.ViewState["fm"]));
        }
        protected void Finish_Btn(object sender, EventArgs e)
        {
            if (string.Concat(this.ViewState["fm"]) != "0" && this.ViewState["fm"] != null)
            {
                string str = "update Gov_modelstep set isend=0,ishead=0 where Flow_ModelID=" + this.ViewState["fm"] + ";";
                string str2 = "update Gov_Model set iscomplete=1 where id=" + this.ViewState["fm"] + ";";
                string str3 = string.Concat(new object[]
				{
					"update Gov_ModelStep set isend=1 where Flow_ModelID=",
					this.ViewState["fm"],
					" and id = (select max(id) from Gov_ModelStep where Flow_ModelID=",
					this.ViewState["fm"],
					");"
				});
                string str4 = string.Concat(new object[]
				{
					"update Gov_ModelStep set ishead=1 where Flow_ModelID=",
					this.ViewState["fm"],
					" and id = (select min(id) from Gov_ModelStep where Flow_ModelID=",
					this.ViewState["fm"],
					");"
				});
                MsSqlOperate.ExecuteNonQuery(CommandType.Text, str + str2 + str3 + str4, new SqlParameter[0]);
                string str5 = HttpContext.Current.Server.HtmlEncode("您好!公文模型设计完成!");
                base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../Manage/gov/Gov_ModelList.aspx&tip=" + str5);
            }
        }
        protected void Cancer_Btn(object sender, EventArgs e)
        {
            if (string.Concat(this.ViewState["fm"]) != "0" && this.ViewState["fm"] != null)
            {
                string cmdText = "delete from Gov_Model where id=" + this.ViewState["fm"];
                string cmdText2 = "delete from Gov_ModelStep where Flow_ModelID=" + this.ViewState["fm"];
                MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
                MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText2, new SqlParameter[0]);
            }
            base.Response.Redirect("Gov_ModelList.aspx");
        }
        protected void Rpt_Edit(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;
            string commandArgument = linkButton.CommandArgument;
            int num = 0;
            if (commandArgument.Contains("flow"))
            {
                this.ShowData(num);
            }
            if (commandArgument.Contains("step"))
            {
                RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
                Label label = repeaterItem.FindControl("lab") as Label;
                Label label2 = repeaterItem.FindControl("labid") as Label;
                Label label3 = repeaterItem.FindControl("showdiv") as Label;
                this.ViewState["step"] = label2.Text;
                this.showobj = label3.Text;
                this.StepNo.InnerText = "第 " + label.Text + " 步骤";
                num = Convert.ToInt32(commandArgument.Split(new char[]
				{
					'p'
				})[1]);
                this.ShowData(num);
            }
            this.ViewState["current count"] = num;
            this.BindRpt(string.Concat(this.ViewState["fm"]));
            this.save1.Enabled = true;
            this.add1.Enabled = true;
        }
        protected void Rpt_Drop(object sender, EventArgs e)
        {
            ImageButton imageButton = sender as ImageButton;
            string commandArgument = imageButton.CommandArgument;
            if (commandArgument.Contains("step"))
            {
                Label label = imageButton.Parent.FindControl("labid") as Label;
                Gov_ModelStep.Init().Delete(Convert.ToInt32(label.Text));
            }
            this.ShowData(0);
            this.BindRpt(string.Concat(this.ViewState["fm"]));
            this.ViewState["max count"] = this.GetMaxIndex();
        }
        private void Show()
        {
            if (this.ModelName.Visible)
            {
                IList all = Gov_ModelFile.Init().GetAll(null, null);
                this.ModelFileList.Items.Add(new ListItem("请从以下 公文模板表单库中 选择一项 (请 酌情选择) ", "0"));
                foreach (object current in all)
                {
                    Gov_ModelFileInfo gov_ModelFileInfo = current as Gov_ModelFileInfo;
                    this.ModelFileList.Items.Add(new ListItem(gov_ModelFileInfo.FormTitle, string.Concat(gov_ModelFileInfo.id)));
                }
                this.GetFirtNode();
                this.Model_Type.Items.Add(new ListItem("不属于任何分类", "0"));
                int i = 0;
                int count = this.li.Count;
                while (i < count)
                {
                    Gov_Model_TypeInfo gov_Model_TypeInfo = this.li[i];
                    this.Model_Type.Items.Add(new ListItem(gov_Model_TypeInfo.Sh, string.Concat(gov_Model_TypeInfo.id)));
                    i++;
                }
                this.ViewState["max count"] = 0;
                this.ViewState["current count"] = 0;
                this.ViewState["isadd"] = 0;
                this.ViewState["fm"] = 0;
            }
        }
        private void SaveModelFlow()
        {
            int num = Convert.ToInt32(this.ViewState["isadd"]);
            if (num == 0)
            {
                Gov_ModelInfo gov_ModelInfo = new Gov_ModelInfo();
                gov_ModelInfo.AddTime = DateTime.Now;
                gov_ModelInfo.CreatorDepName = this.DepName;
                gov_ModelInfo.CreatorID = Convert.ToInt32(this.Uid);
                gov_ModelInfo.CreatorRealName = this.RealName;
                gov_ModelInfo.Flow_Name = this.Flow_Name.Value;
                gov_ModelInfo.ModelFileID = this.ModelFileList.SelectedValue;
                gov_ModelInfo.Remark = this.FlowRemark.Value;
                gov_ModelInfo.ShareDeps = this.userlist_deps.Value;
                gov_ModelInfo.namelist = this.namelist_deps.Value;
                gov_ModelInfo.ComID = Convert.ToInt32(this.Model_Type.SelectedValue);
                Gov_Model.Init().Add(gov_ModelInfo);
                this.ViewState["fm"] = gov_ModelInfo.id;
            }
            else
            {
                Gov_ModelInfo gov_ModelInfo = Gov_Model.Init().GetById(Convert.ToInt32(this.ViewState["fm"]));
                gov_ModelInfo.CreatorDepName = this.DepName;
                gov_ModelInfo.CreatorID = Convert.ToInt32(this.Uid);
                gov_ModelInfo.CreatorRealName = this.RealName;
                gov_ModelInfo.Flow_Name = this.Flow_Name.Value;
                gov_ModelInfo.ModelFileID = this.ModelFileList.SelectedValue;
                gov_ModelInfo.Remark = this.FlowRemark.Value;
                gov_ModelInfo.ShareDeps = this.userlist_deps.Value;
                gov_ModelInfo.namelist = this.namelist_deps.Value;
                gov_ModelInfo.ComID = Convert.ToInt32(this.Model_Type.SelectedValue);
                Gov_Model.Init().Update(gov_ModelInfo);
                this.ViewState["fm"] = gov_ModelInfo.id;
            }
        }
        private void SaveSetpFlow()
        {
            int num = Convert.ToInt32(this.ViewState["isadd"]);
            int step_Orders = Convert.ToInt32(this.ViewState["current count"]);
            if (num == 0)
            {
                Gov_ModelStepInfo gov_ModelStepInfo = new Gov_ModelStepInfo();
                gov_ModelStepInfo.Flow_ModelID = Convert.ToInt32(this.ViewState["fm"]);
                gov_ModelStepInfo.Step_Remark = this.StepRemark.Value;
                gov_ModelStepInfo.Step_Name = this.Step_Name.Value;
                gov_ModelStepInfo.Step_Type = Convert.ToInt32(base.Request.Form["step_type"]);
                gov_ModelStepInfo.UserList = this.userlist.Value;
                gov_ModelStepInfo.NameList = this.namelist.Value;
                gov_ModelStepInfo.NameList_dep = this.namelist_dep.Value;
                gov_ModelStepInfo.UserList_dep = this.userlist_dep.Value;
                gov_ModelStepInfo.IsUserEdit = Convert.ToInt32(this.IsUserEdit.Checked);
                gov_ModelStepInfo.IsUserFile = Convert.ToInt32(this.IsUserFile.Checked);
                gov_ModelStepInfo.MailAlert = Convert.ToInt32(this.MailAlert.Checked);
                gov_ModelStepInfo.RightToFinish = Convert.ToInt32(this.RightToFinish.Checked);
                gov_ModelStepInfo.Step_Orders = step_Orders;
                Gov_ModelStep.Init().Add(gov_ModelStepInfo);
            }
            else
            {
                Gov_ModelStepInfo gov_ModelStepInfo = Gov_ModelStep.Init().GetById(Convert.ToInt32(this.ViewState["step"]));
                gov_ModelStepInfo.Step_Remark = this.StepRemark.Value;
                gov_ModelStepInfo.Step_Name = this.Step_Name.Value;
                gov_ModelStepInfo.Step_Type = Convert.ToInt32(base.Request.Form["step_type"]);
                gov_ModelStepInfo.UserList = this.userlist.Value;
                gov_ModelStepInfo.NameList = this.namelist.Value;
                gov_ModelStepInfo.NameList_dep = this.namelist_dep.Value;
                gov_ModelStepInfo.UserList_dep = this.userlist_dep.Value;
                gov_ModelStepInfo.IsUserEdit = Convert.ToInt32(this.IsUserEdit.Checked);
                gov_ModelStepInfo.IsUserFile = Convert.ToInt32(this.IsUserFile.Checked);
                gov_ModelStepInfo.MailAlert = Convert.ToInt32(this.MailAlert.Checked);
                gov_ModelStepInfo.RightToFinish = Convert.ToInt32(this.RightToFinish.Checked);
                gov_ModelStepInfo.Step_Orders = step_Orders;
                Gov_ModelStep.Init().Update(gov_ModelStepInfo);
            }
        }
        private void ShowData(int step)
        {
            Gov_ModelInfo byId = Gov_Model.Init().GetById(Convert.ToInt32(this.ViewState["fm"]));
            if (step > 0)
            {
                this.ModelName.Visible = false;
                this.ModelStep.Visible = true;
                Gov_ModelStepInfo byId2 = Gov_ModelStep.Init().GetById(Convert.ToInt32(this.ViewState["step"]));
                this.Step_Name.Value = byId2.Step_Name;
                this.This_FolwName.Text = byId.Flow_Name;
                this.userlist.Value = byId2.UserList;
                this.namelist.Value = byId2.NameList;
                this.userlist_dep.Value = byId2.UserList_dep;
                this.namelist_dep.Value = byId2.NameList_dep;
                this.IsUserEdit.Checked = Convert.ToBoolean(byId2.IsUserEdit);
                this.IsUserFile.Checked = Convert.ToBoolean(byId2.IsUserFile);
                this.RightToFinish.Checked = Convert.ToBoolean(byId2.RightToFinish);
                this.MailAlert.Checked = Convert.ToBoolean(byId2.MailAlert);
                this.StepRemark.Value = byId2.Step_Remark;
            }
            else
            {
                this.ModelName.Visible = true;
                this.ModelStep.Visible = false;
                this.Flow_Name.Value = byId.Flow_Name;
                this.ModelFileList.SelectedValue = byId.ModelFileID;
                this.FlowRemark.Value = byId.Remark;
                this.userlist_deps.Value = byId.ShareDeps;
                this.namelist_deps.Value = byId.namelist;
                this.Model_Type.SelectedValue = string.Concat(byId.ComID);
            }
            this.ViewState["isadd"] = 1;
        }
        private void BindRpt(string fmid)
        {
            Gov_ModelInfo byId = Gov_Model.Init().GetById(Convert.ToInt32(this.ViewState["fm"]));
            this.This_FolwName.Text = byId.Flow_Name;
            IList all = Gov_ModelStep.Init().GetAll("Flow_ModelID=" + this.ViewState["fm"], "order by id asc");
            List<TmpInfo> list = new List<TmpInfo>();
            list.Add(new TmpInfo
            {
                Tmp1 = "<strong>公文模型流程基本信息:</strong> &nbsp;&nbsp; " + byId.Flow_Name,
                Tmp2 = "flow",
                Tmp3 = "0"
            });
            for (int i = 0; i < all.Count; i++)
            {
                Gov_ModelStepInfo gov_ModelStepInfo = all[i] as Gov_ModelStepInfo;
                TmpInfo tmpInfo = new TmpInfo();
                int num = i + 1;
                tmpInfo.Tmp1 = string.Concat(new object[]
				{
					"<strong>第 ",
					num,
					" 步 : </strong> &nbsp;&nbsp; ",
					gov_ModelStepInfo.Step_Name
				});
                tmpInfo.Tmp2 = "step" + num;
                tmpInfo.Tmp3 = string.Concat(num);
                tmpInfo.Tmp4 = string.Concat(gov_ModelStepInfo.id);
                tmpInfo.Tmp5 = string.Concat(gov_ModelStepInfo.Step_Type);
                list.Add(tmpInfo);
            }
            this.rpt.DataSource = list;
            this.rpt.DataBind();
        }
        private int GetMaxIndex()
        {
            string where = "Flow_ModelID=" + this.ViewState["fm"];
            IList all = Gov_ModelStep.Init().GetAll(where, null);
            return all.Count;
        }
        private void ClearStepViewData()
        {
            if (this.ModelStep.Visible)
            {
                this.Step_Name.Value = "";
                this.userlist.Value = "";
                this.namelist.Value = "";
                this.userlist_dep.Value = "";
                this.namelist_dep.Value = "";
                this.IsUserEdit.Checked = true;
                this.RightToFinish.Checked = false;
                this.MailAlert.Checked = false;
                this.StepRemark.Value = "";
            }
        }
        private void GetFirtNode()
        {
            DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Gov_Model_Type", null);
            dataSet.Relations.Add("sort", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["ParentID"], false);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                if (dataRow["ParentID"].ToString() == "0")
                {
                    Gov_Model_TypeInfo gov_Model_TypeInfo = this.SetPram(dataRow);
                    gov_Model_TypeInfo.Ch = "";
                    gov_Model_TypeInfo.Sh = gov_Model_TypeInfo.TypeName;
                    this.li.Add(gov_Model_TypeInfo);
                    this.PopulateSubTree(dataRow, this.i);
                }
            }
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
                    if (Convert.ToInt32(childRows[num]["Orders"]) > Convert.ToInt32(childRows[j]["Orders"]))
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
                Gov_Model_TypeInfo gov_Model_TypeInfo = this.SetPram(dataRow);
                if (depth == 2)
                {
                    if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
                    {
                        gov_Model_TypeInfo.Ch = "\u3000└ ";
                    }
                    else
                    {
                        gov_Model_TypeInfo.Ch = "\u3000├ ";
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
                                gov_Model_TypeInfo.Ch = "\u3000│" + gov_Model_TypeInfo.Ch;
                            }
                            Gov_Model_TypeInfo expr_132 = gov_Model_TypeInfo;
                            expr_132.Ch += "\u3000└ ";
                        }
                        else
                        {
                            for (int l = 1; l < depth - 1; l++)
                            {
                                gov_Model_TypeInfo.Ch = "\u3000│" + gov_Model_TypeInfo.Ch;
                            }
                            Gov_Model_TypeInfo expr_177 = gov_Model_TypeInfo;
                            expr_177.Ch += "\u3000├ ";
                        }
                    }
                }
                gov_Model_TypeInfo.Sh = gov_Model_TypeInfo.Ch + gov_Model_TypeInfo.TypeName;
                this.li.Add(gov_Model_TypeInfo);
                this.PopulateSubTree(dataRow, depth);
            }
        }
        private Gov_Model_TypeInfo SetPram(DataRow dbRow)
        {
            return new Gov_Model_TypeInfo
            {
                id = Convert.ToInt32(dbRow["id"]),
                TypeName = Convert.ToString(dbRow["TypeName"]),
                ParentID = Convert.ToInt32(dbRow["ParentID"]),
                Orders = Convert.ToInt32(dbRow["Orders"])
            };
        }
    }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         