<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BigManger.aspx.cs" Inherits="WebApp.admin.BigManger" %>

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
    function modifyGoods(bigid,bigname) {
        $("#myModalLabel").html("修改大类");
        $("#bigid").val(bigid);
        $("#bigname").val(bigname);
    }
    function addBigClass()
    {
        $("#myModalLabel").html("添加大类");
    }

    function saveBig() 
    {
        if($("#bigname").val()==null ||$("#bigname").val()=='')
        {
            $("#error").html("请输入商品大类名称");
            return false;
        }
        $.post("/admin/BigManger.aspx",$("#fm").serialize(),function(result)
        {
            if(result)
            {
                alert("保存成功");
                resetValue();
                location.reload(true);
            }
            else
            {
                alert("保存失败");
            }
        },"text");
       
    }
        
    
    function BigDelete(BigId) {
        if (confirm("确定要删除这条数据吗？包括商品小类的所有商品都会被删除！！！")) { 
            $.post("/admin/BigManger.aspx?flag=delete", { BigId: BigId },
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
   
    function resetValue() {
        $("#bigid").val("");
        $("#bigname").val("");
       
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
            <button class="btn btn-primary" type="button" data-backdrop="static" data-toggle="modal" data-target="#dlg" onclick="return addBigClass()">添加商品大类</button>&nbsp;&nbsp;&nbsp;&nbsp;
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
                                    <th>名称</th>
								</tr>
							</thead>
							<tbody>
								 <%foreach(Shop.Model.BigClass bigclass in bigclassList){%>
									<tr>
										<td><input type="checkbox" /></td>
										<td style="text-align: center;vertical-align: middle;"><%=bigclass.bigid%></td>
										<td style="text-align: center;vertical-align: middle;"><%=bigclass.bigname%></td>
										<td style="text-align: center;vertical-align: middle;">
											<button class="btn btn-info" type="button" data-backdrop="static" data-toggle="modal" data-target="#dlg"

                                            onclick="return modifyGoods(<%=bigclass.bigid %>,'<%=bigclass.bigname%>')">修改
											</button>&nbsp;&nbsp;<button class="btn btn-danger" type="button" onclick="javascript:BigDelete(<%=bigclass.bigid %>)">删除</button>
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
				<h3 id="myModalLabel">修改大类</h3>
			</div>
			<div class="modal-body">
				<form id="fm" action="/admin/BigManger.aspx" method="post" enctype="multipart/form-data">
                    <input type="hidden" value="SaveOrUpdate" name="flag"/>
					<table>
						<tr>
							<td>
								<label class="control-label" for="title">名称：</label>
							</td>
							<td>
								<input id="bigname" type="text" name="bigname" placeholder="请输入数据..."/>
							</td>
						</tr>
					</table>
                    <input id="bigid" type="hidden" name="bigid"/>
				</form>
			</div>
			<div class="modal-footer">
				<font id="error" style="color: red;"></font>
				<button class="btn" data-dismiss="modal" aria-hidden="true"
					onclick="return resetValue()">关闭</button>
				<button class="btn btn-primary" onclick="javascript:saveBig()">保存</button>
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
