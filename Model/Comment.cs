using System;
namespace Shop.Model
{
	/// <summary>
	/// Comment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Comment
	{
		public Comment()
		{}
		#region Model
		private int _comid;
		private string _uname;
		private string _comcontent;
		private DateTime? _comtime;
		private string _replycontent;
		private DateTime? _comreplytime;
		/// <summary>
		/// 
		/// </summary>
		public int comid
		{
			set{ _comid=value;}
			get{return _comid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uname
		{
			set{ _uname=value;}
			get{return _uname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comcontent
		{
			set{ _comcontent=value;}
			get{return _comcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? comtime
		{
			set{ _comtime=value;}
			get{return _comtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string replycontent
		{
			set{ _replycontent=value;}
			get{return _replycontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? comreplytime
		{
			set{ _comreplytime=value;}
			get{return _comreplytime;}
		}
		#endregion Model

	}
}

