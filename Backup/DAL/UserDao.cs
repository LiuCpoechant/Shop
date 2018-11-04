using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Shop.DAL
{
	/// <summary>
	/// 数据访问类:UserDao
	/// </summary>
	public partial class UserDao
	{
		public UserDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("uid", "t_user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_user");
			strSql.Append(" where uid=@uid");
			SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4)
			};
			parameters[0].Value = uid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Shop.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_user(");
			strSql.Append("uname,upwd,unickname,usex,headphoto,urealname,udentity,uquestion1,uanswer1,uquestion2,uanswer2,uphone,uaddress,uemail,uregistertime)");
			strSql.Append(" values (");
			strSql.Append("@uname,@upwd,@unickname,@usex,@headphoto,@urealname,@udentity,@uquestion1,@uanswer1,@uquestion2,@uanswer2,@uphone,@uaddress,@uemail,@uregistertime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.VarChar,30),
					new SqlParameter("@upwd", SqlDbType.VarChar,20),
					new SqlParameter("@unickname", SqlDbType.VarChar,20),
					new SqlParameter("@usex", SqlDbType.VarChar,2),
					new SqlParameter("@headphoto", SqlDbType.VarChar,50),
					new SqlParameter("@urealname", SqlDbType.VarChar,30),
					new SqlParameter("@udentity", SqlDbType.VarChar,18),
					new SqlParameter("@uquestion1", SqlDbType.VarChar,50),
					new SqlParameter("@uanswer1", SqlDbType.VarChar,30),
					new SqlParameter("@uquestion2", SqlDbType.VarChar,50),
					new SqlParameter("@uanswer2", SqlDbType.VarChar,30),
					new SqlParameter("@uphone", SqlDbType.VarChar,11),
					new SqlParameter("@uaddress", SqlDbType.VarChar,200),
					new SqlParameter("@uemail", SqlDbType.VarChar,50),
					new SqlParameter("@uregistertime", SqlDbType.DateTime)};
			parameters[0].Value = model.uname;
			parameters[1].Value = model.upwd;
			parameters[2].Value = model.unickname;
			parameters[3].Value = model.usex;
			parameters[4].Value = model.headphoto;
			parameters[5].Value = model.urealname;
			parameters[6].Value = model.udentity;
			parameters[7].Value = model.uquestion1;
			parameters[8].Value = model.uanswer1;
			parameters[9].Value = model.uquestion2;
			parameters[10].Value = model.uanswer2;
			parameters[11].Value = model.uphone;
			parameters[12].Value = model.uaddress;
			parameters[13].Value = model.uemail;
			parameters[14].Value = model.uregistertime;

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
		public bool Update(Shop.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_user set ");
			strSql.Append("uname=@uname,");
			strSql.Append("upwd=@upwd,");
			strSql.Append("unickname=@unickname,");
			strSql.Append("usex=@usex,");
			strSql.Append("headphoto=@headphoto,");
			strSql.Append("urealname=@urealname,");
			strSql.Append("udentity=@udentity,");
			strSql.Append("uquestion1=@uquestion1,");
			strSql.Append("uanswer1=@uanswer1,");
			strSql.Append("uquestion2=@uquestion2,");
			strSql.Append("uanswer2=@uanswer2,");
			strSql.Append("uphone=@uphone,");
			strSql.Append("uaddress=@uaddress,");
			strSql.Append("uemail=@uemail,");
			strSql.Append("uregistertime=@uregistertime");
			strSql.Append(" where uid=@uid");
			SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.VarChar,30),
					new SqlParameter("@upwd", SqlDbType.VarChar,20),
					new SqlParameter("@unickname", SqlDbType.VarChar,20),
					new SqlParameter("@usex", SqlDbType.VarChar,2),
					new SqlParameter("@headphoto", SqlDbType.VarChar,50),
					new SqlParameter("@urealname", SqlDbType.VarChar,30),
					new SqlParameter("@udentity", SqlDbType.VarChar,18),
					new SqlParameter("@uquestion1", SqlDbType.VarChar,50),
					new SqlParameter("@uanswer1", SqlDbType.VarChar,30),
					new SqlParameter("@uquestion2", SqlDbType.VarChar,50),
					new SqlParameter("@uanswer2", SqlDbType.VarChar,30),
					new SqlParameter("@uphone", SqlDbType.VarChar,11),
					new SqlParameter("@uaddress", SqlDbType.VarChar,200),
					new SqlParameter("@uemail", SqlDbType.VarChar,50),
					new SqlParameter("@uregistertime", SqlDbType.DateTime),
					new SqlParameter("@uid", SqlDbType.Int,4)};
			parameters[0].Value = model.uname;
			parameters[1].Value = model.upwd;
			parameters[2].Value = model.unickname;
			parameters[3].Value = model.usex;
			parameters[4].Value = model.headphoto;
			parameters[5].Value = model.urealname;
			parameters[6].Value = model.udentity;
			parameters[7].Value = model.uquestion1;
			parameters[8].Value = model.uanswer1;
			parameters[9].Value = model.uquestion2;
			parameters[10].Value = model.uanswer2;
			parameters[11].Value = model.uphone;
			parameters[12].Value = model.uaddress;
			parameters[13].Value = model.uemail;
			parameters[14].Value = model.uregistertime;
			parameters[15].Value = model.uid;

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
		public bool Delete(int uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_user ");
			strSql.Append(" where uid=@uid");
			SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4)
			};
			parameters[0].Value = uid;

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
		public bool DeleteList(string uidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_user ");
			strSql.Append(" where uid in ("+uidlist + ")  ");
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
		public Shop.Model.User GetModel(int uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 uid,uname,upwd,unickname,usex,headphoto,urealname,udentity,uquestion1,uanswer1,uquestion2,uanswer2,uphone,uaddress,uemail,uregistertime from t_user ");
			strSql.Append(" where uid=@uid");
			SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4)
			};
			parameters[0].Value = uid;

			Shop.Model.User model=new Shop.Model.User();
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
		public Shop.Model.User DataRowToModel(DataRow row)
		{
			Shop.Model.User model=new Shop.Model.User();
			if (row != null)
			{
				if(row["uid"]!=null && row["uid"].ToString()!="")
				{
					model.uid=int.Parse(row["uid"].ToString());
				}
				if(row["uname"]!=null)
				{
					model.uname=row["uname"].ToString();
				}
				if(row["upwd"]!=null)
				{
					model.upwd=row["upwd"].ToString();
				}
				if(row["unickname"]!=null)
				{
					model.unickname=row["unickname"].ToString();
				}
				if(row["usex"]!=null)
				{
					model.usex=row["usex"].ToString();
				}
				if(row["headphoto"]!=null)
				{
					model.headphoto=row["headphoto"].ToString();
				}
				if(row["urealname"]!=null)
				{
					model.urealname=row["urealname"].ToString();
				}
				if(row["udentity"]!=null)
				{
					model.udentity=row["udentity"].ToString();
				}
				if(row["uquestion1"]!=null)
				{
					model.uquestion1=row["uquestion1"].ToString();
				}
				if(row["uanswer1"]!=null)
				{
					model.uanswer1=row["uanswer1"].ToString();
				}
				if(row["uquestion2"]!=null)
				{
					model.uquestion2=row["uquestion2"].ToString();
				}
				if(row["uanswer2"]!=null)
				{
					model.uanswer2=row["uanswer2"].ToString();
				}
				if(row["uphone"]!=null)
				{
					model.uphone=row["uphone"].ToString();
				}
				if(row["uaddress"]!=null)
				{
					model.uaddress=row["uaddress"].ToString();
				}
				if(row["uemail"]!=null)
				{
					model.uemail=row["uemail"].ToString();
				}
				if(row["uregistertime"]!=null && row["uregistertime"].ToString()!="")
				{
					model.uregistertime=DateTime.Parse(row["uregistertime"].ToString());
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
			strSql.Append("select uid,uname,upwd,unickname,usex,headphoto,urealname,udentity,uquestion1,uanswer1,uquestion2,uanswer2,uphone,uaddress,uemail,uregistertime ");
			strSql.Append(" FROM t_user ");
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
			strSql.Append(" uid,uname,upwd,unickname,usex,headphoto,urealname,udentity,uquestion1,uanswer1,uquestion2,uanswer2,uphone,uaddress,uemail,uregistertime ");
			strSql.Append(" FROM t_user ");
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
			strSql.Append("select count(1) FROM t_user ");
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
			strSql.Append(")AS Row, T.*  from t_user T ");
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
			parameters[0].Value = "t_user";
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

