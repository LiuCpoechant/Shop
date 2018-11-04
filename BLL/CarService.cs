using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Shop.Model;
namespace Shop.BLL
{
	/// <summary>
	/// CarService
	/// </summary>
	public partial class CarService
	{
		private readonly Shop.DAL.CarDao dal=new Shop.DAL.CarDao();
		public CarService()
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
		public bool Exists(string orderid,int gid)
		{
			return dal.Exists(orderid,gid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Shop.Model.Car model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        /// 
        public bool UpdateCarid(Shop.Model.Car model)
        {
            return dal.UpdateCarid(model);
        }
		public bool Update(Shop.Model.Car model)
		{
			return dal.Update(model);
		}
        ///根据gid删除商品
        public bool DeleteById(int gid)
        {
            return dal.DeleteById(gid);
        }
        ///根据carids删除购物车的商品
        public bool DeleteByCarIds(string carids)
        {
            return dal.DeleteByCarIds(carids);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int carid)
		{
			
			return dal.Delete(carid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string orderid,int gid)
		{
			
			return dal.Delete(orderid,gid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string caridlist )
		{
			return dal.DeleteList(caridlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Shop.Model.Car GetModel(int carid)
		{
			
			return dal.GetModel(carid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Shop.Model.Car GetModelByCache(int carid)
		{
			
			string CacheKey = "CarModel-" + carid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(carid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Shop.Model.Car)objModel;
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
		public List<Shop.Model.Car> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Shop.Model.Car> DataTableToList(DataTable dt)
		{
			List<Shop.Model.Car> modelList = new List<Shop.Model.Car>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Shop.Model.Car model;
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

