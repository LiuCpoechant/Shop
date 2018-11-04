using Shop.BLL;
using Shop.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.shopping
{
    public partial class MyOrder : System.Web.UI.Page
    {
        public string searchid { get;set;}
        public List<Car> carList { get; set; }
        public List<Order> orderList { get; set; }
        public string pageCode { get; set; }

        public int uid { get; set; }

        OrderService orderService = new OrderService();
        CarService carService = new CarService();
        GoodsService goodsService = new GoodsService();
        Order orders = new Order();

        protected void Page_Load(object sender, EventArgs e)
        {
          
                //判断是否登录
                if (Session["userlist"] != null)
                {
                    uid = ((User)Session["userlist"]).uid;
                }
                else
                {
                    Response.Redirect("/user/Login.aspx");
                }
                //根据参数执行不同的功能
                string flag = Request["flag"];
                if (flag == null || "".Equals(flag))
                {
                    this.show(sender, e);
                }
                else if (flag == "delete")
                {
                    this.delete(sender, e);
                }
                else if (flag == "receive")
                {
                    this.receive(sender, e);
                } 
        }
        protected void receive(object sender, EventArgs e)
        {
            string s =Request["orderid"];
            string orderId=s.PadLeft(10, '0');//10位不足前面补0
            orders=orderService.GetModel(orderId,uid);
            orders.orderstatus = 3;
            if (orderService.Update(orders))
            {
                Response.Write(true);
                Response.End();
            }
            this.show(sender, e);
        }
        protected void show(object sender, EventArgs e)
        {
                int pageNumber = 1;
                if (!Int32.TryParse(Request["page"], out pageNumber))
                {
                    pageNumber = 1;
                }  
                searchid = Request["searchid"];
                ArrayList List = orderService.Getsearchid(pageNumber, searchid,uid);
                orderList = (List<Order>)List[0];
                //orderList = orderService.GetModelList("uid=" + uid);
                foreach (Order order in orderList)
                {
                    order.carList = carService.GetModelList("orderid=" + order.orderid);

                    foreach (Car car in order.carList)
                    {
                        car.goodlist = goodsService.GetModelList("gid=" + car.gid);
                    }
                }
                pageCode = List[1].ToString();    
        }
        protected void delete(object sender, EventArgs e)
        {
            string s = Request["orderId"];
            string orderId = s.PadLeft(10, '0');//10位不足前面补0
            bool b = orderService.Delete(orderId, uid);
            Response.Write(b);
            Response.End();
        }
    }
}