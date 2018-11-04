<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserModify.aspx.cs" Inherits="WebApp.user.UserModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>修改个人信息</title>
<link href="/admin/css/bootstrap.css" rel="stylesheet" />
<link href="/admin/css/bootstrap-responsive.css" rel="stylesheet" />
<link href="/admin/css/docs.css" rel="stylesheet" />
<script type="text/javascript" src="/js/jquery-1.11.1.js"></script>
<script type="text/javascript" src="/js/jquery.validate.js"></script>
<script type="text/javascript" src="/js/jquery.validate.messages_cn.js"></script>
<script type="text/javascript" src="/js/uploadPreview.min.js"></script>
<script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
<style type="text/css">
button{cursor:pointer;width:100%;height:44px;padding:0;background:#ef4300;border:1px solid #ff730e;border-radius:6px;font-weight:700;color:#fff;font-size:24px;letter-spacing:15px;margin-top:10px; text-shadow:0 1px 2px rgba(0,0,0,.1)}
span{color:Red;font-size:12px}
</style>
<script type="text/javascript">
    $(function () {
        $("#headphoto").uploadPreview({ Img: "ImgPr", Width: 220, Height: 220 });//头像预览
    });

    function back() {
        window.location.href = "/Index.aspx";
    }
    function checkForm() {
        var unickname = $("#unickname").val();
        var usex = $("#usex").val();
        var pwd = $("#password").val();
        var repwd = $("#rePassWord").val();
        var uphone = $("#uphone").val();
        var uemail = $("#uemail").val();
        var uaddress = $("#uaddress").val();
        if (unickname == "") {
            $("#error").html("昵称不能为空！");
            return false;
        }
        if (urealname == "") {
            $("#error").html("真实姓名不能为空！");
            return false;
        }
        if (udentity == "") {
            $("#error").html("身份证号不能为空！");
            return false;
        }
        if (pwd == "") {
            $("#error").html("新密码不能为空！");
            return false;
        }
        if (repwd == "") {
            $("#error").html("确认密码不能为空！");
            return false;
        }
        if (pwd != repwd) {
            $("#error").html("密码和确认密码不一致，请重新输入！");
            return false;
        }
        if (uphone == "") {
            $("#error").html("联系电话不能为空！");
            return false;
        }
        if (uemail == "") {
            $("#error").html("邮箱不能为空！");
            return false;
        }
    }
</script>
</head>
<body>
	<div class="" align="center" style="margin-top: 50px;">
	<h1 style="margin-bottom: 20px; color:red">修改个人信息</h1>                                                     
		<form id="regForm" style="width: 700px;" enctype="multipart/form-data" class="form-horizontal form-inline" runat="server">
			<div class="control-group">
				<label class="control-label" for="nickName">昵称(*)：</label>
				<div class="controls">
					<input class="input-block-level" type="text" id="unickname" name="unickname" value="<%=((Shop.Model.User)Session["userList"]).unickname %>"/><span class="pull-left"></span>
					<font id="userErrorInfo" class="pull-right" color="red"></font>
				</div>
			</div>
			<div class="control-group">
				<label class="control-label" for="trueName">真实姓名(*)：</label>
				<div class="controls">
					<input class="input-block-level" type="text" id="urealname" name="urealname" onblur="checkTrueName(this.value)" value="<%=((Shop.Model.User)Session["userList"]).urealname %>"/><span class="pull-left"></span>
				</div>
			</div>
            <div class="control-group">
				<label class="control-label" for="dentity">身份证号码(*)：</label>
				<div class="controls">
					<input class="input-block-level" type="text" id="udentity" name="udentity"  value="<%=((Shop.Model.User)Session["userList"]).udentity %>"/><span class="pull-left"></span>
				</div>
			</div>
			<div class="control-group">
				<label class="control-label" for="sex">性别(*)：</label>
				<div class="controls">
					<label class="radio" style="margin-right: 50px;">
						<select id="usex" name="sex"><option value="">请选择...</option>
                            <option value="女" <%= sex=="女" ? "selected" : "" %>>女</option>
							<option value="男" <%= sex=="男" ? "selected" : "" %>>男</option>
						</select>
					</label>
				</div>
			</div>
			<div class="control-group" id="preDiv" style="width: 700px; height: 120px;margin-left: 80px;">

                <%
                    if (((Shop.Model.User)Session["userList"]).headphoto != null)
                    {%>
                        <img id="ImgPr" class="pull-left" style="width: 120px; height: 120px; border-radius:50%;" src="<%=((Shop.Model.User)Session["userList"]).headphoto %>" />
                    <%}
                    else
                    {%>
                        <img id="ImgPr" class="pull-left" style="width: 120px; height: 120px; border-radius:50%;" src="/face/defualt.jpg" />
                    <%}

                %>

			</div>
			<div class="control-group">
				<label class="control-label" for="face">上传头像(*)：</label>
				<div class="controls">
					<input type="hidden" name="headphoto" value="<%=((Shop.Model.User)Session["userList"]).headphoto %>">
					<input type="file" id="headphoto" name="headphoto">
				</div>
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
			<div class="control-group">
				<label class="control-label" for="moble">联系电话(*)：</label>
				<div class="controls">
					<input class="text input-block-level" type="text" id="uphone"
						name="uphone" value="<%=((Shop.Model.User)Session["userList"]).uphone%>"/><span class="pull-left"></span>
				</div>
			</div>
			<div class="control-group">
				<label class="control-label" for="email">电子邮箱(*)：</label>
				<div class="controls">
					<input class="text input-block-level" type="text" id="uemail"
						name="uemail" value="<%=((Shop.Model.User)Session["userList"]).uemail %>"/><span class="pull-left"></span>
				</div>
			</div>
            <div class="control-group">
				<label class="control-label" for="address">地址(*)：</label>
				<div class="controls">
					<input class="text input-block-level" type="text" id="uaddress"
						name="uaddress" value="<%=((Shop.Model.User)Session["userList"]).uemail %>"/><span class="pull-left"></span>
				</div>
			</div>
            <a href="#" onclick="back()" style="float:left;color:#8cc051;">返回到首页</a>  
			<input type="hidden" name="user.id" value="<%=((Shop.Model.User)Session["userList"]).uid %>">
			<input type="hidden" name="user.regTime" value="<%=((Shop.Model.User)Session["userList"]).uregistertime %>">
			<div class="control-group" style="margin: 0px;">
				<div style="margin-left: 70px;">
					<button type="submit" >保存修改</button> &nbsp;&nbsp;&nbsp;&nbsp;
                    <font id="error" style="font-size: 20px;" color="red"><%=msg %></font> 
				</div>
			</div>
			<font id="error" color="red"></font>
		</form>
	</div>
</body>
</html>


