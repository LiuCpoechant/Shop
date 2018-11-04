using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Shop.DAL
{
	/// <summary>
	/// 数据访问类:GoodsDao
	/// </summary>
	public partial class GoodsDao
	{
		public GoodsDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("smallid", "t_goods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int smallid,int gid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_goods");
			strSql.Append(" where smallid=@smallid and gid=@gid ");
			SqlParameter[] parameters = {
					new SqlParameter("@smallid", SqlDbType.Int,4),
					new SqlParameter("@gid", SqlDbType.Int,4)			};
			parameters[0].Value = smallid;
			parameters[1].Value = gid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Shop.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_goods(");
			strSql.Append("smallid,gname,descript,goodsphoto,goodsprice,hot,hottime,specialprice,specialpricetime,bigname,smallname,stock,gview,gcount,gtime)");
			strSql.Append(" values (");
			strSql.Append("@smallid,@gname,@descript,@goodsphoto,@goodsprice,@hot,@hottime,@specialprice,@specialpricetime,@bigname,@smallname,@stock,@gview,@gcount,@gtime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@smallid", SqlDbType.Int,4),
					new SqlParameter("@gname", SqlDbType.VarChar,50),
					new SqlParameter("@descript", SqlDbType.VarChar,100),
					new SqlParameter("@goodsphoto", SqlDbType.VarChar,100),
					new SqlParameter("@goodsprice", SqlDbType.Float,8),
					new SqlParameter("@hot", SqlDbType.Int,4),
					new SqlParameter("@hottime", SqlDbType.DateTime),
					new SqlParameter("@specialprice", SqlDbType.Int,4),
					new SqlParameter("@specialpricetime", SqlDbType.DateTime),
					new SqlParameter("@bigname", SqlDbType.VarChar,20),
					new SqlParameter("@smallname", SqlDbType.VarChar,20),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@gview", SqlDbType.Int,4),
					new SqlParameter("@gcount", SqlDbType.Int,4),
					new SqlParameter("@gtime", SqlDbType.DateTime)};
			parameters[0].Value = model.smallid;
			parameters[1].Value = model.gname;
			parameters[2].Value = model.descript;
			parameters[3].Value = model.goodsphoto;
			parameters[4].Value = model.goodsprice;
			parameters[5].Value = model.hot;
			parameters[6].Value = model.hottime;
			parameters[7].Value = model.specialprice;
			parameters[8].Value = model.specialpricetime;
			parameters[9].Value = model.bigname;
			parameters[10].Value = model.smallname;
			parameters[11].Value = model.stock;
			parameters[12].Value = model.gview;
			parameters[13].Value = model.gcount;
			parameters[14].Value = model.gtime;

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
		public bool Update(Shop.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_goods set ");
			strSql.Append("gname=@gname,");
			strSql.Append("descript=@descript,");
			strSql.Append("goodsphoto=@goodsphoto,");
			strSql.Append("goodsprice=@goodsprice,");
			strSql.Append("hot=@hot,");
			strSql.Append("hottime=@hottime,");
			strSql.Append("specialprice=@specialprice,");
			strSql.Append("specialpricetime=@specialpricetime,");
			strSql.Append("bigname=@bigname,");
			strSql.Append("smallname=@smallname,");
			strSql.Append("stock=@stock,");
			strSql.Append("gview=@gview,");
			strSql.Append("gcount=@gcount,");
			strSql.Append("gtime=@gtime");
			strSql.Append(" where gid=@gid");
			SqlParameter[] parameters = {
					new SqlParameter("@gname", SqlDbType.VarChar,50),
					new SqlParameter("@descript", SqlDbType.VarChar,100),
					new SqlParameter("@goodsphoto", SqlDbType.VarChar,100),
					new SqlParameter("@goodsprice", SqlDbType.Float,8),
					new SqlParameter("@hot", SqlDbType.Int,4),
					new SqlParameter("@hottime", SqlDbType.DateTime),
					new SqlParameter("@specialprice", SqlDbType.Int,4),
					new SqlParameter("@specialpricetime", SqlDbType.DateTime),
					new SqlParameter("@bigname", SqlDbType.VarChar,20),
					new SqlParameter("@smallname", SqlDbType.VarChar,20),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@gview", SqlDbType.Int,4),
					new SqlParameter("@gcount", SqlDbType.Int,4),
					new SqlParameter("@gtime", SqlDbType.DateTime),
					new SqlParameter("@gid", SqlDbType.Int,4),
					new SqlParameter("@smallid", SqlDbType.Int,4)};
			parameters[0].Value = model.gname;
			parameters[1].Value = model.descript;
			parameters[2].Value = model.goodsphoto;
			parameters[3].Value = model.goodsprice;
			parameters[4].Value = model.hot;
			parameters[5].Value = model.hottime;
			parameters[6].Value = model.specialprice;
			parameters[7].Value = model.specialpricetime;
			parameters[8].Value = model.bigname;
			parameters[9].Value = model.smallname;
			parameters[10].Value = model.stock;
			parameters[11].Value = model.gview;
			parameters[12].Value = model.gcount;
			parameters[13].Value = model.gtime;
			parameters[14].Value = model.gid;
			parameters[15].Value = model.smallid;

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
		public bool Delete(int gid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_goods ");
			strSql.Append(" where gid=@gid");
			SqlParameter[] parameters = {
					new SqlParameter("@gid", SqlDbType.Int,4)
			};
			parameters[0].Value = gid;

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
		public bool Delete(int smallid,int gid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_goods ");
			strSql.Append(" where smallid=@smallid and gid=@gid ");
			SqlParameter[] parameters = {
					new SqlParameter("@smallid", SqlDbType.Int,4),
					new SqlParameter("@gid", SqlDbType.Int,4)			};
			parameters[0].Value = smallid;
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
		public bool DeleteList(string gidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_goods ");
			strSql.Append(" where gid in ("+gidlist + ")  ");
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
		public Shop.Model.Goods GetModel(int gid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 gid,smallid,gname,descript,goodsphoto,goodsprice,hot,hottime,specialprice,specialpricetime,bigname,smallname,stock,gview,gcount,gtime from t_goods ");
			strSql.Append(" where gid=@gid");
			SqlParameter[] parameters = {
					new SqlParameter("@gid", SqlDbType.Int,4)
			};
			parameters[0].Value = gid;

			Shop.Model.Goods model=new Shop.Model.Goods();
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
		public Shop.Model.Goods DataRowToModel(DataRow row)
		{
			Shop.Model.Goods model=new Shop.Model.Goods();
			if (row != null)
			{
				if(row["gid"]!=null && row["gid"].ToString()!="")
				{
					model.gid=int.Parse(row["gid"].ToString());
				}
				if(row["smallid"]!=null && row["smallid"].ToString()!="")
				{
					model.smallid=int.Parse(row["smallid"].ToString());
				}
				if(row["gname"]!=null)
				{
					model.gname=row["gname"].ToString();
				}
				if(row["descript"]!=null)
				{
					model.descript=row["descript"].ToString();
				}
				if(row["goodsphoto"]!=null)
				{
					model.goodsphoto=row["goodsphoto"].ToString();
				}
				if(row["goodsprice"]!=null && row["goodsprice"].ToString()!="")
				{
					model.goodsprice=decimal.Parse(row["goodsprice"].ToString());
				}
				if(row["hot"]!=null && row["hot"].ToString()!="")
				{
					model.hot=int.Parse(row["hot"].ToString());
				}
				if(row["hottime"]!=null && row["hottime"].ToString()!="")
				{
					model.hottime=DateTime.Parse(row["hottime"].ToString());
				}
				if(row["specialprice"]!=null && row["specialprice"].ToString()!="")
				{
					model.specialprice=int.Parse(row["specialprice"].ToString());
				}
				if(row["specialpricetime"]!=null && row["specialpricetime"].ToString()!="")
				{
					model.specialpricetime=DateTime.Parse(row["specialpricetime"].ToString());
				}
				if(row["bigname"]!=null)
				{
					model.bigname=row["bigname"].ToString();
				}
				if(row["smallname"]!=null)
				{
					model.smallname=row["smallname"].ToString();
				}
				if(row["stock"]!=null && row["stock"].ToString()!="")
				{
					model.stock=int.Parse(row["stock"].ToString());
				}
				if(row["gview"]!=null && row["gview"].ToString()!="")
				{
					model.gview=int.Parse(row["gview"].ToString());
				}
				if(row["gcount"]!=null && row["gcount"].ToString()!="")
				{
					model.gcount=int.Parse(row["gcount"].ToString());
				}
				if(row["gtime"]!=null && row["gtime"].ToString()!="")
				{
					model.gtime=DateTime.Parse(row["gtime"].ToString());
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
			strSql.Append("select gid,smallid,gname,descript,goodsphoto,goodsprice,hot,hottime,specialprice,specialpricetime,bigname,smallname,stock,gview,gcount,gtime ");
			strSql.Append(" FROM t_goods ");
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
			strSql.Append(" gid,smallid,gname,descript,goodsphoto,goodsprice,hot,hottime,specialprice,specialpricetime,bigname,smallname,stock,gview,gcount,gtime ");
			strSql.Append(" FROM t_goods ");
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
			strSql.Append("select count(1) FROM t_goods ");
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
				strSql.Append("order by T.gid desc");
			}
			strSql.Append(")AS Row, T.*  from t_goods T ");
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
			parameters[0].Value = "t_goods";
			parameters[1].Value = "gid";
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

