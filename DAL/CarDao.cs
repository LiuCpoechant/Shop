﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Shop.DAL
{
	/// <summary>
	/// 数据访问类:CarDao
	/// </summary>
	public partial class CarDao
	{
		public CarDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("gid", "t_car"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string orderid,int gid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_car");
			strSql.Append(" where orderid=@orderid and gid=@gid ");
			SqlParameter[] parameters = {
					new SqlParameter("@orderid", SqlDbType.VarChar,16),
					new SqlParameter("@gid", SqlDbType.Int,4)			};
			parameters[0].Value = orderid;
			parameters[1].Value = gid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Shop.Model.Car model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_car(");
			strSql.Append("orderid,gid,carnumber,carstatus,account)");
			strSql.Append(" values (");
			strSql.Append("@orderid,@gid,@carnumber,@carstatus,@account)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@orderid", SqlDbType.VarChar,16),
					new SqlParameter("@gid", SqlDbType.Int,4),
					new SqlParameter("@carnumber", SqlDbType.Int,4),
					new SqlParameter("@carstatus", SqlDbType.Int,4),
					new SqlParameter("@account", SqlDbType.Int,4)};
			parameters[0].Value = model.orderid;
			parameters[1].Value = model.gid;
			parameters[2].Value = model.carnumber;
			parameters[3].Value = model.carstatus;
			parameters[4].Value = model.account;

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

        ///更新
        public bool UpdateCarid(Shop.Model.Car model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_car set ");
            strSql.Append("carnumber=@carnumber,");
            strSql.Append("carstatus=@carstatus,");
            strSql.Append("account=@account,");
            strSql.Append("orderid=@orderid");
            strSql.Append(" where carid=@carid");
            SqlParameter[] parameters = {
					new SqlParameter("@carnumber", SqlDbType.Int,4),
					new SqlParameter("@carstatus", SqlDbType.Int,4),
					new SqlParameter("@account", SqlDbType.Int,4),
					new SqlParameter("@orderid", SqlDbType.VarChar,16),
					new SqlParameter("@gid", SqlDbType.Int,4),
					new SqlParameter("@carid", SqlDbType.Int,4)};
            parameters[0].Value = model.carnumber;
            parameters[1].Value = model.carstatus;
            parameters[2].Value = model.account;
            parameters[3].Value = model.orderid;
            parameters[4].Value = model.gid;
            parameters[5].Value = model.carid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Shop.Model.Car model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_car set ");
			strSql.Append("carnumber=@carnumber,");
			strSql.Append("carstatus=@carstatus,");
			strSql.Append("account=@account");
			strSql.Append(" where carid=@carid");
			SqlParameter[] parameters = {
					new SqlParameter("@carnumber", SqlDbType.Int,4),
					new SqlParameter("@carstatus", SqlDbType.Int,4),
					new SqlParameter("@account", SqlDbType.Int,4),
					new SqlParameter("@orderid", SqlDbType.VarChar,16),
					new SqlParameter("@gid", SqlDbType.Int,4),
					new SqlParameter("@carid", SqlDbType.Int,4)};
			parameters[0].Value = model.carnumber;
			parameters[1].Value = model.carstatus;
			parameters[2].Value = model.account;
			parameters[3].Value = model.orderid;
			parameters[4].Value = model.gid;
			parameters[5].Value = model.carid;

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
		public bool Delete(int carid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_car ");
			strSql.Append(" where carid=@carid");
			SqlParameter[] parameters = {
					new SqlParameter("@carid", SqlDbType.Int,4)
			};
			parameters[0].Value = carid;

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
        ///根据gid删除
        public bool DeleteById(int gid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_car ");
            strSql.Append(" where gid=@gid ");
            SqlParameter[] parameters = {
					new SqlParameter("@gid", SqlDbType.Int,4)
						                 };
            parameters[0].Value = gid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        ///批量删除carids
        public bool DeleteByCarIds(string carids)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_car ");
            strSql.Append(" where carid in("+carids+") ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public bool Delete(string orderid,int gid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_car ");
			strSql.Append(" where orderid=@orderid and gid=@gid ");
			SqlParameter[] parameters = {
					new SqlParameter("@orderid", SqlDbType.VarChar,16),
					new SqlParameter("@gid", SqlDbType.Int,4)			};
			parameters[0].Value = orderid;
			parameters[1].Value = gid;

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
		public bool DeleteList(string caridlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_car ");
			strSql.Append(" where carid in ("+caridlist + ")  ");
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
		public Shop.Model.Car GetModel(int carid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 orderid,gid,carid,carnumber,carstatus,account from t_car ");
			strSql.Append(" where carid=@carid");
			SqlParameter[] parameters = {
					new SqlParameter("@carid", SqlDbType.Int,4)
			};
			parameters[0].Value = carid;

			Shop.Model.Car model=new Shop.Model.Car();
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
		public Shop.Model.Car DataRowToModel(DataRow row)
		{
			Shop.Model.Car model=new Shop.Model.Car();
			if (row != null)
			{
				if(row["orderid"]!=null)
				{
					model.orderid=row["orderid"].ToString();
				}
				if(row["gid"]!=null && row["gid"].ToString()!="")
				{
					model.gid=int.Parse(row["gid"].ToString());
				}
				if(row["carid"]!=null && row["carid"].ToString()!="")
				{
					model.carid=int.Parse(row["carid"].ToString());
				}
				if(row["carnumber"]!=null && row["carnumber"].ToString()!="")
				{
					model.carnumber=int.Parse(row["carnumber"].ToString());
				}
				if(row["carstatus"]!=null && row["carstatus"].ToString()!="")
				{
					model.carstatus=int.Parse(row["carstatus"].ToString());
				}
				if(row["account"]!=null && row["account"].ToString()!="")
				{
					model.account=int.Parse(row["account"].ToString());
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
			strSql.Append("select orderid,gid,carid,carnumber,carstatus,account ");
			strSql.Append(" FROM t_car ");
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
			strSql.Append(" orderid,gid,carid,carnumber,carstatus,account ");
			strSql.Append(" FROM t_car ");
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
			strSql.Append("select count(1) FROM t_car ");
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
				strSql.Append("order by T.carid desc");
			}
			strSql.Append(")AS Row, T.*  from t_car T ");
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
			parameters[0].Value = "t_car";
			parameters[1].Value = "carid";
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

