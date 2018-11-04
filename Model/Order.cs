using System;
using System.Collections.Generic;
namespace Shop.Model
{
	/// <summary>
	/// Order:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Order
	{
		public Order()
		{}
		#region Model
		private string _orderid;
		private int _uid;
		private DateTime? _ordertime;
		private int? _orderstatus;
		private decimal? _orderprice;
		/// <summary>
		/// 
		/// </summary>
		public string orderid
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
        public Car car { get; set; }

        public List<Car> carList { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ordertime
		{
			set{ _ordertime=value;}
			get{return _ordertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? orderstatus
		{
			set{ _orderstatus=value;}
			get{return _orderstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? orderprice
		{
			set{ _orderprice=value;}
			get{return _orderprice;}
		}
		#endregion Model

	}
}

