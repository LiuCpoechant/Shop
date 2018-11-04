<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegRusult.aspx.cs" Inherits="WebApp.user.RegRusult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<title>Insert title here</title>
</head>
<body>
<div id="header" class="wrap">
	<%Server.Execute("/common/Top.aspx"); %>
</div>
<div id="register" class="wrap">
	<div class="shadow">
		<em class="corner lb"></em>
		<em class="corner rt"></em>
		<div class="box">
			<h1>易购物，乐生活</h1>
			<ul class="steps clearfix">
				<li class="finished"><em>填写注册信息</em></li><%--//斜体--%>
				<li class="last-current"><em>注册成功</em></li>
			</ul>
			<div class="msg">
				<p>恭喜：注册成功！</p>
				<p>正在进入首页...</p>
				<script type="text/javascript">
					setTimeout("location.href='/Index.aspx'",3000);//设置3秒跳转至首页
				</script>
			</div>
		</div>
	</div>
</div>
<div id="footer">
		<%Server.Execute("/common/Footer.aspx"); %>
</div>
</body>
</html>

