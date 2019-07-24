using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using WC.BLL;

public partial class KindEditor4_file_manager_json : System.Web.UI.Page
{
    public class NameSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            int result;
            if (x == null && y == null)
            {
                result = 0;
            }
            else
            {
                if (x == null)
                {
                    result = -1;
                }
                else
                {
                    if (y == null)
                    {
                        result = 1;
                    }
                    else
                    {
                        FileInfo fileInfo = new FileInfo(x.ToString());
                        FileInfo fileInfo2 = new FileInfo(y.ToString());
                        result = fileInfo.FullName.CompareTo(fileInfo2.FullName);
                    }
                }
            }
            return result;
        }
    }
    public class SizeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            int result;
            if (x == null && y == null)
            {
                result = 0;
            }
            else
            {
                if (x == null)
                {
                    result = -1;
                }
                else
                {
                    if (y == null)
                    {
                        result = 1;
                    }
                    else
                    {
                        FileInfo fileInfo = new FileInfo(x.ToString());
                        FileInfo fileInfo2 = new FileInfo(y.ToString());
                        result = fileInfo.Length.CompareTo(fileInfo2.Length);
                    }
                }
            }
            return result;
        }
    }
    public class TypeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            int result;
            if (x == null && y == null)
            {
                result = 0;
            }
            else
            {
                if (x == null)
                {
                    result = -1;
                }
                else
                {
                    if (y == null)
                    {
                        result = 1;
                    }
                    else
                    {
                        FileInfo fileInfo = new FileInfo(x.ToString());
                        FileInfo fileInfo2 = new FileInfo(y.ToString());
                        result = fileInfo.Extension.CompareTo(fileInfo2.Extension);
                    }
                }
            }
            return result;
        }
    }
    public new bool IsReusable
    {
        get
        {
            return true;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = base.Request.Path.Substring(0, base.Request.Path.LastIndexOf("/") + 1);
        string path = "/KindEditor4/attached/";
        string text = str + "attached/";
        string text2 = "gif,jpg,jpeg,png,bmp";
        string text3 = base.Request.QueryString["path"];
        text3 = (string.IsNullOrEmpty(text3) ? "" : text3);
        string path2;
        string value;
        string text4;
        string value2;
        if (text3 == "")
        {
            path2 = base.Server.MapPath(path);
            value = text;
            text4 = "";
            value2 = "";
        }
        else
        {
            path2 = base.Server.MapPath(path) + text3;
            value = text + text3;
            text4 = text3;
            value2 = Regex.Replace(text4, "(.*?)[^\\/]+\\/$", "$1");
        }
        string text5 = base.Request.QueryString["order"];
        text5 = (string.IsNullOrEmpty(text5) ? "" : text5.ToLower());
        if (Regex.IsMatch(text3, "\\.\\."))
        {
            base.Response.Write("Access is not allowed.");
            base.Response.End();
        }
        if (text3 != "" && !text3.EndsWith("/"))
        {
            base.Response.Write("Parameter is not valid.");
            base.Response.End();
        }
        if (!Directory.Exists(path2))
        {
            base.Response.Write("Directory does not exist.");
            base.Response.End();
        }
        string[] directories = Directory.GetDirectories(path2);
        string[] files = Directory.GetFiles(path2);
        string text6 = text5;
        if (text6 != null)
        {
            if (text6 == "size")
            {
                Array.Sort(directories, new KindEditor4_file_manager_json.NameSorter());
                Array.Sort(files, new KindEditor4_file_manager_json.SizeSorter());
                goto IL_243;
            }
            if (text6 == "type")
            {
                Array.Sort(directories, new KindEditor4_file_manager_json.NameSorter());
                Array.Sort(files, new KindEditor4_file_manager_json.TypeSorter());
                goto IL_243;
            }
            if (!(text6 == "name"))
            {
            }
        }
        Array.Sort(directories, new KindEditor4_file_manager_json.NameSorter());
        Array.Sort(files, new KindEditor4_file_manager_json.NameSorter());
    IL_243:
        Hashtable hashtable = new Hashtable();
        hashtable["moveup_dir_path"] = value2;
        hashtable["current_dir_path"] = text4;
        hashtable["current_url"] = value;
        hashtable["total_count"] = directories.Length + files.Length;
        List<Hashtable> list = new List<Hashtable>();
        hashtable["file_list"] = list;
        for (int i = 0; i < directories.Length; i++)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directories[i]);
            Hashtable hashtable2 = new Hashtable();
            hashtable2["is_dir"] = true;
            hashtable2["has_file"] = (directoryInfo.GetFileSystemInfos().Length > 0);
            hashtable2["filesize"] = 0;
            hashtable2["is_photo"] = false;
            hashtable2["filetype"] = "";
            hashtable2["filename"] = directoryInfo.Name;
            hashtable2["datetime"] = directoryInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            list.Add(hashtable2);
        }
        for (int i = 0; i < files.Length; i++)
        {
            FileInfo fileInfo = new FileInfo(files[i]);
            Hashtable hashtable2 = new Hashtable();
            hashtable2["is_dir"] = false;
            hashtable2["has_file"] = false;
            hashtable2["filesize"] = fileInfo.Length;
            hashtable2["is_photo"] = (Array.IndexOf<string>(text2.Split(new char[]
				{
					','
				}), fileInfo.Extension.Substring(1).ToLower()) >= 0);
            hashtable2["filetype"] = fileInfo.Extension.Substring(1);
            hashtable2["filename"] = fileInfo.Name;
            hashtable2["datetime"] = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            list.Add(hashtable2);
        }
        base.Response.AddHeader("Content-Type", "application/json; charset=UTF-8");
        base.Response.Write(JsonMapper.ToJson(hashtable));
        base.Response.End();
    }
}