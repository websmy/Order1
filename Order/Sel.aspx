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
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>


    <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>
            <f:Region ID="Region1" ShowBorder="false" Height="50px" ShowHeader="false"
                Position="Top" Layout="Fit" runat="server">
            </f:Region>
            <f:Region ID="Region2" RegionSplit="true" Width="300px"
                ShowHeader="false" Title="选型"
                EnableCollapse="true" Layout="Fit" RegionPosition="Left" runat="server">
                <Items>
                    <f:TabStrip ID="TabStrip1" Width="850px" Height="350px" ShowBorder="true" TabPosition="Top"
                        EnableTabCloseMenu="false" ActiveTabIndex="0"
                        runat="server">
                        <Tabs>
                            <f:Tab Title="输入选型条件" BodyPadding="5px" Layout="Fit"
                                runat="server">
                                <Items>
                                    <f:SimpleForm ID="SimpleForm1" ShowBorder="false"
                                        ShowHeader="true" Title="输入选型条件" LabelWidth="120px" runat="server" AutoScroll="true">
                                        <Items>

                                            <f:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="false" Title="风量信息">
                                                <Items>
                                                    <f:NumberBox Label="风量" ID="txtAirFlow" runat="server" Required="true" Text="100000" ShowRedStar="true" LabelWidth="70px" />

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
                                                    <f:NumberBox Label="压力大小" LabelWidth="80px" ID="txtStaticPres" Required="true" ShowRedStar="true" Text="666" runat="server" />
                                                    <f:DropDownList ID="comboBox2" runat="server" Label="压力单位" LabelWidth="80px">
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


                                            <f:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="false" Title="风压误差设置" Layout="Column">
                                                <Items>
                                                    <f:NumberBox ShowLabel="false" ID="nbxStart" Text="0.95" Required="true" ShowRedStar="true"   runat="server" MinValue="0" MaxValue="1" Width="80" />
                                                    <f:Label ID="Label1" runat="server" ShowLabel="false" Text="~" Margin="0 10 0 10"></f:Label>
                                                    <f:NumberBox ShowLabel="false" ID="nbxEnd" Text="1.05" Required="true" ShowRedStar="true" runat="server" MinValue="1" MaxValue="10" Width="80" />

                                                </Items>
                                            </f:GroupPanel>


                                            <f:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="false" Title="进口空气密度" Layout="Column">
                                                <Items>
                                                    <f:NumberBox ShowLabel="false" ID="txtInletAirDens" Text="1.2" Required="true" ShowRedStar="true" MinValue="0" MaxValue="10" runat="server" Width="80" />
                                                    <f:Label ID="Label4" runat="server" ShowLabel="false" Text="kg/m³" Margin="0 10 0 10"></f:Label>
                                                    <f:Button ID="Button2" runat="server" Text="计算"></f:Button>
                                                </Items>
                                            </f:GroupPanel>


                                            <f:Panel ID="Panel1" runat="server" ShowBorder="true" BodyPadding="5px" Layout="Column">
                                                <Items>
                                                    <f:DropDownList ID="comboBoxPL" runat="server" Label="频率" Required="true" ShowRedStar="true" LabelWidth="50px" Width="120px">
                                                        <f:ListItem Text="60" Value="60" Selected="true" />
                                                    </f:DropDownList>
                                                    <f:Label ID="Label2" runat="server" ShowLabel="false" Text="Hz" Margin="0 10 0 10"></f:Label>
                                                </Items>
                                            </f:Panel>

                                            <f:Button ID="Button3" CssClass="bgbtn" ToolTip="开始进行选型" runat="server" OnClick="Button3_Click" ValidateForms="SimpleForm1" Text="开始选型" Size="Large"></f:Button>


                                        </Items>
                                    </f:SimpleForm>
                                </Items>
                            </f:Tab>
                            <f:Tab Title="<span class='highlight'>选型结果</span>" BodyPadding="5px"
                                runat="server">
                                <Items>

                                    <f:Panel runat="server" ID="Panel3" ShowBorder="false" ShowHeader="false" Layout="VBox" >
                                        <Items>
                                            <f:Grid ID="fanListView" Title="选型结果"  ShowBorder="true" ShowHeader="true" AllowPaging="false" AutoScroll="true"
                                                runat="server" EnableCheckBoxSelect="true" DataKeyNames="FanID"  Height="300px"
                                                EnableMultiSelect="false" EnableRowClickEvent="true" OnRowClick="Grid1_RowClick">
                                                <Columns>
                                                    <f:RowNumberField />
                                                    <f:BoundField  DataField="FanCatagory" DataFormatString="{0}" HeaderText="型号" />
                                                    <f:BoundField  DataField="RPM" DataFormatString="{0}" HeaderText="转速（RPM）" />
                                                    <f:BoundField  DataField="FanID" DataFormatString="{0}" HeaderText="FanID" Hidden="true" />
                                                    <%--<f:TemplateField Width="80px" HeaderText="性别">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# GetGender(Eval("Gender")) %>'></asp:Label>
                                                </ItemTemplate>
                                            </f:TemplateField>
                                            <f:BoundField Width="80px" DataField="EntranceYear" HeaderText="入学年份" />
                                            <f:CheckBoxField Width="80px" RenderAsStaticField="true" DataField="AtSchool" HeaderText="是否在校" />
                                            <f:HyperLinkField HeaderText="所学专业" DataToolTipField="Major" DataTextField="Major"
                                                DataTextFormatString="{0}" DataNavigateUrlFields="Major" DataNavigateUrlFormatString="http://gsa.ustc.edu.cn/search?q={0}"
                                                UrlEncode="true" Target="_blank" ExpandUnusedSpace="True" />
                                            <f:ImageField Width="80px" DataImageUrlField="Group" DataImageUrlFormatString="~/res/images/16/{0}.png"
                                                HeaderText="分组">
                                            </f:ImageField>--%>
                                                </Columns>
                                            </f:Grid>

                                             
                                           
                                            <f:Grid ID="fanProp" Title="风机属性"  ShowBorder="true" ShowHeader="true" Margin="10 0 0 0 " AutoScroll="true"
                                                runat="server" DataKeyNames="FanID" AllowPaging="false"   Height="200px"
                                                EnableMultiSelect="false">
                                                <Columns>
                                                    <f:RowNumberField />

                                                    <f:BoundField  DataField="key" DataFormatString="{0}" HeaderText="属性" />
                                                    <f:BoundField  DataField="value" DataFormatString="{0}" HeaderText="值" />

                                                </Columns>
                                            </f:Grid>

                                      


                                        </Items>
                                    </f:Panel>

                                   <%-- <f:Button ID="Button1" Text="点击显示提示对话框" OnClientClick="selectMenu()" runat="server">
                                    </f:Button>--%>
                                </Items>
                            </f:Tab>

                        </Tabs>
                    </f:TabStrip>
                </Items>
            </f:Region>
            <f:Region ID="mainRegion" ShowHeader="true" Position="Center" Title="详细信息" AutoScroll="true"
                EnableIFrame="true" IFrameName="mainframe" IFrameUrl="about:blank" runat="server">
            </f:Region>
        </Regions>
    </f:RegionPanel>
    <%--<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="./data/menuMail.xml"></asp:XmlDataSource>--%>



    <script>

        function selectMenu() {
            window.frames['mainframe'].location.href = 'http://www.baidu.com';
        }



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
</asp:Content>
