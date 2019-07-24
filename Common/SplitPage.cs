using System;
using System.Text;
namespace WC.Common
{
    public static class SplitPage
    {
        public static string GetPageSet(int pageIndex, int pageSize, int recordCount, string urlFormat, int mode)
        {
            string result;
            switch (mode)
            {
                case 0:
                    result = SplitPage.GetPageSet0(pageIndex, pageSize, recordCount, urlFormat);
                    break;
                case 1:
                    result = SplitPage.GetPageSet1(pageIndex, pageSize, recordCount, urlFormat);
                    break;
                default:
                    result = SplitPage.GetPageSet0(pageIndex, pageSize, recordCount, urlFormat);
                    break;
            }
            return result;
        }
        private static string GetPageSet0(int pageIndex, int pageSize, int recordCount, string urlFormat)
        {
            int num = (recordCount % pageSize == 0) ? (recordCount / pageSize) : (recordCount / pageSize + 1);
            string result;
            if (num <= 1)
            {
                result = "";
            }
            else
            {
                if (pageIndex < 1)
                {
                    pageIndex = 1;
                }
                if (pageIndex > num)
                {
                    pageIndex = num;
                }
                string[] array = urlFormat.Split(new char[]
				{
					'$'
				});
                StringBuilder stringBuilder = new StringBuilder(800);
                stringBuilder.Append("共" + recordCount + "条 | ");
                stringBuilder.Append("每页" + pageSize + "条 | ");
                stringBuilder.Append(string.Concat(new object[]
				{
					"此为",
					pageIndex,
					"/",
					num,
					"页 | "
				}));
                if (pageIndex <= 1)
                {
                    stringBuilder.Append("首页 | 上页 | ");
                }
                else
                {
                    stringBuilder.Append(string.Concat(new string[]
					{
						"<a href=\"",
						array[0],
						"1",
						array[1],
						"\">首页</a> | "
					}));
                    stringBuilder.Append(string.Concat(new string[]
					{
						"<a href=\"",
						array[0],
						(pageIndex - 1).ToString(),
						array[1],
						"\">上页</a> | "
					}));
                }
                if (pageIndex >= num)
                {
                    stringBuilder.Append("下页 | 尾页 | ");
                }
                else
                {
                    stringBuilder.Append(string.Concat(new string[]
					{
						"<a href=\"",
						array[0],
						(pageIndex + 1).ToString(),
						array[1],
						"\">下页</a> | "
					}));
                    stringBuilder.Append(string.Concat(new string[]
					{
						"<a href=\"",
						array[0],
						num.ToString(),
						array[1],
						"\">尾页</a> | "
					}));
                }
                stringBuilder.Append("转到 <input id=\"Paging_PageIndex_Text\" name=\"Paging_PageIndex_Text\" type=\"text\" value=\"" + pageIndex + "\" maxlength=\"10\" size=\"3\" /> 页 ");
                stringBuilder.Append(string.Concat(new string[]
				{
					"<input id=\"Paging_PageIndex_Button\" name=\"Paging_PageIndex_Button\" type=\"button\" value=\"GO\" onclick=\"javascript: document.location.href = '",
					array[0],
					"' + document.getElementById('Paging_PageIndex_Text').value + '",
					array[1],
					"';\" />"
				}));
                result = stringBuilder.ToString();
            }
            return result;
        }
        private static string GetPageSet1(int pageIndex, int pageSize, int recordCount, string urlFormat)
        {
            int num = (recordCount % pageSize == 0) ? (recordCount / pageSize) : (recordCount / pageSize + 1);
            string result;
            if (num <= 1)
            {
                result = "";
            }
            else
            {
                if (pageIndex < 1)
                {
                    pageIndex = 1;
                }
                if (pageIndex > num)
                {
                    pageIndex = num;
                }
                int num2 = 8;
                int num3 = (pageIndex % 8 == 0) ? (pageIndex / num2) : (pageIndex / num2 + 1);
                int num4 = num3 * num2 - (num2 - 1);
                int num5 = num3 * num2;
                if (num < num5)
                {
                    num5 = num;
                }
                string[] array = urlFormat.Split(new char[]
				{
					'$'
				});
                StringBuilder stringBuilder = new StringBuilder(800);
                stringBuilder.Append("<ul id=\"pageSet\">");
                if (num4 > num2)
                {
                    stringBuilder.Append(string.Concat(new string[]
					{
						"<li><a href=\"",
						array[0],
						(pageIndex - num2).ToString(),
						array[1],
						"\">&lt;&lt;</a></li>"
					}));
                }
                if (pageIndex > 1)
                {
                    stringBuilder.Append(string.Concat(new string[]
					{
						"<li><a href=\"",
						array[0],
						(pageIndex - 1).ToString(),
						array[1],
						"\">&lt;</a></li>"
					}));
                }
                for (int i = num4; i <= num5; i++)
                {
                    if (pageIndex == i)
                    {
                        stringBuilder.Append("<li class=\"CurrentPage\"><a class=\"selected\">" + i + "</a></li>");
                    }
                    else
                    {
                        stringBuilder.Append(string.Concat(new object[]
						{
							"<li><a href=\"",
							array[0],
							i.ToString(),
							array[1],
							"\">",
							i,
							"</a></li>"
						}));
                    }
                }
                if (pageIndex < num)
                {
                    stringBuilder.Append(string.Concat(new string[]
					{
						"<li><a href=\"",
						array[0],
						(pageIndex + 1).ToString(),
						array[1],
						"\">&gt;</a></li>"
					}));
                }
                if (num5 < num)
                {
                    stringBuilder.Append(string.Concat(new string[]
					{
						"<li><a href=\"",
						array[0],
						(pageIndex + num2).ToString(),
						array[1],
						"\">&gt;&gt;</a></li>"
					}));
                }
                stringBuilder.Append("</ul>");
                result = stringBuilder.ToString();
            }
            return result;
        }
    }
}
