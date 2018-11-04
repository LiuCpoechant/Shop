<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Introduce.aspx.cs" Inherits="WebApp.Introduce" %>

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
        <h2 style=" text-align:center; padding-top:40px; color:#00ff21; font-size:30px;">网站介绍</h2>
       <h3 style=" text-align:center;font-size:20px;padding-top:40px; color:#00ff90">旨在利用互联网将产品展示给所有的用户，以便用户选购商品，为生活带来更多的便利</h3>
	</div>

<div id="footer">
	<%Server.Execute("/common/Footer.aspx"); %>
</div>

</body>
</html>
