<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Order.WebForm2" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="f" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CssContent" runat="server">
<%--    <link type="text/css" rel="stylesheet" href="./res/css/default.css" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <f:PageManager ID="PageManager2" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="Region2" RegionSplit="true" Width="200px" ShowHeader="false"
                    Title="目录" EnableCollapse="true" Layout="Fit" RegionPosition="Left" runat="server">
                    <Items>
                        <f:Accordion runat="server" ShowBorder="false" ShowHeader="false" ShowCollapseTool="true">
                            <Panes>
                                <f:AccordionPane runat="server" Title="面板一"  BodyPadding="2px 5px"
                                    Layout="Fit" ShowBorder="false">
                                    <Items>
                                        <f:Tree runat="server" ShowBorder="false" ShowHeader="false" ID="treeMenu">
                                        </f:Tree>   
                                    </Items>
                                </f:AccordionPane>
                                <f:AccordionPane runat="server" Title="面板二"  BodyPadding="2px 5px"
                                    ShowBorder="false">
                                    <Items>
                                        <f:Label Text="面板二中的文本" runat="server">
                                        </f:Label>
                                    </Items>
                                </f:AccordionPane>
                            </Panes>
                        </f:Accordion>

                        <%--<f:Label ID="Label1" runat="server" Label="Label" Text="Label"></f:Label>--%>
                    </Items>
                </f:Region>
                <%--<f:Region ID="Region3" ShowHeader="false" EnableIFrame="true" IFrameUrl="~/accordion/accordion_tree_index.htm"
                    IFrameName="main" Position="Center" runat="server">
                </f:Region>--%>
                <f:Region ID="Region1" runat="server" Position="Center"></f:Region>

            </Regions>
        </f:RegionPanel>
        <%--<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/common/menu.xml"></asp:XmlDataSource>--%>
   
    
</asp:Content>
