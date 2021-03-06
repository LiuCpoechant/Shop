﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Shop.Model;
namespace Shop.BLL
{
	/// <summary>
	/// TagService
	/// </summary>
	public partial class TagService
	{
        public int pageCount =4;
		private readonly Shop.DAL.TagDao dal=new Shop.DAL.TagDao();
		public TagService()
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
		public bool Exists(int adminid,int tagid)
		{
			return dal.Exists(adminid,tagid);
		}
        //findAllTag
        public List <Tag> FindAllTag(int pageNumber)
        {
            DataSet ds = this.GetListByPage("","tagid asc",(pageNumber-1)*pageCount+1,pageNumber*pageCount);
            List<Tag> tagList = this.DataTableToList(ds.Tables[0]);
            return tagList;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Shop.Model.Tag model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Shop.Model.Tag model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int tagid)
		{
			
			return dal.Delete(tagid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int adminid,int tagid)
		{
			
			return dal.Delete(adminid,tagid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string tagidlist )
		{
			return dal.DeleteList(tagidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Shop.Model.Tag GetModel(int tagid)
		{
			
			return dal.GetModel(tagid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Shop.Model.Tag GetModelByCache(int tagid)
		{
			
			string CacheKey = "TagModel-" + tagid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(tagid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Shop.Model.Tag)objModel;
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
		public List<Shop.Model.Tag> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Shop.Model.Tag> DataTableToList(DataTable dt)
		{
			List<Shop.Model.Tag> modelList = new List<Shop.Model.Tag>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Shop.Model.Tag model;
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

