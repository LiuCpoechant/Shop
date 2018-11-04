using System;
namespace Shop.Model
{
	/// <summary>
	/// Vote:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Vote
	{
		public Vote()
		{}
		#region Model
		private int _vid;
		private string _vcontent1;
		private string _vcontent2;
		private string _vcontent3;
		private string _vcontent4;
		private int? _vtotal1;
		private int? _vtotal2;
		private int? _vtotal3;
		private int? _vtotal4;
		/// <summary>
		/// 
		/// </summary>
		public int vid
		{
			set{ _vid=value;}
			get{return _vid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vcontent1
		{
			set{ _vcontent1=value;}
			get{return _vcontent1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vcontent2
		{
			set{ _vcontent2=value;}
			get{return _vcontent2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vcontent3
		{
			set{ _vcontent3=value;}
			get{return _vcontent3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vcontent4
		{
			set{ _vcontent4=value;}
			get{return _vcontent4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? vtotal1
		{
			set{ _vtotal1=value;}
			get{return _vtotal1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? vtotal2
		{
			set{ _vtotal2=value;}
			get{return _vtotal2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? vtotal3
		{
			set{ _vtotal3=value;}
			get{return _vtotal3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? vtotal4
		{
			set{ _vtotal4=value;}
			get{return _vtotal4;}
		}
		#endregion Model

	}
}

