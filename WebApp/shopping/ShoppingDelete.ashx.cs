using Shop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.shopping
{
    /// <summary>
    /// ShoppingDelete 的摘要说明
    /// </summary>
    public class ShoppingDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            CarService carService = new CarService();

            if (context.Request["GoodsId"] != null)
            {
                int GoodsId = Int32.Parse(context.Request["GoodsId"]);
                bool b = carService.DeleteById(GoodsId);   //删除这个商品id的所有信息
                context.Response.Write(b);
                context.Response.Redirect("/shopping/ShoppingCar.aspx");
            }
                //批量删除
            else
            {
                string carids = context.Request["carids"];
                bool b1 = carService.DeleteByCarIds(carids);
                context.Response.Write(b1);
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}