<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="WebApp.user.UserDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script src="/js/jquery-1.11.1.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
 <div id="header" class="wrap">
 <%Server.Execute("/common/Top.aspx"); %>
    </div>

    <div id="position" class="wrap">
		当前位置：<a href="/user/UserCenter.aspx">个人中心</a>>用户管理
</div>
    <div id="main" class="wrap">
 <div class="manage">
	<table class="list">
		<tr>
            <th>ID</th>
			<th>头像</th>
			<th>真实姓名</th>
            <th>昵称</th>
            <th>性别</th>
			<th>邮箱</th>
			<th>手机号</th>
            <th>地址</th>
			<th>操作</th>
		</tr>
		<tr>
			<td class="first w4 c"><%=((Shop.Model.User)Session["userList"]).uid %></td>
			<td class="w1 c"><img alt="" src="<%=((Shop.Model.User)Session["userList"]).headphoto %>" style="width: 100px; height: 100px;" /></td>
			<td class="w2 c"><%=((Shop.Model.User)Session["userList"]).urealname%></td>
            <td class="w3 c"><%=((Shop.Model.User)Session["userList"]).unickname%></td>
             <td class="w1 c"><%=((Shop.Model.User)Session["userList"]).usex%></td>
			<td class="w2 c"><%=((Shop.Model.User)Session["userList"]).uemail%></td>
			<td class="w2 c"><%=((Shop.Model.User)Session["userList"]).uphone%></td>
            <td class="w1 c"><%=((Shop.Model.User)Session["userList"]).uaddress%></td>
			<td class="w1 c"><a href="/user/UserPwdValidate.aspx">修改</a></td>
		</tr>
	</table>
    </div>
</div>
</body>
</html>
