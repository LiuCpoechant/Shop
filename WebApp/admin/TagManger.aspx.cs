using Shop.BLL;
using Shop.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace WebApp.admin
{
    public partial class TagManger : System.Web.UI.Page
    {
        public string pageCode { set; get; }
        public string tname { set; get; }
        public List<Tag> tagList { set; get; }
        TagService tagService = new TagService();
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
                int recordCont = tagService.GetRecordCount("");
                if (recordCont % tagService.pageCount == 0)
                {
                    maxPage = recordCont / tagService.pageCount;
                }
                else
                {
                    maxPage = recordCont / tagService.pageCount + 1;
                }
                if (pageNumber > maxPage)
                {
                    pageNumber = maxPage;
                }
                tagList = tagService.FindAllTag(pageNumber);
                pageCode = PageUtil.genPagination("/admin/TagManger.aspx",tagService.GetRecordCount(""),pageNumber,tagService.pageCount,"");

            }
        }
    }
}