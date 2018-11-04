using Shop.BLL;
using Shop.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.commom
{
    public partial class Top : System.Web.UI.Page
    {
        public List<BigClass> BigClassList { get; set; }
        public List<Car> CarList { get; set; }
        public List<Tag> TagList { get; set; }
        public int count { get; set; }
        public string sgname { get; set; }
        //public List<Goods> goodsList { get; set; }
        //GoodsService goodsService=new GoodsService();
        protected void Page_Load(object sender, EventArgs e)
        {
               
                //sgname = Request.Form["sgname"];
                
                BigClassService bigclassService = new BigClassService();
                CarService addorderService = new CarService();
                TagService tagService = new TagService();

                BigClassList = bigclassService.GetModelList("");
                CarList = addorderService.GetModelList("");
                TagList = tagService.GetModelList("");
                Car carer = new Car();
                int? userid = carer.account;
                if (Session["userList"] == null)
                {
                    count = addorderService.GetRecordCount("carstatus='" + 1 + "'");
                }
                else
                {
                    userid = ((User)Session["userList"]).uid;
                    count = addorderService.GetRecordCount("carstatus='" + 1 + "' and account='" + userid + "'");
                }
                if (count > 0)
                {
                    count = count;
                }
                else
                {
                    count = 0;
                }
            
            
        }
    }
}