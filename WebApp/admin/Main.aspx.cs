using Shop.BLL;
using Shop.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.admin
{
    public partial class Main : System.Web.UI.Page
    {
        public int max { get; set; }
        public string jsonStr { get; set; }    
        public int gviewcount { get; set; }
        public List<Goods> goodsList { get; set; } 
        SmallClassService smallclassService = new SmallClassService();
        GoodsService goodsService = new GoodsService();
        VoteService voteService = new VoteService();
        protected void Page_Load(object sender, EventArgs e)
        {
            ////浏览最高商品                   

            //List<Goods> gviewList = goodsService.GetModelList(" max(gview) ");
            //max=(int) gviewList[1].gview;
            
            //max =(int) gviewList[0].gview;
            //for (int i = 0; i < goodsList.Count; i++)
            //{
            //    if (gviewList[i].gview > max)
            //    {
            //        max =(int)gviewList[i].gview;
            //    }
            //}
            if (Session["admin"] == null)
            {
                Response.Redirect("/admin/Login.aspx");
            }
            string flag = Request["flag"];

            if (flag == "smallname")
            {
                this.smallcountlist();
            }
          
            
        }
        //返回商品小类与其数量转换为json返回前台
        protected void smallcountlist()
        {
            List<SmallClass> smallclassList = new List<SmallClass>();
            smallclassList = smallclassService.GetModelList("");
            //
            foreach (SmallClass smallclass in smallclassList)
            {
                smallclass.smallclasscount = goodsService.GetRecordCount("smallid=" + smallclass.smallid);
            }
            //存放小类名以及其下商品的数量
            ArrayList smallcountlist = new ArrayList();
            for (int i = 0; i < smallclassList.Count; i++)
            {
                Hashtable ht = new Hashtable();
                if (smallclassList[i].smallclasscount > 0)
                {
                    ht.Add("smallname", smallclassList[i].smallname);
                    ht.Add("smallclasscount", "" + smallclassList[i].smallclasscount + "");
                }
                else
                {
                    ht.Add("smallname", smallclassList[i].smallname);
                    ht.Add("smallclasscount", "0");
                }
                smallcountlist.Add(ht);
            }
            //JavaScriptSerializer  生成JSON数据
            JavaScriptSerializer ser = new JavaScriptSerializer();

            jsonStr = ser.Serialize(smallcountlist);

            Response.Write(jsonStr);

            Response.End();
            
        }    
    }
}