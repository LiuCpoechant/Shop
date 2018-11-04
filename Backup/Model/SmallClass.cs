using System;
namespace Shop.Model
{
	/// <summary>
	/// SmallClass:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SmallClass
	{
		public SmallClass()
		{}
		#region Model
		private int _smallid;
		private int _bigid;
		private string _smallname;
		private int? _smallsort;
		private string _bigname;
		/// <summary>
		/// 
		/// </summary>
		public int smallid
		{
			set{ _smallid=value;}
			get{return _smallid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int bigid
		{
			set{ _bigid=value;}
			get{return _bigid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string smallname
		{
			set{ _smallname=value;}
			get{return _smallname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? smallsort
		{
			set{ _smallsort=value;}
			get{return _smallsort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bigname
		{
			set{ _bigname=value;}
			get{return _bigname;}
		}
		#endregion Model

	}
}

