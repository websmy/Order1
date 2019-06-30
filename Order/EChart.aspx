<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EChart.aspx.cs" Inherits="Order.EChart" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="f" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="res/js/echarts.min.js"></script>
    <script src="res/js/jquery.min.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server"></f:PageManager>
        <div id="main" style="width: 700px; height: 500px;"></div>

        <f:Panel runat="server" ID="Panel2" ShowBorder="false" ShowHeader="false" AutoScroll="true">
            <Items>

                <f:Grid ID="fanProp" Title="风机属性" ShowBorder="true" ShowHeader="true" Margin="10 0 0 0 " Height="300px" AutoScroll="true"
                    runat="server" DataKeyNames="FanID" AllowPaging="false"
                    EnableMultiSelect="false">
                    <Columns>
                        <f:RowNumberField />

                        <f:BoundField DataField="key" DataFormatString="{0}" HeaderText="属性"   Width="300px"   />
                        <f:BoundField DataField="value" DataFormatString="{0}" HeaderText="值" Width="300px"  />

                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>

    </form>


     <script type="text/javascript">

         function getUrlParam(name) {
             var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
             var r = window.location.search.substr(1).match(reg);
             if (r != null) return unescape(r[2]); return null;
         }

         function bindCalendar(id,p1,p2) {
             // 基于准备好的dom，初始化echarts实例
             var myChart = echarts.init(document.getElementById('main'));

             var symbolSize = 10;
             var data = [[p1, p2]];
             var points = [];

             var option = {
                 title: {
                     text: '风机曲线图'
                 },
                 legend: {
                     data: ['风量静压曲线', '工况点', '风量功率曲线', '风量全压曲线'],
                     //backgroundColor: 'rgba(0,100,50,0.2)'
                 },

                 tooltip: {

                     axisPointer: {
                         type: 'cross'
                     },
                     //formatter: function (params) {
                     //    var data = params.data || [0, 0];
                     //    console.log(data);
                     //    return '风量:' + data[0] + ', '+ '压力:' + data[1];
                     //}
                 },
                 grid: {
                     //top: 70,
                     //bottom: 50
                     //left: '3%',
                     //right: '4%',
                     //bottom: '3%',
                     //containLabel: true
                 },

                 toolbox: {
                     feature: {
                         dataView: { show: true, readOnly: false },
                         restore: { show: true },
                         saveAsImage: { show: true }
                     }
                 },


                 xAxis: [
                     {
                         name: '风量 Q (m3/h)',
                         nameTextStyle: {
                             color: "#657c97",
                             padding: [20, 0, 0, 20],
                             fontFamily: "#Arial",
                             fontSize: 12
                         },

                         type: 'value',
                         nameLocation: 'middle',

                     }
                 ],

                 yAxis: [
                     {
                         name: '压力 P(Pa)',
                         padding: [0, 400, 0, 0],
                         position: 'left',
                         type: 'value',
                         nameLocation: 'end'
                     },
                     {
                         show: false,
                         //axisLine: {
                         //    lineStyle: {
                         //        color: '#FF0000'
                         //    }
                         //},

                         axisLine: { show: false },
                         axisTick: { show: false },
                         splitLine: { show: false },
                         name: '工况点1',
                         position: 'left',
                         offset: 30,
                         nameLocation: 'middle',
                         type: 'value'
                         //inverse: true
                     }
                     ,
                     {
                         name: '轴功率N (W)',
                         position: 'right',
                         nameLocation: 'end',
                         type: 'value'
                         //inverse: true
                     },
                     {
                         show: false,
                         name: '全压',
                         position: 'left',
                         type: 'value',
                         nameLocation: 'middle',
                         offset:40
                     },

                 ],

                 series: [
                     {
                         name: '风量静压曲线',
                         id: 'l1',
                         type: 'line',
                         smooth: true,
                         yAxisIndex: 0,
                         symbolSize: symbolSize
                         //data: data
                     },

                     {
                         name: '工况点',
                         id: 'l2',
                         type: 'line',
                         smooth: true,
                         yAxisIndex: 1,
                         symbol:'circle',
                         symbolSize: 20,
                         data: data
                     },
                     {
                         name: '风量功率曲线',
                         id: 'l3',
                         type: 'line',
                         smooth: true,
                         yAxisIndex: 2,
                         symbolSize: symbolSize
                     }
                     ,
                     {
                         name: '风量全压曲线',
                         id: 'l4',
                         type: 'line',
                         smooth: true,
                         yAxisIndex: 3,
                         symbolSize: symbolSize
                     }

                 ]
             };

             var zr = myChart.getZr();


             //zr.on('click', function (params) {
             //    var pointInPixel = [params.offsetX, params.offsetY];
             //    var pointInGrid = myChart.convertFromPixel('grid', pointInPixel);

             //    if (myChart.containPixel('grid', pointInPixel)) {
             //        data.push(pointInGrid);

             //        myChart.setOption({
             //            series: [{
             //                id: 'a',
             //                data: data
             //            }]
             //        });
             //    }
             //});

             zr.on('mousemove', function (params) {
                 var pointInPixel = [params.offsetX, params.offsetY];
                 zr.setCursorStyle(myChart.containPixel('grid', pointInPixel) ? 'copy' : 'default');
             });

             var transresult = [];

             $.ajax({
                 type: "post",
                 async: false,
                 url: "GetValue.ashx?id=" + id,
                 data: { test: "test" }, //发送到服务器的参数
                 datatype: "json",
                 success: function (result) {
                     if (result) {

                         var rtdata = eval("(" + result + ")");
                         if (rtdata.length > 0) {
                             console.log(rtdata);
                         }
                         //alert(result);
                         //eval("transresult=" + result);
                         //console.log(result);
                         //alert(transresult[0].Month);

                         var sdata = [];
                         var sdataW = [];
                         var sdataP = [];

                         for (var i = 0; i < rtdata.length - 1; i++) {
                             var sdataArray = [];
                             var sdataArrayW = [];
                             var sdataArrayP = [];
                             
                             var a1, a2, aw ,ap;
                             a1 = parseInt(rtdata[i].Q).toFixed(0);
                             a2 = parseInt(rtdata[i].S).toFixed(0);
                             aw = parseInt(rtdata[i].W).toFixed(0);
                             ap = parseInt(rtdata[i].P).toFixed(0);
                             sdataArray[0] = a1;
                             sdataArray[1] = a2;

                             sdataArrayW[0] = a1;
                             sdataArrayW[1] = aw;

                             sdataArrayP[0] = a1;
                             sdataArrayP[1] = ap;

                             sdata.push(sdataArray);
                             sdataW.push(sdataArrayW);
                             sdataP.push(sdataArrayP);
                         }

                         option.series[0].data = sdata;
                         option.series[2].data = sdataW;
                         option.series[3].data = sdataP;
                         //option.series[0].data = [
                         //    [transresult[0].Q, transresult[0].S],
                         //    [transresult[1].Q, transresult[1].S],
                         //    [transresult[2].Q, transresult[2].S],
                         //    [transresult[3].Q, transresult[3].S],
                         //    [transresult[4].Q, transresult[4].S]
                         //];

                         var max = Math.floor(rtdata[rtdata.length - 1].maxS) > Math.floor(rtdata[rtdata.length - 1].maxP) ? Math.floor(rtdata[rtdata.length - 1].maxS) : Math.floor(rtdata[rtdata.length - 1].maxP);
                         var min = Math.ceil(rtdata[rtdata.length - 1].minS) < Math.ceil(rtdata[rtdata.length - 1].minP) ? Math.ceil(rtdata[rtdata.length - 1].minS) : Math.ceil(rtdata[rtdata.length - 1].minP)


                         option.yAxis[0].min = min;
                         option.yAxis[0].max = max;

                         option.yAxis[1].min = min;
                         option.yAxis[1].max = max;

                         option.yAxis[3].min = min;
                         option.yAxis[3].max = max;




                         option.yAxis[2].min = Math.ceil(rtdata[rtdata.length - 1].minW);
                         option.yAxis[2].max = Math.ceil(rtdata[rtdata.length - 1].maxW);

                         option.xAxis[0].min = Math.ceil(rtdata[rtdata.length - 1].minQ);
                         option.xAxis[0].max = Math.floor(rtdata[rtdata.length - 1].maxQ);



                         myChart.setOption(option);
                     }
                 },
                 error: function (errorMsg) {
                     alert("request data failed!!!");
                 }
             });

             //myChart.setOption(option);
         }
        // 使用刚指定的配置项和数据显示图表。
        


         $(document).ready(function () {

             // page is now ready, initialize the calendar...
             var id = getUrlParam('fanid');
             var p1 = getUrlParam('p1');
             var p2 = getUrlParam('p2');
             bindCalendar(id,p1,p2);

         });

     </script>

</body>
</html>
