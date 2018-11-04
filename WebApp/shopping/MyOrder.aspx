<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOrder.aspx.cs" Inherits="WebApp.shopping.MyOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<title>Insert title here</title>
<script type="text/javascript">
    function confirmReceive(orderid) {
        $("#orderid").val(orderid);
	    if (confirm("确认收货？")) {
			$.post("/shopping/MyOrder.aspx?flag=receive",{orderid:orderid},
				function(result){
					if(result){
						alert("交易完成");
						location.reload(true);
					}
				},"text")
		}
	}
	function deleteoid(orderId)
	{
	    if (confirm("确认删除该订单吗？")) {
	        $.post("/shopping//MyOrder.aspx?flag=delete", { orderId: orderId },function(result)
	        {
	            if (result)
	            {
	                alert("删除成功！");
	                location.reload(true);
	            }
	        },"text")
	    }
	}
</script>
</head>
<body>
    <div id="header" class="wrap">
	<% Server.Execute("/common/Top.aspx"); %>
   </div>
    <div id="position" class="wrap">
		当前位置：订单管理
    </div>
    <div class="wrap">
		<div class="manage">
			<div class="search">
				<form action="/shopping/MyOrder.aspx" method="post">
					订单号：<input type="text" class="text" name="searchid" value="<%=searchid %>" /> 
					 <label class="ui-blue"><input type="submit" name="submit" value="查询" /></label>
				</form>
			</div>
			<div class="spacer"></div>
				<table class="list">	           
                     <%      
                        foreach (Shop.Model.Order order in orderList)
                        { %>                             
                        <tr style="background-color: #f7f4eb;">
							<td colspan="4">   
                                <input id="orderid" type="hidden" name="orderid"/>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								单号：<%=order.orderid %>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								下单时间：<%=order.ordertime %>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								状态：  	
                                <%
                                    if (order.orderstatus == 0)
                                    {%>
                                     <font style="color:black;">待发货</font>
                                  <%}
                                    else if (order.orderstatus == 1)
                                    {%> 
                                    <font style="color:blue;">运输中</font>
                                    <%}
                                       else if (order.orderstatus == 2)
                                    {%> 
                                   <button  style="padding:3px;" onclick="return confirmReceive(<%=order.orderid %>)">确认收货</button>
                                    <%}
                                       else if (order.orderstatus == 3)
                                    {%> 
                                    <font style="color:red;">交易完成</font>
                                    <%}
                                %>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								总金额：￥<%=order.orderprice %>&nbsp;
							</td>
                            <td>操作</td>
						</tr>
                             <%foreach (Shop.Model.Car car in order.carList)
                              {%> 
                                <tr>
                                    <%
                                        foreach (Shop.Model.Goods goods in car.goodlist)
                                            {%>
                                                <td width="50%">
									                <img width="72" height="72" alt="" src="<%=goods.goodsphoto %>">
									                <a href="/goods/GoodsDetail.aspx?GoodsId=<%=goods.gid %>" target="_blank"><%=goods.gname%></a>
								                </td>
                                                <td width="17%">
									                   单价：&nbsp; ￥<%=goods.goodsprice %>
								                </td>
								                    <td width="17%">
									                    &nbsp;&nbsp;数量：<%=car.carnumber %>
								                    </td>
								                    <td>
									                    &nbsp;&nbsp;小计：￥<%=goods.goodsprice *car.carnumber %>
								                    </td>
                                                    <td class="delete">
						                                <a href="javascript:deleteoid(<%=order.orderid%>)">删除</a>
						                            </td>
                                            <%}
                                             %>
							        </tr>
                              <%}
                             %>     
                      <%}
                    %>
				</table>
          <div class="pager">
			    <ul class="clearfix">
				    <%=pageCode %>
			    </ul>
		</div>
		</div>
        </div>
</body>
</html>

