

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApp.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<link type="text/css" rel="stylesheet" href="css/kefu.css"/>
<script type="text/javascript" src="/js/jquery-1.8.3.min.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>乐易购-首页</title>
     <style>
     *{margin:0;padding:0;}
     .yang{width:100px;height:100px;}
     .yang img{width:100px;height:100px;transition:all 0.5s;}/*图片放大过程的时间*/
     .yang img:hover{ 
             transform: scale(1.2);/*鼠标经过图片放大的倍数*/
         }
 
     .ziti{width:300px;height:40px;border:1px dashed red;text-align:center;margin:80px auto;}
</style>
    <script type="text/javascript">
        ///右侧悬浮客服开启关闭
        $(function () {
            $("#aFloatTools_Show").click(function () {
                $('#divFloatToolsView').animate({ width: 'show', opacity: 'show' }, 100, function () { $('#divFloatToolsView').show(); });
                $('#aFloatTools_Show').hide();
                $('#aFloatTools_Hide').show();
            });
            $("#aFloatTools_Hide").click(function () {
                $('#divFloatToolsView').animate({ width: 'hide', opacity: 'hide' }, 100, function () { $('#divFloatToolsView').hide(); });
                $('#aFloatTools_Show').show();
                $('#aFloatTools_Hide').hide();
            });
        });
        //radio取消选中
        var flag = true;
        function checkRadio(id) {         
            id.checked = flag;
            flag = !flag;
        }
        ///判断传过来的是哪个被选中，选中的票数加1
        function add()
        {
            vid = 1;
            var t;
            var idlist = new Array();
            $('input[name="radio"]:checked').each(function () {               
                idlist.push($(this).val());
            });
            var val = $('input[id="Radio"]:checked').val();          
            if (val ==1)
            {
                t = 1;
            }
            var val2 = $('input[id="Radio2"]:checked').val();
            if (val2==2) {
                t = 2;
            }
            var val3 = $('input[id="Radio3"]:checked').val();
            if (val3 == 3) {
                t = 3;
            }
            var val4 = $('input[id="Radio4"]:checked').val();
            if (val4 == 4) {
                t = 4;
            }
            //alert(t);
            if (idlist.length == 0)
            {
                alert("请选择数据");
                return;
             }
             var ids = idlist.join(',');
             if (confirm("你确定要提交这个选择吗")) {
                 $.post("/index.aspx?flag=choice", { ids: ids,vid:vid,t:t}, function (result) {
                     if (result) {
                         alert("感谢您的投票！");
                         location.reload(true);
                     }
                     else {
                         alert("投票失败");
                     }
                 }, "text");
             }
             else {
                 return;
             }
        }


  </script>
</head>
<body>
      <!--kefu-->
<div id="floatTools" class="rides-cs" style="height:246px;">
  <div class="floatL">
  	<a style="display: none;" id="aFloatTools_Show" class="btnOpen" title="查看在线客服" href="javascript:void(0);">展开</a>
  	<a style="display: block;" id="aFloatTools_Hide" class="btnCtn" title="关闭在线客服" href="javascript:void(0);">收缩</a>
  </div>
  <div id="divFloatToolsView" class="floatR" style="height: 237px; width: 140px; display: block;">
    <div class="cn">
      <h3 class="titZx">在线客服</h3>
      <ul>
        <li><span>如果您有任何问题请联系我们的在线客服帮您解答</span></li>
        <li><span>我们的在线客服帮您解答</span></li>
        <li><span>客服</span> <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=1251832836&amp;site=qq&amp;menu=yes"><img border="0" src="/image/online.png" alt="点击这里给我发消息" title="点击这里给我发消息"/></a> </li>      
        <li>
            <a href="https://weibo.com/" target="_blank">新浪微博</a>       
            <div class="div_clear"></div>
        </li>
        <li style="border:none;"><span>电话：12345678</span> </li>
      </ul>
    </div>
  </div>
</div>
<!--kefu-->
<div id="header" class="wrap">
	<%Server.Execute("/common/Top.aspx");%>
</div>

