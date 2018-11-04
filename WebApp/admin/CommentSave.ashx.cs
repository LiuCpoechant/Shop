using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.admin
{
    /// <summary>
    /// CommentSave 的摘要说明
    /// </summary>
    public class CommentSave : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int commentId = Int32.Parse(context.Request["comid"]);

            CommentService commentService = new CommentService();

            Comment comments = commentService.GetModel(commentId);


            comments.replycontent = context.Request["replycontent"];
            comments.comreplytime = DateTime.Now;

            bool b = commentService.Update(comments);

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