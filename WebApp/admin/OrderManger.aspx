<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderManger.aspx.cs" Inherits="WebApp.admin.OrderManger" %>

<!DOCTYPE html  PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Insert title here</title>
<link rel="stylesheet" href="/admin/css/bootstrap.min.css" />
<link rel="stylesheet" href="/admin/css/bootstrap-responsive.min.css" />
<link rel="stylesheet" href="/admin/css/uniform.css" />
<link rel="stylesheet" href="/admin/css/unicorn.main.css" />
<link rel="stylesheet" href="/admin/css/unicorn.grey.css" class="skin-color" />
<script type="text/javascript" src="/js/jquery-1.11.1.js"></script>
<script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript">
//单个删除
    function OrderDelete(orderId) {
        if (confirm("确定要删除这条数据吗?")) { 
            $.post("/admin/OrderManger.aspx?flag=delete", { orderId: orderId },
                    function (result) {
                        if (result) {
                            alert("删除成功！");
                            setTimeout("location.reload(true)",300);

                        } else {
                            alert("删除失败");
                        }
                    }, "text");
        }
    }
    //批量删除
    function DeleteList()
    {
        var idlist = new Array();
        $('input[name="checkbox"]:checked').each(function () {
            idlist.push($(this).val());
        });
        if (idlist.length == 0)
        {
            alert("请选择要删除的数据");
            return;
        }
        var orderids = idlist.join(',');
        if (confirm("你确定要删除这" + idlist.length + "条数据吗？")) {
            $.post("/admin/OrderManger.aspx?flag=deleteList", { orderids: orderids }, function (result) {
                if (result) {
                    alert("删除成功！");
                    location.reload(true);
                }
                else {
                    alert("删除失败");
                }
            }), "text";
        }
        else {
            return;
        }
    }
    //批量修改订单状态
    function altertype(n)
    {
        var idlist = new Array();    
        $('input[name="checkbox"]:checked').each(function () {
            idlist.push($(this).val());
        });
        if (idlist.length == 0) {
            alert("请选择修改的数据");
            return;
        }
        var ids = idlist.join(',');
        var status = 1;
        if (n == 1) {
            status = 1;
        }
        else if (n == 2) {
            status = 2;
        }
        else if (n = 3) {
            status = 3;
        }
        if (confirm("你确定要修改" + idlist.length + "条数据吗？")) {
            $.post("/admin/OrderManger.aspx?flag=altertype", { ids: ids,status:status}, function (result) {
                if (result) {
                    alert("修改成功！");
                    location.reload(true);
                }
                else {
                    alert("修改失败");
                }
            }), "text";
        }
        else {
            return;
        }
    }

</script>
</head>
 <%
        if(Session["admin"]==null){
	        Response.Redirect("/admin/Login.aspx");
	        return;
        }
        %>
