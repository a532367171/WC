using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace WC.Tool
{
    public class Encrypt
    {
        private static string _UrlKey = "c07j30bg";
        private static byte[] Keys;
        public static string SimpEncrypt(string str)
        {
            string result="";
            while (true)
            {
                StringBuilder stringBuilder = new StringBuilder();
                int num = 0;
                int num2 = 0;
                while (true)
                {
                    bool flag = false;
                    switch (num2)
                    {
                        case 0:
                            if (true)
                            {
                            }
                            goto IL_52;
                        case 1:
                            {
                                if (!flag)
                                {
                                    num2 = 2;
                                    continue;
                                }
                                char c = char.Parse(str.Substring(num, 1));
                                int num3 = (int)(c + '\u0003');
                                stringBuilder.Append((char)num3);
                                num++;
                                num2 = 3;
                                continue;
                            }
                        case 2:
                            result = stringBuilder.ToString();
                            num2 = 4;
                            continue;
                        case 3:
                            goto IL_52;
                        case 4:
                            return result;
                    }
                    break;
                IL_52:
                    flag = (num < str.Length);
                    num2 = 1;
                }
            }
            return result;
        }
        public static string SimpUnEncrypt(string str)
        {
            string result="";
            while (true)
            {
                StringBuilder stringBuilder = new StringBuilder();
                int num = 0;
                int num2 = 3;
                while (true)
                {
                    bool flag = false;
                    switch (num2)
                    {
                        case 0:
                            {
                                if (!flag)
                                {
                                    num2 = 1;
                                    continue;
                                }
                                char c = char.Parse(str.Substring(num, 1));
                                int num3 = (int)(c - '\u0003');
                                stringBuilder.Append((char)num3);
                                num++;
                                num2 = 2;
                                continue;
                            }
                        case 1:
                            result = stringBuilder.ToString();
                            num2 = 4;
                            continue;
                        case 2:
                            goto IL_52;
                        case 3:
                            if (true)
                            {
                            }
                            goto IL_52;
                        case 4:
                            return result;
                    }
                    break;
                IL_52:
                    flag = (num < str.Length);
                    num2 = 0;
                }
            }
            return result;
        }
        public static string EncryptStr(string rs)
        {
            string result="";
            while (true)
            {
                byte[] array = new byte[rs.Length];
                int num = 0;
                int num2 = 6;
                while (true)
                {
                    bool flag = false;
                    switch (num2)
                    {
                        case 0:
                            rs = "";
                            num = array.Length - 1;
                            num2 = 5;
                            continue;
                        case 1:
                            if (!flag)
                            {
                                if (true)
                                {
                                }
                                num2 = 0;
                                continue;
                            }
                            array[num] = (byte)(rs[num] + 1);
                            num++;
                            num2 = 2;
                            continue;
                        case 2:
                            goto IL_C4;
                        case 3:
                            return result;
                        case 4:
                            goto IL_4B;
                        case 5:
                            goto IL_4B;
                        case 6:
                            goto IL_C4;
                        case 7:
                            result = rs;
                            num2 = 3;
                            continue;
                        case 8:
                            {
                                if (!flag)
                                {
                                    num2 = 7;
                                    continue;
                                }
                                string arg_10D_0 = rs;
                                char c = (char)array[num];
                                rs = arg_10D_0 + c.ToString();
                                num--;
                                num2 = 4;
                                continue;
                            }
                    }
                    break;
                IL_4B:
                    flag = (num >= 0);
                    num2 = 8;
                    continue;
                IL_C4:
                    flag = (num <= rs.Length - 1);
                    num2 = 1;
                }
            }
            return result;
        }
        public static string DecryptStr(string rs)
        {
            string result="";
            while (true)
            {
                byte[] array = new byte[rs.Length];
                int num = 0;
                int num2 = 1;
                while (true)
                {
                    bool flag = false;
                    switch (num2)
                    {
                        case 0:
                            {
                                if (!flag)
                                {
                                    num2 = 8;
                                    continue;
                                }
                                string arg_10D_0 = rs;
                                char c = (char)array[num];
                                rs = arg_10D_0 + c.ToString();
                                num--;
                                num2 = 5;
                                continue;
                            }
                        case 1:
                            goto IL_C4;
                        case 2:
                            if (true)
                            {
                            }
                            rs = "";
                            num = array.Length - 1;
                            num2 = 3;
                            continue;
                        case 3:
                            goto IL_4B;
                        case 4:
                            if (!flag)
                            {
                                num2 = 2;
                                continue;
                            }
                            array[num] = (byte)(rs[num] - 1);
                            num++;
                            num2 = 6;
                            continue;
                        case 5:
                            goto IL_4B;
                        case 6:
                            goto IL_C4;
                        case 7:
                            return result;
                        case 8:
                            result = rs;
                            num2 = 7;
                            continue;
                    }
                    break;
                IL_4B:
                    flag = (num >= 0);
                    num2 = 0;
                    continue;
                IL_C4:
                    flag = (num <= rs.Length - 1);
                    num2 = 4;
                }
            }
            return result;
        }
        public static string MD5(string str)
        {
            byte[] array = Encoding.Default.GetBytes(str);
            array = new MD5CryptoServiceProvider().ComputeHash(array);
            string text = "";
            for (int i = 0; i < array.Length; i++)
            {
                text += array[i].ToString("x").PadLeft(2, '0');
            }
            return text.Substring(8, 16);
        }
        public static string MD5_32(string str)
        {
            byte[] array = Encoding.Default.GetBytes(str);
            array = new MD5CryptoServiceProvider().ComputeHash(array);
            string text = "";
            for (int i = 0; i < array.Length; i++)
            {
                text += array[i].ToString("x").PadLeft(2, '0');
            }
            return text;
        }
        public static string SHA256(string str)
        {
            if (true)
            {
            }
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            SHA256Managed sHA256Managed = new SHA256Managed();
            byte[] inArray = sHA256Managed.ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }

        public static string RC4_Encode(string encryptString, string encryptKey)
        {
            encryptKey = Utils.GetSubString(encryptKey, 8, "");
            encryptKey = encryptKey.PadRight(8, ' ');
            byte[] bytes = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
            byte[] keys = Encrypt.Keys;
            byte[] bytes2 = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, keys), CryptoStreamMode.Write);
            cryptoStream.Write(bytes2, 0, bytes2.Length);
            cryptoStream.FlushFinalBlock();
            string result = Convert.ToBase64String(memoryStream.ToArray());
            if (true)
            {
            }
            return result;
        }
        public static string RC4_Decode(string decryptString, string decryptKey)
        {
            string result="";
            try
            {
                if (true)
                {
                }
                decryptKey = Utils.GetSubString(decryptKey, 8, "");
                decryptKey = decryptKey.PadRight(8, ' ');
                byte[] bytes = Encoding.UTF8.GetBytes(decryptKey);
                byte[] keys = Encrypt.Keys;
                byte[] array = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, keys), CryptoStreamMode.Write);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                result = Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch
            {
                result = "";
            }
            return result;
        }

        public static string DES_EnUrl(string UrlKey)
        {
            return Encrypt.DES_EncryptUrl(UrlKey, Encrypt._UrlKey);
        }
        public static string DES_DeUrl(string UrlKey)
        {
            return Encrypt.DES_DecryptUrl(UrlKey, Encrypt._UrlKey);
        }
        //private static string DES_EncryptUrl(string pToEncrypt, string sKey)
        //{
        //    int a_ = 18;
        //    string result="";
        //    while (true)
        //    {
        //        DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
        //        byte[] bytes = Encoding.Default.GetBytes(pToEncrypt);
        //        dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
        //        dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
        //        MemoryStream memoryStream = new MemoryStream();
        //        CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
        //        cryptoStream.Write(bytes, 0, bytes.Length);
        //        cryptoStream.FlushFinalBlock();
        //        StringBuilder stringBuilder = new StringBuilder();
        //        byte[] array = memoryStream.ToArray();
        //        int num = 0;
        //        int num2 = 0;
        //        while (true)
        //        {
        //            if (true)
        //            {
        //            }
        //            bool flag = false;
        //            switch (num2)
        //            {
        //            case 0:
        //                goto IL_D2;
        //            case 1:
        //                return result;
        //            case 2:
        //                goto IL_D2;
        //            case 3:
        //            {
        //                if (!flag)
        //                {
        //                    num2 = 4;
        //                    continue;
        //                }
        //                byte b = array[num];
        //                stringBuilder.AppendFormat(Module.a("鯟틡\udee3뻥\udae7韩", a_), b);
        //                num++;
        //                num2 = 2;
        //                continue;
        //            }
        //            case 4:
        //                stringBuilder.ToString();
        //                result = stringBuilder.ToString();
        //                num2 = 1;
        //                continue;
        //            }
        //            break;
        //            IL_D2:
        //            flag = (num < array.Length);
        //            num2 = 3;
        //        }
        //    }
        //    return result;
        //}

        private static string DES_EncryptUrl(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(pToEncrypt);
            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array = memoryStream.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                byte b = array[i];
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            stringBuilder.ToString();
            return stringBuilder.ToString();
        }

        private static string DES_DecryptUrl(string pToDecrypt, string sKey)
        {
            string @string="";
            while (true)
            {
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                byte[] array = new byte[pToDecrypt.Length / 2];
                int num = 0;
                int num2 = 3;
                while (true)
                {
                    bool flag = false;
                    switch (num2)
                    {
                        case 0:
                            {
                                if (true)
                                {
                                }
                                dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
                                dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
                                MemoryStream memoryStream = new MemoryStream();
                                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
                                cryptoStream.Write(array, 0, array.Length);
                                cryptoStream.FlushFinalBlock();
                                StringBuilder stringBuilder = new StringBuilder();
                                @string = Encoding.Default.GetString(memoryStream.ToArray());
                                num2 = 2;
                                continue;
                            }
                        case 1:
                            goto IL_C8;
                        case 2:
                            return @string;
                        case 3:
                            goto IL_C8;
                        case 4:
                            {
                                if (!flag)
                                {
                                    num2 = 0;
                                    continue;
                                }
                                int num3 = Convert.ToInt32(pToDecrypt.Substring(num * 2, 2), 16);
                                array[num] = (byte)num3;
                                num++;
                                num2 = 1;
                                continue;
                            }
                    }
                    break;
                IL_C8:
                    flag = (num < pToDecrypt.Length / 2);
                    num2 = 4;
                }
            }
            return @string;
        }


        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string EncryptString(string input, string sKey)
        {
            byte[] data = Encoding.UTF8.GetBytes(input);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = des.CreateEncryptor();
                byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                return BitConverter.ToString(result);
            }
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string DecryptString(string input, string sKey)
        {
            string[] sInput = input.Split("-".ToCharArray());
            byte[] data = new byte[sInput.Length];
            for (int i = 0; i < sInput.Length; i++)
            {
                data[i] = byte.Parse(sInput[i], System.Globalization.NumberStyles.HexNumber);
            }
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = des.CreateDecryptor();
                byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                return Encoding.UTF8.GetString(result);
            }
        }





    }
}
//using System;
//using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.IO;
//using System.Text;
//using System.Security.Cryptography;
///// <summary>
///// Encrypt 的摘要说明
///// </summary>
//public class Encrypt
//{
//    public Encrypt()
//    {
//    }
//    //默认密钥向量
//    private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
   
   
   
