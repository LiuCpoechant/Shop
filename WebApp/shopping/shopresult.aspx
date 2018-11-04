<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopresult.aspx.cs" Inherits="WebApp.shopping.shopresult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <title>Insert title here</title>
    <link href="../css/style.css" rel="stylesheet" />
</head>
<body>
    <div id="header" class="wrap">
	<%Server.Execute("/common/Top.aspx"); %>
</div>
    <div class="wrap">
        <div id="shopping">
            <div class="shadow">
                <em class="corner lb"></em>
                <em class="corner rt"></em>
                <div class="box">
                    <div class="msg">
                        <p>恭喜：购买成功！</p>
                        <p>正在进入首页...</p>
                        <script type="text/javascript">
						setTimeout("location.href='/index.aspx'", 3000);
                        </script>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
