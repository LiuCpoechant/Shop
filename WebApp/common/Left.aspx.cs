using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.commom
{
    public partial class Left : System.Web.UI.Page
    {
        public string msg { get; set; }
        public List<BigClass> BigClassList { get; set; }
        public List<SmallClass> SmallClassList { get; set; }
        public List<Goods> GoodsList { get; set; }
        public Goods Lately { get; set; } //最近浏览
        protected void Page_Load(object sender, EventArgs e)
        {

            BigClassService bigclassService = new BigClassService();

            SmallClassService smallclassService = new SmallClassService();
            GoodsService goodsService = new GoodsService();


            BigClassList = bigclassService.GetModelList("");

            foreach (BigClass bigclass in BigClassList)
            {
                bigclass.SmallClassList = smallclassService.GetModelList("bigid = " + bigclass.bigid);
            }


        }
    }
}