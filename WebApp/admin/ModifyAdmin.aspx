<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyAdmin.aspx.cs" Inherits="WebApp.admin.ModifyAdmin" %>

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
    <style type="text/css">
button{cursor:pointer;width:50%;height:30px;padding:0;background:#ef4300;border:1px solid #ff730e;border-radius:6px;font-weight:700;color:#fff;font-size:20px;letter-spacing:15px;margin-top:10px; text-shadow:0 1px 2px rgba(0,0,0,.1)}
</style>
<script type="text/javascript">
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

        <div class="" align="center" style="margin-top: 50px;">
	<h1 style="margin-bottom: 20px; color:red">修改个人信息</h1>                                                     
		<form id="regForm" style="width: 700px;"  class="form-horizontal form-inline" runat="server">
			<div class="control-group">
				<label class="control-label" for="nickName">昵称(*)：</label>
				<div class="controls">
					<input class="input-block-level" type="text" id="nickname" name="nickname" value="<%=((Shop.Model.Admin)Session["admin"]).adminrealname %>"/><span class="pull-left"></span>
					<font id="userErrorInfo" class="pull-right" color="red"></font>
				</div>
			</div>		
			<div class="control-group" id="preDiv" style="width: 700px; height: 120px;margin-left: 80px;">      
               <img id="ImgPr" class="pull-left" style="width: 120px; height: 120px; border-radius:50%;" src="/face/qqq123.png" />                       
			</div>		
			<div class="control-group">
				<label class="control-label" for="password">请输入新密码(*)：</label>
				<div class="controls">
					<input class="input-block-level" type="password" id="pwd"
						name="pwd" placeholder="新密码...(不修改则不需要输入)"/><span class="pull-left"></span>
				</div>
			</div>
			<div class="control-group">
				<label class="control-label" for="rePassWord">确认新密码(*)：</label>
				<div class="controls">
					<input class="input-block-level" type="password" id="repwd" name="repwd"  placeholder="确认新密码..."/><span class="pull-left"></span>
				</div>
			</div>					           
            <a href="#" onclick="back()" style="float:left;color:#8cc051;">返回到首页</a>  
			<input type="hidden" name="user.id" value="<%=((Shop.Model.Admin)Session["admin"]).adminid %>"/>
			<div class="control-group" style="margin: 0px;">
				<div style="margin-left: 70px;">
					<button type="submit" tabindex="5">保存修改</button> &nbsp;&nbsp;&nbsp;&nbsp;
                    <font id="error" style="font-size: 20px;" color="red"><%=msg %></font> 
				</div>
			</div>
			<font id="error" color="red"></font>
		</form>
	</div>
        </div>
</body>
</html>
