using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.shopping
{
    public partial class ShoppingCar : System.Web.UI.Page
    {
        public Goods Good { get; set; }

        Car car = new Car();

        public List<Goods> goodList { get; set; }
        public List<Car> carList { get; set; }

        CarService carService = new CarService();

        GoodsService goodsService = new GoodsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string flag = Request["flag"];

                if (flag == null || "".Equals(flag))
                {
                    this.show();
                }
                else if (flag == "add")
                {
                    this.addcar();
                }
                else if (flag == "shop")
                {
                    this.shop();
                }
                else if(flag == "money")
                {
                    this.money();
                }
            }
        }

        //查询购物车中所有信息
        protected void show()
        {
            Car carer = new Car();
            int? userid = carer.account;
            userid = ((User)Session["userList"]).uid;
            carList = carService.GetModelList("carstatus='" + 1 + "' and account='"+userid+"'");


            foreach (Car car in carList)
            {
                car.goods = goodsService.GetModel(car.gid);
            }
        }

        //加入购物车
        protected void addcar()
        {
            int GoodsId = Int32.Parse(Request["GoodsId"]);
            int carnumber = 1;
            Car car = new Car();
            car.gid = GoodsId;
            DateTime dt = DateTime.Now;
            string oid = dt.ToString("MMddHHmmss");
            //oid = oid.PadRight(10, '0');//设置为10位数，不足后面补为0
            string orderid = Convert.ToString(oid);
            car.orderid = orderid;
            car.carnumber = carnumber;
            car.carstatus = 1;
            car.account = ((User)Session["userList"]).uid;
            if (carService.Add(car) > 0)
            {
                Response.Write(true);

                Response.End();
            }
        }

        //购物
        protected void shop()
        {
            string GoodsId = Request["GoodsId"];
            //int uid = ((User)Session["userList"]).uid;
            int carnumber = 1;
            Car car = new Car();

            car.gid = Int32.Parse(GoodsId);
            DateTime dt = DateTime.Now;
            string oid = dt.ToString("MMddHHmmss");
            //oid = oid.PadRight(10, '0');//设置为10位数，不足后面补为0
            string orderid = Convert.ToString(oid);
            car.orderid = orderid;
            car.carstatus = 1;
            car.carnumber = carnumber;
            int? userid = car.account;
            car.account = ((User)Session["userList"]).uid;

            if (carService.Add(car) > 0)
            {
                carList = carService.GetModelList("carstatus='" + 1 + "' and account='"+userid+"'");
            }

            Response.Redirect("/shopping/ShoppingCar.aspx");

        }

        //结算
        protected void money()
        {
            OrderService orderService = new OrderService();

            Order order = new Order();

            order.uid = ((User)Session["userList"]).uid;

            string carids = Request["carids"];

            string[] ids = carids.Split(',');
            //添加到order表
            order.ordertime = DateTime.Now;

            DateTime dt = DateTime.Now;
            string oid = dt.ToString("MMddHHmmss");
            string orderid = oid;
            order.orderid = orderid;
            order.orderstatus = 0;
            order.orderprice = decimal.Parse(Request["pricecount"]);

            for (int i = 0; i < ids.Length; i++ )
            {
                Car car = carService.GetModel(Int32.Parse(ids[i]));
                car.carstatus = 3;
                //修改购物车商品状态
                car.orderid =orderid;
                carService.UpdateCarid(car);//更新购物车表 
            }
            if (orderService.Add(order))
            {
                Response.Write(true);
                Response.End();
            }
            else
            {
                Response.Write(false);
            }


        }
        
    }
}