<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManger.aspx.cs" Inherits="WebApp.admin.UserManger" %>
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
    $(function () {
        $("#headphoto").uploadPreview({ Img: "ImgPr", Width: 220, Height: 220 });
    });
    function modifyUser(uid, unickname, upwd, usex,headphoto, uphone, uaddress, uemail) {
        $("#myModalLabel").html("修改用户");
        $("#uid").val(uid);
        $("#unickname").val(unickname);
        $("#upwd").val(upwd);
        $("#usex").val(usex);
        $("#ImgPr").attr("src" ,headphoto);//返回被选元素属性和值
        $("#uphone").val(uphone);
        $("#uaddress").val(uaddress);
        $("#uemail").val(uemail);
    }
    function addUser()
    {
        $("#myModalLabel1").html("添加用户");
    }
    function publish()
    {
        $.post("/admin/UserManger.aspx?flag=add", $("#fm1").serialize(), function (data)//序列化表单值
        {
            if (data) {
                alert("添加成功");
                resetValue(); //清空
                location.reload(true);
            }
            else {
                alert("添加失败");
            }
        }, "text");
    }
    function saveUser() {
        $("#myModalLabel").html("修改用户");
        var form = document.getElementById('fm');
        var formData = new FormData(form);
        //alert(formData);
        $.ajax({
            type: "POST",
            url: "/admin/UserManger.aspx?flag=save",
            data: formData,
            async: false,//(异步函数)
            cache: false,
            contentType: false,
            processData: false,
            success: function (result) {
                if (result) {
                    alert('该用户信息修改成功!', { icon: 1 });
                    resetValue();
                    setTimeout("window.location.reload(true)", 600);
                }
                else {
                    alert('用户信息修改失败!', { icon: 5 });
                }
            }
        });
    }
    function userDelete(uid) {
        if (confirm("确定要删除这条数据吗?")) {
            $.post("/admin/UserDelete.ashx", { uid: uid },
                    function (result) {
                        if (result) {
                            alert("删除成功！");
                            window.location.reload(true);

                        } else
                        {
                            alert("删除失败");
                        }
                    }, "text");
        }
    }
    function deleteUsers() {
        var selectedSpan = $(".checked").parent().parent().next("td");
        if (selectedSpan.length == 0) {
            alert("请选择要删除的数据");
            return;
        }
        var strIds = [];
        for (var i=0;i<selectedSpan.length; i++) {
            strIds.push(selectedSpan[i].innerHTML);
        }
        var uids = strIds.join(",");
        if (confirm("你确定要删除这" + selectedSpan.length + "条数据吗")) {
            $.post("/admin/UserDelete.ashx", { uids: uids }, function (result) {
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
    function resetValue()
    {
        $("#uid").val();
        $("#uname").val();
        $("#upwd").val();
        $("#usex").val();
        $("#headphoto").val();
        $("#uphone").val();
        $("#uaddress").val();
        $("#uemail").val();
    }


</script>
</head>
 <%
        if(Session["admin"]==null){
	        Response.Redirect("/admin/Login.aspx");
	        return;
        }
        %><body>
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
			<li id="zoneLi"><a href="/admin/UserList.aspx"><i class="icon icon-home"></i> <span>留言管理</span></a></li>
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
			<!-- <div class="btn-group">
				<a class="btn btn-large tip-bottom" title="Manage Files"><i
					class="icon-file"></i></a> <a class="btn btn-large tip-bottom"
					title="Manage Users"><i class="icon-user"></i></a> <a
					class="btn btn-large tip-bottom" title="Manage Comments"><i
					class="icon-comment"></i><span class="label label-important">5</span></a>
				<a class="btn btn-large tip-bottom" title="Manage Orders"><i
					class="icon-shopping-cart"></i></a>
			</div> -->
		</div>
		<div id="breadcrumb">
			<a href="#" title="首页" class="tip-bottom">
			<i class="icon-home"></i> 首页</a> 
		</div>
		<%--//主部分--%>
        <div class="container-fluid">
		<div id="tooBar" style="padding: 10px 0px 0px 10px;">
		    <button class="btn btn-primary" type="button" data-backdrop="static" data-toggle="modal" data-target="#dlg1" onclick="return addUser()">添加用户</button>&nbsp;&nbsp;&nbsp;&nbsp;
			<a href="#" role="button" class="btn btn-danger" onclick="javascrip:deleteUsers()">批量删除</a>
            <form method="post" action="/admin/UserManger.aspx" class ="form-search"  style="display:inline;">
                <input  name="uniname" value="<%=niname%>" id="uniname" type="text" class="input-medium search-query" placeholder="请输入用户名或昵称..."/>
                 &nbsp;
			  <button type="submit" class="btn btn-primary" title="Search">查询&nbsp;<i class="icon  icon-search"></i></button>
            </form>
		</div>
		<div class="row-fluid">
			<div class="span12">
				<div class="widget-box">
					<div class="widget-title">
						<h5>用户列表</h5>
					</div>
					<div class="widget-content nopadding">
						<table class="table table-bordered table-striped with-check">
							<thead>
								<tr>
									<th><i class=""></i></th>
									<th>编号</th>
                                    <th>用户名</th>
                                    <th>登录密码</th>
									<th>昵称</th>
                                    <th>头像</th>
									<th>真实姓名</th>
                                    <th>id</th>
									<th>性别</th>
									<th>注册时间</th>
                                    <th>联系电话</th>
									<th>地址</th>
                                    <th>邮箱</th>
									<th>操作</th>
								</tr>
							</thead>
							<tbody>
								 <%foreach(Shop.Model.User User in userList) {%>
									<tr>
										<td><input type="checkbox" /></td>
										<td style="text-align: center;vertical-align: middle;"><%=User.uid %></td>
										<td style="text-align: center;vertical-align: middle;"><%=User.uname%></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=User.upwd%></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=User.unickname%></td>
										<td style="text-align: center;vertical-align: middle;">
											<img alt="" style="width: 100px;height: 100px" src='<%=User.headphoto%>' />
										</td>
										<td style="text-align: center;vertical-align: middle;"><%=User.urealname %></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=User.udentity %></td>
										<td style="text-align: center;vertical-align: middle;"><%=User.usex%></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=User.uregistertime%></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=User.uphone%></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=User.uaddress%></td>
                                        <td style="text-align: center;vertical-align: middle;"><%=User.uemail%></td>
										<td style="text-align: center;vertical-align: middle;">
											<button class="btn btn-info" type="button" data-backdrop="static" data-toggle="modal" data-target="#dlg"

                                            onclick="return modifyUser(<%=User.uid %>,'<%=User.unickname%>','<%=User.upwd%>','<%=User.usex%>','<%=User.headphoto%>','<%=User.uphone%>','<%=User.uaddress%>','<%=User.uemail%>')">修改    
                                            </button><br /><button class="btn btn-danger" type="button" onclick="javascript:userDelete(<%=User.uid %>)">删除</button>
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
				<h3 id="myModalLabel">修改用户</h3>
			</div>
			<div class="modal-body">
				<form id="fm" action="/admin/UserManger.aspx" method="post" enctype = "multipart/form-data">
					<table>
						<tr>
							<td>
								<label class="control-label" for="nickName">昵称：</label>
							</td>
							<td>
								<input id="unickname" type="text" name="unickname" placeholder="导入数据失败！"/>
							</td>
						</tr>
						<tr>
							<td>
								<label class="control-label" for="password">密码：</label>
							</td>
							<td>
								<input id="upwd" type="text" name="upwd" placeholder="导入数据失败！"/>
							</td>
						</tr>
						<tr>
							<td>
								<label class="control-label" for="sex">性别：</label>
							</td>
							<td>
						    <select name="usex" id="usex" >
                                <option value="">请选择...</option>
                                <option value="男">男</option>
                                <option value="女">女</option>
                            </select>
							</td>
						</tr>
						<tr>
							<td>
								<label class="control-label" for="headphoto">头像：</label>
							</td>	
							<td>
								<img  id="ImgPr"  style="width: 120px; height: 120px;" src="/face/qqq123.png"/>
							</td>
						</tr>
                        <tr>
							<td>
								<label class="control-label" for="headphoto">修改头像：</label>
							</td>
							<td>
								<input type="file" id="headphoto" name="headphoto"/>
							</td>
						</tr>
                        <tr>
							<td>
								<label class="control-label" for="phone">联系电话：</label>
							</td>
							<td>
								<input id="uphone" type="text" name="uphone" placeholder="导入数据失败！"/>
							</td>
						</tr>
                        <tr>
							<td>
								<label class="control-label" for="address">地址：</label>
							</td>
							<td>
								<input id="uaddress" type="text" name="uaddress" placeholder="导入数据失败！"/>
							</td>
						</tr>
						<tr>
							<td>
								<label class="control-label" for="email">邮箱：</label>
							</td>
							<td>
								<input id="uemail" type="text" name="uemail" placeholder="导入数据失败！"/>
							</td>
						</tr>
					</table>
					<input id="uid" type="hidden" name="uid"/>
				</form>
			</div>
			<div class="modal-footer">
				<font id="error" style="color: red;"></font>
				<button class="btn" data-dismiss="modal" aria-hidden="true"
					onclick="return resetValue()">关闭</button>
				<button class="btn btn-primary" onclick="javascript:saveUser()">保存</button>
			</div>
		</div>
              <%-- ------------------------%>
            	<div id="dlg1" class="modal hide fade"  tabindex="-1" role="dialog" aria-labelledby="myModalLabel1" aria-hidden="true">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-hidden="true" onclick="return resetValue()">×</button>
				<h3 id="myModalLabel1">添加用户</h3>
			</div>
			<div class="modal-body">
				<form id="fm1" action="/admin/UserManger.aspx" method="post">
					<table>
                        <tr>
							<td>
								<label class="control-label" for="uname">用户名：</label>
							</td>
							<td>
								<input id="uname" type="text" name="uname"/>
							</td>
						</tr>
						<tr>
							<td>
								<label class="control-label" for="nickName">昵称：</label>
							</td>
							<td>
								<input id="unickname1" type="text" name="unickname1"/>
							</td>
						</tr>
						<tr>
							<td>
								<label class="control-label" for="password">密码：</label>
							</td>
							<td>
								<input id="upwd1" type="text" name="upwd1"/>
							</td>
						</tr>
						<tr>
							<td>
								<label class="control-label" for="sex">性别：</label>
							</td>
                            <td>
                                <select name="usex1" id="usex1" >
                                <option value="">请选择...</option>
                                <option value="男">男</option>
                                <option value="女">女</option>
                            </select>
                            </td>			 
						</tr>
						<tr>
							<td>
								<label class="control-label" for="headphoto1">头像：</label>
							</td>
							
							<td>
								<img id="ImgPr1"  style="width: 120px; height: 120px;" src="/face/defualt.jpg" />
							</td>
                        </tr>		
                        <tr>
							<td>
								<label class="control-label" for="realname">真实姓名：</label>
							</td>
							<td>
								<input id="urealname" type="text" name="urealname"/>
							</td>
						</tr>  
                        <tr>
							<td>
								<label class="control-label" for="dentitty">id：</label>
							</td>
							<td>
								<input id="udentity" type="text" name="udentity"/>
							</td>
						</tr> 
                        <tr>
							<td>
								<label class="control-label" for="registertime">注册时间：</label>
							</td>
							<td>
								<input id="registertime" type="text" name="registertime" value="<%=DateTime.Now %>"/>
							</td>
						</tr>   
                        <tr>
							<td>
								<label class="control-label" for="phone">联系电话：</label>
							</td>
							<td>
								<input id="uphone1" type="text" name="uphone1"/>
							</td>
						</tr>
                        <tr>
							<td>
								<label class="control-label" for="address">地址：</label>
							</td>
							<td>
								<input id="uaddress1" type="text" name="uaddress"/>
							</td>
						</tr>
						<tr>
							<td>
								<label class="control-label" for="email">邮箱：</label>
							</td>
							<td>
								<input id="uemail1" type="text" name="uemail1" />
							</td>
						</tr>
					</table>
					<input id="uid1" type="hidden" name="uid1"/>
				</form>
			</div>
			<div class="modal-footer">
				<font id="error1" style="color: red;"></font>
				<button class="btn" data-dismiss="modal" aria-hidden="true"
					onclick="return resetValue()">关闭</button>
				<button class="btn btn-primary" onclick="javascript:publish()">保存</button>
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
