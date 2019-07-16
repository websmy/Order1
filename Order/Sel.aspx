<%@ Page Title="风机选型" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sel.aspx.cs" Inherits="Order.Sel" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="f" %>
<asp:Content ID="Content2" ContentPlaceHolderID="CssContent" runat="server">
    <style type="text/css">
        .bgbtn {
            width: 100%;
            height: 50px;
            border-width: 0;
            background-color: transparent;
        }

            .bgbtn .x-frame-ml, .bgbtn .x-frame-mc, .bgbtn .x-frame-mr,
            .bgbtn .x-frame-tl, .bgbtn .x-frame-tc, .bgbtn .x-frame-tr,
            .bgbtn .x-frame-bl, .bgbtn .x-frame-bc, .bgbtn .x-frame-br {
                background-image: none;
                background-color: transparent;
            }
    </style>
    <link type="text/css" rel="stylesheet" href="./res/css/default.css" />
    <script src="res/js/echarts.min.js"></script>
    <%--<script src="res/js/jquery.min.js"></script>--%>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <f:PageManager ID="PageManager1" runat="server"></f:PageManager>

    <f:Panel ID="RegionPanel1" Layout="Column" ShowBorder="true" runat="server">
        <Items>

            <f:Panel ID="leftPanel" ColumnWidth="28%" ShowHeader="true" ShowBorder="true" Title="风机选型" Margin="50 0 5 0"
                runat="server">

                <Items>
                    <f:TabStrip ID="TabStrip1" ShowBorder="false"
                        ActiveTabIndex="0"
                        runat="server">
                        <Tabs>
                            <f:Tab Title="输入选型条件" BodyPadding="5px"
                                runat="server">
                                <Items>
                                    <f:SimpleForm ID="SimpleForm1" ShowBorder="false"
                                        ShowHeader="false" Title="输入选型条件" LabelWidth="80px" runat="server" AutoScroll="true">
                                        <Items>

                                            <f:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="false" Title="风量信息">
                                                <Items>
                                                    <f:NumberBox Label="风量" ID="txtAirFlow" runat="server" Required="true" Text="200000" ShowRedStar="true" LabelWidth="70px" />

                                                    <f:DropDownList ID="comboBox1" runat="server" Label="风量单位" LabelWidth="70px">
                                                        <f:ListItem Text="m³/s" Value="m³/s" />
                                                        <f:ListItem Text="m³/h" Value="m³/h" Selected="true" />
                                                        <f:ListItem Text="l/s" Value="l/s" />
                                                        <f:ListItem Text="l/h" Value="l/h" />
                                                        <f:ListItem Text="gallon/min" Value="gallon/min" />
                                                    </f:DropDownList>
                                                </Items>
                                            </f:GroupPanel>

                                            <f:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="false" Title="风压信息">
                                                <Items>
                                                    <f:RadioButtonList ID="RadioButtonList1" Label="压力类型" LabelWidth="70px" runat="server">
                                                        <f:RadioItem Text="静压" Value="jingya" Selected="true" />
                                                        <f:RadioItem Text="全压" Value="quanya" />
                                                    </f:RadioButtonList>
                                                    <f:NumberBox Label="压力大小"  ID="txtStaticPres" Required="true" ShowRedStar="true" Text="230" runat="server" />
                                                    <f:DropDownList ID="comboBox2" runat="server" Label="压力单位" >
                                                        <f:ListItem Text="Pa" Value="Pa" Selected="true" />
                                                        <f:ListItem Text="mm Hg" Value="mm Hg" />
                                                        <f:ListItem Text="mm H20" Value="mm H20" />
                                                        <f:ListItem Text="kPa" Value="kPa" />
                                                        <f:ListItem Text="ft H2O" Value="ft H2O" />
                                                        <f:ListItem Text="bar" Value="bar" />
                                                        <f:ListItem Text="atm" Value="atm" />
                                                    </f:DropDownList>

                                                </Items>
                                            </f:GroupPanel>





                                            <f:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="false" Title="进口空气密度" Layout="Column">
                                                <Items>
                                                    <f:NumberBox ShowLabel="false" ID="txtInletAirDens" Text="1.2" Required="true" ShowRedStar="true" MinValue="0" MaxValue="10" runat="server" Width="80" />
                                                    <f:Label ID="Label4" runat="server" ShowLabel="false" Text="kg/m³" Margin="0 10 0 10"></f:Label>
                                                    <f:Button ID="Button2" runat="server" Text="计算" OnClick="Button2_Click"></f:Button>
                                                </Items>
                                            </f:GroupPanel>


                                           <%-- <f:Panel ID="Panel1" runat="server" ShowBorder="true" BodyPadding="5px" Layout="Column">
                                                <Items>
                                                    <f:DropDownList ID="comboBoxPL" runat="server" Label="频率" Required="true" ShowRedStar="true" LabelWidth="50px" Width="120px">
                                                        <f:ListItem Text="60" Value="60" Selected="true" />
                                                    </f:DropDownList>
                                                    <f:Label ID="Label2" runat="server" ShowLabel="false" Text="Hz" Margin="0 10 0 10"></f:Label>
                                                </Items>
                                            </f:Panel>--%>

                                            <f:Panel ID="Panel2" runat="server" ShowBorder="false" BodyPadding="5px" Layout="Column">
                                                <Items>
                                                    <f:NumberBox ID="Diameter" runat="server" Label="风机直径"   Text="2134"  Width="200" MinValue="0"></f:NumberBox>

                                                    <f:DropDownList ID="DUnit" runat="server" Width="70">
                                                        <f:ListItem Text="mm" Value="60" Selected="true" />
                                                    </f:DropDownList>


                                                </Items>
                                            </f:Panel>

                                            <f:Panel ID="Panel5" runat="server" ShowBorder="false" BodyPadding="5px" Layout="Column">
                                                <Items>
                                                    <f:NumberBox ID="RPM" runat="server" Label="风机转速"  Width="200"  Text="550" MinValue="0"></f:NumberBox>
                                                    <f:DropDownList ID="DropDownList1" runat="server" Width="70">
                                                        <f:ListItem Text="rpm" Value="60" Selected="true" />
                                                    </f:DropDownList>
                                                </Items>
                                            </f:Panel>




                                            <f:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="false" Title="误差设置" Layout="Column">
                                                <Items>
                                                    <f:NumberBox ShowLabel="false" ID="nbxStart" Text="0.5" Required="true" ShowRedStar="true" runat="server" MinValue="0" MaxValue="1" Width="80" />
                                                    <f:Label ID="Label1" runat="server" ShowLabel="false" Text="~" Margin="0 10 0 10"></f:Label>
                                                    <f:NumberBox ShowLabel="false" ID="nbxEnd" Text="1.5" Required="true" ShowRedStar="true" runat="server" MinValue="1" MaxValue="10" Width="80" />

                                                </Items>
                                            </f:GroupPanel>


                                             <f:GroupPanel ID="GroupPanel5" runat="server" EnableCollapse="false" Title="接口尺寸"   >
                                                <Items>
                                                    <f:NumberBox ID="轴伸" runat="server"   Label="轴伸L(mm)"  Text="106" MinValue="0"   ></f:NumberBox>
                                                    <f:NumberBox ID="大径" runat="server"   Label="大径d(mm)"  Text="65" MinValue="0"   ></f:NumberBox>

                                                    <f:TextBox ID="锥度" runat="server" Label="锥度" Text="1:20"></f:TextBox>

                                                    <f:NumberBox ID="键宽" runat="server"   Label="键宽d(mm)" Text="18"  MinValue="0"  ></f:NumberBox>
                                                 <f:Button ID="Button1" runat="server" Text="显示接口示意图" OnClick="Button1_Click"></f:Button>
                                                    <f:CheckBox ID="我不知道接口尺寸" runat="server" Label="" Text="我不知道接口尺寸"  AutoPostBack="true"  OnCheckedChanged="我不知道接口尺寸_CheckedChanged"></f:CheckBox>
                                                </Items>
                                            </f:GroupPanel>

                                            <f:Panel ID="Panel1" runat="server" ShowBorder="false" BodyPadding="5px" Layout="Column">
                                                <Items>
                                                    <f:DropDownList ID="前吹后吹" runat="server"  AutoSelectFirstItem="false"  Label="前吹/后吹"    Required="true"  ShowRedStar="true"  >
                                                        <f:ListItem Text="前吹" Value="前吹"/>
                                                        <f:ListItem Text="后吹" Value="后吹"/>
                                                    </f:DropDownList>
                                            <f:Button ID="Button4" runat="server" Text="显示前吹/后吹示意图" OnClick="Button4_Click"></f:Button>

                                                </Items>
                                            </f:Panel>

                                             <f:Panel ID="Panel9" runat="server" ShowBorder="false" BodyPadding="5px" Layout="Column">
                                                <Items>
                                                    <f:DropDownList ID="鼓风引风" runat="server"  AutoSelectFirstItem="false"  Label="鼓风/引风"    Required="true"  ShowRedStar="true"  >
                                                        <f:ListItem Text="鼓风" Value="鼓风" />
                                                        <f:ListItem Text="引风" Value="引风" />
                                                    </f:DropDownList>
                                                    <f:Label ID="Label2" runat="server"  Text="鼓风：叶轮带动气流吹向客户端设备进行通风制冷；引风：叶轮带动气流从客户端设备抽风进行通风制冷；"></f:Label>
                                                </Items>
                                            </f:Panel>


                                             <f:GroupPanel ID="GroupPanel6" runat="server" EnableCollapse="false" Layout="Column" Title="叶片材质要求"   >
                                                <Items>
                                                    <f:CheckBox ID="ALU" runat="server" Label="" Text="ALU"  ></f:CheckBox>
                                                    <f:CheckBox ID="FRP" runat="server" Label="" Text="FRP"  ></f:CheckBox>
                                                    <f:CheckBox ID="PAG" runat="server" Label="" Text="PAG"  ></f:CheckBox>
                                                    <f:CheckBox ID="是否其它材质" runat="server" Label="" Text="其它" AutoPostBack="true" OnCheckedChanged="是否其它材质_CheckedChanged"></f:CheckBox>
                                                </Items>
                                                 
                                                 <Items>
                                                     <f:TextBox ID="其它材质" runat="server"   Label="其它材质" Text="" Enabled="false" ></f:TextBox>
                                                 </Items>
                                            </f:GroupPanel>

                                               <f:GroupPanel ID="GroupPanel7" runat="server" EnableCollapse="false" Title="储存温度范围（℃）" Layout="Column">
                                                <Items>
                                                    <f:NumberBox ShowLabel="false" ID="储存温度min" Text="-20"  runat="server"  Width="80" />
                                                    <f:Label ID="Label3" runat="server" ShowLabel="false" Text="~" Margin="0 10 0 10"></f:Label>
                                                    <f:NumberBox ShowLabel="false" ID="储存温度max" Text="60" runat="server"  Width="80" />

                                                </Items>
                                            </f:GroupPanel>

                                              <f:Panel ID="Panel11" runat="server" ShowBorder="false" BodyPadding="5px">
                                                <Items>

                                                    <f:DropDownList ID="防腐要求" runat="server"   Label="防腐要求" >
                                                        <f:ListItem Text="C3" Value="C3" Selected="true" />
                                                        <f:ListItem Text="C4" Value="C4" />
                                                        <f:ListItem Text="C5" Value="C5"  />
                                                    </f:DropDownList>

                                                </Items>
                                            </f:Panel>

                                              <f:Panel ID="Panel12" runat="server" ShowBorder="false" BodyPadding="5px">
                                                <Items>

                                                    <f:TextArea ID="备注项"  EmptyText="特殊要求：比如采用焊接铝堵头、采用球铁轮毂、采用4个叶片、叶片不切角处理；" runat="server" Height="50px" Label="备注项" Text=""></f:TextArea>
                                                </Items>
                                            </f:Panel>








                                            <f:Button ID="Button3" CssClass="bgbtn" ToolTip="开始进行选型" runat="server" OnClick="Button3_Click" ValidateForms="SimpleForm1" Text="开始选型" Size="Large"></f:Button>


                                        </Items>
                                    </f:SimpleForm>


                                    <f:Window ID="Window1" Title="计算" runat="server"
                                        Target="Parent" Hidden="true"
                                        IsModal="True" Width="400px" Height="200px">

                                        <Items>
                                            <f:SimpleForm ID="SimpleForm2" runat="server" ShowBorder="false" BodyPadding="10px"
                                                ShowHeader="false" LabelAlign="Right">
                                                <Items>
                                                    <f:Panel ID="Panel6" runat="server" ShowBorder="false" BodyPadding="5px" Layout="Column">
                                                        <Items>
                                                            <f:NumberBox ID="txtAirTemper" runat="server" Label="温度" LabelWidth="110" Width="250" MinValue="0" Required="true" ShowRedStar="true"></f:NumberBox>
                                                            <f:DropDownList ID="cbAirTemper" runat="server" Width="70" >
                                                                <f:ListItem Text="℃" Value="0" Selected="true" />
                                                                <f:ListItem Text="℉" Value="1" Selected="true" />
                                                            </f:DropDownList>
                                                        </Items>
                                                    </f:Panel>

                                                    <f:Panel ID="Panel7" runat="server" ShowBorder="false" BodyPadding="5px" Layout="Column">
                                                        <Items>
                                                            <f:NumberBox ID="txtSiteElevat" runat="server" Label="海拔" LabelWidth="110" Width="250" MinValue="0" Required="true" ShowRedStar="true" ></f:NumberBox>
                                                            <f:DropDownList ID="cbSiteEleva" runat="server" Width="70">
                                                                <f:ListItem Text="m" Value="0" Selected="true" />
                                                                <f:ListItem Text="ft" Value="1" Selected="true" />
                                                            </f:DropDownList>
                                                        </Items>
                                                    </f:Panel>

                                                    <f:Panel ID="Panel8" runat="server" ShowBorder="false" BodyPadding="5px" Layout="Column">
                                                        <Items>
                                                            <f:NumberBox ID="txtAirHumi" runat="server" Label="进口空气湿度" EmptyText="0-100%" MinValue="0" MaxValue="100" LabelWidth="110" Width="250"  Required="true" ShowRedStar="true"></f:NumberBox>
                                                        </Items>
                                                    </f:Panel>


                                                    <f:Panel ID="Panel10" runat="server" ShowBorder="false"  BodyPadding="5px" Layout="Column">
                                                        <Items>
                                                            <f:Button ID="btnCalc" runat="server" OnClick="btnCalc_Click" Text="计算" ValidateForms="SimpleForm2" Margin="0 30 0 120 "></f:Button>
                                                            <f:Button ID="btnCalcel" runat="server" Text="取消"></f:Button>
                                                        </Items>
                                                    </f:Panel>





                                                </Items>
                                            </f:SimpleForm>
                                        </Items>

                                    </f:Window>



                                     <f:Window ID="Window2" Title="接口图" runat="server"  IsModal="false" Hidden="true">
                                        <Items>
                                            <f:Image ID="Image1" runat="server" ImageUrl="./img/jiekou.png" Label="接口尺寸示意图"></f:Image>
                                        </Items>
                                    </f:Window>

                                     <f:Window ID="Window3" Title="前吹后吹示意图" runat="server"  IsModal="false" Hidden="true">
                                        <Items>
                                            <f:Image ID="Image3" runat="server" ImageUrl="./img/qian.jpg" Label="前吹示意图"></f:Image>
                                            <f:Image ID="Image2" runat="server" ImageUrl="./img/hou.jpg" Label="后吹示意图"></f:Image>
                                        </Items>
                                    </f:Window>


                                </Items>
                            </f:Tab>
                            <f:Tab Title="<span class='highlight'>选型结果</span>" BodyPadding="0px"
                                runat="server">
                                <Items>

                                    <f:Panel runat="server" ID="Panel3" ShowBorder="false" ShowHeader="false">
                                        <Items>
                                            <f:Grid ID="fanListView" Title="选型结果" ShowBorder="true" ShowHeader="true" AllowPaging="false"
                                                runat="server" EnableCheckBoxSelect="true" DataKeyNames="FanID"
                                                EnableMultiSelect="false" EnableRowClickEvent="true" OnRowClick="Grid1_RowClick">
                                                <Columns>
                                                    <f:RowNumberField />
                                                    <f:BoundField DataField="FanCatagory" DataFormatString="{0}" HeaderText="型号" />
                                                    <f:BoundField DataField="RPM" DataFormatString="{0}" HeaderText="转速（RPM）" />
                                                    <f:BoundField DataField="FanID" DataFormatString="{0}" HeaderText="FanID" Hidden="true" />

                                                </Columns>
                                            </f:Grid>






                                        </Items>
                                    </f:Panel>






                                </Items>
                            </f:Tab>

                        </Tabs>
                    </f:TabStrip>
                </Items>

            </f:Panel>

            <f:Panel ID="mainRegion" ShowHeader="true" ColumnWidth="72%" Title="风机信息" ShowBorder="true" Margin="50 0 0 5"
                runat="server">

                <Items>
                    <f:ContentPanel ID="ContentPanel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="false" Title="ContentPanel">
                        <div id="main" style="width: 700px; height: 500px;"></div>
                    </f:ContentPanel>


                    <f:Panel ID="Panel4" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" Title="Panel">

                         <Items>
                            <f:Grid ID="Grid1" Title="风机结构属性对比（属性不一致的需要跟本公司确认）" ShowBorder="true" ShowHeader="true" Margin="10 0 0 0 "
                                runat="server" DataKeyNames="FanID" AllowPaging="false"
                                EnableMultiSelect="false">
                                <Columns>
                                    <f:RowNumberField />

                                    <f:BoundField DataField="key" DataFormatString="{0}" Width="150px" HeaderText="属性" />
                                    <f:BoundField DataField="val1" DataFormatString="{0}" Width="150px" HeaderText="输入值" />
                                    <f:BoundField DataField="val2" DataFormatString="{0}" Width="150px" HeaderText="实际值" />
                                    <f:BoundField DataField="issame" DataFormatString="{0}" Width="150px" HeaderText="对比" />

                                </Columns>
                            </f:Grid>
                        </Items>

                        <Items>
                            <f:Grid ID="fanProp" Title="该风机详细属性" ShowBorder="true" ShowHeader="true" Margin="10 0 0 0 "
                                runat="server" DataKeyNames="FanID" AllowPaging="false"
                                EnableMultiSelect="false">
                                <Columns>
                                    <f:RowNumberField />

                                    <f:BoundField DataField="key" DataFormatString="{0}" Width="150px" HeaderText="属性" />
                                    <f:BoundField DataField="value" DataFormatString="{0}" Width="150px" HeaderText="值" />

                                </Columns>
                            </f:Grid>
                        </Items>

                    </f:Panel>
                </Items>
            </f:Panel>


        </Items>
    </f:Panel>



    <script>

        //function selectMenu() {
        //    window.frames['mainframe'].location.href = 'http://www.baidu.com';
        //}



    <%--    var leftTreeID = '<%= leftTree.ClientID %>';

        function selectMenu(menuClassName) {
            // 选中当前菜单
            $('.menu ul li').removeClass('selected');
            $('.menu ul li.' + menuClassName).addClass('selected');

            // 展开树的第一个节点，并选中第一个节点下的第一个子节点（在右侧IFrame中打开）
            var tree = F(leftTreeID);
            var treeFirstChild = tree.getRootNode().firstChild;

            // 展开第一个节点（如果想要展开全部节点，调用 tree.expandAll();）
            treeFirstChild.expand();

            // 选中第一个链接节点，并在右侧IFrame中打开此链接
            var treeFirstLink = treeFirstChild.firstChild;
            tree.getSelectionModel().select(treeFirstLink);
            window.frames['mainframe'].location.href = treeFirstLink.data.href;

        }

        F.ready(function () {
            selectMenu('menu-mail');
        });--%>
</script>



    <script type="text/javascript">

        function getUrlParam(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }

        function bindCalendar(id, p1, p2) {
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
                        offset: 40
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
                        symbol: 'circle',
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

                            var a1, a2, aw, ap;
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



         //$(document).ready(function () {

         //    // page is now ready, initialize the calendar...
         //    var id = getUrlParam('fanid');
         //    var p1 = getUrlParam('p1');
         //    var p2 = getUrlParam('p2');
         //    bindCalendar(id, p1, p2);

         //});

    </script>
</asp:Content>
