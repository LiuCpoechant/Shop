using Shop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.admin
{
    /// <summary>
    /// CommentDelete 的摘要说明
    /// </summary>
    public class CommentDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            CommentService commentService = new CommentService(); 
            context.Response.ContentType = "text/plain";
            if (context.Request["CommentId"] != null)
            {
                int comid = Int32.Parse(context.Request["CommentId"]);
                bool b = commentService.Delete(comid);
                context.Response.Write(b);
                context.Response.End();
            }
            else
            {
                string cids = context.Request["cids"];
                bool b1 = commentService.DeleteList(cids);
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