<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsManger.aspx.cs" Inherits="WebApp.admin.GoodsManger" %>

<!DOCTYPE html>

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
    function modifyGoods(gid,gname, goodsphoto, descript, smallid, goodsprice, stock, specialprice, hot, gview, gcount) {
        $("#myModalLabel").html("修改商品信息");
        $("#gid").val(gid);  
        $("#gname").val(gname);
        $("#ImgPr").attr("src", goodsphoto);//返回被选元素属性和值
        $("#descript").val(descript);
        $("#sid").val(smallid); 
        $("#goodsprice").val(goodsprice);
        $("#stock").val(stock);
        $("#specialprice").val(specialprice);
        $("#hot").val(hot);
        $("#gview").val(gview);
        $("#gcount").val(gcount);
    }
    function addGoods()
    {
        $("#myModalLabel").html("添加商品");
        var form = document.getElementById('fm');
        var formData = new FormData(form);     
    }
    function saveGoods() {
        $("#myModalLabel").html("保存商品");
        var form = document.getElementById('fm');
        var formData = new FormData(form);
        //alert(formData);
        $.ajax({
            type: "POST",
            url: "/admin/GoodsManger.aspx",
            data: formData,
            async: false,//(异步函数)
            cache: false,
            contentType: false,
            processData: false,
            success: function (result) {
                if (result) {
                    alert('该商品修改成功!', { icon: 1 });
                    resetValue();
                    setTimeout("window.location.reload(true)", 600);
                }
                else {
                    alert('修改失败!', { icon: 5 });
                }
            }
        });
    }
    function GoodsDelete(GoodsId) {
        if (confirm("确定要删除这条数据吗?")) {
            $.post("/admin/GoodsManger.aspx?flag=delete", { GoodsId: GoodsId },
                    function (result) {
                        if (result) {
                            alert("删除成功！");
                            window.location.reload(true);

                        } else {
                            alert("删除失败");
                        }
                    }, "text");
        }
    }
    function deleteGoodss() {
        var idlist = new Array();
        $('input[name="checkbox"]:checked').each(function () {
            idlist.push($(this).val());    //循环拿到所有被选中的input
        });
        if (idlist.length == 0)
        {
            alert("请选择数据");
            return;
        }
        var gids =idlist.join(',');
        if (confirm("你确定要删除这" + idlist.length + "条数据吗")) {
            $.post("/admin/GoodsManger.aspx?flag=delete", { gids: gids }, function (result) {
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
    function resetValue() {
        $("#gid").val("");
        $("#smallid").val("");
        $("#smallname").val("");
        $("#goodsphoto").val("");
    }

    $(function () {
        $("#goodsphoto").uploadPreview({ Img: "ImgPr", Width: 220, Height: 220 });
    });

</script>
</head>

<% 
    if (Session["admin"] == null)
    {
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
		    <button class="btn btn-primary" type="button" data-backdrop="static" data-toggle="modal" data-target="#dlg" onclick="return addGoods()">添加商品</button>&nbsp;&nbsp;&nbsp;&nbsp;
			<a href="#" role="button" class="btn btn-danger" onclick="javascrip:deleteGoodss()">批量删除</a>
            <form runat="server" class ="form-search"  style="display:inline;">      
                 <table>
                     <tr>
                     <td>商品名：</td>
                            <td><input  name="goname" value="<%=goname %>" type="text" class="input-medium search-query" placeholder="请输入商品名称..." style="width: 165px;"/></td>
                     <td>属小类：</td>
                          <td>
                            <select id="bysmall" name="bysmall" style="width: 165px;"><option value="">请选择...</option>
                             <%foreach(Shop.Model.SmallClass smallclass in smallclassList) {%>
                             <option value="<%=smallclass.smallid%>"  <%= bysmall == smallclass.smallid.ToString() ? "selected": ""  %> ><%=smallclass.smallname%></option>
                             <%} %>
                            </select>
                          </td>
                         <td>是否特价：</td>
                            <td>
                                <select name="iste"><option value="">全部</option>
							    <option value="1" <%=iste=="1"?"selected":"" %>>是</option>
							    <option value="0" <%=iste=="0"?"selected":"" %>>否</option>
						        </select>
                            </td>   
                         <td>是否热卖：</td>
                            <td> <select id="isre" name="isre"><option value="">全部</option>
                                <option value="1" <%=isre=="1"?"selected":"" %>>是</option>
							    <option value="0" <%=isre=="0"?"selected":"" %>>否</option>
                                </select>
                            </td>       
                         <td><button type="submit" class="btn btn-primary" title="Search">查询&nbsp;<i class="icon  icon-search"></i></button></td>
                        </tr>      
            </table> 
        </form>
		</div>
		<div class="row-fluid">
			<div class="span12">
				<div class="widget-box">
					<div class="widget-title">
						<h5>商品列表</h5>
					</div>
					<div class="widget-content nopadding">
						<table class="table table-bordered table-striped with-check">
							<thead>
								<tr>
									<th><i class=""></i></th>
									<th>编号</th>
                                    <th>图片</th>
                                    <th>商品名</th>
                                    <th>描述</th>
									<th>价格</th>
                                    <th>是否特价</th>
									<th>是否热卖</th>
                                    <th>属小类</th>                    
                                    <th>库存</th>
                                    <th>浏览量</th>
                                    <th>成交量</th>
								</tr>
							</thead>
							<tbody>
								 <%foreach(Shop.Model.Goods goods in GoodsList) {%>
									<tr>
										<td><input type="checkbox" name="checkbox"  value="<%=goods.gid %>"/></td>      
										<td style="text-align: center;vertical-align: middle;"><%=goods.gid%></td>
										<td style="text-align: center;vertical-align: middle;">
                                              <img alt="" style="width: 100px;height: 100px" src='<%=goods.goodsphoto%>' />
                                         </td>
                                        <td style="text-align: center;vertical-align: middle;"><%=goods.gname%></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=goods.descript%></td>
										<td style="text-align: center;vertical-align: middle;"><%=goods.goodsprice %></td>
                                        <td style="text-align: center;vertical-align: middle;">
                                          <%if(goods.specialprice==1)
                                            {%>
                                             <font style="color: red;">是</font>
                                           <%}
                                             else
                                             {%>
                                             <font style="color: blue;">否</font>
                                             <%}      
                                          %> 

                                          </td>
                                        <td style="text-align: center;vertical-align: middle;">
                                            <%if(goods.hot==1)
                                            {%>
                                             <font style="color: red;">是</font>
                                           <%}
                                             else
                                             {%>
                                             <font style="color: blue;">否</font>
                                             <%}
                                          %>  
                                        </td>
                                        <td style="text-align: center;vertical-align: middle;"><%=goods.smallclass.smallname%></td>               
                                        <td style="text-align: center;vertical-align: middle;"><%=goods.stock %></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=goods.gview %></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=goods.gcount %></td>
										<td style="text-align: center;vertical-align: middle;">
											<button class="btn btn-info" type="button" data-backdrop="static" data-toggle="modal" data-target="#dlg"

                                            onclick="return modifyGoods(<%=goods.gid %>,'<%=goods.gname%>','<%=goods.goodsphoto%>','<%=goods.descript%>','<%=goods.smallid %>','<%=goods.goodsprice%>','<%=goods.stock%>','<%=goods.specialprice%>','<%=goods.hot%>','<%=goods.gview%>','<%=goods.gcount%>')">修改
											</button>&nbsp;&nbsp;<button class="btn btn-danger" type="button" onclick="javascript:GoodsDelete(<%=goods.gid %>)">删除</button>
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

		<div id="dlg" class="modal hide fade"  tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true" onclick="return resetValue()">×</button>
				<h3 id="myModalLabel">修改商品</h3>
			</div>
			<div class="modal-body">
				<form id="fm" action="/admin/GoodsManger.aspx" method="post" enctype="multipart/form-data">
                     <input type="hidden" value="saveOrUpdate" name="flag"/>
					<table>
						<tr>
							<td>
								<label class="control-label" for="title">商品名称：</label>
							</td>
							<td>
								<input id="gname" type="text" name="gname" placeholder="导入数据失败！"/>
							</td>
						</tr>
						<tr>
							<td>
								<label class="control-label" for="goodsphoto">图片：</label>
							</td>
							
							<td>
								<img  id="ImgPr" style="width: 120px; height: 120px;"  src=""/>
							</td>
						</tr>
                        <tr>
							<td>
								<label class="control-label" for="photo">上传图片：</label>
							</td>
							<td>
								<input type="file" id="goodsphoto" name="goodsphoto"/>
							</td>
						</tr>
						<tr>
							<td>
								<label class="control-label" for="des">描述：</label>
							</td>
							<td>
								<input id="descript" type="text" name="descript"  placeholder="导入数据失败！"/>
							</td>
						</tr>
                        <tr>
							<td>
								<label class="control-label" for="name">所属小类：</label>
							</td>
                            <td>
							    <select id="sid" name="sid"><option value="">请选择...</option>
                                        <%
                                            foreach (Shop.Model.SmallClass smallclass in smallclassList)
                                            {%>
                                              <option value="<%=smallclass.smallid%>"><%=smallclass.smallname %></option>  
                                            <%}
                                        %>
						       </select>
                            </td>
						</tr>  		
						<tr>
							<td>
								<label class="control-label" for="price">价格：</label>
							</td>
							<td>
								<input id="goodsprice" type="text" name="goodsprice"  placeholder="导入数据失败！"/>
							</td>
						</tr>
                        <tr>
							<td>
								<label class="control-label" for="sto">库存：</label>
							</td>
							<td>
								<input id="stock" type="text" name="stock"  placeholder="导入数据失败！"/>
							</td>
						</tr>
                        <tr>
							<td>
								<label class="control-label" for="isspecial">是否特价：</label>
							</td>
                            <td>
							    <select id="specialprice" name="specialprice">
                                          <option value="1">是</option>
                                          <option value="0">否</option>
                                          
						       </select>
                            </td>
						</tr>
                        <tr>
							<td>
								<label class="control-label" for="ishot">是否热卖：</label>
							</td>
							<td>
								 <select id="hot" name="hot">
                                          <option value="1">是</option>
                                          <option value="0">否</option>
                                          
						       </select>
							</td>
						</tr>
                        <tr>
							<td>
								<label class="control-label" for="view">浏览量：</label>
							</td>
							<td>
								<input id="gview" type="text" name="gview"  placeholder="导入数据失败！"/>
							</td>
						</tr>
                        <tr>
							<td>
								<label class="control-label" for="view">成交量：</label>
							</td>
							<td>
								<input id="gcount" type="text" name="gcount"  placeholder="导入数据失败！"/>
							</td>
						</tr>
					</table>
					<input id="gid" type="hidden" name="gid"/>    
				</form>
			</div>
			<div class="modal-footer">
				<font id="error" style="color: red;"></font>
				<button class="btn" data-dismiss="modal" aria-hidden="true"
					onclick="return resetValue()">关闭</button>
				<button class="btn btn-primary" onclick="javascript:saveGoods()">保存</button>
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
