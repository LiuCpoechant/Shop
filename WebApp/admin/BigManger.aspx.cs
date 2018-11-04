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
    public partial class BigManger : System.Web.UI.Page
    {
        public string pageCode { get; set; }
        public List<BigClass> bigclassList { get; set; }
        private BigClassService bigclassService = new BigClassService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];
            if (Request["flag"]==null||"".Equals(flag))
            {
                this.show(sender, e);
            }
            else if("SaveOrUpdate".Equals(flag))
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
            BigClass bigclass = new BigClass();
            bigclassList = bigclassService.GetModelList("");
        }
        protected void SaveOrUpdate(object sender,EventArgs e)
        {
            int BigId;
            if(!Int32.TryParse(Request["bigid"],out BigId))
            {
                BigId = 0;
            }
            string Bigname=Request["bigname"];
            BigClass bigclass = new BigClass();
            bigclass.bigid = BigId;
            bigclass.bigname = Bigname;
            bigclassService.SaveOrUpdate(bigclass);
            this.show(sender, e);
        }
        protected void delete(object sender, EventArgs e)
        {
            int BigId =Int32.Parse(Request["bigid"]);
            bool b = bigclassService.DeleteBigClass(BigId);
            Response.Write(b);
            Response.End();
        }
    }
}