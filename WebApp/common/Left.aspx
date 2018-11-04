
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="WebApp.commom.Left" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inser title here</title>
</head>
<body>
    <form runat="server">
    <div class="box">
        <h2>商品分类</h2>
    <dl>
        <% foreach (Shop.Model.BigClass BigClass in BigClassList)
           {%>
            
			<dt><%=BigClass.bigname %></dt>
                <%
                    foreach(Shop.Model.SmallClass SmallClass in BigClass.SmallClassList)
                {
                %>
				    <dd><a href="/goods/GoodsList.aspx?SearchBigId=<%=BigClass.bigid %>&SearchSmallId=<%=SmallClass.smallid %>&page=1"><%=SmallClass.smallname %></a></dd>
                <% 
                }
                %>
      <%
      }
       %>	
	</dl>
</div>
         

<div class="spacer"></div>

<div class="last-view">
	<h2>最近浏览</h2>
	<dl class="clearfix">
       <%=msg%>
        <%--  <%
            foreach(Shop.Model.Goods Goods in GoodsList)
            {
              %>
                  
                   <dt><img src="<%=Goods.goodsphoto%>" class="imgs" style="width: 50px; height: 50px;" /></dt>
                   <dd><a style="font-size: 12px; height: 46px; overflow: hidden; line-height: 14px" href="GoodsDetail.aspx?GoodsId=<%=Goods.gid %>"><%=Goods.gname %></a></dd>
       
        <%     
              }
               %>--%>
              
              
     
	</dl>
    </div>
    </form>
</body>
</html>
