using System;
namespace Shop.Model
{
	/// <summary>
	/// Tag:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Tag
	{
		public Tag()
		{}
		#region Model
		private int _tagid;
		private int _adminid;
		private string _tagname;
		private string _taglink;
		/// <summary>
		/// 
		/// </summary>
		public int tagid
		{
			set{ _tagid=value;}
			get{return _tagid;}
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
		public string tagname
		{
			set{ _tagname=value;}
			get{return _tagname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string taglink
		{
			set{ _taglink=value;}
			get{return _taglink;}
		}
		#endregion Model

	}
}