<body>
	<div id="header">
		<h1 style="margin-left: 0px;padding-left: 0px;"><a href="#">湖北理工学院</a></h1>	
	</div>
	<div id="sidebar">
		<ul>
            <li id="u"><a href="/admin/Main.aspx"><i class="icon icon-home"></i> <span>主界面</span></a></li>
			<li id="userLi"><a href="/admin/UserManger.aspx"><i class="icon icon-home"></i> <span>用户管理</span></a></li>
			<li class="submenu"><a href="#"><i class="icon icon-th-list"></i>
					<span>商品管理</span> <span class="label">3</span></a>
				<ul>
                    <li><a href="/admin/GoodsManger.aspx">商品管理</a></li>
					<li><a href="/admin/BigManger.aspx">商品大类管理</a></li>
					<li><a href="/admin/SmallManger.aspx">商品小类管理</a></li>
				</ul></li>
			<li id="topicLi"><a href="/admin/OrderManger.aspx"><i class="icon icon-home"></i> <span>订单管理</span></a></li>
			 <li><a href="/admin/NoticeManger.aspx"><i class="icon icon-home"></i> <span>公告管理</span></a></li> 
             <li><a href="/admin/TagManger.aspx"><i class="icon icon-home"></i> <span>标签管理</span></a></li> 
            <li><a href="/admin/VoteManger.aspx"><i class="icon icon-home"></i> <span>投票管理</span></a></li> 
			<li id="zoneLi"><a href="/admin/CommentManger.aspx"><i class="icon icon-home"></i> <span>留言管理</span></a></li>
			<li class="submenu"><a href="#"><i class="icon icon-th-list"></i>
					<span>系统管理</span> <span class="label">2</span></a>
				<ul>
					<li><a href="/admin/ModifyAdmin.aspx">修改个人信息</a></li>
					<li><a href="/admin/LoginOut.ashx">安全退出</a></li>				
				</ul></li>
		</ul>

	</div>

	<div id="style-switcher">
		<i class="icon-arrow-left icon-white"></i> <span>颜色:</span> 
		<a href="#grey" style="background-color: #555555; border-color: #aaaaaa;"></a> 
		<a href="#blue" style="background-color: #2D2F57;"></a> 
		<a href="#red" style="background-color: #673232;"></a>
	</div>

	<div id="content">
		<div id="content-header">
			<h1>乐易购后台管理</h1>
		</div>
		<div id="breadcrumb">
			<a href="#" title="首页" class="tip-bottom">
			<i class="icon-home"></i> 首页</a> 
		</div>
		<%--//主部分--%>
        <div class="container-fluid">
		<div id="tooBar" style="padding: 10px 0px 0px 10px;">
			<a href="#" role="button" class="btn btn-danger" onclick="javascrip:DeleteList()">批量删除</a>
            <a href="#" role="button" class="btn btn-primary" onclick="javascrip:altertype(1)">运输中</a>
            <a href="#" role="button" class="btn btn-primary" onclick="javascrip:altertype(2)">配送中</a>
            <a href="#" role="button" class="btn btn-primary" onclick="javascrip:altertype(3)">交易完成</a>
            <form method="post" action="/admin/OrderManger.aspx" class ="form-search"  style="display:inline;">
                <select name="otype">
                    <option value="">订单状态排序</option>
                    <option value="0" <%=otype=="0"?"selected":"" %>>待发货</option>
                     <option value="1" <%=otype=="1"?"selected":"" %>>运输中</option>
                     <option value="2" <%=otype=="2"?"selected":"" %>>已到达</option>
                     <option value="3" <%=otype=="3"?"selected":"" %>>交易完成</option>
                </select>
                <input  name="oid" value="<%=oid %>" id="oid" type="text" class="input-medium search-query" placeholder="订单号..."/>  
			  <button type="submit" class="btn btn-primary" title="Search">查询&nbsp;<i class="icon  icon-search"></i></button>
            </form> 
		</div>
		<div class="row-fluid">
			<div class="span12">
				<div class="widget-box">
					<div class="widget-title">
						<h5>订单列表</h5>
					</div>
					<div class="widget-content nopadding">
						<table class="table table-bordered table-striped with-check">
							<thead>
								<tr>
									<th><i class=""></i></th>
									<th>订单号</th>
                                    <th>用户id</th>      
                                    <th>商品信息</th>
                                    <th>单价</th> 
                                    <th>总金额</th>
                                    <th>下单时间</th>
                                    <th>订单状态</th>
                                    <th>操作</th>
								</tr>
							</thead>
							<tbody>
								 <%foreach(Shop.Model.Order order in orderList){%>
									<tr>
										<td><input type="checkbox" name="checkbox"  value="<%=order.orderid %>"/></td>
										<td style="text-align: center;vertical-align: middle;"><%=order.orderid%></td>
										<td style="text-align: center;vertical-align: middle;"><%=order.uid%></td>
                                        <td style="text-align: center;vertical-align: middle;">
                                        <%foreach(Shop.Model.Car car in order.carList)
                                          {%>
                                             <%foreach(Shop.Model.Goods goods in car.goodlist)
                                               { %>   
											<img alt="" style="width: 100px;height: 100px" src='<%=goods.goodsphoto%>' />
                                               <%=goods.gname%>  
                                         <%} %>
                                        <% }%>
                                        </td>
                                        <td style="text-align: center;vertical-align: middle;">
                                            <%foreach(Shop.Model.Car car in order.carList)
                                          {%>
                                             <%foreach(Shop.Model.Goods goods in car.goodlist)
                                               { %>   
											 <%=goods.goodsprice%>   
                                         <%} %>
                                        <% }%> 
                                        </td>                 
                                        <td style="text-align: center;vertical-align: middle;"><%=order.orderprice%></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=order.ordertime%></td>
                                        <td style="text-align: center;vertical-align: middle;">
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
                                    <font style="color:blue;">配送中</font>
                                    <%}
                                       else if (order.orderstatus == 3)
                                    {%> 
                                    <font style="color:red;">交易完成</font>
                                    <%}
                                %>
                                            </td>
									<td style="text-align: center;vertical-align: middle;">			                       
										<button class="btn btn-danger" type="button" onclick="javascript:OrderDelete(<%=order.orderid %>)">删除</button>
									</td>
									</tr>
                                <%} %>
							</tbody>
						</table>
					</div>
				</div>
				<div class="pagination alternate">
					<ul class="clearfix"><%=pageCode %>
					</ul>
				</div>
			</div>
		</div>
	</div>
		<div class="row-fluid">
			<div id="footer" class="span12">
				2018 &copy;  作者：计算机学院毕设&nbsp;&nbsp;&nbsp;&nbsp; <a href="http://www.hbpu.edu.cn/">湖北理工学院</a>
			</div>
		</div>
	</div>

<script src="/admin/js/jquery.min.js"></script>
<script src="/admin/js/jquery.ui.custom.js"></script>
<script src="/admin/js/bootstrap.min.js"></script>
<script src="/admin/js/jquery.uniform.js"></script>
<!-- <script src="js/select2.min.js"></script> -->
<script src="/admin/js/jquery.dataTables.min.js"></script>
<script src="/admin/js/unicorn.js"></script>
<script src="/admin/js/unicorn.tables.js"></script>
<script type="text/javascript" src="/js/uploadPreview.min.js"></script>
</body>
</html>

