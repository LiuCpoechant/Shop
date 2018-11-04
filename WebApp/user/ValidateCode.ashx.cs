using shop.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.user
{
    /// <summary>
    /// ValidateCode 的摘要说明
    /// </summary>
    public class ValidateCode : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            MyValidate validateCode = new MyValidate();

            string code = validateCode.CreateValidateCode(4);
            context.Session["code"] = code;//保存到session中
            validateCode.CreateValidateGraphic(code, context);
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