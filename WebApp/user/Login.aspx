<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.user.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<title>Insert title here</title>
<link type="text/css" rel="stylesheet" href="/css/style.css" />
<script type="text/javascript" src="/js/jquery-1.11.1.js"></script>
<script type="text/javascript">
	
	function checkForm(){
		 var uname=$("#uname").val();
		 var upwd=$("#upwd").val();
		 var imageCode=$("#imageCode").val();
		 if(uname==""){
			 $("#error").html("用户名不能为空！");
			 return false;
		 }
		 if(upwd==""){
			 $("#error").html("密码不能为空！");
			 return false;
		 }
		 if(imageCode==""){
			 $("#error").html("验证码不能为空！");
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
    </div>
<div id="register" class="wrap">
	<div class="shadow">
		<em class="corner lb"></em> <em class="corner rt"></em>
		<div class="box">
			<h1>欢迎登录到乐易购</h1>
			<form runat="server" onsubmit="return checkForm()">
			<table>
				<tr>
					<td class="field">用户名：</td>
					<td><input class="text" type="text" id="userName" name="uname" value="20180001"   />
					</td>
				</tr>
				<tr>
					<td class="field">密码：</td>
					<td><input class="text" type="password" id="upwd" name="upwd"  value="123456"   />
					</td>
				</tr>
				<tr>
					<td class="field">验证码：</td>
					<td><input  class="text" style="width: 60px;margin-right: 10px;"
								type="text" value="" name="imageCode" id="imageCode"><img
								onclick="javascript:loadimage();" title="换一张试试" name="randImage"
								id="randImage" src="/user/ValidateCode.ashx" width="60" height="20" border="1"
								align="absmiddle">					
					</td>
				</tr>
	
				<tr>
						<td>
							<input type="hidden" name="uid" />
						</td>
						<td><label class="ui-green"><input type="submit" name="submit" value="立即登录" />                    
						    </label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<a href="/user/findPwd.aspx" >忘记密码?</a> &nbsp;&nbsp;<font id="error" color="red"><%=error %></font></td>                      
				</tr>
			</table>
		</form>
	</div>
	</div>
</div>
    <div class="clearfix">

    </div>
<div id="footer">
	<% Server.Execute("/common/Footer.aspx"); %>
</div>

</body>
</html>
