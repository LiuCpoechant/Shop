using System;
namespace Shop.Model
{
	/// <summary>
	/// User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class User
	{
		public User()
		{}
		#region Model
		private int _uid;
		private string _uname;
		private string _upwd;
		private string _unickname;
		private string _usex;
		private string _headphoto;
		private string _urealname;
		private string _udentity;
		private string _uquestion1;
		private string _uanswer1;
		private string _uquestion2;
		private string _uanswer2;
		private string _uphone;
		private string _uaddress;
		private string _uemail;
		private DateTime? _uregistertime;
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
		public string uname
		{
			set{ _uname=value;}
			get{return _uname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string upwd
		{
			set{ _upwd=value;}
			get{return _upwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unickname
		{
			set{ _unickname=value;}
			get{return _unickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string usex
		{
			set{ _usex=value;}
			get{return _usex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string headphoto
		{
			set{ _headphoto=value;}
			get{return _headphoto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string urealname
		{
			set{ _urealname=value;}
			get{return _urealname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string udentity
		{
			set{ _udentity=value;}
			get{return _udentity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uquestion1
		{
			set{ _uquestion1=value;}
			get{return _uquestion1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uanswer1
		{
			set{ _uanswer1=value;}
			get{return _uanswer1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uquestion2
		{
			set{ _uquestion2=value;}
			get{return _uquestion2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uanswer2
		{
			set{ _uanswer2=value;}
			get{return _uanswer2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uphone
		{
			set{ _uphone=value;}
			get{return _uphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uaddress
		{
			set{ _uaddress=value;}
			get{return _uaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uemail
		{
			set{ _uemail=value;}
			get{return _uemail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? uregistertime
		{
			set{ _uregistertime=value;}
			get{return _uregistertime;}
		}
		#endregion Model

	}
}

