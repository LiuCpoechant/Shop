using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Shop.Model;
namespace Shop.BLL
{
	/// <summary>
	/// SmallClassService
	/// </summary>
	public partial class SmallClassService
	{
        public int pageCount = 6;
        private readonly GoodsService goodsService = new GoodsService();
		private readonly Shop.DAL.SmallClassDao dal=new Shop.DAL.SmallClassDao();
		public SmallClassService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int bigid,int smallid)
		{
			return dal.Exists(bigid,smallid);
		}
        ///添加还是修改操作，无id添加，有修改
        public bool SaveOrUpdate(SmallClass smallclass)
        {
            if (smallclass.smallid > 0)
            {
                return dal.Update(smallclass);
            }
            else
            {
                return dal.Add(smallclass) > 0 ? true : false;
            }
        }
        //删除小类，包括小类下所有商品
        public bool DeleteSmall(int smallid)
        {
            List<Goods> goodsList = goodsService.GetModelList("smallid=" + smallid);
            goodsService.DeleteBySmallId(smallid); //通过外键smallid删除所有商品
            return this.dal.Delete(smallid);
        }
        ///findallsmall
        public List<SmallClass> FindAllSmall(int pageNumber)
        {
            DataSet ds = this.GetListByPage("", "smallid asc", (pageNumber - 1) * pageCount + 1, pageNumber*pageCount);
            List<SmallClass> smallclassList = this.DataTableToList(ds.Tables[0]);
            return smallclassList;
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Shop.Model.SmallClass model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Shop.Model.SmallClass model)
		{
			return dal.Update(model);
		}
        ///根据外键BigId删除所有小类
        public bool DeleteByBigId(int bigid)
        {
            return dal.DeleteByBigId(bigid);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int smallid)
		{
			
			return dal.Delete(smallid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int bigid,int smallid)
		{
			
			return dal.Delete(bigid,smallid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string smallidlist )
		{
			return dal.DeleteList(smallidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Shop.Model.SmallClass GetModel(int smallid)
		{
			
			return dal.GetModel(smallid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Shop.Model.SmallClass GetModelByCache(int smallid)
		{
			
			string CacheKey = "SmallClassModel-" + smallid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(smallid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Shop.Model.SmallClass)objModel;
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
		public List<Shop.Model.SmallClass> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Shop.Model.SmallClass> DataTableToList(DataTable dt)
		{
			List<Shop.Model.SmallClass> modelList = new List<Shop.Model.SmallClass>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Shop.Model.SmallClass model;
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

