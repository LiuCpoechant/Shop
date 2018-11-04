using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.admin
{
    /// <summary>
    /// TagAdd 的摘要说明
    /// </summary>
    public class TagAdd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            TagService tagService = new TagService();
            Tag tag = new Tag();
            tag.tagname = context.Request["tagname1"];
            tag.taglink = context.Request["taglink1"];
            bool b;
            if (tagService.Add(tag) > 0)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            context.Response.Write(b);
            context.Response.End();
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