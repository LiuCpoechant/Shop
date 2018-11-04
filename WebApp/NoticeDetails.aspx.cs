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
    public partial class NoticeDetails : System.Web.UI.Page
    {
        public Notice Notices { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string NoticeId = Request.QueryString["NoticeId"];
            NoticeService noticeService = new NoticeService();
            Notices = noticeService.GetModel(Int32.Parse(NoticeId));

        }
    }
}