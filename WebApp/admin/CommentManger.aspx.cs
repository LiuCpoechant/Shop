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
    public partial class CommentManger : System.Web.UI.Page
    {
        public string pageCode { get; set; }
        public List<Comment> commentList { get; set; }
        CommentService commentsService = new CommentService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int pageNumber = 1;
                if (!Int32.TryParse(Request["page"], out pageNumber))
                {
                    pageNumber = 1;
                }
                int maxPage = 0;
                int recordCont = commentsService.GetRecordCount("");
                if (recordCont % commentsService.pageCount == 0)
                {
                    maxPage = recordCont / commentsService.pageCount;
                }
                else
                {
                    maxPage = recordCont /commentsService.pageCount + 1;
                }
                if (pageNumber > maxPage)
                {
                    pageNumber = maxPage;
                }
                commentList =commentsService.FindAllComment(pageNumber);
                pageCode = PageUtil.genPagination("/admin/CommentManger.aspx", commentsService.GetRecordCount(""), pageNumber, commentsService.pageCount, "");

            }
        }
    }
}