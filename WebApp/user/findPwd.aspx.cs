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
    public partial class findPwd : System.Web.UI.Page
    {    
        QuestionService questionService = new QuestionService();
        UserService userService = new UserService();
        public List<Question> questionList { get; set; }
        public string message { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            questionList = questionService.GetModelList("");
            if (IsPostBack)
            {
                string name = Request["uname"];
                string qid = Request["uquestion1"];
                string answer = Request["uanswer1"];
                User user = new User();
                user = userService.GetByname(Int32.Parse(name));
                string question = user.uquestion1;
                string reply = user.uanswer1;
                //判断得到的问题和答案是否与用户保存的相同
                if (user.uquestion1 == qid)
                {
                    if (user.uanswer1 == answer)
                    {
                       message="您的密码是" + user.upwd;
                    }
                    else
                    {
                        message="你的密保或者答案错误，多次错误后账号将会被锁定！";
                    }
                }
            }
        }
    }
}