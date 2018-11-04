using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Shop.DAL
{
	/// <summary>
	/// 数据访问类:OrderDao
	/// </summary>
	public partial class OrderDao
	{
		public OrderDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("uid", "t_order"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string orderid,int uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_order");
			strSql.Append(" where orderid=@orderid and uid=@uid ");
			SqlParameter[] parameters = {
					new SqlParameter("@orderid", SqlDbType.VarChar,16),
					new SqlParameter("@uid", SqlDbType.Int,4)			};
			parameters[0].Value = orderid;
			parameters[1].Value = uid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Shop.Model.Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_order(");
			strSql.Append("orderid,uid,ordertime,orderstatus,orderprice)");
			strSql.Append(" values (");
			strSql.Append("@orderid,@uid,@ordertime,@orderstatus,@orderprice)");
			SqlParameter[] parameters = {
					new SqlParameter("@orderid", SqlDbType.VarChar,16),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@ordertime", SqlDbType.DateTime),
					new SqlParameter("@orderstatus", SqlDbType.Int,4),
					new SqlParameter("@orderprice", SqlDbType.Float,8)};
			parameters[0].Value = model.orderid;
			parameters[1].Value = model.uid;
			parameters[2].Value = model.ordertime;
			parameters[3].Value = model.orderstatus;
			parameters[4].Value = model.orderprice;

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
		/// 更新一条数据
		/// </summary>
        /// 批量更新订单状态
        public bool UpdateType(Shop.Model.Order model,string orderids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_order set ");
            strSql.Append("orderstatus=@orderstatus,"); 
            strSql.Append(" where orderid in ("+orderids+")");
            SqlParameter[] parameters = {
					new SqlParameter("@orderstatus", SqlDbType.Int,4)	
                                        };
            parameters[0].Value = model.orderstatus;
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
		public bool Update(Shop.Model.Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_order set ");
			strSql.Append("ordertime=@ordertime,");
			strSql.Append("orderstatus=@orderstatus,");
			strSql.Append("orderprice=@orderprice");
			strSql.Append(" where orderid=@orderid and uid=@uid ");
			SqlParameter[] parameters = {
					new SqlParameter("@ordertime", SqlDbType.DateTime),
					new SqlParameter("@orderstatus", SqlDbType.Int,4),
					new SqlParameter("@orderprice", SqlDbType.Float,8),
					new SqlParameter("@orderid", SqlDbType.VarChar,16),
					new SqlParameter("@uid", SqlDbType.Int,4)};
			parameters[0].Value = model.ordertime;
			parameters[1].Value = model.orderstatus;
			parameters[2].Value = model.orderprice;
			parameters[3].Value = model.orderid;
			parameters[4].Value = model.uid;

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
        //批量删除deletebuids
        public bool DeleteByIds(string orderids)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_order ");
            strSql.Append(" where orderid in ("+orderids+")");
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
        /// deletebyid
        public bool DeleteById(string orderid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_order ");
            strSql.Append(" where orderid=@orderid");
            SqlParameter[] parameters = {
					new SqlParameter("@orderid", SqlDbType.VarChar,16)
                                        };
            parameters[0].Value = orderid;
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
		public bool Delete(string orderid,int uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_order ");
			strSql.Append(" where orderid=@orderid and uid=@uid ");
			SqlParameter[] parameters = {
					new SqlParameter("@orderid", SqlDbType.VarChar,16),
					new SqlParameter("@uid", SqlDbType.Int,4)			};
			parameters[0].Value = orderid;
			parameters[1].Value = uid;

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
		/// 得到一个对象实体
		/// </summary>
		public Shop.Model.Order GetModel(string orderid,int uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 orderid,uid,ordertime,orderstatus,orderprice from t_order ");
			strSql.Append(" where orderid=@orderid and uid=@uid ");
			SqlParameter[] parameters = {
					new SqlParameter("@orderid", SqlDbType.VarChar,16),
					new SqlParameter("@uid", SqlDbType.Int,4)			};
			parameters[0].Value = orderid;
			parameters[1].Value = uid;

			Shop.Model.Order model=new Shop.Model.Order();
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

        public Shop.Model.Order GetOrderModel(string orderid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 orderid,uid,ordertime,orderstatus,orderprice from t_order ");
            strSql.Append(" where orderid=@orderid");
            SqlParameter[] parameters = {
					new SqlParameter("@orderid", SqlDbType.VarChar,16)
								};
            parameters[0].Value = orderid;
            Shop.Model.Order model = new Shop.Model.Order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
		public Shop.Model.Order DataRowToModel(DataRow row)
		{
			Shop.Model.Order model=new Shop.Model.Order();
			if (row != null)
			{
				if(row["orderid"]!=null)
				{
					model.orderid=row["orderid"].ToString();
				}
				if(row["uid"]!=null && row["uid"].ToString()!="")
				{
					model.uid=int.Parse(row["uid"].ToString());
				}
				if(row["ordertime"]!=null && row["ordertime"].ToString()!="")
				{
					model.ordertime=DateTime.Parse(row["ordertime"].ToString());
				}
				if(row["orderstatus"]!=null && row["orderstatus"].ToString()!="")
				{
					model.orderstatus=int.Parse(row["orderstatus"].ToString());
				}
				if(row["orderprice"]!=null && row["orderprice"].ToString()!="")
				{
					model.orderprice=decimal.Parse(row["orderprice"].ToString());
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
			strSql.Append("select orderid,uid,ordertime,orderstatus,orderprice ");
			strSql.Append(" FROM t_order ");
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
			strSql.Append(" orderid,uid,ordertime,orderstatus,orderprice ");
			strSql.Append(" FROM t_order ");
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
			strSql.Append("select count(1) FROM t_order ");
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
				strSql.Append("order by T.uid desc");
			}
			strSql.Append(")AS Row, T.*  from t_order T ");
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
			parameters[0].Value = "t_order";
			parameters[1].Value = "uid";
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

