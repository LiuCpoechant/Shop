using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Index : System.Web.UI.Page
    {
        public int t { get; set; }
        public string pageCode { get; set; }
        public Goods gview { get; set; }
        public List<Notice> NoticeList { get; set; }
        public List<Goods> GoodsList { get; set; }
        public List<Vote> voteList { get; set; }
        VoteService voteService = new VoteService();
        NoticeService noticeService = new NoticeService();
        GoodsService goodsService = new GoodsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];
            voteList = voteService.GetModelList("");
            NoticeList = noticeService.GetModelList("");
            GoodsList = goodsService.GetModelList("");
            if ("choice".Equals(flag))
            {
             this.choice(sender,e);
            }               
    }
        protected void choice(object sender, EventArgs e)
        {        
            int vid = Int32.Parse(Request["vid"]);
            t = Int32.Parse(Request["t"]);
            Vote vote = new Vote();
            vote = voteService.GetModel(vid);
            int total1 = (int)vote.vtotal1;
            int total2 = (int)vote.vtotal2;
            int total3 = (int)vote.vtotal3;
            int total4 = (int)vote.vtotal4;
            if (t == 1) 
            { 
              vote.vtotal1 = total1 + 1;
            }
            else if (t == 2) 
            {
              vote.vtotal2 = total2 + 1;
            }
            else if (t == 3)
            {
              vote.vtotal3 = total3 + 1;
            }
            else if (t == 4)
            {
               vote.vtotal4 = total4 + 1;
            }        
            if (voteService.Update(vote))
            {
                Response.Write(true);
                Response.End();
            }
            else
            {
                Response.Write(false);
                Response.End();
            }
        }
        
    }
}