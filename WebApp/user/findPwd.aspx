<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findPwd.aspx.cs" Inherits="WebApp.user.findPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css" >
        .bg1{                                      
            width: 960px;
            height:650px;
            margin: 0 auto;
            background: url(/image/bg1.jpg) no-repeat center;    <%--图片居中--%>          
        }      
</style>
</head>
<body>
    <div id="header" class="wrap">
	<%Server.Execute("/common/Top.aspx"); %>
</div>
	<div class="bg1" style="align-content:center">
        <h2 style=" text-align:center; padding-top:40px; color:#00ff21; font-size:30px;">找回密码</h2>
        <form runat="server" action="/user/findPwd.aspx">
        <div style="text-align:center; vertical-align:middle; padding-top:40px;">
                  
              <label><font style="font-size:15px; color:#00ffff">请输入账号:</font></label>  
              <input type="text" style="width:200px;height:25px;" id="uname" name="uname"/><br /> 
              <font style="font-size:15px; color:#00ffff;padding-left:0;">请选择密保:
              <select id="uquestion1" name="uquestion1" style="width:200px;padding: 0 2%;margin: 0;">
                    <option value="" style="align-content:center">请选择密保问题...</option>
                            <%
                                foreach (Shop.Model.Question question in questionList)
                                {%> 
                                <option value="<%=question.qid %>"><%=question.qquestion %></option>
                                <%}
                                %>                           
                    </select>                  
              <br />
              <label><font style="font-size:15px; color:#00ffff">请输入答案:</font></label>  
              <input type="text" style="width:200px;height:25px;" id="uanswer1" name="uanswer1"/> <br />                        
        </div> 
        <div style="text-align:center;padding-top:20px; padding-right:40px;">
            <label class="ui-green"><input type="submit" name="submit" value="确认提交" /></label>
        </div>  
           <div style="text-align:center;">
               <font color="red"><%=message %></font>
           </div>          
        </form>
	</div>
   
<div id="footer">
	<%Server.Execute("/common/Footer.aspx"); %>
</div>

</body>
</html>
