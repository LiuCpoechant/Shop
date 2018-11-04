using Shop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.admin
{
    /// <summary>
    /// TagDelete 的摘要说明
    /// </summary>
    public class TagDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            TagService tagService = new TagService();
            context.Response.ContentType = "text/plain";
            if (context.Request["TagId"] != null)//删除单个数据
            {
                int tagid = Int32.Parse(context.Request["TagId"]);
                bool b = tagService.Delete(tagid);
                context.Response.Write(b);
                context.Response.End();
            }
            else                                //批量删除数据
            { 
                string tagids=context.Request["tagids"];
                bool b1 = tagService.DeleteList(tagids);
                context.Response.Write(b1);
                context.Response.End();
            }
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