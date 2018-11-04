<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsList.aspx.cs" Inherits="WebApp.goods.GoodsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<title>乐易购</title>
<link type="text/css" rel="stylesheet" href="css/style.css" />
</head>
     <style>
     *{margin:0;padding:0;}
     .yang{width:100px;height:100px;}
     .yang img{width:100px;height:100px;transition:all 0.5s;}/*图片放大过程的时间*/
     .yang img:hover{ 
             transform: scale(1.2);/*鼠标经过图片放大的倍数*/
         }
 
     .ziti{width:300px;height:40px;border:1px dashed red;text-align:center;margin:80px auto;}
</style>
<body>
<div id="header" class="wrap">
	<%Server.Execute("/common/Top.aspx"); %>
</div>

<div id="position" class="wrap">
	当前位置：<%= nav%>><%=Code %>
</div>
	
<div id="main" class="wrap">
	<div class="lefter">
 <%Server.Execute("/common/Left.aspx");%>
	</div>
	<div class="main">
			<div class="price-off">
				<h2>全部商品</h2>
				<ul class="product clearfix">
				
                    <%foreach (Shop.Model.Goods Goods in goodsList) 
                      {%>
                          <%
                              if(Goods.smallid==SearchSmallId)
                              { 
                               %>
                           <li>
							    <dl>
								    <dt class="yang"><a href="/goods/GoodsDetail.aspx?GoodsId=<%=Goods.gid %>" target="_blank"><img src="<%=Goods.goodsphoto %>"/></a></dt>
								    <dd class="title"><a href="/goods/GoodsDetail.aspx?GoodsId=<%=Goods.gid %>" target="_blank"><%=Goods.gname %></a></dd>
								    <dd class="price"><%=Goods.goodsprice %></dd>
                                    <dd class="text">浏览量：<%=Goods.gview %></dd>
							    </dl>
						   </li>
                          <%  }
                       %>
                       <%}
                         %>
				</ul>
                <div class="pager">
			<ul class="clearfix">
				<%=pageCode %>
			</ul>
		</div>
			</div>
			<div class="side">
				<div class="news-list">
					<h4>最新公告</h4>
					<ul>
                        <%foreach(Shop.Model.Notice Notice in NoticeList)
                          { %>
                               <li><a href="/NoticeDetails.aspx?NoticeId=<%=Notice.noid %>" target="_blank"> <%=Notice.notitle %></a></li>
                         <%} 
                        %>
					</ul>
				</div>
				<div class="spacer"></div>
				<div class="news-list">
                    <h4>在线投票</h4>
              <form method="post" action="Vote.ashx">


              </form>
            
         
          

				</div>
			</div>
			<div class="spacer clear"></div>
		
			
		</div>
		
</div>
<div id="footer">
	<%Server.Execute("/common/Footer.aspx"); %>
</div>
    
</body>
</html>