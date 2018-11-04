using Shop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.admin
{
    /// <summary>
    /// NoticeDelete 的摘要说明
    /// </summary>
    public class NoticeDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            NoticeService noticeService = new NoticeService();
            context.Response.ContentType = "text/plain";
            if (context.Request["NoticeId"] != null)//删除单个数据
            {
                int uid = Int32.Parse(context.Request["NoticeId"]);
                bool b = noticeService.Delete(uid);
                context.Response.Write(b);
                context.Response.End();
            }
            else                                //批量删除数据
            {
                string nids = context.Request["nids"];
                bool b1 = noticeService.DeleteList(nids);
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