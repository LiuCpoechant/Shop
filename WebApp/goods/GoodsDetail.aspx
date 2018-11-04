<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsDetail.aspx.cs" Inherits="WebApp.goods.GoodsDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<title>乐易购</title>
<link type="text/css" rel="stylesheet" href="css/style.css" />
<script type="text/javascript">
    function AddGoodsCar(GoodsId) {
        var strsession = "<%=Session["userList"] %>"; //可以用tostring()，也可不用
        var GoodsId = $("#GoodsId").val();
        //alert(GoodsId);
        if (strsession == "") {
            alert("请先登录")
        }
        else {
            $.post("/shopping/ShoppingCar.aspx?flag=add",{ GoodsId: GoodsId },function (result) {
				    if (result) {
				        alert("已成功加入购物车");
				        location.reload(); //立即刷新页面
				    } else {
				        alert("出现了一个未知的错误");
				    }
				},"text");
            }
    }

        //购物
        function gobuy()
        {
            var str = "<%=Session["userList"] %>"; //可以用tostring()，也可不用
            var GoodsId = $("#GoodsId").val();
            if (str == "") {
                alert("请先登录")
            }
            else {
                window.location.href = "/shopping/ShoppingCar.aspx?flag=shop&GoodsId=" + GoodsId;
            }
        }

</script>

</head>
<body>
<div id="header" class="wrap">
  <%Server.Execute("/common/Top.aspx");%>
</div>
<div id="position" class="wrap">
	当前位置：<a href="/Index.aspx">首页></a>商品详情
</div>

  <div id="main" class="wrap">
         <div class="lefter">
		    <%Server.Execute("/common/Left.aspx");%>
	    </div>

      <div id="product"  class="main">
          <div class="clear"></div>
		        <h1><%=Good.gname %></h1>
           <input type ="hidden" id ="GoodsId"  value ="<%=Good.gid%>" />
          <%-- <input type ="hidden" id ="uname"  value ="<%=((Shop.Model.User)Session["userList"]).uname %>" />--%>
		        <div class="infos">
			        <div class="thumb">
				        <img class="img" src="<%=Good.goodsphoto %>" />
			        </div>
			        <div class="buy">
				        <br/>
				        <p>
					        商城价：<span class="price">￥<%=Good.goodsprice %></span>
				        </p>
				        <p>库 存：<%=Good.stock %></p>
				        <br/>
				        <div >
					        <img src="/image/car.jpg" style="width:40px;height:40px;"/> <a href="javascript:AddGoodsCar(GoodsId)">加入到购物车</a> <br/>
                          <input class="ui-green" type="button"  style="background:green; width:120px;height:40px;" name="button" value="购买" onclick="javascript:gobuy()" />
				        </div>
			        </div>
			        <div class="clear"></div>
		        </div>
		        <div class="introduce">
			        <h2>
				        <strong>商品详情</strong>
			        </h2>
			        <div class="text">
				       <%=Good.descript %>
			        </div>
		        </div>
	        </div>
        <div id="footer">
	        <%Server.Execute("/common/Footer.aspx"); %>
         </div>
  </div>

</body>
</html>
