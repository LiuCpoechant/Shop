using Shop.BLL;
using Shop.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.admin
{
    public partial class NoticeManger : System.Web.UI.Page
    {
        public string pageCode { set; get; }
        public string noname { set; get; }
        public List<Notice> noticeList { set; get; }
        NoticeService noticeService = new NoticeService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];
            if (flag == null || "".Equals(flag))
            {

               int pageNumber = 1;
               if (!Int32.TryParse(Request["page"], out pageNumber))
               {
                   pageNumber = 1;
               }
               noname = Request["unoname"];

               ArrayList List = noticeService.GetTitleContentList(pageNumber, noname);  //动态数组
               noticeList = (List<Notice>)List[0];
               pageCode = List[1].ToString();
            }
        }
    }
}