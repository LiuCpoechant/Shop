using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Shop.Model;
using System.Collections;
using System.Text;
using Util;
namespace Shop.BLL
{
	/// <summary>
	/// GoodsService
	/// </summary>
	public partial class GoodsService
	{
        public int pageCount = 8;
		private readonly Shop.DAL.GoodsDao dal=new Shop.DAL.GoodsDao();
		public GoodsService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

        //得到最高浏览量商品
        public DataTable GetMax()
        {
            DataTable table = new DataTable();
            table.Compute("max(gview)", "");
            return table;

        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int smallid,int gid)
		{
			return dal.Exists(smallid,gid);
		}
        ///顶部查找商品
        public ArrayList Getsgname(int pageNumber, string sgname)
        {
            StringBuilder strWhere = new StringBuilder();
            if ( sgname != null && !"".Equals(sgname))
            {
                strWhere.Append("gname like '%" + sgname + "%'");
            }
            int recordCount = dal.GetRecordCount(strWhere.ToString());
            int maxPage = 0;
            if (recordCount % pageCount == 0)
            {
                maxPage = recordCount / pageCount;
            }
            else
            {
                maxPage = recordCount / pageCount + 1;
            }

            if (pageNumber > maxPage)
            {
                pageNumber = maxPage;
            }
            DataSet ds = dal.GetListByPage(strWhere.ToString(), "gid asc", (pageNumber - 1) * pageCount + 1, pageNumber * pageCount);
            List<Goods> goodsList = this.DataTableToList(ds.Tables[0]);
            string pageCode=PageUtil.genPagination("/goods/SearchGoods.aspx",recordCount,pageNumber,pageCount,"sgname="+sgname);
            ArrayList List = new ArrayList();
            List.Add(goodsList);    //0下标放userList
            List.Add(pageCode);    //1下标放pagecode
            return List;
        }

        ///获取smallcount 记录总数
        //public int GetSmallcount(string strWhere)
        //{
        //    return dal.GetSmallRecordCount(strWhere);
        //}
        ///FindAllGoods
        public List<Goods> FindAllGoodsList(int pageNumber,string strWhere)
        {
            DataSet ds = this.GetListByPage(strWhere, "gid asc", (pageNumber - 1) * pageCount + 1, pageNumber * pageCount);
            List<Goods> GoodsList = this.DataTableToList(ds.Tables[0]);
            return GoodsList;
        }
        ///多条件分页
        public ArrayList GetSmallList(int pageNumber, string goname, string bysmall, string iste, string isre)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append("gid >" + 0);/*生成出来的方法拼接时如果第一个为空则后面不为空and关键字报错，需要添加一个固定的第一个)*/
            if (goname != null && !"".Equals(goname))
            {
                strWhere.Append("gname like '%" + goname + "%'");
            }
            if (bysmall != null && !"".Equals(bysmall))
            {
                strWhere.Append("and smallid='" + bysmall + "'");
            } 
            if (iste != null && !"".Equals(iste))
            {
                strWhere.Append("and specialprice='" + iste + "'");
            }
            if (isre != null && !"".Equals(isre))
            {
                strWhere.Append("and hot='" + isre + "'");
            }
            int recordCount = dal.GetRecordCount(strWhere.ToString());
            int maxPage = 0;
            if (recordCount % pageCount == 0)
            {
                maxPage = recordCount / pageCount;
            }
            else
            {
                maxPage = recordCount / pageCount + 1;
            }

            if (pageNumber > maxPage)
            {
                pageNumber = maxPage;
            }
            DataSet ds = dal.GetListByPage(strWhere.ToString(), "gid asc", (pageNumber - 1) * pageCount + 1, pageNumber * pageCount);
            List<Goods> GoodsList = this.DataTableToList(ds.Tables[0]);
            string pageCode = PageUtil.genPagination("/admin/GoodsManger.aspx", recordCount, pageNumber, pageCount, strWhere.ToString());
            ArrayList list = new ArrayList();
            list.Add(GoodsList);
            list.Add(pageCode);
            return list;
        }
        ///添加或者保存
        public bool saveOrUpdate(Goods goods)
        {
            if (goods.gid > 0)
            {
                return dal.UpdateSmall(goods);
            }
            else
            {
                return dal.Add(goods) > 0 ? true : false;
            }
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Shop.Model.Goods model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Shop.Model.Goods model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int gid)
		{
			
			return dal.Delete(gid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int smallid,int gid)
		{
			
			return dal.Delete(smallid,gid);
		}
        ///根据外键smallid删除商品
        public bool DeleteBySmallId(int smallid)
        {
            return dal.DeleteBySmallId(smallid);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string gidlist )
		{
			return dal.DeleteList(gidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Shop.Model.Goods GetModel(int gid)
		{
			
			return dal.GetModel(gid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Shop.Model.Goods GetModelByCache(int gid)
		{
			
			string CacheKey = "GoodsModel-" + gid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(gid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Shop.Model.Goods)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Shop.Model.Goods> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        ///三表获取数据列表
        public List<Shop.Model.Goods> DataTableToGoodsList(DataTable dt)
        {
            List<Shop.Model.Goods> modelList = new List<Shop.Model.Goods>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Shop.Model.Goods model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToGoodsModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Shop.Model.Goods> DataTableToList(DataTable dt)
		{
			List<Shop.Model.Goods> modelList = new List<Shop.Model.Goods>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Shop.Model.Goods model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

