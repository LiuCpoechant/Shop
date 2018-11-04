<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCenter.aspx.cs" Inherits="WebApp.user.UserCenter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<div id="header" class="wrap">
	<% Server.Execute("/common/Top.aspx"); %>
</div>
<div id="position" class="wrap">
		当前位置：用户中心
</div>
    <div class="wrap">
<div id="main" class="wrap">
		<div id="menu-mng" class="lefter">
            <div class="box">
                <dl>        <%-- //定义列表--%>
                    <dt>用户管理</dt>                                      <%--//定义列表中的项目--%>
                    <dd><a href="/user/UserDetail.aspx">个人信息管理</a></dd> <%--//定义列表中的定义部分--%>
                    <dt>订单管理</dt>
                    <dd><a href="/shopping/MyOrder.aspx">个人订单管理</a></dd>
                </dl>
            </div>
        </div>
        <div style="text-align: center;padding-top: 20px;font-size: 30px;height: 300px;"><font color="red">欢迎进入个人中心</font></div>
    </div>
        </div>
   
	
<div id="footer">
		<% Server.Execute("/common/Footer.aspx"); %>
</div>
</body>
</html>