using Shop.BLL;
using Shop.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace WebApp.admin
{
    public partial class UserManger : System.Web.UI.Page
    {
        public string niname { set; get; }
        public List<User> userList { set; get; }
        public string pageCode { set; get; }

        UserService userService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];
            if (flag == null || "".Equals(flag))
            {
                this.show(sender, e);
            }
            else if (flag == "save")
            {
                this.save(sender, e);
            }
            else if (flag == "add")
            {
                this.add(sender, e);
            }

        }
        protected void show(object sender, EventArgs e)
        {
            int pageNumber = 1;
            if (!Int32.TryParse(Request["page"], out pageNumber))
            {
                pageNumber = 1;
            }
            niname = Request["uniname"];

            ArrayList List = userService.GetUnameNickNameList(pageNumber, niname);  //动态数组
            userList = (List<User>)List[0];
            pageCode = List[1].ToString();
        }
        protected void save(object sender, EventArgs e)
        {
            int userId = Int32.Parse(Request["uid"]);   
            User user = userService.GetModel(userId); 
            HttpPostedFile file = Request.Files["headphoto"];  //获取上传的图片
            string headphoto =user.headphoto;
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
            user.headphoto = headphoto;
            user.upwd = Request["upwd"];
            user.unickname = Request["unickname"];
            user.usex = Request["usex"];
            user.uphone = Request["uphone"];
            user.uaddress = Request["uaddress"];
            user.uemail = Request["uemail"];

            bool b = userService.Update(user);

            Response.Write(b);
            Response.End();
        }
        protected void add(object sender, EventArgs e)
        {
            User user = new User();
            string headphoto1 = user.headphoto;
            headphoto1 = "/face/defualt.jpg";
            user.uname = Request["uname"];
            user.unickname = Request["unickname1"];
            user.upwd = Request["upwd1"];
            user.usex = Request["usex1"];
            user.headphoto = headphoto1;
            user.uregistertime = DateTime.Now;
            user.urealname = Request["urealname"]; 
            user.udentity = Request["udentity"];
            user.uphone = Request["uphone1"];
            user.uaddress = Request["uaddress1"];
            user.uemail = Request["uemail1"];

            if (userService.Add(user) > 0)
            {
                Response.Write(true);
                Response.End();
            }
            else
            {
                Response.Write(false);
            }
            
        }
    }
}

    