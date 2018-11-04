using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.admin
{
    /// <summary>
    /// UserSave 的摘要说明
    /// </summary>
    public class UserSave : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //int userId = Int32.Parse(context.Request["uid"]);

            //UserService userService = new UserService();

            //User user = userService.GetModel(userId);
            // HttpPostedFile file = Request.Files["headphoto"];
            //    string headphoto = ((User)Session["userList"]).headphoto;
            //    if (file != null && !file.FileName.Equals(""))
            //    {    //判断文件是否为空

            //        string fileName = file.FileName;   //得到上传图片的文件名字

            //        string ext = Path.GetExtension(fileName);   //得到上传图片的文件扩展名

            //        if (ext == ".jpg" || ext == ".gif" || ext == ".png" || ext == ".jpeg" || ext == ".JPG" || ext == ".bmp") //设定文件的类型
            //        {
            //            string newFileNames = Guid.NewGuid().ToString() + ext;

            //            string fileSavePath = Request.MapPath("/face/" + newFileNames);

            //            headphoto = "/face/" + newFileNames;

            //            file.SaveAs(fileSavePath);   //保存图片到服务器指定的目录中去
            //        }
            
            //user.upwd = context.Request["upwd"];
            //user.unickname = context.Request["unickname"];
            //user.usex = context.Request["usex"];
            //user.uphone = context.Request["uphone"];
            //user.uaddress = context.Request["uaddress"];
            //user.uemail = context.Request["uemail"];

            //bool b = userService.Update(user);

            //context.Response.Write(b);
            //context.Response.End();
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