<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApp.user.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<title>用户注册</title>
<script type="text/javascript" src="/js/jquery-1.11.1.js"></script>
<script type="text/javascript" src="/js/jquery.validate.js"></script>
<script type="text/javascript" src="/js/jquery.validate.messages_cn.js"></script>
<script type="text/javascript" src="/js/uploadPreview.min.js"></script>
<style type="text/css">
span{color:Red;font-size:12px}
</style>
<script type="text/javascript">
    $(function () {
        $("#headphoto").uploadPreview({ Img: "ImgPr", Width: 220, Height: 220 });      
    });
    //检查用户名
    function checkUserName(uname) {
        var uname = document.getElementById("uname").value;//从服务器中传来uname
        if ($("#uname").val() == "") {
            $("#userErrorInfo").html("用户名不能为空！");
            return;
        }
        $.post(
			"/user_existUserWithUserName.ashx",
			{ uname: uname },
			function (result) {
			    //var ret = $.parseJSON(result);
			    if (result == "False") {
			        $("#userErrorInfo").html("用户名已存在，请重新输入！");
			        $("#uname").focus();
			    } else {
			        $("#userErrorInfo").html("可以使用");
			    }

			},"text"
		);
    }  
    //检查密码
    function checkpwd()
    {     
            var pwd = $("#upwd").val();
            var repwd = $("#reupwd").val();
            if (pwd == "") {
                $("#pwdError").html("密码不能为空");
            }
            else {
                $("#pwdError").html(null);
            }
            if (repwd != pwd) {
                $("#pwdError2").html("两次密码不一致,请重新输入...");
            }
            else {
                $("#pwdError2").html(null);
            }     
    }
    function checkForm() {
        var unickname = $("#unickname").val();           
        var udentity = $("#udentity").val();     
        var uanswer1 = $("#uanswer1").val();
        var uphone = $("#uphone").val();
        var uaddress = $("#address").val();        
        if (unickname == "") {
            $("#error").html("昵称不能为空");
            return false;
        }            
        if (udentity == "") {
            $("#error").html("身份证不能为空");
            return false;
        }
        if (uanswer1 == "") {
            $("#error").html("问题不能为空");
            return false;
        }
        if (uphone == "") {
            $("#error").html("电话不能为空");
            return false;
        }
        if (uaddress == "") {
            $("#error").html("收货地址不能为空");
            return false;
        }
        return true;
    }
</script>
</head>
<body>
<div id="header" class="wrap">
	<%Server.Execute("/common/Top.aspx"); %>
</div>

<div id="register" class="wrap">
	<div class="shadow">
		<em class="corner lb"></em>
		<em class="corner rt"></em>
		<div class="box">
			<h1>易购物，乐生活</h1>
			<ul class="steps clearfix">
				<li class="current"><em></em>填写注册信息</li>
				<li class="last"><em></em>注册成功</li>
			</ul>
			 <form id="regForm"  runat="server" onsubmit="return checkForm()" enctype="multipart/form-data">
							
                <div id="preDiv" style="width: 700px; height: 120px;margin-left: 80px;">
				   <img id="ImgPr" style="width: 120px; height: 120px; border-radius:50%;" src="/face/defualt.jpg" />
			    </div>			
                <table>
                    <%--onblur 当用户离开输入字段时进行验证--%>
					<tr>
						<td class="field">用户名(*)：</td>
						<td><input class="text" type="text" id="uname" name="uname" onblur="checkUserName(this.value)" />&nbsp;<font id="userErrorInfo" color="red"></font></td>
					</tr>
					<tr>
						<td class="field">密码(*)：</td>
						<td><input class="text"  type="password" id="upwd" name="upwd" onblur="checkpasswd()" /><font id="pwdError" color="red"></font></td>
					</tr>
					<tr>
						<td class="field">确认密码(*)：</td>
						<td><input class="text" type="password"  id="reupwd"  name="reupwd" onblur="checkpwd()" />&nbsp;<font id="pwdError2" color="red"></font></td>
					</tr>
					<tr>
						<td class="field">昵称(*)：</td>
						<td><input class="text" type="text" id="unickname" name="unicknam"  />&nbsp;</td>
					</tr>
					<tr>
						<td class="field">性别(*)：</td>
						<td>
					    <input type="radio"   name="usex" value="男" checked="checked"/>男&nbsp;&nbsp;<%--radio单选按钮--%>
					    <input type ="radio" name="usex" value="女"/>女					    					    
					    </td>						
					</tr>
					<tr>
						<td class="field">身份证号：</td>
						<td><input class="text" type="text" id="udentity" name="udentity"   /></td>
					</tr>
                    <tr>
						<td class="field">真实姓名：</td>
						<td><input class="text" type="text" id="urealname" name="urealname" /></td>
					</tr>
					<tr>
						<td class="field">密保问题：</td>
						<td>
                            <select id="uquestion1" name="uquestion1">
                                <option value="">请选择密保问题...</option>
                                   <%
                                       foreach (Shop.Model.Question question in questionList)
                                       {%> 
                                        <option value="<%=question.qid %>"><%=question.qquestion %></option>
                                       <%}
                                        %>                           
                            </select>
						</td>
                            
					</tr>
					<tr>
						<td class="field">密保问题答案：</td>
						<td><input class="text" type="text" id="uanswer1" name="uanswer1" /></td>
					</tr>
					<tr>
						<td class="field">Email：</td>
						<td><input class="text" type="text" id="uemail" name="uemail" /></td>
					</tr>
					<tr>
						<td class="field">手机号码(*)：</td>
						<td><input class="text" type="text" id="uphone" name="uphone"/></td>
					</tr>
					<tr>
						<td class="field">收货地址(*)：</td>
						<td><input class="text" type="text" id="uaddress" name="uaddress" /></td>
					</tr>
					<tr>
						<td></td>
						<td><label class="ui-green"><input type="submit" name="submit" value="提交注册" /></label></td>
					</tr>
					<tr>
						<td>&nbsp;</td>
						<td><font id="error" color="red"><%=error %></font> </td>
					</tr>
				</table>
			</form>
		</div>
	</div>
	<div class="clear"></div>
</div>

<div id="footer">
	<%Server.Execute("/common/Footer.aspx"); %>
</div>
</body>
</html>
