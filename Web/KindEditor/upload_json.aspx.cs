using LitJson;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.Tool;

public partial class KindEditor_upload_json : ViewPages
{
    public enum FileExtension
    {
        JPG = 255216,
        GIF = 7173,
        BMP = 6677,
        PNG = 13780
    }
    private string savePath = "/KindEditor/attached/";
    private string saveUrl = "/KindEditor/attached/";
    private string fileTypes = "gif,jpg,jpeg,png,bmp";
    private int maxSize = 311000000;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.savePath += DateTime.Now.ToString("yyMM");
        this.saveUrl += DateTime.Now.ToString("yyMM");
        HttpPostedFile httpPostedFile = base.Request.Files["imgFile"];
        if (httpPostedFile == null)
        {
            this.showError("请选择文件。");
        }
        string text = base.Server.MapPath(this.savePath);
        if (!Directory.Exists(text))
        {
            FileSystemManager.CreateFolder(DateTime.Now.ToString("yyMM"), base.Server.MapPath("~/KindEditor/attached"));
        }
        if (!Directory.Exists(text))
        {
            this.showError("上传目录不存在。");
        }
        string fileName = httpPostedFile.FileName;
        string text2 = Path.GetExtension(fileName).ToLower();
        ArrayList.Adapter(this.fileTypes.Split(new char[]
			{
				','
			}));
        if (httpPostedFile.InputStream == null || httpPostedFile.InputStream.Length > (long)this.maxSize)
        {
            this.showError("上传文件大小超过限制。");
        }
        if (string.IsNullOrEmpty(text2) || Array.IndexOf<string>(this.fileTypes.Split(new char[]
			{
				','
			}), text2.Substring(1).ToLower()) == -1)
        {
            this.showError("上传文件扩展名是不允许的扩展名。");
        }
        KindEditor_upload_json.FileExtension[] fileEx = new KindEditor_upload_json.FileExtension[]
			{
				KindEditor_upload_json.FileExtension.GIF,
				KindEditor_upload_json.FileExtension.JPG,
				KindEditor_upload_json.FileExtension.PNG,
				KindEditor_upload_json.FileExtension.BMP
			};
        if (!KindEditor_upload_json.IsAllowedExtension(httpPostedFile, fileEx))
        {
            this.showError("非法图片文件! 上传文件发生异常。");
        }
        string str = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + text2;
        string filename = text + "/" + str;
        httpPostedFile.SaveAs(filename);
        string value = this.saveUrl + "/" + str;
        Hashtable hashtable = new Hashtable();
        hashtable["error"] = 0;
        hashtable["url"] = value;
        base.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
        base.Response.Write(JsonMapper.ToJson(hashtable));
        base.Response.End();
    }
    private void showError(string message)
    {
        Hashtable hashtable = new Hashtable();
        hashtable["error"] = 1;
        hashtable["message"] = message;
        base.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
        base.Response.Write(JsonMapper.ToJson(hashtable));
        base.Response.End();
    }
    public static bool IsAllowedExtension(HttpPostedFile fu, KindEditor_upload_json.FileExtension[] fileEx)
    {
        int contentLength = fu.ContentLength;
        byte[] buffer = new byte[contentLength];
        fu.InputStream.Read(buffer, 0, contentLength);
        MemoryStream memoryStream = new MemoryStream(buffer);
        BinaryReader binaryReader = new BinaryReader(memoryStream);
        string text = "";
        bool result;
        try
        {
            text = binaryReader.ReadByte().ToString();
            text += binaryReader.ReadByte().ToString();
        }
        catch
        {
            result = false;
            return result;
        }
        finally
        {
            binaryReader.Close();
            if (memoryStream != null)
                memoryStream.Close();
        }


            
        for (int i = 0; i < fileEx.Length; i++)
        {
            KindEditor_upload_json.FileExtension fileExtension = fileEx[i];
            try
            {
                if (int.Parse(text) == (int)fileExtension)
                {
                    result = true;
                    return result;
                }
            }
            catch
            {
                result = false;
                return result;
            }
        }
        result = false;
        return result;
    }
}