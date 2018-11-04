<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="WebApp.Help" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css" >
        .bg1{                                      
            width: 960px;
            height:650px;
            margin: 0 auto;
            background: url(/image/bg1.jpg) no-repeat center;    <%--图片居中--%>          
        }
</style>
</head>
<body>
    <div id="header" class="wrap">
	<%Server.Execute("/common/Top.aspx"); %>
</div>
	<div class="bg1" style="align-content:center">
        <h2 style=" text-align:center; padding-top:40px; color:#00ff21; font-size:30px;">帮助中心</h2>
       <h3 style=" text-align:left;font-size:20px;padding-top:40px; color:#00ff90">
           1.用户注册<br />
           2.用户登录(登录后才能享用更多权限)<br />
           3.个人中心<br />
           4.留言<br />
           5.购物<br />
           6.购物车<br />
           7.投票<br />
           (更多问题请联系客服解决)
       </h3>
	</div>

<div id="footer">
	<%Server.Execute("/common/Footer.aspx"); %>
</div>

</body>
</html>

