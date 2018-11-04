using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Shop.DAL
{
	/// <summary>
	/// 数据访问类:BigClassDao
	/// </summary>
	public partial class BigClassDao
	{
		public BigClassDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("bigid", "t_bigClass"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int bigid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_bigClass");
			strSql.Append(" where bigid=@bigid");
			SqlParameter[] parameters = {
					new SqlParameter("@bigid", SqlDbType.Int,4)
			};
			parameters[0].Value = bigid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Shop.Model.BigClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_bigClass(");
			strSql.Append("bigname,bigsort)");
			strSql.Append(" values (");
			strSql.Append("@bigname,@bigsort)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@bigname", SqlDbType.VarChar,20),
					new SqlParameter("@bigsort", SqlDbType.Int,4)};
			parameters[0].Value = model.bigname;
			parameters[1].Value = model.bigsort;

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
		public bool Update(Shop.Model.BigClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_bigClass set ");
			strSql.Append("bigname=@bigname,");
			strSql.Append("bigsort=@bigsort");
			strSql.Append(" where bigid=@bigid");
			SqlParameter[] parameters = {
					new SqlParameter("@bigname", SqlDbType.VarChar,20),
					new SqlParameter("@bigsort", SqlDbType.Int,4),
					new SqlParameter("@bigid", SqlDbType.Int,4)};
			parameters[0].Value = model.bigname;
			parameters[1].Value = model.bigsort;
			parameters[2].Value = model.bigid;

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
		public bool Delete(int bigid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_bigClass ");
			strSql.Append(" where bigid=@bigid");
			SqlParameter[] parameters = {
					new SqlParameter("@bigid", SqlDbType.Int,4)
			};
			parameters[0].Value = bigid;

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
		public bool DeleteList(string bigidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_bigClass ");
			strSql.Append(" where bigid in ("+bigidlist + ")  ");
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
		public Shop.Model.BigClass GetModel(int bigid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 bigid,bigname,bigsort from t_bigClass ");
			strSql.Append(" where bigid=@bigid");
			SqlParameter[] parameters = {
					new SqlParameter("@bigid", SqlDbType.Int,4)
			};
			parameters[0].Value = bigid;

			Shop.Model.BigClass model=new Shop.Model.BigClass();
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
		public Shop.Model.BigClass DataRowToModel(DataRow row)
		{
			Shop.Model.BigClass model=new Shop.Model.BigClass();
			if (row != null)
			{
				if(row["bigid"]!=null && row["bigid"].ToString()!="")
				{
					model.bigid=int.Parse(row["bigid"].ToString());
				}
				if(row["bigname"]!=null)
				{
					model.bigname=row["bigname"].ToString();
				}
				if(row["bigsort"]!=null && row["bigsort"].ToString()!="")
				{
					model.bigsort=int.Parse(row["bigsort"].ToString());
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
			strSql.Append("select bigid,bigname,bigsort ");
			strSql.Append(" FROM t_bigClass ");
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
			strSql.Append(" bigid,bigname,bigsort ");
			strSql.Append(" FROM t_bigClass ");
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
			strSql.Append("select count(1) FROM t_bigClass ");
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
				strSql.Append("order by T.bigid desc");
			}
			strSql.Append(")AS Row, T.*  from t_bigClass T ");
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
			parameters[0].Value = "t_bigClass";
			parameters[1].Value = "bigid";
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

