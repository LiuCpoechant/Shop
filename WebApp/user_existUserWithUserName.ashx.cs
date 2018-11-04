using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    /// <summary>
    /// user_existUserWithUserName 的摘要说明
    /// </summary>
    public class user_existUserWithUserName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string uname = context.Request["uname"];

            UserService userService = new UserService();
            List<User> userList = userService.GetModelList("uname='" + uname + "'");

            if (userList.Count > 0)
            {
                context.Response.Write(false);//用户已存在
            }
            else
            {
                context.Response.Write(true);//可以使用
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