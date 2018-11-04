<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCar.aspx.cs" Inherits="WebApp.shopping.ShoppingCar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>乐易购-购物车</title>
    <script src="../js/jquery-1.11.1.js"></script>
<script>
    //结算
    function buy(carid) {
        var idlist = new Array();
        //获取勾选的checkbox的值val=aid
        $('input[name="checkbox"]:checked').each(function () {
            idlist.push($(this).val());
        });
        if (idlist.length == 0) {
            alert("请选择要结算的商品");
            return;
        }
        var carids = idlist.join(",");
        var pricecount = $("#product_total").text();
        //alert(pricecount);

        if (confirm("你确定要结算这" + idlist.length + "件商品吗？总共"+pricecount+"元！")) {
            $.post("/shopping/ShoppingCar.aspx?flag=money&pricecount=" + pricecount, { carids: carids }, function (result) {
                if (result) {
                    alert("结算成功！");
                    window.location.href="/shopping/shopresult.aspx";
                }
                else {
                    alert("结算失败");
                }
            }, "text");
        }
    }
    
    ///清空购物车
    function clearCar()
    {
        var idlist = new Array();
        //获取勾选的checkbox的值val=carid
        $('input[name="checkbox"]:checked').each(function () {
            idlist.push($(this).val());
        });
        if (idlist.length == 0) {
            alert("请选择要删除的商品");
            return;
        }
        var carids = idlist.join(",");
        if (confirm("你确定要删除这" + idlist.length + "条数据吗")) {
            $.post("/shopping/ShoppingDelete.ashx", { carids: carids }, function (result) {
                if (result) {
                    alert("删除成功！");
                    location.reload(true);
                }
                else {
                    alert("删除失败");
                }
            }, "text");
        }
        else {
            return;
        }
    }

    //设置总价
    function setTotal() {
        var allaccount = 0;
        //$(".productTr").each(function (index, element)  //对该class的元素集合遍历
        //{
        //    if ($(this).find("#chekbox").is(':checked'))   //$("input[type='checkbox']").attr("checked")
        //    {
        //        //$(this).parent().find(".text_box").val();
        //        var price = $(this).find(".item_price").html();
        //        account += Number(price);
        //    }
        //}); 

        $('input[name="checkbox"]:checked').each(function () {
            var tr = $(this).parent().parent();
            var b = tr.children("td");
            var price = b.eq(3).find(".item_price").html();
            //alert(price);
            allaccount += Number(price);
            //alert(allaccount);
        });
        $("#product_total").text(allaccount);
    }

    $(function () {
        //setTotal();
        $(".min").click(function () {
            var count = $(this).parent().find(".text_box").val();    
            $(this).parent().find(".text_box").val(--count);
            var tr = $(this).parent().parent();
            var price = $(tr).find("#price").text();
            $(tr).find(".item_price").html(price * count);
            setTotal();
        });

        $(".add").click(function () {
            var count = $(this).parent().find(".text_box").val();
            $(this).parent().find(".text_box").val(++count);
            
            //修改单项总价
            var tr = $(this).parent().parent();
            var price = $(tr).find("#price").text();
            $(tr).find(".item_price").html(price * count);
            //设置总价
            setTotal();
            //修改session中的值
        });
        //失去焦点
        $(".text_box").blur(function () {
            var count = $(this).parent().find(".text_box").val();
            $(this).parent().find(".text_box").val(count);
            //修改单项总价
            var tr = $(this).parent().parent();
            var price = $(tr).find("#price").text();
            $(tr).find(".item_price").html(price * count);
            setTotal();
        });

        //更新session
        function refreshSessionShoppingCar(GoodsId, count) {
            $.post(
				"shopping_updateShoppingCarItem.action",
				{ GoodsId: GoodsId, count: count },
				function (result) {
				}
			);
        }

    });

    //删除某件商品
    function deletegoods(GoodsId)
    {
        if(confirm("确认删除这件商品吗？"))         //confirm显示指定消息和确认、取消框
        {
            window.location.href = "/shopping/ShoppingDelete.ashx?GoodsId="+GoodsId;
        }
    }
</script>
</head>
<body>
<div id="header" class="wrap">
	<% Server.Execute("/common/Top.aspx"); %>
</div>
<div id="position" class="wrap">
		当前位置：购物车
</div>
    <div class="wrap">
<div id="shopping">
		<form action="order_save.action" method="post">
			<table id="myTableProduct">
				<tr>
                    <th><i class=""></i></th>
					<th>商品名称</th>
					<th>商品单价</th>
					<th>金额</th>
					<th>购买数量</th>
					<th>操作</th>
				</tr>
                <%
                    foreach (Shop.Model.Car car in carList)
                    {%>   
                      <%if(car.account==((Shop.Model.User)Session["userList"]).uid)
                        {%>
                                
                       <tr class="productTr">
                           <td><input type="checkbox" name="checkbox" value="<%=car.carid %>" onclick="setTotal()"/></td>
                           <td class="thumb">
                               <img class="imgs" src="<%=car.goods.goodsphoto%>" /><a href="/goods/GoodsDetail.aspx?GoodsId=<%=car.gid %>"><%=car.goods.gname %></a>
                           </td>
                           <td class="price">
                               <span>￥<lable id="price" classs="price_"><%=car.goods.goodsprice %></lable></span>
                           </td>
                       
                       <td class="price" >
							<span>￥<label id="item_price" class="item_price"><%=(car.goods.goodsprice) * (car.carnumber) %></label></span><%--//总计--%>
						</td>
						<td class="number">
					        <input type="hidden" class="product_id" value="<%=car.gid %>"/>
							<input class="min" name="" type="button" value=" - "  /> 
							<input class="text_box"  style="width: 30px;text-align: center" name="" type="text" value="<%=car.carnumber %>" /> 
							<input class="add" name="" type="button" value=" + " /> 
						</td>
                        <td class="delete">
						    <a href="javascript:deletegoods(<%=car.gid %>)">删除</a>
						</td>
                       </tr>
               <%  }
                   %>
                <% }
                   
				%>

			</table>
            </form>
    </div>
        <div class="shopping_list_end">
      <ul>
        <li style="float:left">
         <a href="javascript:clearCar()" ><font style="font-size:14px;margin:15px 0px 0px 15px;">批量删除</font></a>
        </li>
      </ul>
	<ul>
		<li class="shopping_list_end_2">
			￥<label id="product_total">0</label>
		</li>
		<li class="shopping_list_end_3">商品金额总计：</li>
	</ul>
    <ul>
		<li>
            <input class="ui-green" type="button"  style="background:#0094ff; width:120px;height:40px;color:white; font-size:14px;" name="button" value="去 结 算"onclick="javascript:buy()" />
		</li>
	</ul>
</div>

<div style="background-color: #cddbb8;margin-top: 10px;font-size: 20px;height: 40px;text-align: center">
	<div style="padding: 5px;">
		<b>个人信息</b>&nbsp;&nbsp;&nbsp;&nbsp;<b>收件人：</b><%=((Shop.Model.User)Session["userList"]).urealname %>--<%-- shoppingCar.shoppingCar.size()--%>&nbsp;&nbsp;<b>收货地址：</b><%=((Shop.Model.User)Session["userList"]).uaddress %>&nbsp;&nbsp;<b>联系电话：</b><%=((Shop.Model.User)Session["userList"]).uphone %>
	</div>
        </div>
 </div>
	
<div id="footer">
		<% Server.Execute("/common/Footer.aspx"); %>
</div>
</body>
</html>
