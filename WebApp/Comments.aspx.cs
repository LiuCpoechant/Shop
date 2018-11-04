using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace WebApp
{
    public partial class Comments : System.Web.UI.Page
    {
        public string error { get; set; }
        public DateTime comtime { get; set; }
        public DateTime comreplytime { get; set; }
        public string uname { get; set; }
        public string uemail { get; set; }
        public string replycontent { get; set; }
        public string comcontent { get; set; }
        public string pageCode { get; set; }
        public List<Comment> commentList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //分页
            int pageNumber = 1;
            if (!Int32.TryParse(Request["page"], out pageNumber))
            {
                pageNumber = 1;
            }

            CommentService commentService = new CommentService();

            //求最大页
            int pageRecord = commentService.GetRecordCount("");
            int maxPage = 0;
            if (pageRecord / commentService.pageCount == 0)
            {
                maxPage = pageRecord % commentService.pageCount;
            }
            else
            {
                maxPage = pageRecord % commentService.pageCount + 1;
            }
            if (pageNumber > maxPage)
            {
                pageNumber = maxPage;
            }
            commentList = commentService.FindAllComment(pageNumber);

            pageCode = PageUtil.genPagination("/Comments.aspx", commentService.GetRecordCount(""), pageNumber, commentService.pageCount, "");

            //将数据保存到数据库中
            if (IsPostBack)
            {
                uname = ((User)Session["userList"]).uname;
                comcontent = Request["comcontent"];
                comtime = DateTime.Now;
                Comment comment = new Comment();
                comment.uname = uname;
                comment.comtime = comtime;
                comment.comcontent = comcontent;
                int i = commentService.Add(comment);

                if (i > 0)
                {
                    Response.Redirect("/Comments.aspx");
                }
            }
        }
    }
    
}