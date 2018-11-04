using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Shop.DAL
{
	/// <summary>
	/// 数据访问类:AdminDao
	/// </summary>
	public partial class AdminDao
	{
		public AdminDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("adminid", "t_admin"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int adminid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_admin");
			strSql.Append(" where adminid=@adminid");
			SqlParameter[] parameters = {
					new SqlParameter("@adminid", SqlDbType.Int,4)
			};
			parameters[0].Value = adminid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Shop.Model.Admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_admin(");
			strSql.Append("adminname,adminpsw,adminrealname,status)");
			strSql.Append(" values (");
			strSql.Append("@adminname,@adminpsw,@adminrealname,@status)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@adminname", SqlDbType.VarChar,30),
					new SqlParameter("@adminpsw", SqlDbType.VarChar,20),
					new SqlParameter("@adminrealname", SqlDbType.VarChar,20),
					new SqlParameter("@status", SqlDbType.Int,4)};
			parameters[0].Value = model.adminname;
			parameters[1].Value = model.adminpsw;
			parameters[2].Value = model.adminrealname;
			parameters[3].Value = model.status;

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
		public bool Update(Shop.Model.Admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_admin set ");
			strSql.Append("adminname=@adminname,");
			strSql.Append("adminpsw=@adminpsw,");
			strSql.Append("adminrealname=@adminrealname,");
			strSql.Append("status=@status");
			strSql.Append(" where adminid=@adminid");
			SqlParameter[] parameters = {
					new SqlParameter("@adminname", SqlDbType.VarChar,30),
					new SqlParameter("@adminpsw", SqlDbType.VarChar,20),
					new SqlParameter("@adminrealname", SqlDbType.VarChar,20),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@adminid", SqlDbType.Int,4)};
			parameters[0].Value = model.adminname;
			parameters[1].Value = model.adminpsw;
			parameters[2].Value = model.adminrealname;
			parameters[3].Value = model.status;
			parameters[4].Value = model.adminid;

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
		public bool Delete(int adminid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_admin ");
			strSql.Append(" where adminid=@adminid");
			SqlParameter[] parameters = {
					new SqlParameter("@adminid", SqlDbType.Int,4)
			};
			parameters[0].Value = adminid;

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
		public bool DeleteList(string adminidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_admin ");
			strSql.Append(" where adminid in ("+adminidlist + ")  ");
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
		public Shop.Model.Admin GetModel(int adminid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 adminid,adminname,adminpsw,adminrealname,status from t_admin ");
			strSql.Append(" where adminid=@adminid");
			SqlParameter[] parameters = {
					new SqlParameter("@adminid", SqlDbType.Int,4)
			};
			parameters[0].Value = adminid;

			Shop.Model.Admin model=new Shop.Model.Admin();
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
		public Shop.Model.Admin DataRowToModel(DataRow row)
		{
			Shop.Model.Admin model=new Shop.Model.Admin();
			if (row != null)
			{
				if(row["adminid"]!=null && row["adminid"].ToString()!="")
				{
					model.adminid=int.Parse(row["adminid"].ToString());
				}
				if(row["adminname"]!=null)
				{
					model.adminname=row["adminname"].ToString();
				}
				if(row["adminpsw"]!=null)
				{
					model.adminpsw=row["adminpsw"].ToString();
				}
				if(row["adminrealname"]!=null)
				{
					model.adminrealname=row["adminrealname"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
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
			strSql.Append("select adminid,adminname,adminpsw,adminrealname,status ");
			strSql.Append(" FROM t_admin ");
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
			strSql.Append(" adminid,adminname,adminpsw,adminrealname,status ");
			strSql.Append(" FROM t_admin ");
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
			strSql.Append("select count(1) FROM t_admin ");
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
				strSql.Append("order by T.adminid desc");
			}
			strSql.Append(")AS Row, T.*  from t_admin T ");
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
			parameters[0].Value = "t_admin";
			parameters[1].Value = "adminid";
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

