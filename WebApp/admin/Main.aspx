<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebApp.admin.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Insert title here</title>
<link rel="stylesheet" href="/admin/css/bootstrap.min.css" />
<link rel="stylesheet" href="/admin/css/bootstrap-responsive.min.css" />
<link rel="stylesheet" href="/admin/css/uniform.css" />
<link rel="stylesheet" href="/admin/css/unicorn.main.css" />
<link rel="stylesheet" href="/admin/css/unicorn.grey.css" class="skin-color" />
<script type="text/javascript" src="/js/jquery-1.11.1.js"></script>
<script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="/admin/js/echarts.js"></script>  
</head>
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
        
        <!-- 为 ECharts 准备一个具备大小（宽高）的 DOM -->
        <div id="main-line" style="width: 100%;height:400px;"></div>

        <div style="width: 100%;height:400px;text-align:center;">           
            <<%--div style="width: 40%;height:400px; float:left;">
              
                  浏览最高商品： 浏览量：<%=max%>                    
            </div>--%>
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

<script type="text/javascript" src="/js/jquery-1.11.1.js"></script>
<script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="/admin/js/echarts.js"></script>

 <script type="text/javascript">

     //==============================<各板块下商品数量统计>====================================//
     // 基于准备好的dom，初始化echarts实例
     var myChart = echarts.init(document.getElementById('main-line'));

     // 使用刚指定的配置项和数据显示图表。
     myChart.setOption({
         title: {
             text: '<各小类下商品数量统计>'
         },
         tooltip: {},
         legend: {
             data: ['数量']
         },
         xAxis: {
             data: []
         },
         yAxis: {},
         series: [{
             name: '数量',
             type: 'bar',
             data: []
         }]
     });
     $.ajax({
         type: "post",
         url: "/admin/Main.aspx?flag=smallname",
         dataType: "JSON",
         success: function (data) {
             var varReceiver = data;
             //alert(varReceiver);
             //var varReceiver = jQuery.parseJSON(data);  
             //var varReceiver = JSON.parse(data);     //不需要转换为对象
             var varAxis = new Array();
             var varSeries = new Array();
             for (var i = 0; i < Object.keys(varReceiver).length ; i++) {
                 varAxis[i] = varReceiver[i].smallname;
                 varSeries[i] = varReceiver[i].smallclasscount;
             }
             //alert(varAxis);  //所有sname
             // 填入数据
             myChart.setOption({
                 xAxis: {
                     data: varAxis
                 },
                 series: [{
                     //根据名字对应到相应的系列
                     name: '数量',
                     data: varSeries
                 }]
             });
         },
         error: function (XMLHttpRequest, textStatus, errorThrown) {
             alert(errorThrown);
             alert('数据加载失败!请刷新此页面...', { icon: 5 });
         }
     }); 
</script>
