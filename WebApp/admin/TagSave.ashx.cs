using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.admin
{
    /// <summary>
    /// TagSave 的摘要说明
    /// </summary>
    public class TagSave : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int TagId = Int32.Parse(context.Request["tagid"]);
            TagService tagService = new TagService();
            Tag tag = new Tag();
            tag =tagService.GetModel(TagId);
            tag.tagname = context.Request["tagname"];
            tag.taglink = context.Request["taglink"];
            bool b =tagService.Update(tag);
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