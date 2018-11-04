using System;
namespace Shop.Model
{
	/// <summary>
	/// Notice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Notice
	{
		public Notice()
		{}
		#region Model
		private int _noid;
		private int _adminid;
		private string _notitle;
		private string _nocontent;
		private DateTime? _notime;
		/// <summary>
		/// 
		/// </summary>
		public int noid
		{
			set{ _noid=value;}
			get{return _noid;}
		}
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
		public string notitle
		{
			set{ _notitle=value;}
			get{return _notitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nocontent
		{
			set{ _nocontent=value;}
			get{return _nocontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? notime
		{
			set{ _notime=value;}
			get{return _notime;}
		}
		#endregion Model

	}
}

