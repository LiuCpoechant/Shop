using Shop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.admin
{
    /// <summary>
    /// UserDelete 的摘要说明
    /// </summary>
    public class UserDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
             UserService userService = new UserService();
            context.Response.ContentType = "text/plain";
            if (context.Request["uid"] != null)//删除单个数据
            {
                int uid = Int32.Parse(context.Request["uid"]);
                bool b = userService.Delete(uid);
                context.Response.Write(b);
                context.Response.End();
            }
            else                                //批量删除数据
            { 
                string uids=context.Request["uids"];
                bool b1 = userService.DeleteList(uids);
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