<div id="main" class="wrap">
	<div class="lefter">
 <%Server.Execute("/common/Left.aspx");%>
	</div>
	<div class="main">
			<div class="price-off">
				<h2>今日特价</h2>
				<ul class="product clearfix">
				
                    <%foreach (Shop.Model.Goods Goods in GoodsList) 
                      {%>
                          <%
                              if(Goods.specialprice==1)
                              { 
                               %>
                           <li>
							    <dl>
								   
                                    <dt class="yang">
                                        <a href="/goods/GoodsDetail.aspx?GoodsId=<%=Goods.gid %>" target="_blank"><img src="<%=Goods.goodsphoto %>"/></a>
                                    </dt>
								    <dd class="title"><a href="/goods/GoodsDetail.aspx?GoodsId=<%=Goods.gid %>" target="_blank"><%=Goods.gname %></a></dd>
								    <dd class="price">￥<%=Goods.goodsprice %></dd>
                                    <dd class="text">浏览量：<%=Goods.gview %></dd>
							    </dl>
						   </li>
                   <%  }
                       %>
                       <%}
                         %>
				</ul>
			</div>
		<div class="pager">
			<ul class="clearfix">
				<%=pageCode %>
			</ul>
		</div>
			<div class="side">
				<div class="news-list">
					<h4>最新公告</h4>
					<ul>
                        <%foreach(Shop.Model.Notice Notice in NoticeList)
                          { %>
                               <li><a href="/NoticeDetails.aspx?NoticeId=<%=Notice.noid %>" target="_blank"> <%=Notice.notitle %></a></li>
                         <%} 
                        %>
					</ul>
				</div>
				<div class="spacer"></div>
				<div class="news-list">
                    <h3>在线投票</h3>
                <form runat="server" action="/index.aspx">
                    您希望哪类商品能多些促销活动呢？<br />
                    <% 
                        foreach (Shop.Model.Vote vote in voteList)
                        {%>
                    <input id="vid" type="hidden" name="vid"  value="<%=vote.vid %>"/>
                    <input id="total1" type="hidden"  name="total1" value="<%=vote.vtotal1 %>"/>                
                    <input id="total2" type="hidden"  name="total2" value="<%=vote.vtotal2 %>"/> 
                    <input id="total3" type="hidden"  name="total3" value="<%=vote.vtotal3 %>"/> 
                    <input id="total4" type="hidden"  name="total4" value="<%=vote.vtotal4 %>"/>
                    <input id="Radio" type="radio" name="radio"  onclick="checkRadio(this)" value="1"/>
                       <label for="Radio"><%=vote.vcontent1 %>&nbsp&nbsp&nbsp</label>&nbsp &nbsp 票数<%=vote.vtotal1 %>票<br />                                                                                       
                    <input id="Radio2" type="radio"name="radio"   onclick="checkRadio(this)" value="2"/>
                       <label for="Radio"><%=vote.vcontent2 %>&nbsp&nbsp&nbsp</label>&nbsp &nbsp 票数<%=vote.vtotal2 %>票 <br />                                                          
                    <input id="Radio3" type="radio" name="radio"  onclick="checkRadio(this)" value="3"/>
                        <label for="Radio"><%=vote.vcontent3 %>&nbsp&nbsp&nbsp</label>&nbsp &nbsp 票数<%=vote.vtotal3 %>票 <br />   
                    <input id="Radio4" type="radio" name="radio" onclick="checkRadio(this)" value="4"/>
                       <label for="Radio"><%=vote.vcontent4 %>&nbsp&nbsp&nbsp</label>&nbsp &nbsp 票数<%=vote.vtotal4 %>票 <br />                
                    <label class="ui-green"><input type="button" onclick="add()" value="提交" /></label><br /><br />
                   <% }
                    %>
                    &nbsp;</form>
				</div>
			</div>
			<div class="spacer clear"></div>
			<div class="hot">
				<h2>热卖推荐</h2>
				<ul class="product clearfix">
                    <%
                       foreach(Shop.Model.Goods  Goods in GoodsList)
                       {%>
                            <%
                           if (Goods.hot == 1)
                           {%> 
                                <li>
                                    <dl>
                                        <dt class="yang"><a href="/goods/GoodsDetail.aspx?GoodsId=<%=Goods.gid %>" target="_blank"><img src="<%=Goods.goodsphoto %>" /></a></dt>
                                        <dd class="title"><a href="/goods/GoodsDetail.aspx?GoodsId=<%=Goods.gid %>" target="_blank"><%=Goods.gname %></a></dd>
                                        <dd class="price">￥<%=Goods.goodsprice%></dd>
                                    </dl>
                                </li>
                           <%}
                                 %>
                    <%}
                             %>
				</ul>
			</div>
			
		</div>
		<div class="clear"></div>
</div>
&nbsp;
<div id="footer">
	<%Server.Execute("/common/Footer.aspx"); %>
</div>
</body>
</html>

