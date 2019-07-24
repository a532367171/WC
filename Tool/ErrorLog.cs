using System;
using System.IO;
using System.Text;
namespace WC.Tool
{
    public class ErrorLog
    {
        public static void ToTxt(Exception exception, string path, string tmp)
        {
            StringBuilder stringBuilder = new StringBuilder(1024);
            stringBuilder.Append("============================================================================\n\n   ");
            stringBuilder.Append("\n\n客户机IP/错误地址：" + tmp + "\n\n");
            stringBuilder.Append("\n\n错误发生时间：   \n\n");
            stringBuilder.Append(DateTime.Now.ToString("yy-M-dd HH:mm:ss"));
            stringBuilder.Append("\n\n错误信息：\n\n   ");
            stringBuilder.Append(exception.ToString());
            stringBuilder.Append("\n\n\n");
            StreamWriter streamWriter = new StreamWriter(path, true, Encoding.Unicode);
            streamWriter.Write(stringBuilder);
            streamWriter.Close();
        }
    }
}
