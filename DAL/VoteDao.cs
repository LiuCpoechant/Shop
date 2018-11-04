using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Shop.DAL
{
	/// <summary>
	/// 数据访问类:VoteDao
	/// </summary>
	public partial class VoteDao
	{
		public VoteDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("vid", "t_vote"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int vid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_vote");
			strSql.Append(" where vid=@vid");
			SqlParameter[] parameters = {
					new SqlParameter("@vid", SqlDbType.Int,4)
			};
			parameters[0].Value = vid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Shop.Model.Vote model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_vote(");
			strSql.Append("vcontent1,vcontent2,vcontent3,vcontent4,vtotal1,vtotal2,vtotal3,vtotal4)");
			strSql.Append(" values (");
			strSql.Append("@vcontent1,@vcontent2,@vcontent3,@vcontent4,@vtotal1,@vtotal2,@vtotal3,@vtotal4)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@vcontent1", SqlDbType.VarChar,20),
					new SqlParameter("@vcontent2", SqlDbType.VarChar,20),
					new SqlParameter("@vcontent3", SqlDbType.VarChar,20),
					new SqlParameter("@vcontent4", SqlDbType.VarChar,20),
					new SqlParameter("@vtotal1", SqlDbType.Int,4),
					new SqlParameter("@vtotal2", SqlDbType.Int,4),
					new SqlParameter("@vtotal3", SqlDbType.Int,4),
					new SqlParameter("@vtotal4", SqlDbType.Int,4)};
			parameters[0].Value = model.vcontent1;
			parameters[1].Value = model.vcontent2;
			parameters[2].Value = model.vcontent3;
			parameters[3].Value = model.vcontent4;
			parameters[4].Value = model.vtotal1;
			parameters[5].Value = model.vtotal2;
			parameters[6].Value = model.vtotal3;
			parameters[7].Value = model.vtotal4;

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
		public bool Update(Shop.Model.Vote model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_vote set ");
			strSql.Append("vcontent1=@vcontent1,");
			strSql.Append("vcontent2=@vcontent2,");
			strSql.Append("vcontent3=@vcontent3,");
			strSql.Append("vcontent4=@vcontent4,");
			strSql.Append("vtotal1=@vtotal1,");
			strSql.Append("vtotal2=@vtotal2,");
			strSql.Append("vtotal3=@vtotal3,");
			strSql.Append("vtotal4=@vtotal4");
			strSql.Append(" where vid=@vid");
			SqlParameter[] parameters = {
					new SqlParameter("@vcontent1", SqlDbType.VarChar,20),
					new SqlParameter("@vcontent2", SqlDbType.VarChar,20),
					new SqlParameter("@vcontent3", SqlDbType.VarChar,20),
					new SqlParameter("@vcontent4", SqlDbType.VarChar,20),
					new SqlParameter("@vtotal1", SqlDbType.Int,4),
					new SqlParameter("@vtotal2", SqlDbType.Int,4),
					new SqlParameter("@vtotal3", SqlDbType.Int,4),
					new SqlParameter("@vtotal4", SqlDbType.Int,4),
					new SqlParameter("@vid", SqlDbType.Int,4)};
			parameters[0].Value = model.vcontent1;
			parameters[1].Value = model.vcontent2;
			parameters[2].Value = model.vcontent3;
			parameters[3].Value = model.vcontent4;
			parameters[4].Value = model.vtotal1;
			parameters[5].Value = model.vtotal2;
			parameters[6].Value = model.vtotal3;
			parameters[7].Value = model.vtotal4;
			parameters[8].Value = model.vid;

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
		public bool Delete(int vid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_vote ");
			strSql.Append(" where vid=@vid");
			SqlParameter[] parameters = {
					new SqlParameter("@vid", SqlDbType.Int,4)
			};
			parameters[0].Value = vid;

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
		public bool DeleteList(string vidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_vote ");
			strSql.Append(" where vid in ("+vidlist + ")  ");
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
		public Shop.Model.Vote GetModel(int vid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 vid,vcontent1,vcontent2,vcontent3,vcontent4,vtotal1,vtotal2,vtotal3,vtotal4 from t_vote ");
			strSql.Append(" where vid=@vid");
			SqlParameter[] parameters = {
					new SqlParameter("@vid", SqlDbType.Int,4)
			};
			parameters[0].Value = vid;

			Shop.Model.Vote model=new Shop.Model.Vote();
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
		public Shop.Model.Vote DataRowToModel(DataRow row)
		{
			Shop.Model.Vote model=new Shop.Model.Vote();
			if (row != null)
			{
				if(row["vid"]!=null && row["vid"].ToString()!="")
				{
					model.vid=int.Parse(row["vid"].ToString());
				}
				if(row["vcontent1"]!=null)
				{
					model.vcontent1=row["vcontent1"].ToString();
				}
				if(row["vcontent2"]!=null)
				{
					model.vcontent2=row["vcontent2"].ToString();
				}
				if(row["vcontent3"]!=null)
				{
					model.vcontent3=row["vcontent3"].ToString();
				}
				if(row["vcontent4"]!=null)
				{
					model.vcontent4=row["vcontent4"].ToString();
				}
				if(row["vtotal1"]!=null && row["vtotal1"].ToString()!="")
				{
					model.vtotal1=int.Parse(row["vtotal1"].ToString());
				}
				if(row["vtotal2"]!=null && row["vtotal2"].ToString()!="")
				{
					model.vtotal2=int.Parse(row["vtotal2"].ToString());
				}
				if(row["vtotal3"]!=null && row["vtotal3"].ToString()!="")
				{
					model.vtotal3=int.Parse(row["vtotal3"].ToString());
				}
				if(row["vtotal4"]!=null && row["vtotal4"].ToString()!="")
				{
					model.vtotal4=int.Parse(row["vtotal4"].ToString());
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
			strSql.Append("select vid,vcontent1,vcontent2,vcontent3,vcontent4,vtotal1,vtotal2,vtotal3,vtotal4 ");
			strSql.Append(" FROM t_vote ");
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
			strSql.Append(" vid,vcontent1,vcontent2,vcontent3,vcontent4,vtotal1,vtotal2,vtotal3,vtotal4 ");
			strSql.Append(" FROM t_vote ");
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
			strSql.Append("select count(1) FROM t_vote ");
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
				strSql.Append("order by T.vid desc");
			}
			strSql.Append(")AS Row, T.*  from t_vote T ");
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
			parameters[0].Value = "t_vote";
			parameters[1].Value = "vid";
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

