<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeDetails.aspx.cs" Inherits="WebApp.NoticeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<title>乐易购 公告 </title>
</head>
<body>
<div id="header" class="wrap">
	<%Server.Execute("/common/Top.aspx");%>
</div>

<div id="position" class="wrap">
		当前位置：留言
</div>
	
<div id="main" class="wrap">
	<div class="lefter">
		<%Server.Execute("/common/Left.aspx"); %>
	</div>
	
         <div id="notice" class="right-main">
		    <h1><%=Notices.notitle %></h1>
		    <div class="content">
			    <%=Notices.nocontent %>
		    </div>
	    </div>

<div class="clear"></div>
</div>
<div id="footer">
	<%Server.Execute("/common/Footer.aspx"); %>
</div>
</body>
</html>
