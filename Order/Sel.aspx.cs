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
    public partial class Sel : PageBase
    {
        private const double P0 = 101325;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PrepareClass.PrepareData();
                btnCalcel.OnClientClick = Window1.GetHideReference();

            }
        }

        protected void Button3_Click(object sender, EventArgs e) 
        {
            this.fanListView.DataSource = null;
          
            this.fanListView.DataBind();

            double air = Convert.ToDouble(this.txtAirFlow.Text) / Convert.ToDouble(MeasureClass.GetSiValue(this.comboBox1.SelectedValue));
            air *= 3600.0;
            double staticpres = Convert.ToDouble(this.txtStaticPres.Text) / Convert.ToDouble(MeasureClass.GetSiValue(this.comboBox2.SelectedValue));
            //QueryClass.DianYuanPinLuCompare = Convert.ToDouble(comboBoxPL.SelectedValue);
            QueryClass.Diameter = Convert.ToDouble(Diameter.Text);
            QueryClass.RPM = Convert.ToDouble(RPM.Text);


            QueryClass.MinTolerance = Convert.ToDouble(nbxStart.Text);
            QueryClass.MaxTolerance = Convert.ToDouble(nbxEnd.Text);


            #region tpfstart 20190716

            //QueryClass.轮毂高度 = "";
            QueryClass.轴孔大径 = 大径.Text;
            QueryClass.锥度 = 锥度.Text;
            QueryClass.键宽 = 键宽.Text; 
            QueryClass.轴伸L = 轴伸.Text;
            QueryClass.我不知道接口尺寸 = 我不知道接口尺寸.Checked;

            QueryClass.是否其它材质 = 是否其它材质.Checked;
            QueryClass.其它材质 = 其它材质.Text;
            QueryClass.叶片材质 = (ALU.Checked?"ALU,":"") +  (FRP.Checked ? "FRP," : "") + (PAG.Checked ? "PAG," : "");

            QueryClass.前吹后吹 = 前吹后吹.SelectedText;
            QueryClass.鼓风引风 = 鼓风引风.SelectedText;

            QueryClass.储存温度min = 储存温度min.Text;
            QueryClass.储存温度max = 储存温度max.Text;

            QueryClass.防腐要求 = 防腐要求.SelectedText;
            QueryClass.备注项 = 备注项.Text;
            #endregion  tpfend 20190716



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



            table = new DataTable();
            table.Columns.Add(new DataColumn("key", typeof(String)));
            table.Columns.Add(new DataColumn("val1", typeof(String)));
            table.Columns.Add(new DataColumn("val2", typeof(String)));
            table.Columns.Add(new DataColumn("issame", typeof(String)));

            foreach (System.Reflection.PropertyInfo p in fanClass.GetType().GetProperties())
            {
                if ("前吹后吹".Equals(p.Name))
                {
                    row = table.NewRow();
                    row[0] = p.Name;
                    row[1] = QueryClass.前吹后吹;
                    row[2] = p.GetValue(fanClass);
                    row[3] = p.GetValue(fanClass).Equals(QueryClass.前吹后吹)?"":"不一致";
                    table.Rows.Add(row);
                }
                if ("鼓风引风".Equals(p.Name))
                {
                    row = table.NewRow();
                    row[0] = p.Name;
                    row[1] = QueryClass.鼓风引风;
                    row[2] = p.GetValue(fanClass);
                    row[3] = p.GetValue(fanClass).Equals(QueryClass.鼓风引风) ? "" : "不一致";
                    table.Rows.Add(row);
                }

                if ("叶片材质".Equals(p.Name))
                {
                    row = table.NewRow();
                    row[0] = p.Name;
                    row[1] = QueryClass.是否其它材质? QueryClass.其它材质: QueryClass.叶片材质;
                    row[2] = p.GetValue(fanClass);
                    row[3] = QueryClass.叶片材质.Contains((string)p.GetValue(fanClass)) ? "" : "不一致";
                    table.Rows.Add(row);
                }

                if ("储存温度min".Equals(p.Name))
                {
                    row = table.NewRow();
                    row[0] = p.Name;
                    row[1] = QueryClass.储存温度min;
                    row[2] = p.GetValue(fanClass);
                    row[3] = p.GetValue(fanClass).Equals(QueryClass.储存温度min) ? "" : "不一致";
                    table.Rows.Add(row);
                }
                if ("储存温度max".Equals(p.Name))
                {
                    row = table.NewRow();
                    row[0] = p.Name;
                    row[1] = QueryClass.储存温度max;
                    row[2] = p.GetValue(fanClass);
                    row[3] = p.GetValue(fanClass).Equals(QueryClass.储存温度max) ? "" : "不一致";
                    table.Rows.Add(row);
                }
                if ("防腐要求".Equals(p.Name))
                {
                    row = table.NewRow();
                    row[0] = p.Name;
                    row[1] = QueryClass.防腐要求;
                    row[2] = p.GetValue(fanClass);
                    row[3] = p.GetValue(fanClass).Equals(QueryClass.防腐要求) ? "" : "不一致";
                    table.Rows.Add(row);
                }

            }

            if (!"".Equals(QueryClass.备注项))
            {
                row = table.NewRow();
                row[0] = "备注项";
                row[1] = QueryClass.备注项;
                row[2] = "";
                row[3] = "";
                table.Rows.Add(row);
            }

            Grid1.DataSource = table;
            Grid1.DataBind();

            //if (e.RowIndex == 0)
            //{
            //    mainRegion.IFrameUrl = "http://www.baidu.com";
            //    PageContext.RegisterStartupScript("$('#" + mainRegion.ClientID + "').find('iframe').attr('src','" + "./CalendarFrame.aspx?userid=" + 1 + "');");

            //}
            //else
            //{
            //    mainRegion.IFrameUrl = "http://www.163.com";

            //}

            //PageContext.RegisterStartupScript("$('#" + mainRegion.ClientID + "').find('iframe').attr('src','" + "./EChart.aspx?fanid=" + fanClass.FanID + "&p1=" + txtAirFlow.Text + "&p2=" + txtStaticPres.Text + "  ');");

            PageContext.RegisterStartupScript("bindCalendar('" + fanClass.FanID + "','" + txtAirFlow.Text + "','" + txtStaticPres.Text + "');");


            //PageContext.RegisterStartupScript("$('#" + mainRegion.ClientID + "').find('iframe').attr('src','" + "./CalendarFrame.aspx?userid=" + 1 + "');");

            //Alert.ShowInTop(String.Format("你点击了第 {0} 行（单击）", e.RowIndex + 1));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //string openUrl = String.Format("./passvalue_iframe_iframe.aspx?selected={0}", HttpUtility.UrlEncode(txtInletAirDens.Text));

            PageContext.RegisterStartupScript(Window1.GetSaveStateReference(txtInletAirDens.ClientID)
                    + Window1.GetShowReference());
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(Window2.GetShowReference());
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(Window3.GetShowReference());
        }
        protected void btnCalc_Click(object sender, EventArgs e)
        {
            double retValue = 1.3;
            retValue = calculateAirDensity();
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(retValue.ToString()) + ActiveWindow.GetHideReference());

        }

        private double calculateAirDensity()
        {
            double airTemperature = 0.0;
            double H = 0.0;
            double inletAirHumidity = 0.0;

            airTemperature = Convert.ToDouble(txtAirTemper.Text);
            airTemperature = con.TemperConvert(airTemperature, this.cbAirTemper.SelectedIndex);

            H = Convert.ToDouble(txtSiteElevat.Text);
            H = con.FttoM(H, this.cbSiteEleva.SelectedIndex);

            inletAirHumidity = Convert.ToDouble(txtAirHumi.Text);

            double result = getAirDensity(airTemperature, H, inletAirHumidity);
            result = Math.Round(result, 3);
            return result;
        }



        private Double getAirDensity(double airTemperature, double H, double inletAirHumidity)
        {
            inletAirHumidity /= 100;
            Decimal result = new Decimal(0.0);

            Decimal P = new Decimal(P0 - (98.0665 * H / 12));
            //  x=0.622*(Φ*Pb)/(P-Φ*Pb)
            Decimal x = Decimal.Divide(Decimal.Multiply(new Decimal(0.622), Decimal.Multiply(new Decimal(inletAirHumidity), PbPa(airTemperature))), P - Decimal.Multiply(new Decimal(inletAirHumidity), PbPa(airTemperature)));
            //  R=(287.1+461.4x)/(1+x)
            Decimal R = Decimal.Divide((new Decimal(287.1) + Decimal.Multiply(new Decimal(461.4), x)), (new Decimal(1) + x));
            //  ρ=P/(R(t+273.15)) (kg/m3)
            result = Decimal.Divide(P, Decimal.Multiply(R, new Decimal(airTemperature + 273.15)));

            return Math.Round(Convert.ToDouble(result), 3);
        }
        private Decimal PbPa(double x)
        {
            Decimal result = new Decimal(0.0);

            result = result - Decimal.Multiply(new Decimal(0.00000004), new Decimal(Math.Pow(x, 6)));
            result = result + Decimal.Multiply(new Decimal(0.00001089), new Decimal(Math.Pow(x, 5)));
            result = result - Decimal.Multiply(new Decimal(0.00026706), new Decimal(Math.Pow(x, 4)));
            result = result + Decimal.Multiply(new Decimal(0.03721893), new Decimal(Math.Pow(x, 3)));
            result = result + Decimal.Multiply(new Decimal(1.52895877), new Decimal(Math.Pow(x, 2)));
            result = result + Decimal.Multiply(new Decimal(41.67425407), new Decimal(x));
            result = result + new Decimal(607.01661633);

            return result;
        }

        protected void 我不知道接口尺寸_CheckedChanged(object sender, CheckedEventArgs e)
        {
            if (我不知道接口尺寸.Checked)
            {
                轴伸.Enabled = false;
                大径.Enabled = false;
                锥度.Enabled = false;
                键宽.Enabled = false;
            }
            else
            {
                轴伸.Enabled = true;
                大径.Enabled = true;
                锥度.Enabled = true;
                键宽.Enabled = true;

            }
        }

        protected void 是否其它材质_CheckedChanged(object sender, CheckedEventArgs e)
        {
            if (是否其它材质.Checked)
            {
                ALU.Enabled = false;
                FRP.Enabled = false;
                PAG.Enabled = false;
                其它材质.Enabled = true;
            }
            else
            {
                ALU.Enabled = true;
                FRP.Enabled = true;
                PAG.Enabled = true;
                其它材质.Enabled = false;

            }
        }
    }
}