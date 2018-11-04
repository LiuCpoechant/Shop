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
    public partial class Register : System.Web.UI.Page
    {
        public string error { get; set; }
        public string headphoto { get; set; }
        public string uname { get; set; }
        public string upwd { get; set; }
        public string usex { get; set; }
        public string urealname { get; set; }
        public string nickname { get; set; }
        public string udentity { get; set; }
        public string uquestion1 { get; set; }
        public string uquestion2 { get; set; }
        public string uanswer1 { get; set; }
        public string uanswer2 { get; set; }
        public string uphone { get; set; }
        public string uemail { get; set; }
        public string uaddress { get; set; }
        public DateTime uregistertime { get; set; }
        public  List<Question> questionList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            QuestionService questionService = new QuestionService();
            questionList = questionService.GetModelList("");
            if (IsPostBack)
            {               
                HttpPostedFile file = Request.Files["headphoto"];//获取上传的图片
                if (file != null && !file.FileName.Equals(""))//判断文件名是否为空
                {
                    string fileName = file.FileName;//得到上传的图片名字
                    string ext = Path.GetExtension(fileName);//得到文件的扩展名

                    if (ext == ".jpg" || ext == ".gif" || ext == ".png" || ext == ".jpeg" || ext == ".JPG") //设定文件的类型
                    {

                        string newFileNames = Guid.NewGuid().ToString() + ext;

                        //Directory.CreateDirectory(Path.GetDirectoryName(Request.MapPath("/face/" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "/")));

                        string fileSavePath = Request.MapPath("/face/" + newFileNames);

                        headphoto = "/face/" + newFileNames;

                        file.SaveAs(fileSavePath);   //保存图片到服务器指定的目录中去
                    }
                    else
                    {
                        headphoto = "/image/defualt.jpg";
                    }
                }
                else
                {
                    headphoto = "/image/defualt.jpg";
                }
                uname = Request.Form["uname"];
                upwd = Request.Form["upwd"];
                nickname = Request.Form["unickname"];
                usex = Request.Form["usex"];
                uregistertime = DateTime.Now;
                urealname = Request.Form["urealname"];
                uquestion1 = Request.Form["uquestion1"];              
                uanswer1 = Request.Form["uanswer1"];
                udentity = Request.Form["udentity"];
                uphone = Request.Form["uphone"];
                uaddress = Request.Form["uaddress"];
                uemail = Request.Form["uemail"];
                //创建业务层，并且调用业务层的方法来添加用户信息
                UserService userService = new UserService();
                User userInfo = new User();
                //将页面提交的数据保存到user中
                userInfo.uname = uname;
                userInfo.upwd = upwd;
                userInfo.usex = usex;
                userInfo.headphoto = headphoto;
                userInfo.urealname = urealname;
                userInfo.unickname = nickname;
                userInfo.uregistertime = uregistertime;
                userInfo.uquestion1 = uquestion1;             
                userInfo.uanswer1 = uanswer1;             
                userInfo.udentity = udentity;
                userInfo.uphone = uphone;
                userInfo.uaddress = uaddress;
                userInfo.uemail = uemail;

                int i = userService.Add(userInfo);//在业务层和dal层修改方法
                if (i > 0)
                {
                    userInfo.uid = i;//用户的主键id
                    Session["userInfo"] = userInfo;
                    Response.Redirect("/user/RegRusult.aspx");
                }
                else
                {
                    error = "注册失败，请重新注册";
                }

            }

        }
    }
}