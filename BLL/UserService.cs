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
	/// UserService
	/// </summary>
	public partial class UserService
	{
        public int pageCount = 5;
		private readonly Shop.DAL.UserDao dal=new Shop.DAL.UserDao();
		public UserService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}
        ///FindAllUser
        public List<User> FindAllUser(int pageNumber)
        {
            DataSet ds = this.GetListByPage("", "uid asc", (pageNumber - 1) * pageCount+1, pageNumber * pageCount);
            List<User> userList = this.DataTableToList(ds.Tables[0]);
            return userList;
        }
        public ArrayList GetUnameNickNameList(int pageNumber, string niname)
        {
            StringBuilder strWhere = new StringBuilder();

            if (niname != null && !"".Equals(niname))
            {
                strWhere.Append( "uname like '%"+ niname + "%'" );
                strWhere.Append("or unickname like '%" + niname + "%'");
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
            if (pageNumber > maxPage)
            {
                pageNumber = maxPage;
            }

            DataSet ds = dal.GetListByPage(strWhere.ToString(), "uid asc", (pageNumber - 1) * pageCount + 1, pageNumber * pageCount);

            List<User> userList = this.DataTableToList(ds.Tables[0]);
            string pageCode = PageUtil.genPagination("/admin/UserManger.aspx", recordCount, pageNumber, pageCount, "niname=" + niname);
            ArrayList List = new ArrayList();
            List.Add(userList);    //0下标放userList
            List.Add(pageCode);    //1下标放pagecode
            return List;
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int uid)
		{
			return dal.Exists(uid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Shop.Model.User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Shop.Model.User model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int uid)
		{
			
			return dal.Delete(uid);
		}
       
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string uidlist )
		{
			return dal.DeleteList(uidlist );
		}

        public Shop.Model.User GetByname(int uname)
        {

            return dal.GetByname(uname);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Shop.Model.User GetModel(int uid)
		{
			
			return dal.GetModel(uid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Shop.Model.User GetModelByCache(int uid)
		{
			
			string CacheKey = "UserModel-" + uid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(uid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Shop.Model.User)objModel;
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
		public List<Shop.Model.User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Shop.Model.User> DataTableToList(DataTable dt)
		{
			List<Shop.Model.User> modelList = new List<Shop.Model.User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Shop.Model.User model;
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

