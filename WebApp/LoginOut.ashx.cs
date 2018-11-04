using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    /// <summary>
    /// LoginOut 的摘要说明
    /// </summary>
    public class LoginOut : IHttpHandler, System.Web.SessionState.IRequiresSessionState //处理程序中使用session需要实现此接口
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Session["userList"] != null)
            {
                context.Session["userList"] = null;   //清除session中的userList对象 


                //退出到登录页
                context.Response.Redirect("/user/Login.aspx");
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