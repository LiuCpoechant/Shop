using System;
namespace Shop.Model
{
	/// <summary>
	/// Goods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Goods
	{
		public Goods()
		{}
		#region Model
		private int _gid;
		private int _smallid;
		private string _gname;
		private string _descript;
		private string _goodsphoto;
		private decimal? _goodsprice;
		private int? _hot;
		private DateTime? _hottime;
		private int? _specialprice;
		private DateTime? _specialpricetime;
		private string _bigname;
		private string _smallname;
		private int? _stock;
		private int? _gview;
		private int? _gcount;
		private DateTime? _gtime;
		/// <summary>
		/// 
		/// </summary>
		public int gid
		{
			set{ _gid=value;}
			get{return _gid;}
		}
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
		public string gname
		{
			set{ _gname=value;}
			get{return _gname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string descript
		{
			set{ _descript=value;}
			get{return _descript;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodsphoto
		{
			set{ _goodsphoto=value;}
			get{return _goodsphoto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? goodsprice
		{
			set{ _goodsprice=value;}
			get{return _goodsprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? hot
		{
			set{ _hot=value;}
			get{return _hot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? hottime
		{
			set{ _hottime=value;}
			get{return _hottime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? specialprice
		{
			set{ _specialprice=value;}
			get{return _specialprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? specialpricetime
		{
			set{ _specialpricetime=value;}
			get{return _specialpricetime;}
		}
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
		public string smallname
		{
			set{ _smallname=value;}
			get{return _smallname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? stock
		{
			set{ _stock=value;}
			get{return _stock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? gview
		{
			set{ _gview=value;}
			get{return _gview;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? gcount
		{
			set{ _gcount=value;}
			get{return _gcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? gtime
		{
			set{ _gtime=value;}
			get{return _gtime;}
		}
		#endregion Model

	}
}

