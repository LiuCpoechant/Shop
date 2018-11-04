using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.admin
{
    /// <summary>
    /// NoticeSave 的摘要说明
    /// </summary>
    public class NoticeSave : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int NoticeId =Int32.Parse(context.Request["noid"]);
            NoticeService noticeService = new NoticeService();
            Notice notice = new Notice();
            notice = noticeService.GetModel(NoticeId);
            notice.notitle=context.Request["notitle"];
            notice.nocontent = context.Request["nocontent"];
            bool b = noticeService.Update(notice);
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