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
    public partial class ModifyAdmin : System.Web.UI.Page
    {
        public string msg { get; set; }
        public string sex { get; set; }
        Admin admin = new Admin();
        AdminService adminService = new AdminService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int aid = ((Admin)Session["admin"]).adminid;
                admin = adminService.GetModel(aid);
                admin.adminrealname = Request["nickname"];
                //判断是否换了密码
                if (!"".Equals(Request["pwd"]) && Request["repwd"] != null)
                {
                    admin.adminpsw = Request["pwd"];
                }
                else
                {
                    admin.adminpsw = ((Admin)Session["admin"]).adminpsw;
                }
                if (adminService.Update(admin))
                {
                    Session["admin"] = admin;
                    Response.Redirect("/admin/Login.aspx");
                }
                else
                {
                    msg = "修改失败";
                }
            }

        }
    }
}