using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace WebApp.admin
{
    public partial class SmallManger : System.Web.UI.Page
    {
        public int smallcount { get; set; }
        public string pageCode { get; set; }
        public List<Goods> goodsList { get; set; }
        public List<SmallClass> smallclassList { get; set; }
        public List<BigClass> bigclassList { get; set; }
        private GoodsService goodsService = new GoodsService();
        private SmallClassService smallclassService = new SmallClassService();
        private BigClassService bigclassService = new BigClassService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];
            if (Request["flag"] == null || "".Equals(flag))
            {
                this.show(sender, e);
            }
            else if ("SaveOrUpdate".Equals(flag))
            {
                this.SaveOrUpdate(sender, e);
            }
            else if ("delete".Equals(flag))
            {
                this.delete(sender, e);
            }

        }
        protected void show(object sender, EventArgs e)
        {
            int pageNumber = 1;
            if (!Int32.TryParse(Request["page"], out pageNumber))
            {
                pageNumber = 1;
            }
            int maxPage = 0;
            int recordCount=smallclassService.GetRecordCount("");
            if (recordCount % smallclassService.pageCount == 0)
            {
                maxPage = recordCount / smallclassService.pageCount;
            }
            else
            {
                maxPage = recordCount / smallclassService.pageCount + 1;
            }
            smallclassList = smallclassService.FindAllSmall(pageNumber);
            BigClass bigclass = new BigClass();
            bigclassList = bigclassService.GetModelList("");

            foreach (SmallClass smallclass in smallclassList)
            {
                smallclass.BigClassName = bigclassService.GetModel(smallclass.bigid).bigname;
            }
            pageCode = PageUtil.genPagination("/admin/SmallManger.aspx",recordCount,pageNumber,smallclassService.pageCount,"");
        }
        protected void SaveOrUpdate(object sender, EventArgs e)
        {
            int SmallId;
            if(!Int32.TryParse(Request["smallid"],out SmallId))
            {
                SmallId = 0;
            }
            string Smallname = Request["smallname"];
            int Bigname =Int32.Parse(Request["bigname"]);
            SmallClass smallclass = new SmallClass();
            smallclass.smallid = SmallId;
            smallclass.smallname = Smallname;
            smallclass.bigid = Bigname;
            if (smallclassService.SaveOrUpdate(smallclass))
            {
                Response.Write(true);
                Response.End();
            }
            else
            {
                Response.Write(false);
            }
          
        }
        protected void delete(object sender, EventArgs e)
        {
            int SmallId =Int32.Parse(Request["smallid"]); 
            bool b = smallclassService.DeleteSmall(SmallId);
            Response.Write(b);
            Response.End();
        }
    }
}