using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.admin
{
    public partial class VoteManger : System.Web.UI.Page
    {
        public string pageCode { get; set; }
        public List<Vote> voteList { get; set; }
        VoteService voteService = new VoteService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string flag=Request["flag"];
            if (flag == null)
            {
                this.show(sender, e);
            }
            else 
            if (flag == "save")
            {
                this.save(sender, e);
            }
      
        }
        protected void show(object sender, EventArgs e)
        {
            voteList = voteService.GetModelList("");
        }
        protected void save(object sender, EventArgs e)
        {
            int vid = Int32.Parse(Request["vid"]);
            Vote vote = new Vote();
            vote = voteService.GetModel(vid);
            vote.vcontent1 = Request["content1"];
            vote.vcontent2 = Request["content2"];
            vote.vcontent3 = Request["content3"];
            vote.vcontent4 = Request["content4"];
            vote.vtotal1=Int32.Parse(Request["total1"]);
            vote.vtotal2=Int32.Parse(Request["total2"]);
            vote.vtotal3=Int32.Parse(Request["total3"]);
            vote.vtotal4 = Int32.Parse(Request["total4"]);
           
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
            this.show(sender, e);
        }
    }
}