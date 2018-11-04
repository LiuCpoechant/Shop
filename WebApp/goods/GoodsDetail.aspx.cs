using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.goods
{
    public partial class GoodsDetail : System.Web.UI.Page
    {
        public Goods Good { get; set; }
        public int? viewtime { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string GoodsId = Request.QueryString["GoodsId"];
                GoodsService goodsService = new GoodsService();
                Good = goodsService.GetModel(Int32.Parse(GoodsId));

                if (Good.gview == null)//浏览量
                {
                    Good.gview = 0;
                    goodsService.Update(Good);
                }
                viewtime = Good.gview;
                viewtime++;
                Good.gview = viewtime;
                goodsService.Update(Good);
            }
        }
    }
}