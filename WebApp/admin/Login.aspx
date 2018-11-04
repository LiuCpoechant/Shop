<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>管理员登录</title>
<link  type="text/css" rel="stylesheet" src="/css/style.css"/>
<script type="text/javascript">
    function checkForm()
    {
        var adminname = $("#adminname").val();
        var adminpsw = $("#adminpsw").val();
        if (adminname == "")
        {
            $("#error").html("用户名不能为空！");
            return false;
        }
        if(adminpsw=="")
        {
            $("#error").html("密码不能为空！");
            return false;
        }
        if(imageCode=="")
        {
            $("#error").html("验证码不能为空！");
            return false;
        }
        return true;
    }
</script>
</head>
<body>
    <div id="header" class="wrap">
     <%Server.Execute("/common/Top.aspx"); %>
    </div>
    <div id="register" class="wrap">
	<div class="shadow">
		<em class="corner lb"></em> <em class="corner rt"></em>
		<div class="box">
			<h1>管理员登录界面</h1>
			<form runat="server" onsubmit="return checkForm()">
			<table>
				<tr>
					<td class="field">用户名：</td>
					<td><input class="text" type="text" id="adminname" name="adminname" value="admin"  />
					</td>
				</tr>
				<tr>
					<td class="field">密码：</td>
					<td><input class="text" type="password" id="adminpsw" name="adminpsw" value="123"     />
					</td>
				</tr>
				<tr>
					<td class="field">验证码：</td>
					<td><input  class="text" style="width: 60px;margin-right: 10px;"
								type="text" value="" name="imageCode" id="imageCode"/><img
								onclick="javascript:loadimage();" title="换一张试试" name="randImage"
								id="randImage" src="/user/ValidateCode.ashx" width="60" height="20" border="1"
								align="absmiddle">					
					</td>
				</tr>
                <tr>
                    <td><input type="hidden" name="adminid" /></td>
                    <td><label class="ui-green"><input type="submit" name="submit" value="立即登录" /> </label>&nbsp;&nbsp;&nbsp;&nbsp;
							<font id="error"  color="red"><%=error %></font>
					</td>
                </tr>
			</table>
		</form>
	</div>
	</div>
</div>
    <div id="footer">
         <%Server.Execute("/common/Footer.aspx"); %>
    </div>
</body>
</html>

