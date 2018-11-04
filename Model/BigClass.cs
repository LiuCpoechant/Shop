using System;
using System.Collections.Generic;
namespace Shop.Model
{
	/// <summary>
	/// BigClass:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BigClass
	{
		public BigClass()
		{}
		#region Model
		private int _bigid;
		private string _bigname;
		private int? _bigsort;
		/// <summary>
		/// 
		/// </summary>
		public int bigid
		{
			set{ _bigid=value;}
			get{return _bigid;}
		}

        public List<SmallClass> SmallClassList { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string bigname
		{
			set{ _bigname=value;}
			get{return _bigname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? bigsort
		{
			set{ _bigsort=value;}
			get{return _bigsort;}
		}
		#endregion Model

	}
}

