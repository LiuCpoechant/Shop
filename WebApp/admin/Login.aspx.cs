using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.admin
{
    public partial class Login : System.Web.UI.Page
    {
        public string adminname { get; set; }
        public string adminpsw { get; set; }
        public string error { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                adminname = Request["adminname"];
                adminpsw = Request["adminpsw"];
                string code = Request["imageCode"];
                if (Session["code"].ToString().Equals(code))
                {
                    AdminService adminService = new AdminService();
                    List<Admin> adminList = adminService.GetModelList("adminname='" + adminname + " ' and adminpsw='" + adminpsw + "'");
                    if (adminList.Count > 0)
                    {
                        Session["admin"] = adminList[0];
                        Response.Redirect("/admin/Main.aspx");
                    }
                    else
                    {
                        error = "你的用户名或密码错误！";
                    }
                }
                else
                {
                    error = "验证码错误！";
                }
            }
        }
    }
}