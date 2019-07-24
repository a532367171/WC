using System;
/// <summary>
/// Module 的摘要说明
/// </summary>
namespace WC
{
    public class Module
    {
        public static string a(string A_0, int A_1)
        {
            char[] array = A_0.ToCharArray();
            int num = 1015646121 + A_1;
            int arg_47_0;
            int arg_14_0;
            if ((arg_14_0 = (arg_47_0 = 0)) < 1)
            {
                goto IL_47;
            }
        IL_14:
            int num2;
            int expr_14 = num2 = arg_14_0;
            char[] arg_44_0 = array;
            int arg_44_1 = num2;
            char expr_1B = array[num2];
            byte b = (byte)((int)(expr_1B & 'ÿ') ^ num++);
            byte b2 = (byte)((int)(expr_1B >> 8) ^ num++);
            byte arg_3C_0 = b2;
            b2 = b;
            b = arg_3C_0;
            arg_44_0[arg_44_1] = (char)((int)b2 << 8 | (int)b);
            arg_47_0 = expr_14 + 1;
        IL_47:
            if ((arg_14_0 = arg_47_0) >= array.Length)
            {
                return string.Intern(new string(array));
            }
            goto IL_14;
        }
    }
}