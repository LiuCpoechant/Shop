using System;
namespace Shop.Model
{
	/// <summary>
	/// Question:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Question
	{
		public Question()
		{}
		#region Model
		private int _qid;
		private string _qquestion;
		/// <summary>
		/// 
		/// </summary>
		public int qid
		{
			set{ _qid=value;}
			get{return _qid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qquestion
		{
			set{ _qquestion=value;}
			get{return _qquestion;}
		}
		#endregion Model

	}
}

