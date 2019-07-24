using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;
using WC.DK;

public partial class Manage_sys_User_Manage : ModulePages
	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText UUserName;
        //protected HtmlInputPassword PassWord;
        //protected HtmlInputPassword PassWord2;
        //protected HtmlInputText URealName;
        //protected HtmlInputText PositionName;
        //protected DropDownList parentID;
        //protected DropDownList RoleID;
        //protected RadioButtonList Sex1;
        //protected HtmlInputText Birthday;
        //protected HtmlInputText Phone;
        //protected HtmlInputText Tel;
        //protected HtmlInputText Email;
        //protected HtmlInputText QQ;
        //protected HtmlInputText HomeAddress;
        //protected HtmlInputText JoinTime;
        //protected FileUpload Fup;
        //protected RadioButtonList Status1;
        //protected HtmlInputCheckBox IsLock;
        //protected HtmlInputHidden userlist;
        //protected HtmlInputText namelist;
        //protected RadioButtonList DepGuid;
        //protected HtmlInputCheckBox MemoShare;
        //protected DropDownList RoleGUID;
        //protected HtmlInputText Orders;
        //protected HtmlTextArea Notes;
        //protected HtmlGenericControl dvReadAttach;
        //protected Panel Attachword;
        //protected Repeater rpt;
        //protected Button save_bt;
		private int i = 1;
		private IList<Sys_DepInfo> li = new List<Sys_DepInfo>();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.InitData();
				if (!string.IsNullOrEmpty(base.Request.QueryString["uid"]))
				{
					this.Show(base.Request.QueryString["uid"]);
				}
			}
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["uid"]))
			{
				Sys_UserInfo sys_UserInfo = this.ViewState["su"] as Sys_UserInfo;
				if (this.PassWord.Value.Trim() != "")
				{
					sys_UserInfo.PassWord = Encrypt.MD5_32(this.PassWord.Value.Trim().ToLower());
				}
				sys_UserInfo.RealName = this.URealName.Value;
				sys_UserInfo.Sex = Convert.ToInt32(this.Sex1.SelectedValue);
				sys_UserInfo.Birthday = this.Birthday.Value;
				sys_UserInfo.Phone = this.Phone.Value;
				sys_UserInfo.RoleID = Convert.ToInt32(this.RoleID.SelectedValue);
				sys_UserInfo.DepID = Convert.ToInt32(this.parentID.SelectedValue);
				sys_UserInfo.DepName = this.ClearLeaf(this.parentID.Items[this.parentID.SelectedIndex].Text);
				sys_UserInfo.Status = Convert.ToInt32(this.Status1.SelectedValue);
				sys_UserInfo.IsLock = Convert.ToInt32(this.IsLock.Checked);
				sys_UserInfo.Notes = this.Notes.Value;
				sys_UserInfo.Tel = this.Tel.Value;
				sys_UserInfo.QQ = this.QQ.Value;
				sys_UserInfo.Email = this.Email.Value;
				sys_UserInfo.HomeAddress = this.HomeAddress.Value;
				sys_UserInfo.PositionName = this.PositionName.Value;
				sys_UserInfo.JoinTime = this.JoinTime.Value;
				sys_UserInfo.MsgTime = Convert.ToInt32(this.RoleGUID.SelectedValue);
				sys_UserInfo.MemoShare = Convert.ToInt32(this.MemoShare.Checked);
				sys_UserInfo.Orders = Convert.ToInt32(this.Orders.Value);
				sys_UserInfo.DepGUID = this.DepGuid.SelectedValue;
				if (this.Fup.HasFile)
				{
					FileExtension[] fileEx = new FileExtension[]
					{
						FileExtension.GIF,
						FileExtension.JPG,
						FileExtension.PNG,
						FileExtension.BMP
					};
					if (FileSystemManager.IsAllowedExtension(this.Fup, fileEx))
					{
						string userName = sys_UserInfo.UserName;
						string text = base.Server.MapPath("~/Files/common/");
						string text2 = userName + Path.GetExtension(this.Fup.FileName);
						text += text2;
						this.Fup.PostedFile.SaveAs(text);
						sys_UserInfo.PerPic = text2;
						this.Fup.Dispose();
					}
				}
				sys_UserInfo.et4 = this.UpdateFiles();
				sys_UserInfo.et6 = this.userlist.Value;
				sys_UserInfo.et5 = this.namelist.Value;
				Sys_User.Init().Update(sys_UserInfo);
                Help.UpdateIMUser(sys_UserInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!员工已编辑成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
			else
			{
				if (this.IsNewUsername(this.UUserName.Value.Trim().ToLower()))
				{
					Sys_UserInfo sys_UserInfo = new Sys_UserInfo();
					sys_UserInfo.UserName = this.UUserName.Value.ToLower();
					sys_UserInfo.PassWord = Encrypt.MD5_32(this.PassWord.Value.Trim().ToLower());
					sys_UserInfo.RealName = this.URealName.Value;
					sys_UserInfo.Sex = Convert.ToInt32(this.Sex1.SelectedValue);
					sys_UserInfo.Birthday = this.Birthday.Value;
					sys_UserInfo.Phone = this.Phone.Value;
					sys_UserInfo.RoleID = Convert.ToInt32(this.RoleID.SelectedValue);
					sys_UserInfo.DepID = Convert.ToInt32(this.parentID.SelectedValue);
					sys_UserInfo.DepName = this.ClearLeaf(this.parentID.Items[this.parentID.SelectedIndex].Text);
					sys_UserInfo.Status = Convert.ToInt32(this.Status1.SelectedValue);
					sys_UserInfo.IsLock = Convert.ToInt32(this.IsLock.Checked);
					sys_UserInfo.RegFromIp = RequestUtils.GetIP();
					sys_UserInfo.Notes = this.Notes.Value;
					sys_UserInfo.LastLoginTime = DateTime.Now;
					sys_UserInfo.RegTime = DateTime.Now;
					sys_UserInfo.Tel = this.Tel.Value;
					sys_UserInfo.QQ = this.QQ.Value;
					sys_UserInfo.Email = this.Email.Value;
					sys_UserInfo.MsgTime = 10;
					sys_UserInfo.HomeAddress = this.HomeAddress.Value;
					sys_UserInfo.PositionName = this.PositionName.Value;
					sys_UserInfo.JoinTime = this.JoinTime.Value;
					sys_UserInfo.MsgTime = Convert.ToInt32(this.RoleGUID.SelectedValue);
					sys_UserInfo.MemoShare = Convert.ToInt32(this.MemoShare.Checked);
					sys_UserInfo.Orders = Convert.ToInt32(this.Orders.Value);
					sys_UserInfo.DepGUID = this.DepGuid.SelectedValue;
					if (this.Fup.HasFile)
					{
						FileExtension[] fileEx = new FileExtension[]
						{
							FileExtension.GIF,
							FileExtension.JPG,
							FileExtension.PNG,
							FileExtension.BMP
						};
						if (FileSystemManager.IsAllowedExtension(this.Fup, fileEx))
						{
							string userName = sys_UserInfo.UserName;
							string text = base.Server.MapPath("~/Files/common/");
							string text2 = userName + Path.GetExtension(this.Fup.FileName);
							text += text2;
							this.Fup.PostedFile.SaveAs(text);
							sys_UserInfo.ComGUID = text2;
							this.Fup.Dispose();
						}
					}
					sys_UserInfo.et4 = this.UpdateFiles();
					sys_UserInfo.et6 = this.userlist.Value;
					sys_UserInfo.et5 = this.namelist.Value;
					Sys_User.Init().Add(sys_UserInfo);
					Help.UpdateIMUser(sys_UserInfo);
					string title = "[系统通知] : " + sys_UserInfo.RealName + ", 您好! 您的系统账号已开通, 欢迎使用本系统!";
					string content = "恭喜您! 您的系统账号已开通! <br><br>您的用户名：" + sys_UserInfo.UserName + " <br>您可以更改初始密码！如果您有其他疑问 请和系统管理员联系。<br>";
					int id = sys_UserInfo.id;
					string text3 = string.Concat(new object[]
					{
						sys_UserInfo.RealName,
						"#",
						sys_UserInfo.id,
						"#",
						sys_UserInfo.DepName,
						","
					});
					string text4 = sys_UserInfo.RealName + "(" + sys_UserInfo.DepName + "),";
					//Help.AdminSendMail(title, content, id, text3, text4);
					string str = HttpContext.Current.Server.HtmlEncode("您好!员工已添加成功!");
					base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
				}
				else
				{
					base.Response.Write("<script>alert('该用户名已被占用!请另外选择');window.location='User_Manage.aspx'</script>");
				}
			}
		}
		private void InitData()
		{
			IList all = Sys_Role.Init().GetAll(null, "order by id desc");
			this.RoleID.DataSource = all;
			this.RoleID.DataTextField = "RoleName";
			this.RoleID.DataValueField = "id";
			this.RoleID.DataBind();
			this.GetFirtNode();
			this.parentID.DataSource = this.li;
			this.parentID.DataTextField = "Sh";
			this.parentID.DataValueField = "ID";
			this.parentID.DataBind();
		}
		private void Show(string uid)
		{
			this.UUserName.Attributes.Add("readonly", "readonly");
			Sys_UserInfo byId = Sys_User.Init().GetById(Convert.ToInt32(uid));
			this.ViewState["su"] = byId;
			this.UUserName.Value = byId.UserName;
			this.PassWord.Value = byId.PassWord;
			this.PassWord2.Value = byId.PassWord;
			this.URealName.Value = byId.RealName;
			this.Sex1.SelectedValue = string.Concat(byId.Sex);
			this.Birthday.Value = byId.Birthday;
			this.Phone.Value = byId.Phone;
			this.RoleID.SelectedValue = string.Concat(byId.RoleID);
			this.parentID.SelectedValue = string.Concat(byId.DepID);
			this.Status1.SelectedValue = string.Concat(byId.Status);
			this.IsLock.Checked = Convert.ToBoolean(byId.IsLock);
			this.Notes.Value = byId.Notes;
			this.Tel.Value = byId.Tel;
			this.JoinTime.Value = byId.JoinTime;
			this.HomeAddress.Value = byId.HomeAddress;
			this.PositionName.Value = byId.PositionName;
			this.Email.Value = byId.Email;
			this.QQ.Value = byId.QQ;
			this.Orders.Value = string.Concat(byId.Orders);
			this.RoleGUID.SelectedValue = string.Concat(byId.MsgTime);
			this.MemoShare.Checked = Convert.ToBoolean(byId.MemoShare);
			this.userlist.Value = byId.et6;
			this.namelist.Value = byId.et5;
			if (byId.DepGUID == "no")
			{
				this.DepGuid.SelectedValue = "no";
			}
			if (!string.IsNullOrEmpty(byId.et4) && byId.et4.Contains("|"))
			{
				this.Attachword.Visible = true;
				List<TmpInfo> list = new List<TmpInfo>();
				string[] array = byId.et4.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].Trim() != "")
					{
						TmpInfo tmpInfo = new TmpInfo();
						int num = array[i].LastIndexOf('/') + 1;
						string tmp = array[i].Substring(num, array[i].Length - num);
						string tmp2 = array[i].Replace("~", "");
						tmpInfo.Tmp1 = array[i];
						tmpInfo.Tmp2 = tmp;
						tmpInfo.Tmp3 = tmp2;
						list.Add(tmpInfo);
					}
				}
				this.rpt.DataSource = list;
				this.rpt.DataBind();
			}
		}
		private bool IsNewUsername(string username)
		{
			IList all = Sys_User.Init().GetAll("UserName='" + username + "'", null);
			return all.Count == 0;
		}
		private string ClearLeaf(string text)
		{
			string[] array = new string[]
			{
				"\u3000",
				"└",
				"├",
				"│",
				"└"
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (text.Contains(array[i]))
				{
					text = text.Replace(array[i], "");
				}
			}
			return text.Trim();
		}
		private string UpdateFiles()
		{
			string text = "";
			HttpFileCollection files = HttpContext.Current.Request.Files;
			string text2 = DateTime.Now.ToString("yyMMdd");
			string text3 = base.Server.MapPath("~/Files/DocsFiles/");
			string str = "~/Files/DocsFiles/" + text2 + "/";
			text3 += text2;
			if (!Directory.Exists(text3))
			{
				FileSystemManager.CreateFolder(text2, base.Server.MapPath("~/Files/DocsFiles"));
			}
			try
			{
				string str2 = "";
				if (this.Attachword.Visible)
				{
					foreach (RepeaterItem repeaterItem in this.rpt.Items)
					{
						HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
						if (htmlInputCheckBox.Checked)
						{
							str2 = str2 + htmlInputCheckBox.Value + "|";
						}
					}
				}
				for (int i = 0; i < files.Count; i++)
				{
					HttpPostedFile httpPostedFile = files[i];
					if (Config.IsValidFile(httpPostedFile))
					{
						string fileName = Path.GetFileName(httpPostedFile.FileName);
						string str3 = str + fileName;
						string text4 = text3 + "\\" + fileName;
						if (File.Exists(text4))
						{
							string text5 = string.Concat(new object[]
							{
								DateTime.Now.ToString("HHmmssfff"),
								Utils.CreateRandomStr(3),
								this.Uid,
								i
							});
							text4 = string.Concat(new string[]
							{
								text3,
								"\\",
								text5,
								"@",
								Utils.GetFileExtension(fileName)
							});
							str3 = str + text5 + "@" + Utils.GetFileExtension(fileName);
						}
						httpPostedFile.SaveAs(text4);
						text = text + str3 + "|";
					}
				}
				text = str2 + text;
			}
			catch (IOException ex)
			{
				throw;
			}
			return text;
		}
		private void GetFirtNode()
		{
			DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Sys_Dep", null);
			dataSet.Relations.Add("sort", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["ParentID"], false);
			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				if (dataRow["ParentID"].ToString() == "0")
				{
					Sys_DepInfo sys_DepInfo = this.SetPram(dataRow);
					sys_DepInfo.Ch = "";
					sys_DepInfo.Sh = sys_DepInfo.DepName;
					this.li.Add(sys_DepInfo);
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
				Sys_DepInfo sys_DepInfo = this.SetPram(dataRow);
				if (depth == 2)
				{
					if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
					{
						sys_DepInfo.Ch = "\u3000└ ";
					}
					else
					{
						sys_DepInfo.Ch = "\u3000├ ";
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
							Sys_DepInfo expr_132 = sys_DepInfo;
							expr_132.Ch += "\u3000└ ";
						}
						else
						{
							for (int l = 1; l < depth - 1; l++)
							{
								sys_DepInfo.Ch = "\u3000│" + sys_DepInfo.Ch;
							}
							Sys_DepInfo expr_177 = sys_DepInfo;
							expr_177.Ch += "\u3000├ ";
						}
					}
				}
				sys_DepInfo.Sh = sys_DepInfo.Ch + sys_DepInfo.DepName;
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
				IsPosition = Convert.ToInt32(dbRow["IsPosition"])
			};
		}
	}
