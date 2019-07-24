using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using WC.Model;
namespace WC.Tool
{
    public class FileSystemManager
    {
        private static string strRootFolder;
        static FileSystemManager()
        {
            FileSystemManager.strRootFolder = HttpContext.Current.Server.MapPath("~/pic/UpFiles") + "\\";
            FileSystemManager.strRootFolder = FileSystemManager.strRootFolder.Substring(0, FileSystemManager.strRootFolder.LastIndexOf("\\"));
        }
        public static FileSystemManager Iint()
        {
            return new FileSystemManager();
        }
        public static string GetRootPath()
        {
            return FileSystemManager.strRootFolder;
        }
        public static void SetRootPath(string path)
        {
            FileSystemManager.strRootFolder = path;
        }
        public static List<FileSystemItem> GetItems()
        {
            return FileSystemManager.GetItems(FileSystemManager.strRootFolder);
        }
        public static List<FileSystemItem> GetItems(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            List<FileSystemItem> list = new List<FileSystemItem>();
            string[] array = directories;
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i];
                FileSystemItem fileSystemItem = new FileSystemItem();
                DirectoryInfo directoryInfo = new DirectoryInfo(text);
                fileSystemItem.Name = directoryInfo.Name;
                fileSystemItem.FullName = directoryInfo.FullName;
                fileSystemItem.CreationDate = directoryInfo.CreationTime;
                fileSystemItem.IsFolder = true;
                fileSystemItem.WebName = fileSystemItem.FullName;
                fileSystemItem.WebName = fileSystemItem.WebName.Replace(FileSystemManager.GetRootPath(), "/UpFiles");
                fileSystemItem.WebName = fileSystemItem.WebName.Replace("\\", "/");
                list.Add(fileSystemItem);
            }
            array = files;
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i];
                FileSystemItem fileSystemItem = new FileSystemItem();
                FileInfo fileInfo = new FileInfo(text);
                fileSystemItem.Name = fileInfo.Name;
                fileSystemItem.FullName = fileInfo.FullName;
                fileSystemItem.CreationDate = fileInfo.CreationTime;
                fileSystemItem.IsFolder = false;
                fileSystemItem.WebName = fileSystemItem.FullName;
                fileSystemItem.WebName = fileSystemItem.WebName.Replace(FileSystemManager.GetRootPath(), "/UpFiles");
                fileSystemItem.WebName = fileSystemItem.WebName.Replace("\\", "/");
                fileSystemItem.Size = fileInfo.Length / 1024L;
                list.Add(fileSystemItem);
            }
            if (path.ToLower() != FileSystemManager.strRootFolder.ToLower())
            {
                FileSystemItem fileSystemItem2 = new FileSystemItem();
                DirectoryInfo parent = new DirectoryInfo(path).Parent;
                fileSystemItem2.Name = "[上一级]";
                fileSystemItem2.FullName = parent.FullName;
                list.Insert(0, fileSystemItem2);
                FileSystemItem fileSystemItem3 = new FileSystemItem();
                DirectoryInfo directoryInfo2 = new DirectoryInfo(FileSystemManager.strRootFolder);
                fileSystemItem3.Name = "[根目录]";
                fileSystemItem3.FullName = directoryInfo2.FullName;
                list.Insert(0, fileSystemItem3);
            }
            return list;
        }
        public static void CreateFolder(string name, string parentName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(parentName);
            directoryInfo.CreateSubdirectory(name);
        }
        public static bool DeleteFolder(string path)
        {
            bool result;
            try
            {
                Directory.Delete(path);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static bool MoveFolder(string oldPath, string newPath)
        {
            bool result;
            try
            {
                Directory.Move(oldPath, newPath);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static bool CreateFile(string filename, string path)
        {
            bool result;
            try
            {
                FileStream fileStream = File.Create(path + "\\" + filename);
                fileStream.Close();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static bool CreateFile(string filename, string path, byte[] contents)
        {
            bool result;
            try
            {
                FileStream fileStream = File.Create(path + "\\" + filename);
                fileStream.Write(contents, 0, contents.Length);
                fileStream.Close();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static string OpenText(string parentName)
        {
            StreamReader streamReader = File.OpenText(parentName);
            StringBuilder stringBuilder = new StringBuilder();
            string value;
            while ((value = streamReader.ReadLine()) != null)
            {
                stringBuilder.Append(value);
            }
            streamReader.Close();
            return stringBuilder.ToString();
        }
        public static bool WriteAllText(string parentName, string contents)
        {
            bool result;
            try
            {
                File.WriteAllText(parentName, contents, Encoding.Unicode);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static bool DeleteFile(string path)
        {
            bool result;
            try
            {
                File.Delete(path);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static bool MoveFile(string oldPath, string newPath)
        {
            bool result;
            try
            {
                File.Move(oldPath, newPath);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static FileSystemItem GetItemInfo(string path)
        {
            FileSystemItem fileSystemItem = new FileSystemItem();
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                fileSystemItem.Name = directoryInfo.Name;
                fileSystemItem.FullName = directoryInfo.FullName;
                fileSystemItem.CreationDate = directoryInfo.CreationTime;
                fileSystemItem.IsFolder = true;
                fileSystemItem.LastAccessDate = directoryInfo.LastAccessTime;
                fileSystemItem.LastWriteDate = directoryInfo.LastWriteTime;
                fileSystemItem.FileCount = (long)directoryInfo.GetFiles().Length;
                fileSystemItem.SubFolderCount = (long)directoryInfo.GetDirectories().Length;
            }
            else
            {
                FileInfo fileInfo = new FileInfo(path);
                fileSystemItem.Name = fileInfo.Name;
                fileSystemItem.FullName = fileInfo.FullName;
                fileSystemItem.CreationDate = fileInfo.CreationTime;
                fileSystemItem.LastAccessDate = fileInfo.LastAccessTime;
                fileSystemItem.LastWriteDate = fileInfo.LastWriteTime;
                fileSystemItem.IsFolder = false;
                fileSystemItem.Size = fileInfo.Length;
            }
            return fileSystemItem;
        }
        public static bool CopyFolder(string source, string destination)
        {
            bool result;
            try
            {
                if (destination[destination.Length - 1] != Path.DirectorySeparatorChar)
                {
                    destination += Path.DirectorySeparatorChar;
                }
                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                }
                string[] fileSystemEntries = Directory.GetFileSystemEntries(source);
                string[] array = fileSystemEntries;
                for (int i = 0; i < array.Length; i++)
                {
                    string text = array[i];
                    if (Directory.Exists(text))
                    {
                        FileSystemManager.CopyFolder(text, destination + Path.GetFileName(text));
                    }
                    else
                    {
                        File.Copy(text, destination + Path.GetFileName(text), true);
                    }
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static bool IsSafeName(string strExtension)
        {
            strExtension = strExtension.ToLower();
            if (strExtension.LastIndexOf(".") >= 0)
            {
                strExtension = strExtension.Substring(strExtension.LastIndexOf("."));
            }
            else
            {
                strExtension = ".txt";
            }
            string[] array = new string[]
			{
				".jpeg",
				".jpg",
				".gif",
				".png",
				".bmp"
			};
            bool result;
            for (int i = 0; i < array.Length; i++)
            {
                if (strExtension.Equals(array[i]))
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }
        public static bool IsUnsafeName(string strExtension)
        {
            strExtension = strExtension.ToLower();
            if (strExtension.LastIndexOf(".") >= 0)
            {
                strExtension = strExtension.Substring(strExtension.LastIndexOf("."));
            }
            else
            {
                strExtension = ".txt";
            }
            string[] array = new string[]
			{
				".",
				"jpg",
				"jpeg",
				"png",
				"bmp",
				"gif"
			};
            bool result;
            for (int i = 0; i < array.Length; i++)
            {
                if (strExtension.Equals(array[i]))
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }
        public static void MakeXpic(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(originalImagePath);
            int num = width;
            int num2 = height;
            int x = 0;
            int y = 0;
            int num3 = image.Width;
            int num4 = image.Height;
            if (mode != null && !(mode == "HW"))
            {
                if (!(mode == "W"))
                {
                    if (!(mode == "H"))
                    {
                        if (mode == "Cut")
                        {
                            if ((double)image.Width / (double)image.Height > (double)num / (double)num2)
                            {
                                num4 = image.Height;
                                num3 = image.Height * num / num2;
                                y = 0;
                                x = (image.Width - num3) / 2;
                            }
                            else
                            {
                                num3 = image.Width;
                                num4 = image.Width * height / num;
                                x = 0;
                                y = (image.Height - num4) / 2;
                            }
                        }
                    }
                    else
                    {
                        num = image.Width * height / image.Height;
                    }
                }
                else
                {
                    num2 = image.Height * width / image.Width;
                }
            }
            System.Drawing.Image image2 = new Bitmap(num, num2);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num3, num4), GraphicsUnit.Pixel);
            try
            {
                image2.Save(thumbnailPath, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
            }
        }
        public static bool IsAllowedExtension(FileUpload fu, FileExtension[] fileEx)
        {
            int contentLength = fu.PostedFile.ContentLength;
            byte[] buffer = new byte[contentLength];
            fu.PostedFile.InputStream.Read(buffer, 0, contentLength);
            MemoryStream memoryStream = new MemoryStream(buffer);
            BinaryReader binaryReader = new BinaryReader(memoryStream);
            string text = "";
            try
            {
                text = binaryReader.ReadByte().ToString();
                text += binaryReader.ReadByte().ToString();
            }
            catch
            {
            }
            binaryReader.Close();
            memoryStream.Close();
            bool result;
            for (int i = 0; i < fileEx.Length; i++)
            {
                FileExtension fileExtension = fileEx[i];
                if (int.Parse(text) == (int)fileExtension)
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }
        public static bool IsAllowedExtension(HttpPostedFile fu, FileExtension[] fileEx)
        {
            int contentLength = fu.ContentLength;
            byte[] buffer = new byte[contentLength];
            fu.InputStream.Read(buffer, 0, contentLength);
            MemoryStream memoryStream = new MemoryStream(buffer);
            BinaryReader binaryReader = new BinaryReader(memoryStream);
            string text = "";
            try
            {
                text = binaryReader.ReadByte().ToString();
                text += binaryReader.ReadByte().ToString();
            }
            catch
            {
            }
            binaryReader.Close();
            memoryStream.Close();
            bool result;
            for (int i = 0; i < fileEx.Length; i++)
            {
                FileExtension fileExtension = fileEx[i];
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
                }
            }
            result = false;
            return result;
        }
        public static string CreateRandomStr(int len)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < len; i++)
            {
                int value = random.Next(0, 10);
                stringBuilder.Append(value);
            }
            return stringBuilder.ToString();
        }
        public static MemoryStream DrawRandomStr(string authStr)
        {
            int width = authStr.Length * 20 + 2;
            Random random = new Random();
            Bitmap bitmap = new Bitmap(width, 28);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.FromArgb(random.Next(255, 255), random.Next(255, 255), random.Next(250, 255)));
            Font font = new Font("Verdana", (float)13, FontStyle.Bold);
            for (int i = 0; i < authStr.Length; i++)
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(random.Next(100, 150), random.Next(100, 150), random.Next(100, 150)));
                int num = i * 20;
                graphics.DrawString(authStr.Substring(i, 1), font, brush, (float)num, 1f);
            }
            MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, ImageFormat.Gif);
            graphics.Dispose();
            bitmap.Dispose();
            return memoryStream;
        }
    }
}
