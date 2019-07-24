<%@ WebHandler Language="C#" Class="limagan.cal.ping" %>
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace limagan.cal
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ping : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/javascript";
            context.Response.Charset = "UTF-8";
            string mytemp = "";
            context.Response.Write(mytemp);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
