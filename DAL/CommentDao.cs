using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Shop.DAL
{
	/// <summary>
	/// 数据访问类:CommentDao
	/// </summary>
	public partial class CommentDao
	{
		public CommentDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("comid", "t_comment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int comid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_comment");
			strSql.Append(" where comid=@comid");
			SqlParameter[] parameters = {
					new SqlParameter("@comid", SqlDbType.Int,4)
			};
			parameters[0].Value = comid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Shop.Model.Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_comment(");
			strSql.Append("uname,comcontent,comtime,replycontent,comreplytime)");
			strSql.Append(" values (");
			strSql.Append("@uname,@comcontent,@comtime,@replycontent,@comreplytime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.VarChar,30),
					new SqlParameter("@comcontent", SqlDbType.VarChar,500),
					new SqlParameter("@comtime", SqlDbType.DateTime),
					new SqlParameter("@replycontent", SqlDbType.VarChar,500),
					new SqlParameter("@comreplytime", SqlDbType.DateTime)};
			parameters[0].Value = model.uname;
			parameters[1].Value = model.comcontent;
			parameters[2].Value = model.comtime;
			parameters[3].Value = model.replycontent;
			parameters[4].Value = model.comreplytime;

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
		public bool Update(Shop.Model.Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_comment set ");
			strSql.Append("uname=@uname,");
			strSql.Append("comcontent=@comcontent,");
			strSql.Append("comtime=@comtime,");
			strSql.Append("replycontent=@replycontent,");
			strSql.Append("comreplytime=@comreplytime");
			strSql.Append(" where comid=@comid");
			SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.VarChar,30),
					new SqlParameter("@comcontent", SqlDbType.VarChar,500),
					new SqlParameter("@comtime", SqlDbType.DateTime),
					new SqlParameter("@replycontent", SqlDbType.VarChar,500),
					new SqlParameter("@comreplytime", SqlDbType.DateTime),
					new SqlParameter("@comid", SqlDbType.Int,4)};
			parameters[0].Value = model.uname;
			parameters[1].Value = model.comcontent;
			parameters[2].Value = model.comtime;
			parameters[3].Value = model.replycontent;
			parameters[4].Value = model.comreplytime;
			parameters[5].Value = model.comid;

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
		public bool Delete(int comid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_comment ");
			strSql.Append(" where comid=@comid");
			SqlParameter[] parameters = {
					new SqlParameter("@comid", SqlDbType.Int,4)
			};
			parameters[0].Value = comid;

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
		public bool DeleteList(string comidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_comment ");
			strSql.Append(" where comid in ("+comidlist + ")  ");
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
		public Shop.Model.Comment GetModel(int comid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 comid,uname,comcontent,comtime,replycontent,comreplytime from t_comment ");
			strSql.Append(" where comid=@comid");
			SqlParameter[] parameters = {
					new SqlParameter("@comid", SqlDbType.Int,4)
			};
			parameters[0].Value = comid;

			Shop.Model.Comment model=new Shop.Model.Comment();
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
		public Shop.Model.Comment DataRowToModel(DataRow row)
		{
			Shop.Model.Comment model=new Shop.Model.Comment();
			if (row != null)
			{
				if(row["comid"]!=null && row["comid"].ToString()!="")
				{
					model.comid=int.Parse(row["comid"].ToString());
				}
				if(row["uname"]!=null)
				{
					model.uname=row["uname"].ToString();
				}
				if(row["comcontent"]!=null)
				{
					model.comcontent=row["comcontent"].ToString();
				}
				if(row["comtime"]!=null && row["comtime"].ToString()!="")
				{
					model.comtime=DateTime.Parse(row["comtime"].ToString());
				}
				if(row["replycontent"]!=null)
				{
					model.replycontent=row["replycontent"].ToString();
				}
				if(row["comreplytime"]!=null && row["comreplytime"].ToString()!="")
				{
					model.comreplytime=DateTime.Parse(row["comreplytime"].ToString());
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
			strSql.Append("select comid,uname,comcontent,comtime,replycontent,comreplytime ");
			strSql.Append(" FROM t_comment ");
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
			strSql.Append(" comid,uname,comcontent,comtime,replycontent,comreplytime ");
			strSql.Append(" FROM t_comment ");
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
			strSql.Append("select count(1) FROM t_comment ");
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
				strSql.Append("order by T.comid desc");
			}
			strSql.Append(")AS Row, T.*  from t_comment T ");
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
			parameters[0].Value = "t_comment";
			parameters[1].Value = "comid";
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

