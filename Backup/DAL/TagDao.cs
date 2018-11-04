using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Shop.DAL
{
	/// <summary>
	/// 数据访问类:TagDao
	/// </summary>
	public partial class TagDao
	{
		public TagDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("adminid", "t_tag"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int adminid,int tagid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_tag");
			strSql.Append(" where adminid=@adminid and tagid=@tagid ");
			SqlParameter[] parameters = {
					new SqlParameter("@adminid", SqlDbType.Int,4),
					new SqlParameter("@tagid", SqlDbType.Int,4)			};
			parameters[0].Value = adminid;
			parameters[1].Value = tagid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Shop.Model.Tag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_tag(");
			strSql.Append("adminid,tagname,taglink)");
			strSql.Append(" values (");
			strSql.Append("@adminid,@tagname,@taglink)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@adminid", SqlDbType.Int,4),
					new SqlParameter("@tagname", SqlDbType.VarChar,20),
					new SqlParameter("@taglink", SqlDbType.VarChar,50)};
			parameters[0].Value = model.adminid;
			parameters[1].Value = model.tagname;
			parameters[2].Value = model.taglink;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Shop.Model.Tag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_tag set ");
			strSql.Append("tagname=@tagname,");
			strSql.Append("taglink=@taglink");
			strSql.Append(" where tagid=@tagid");
			SqlParameter[] parameters = {
					new SqlParameter("@tagname", SqlDbType.VarChar,20),
					new SqlParameter("@taglink", SqlDbType.VarChar,50),
					new SqlParameter("@tagid", SqlDbType.Int,4),
					new SqlParameter("@adminid", SqlDbType.Int,4)};
			parameters[0].Value = model.tagname;
			parameters[1].Value = model.taglink;
			parameters[2].Value = model.tagid;
			parameters[3].Value = model.adminid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int tagid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_tag ");
			strSql.Append(" where tagid=@tagid");
			SqlParameter[] parameters = {
					new SqlParameter("@tagid", SqlDbType.Int,4)
			};
			parameters[0].Value = tagid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int adminid,int tagid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_tag ");
			strSql.Append(" where adminid=@adminid and tagid=@tagid ");
			SqlParameter[] parameters = {
					new SqlParameter("@adminid", SqlDbType.Int,4),
					new SqlParameter("@tagid", SqlDbType.Int,4)			};
			parameters[0].Value = adminid;
			parameters[1].Value = tagid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string tagidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_tag ");
			strSql.Append(" where tagid in ("+tagidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Shop.Model.Tag GetModel(int tagid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 tagid,adminid,tagname,taglink from t_tag ");
			strSql.Append(" where tagid=@tagid");
			SqlParameter[] parameters = {
					new SqlParameter("@tagid", SqlDbType.Int,4)
			};
			parameters[0].Value = tagid;

			Shop.Model.Tag model=new Shop.Model.Tag();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Shop.Model.Tag DataRowToModel(DataRow row)
		{
			Shop.Model.Tag model=new Shop.Model.Tag();
			if (row != null)
			{
				if(row["tagid"]!=null && row["tagid"].ToString()!="")
				{
					model.tagid=int.Parse(row["tagid"].ToString());
				}
				if(row["adminid"]!=null && row["adminid"].ToString()!="")
				{
					model.adminid=int.Parse(row["adminid"].ToString());
				}
				if(row["tagname"]!=null)
				{
					model.tagname=row["tagname"].ToString();
				}
				if(row["taglink"]!=null)
				{
					model.taglink=row["taglink"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select tagid,adminid,tagname,taglink ");
			strSql.Append(" FROM t_tag ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" tagid,adminid,tagname,taglink ");
			strSql.Append(" FROM t_tag ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_tag ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.tagid desc");
			}
			strSql.Append(")AS Row, T.*  from t_tag T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_tag";
			parameters[1].Value = "tagid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