//    /// <summary>
//    /// DES加密字符串
//    /// </summary>
//    /// <param name="encryptString">待加密的字符串</param>
//    /// <param name="encryptKey">加密密钥,要求为8位</param>
//    /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
//    public static string EncryptDES(string encryptString, string encryptKey)
//    {
//        try
//        {
//            byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
//            byte[] rgbIV = Keys;
//            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
//            DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
//            MemoryStream mStream = new MemoryStream();
//            CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
//            cStream.Write(inputByteArray, 0, inputByteArray.Length);
//            cStream.FlushFinalBlock();
//            return Convert.ToBase64String(mStream.ToArray());
//        }
//        catch
//        {
//            return encryptString;
//        }
//    }
   
   
   
//    /// <summary>
//    /// DES解密字符串
//    /// </summary>
//    /// <param name="decryptString">待解密的字符串</param>
//    /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
//    /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
//    public static string DecryptDES(string decryptString, string decryptKey)
//    {
//        try
//        {
//            byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
//            byte[] rgbIV = Keys;
//            byte[] inputByteArray = Convert.FromBase64String(decryptString);
//            DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
//            MemoryStream mStream = new MemoryStream();
//            CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
//            cStream.Write(inputByteArray, 0, inputByteArray.Length);
//            cStream.FlushFinalBlock();
//            return Encoding.UTF8.GetString(mStream.ToArray());
//        }
//        catch
//        {
//            return decryptString;
//        }
//    }

//}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        