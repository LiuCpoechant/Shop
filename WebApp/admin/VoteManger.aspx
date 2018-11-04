<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoteManger.aspx.cs" Inherits="WebApp.admin.VoteManger" %>

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
    function modifyVote(vid, content1, total1, content2, total2, content3, total3, content4, total4) {
        $("#myModalLabel").html("修改投票信息");
        $("#vid").val(vid);
        $("#content1").val(content1);
        $("#total1").val(total1);
        $("#content2").val(content2);
        $("#total2").val(total2);
        $("#content3").val(content3);
        $("#total3").val(total3);
        $("#content4").val(content4);
        $("#total4").val(total4);      
    }
    function saveVote() {
        $("#myModalLabel").html("修改用户");
        $.post("/admin/VoteManger.aspx", $("#fm").serialize(), function (data) {
            if (data) {
                alert("修改成功");
                resetValue();
                location.reload(true);
            }
            else {
                alert("修改失败");
            }
        }
        , "text")
    }
   
    function resetValue() {
        $("#vid").val();
        $("#content1").val();
        $("#total1").val();
        $("#content2").val();
        $("#total2").val();
        $("#content3").val();
        $("#total3").val();
        $("#content4").val();
        $("#total4").val();
    }

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
		<div class="row-fluid">
			<div class="span12">
				<div class="widget-box">
					<div class="widget-title">
						<h5>投票列表</h5>
					</div>
					<div class="widget-content nopadding">
						<table class="table table-bordered table-striped with-check">
							<thead>
								<tr>
									<th><i class=""></i></th>
									<th>编号</th>
                                    <th>选项一</th>
                                    <th>票数一</th>
                                    <th>选项二</th>
                                    <th>票数二</th>
                                    <th>选项三</th>
                                    <th>票数三</th>
                                    <th>选项四</th>
                                    <th>票数四</th>  
                                    <th>操作</th>                               
								</tr>
							</thead>
							<tbody>
								 <%foreach(Shop.Model.Vote vote in voteList) {%>
									<tr>
										<td><input type="checkbox" name="checkbox"  value="<%=vote.vid %>"/></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=vote.vid%></td>      
										<td style="text-align: center;vertical-align: middle;"><%=vote.vcontent1%></td>										
                                        <td style="text-align: center;vertical-align: middle;"><%=vote.vtotal1%></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=vote.vcontent2%></td>										
                                        <td style="text-align: center;vertical-align: middle;"><%=vote.vtotal2%></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=vote.vcontent3%></td>										
                                        <td style="text-align: center;vertical-align: middle;"><%=vote.vtotal3%></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=vote.vcontent4%></td>										
                                        <td style="text-align: center;vertical-align: middle;"><%=vote.vtotal4%></td>
                                         <td style="text-align: center;vertical-align: middle;">                                     
											<button class="btn btn-info" type="button" data-backdrop="static" data-toggle="modal" data-target="#dlg"

                                            onclick="return modifyVote(<%=vote.vid %>,'<%=vote.vcontent1%>',<%=vote.vtotal1%>,'<%=vote.vcontent2%>',<%=vote.vtotal2%>,'<%=vote.vcontent3%>',<%=vote.vtotal3%>,'<%=vote.vcontent4%>',<%=vote.vtotal4%>)">修改
											</button>
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
				<h3 id="myModalLabel">修改投票</h3>
			</div>
			<div class="modal-body">
				<form id="fm" action="/admin/VoteManger.aspx" method="post">
                     <input type="hidden" value="save" name="flag"/>
					<table>
						<tr>
							<td>
								<label class="control-label" for="title">内容一：</label>
							</td>
							<td>
								<input id="content1" type="text" name="content1" placeholder="导入数据失败！"/>
							</td>
						</tr>					
                        <tr>
							<td>
								<label class="control-label" for="total">票数：</label>
							</td>
							<td>
								<input type="text" id="total1" name="total1"/>
							</td>
						</tr>
						<tr>
							<td>
								<label class="control-label" for="title">内容二：</label>
							</td>
							<td>
								<input id="content2" type="text" name="content2" placeholder="导入数据失败！"/>
							</td>
						</tr>					
                        <tr>
							<td>
								<label class="control-label" for="total">票数二：</label>
							</td>
							<td>
								<input type="text" id="total2" name="total2"/>
							</td>
						</tr>
						<tr>
							<td>
								<label class="control-label" for="title">内容三：</label>
							</td>
							<td>
								<input id="content3" type="text" name="content3" placeholder="导入数据失败！"/>
							</td>
						</tr>					
                        <tr>
							<td>
								<label class="control-label" for="total">票数三：</label>
							</td>
							<td>
								<input type="text" id="total3" name="total3"/>
							</td>
						</tr>
                        <tr>
							<td>
								<label class="control-label" for="title">内容四：</label>
							</td>
							<td>
								<input id="content4" type="text" name="content4" placeholder="导入数据失败！"/>
							</td>
						</tr>					
                        <tr>
							<td>
								<label class="control-label" for="total">票数四：</label>
							</td>
							<td>
								<input type="text" id="total4" name="total4"/>
							</td>
						</tr>
					</table>
					<input id="vid" type="hidden" name="vid"/>    
				</form>
			</div>
			<div class="modal-footer">
				<font id="error" style="color: red;"></font>
				<button class="btn" data-dismiss="modal" aria-hidden="true"
					onclick="return resetValue()">关闭</button>
				<button class="btn btn-primary" onclick="javascript:saveVote()">保存</button>
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
