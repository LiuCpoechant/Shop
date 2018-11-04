using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.admin
{
    /// <summary>
    /// NoticeAdd 的摘要说明
    /// </summary>
    public class NoticeAdd : IHttpHandler, System.Web.SessionState.IRequiresSessionState //处理程序中使用session需要实现此接口
    {
        public void ProcessRequest(HttpContext context)
        {
            //string a = context.Session["admin"].ToString();

            context.Response.ContentType = "text/plain";
            NoticeService noticeService = new NoticeService();
            Notice notice = new Notice();
            notice.notitle = context.Request["notitle1"];
            notice.nocontent = context.Request["nocontent1"];
            notice.adminid =1;
            notice.notime = DateTime.Now;
            bool b;
            if (noticeService.Add(notice) > 0)
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