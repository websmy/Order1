using FineUI;
using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Order
{
    public class PrepareClass
    {

        private static bool InitFlag = false;

        public static bool PrepareData()
        {
            try
            {
                if (InitFlag)
                {
                    return InitFlag;
                }
                QueryClass.Fanlist = new Dictionary<string, FanClass>();
                //QueryClass.ElectricMachineryList = new Dictionary<string, ElectricMachinery>();
                DataTable table = SQLHelper.Query("select * from fanInfo").Tables[0];
                DataTable table2 = SQLHelper.Query("select * from fanData").Tables[0];
                //DataTable table2 = DataAccess.GetFanData().Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    if (row["风机型号"].ToString().Equals("XYL-6.8-1"))
                    {

                    }
                    FanClass class2 = new FanClass();
                    class2 = new FanClass
                    {
                        FanID = row["风机型号"].ToString(),
                        FanCatagory = row["类型"].ToString(),
                        FanCode = class2.FanID,
                        Diameter = Order.Convert.ToDouble(row["直径"]),
                        MinFlow = Order.Convert.ToDouble(row["最小风量"]),
                        MaxFlow = Order.Convert.ToDouble(row["最大风量"]),

                        RPM = Order.Convert.ToInt32(row["G1"].ToString()),
                        DianYuanPinLu = Order.Convert.ToInt32(row["G2"].ToString()),
                        DianJiGongLv = row["G3"].ToString(),
                        DianJiXingHao = row["G4"].ToString(),
                        Weight = row["G5"].ToString(),

                        F1 = row["F1"].ToString(),
                        F2 = row["F2"].ToString(),
                        F3 = row["F3"].ToString(),
                        F4 = row["F4"].ToString(),
                        F5 = row["F5"].ToString(),
                        F6 = row["F6"].ToString(),
                        F7 = row["F7"].ToString(),
                        F8 = row["F8"].ToString(),
                        F9 = row["F9"].ToString(),
                        F10 = row["F10"].ToString(),
                        F11 = row["F11"].ToString(),
                        F12 = row["F12"].ToString(),
                        F13 = row["F13"].ToString(),
                        F14 = row["F14"].ToString(),
                        F15 = row["F15"].ToString(),
                        F16 = row["F16"].ToString(),
                        F17 = row["F17"].ToString(),
                        F18 = row["F18"].ToString(),
                        F19 = row["F19"].ToString(),
                        F20 = row["F20"].ToString(),
                        F21 = row["F21"].ToString(),
                        F22 = row["F22"].ToString(),
                        F23 = row["F23"].ToString(),
                        F24 = row["F24"].ToString(),
                        F25 = row["F25"].ToString(),
                        F26 = row["F26"].ToString(),
                        F27 = row["F27"].ToString(),
                        F28 = row["F28"].ToString(),
                        F29 = row["F29"].ToString(),
                        F30 = row["F30"].ToString(),
                        F31 = row["F31"].ToString(),
                        F32 = row["F32"].ToString(),
                        F33 = row["F33"].ToString(),
                        F34 = row["F34"].ToString(),
                        F35 = row["F35"].ToString(),
                        F36 = row["F36"].ToString(),
                        F37 = row["F37"].ToString(),
                        F38 = row["F38"].ToString(),
                        F39 = row["F39"].ToString(),
                        F40 = row["F40"].ToString(),

                        轮毂高度 = row["轮毂高度"].ToString(),
                        轴孔大径 = row["轴孔大径"].ToString(),
                        锥度 = row["锥度"].ToString(),
                        键宽 = row["键宽"].ToString(),
                        轴伸L = row["轴伸L"].ToString(),
                        叶片材质 = row["叶片材质"].ToString(),
                        前吹后吹 = row["前吹后吹"].ToString(),
                        鼓风引风 = row["鼓风引风"].ToString(),
                        储存温度min = row["储存温度min"].ToString(),
                        储存温度max = row["储存温度max"].ToString(),
                        防腐要求 = row["防腐要求"].ToString(),



                        //YeXing = row["叶型"].ToString(),
                        //FengXiang = row["换气方向"].ToString(),
                        //JueDu = Order.Convert.ToDouble(row["角度"]),
                        ////DianJiJiShu = Order.Convert.ToInt32(row["电源相数"]),
                        //RPM = Order.Convert.ToInt32(row["转速"]),
                        //DianYuanXiangShu = Order.Convert.ToInt32(row["电源相数"]),
                        ////DianYa = Order.Convert.ToInt32(row["电压"]),
                        ////DianYuanPinLu = Order.Convert.ToInt32(row["频率"]),
                        //MinFlow = Order.Convert.ToDouble(row["最小风量"]),
                        //MaxFlow = Order.Convert.ToDouble(row["最大风量"]),
                        //DianJiXingHao = row["电机型号"].ToString(),
                        //Description = row["说明"].ToString(),
                        //CurveJC = Order.Convert.ToInt32(row["曲线阶次"]),
                        //Temperature = row["样本温度"].ToString(),
                        ////Type = Order.Convert.ToInt32(row["风机类型"]),
                        ////ProtNet = Order.Convert.ToInt32(row["防护网"]),
                        //A = row["A"].ToString(),
                        //B = row["B"].ToString(),
                        //C = row["C"].ToString(),
                        //D = row["D"].ToString(),
                        //E = row["E"].ToString(),
                        //F = row["F"].ToString(),
                        //L = row["L"].ToString(),
                        //L1 = row["L1"].ToString(),

                        //L2 = row["L2"].ToString(),
                        //L3 = row["L3"].ToString(),
                        //L4 = row["L4"].ToString(),
                        //L5 = row["L5"].ToString(),
                        //L6 = row["L6"].ToString(),
                        //L7 = row["L7"].ToString(),
                        //L8 = row["L8"].ToString(),
                        //L9 = row["L9"].ToString(),

                        //H1 = row["H1"].ToString(),
                        //H2 = row["H2"].ToString(),
                        //H3 = row["H3"].ToString(),

                        //n_d2 = row["n_d2"].ToString(),

                        //n_d = row["n_d"].ToString(),
                        //Airflow = row["Airflow"].ToString(),
                        //Motordata = row["Motordata"].ToString(),
                        //Weight = row["Weight"].ToString(),
                        //标志位 = row["标志位"].ToString(),
                        //叶轮材料 = row["叶轮材料"].ToString(),
                        //图纸名称 = row["图纸名称"].ToString(),

                        //风筒 = row["风筒"].ToString(),
                        //防护网安装位置 = row["防护网安装位置"].ToString(),
                        //出线方式 = row["出线方式"].ToString(),
                        //紧固件 = row["紧固件"].ToString(),
                        //防护网材料 = row["防护网材料"].ToString(),
                        //机号 = row["机号"].ToString()

                    };

                    double jihao = getJiHao(class2.FanID);
                    double m = 0;
                    double n = 0;
                    double m1 = 0;
                    double n1 = 0;
                    double m2 = 0;
                    double n2 = 0;

                    //double JiaBanGreaterThan5RepairQ = 0;
                    //double JiaBanGreaterThan5RepairP = 0;
                    //double B3DianJiGreaterThan5RepairQ = 0;
                    //double B3DianJiGreaterThan5RepairP = 0;

                    Config c = new Config();
                    if (jihao <= 5)
                    {
                        m = System.Convert.ToDouble(c.GetXmlValue("JiaBanLessThan5RepairQ"));
                        n = System.Convert.ToDouble(c.GetXmlValue("JiaBanLessThan5RepairP"));

                        m1 = System.Convert.ToDouble(c.GetXmlValue("B3DianJiLessThan5RepairQ"));
                        n1 = System.Convert.ToDouble(c.GetXmlValue("B3DianJiLessThan5RepairP"));

                        m2 = m * m1;
                        n2 = n * n1;
                    }
                    else
                    {
                        m = System.Convert.ToDouble(c.GetXmlValue("JiaBanGreaterThan5RepairQ"));
                        n = System.Convert.ToDouble(c.GetXmlValue("JiaBanGreaterThan5RepairP"));

                        m1 = System.Convert.ToDouble(c.GetXmlValue("B3DianJiGreaterThan5RepairQ"));
                        n1 = System.Convert.ToDouble(c.GetXmlValue("B3DianJiLessThan5RepairP"));

                        m2 = m * m1;
                        n2 = n * n1;
                    }

                    class2.m = m;
                    class2.n = n;

                    class2.m1 = m1;
                    class2.n1 = n1;

                    class2.m2 = m2;
                    class2.n2 = n2;

                    DataRow[] rowArray = table2.Select(string.Format("风机型号='{0}'  and 温度={1} and 幂数={2}  and 类别='静压' ", row["风机型号"], class2.Temperature, class2.CurveJC));
                    DataRow[] rowArray2 = table2.Select(string.Format("风机型号='{0}'  and 温度={1} and 幂数={2}  and 类别='全压' ", row["风机型号"], class2.Temperature, class2.CurveJC));
                    DataRow[] rowArray3 = table2.Select(string.Format("风机型号='{0}'  and 温度={1} and 幂数={2}  and 类别='功率' ", row["风机型号"], class2.Temperature, class2.CurveJC));
                    DataRow[] rowArray4 = table2.Select(string.Format("风机型号='{0}'  and 温度={1} and 幂数={2}  and 类别='效率' ", row["风机型号"], class2.Temperature, class2.CurveJC));
                    DataRow[] rowArray5 = table2.Select(string.Format("风机型号='{0}'  and 温度={1} and 幂数={2}  and 类别='静压效率' ", row["风机型号"], class2.Temperature, class2.CurveJC));
                    if ((((rowArray.Length >= 1) && (rowArray2.Length >= 1)) && (rowArray3.Length >= 1)) && (rowArray4.Length >= 1))
                    {
                        class2.StaticParas[0] = Order.Convert.ToDouble(rowArray[0]["A"]);
                        class2.JiaBanStaticParas[0] = (n / Math.Pow(m, 3)) * class2.StaticParas[0];
                        class2.B3DianJiStaticParas[0] = (n1 / Math.Pow(m1, 3)) * class2.StaticParas[0];
                        class2.TwoKindStaticParas[0] = (n2 / Math.Pow(m2, 3)) * class2.StaticParas[0];

                        class2.StaticParas[1] = Order.Convert.ToDouble(rowArray[0]["B"]);
                        class2.JiaBanStaticParas[1] = (n / Math.Pow(m, 2)) * class2.StaticParas[1];
                        class2.B3DianJiStaticParas[1] = (n1 / Math.Pow(m1, 2)) * class2.StaticParas[1];
                        class2.TwoKindStaticParas[1] = (n2 / Math.Pow(m2, 2)) * class2.StaticParas[1];

                        class2.StaticParas[2] = Order.Convert.ToDouble(rowArray[0]["C"]);
                        class2.JiaBanStaticParas[2] = (n / Math.Pow(m, 1)) * class2.StaticParas[2];
                        class2.B3DianJiStaticParas[2] = (n1 / Math.Pow(m1, 1)) * class2.StaticParas[2];
                        class2.TwoKindStaticParas[2] = (n2 / Math.Pow(m2, 1)) * class2.StaticParas[2];

                        class2.StaticParas[3] = Order.Convert.ToDouble(rowArray[0]["D"]);
                        class2.StaticParas[4] = Order.Convert.ToDouble(rowArray[0]["E"]);
                        class2.StaticParas[5] = Order.Convert.ToDouble(rowArray[0]["F"]);
                        class2.StaticParas[6] = Order.Convert.ToDouble(rowArray[0]["G"]);
                        class2.JiaBanStaticParas[6] = n * class2.StaticParas[6];
                        class2.B3DianJiStaticParas[6] = n1 * class2.StaticParas[6];
                        class2.TwoKindStaticParas[6] = n2 * class2.StaticParas[6];





                        class2.TotalParas[0] = Order.Convert.ToDouble(rowArray2[0]["A"]);
                        class2.JiaBanTotalParas[0] = (n / Math.Pow(m, 3)) * class2.TotalParas[0];
                        class2.B3DianJiTotalParas[0] = (n1 / Math.Pow(m1, 3)) * class2.TotalParas[0];
                        class2.TwoKindTotalParas[0] = (n2 / Math.Pow(m2, 3)) * class2.TotalParas[0];

                        class2.TotalParas[1] = Order.Convert.ToDouble(rowArray2[0]["B"]);
                        class2.JiaBanTotalParas[1] = (n / Math.Pow(m, 2)) * class2.TotalParas[1];
                        class2.B3DianJiTotalParas[1] = (n1 / Math.Pow(m1, 2)) * class2.TotalParas[1];
                        class2.TwoKindTotalParas[1] = (n2 / Math.Pow(m2, 2)) * class2.TotalParas[1];

                        class2.TotalParas[2] = Order.Convert.ToDouble(rowArray2[0]["C"]);
                        class2.JiaBanTotalParas[2] = (n / Math.Pow(m, 1)) * class2.TotalParas[2];
                        class2.B3DianJiTotalParas[2] = (n1 / Math.Pow(m1, 1)) * class2.TotalParas[2];
                        class2.TwoKindTotalParas[2] = (n2 / Math.Pow(m2, 1)) * class2.TotalParas[2];

                        class2.TotalParas[3] = Order.Convert.ToDouble(rowArray2[0]["D"]);
                        class2.TotalParas[4] = Order.Convert.ToDouble(rowArray2[0]["E"]);
                        class2.TotalParas[5] = Order.Convert.ToDouble(rowArray2[0]["F"]);
                        class2.TotalParas[6] = Order.Convert.ToDouble(rowArray2[0]["G"]);
                        class2.JiaBanTotalParas[6] = n * class2.TotalParas[6];
                        class2.B3DianJiTotalParas[6] = n1 * class2.TotalParas[6];
                        class2.TwoKindTotalParas[6] = n2 * class2.TotalParas[6];


                        class2.PowerParas[0] = Order.Convert.ToDouble(rowArray3[0]["A"]);
                        class2.PowerParas[1] = Order.Convert.ToDouble(rowArray3[0]["B"]);
                        class2.PowerParas[2] = Order.Convert.ToDouble(rowArray3[0]["C"]);
                        class2.PowerParas[3] = Order.Convert.ToDouble(rowArray3[0]["D"]);
                        class2.PowerParas[4] = Order.Convert.ToDouble(rowArray3[0]["E"]);
                        class2.PowerParas[5] = Order.Convert.ToDouble(rowArray3[0]["F"]);
                        class2.PowerParas[6] = Order.Convert.ToDouble(rowArray3[0]["G"]);

                        class2.EfficiencyParas[0] = Order.Convert.ToDouble(rowArray4[0]["A"]);
                        class2.EfficiencyParas[1] = Order.Convert.ToDouble(rowArray4[0]["B"]);
                        class2.EfficiencyParas[2] = Order.Convert.ToDouble(rowArray4[0]["C"]);
                        class2.EfficiencyParas[3] = Order.Convert.ToDouble(rowArray4[0]["D"]);
                        class2.EfficiencyParas[4] = Order.Convert.ToDouble(rowArray4[0]["E"]);
                        class2.EfficiencyParas[5] = Order.Convert.ToDouble(rowArray4[0]["F"]);
                        class2.EfficiencyParas[6] = Order.Convert.ToDouble(rowArray4[0]["G"]);

                        class2.EfficiencyParasStaPre[0] = Order.Convert.ToDouble(rowArray5[0]["A"]);
                        class2.EfficiencyParasStaPre[1] = Order.Convert.ToDouble(rowArray5[0]["B"]);
                        class2.EfficiencyParasStaPre[2] = Order.Convert.ToDouble(rowArray5[0]["C"]);
                        class2.EfficiencyParasStaPre[3] = Order.Convert.ToDouble(rowArray5[0]["D"]);
                        class2.EfficiencyParasStaPre[4] = Order.Convert.ToDouble(rowArray5[0]["E"]);
                        class2.EfficiencyParasStaPre[5] = Order.Convert.ToDouble(rowArray5[0]["F"]);
                        class2.EfficiencyParasStaPre[6] = Order.Convert.ToDouble(rowArray5[0]["G"]);

                        if (!QueryClass.Fanlist.ContainsKey(class2.FanID))
                        {
                            QueryClass.Fanlist.Add(class2.FanID, class2);
                        }
                       
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                Alert.Show(exception.Message);
                return false;
            }
        }

        private static double getJiHao(string str)
        {
            char[] c = str.ToCharArray();
            string number = "";
            bool isBegin = false;
            foreach (char item in c)
            {
                if (item >= 48 && item <= 58)
                {
                    number += item;
                    isBegin = true;
                }
                else
                {
                    if (isBegin)
                    {
                        break;
                    }
                }
            }
            double a = System.Convert.ToDouble(number) / 10D;
            return a;
        }

    }
}