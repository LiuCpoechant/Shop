using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.user
{
    public partial class UserModify : System.Web.UI.Page
    {
        public string sex { get; set; }
        public string msg { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            sex = ((User)Session["userList"]).usex;  //下拉菜单默认显示
            if (IsPostBack)
            {
                UserService userService = new UserService();
                HttpPostedFile file = Request.Files["headphoto"];
                string headphoto = ((User)Session["userList"]).headphoto;
                if (file != null && !file.FileName.Equals(""))
                {    //判断文件是否为空

                    string fileName = file.FileName;   //得到上传图片的文件名字

                    string ext = Path.GetExtension(fileName);   //得到上传图片的文件扩展名

                    if (ext == ".jpg" || ext == ".gif" || ext == ".png" || ext == ".jpeg" || ext == ".JPG" || ext == ".bmp") //设定文件的类型
                    {
                        string newFileNames = Guid.NewGuid().ToString() + ext;

                        string fileSavePath = Request.MapPath("/face/" + newFileNames);

                        headphoto = "/face/" + newFileNames;

                        file.SaveAs(fileSavePath);   //保存图片到服务器指定的目录中去
                    }
                }
                int uid = ((User)Session["userList"]).uid;
                User user = new User();
                user = userService.GetModel(uid);
                user.unickname = Request["unickname"];
                user.urealname = Request["urealname"];
                user.udentity = Request["udentity"];
                user.usex = Request["usex"];
                user.headphoto = headphoto;
                user.uphone = Request["uphone"];
                user.uemail = Request["uemail"];
                user.uaddress = Request["uaddress"];
                ///判断是否更改了密码
                if (!"".Equals(Request["pwd"]) && Request["repwd"] != null)
                {
                    user.upwd = Request["pwd"];
                }
                else
                {
                    user.upwd = ((User)Session["userList"]).upwd;
                }
                ///修改
                if (userService.Update(user))
                {
                    Session["userList"] = user;
                    Response.Redirect("/user/UserCenter.aspx");
                }
                else
                {
                    msg = "修改失败！";
                }
            }
        }
    }
}