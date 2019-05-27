using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order
{
    public partial class Sel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PrepareClass.PrepareData();
            }
        }

        protected void Button3_Click(object sender, EventArgs e) 
        {
            this.fanListView.DataSource = null;
            this.fanProp.DataSource = null;
            this.fanProp.DataBind();
            this.fanListView.DataBind();

            double air = Convert.ToDouble(this.txtAirFlow.Text) / Convert.ToDouble(MeasureClass.GetSiValue(this.comboBox1.SelectedValue));
            air *= 3600.0;
            double staticpres = Convert.ToDouble(this.txtStaticPres.Text) / Convert.ToDouble(MeasureClass.GetSiValue(this.comboBox2.SelectedValue));
            QueryClass.DianYuanPinLuCompare = Convert.ToDouble(comboBoxPL.SelectedValue);

            QueryClass.MinTolerance = Convert.ToDouble(nbxStart.Text);
            QueryClass.MaxTolerance = Convert.ToDouble(nbxEnd.Text);

            int repairIndex = 0;
            //if (comboxRepair.Enabled && comboxRepair.SelectedIndex != 0)
            //{
            //    repairIndex = comboxRepair.SelectedIndex;
            //}
            //else
            //{
            //    repairIndex = -1;
            //}
            if (this.RadioButtonList1.SelectedValue.Equals("jingya"))
            {
                QueryClass.SelectData(air, staticpres, "S", Convert.ToDouble(this.txtInletAirDens.Text), repairIndex);
            }
            else if (this.RadioButtonList1.SelectedValue.Equals("quanya"))
            {
                QueryClass.SelectData(air, staticpres, "T", Convert.ToDouble(this.txtInletAirDens.Text), repairIndex);
            }

            ////start 2013-5-24
            //List<string> blist = new List<string>();
            //if (comboBoxType.SelectedIndex != 0)
            //{
            //    foreach (KeyValuePair<string, FanClass> a in QueryClass.SelectedFan)
            //    {
            //        if (!CheckType(comboBoxType.SelectedIndex, a.Value.FanCatagory))
            //        {
            //            //if ((Convert.ToDouble(txtGongLv.Text) * 1000 * Convert.ToDouble(1)) < a.Value.PowerY(air))
            //            //{
            //            blist.Add(a.Key);
            //            continue;
            //            //}
            //        }
            //    }
            //}
            //if (comboBoxFangBao.SelectedIndex != 0)
            //{
            //    foreach (KeyValuePair<string, FanClass> a in QueryClass.SelectedFan)
            //    {
            //        if (!CheckFangBao(comboBoxFangBao.SelectedIndex, a.Value.FanCatagory))
            //        {
            //            //if ((Convert.ToDouble(txtGongLv.Text) * 1000 * Convert.ToDouble(1)) < a.Value.PowerY(air))
            //            //{
            //            blist.Add(a.Key);
            //            continue;
            //            //}
            //        }
            //    }
            //}

            //foreach (string strKey in blist)
            //{
            //    QueryClass.SelectedFan.Remove(strKey);
            //}
            ////end 2013-5-24
            //this.fanChartCurve.SelectAirFlow = Math.Round(air, 2);
            //this.fanChartCurve.SelectPressure = staticpres;
            //this.fanChartCurve.dens = Convert.ToDouble(txtInletAirDens.Text);

            ////StaticVal.风机类型 = typeZL.Checked ? "制冷轴流风机" : typeZFL.Checked ? "蒸发冷风机" : "制冷离心风机";
            //StaticVal.风量 = txtAirFlow.Text + " " + comboBox1.Text;
            //StaticVal.风量值 = txtAirFlow.Text;
            ////StaticVal.风量误差设置 = AirFlowToleranceContol.Min + "~" + AirFlowToleranceContol.Max;
            //StaticVal.静压还是全压 = FrmDesktop_label_SPressure.Checked ? "静压：" : "全压：";
            //StaticVal.静压还是全压值 = txtStaticPres.Text + " " + comboBox2.Text;
            //StaticVal.风压值 = Convert.ToDouble(txtStaticPres.Text);
            //StaticVal.密度 = txtInletAirDens.Text + " kg/m³";

            //StaticVal.防护等级 = comboBoxFHDJ.Text;
            //StaticVal.绝缘等级 = comboBoxJYDJ.Text;
            //StaticVal.电压 = comboBoxDY.Text + " V";
            //StaticVal.风筒板厚 = comboBoxFTBH.SelectedIndex != 5 ? comboBoxFTBH.Text : ultraNumericEditorFTBH.Text;

            //if (comboBoxType.SelectedIndex == 0)
            //{
            //    StaticVal.风筒类型 = comboBoxFTLX.Text;
            //    StaticVal.旋向角度 = "";
            //}
            //else
            //{
            //    StaticVal.风筒类型 = "";
            //    StaticVal.旋向角度 = comboBoxXXJD.Text;
            //}

            //StaticVal.换气类型 = comboBoxHQLX.Text;
            //StaticVal.防护网 = comboBoxFHW.Text;
            //StaticVal.认证 = comboBoxRZ.Text;
            //StaticVal.空间加热器 = comboBoxKJJRQ.Text;
            //if (comboxRepair.Enabled)
            //{
            //    StaticVal.修正因素 = comboxRepair.Text;
            //}
            //else
            //{
            //    StaticVal.修正因素 = "";
            //}


            //StaticVal.RDLC8 = txtGongLv.Text + " kW";
            //StaticVal.RDLC9 = cbDianYa.Text + " V";
            //StaticVal.RDLC10 = cbProNet.Text;
            //StaticVal.RDLC11 = cbRpm.Text + " rpm";
            //StaticVal.RDLC12 = cbJiHao.Text;

            //this.fanChartCurve1.SelectAirFlow = air;
            //this.fanChartCurve1.SelectPressure = staticpres;

            //this.InitListViewData();

            fanListView.DataSource = QueryClass.SelectedFan.Values;
            fanListView.DataBind();

            if (QueryClass.SelectedFan.Count > 0)
            {
                this.TabStrip1.ActiveTabIndex = 1;
            }
            else
            {
                Alert.Show("无符合条件的风机，请修改选型条件！");
            }

        }


        protected void Grid1_RowClick(object sender, GridRowClickEventArgs e)
        {

            object[] keys = fanListView.DataKeys[e.RowIndex];
            string a = keys[0].ToString();
            FanClass fanClass = QueryClass.Fanlist[a];

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("key", typeof(String)));
            table.Columns.Add(new DataColumn("value", typeof(String)));
            DataRow row = table.NewRow();

            foreach (System.Reflection.PropertyInfo p in fanClass.GetType().GetProperties())
            {
                row = table.NewRow();
                row[0] = p.Name;
                row[1] = p.GetValue(fanClass);
                table.Rows.Add(row);
            }
            fanProp.DataSource = table;
            fanProp.DataBind();

            //if (e.RowIndex == 0)
            //{
            //    mainRegion.IFrameUrl = "http://www.baidu.com";
            //    PageContext.RegisterStartupScript("$('#" + mainRegion.ClientID + "').find('iframe').attr('src','" + "./CalendarFrame.aspx?userid=" + 1 + "');");

            //}
            //else
            //{
            //    mainRegion.IFrameUrl = "http://www.163.com";

            //}

            PageContext.RegisterStartupScript("$('#" + mainRegion.ClientID + "').find('iframe').attr('src','" + "./EChart.aspx?fanid=" + fanClass.FanID + "&p1=" + txtAirFlow.Text + "&p2=" + txtStaticPres.Text + "  ');");


            //PageContext.RegisterStartupScript("$('#" + mainRegion.ClientID + "').find('iframe').attr('src','" + "./CalendarFrame.aspx?userid=" + 1 + "');");

            //Alert.ShowInTop(String.Format("你点击了第 {0} 行（单击）", e.RowIndex + 1));
        }
    }
}