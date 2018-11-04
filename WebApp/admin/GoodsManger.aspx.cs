using Shop.BLL;
using Shop.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.admin
{
    public partial class GoodsManger : System.Web.UI.Page
    {
        public string goname { get; set; }
        public string bysmall { get; set; }
        public string iste { get; set; }
        public string isre { get; set; }
        public string pageCode { get; set; }
        public int SId { get; set; }
        public List<Goods> GoodsList { get; set; }
        public Goods goods = new Goods();
        public List<SmallClass> smallclassList { get; set; }
        private GoodsService goodsService = new GoodsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];
            if(Request["flag"]==null ||"".Equals(flag))
            {
                this.show(sender, e);
            }
            else if ("delete".Equals(flag))
            {
                this.delete(sender, e);
            }
            else if ("saveOrUpdate".Equals(flag))
            {
                this.saveOrUpdate(sender, e);
            }
        }

        protected void delete(object sender, EventArgs e)
        {
            string ids = Request["gids"];
            //单个删除
            if (ids == null)
            {
                int gid = Int32.Parse(Request["GoodsId"]);
                if (goodsService.Delete(gid))
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
                ///批量删除
            else
            {
                if (goodsService.DeleteList(ids))
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

        protected void saveOrUpdate(object sender, EventArgs e)
        {          
            int GId;
            if(!Int32.TryParse(Request["gid"],out GId))
            {
                GId = 0;
            }
            if (GId > 0)
            {
                Goods goods = goodsService.GetModel(GId);
            }
            else
            {
                goods.goodsphoto = "/image/goods/1.jpg";
            }
            string Gname = Request["gname"];
            string descript = Request["descript"];
            int smallid =Int32.Parse(Request["sid"]);  
            string goodsprice = Request["goodsprice"];
            int stock = Int32.Parse(Request["stock"]);
            int specialprice = Int32.Parse(Request["specialprice"]);
            int hot = Int32.Parse(Request["hot"]);
            int gview = Int32.Parse(Request["gview"]);
            int gcount = Int32.Parse(Request["gcount"]);
            HttpPostedFile file = Request.Files["goodsphoto"]; 
            string goodsphoto = goods.goodsphoto;
            if (file != null && !file.FileName.Equals(""))
            {    //判断文件是否为空

                string fileName = file.FileName;   //得到上传图片的文件名字


                string ext = Path.GetExtension(fileName);   //得到上传图片的文件扩展名

                if (ext == ".jpg" || ext == ".gif" || ext == ".png" || ext == ".jpeg" || ext == ".JPG") //设定文件的类型
                {
                    string newFileNames = Guid.NewGuid().ToString() + ext;

                    goodsphoto = "/image/goods/" + newFileNames;

                    string fileSavaPath = Request.MapPath(goodsphoto);

                    file.SaveAs(fileSavaPath);   //保存图片到服务器指定的目录中去
                }         
            }
            goods.gid = GId;
            goods.smallid = smallid;
            goods.gname = Gname;
            goods.goodsphoto = goodsphoto;
            goods.descript = descript;
            goods.goodsprice = decimal.Parse(goodsprice);
            goods.stock = stock;
            goods.specialprice = specialprice;
            goods.hot = hot;
            goods.gview = gview;
            goods.gcount = gcount;
            goodsService.saveOrUpdate(goods);
            this.show(sender, e);
        }

         protected void show(object sender, EventArgs e)
        {
            
                SmallClassService smallclassService = new SmallClassService();
                BigClassService bigclassService = new BigClassService();
                GoodsService goodsService = new GoodsService();
                smallclassList = smallclassService.GetModelList("");
                int pageNumber = 1;
                if (!Int32.TryParse(Request["page"], out pageNumber))
                {
                    pageNumber = 1;
                }
                if (IsPostBack)
                {
                    goname = Request.Form["goname"];
                    bysmall = Request.Form["bysmall"];  
                    iste = Request.Form["iste"];
                    isre = Request.Form["isre"];
                }
                else
                {
                    goname = Request.QueryString["goname"];
                    bysmall = Request.QueryString["bysmall"];
                    iste = Request.QueryString["iste"]; 
                    isre = Request.QueryString["isre"];              
                }
                ArrayList list = goodsService.GetSmallList(pageNumber, goname, bysmall,iste, isre);
                GoodsList = (List<Goods>)list[0];
                pageCode = list[1].ToString();
               //将小类封装到Goodsmodel中
                foreach (Goods goods in GoodsList)
                {
                   goods.smallclass = smallclassService.GetModel(goods.smallid);
                }
            
          }
    }
}