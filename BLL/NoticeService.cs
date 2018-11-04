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
	/// NoticeService
	/// </summary>
	public partial class NoticeService
	{
        public int pageCount = 5;
		private readonly Shop.DAL.NoticeDao dal=new Shop.DAL.NoticeDao();
		public NoticeService()
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
		public bool Exists(int adminid,int noid)
		{
			return dal.Exists(adminid,noid);
		}

        ///条件分页
        public ArrayList GetTitleContentList(int pageNumber, string noname)
        {
            StringBuilder strWhere = new StringBuilder();
            if (noname != null || !"".Equals(noname))
            {
                strWhere.Append("notitle like '%"+noname+"%'");
                strWhere.Append("or nocontent like '%" + noname + "%'");
            }
            int recordCount = this.GetRecordCount(strWhere.ToString());
            int maxPage = 0;
            if (recordCount % pageCount == 0)
            {
                maxPage = recordCount / pageCount;
            }
            else
            {
                maxPage = recordCount / pageCount + 1;
            }
            if(pageNumber>maxPage)
            {
                pageNumber = maxPage;
            }
            DataSet ds = dal.GetListByPage(strWhere.ToString(), "noid asc", (pageNumber - 1) * pageCount + 1, pageNumber*pageCount);
            List<Notice> noticeList = this.DataTableToList(ds.Tables[0]);
            string pageCode=PageUtil.genPagination("/admin/NoticeManger.aspx",recordCount,pageNumber,pageCount,"noname="+noname);
            ArrayList List = new ArrayList();
            List.Add(noticeList);
            List.Add(pageCode);
            return List;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Shop.Model.Notice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Shop.Model.Notice model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int noid)
		{
			
			return dal.Delete(noid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int adminid,int noid)
		{
			
			return dal.Delete(adminid,noid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string noidlist )
		{
			return dal.DeleteList(noidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Shop.Model.Notice GetModel(int noid)
		{
			
			return dal.GetModel(noid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Shop.Model.Notice GetModelByCache(int noid)
		{
			
			string CacheKey = "NoticeModel-" + noid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(noid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Shop.Model.Notice)objModel;
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
		public List<Shop.Model.Notice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Shop.Model.Notice> DataTableToList(DataTable dt)
		{
			List<Shop.Model.Notice> modelList = new List<Shop.Model.Notice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Shop.Model.Notice model;
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

