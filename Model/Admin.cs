using System;
namespace Shop.Model
{
	/// <summary>
	/// Admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin
	{
		public Admin()
		{}
		#region Model
		private int _adminid;
		private string _adminname;
		private string _adminpsw;
		private string _adminrealname;
		private int? _status;
		/// <summary>
		/// 
		/// </summary>
		public int adminid
		{
			set{ _adminid=value;}
			get{return _adminid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string adminname
		{
			set{ _adminname=value;}
			get{return _adminname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string adminpsw
		{
			set{ _adminpsw=value;}
			get{return _adminpsw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string adminrealname
		{
			set{ _adminrealname=value;}
			get{return _adminrealname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

