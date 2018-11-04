using System;
namespace Shop.Model
{
	/// <summary>
	/// Car:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Car
	{
		public Car()
		{}
		#region Model
		private string _orderid;
		private int _gid;
		private int _carid;
		private int? _carnumber;
		private int? _carstatus;
		private int? _account;
		/// <summary>
		/// 
		/// </summary>
		public string orderid
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
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
		public int carid
		{
			set{ _carid=value;}
			get{return _carid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? carnumber
		{
			set{ _carnumber=value;}
			get{return _carnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? carstatus
		{
			set{ _carstatus=value;}
			get{return _carstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? account
		{
			set{ _account=value;}
			get{return _account;}
		}
		#endregion Model

	}
}

