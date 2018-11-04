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
    public partial class UserPwdValidate : System.Web.UI.Page
    {
        public string error { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                string pwd = Request["pwd"];
                string upwd = Request["upwd"];
               
                if (pwd==upwd)
                {
                    UserService userservice = new UserService();
                    User user =new User();
                    if(pwd==((User)Session["userList"]).upwd)
                    {
                        Response.Redirect("/user/UserModify.aspx");
                    }
                    else
                    {
                        error = "登录密码错误!";
                    }
                }  
            }
        }
    }
}