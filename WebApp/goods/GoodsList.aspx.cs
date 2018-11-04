using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace WebApp.goods
{
    public partial class GoodsList : System.Web.UI.Page
    {
        public int SearchSmallId { get; set; }
        public int SearchBigId { get; set; }
        public string nav { get; set; }
        public string Code { get; set; }
        public string pageCode { get; set; }
        public List<Goods> goodsList { get; set; }
        public List<Notice> NoticeList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           
                //占位标签
                SearchBigId = Int32.Parse(Request["SearchBigId"]);
                BigClassService bigclassService = new BigClassService();
                BigClass bigClass = new BigClass();
                bigClass = bigclassService.GetModel(SearchBigId);
                nav = bigClass.bigname;

                SearchSmallId = Int32.Parse(Request["SearchSmallId"]);
                if(SearchSmallId>0)
               {
                SmallClassService smallclassService = new SmallClassService();
                SmallClass smallClass = new SmallClass();
                smallClass = smallclassService.GetModel(SearchSmallId);
                Code = smallClass.smallname;

                NoticeService noticeService = new NoticeService();
                NoticeList = noticeService.GetModelList("");
                //分页
                int pageNumber = 1;
                if (!Int32.TryParse(Request["page"], out pageNumber))
                {
                    pageNumber = 1;
                }
                GoodsService goodsService = new GoodsService();
                //goodsList = goodsService.GetModelList("smallid=" +SearchSmallId);
                int maxPage = 0;
                int recordCount = goodsService.GetRecordCount("smallid=" + SearchSmallId);
                if (recordCount % goodsService.pageCount == 0)
                {
                    maxPage = recordCount / goodsService.pageCount;
                }
                else
                {
                    maxPage = recordCount / goodsService.pageCount + 1;
                }
                if (pageNumber > maxPage)
                {
                    pageNumber = maxPage;
                }
                goodsList = goodsService.FindAllGoodsList(pageNumber, "smallid=" + SearchSmallId);
                pageCode = PageUtil.genPagination("/goods/GoodsList.aspx", recordCount, pageNumber, goodsService.pageCount, "SearchSmallId=" + SearchSmallId.ToString() + "&SearchBigId=" + SearchBigId);
              }
            else
                {
                   
                }
        }
    }
}