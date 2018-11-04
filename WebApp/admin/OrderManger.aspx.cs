using Shop.BLL;
using Shop.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.admin
{
    public partial class OrderManger : System.Web.UI.Page
    {
        public string otype { get; set; }
        public string oid { get; set; }
        public List<Car> carList { get; set; }
        public List<Order> orderList { get; set; }
        public string pageCode { get; set; }
        OrderService orderService = new OrderService();
        CarService carService = new CarService();
        GoodsService goodsService = new GoodsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];
            if(flag==null||"".Equals(flag))
            {
                this.show(sender, e);
            }
            else if (flag == "delete")
            {
                this.delete(sender, e);
            }
            else if (flag == "deleteList")
            {
                this.deleteList(sender, e);
            }
            else if (flag == "altertype")
            {
                this.altertype(sender, e);
            }
           
            
        }
        protected void show(object sender, EventArgs e)
        {
            
                int pageNumber = 1;
                if (!Int32.TryParse(Request["page"], out pageNumber))
                {
                    pageNumber = 1;
                }
                oid = Request["oid"];
                otype = Request["otype"];
                ArrayList List = orderService.Getoid(pageNumber, oid, otype);
                orderList = (List<Order>)List[0];
                //orderList = orderService.GetModelList("");
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
            string orderid = Request["orderId"];
            bool b = orderService.DeleteById(orderid);
            Response.Write(b);
            Response.End();
        }
        protected void deleteList(object sender, EventArgs e)
        {
            string orderids = Request["orderids"];
            bool b = orderService.DeleteByIds(orderids);
            Response.Write(b);
            Response.End();    
        }
        protected void altertype(object sender, EventArgs e)
        {
            string orderids = Request["ids"];
            int type=Int32.Parse(Request["status"]);
            string[] ids = orderids.Split(',');
            Order order = new Order();
            for (int i = 0; i < ids.Length; i++)
            {           
                order = orderService.GetOrderModel(ids[i]);
                order.orderstatus = type;
                orderService.Update(order);               
            }
            if (orderService.Update(order))
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