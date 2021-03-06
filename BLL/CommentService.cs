﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Shop.Model;
namespace Shop.BLL
{
	/// <summary>
	/// CommentService
	/// </summary>
	public partial class CommentService
	{
        public int pageCount = 5;
		private readonly Shop.DAL.CommentDao dal=new Shop.DAL.CommentDao();
		public CommentService()
		{}
		#region  BasicMethod

        //findAllComment
        public List<Comment> FindAllComment(int pageNumber)
        {
            DataSet ds = this.GetListByPage("", "comid asc", (pageNumber - 1) * pageCount + 1, pageNumber * pageCount);
            List<Comment> commentList = this.DataTableToList(ds.Tables[0]);
            return commentList;
        }

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
		public bool Exists(int comid)
		{
			return dal.Exists(comid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Shop.Model.Comment model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Shop.Model.Comment model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int comid)
		{
			
			return dal.Delete(comid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string comidlist )
		{
			return dal.DeleteList(comidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Shop.Model.Comment GetModel(int comid)
		{
			
			return dal.GetModel(comid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Shop.Model.Comment GetModelByCache(int comid)
		{
			
			string CacheKey = "CommentModel-" + comid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(comid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Shop.Model.Comment)objModel;
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
		public List<Shop.Model.Comment> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Shop.Model.Comment> DataTableToList(DataTable dt)
		{
			List<Shop.Model.Comment> modelList = new List<Shop.Model.Comment>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Shop.Model.Comment model;
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

