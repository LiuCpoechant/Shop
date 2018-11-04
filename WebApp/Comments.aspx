<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="WebApp.Comments" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <link type="text/css" rel="stylesheet" href="css/style.css" />
<script type="text/javascript" src="js/jquery-1.11.1.js"></script>
<script type="text/javascript">
</script>
 <title>留言</title>

</head>

<body>
    <div id="header" class="wrap">
        <%Server.Execute("/common/Top.aspx"); %>
    </div>
    <div id="main" class="wrap">
        <div class="lefter">
            <%Server.Execute("/common/Left.aspx"); %>
        </div>

                 <div class="main">
                     <div class="guestbook">
                         <h2>全部留言</h2>
                         <ul>
                             <%foreach(Shop.Model.Comment Comment in commentList)
                               {%>
                                   <li>
                                       <dl>
                                           <dt><%=Comment.comcontent %></dt>
                                           <dd class="author">
                                               用户：<%=Comment.uname %>
                                           <span class="timer">
                                              <%=Comment.comtime %>
                                           </span>
                                           </dd>
                                           <%if( Comment.replycontent!="")
                                             {%>
                                             <dd>
								            官方回复：<% =Comment.replycontent%>&nbsp;&nbsp;
								            <span class="timer">
									        回复时间：<%=Comment.comreplytime%>
								            </span>
							              </dd>
                                          <% }
                                                %>
                                       </dl>
                                   </li>
                               <%}
                                  %>
                         </ul>
 	<div class="clear"></div>
		<div class="pager">
			<ul class="clearfix">
				<%=pageCode %>
			</ul>
		</div>
		<div id="reply-box">
			<form runat="server" onsubmit="return checkForm()">
				<table>
					<tr>
						<td class="field">用户：</td>
						<%
                            if(Session["userList"]==null)
                            {%>
                              <td><input class="text" type="text"  id="comment.uname"  name="uname" value="游客" disabled="disabled" /></td>  
                            <%}
                              else
                            {%> 
                              <td><input class="text" type="text"  id="comment.unames"  name="uname" value="<%=((Shop.Model.User)Session["userList"]).uname%>" disabled="disabled" /></td>
                            <%}
                        %>
					</tr>
					<tr>
						<td class="field">留言内容：</td>
						<td><textarea id="comcontent" name="comcontent"></textarea>
						</td>
					</tr>
					<tr>
						<td></td>
						<td><label class="ui-blue"><input type="submit"
								name="submit" value="提交留言" /> </label>&nbsp;&nbsp;<font id="error"  color="red"><%=error%></font>
						</td>
					</tr>
				</table>
			</form>
		</div>
	</div>
	</div>
</div>
<div class="clear"></div>
    <div id="footer">
        <%Server.Execute("/common/Footer.aspx"); %>
    </div>
</body>
</html>
