<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="WebApp.commom.Top" %>

<!DOCTYPE html>
<html>
<head>
    <link type="text/css" rel="stylesheet" href="/css/style.css" />
    <title>Insert title here</title>
    <script type="text/javascript" src="/js/jquery-1.11.1.js"></script>
    <script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>   
    <script type="text/javascript">  
        function loginout() {
            if (confirm("您确定要退出系统吗？")) {
                window.location.href = "/LoginOut.ashx";
            }
        }

        function checkLogin() {
            alert("请先登录!");
        }           
    </script>
</head>
<body>
    <div id="logo">
        <img src="/image/logo.png" />
    </div>
    <div class="help">
        <% 
            if (Session["userList"] == null)
            { 
              %>
                <a href="javascript:checkLogin()" class="Shopping">购物车</a>
                <a href="/user/Login.aspx">登录</a>
                <a href="/user/Register.aspx">注册</a>
                <a href="/Comments.aspx">留言</a>
          <%}
               else
            { 
               %>
               <a href="/shopping/ShoppingCar.aspx" class="Shopping">购物车(<%=count %>)件商品</a>
               <a href="/user/UserCenter.aspx" class="Shopping">欢迎您：<%=((Shop.Model.User)Session["userList"]).urealname %></a>
               <a href="javascript:loginout()">注销</a>
			   <a href="/Comments.aspx">留言</a>

          <%}     
               
             %>

        <form runat="server" action="/goods/SearchGoods.aspx">
            <input type="text" id="sgname" name="sgname"  onkeyup="" autocomplete="off" value="<%=sgname %>" />
            <input type="submit" id="search" value="搜索" /><br />
            <div id="suggest" style="width: 200px"></div>
        </form>
    </div>

    <div class="navbar">
        <ul class="clearfix">
            <li>
            <a href="/Index.aspx">首页</a>
            </li>
             <li >                       
                <a href="/Introduce.aspx" target="_blank">网站介绍</a>                                                
            </li> 
            <li >                       
                <a href="/Help.aspx" target="_blank">帮助中心</a>                                                
            </li>               
               <%-- <%
                foreach(Shop.Model.BigClass BigClass in BigClassList)
                {
                    %>
                    <li>
                       	<a href="/goods/GoodsList.aspx?SearchBigId=<%=BigClass.bigid %>&SearchSmallId=0"><%=BigClass.bigname %></a>
                    </li>
              <%}
                 %>--%>
        </ul>
    </div>

    <div id="childNav">
        <div class="wrap">
            <ul class="clearfix">
             <%--   target="_blank" 在新窗口中打开被链接文档--%>
                <% 
                    foreach (Shop.Model.Tag Tag in TagList)
                   {
                    %>
                   <li>
                       <a href="<%=Tag.taglink %>"&<%=Tag.tagid %> target="_blank"><%=Tag.tagname %></a>
                   </li>
                   <% }
                %>
    
            </ul>
        </div>
    </div>
</body>
</html>