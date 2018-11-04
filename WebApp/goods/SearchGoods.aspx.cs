using Shop.BLL;
using Shop.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.goods
{
    public partial class SearchGoods : System.Web.UI.Page
    {
        public string pageCode { get; set; }
        public string sgname { get; set; }
        public List<Notice> NoticeList { get; set; }
        public List<Goods> goodsList { get; set; }
        GoodsService goodsService=new GoodsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            NoticeService noticeService = new NoticeService();
            NoticeList = noticeService.GetModelList("");
            int pageNumber = 1;
            if (!Int32.TryParse(Request["page"], out pageNumber))
            {
                pageNumber = 1;
            }
            sgname = Request.Form["sgname"];
            ArrayList List = goodsService.Getsgname(pageNumber, sgname);
            goodsList = (List<Goods>)List[0];
            pageCode = List[1].ToString();
        }
    }
}