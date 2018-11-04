using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.user
{
    public partial class Login : System.Web.UI.Page
    {
        public string error { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                string uname = Request["uname"];
                string upwd = Request["upwd"];
                string code = Request["imageCode"];//令code=imageCode
                if (Session["code"].ToString().Equals(code))
                {
                    UserService userservice = new UserService();
                    List<User> userList = userservice.GetModelList("uname='" + uname + "'and upwd='" + upwd + "'");//将user的用户名和密码放到list中
                    if (userList.Count > 0)
                    {
                        User u = userList[0];
                        Session["userList"] = u;

                        if (!Request["url"].ToString().Contains("/user/Login.aspx"))
                        {
                            Response.Redirect(Request["url"].ToString());
                        }
                        else
                        {
                            Response.Redirect("/Index.aspx");
                        }
                    }
                    else
                    {
                        error = "你的用户名或密码错误";
                    }
                }
                else
                {
                    error = "验证码错误";
                }
            }
        }
    }
}