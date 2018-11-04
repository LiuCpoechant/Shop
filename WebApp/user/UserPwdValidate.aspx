<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPwdValidate.aspx.cs" Inherits="WebApp.user.UserPwdValidate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <title>用户认证</title>
<link type="text/css" rel="stylesheet" href="/css/style.css" />
<script type="text/javascript" src="/js/jquery-1.11.1.js"></script>
<script type="text/javascript">
	
	function checkForm(){
		 var pwd=$("#pwd").val();
		 var upwd=$("#upwd").val();
		 
		 if(pwd==""){
			 $("#error").html("登录密码不能为空！");
			 return false;
		 }
		 if(upwd==""){
			 $("#error").html("确认密码不能为空！");
			 return false;
		 }
		 if (pwd != upwd)
		 {
		     $("#error").html("两次密码不一致请确认后重新输入！");
		     return false;
		 }
		 return true;
	}
	function loadimage() {
	    document.getElementById("randImage").src = "/user/ValidateCode.ashx?d=" + Math.random();
	}
	</script>

</head>
<body>
<div id="header" class="wrap">
		<% Server.Execute("/common/Top.aspx"); %>
<div id="register" class="wrap">
	<div class="shadow">
		<em class="corner lb"></em> <em class="corner rt"></em>
		<div class="box">
			<h1>请重新验证你的密码</h1>
			<form runat="server" onsubmit="return checkForm()">
			<table>
				<tr>
					<td class="field">登录密码：</td>
					<td><input class="text" type="password" id="pwd" name="pwd"   />
					</td>
				</tr>
				<tr>
					<td class="field">确认密码：</td>
					<td><input class="text" type="password" id="upwd" name="upwd"     />
					</td>
				</tr>
	
				<tr>
					<td><input type="hidden" name="user.status" value="1"/></td>
					<td><label class="ui-green"><input type="submit"
							name="submit" value="确    认" /> </label>&nbsp;&nbsp;&nbsp;&nbsp;
							<font id="error"  color="red"><%=error %></font>
					</td>
				</tr>
			</table>
		</form>
	</div>
	</div>
</div>
<div id="footer">
	<% Server.Execute("/common/Footer.aspx"); %>
</div>

</body>
</html>

