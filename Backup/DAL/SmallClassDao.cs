using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Shop.DAL
{
	/// <summary>
	/// 数据访问类:SmallClassDao
	/// </summary>
	public partial class SmallClassDao
	{
		public SmallClassDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("bigid", "t_smallClass"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int bigid,int smallid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_smallClass");
			strSql.Append(" where bigid=@bigid and smallid=@smallid ");
			SqlParameter[] parameters = {
					new SqlParameter("@bigid", SqlDbType.Int,4),
					new SqlParameter("@smallid", SqlDbType.Int,4)			};
			parameters[0].Value = bigid;
			parameters[1].Value = smallid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Shop.Model.SmallClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_smallClass(");
			strSql.Append("bigid,smallname,smallsort,bigname)");
			strSql.Append(" values (");
			strSql.Append("@bigid,@smallname,@smallsort,@bigname)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@bigid", SqlDbType.Int,4),
					new SqlParameter("@smallname", SqlDbType.VarChar,20),
					new SqlParameter("@smallsort", SqlDbType.Int,4),
					new SqlParameter("@bigname", SqlDbType.VarChar,20)};
			parameters[0].Value = model.bigid;
			parameters[1].Value = model.smallname;
			parameters[2].Value = model.smallsort;
			parameters[3].Value = model.bigname;

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
		public bool Update(Shop.Model.SmallClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_smallClass set ");
			strSql.Append("smallname=@smallname,");
			strSql.Append("smallsort=@smallsort,");
			strSql.Append("bigname=@bigname");
			strSql.Append(" where smallid=@smallid");
			SqlParameter[] parameters = {
					new SqlParameter("@smallname", SqlDbType.VarChar,20),
					new SqlParameter("@smallsort", SqlDbType.Int,4),
					new SqlParameter("@bigname", SqlDbType.VarChar,20),
					new SqlParameter("@smallid", SqlDbType.Int,4),
					new SqlParameter("@bigid", SqlDbType.Int,4)};
			parameters[0].Value = model.smallname;
			parameters[1].Value = model.smallsort;
			parameters[2].Value = model.bigname;
			parameters[3].Value = model.smallid;
			parameters[4].Value = model.bigid;

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
		public bool Delete(int smallid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_smallClass ");
			strSql.Append(" where smallid=@smallid");
			SqlParameter[] parameters = {
					new SqlParameter("@smallid", SqlDbType.Int,4)
			};
			parameters[0].Value = smallid;

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
		public bool Delete(int bigid,int smallid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_smallClass ");
			strSql.Append(" where bigid=@bigid and smallid=@smallid ");
			SqlParameter[] parameters = {
					new SqlParameter("@bigid", SqlDbType.Int,4),
					new SqlParameter("@smallid", SqlDbType.Int,4)			};
			parameters[0].Value = bigid;
			parameters[1].Value = smallid;

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
		public bool DeleteList(string smallidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_smallClass ");
			strSql.Append(" where smallid in ("+smallidlist + ")  ");
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
		public Shop.Model.SmallClass GetModel(int smallid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 smallid,bigid,smallname,smallsort,bigname from t_smallClass ");
			strSql.Append(" where smallid=@smallid");
			SqlParameter[] parameters = {
					new SqlParameter("@smallid", SqlDbType.Int,4)
			};
			parameters[0].Value = smallid;

			Shop.Model.SmallClass model=new Shop.Model.SmallClass();
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
		public Shop.Model.SmallClass DataRowToModel(DataRow row)
		{
			Shop.Model.SmallClass model=new Shop.Model.SmallClass();
			if (row != null)
			{
				if(row["smallid"]!=null && row["smallid"].ToString()!="")
				{
					model.smallid=int.Parse(row["smallid"].ToString());
				}
				if(row["bigid"]!=null && row["bigid"].ToString()!="")
				{
					model.bigid=int.Parse(row["bigid"].ToString());
				}
				if(row["smallname"]!=null)
				{
					model.smallname=row["smallname"].ToString();
				}
				if(row["smallsort"]!=null && row["smallsort"].ToString()!="")
				{
					model.smallsort=int.Parse(row["smallsort"].ToString());
				}
				if(row["bigname"]!=null)
				{
					model.bigname=row["bigname"].ToString();
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
			strSql.Append("select smallid,bigid,smallname,smallsort,bigname ");
			strSql.Append(" FROM t_smallClass ");
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
			strSql.Append(" smallid,bigid,smallname,smallsort,bigname ");
			strSql.Append(" FROM t_smallClass ");
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
			strSql.Append("select count(1) FROM t_smallClass ");
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
				strSql.Append("order by T.smallid desc");
			}
			strSql.Append(")AS Row, T.*  from t_smallClass T ");
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
			parameters[0].Value = "t_smallClass";
			parameters[1].Value = "smallid";
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

