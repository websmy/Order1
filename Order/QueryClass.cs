using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Order
{
    public class QueryClass
    {
        public static bool AllJiHao;
        public static string JiHaoCompare;

        public static bool AllProNet;
        public static double ProNetCompare;

        public static bool AllDiameter = true;
        public static bool AllDianJiJiShu = true;
        public static bool AllDianYa = false;
        public static bool AllDianYuanPinlu = false;
        public static bool AllZhuanSu = true;
        public static bool AllFengXiang = true;
        //public static bool AllType;
        public static int CalcTimes = 50;
        public static double DiameterCompare = 0.0;
        public static double DianJiJiShuCompare = 2.0;
        public static double DianYaCompare = 220.0;
        public static double DianYuanPinLuCompare = 50.0;
        public static double ZhuanSuCompare = 0;
        public static double TypeCompare;
        public static Dictionary<string, ElectricMachinery> ElectricMachineryList = new Dictionary<string, ElectricMachinery>();
        public static Dictionary<string, FanClass> Fanlist = new Dictionary<string, FanClass>();
        public static string FengXiangCompare = "";
        public static double MaxAirFlowTolerance = 1.0;
        public static double MaxTolerance = 1.0;
        public static double MinAirFlowTolerance = 1.0;
        public static double MinTolerance = 1.0;
        public static Dictionary<string, FanClass> SelectedFan = new Dictionary<string, FanClass>();
        public static string SelectLx = "S";

        public static double Diameter = 0;
        public static double RPM = 0;



        public static string 轮毂高度 { get; set; }
        public static string 轴孔大径 { get; set; }
        public static string 锥度 { get; set; }
        public static string 键宽 { get; set; }
        public static string 轴伸L { get; set; }
        public static string 叶片材质 { get; set; }
        public static Boolean 是否其它材质 { get; set; }
        public static string 其它材质 { get; set; }
        public static string 前吹后吹 { get; set; }
        public static string 鼓风引风 { get; set; }
        public static string 储存温度min { get; set; }
        public static string 储存温度max { get; set; }
        public static string 防腐要求 { get; set; }
        public static string 备注项 { get; set; }
        public static Boolean 我不知道接口尺寸 { get; set; }

        

        protected static bool isNumberic(string message)
        {
            //判断是否为整数字符串 
            //是的话则将其转换为数字并将其设为out类型的输出值、返回true, 否则为false 
            //result = -1;   //result 定义为out 用来输出值 
            try
            {
                //当数字字符串的为是少于4时，以下三种都可以转换，任选一种 
                //如果位数超过4的话，请选用Convert.ToInt32() 和int.Parse() 

                //result = int.Parse(message); 
                //result = Convert.ToInt16(message); 
                System.Convert.ToDouble(message);
                return true;
            }
            catch
            {
                return false;
            }
        }


        private static bool CheckProtNet(FanClass fam)
        {
            return (AllProNet || (fam.ProtNet == (ProNetCompare - 1)));
        }

        private static bool CheckType(FanClass fam)
        {
            if (fam.FanID.Equals("XYL-6.8-1") || fam.FanID.Equals("XYL-7.0A"))
            {
                if (fam.Type == 3)
                {
                    return true;
                }
            }
            else
            {
                return (fam.Type == TypeCompare);
            }

            return true;
            //return ((fam.Type == TypeCompare));
        }

        private static bool CheckJiHao(FanClass fam)
        {
            bool result = false;

            if (AllJiHao)
            {
                result = true;
            }
            else if (isNumberic(JiHaoCompare) && isNumberic(fam.机号.Trim()))
            {
                if ((System.Convert.ToDouble(fam.机号.Trim()) == System.Convert.ToDouble(JiHaoCompare)))
                {
                    result = true;
                }
            }
            else if (!isNumberic(JiHaoCompare) && !isNumberic(fam.机号.Trim()))
            {
                if (fam.机号.Trim().Equals(JiHaoCompare))
                {
                    result = true;
                }
            }
            return result;
            //return (AllJiHao || fam.机号.Equals(JiHaoCompare) || (System.Convert.ToDouble(fam.机号) == System.Convert.ToDouble(JiHaoCompare)));
        }

        private static bool CheckDiameter(FanClass fam)
        {
            //return (AllDiameter || (fam.Diameter == DiameterCompare));
            return (Diameter * MinTolerance <= fam.Diameter && fam.Diameter <= Diameter * MaxTolerance);
        }
        private static bool CheckRPM(FanClass fam)
        {
            //return (AllDiameter || (fam.Diameter == DiameterCompare));
            return (RPM * MinTolerance <= fam.RPM && fam.RPM <= RPM * MaxTolerance);
        }
        private static bool CheckDianJiJiShu(FanClass fam)
        {
            return (AllDianJiJiShu || (fam.DianJiJiShu == DianJiJiShuCompare));
        }

        private static bool CheckDianYa(FanClass fam)
        {
            return (AllDianYa || (fam.DianYa == DianYaCompare));
        }

        private static bool CheckDianYuanPinLu(FanClass fam)
        {
            return (AllDianYuanPinlu || (fam.DianYuanPinLu == DianYuanPinLuCompare));
        }
        private static bool CheckZhuanSu(FanClass fam)
        {
            return (AllZhuanSu || (fam.RPM == ZhuanSuCompare));
        }

        private static bool CheckFengXiang(FanClass fam)
        {
            return (AllFengXiang || (fam.FengXiang == FengXiangCompare));
        }

        internal static double Cifre_Significative(double soundVar)
        {
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            string str = "";
            int num4 = 0;
            int num5 = 0;
            num = soundVar;
            num5 = 0;
            num4 = 0;
            if (num < 0.0)
            {
                num *= -1.0;
                num4 = 1;
            }
            if (num > 1.0)
            {
                while (num > 0.1)
                {
                    num /= 10.0;
                    num5++;
                }
                num *= 10.0;
                num5--;
                str = num.ToString();
                if (str.Length > 5)
                {
                    num2 = Order.Convert.ToDouble(str.Substring(2, 1)) * Math.Pow(10.0, (double)(num5 - 1));
                    num3 = Order.Convert.ToDouble(str.Substring(3, 1)) * Math.Pow(10.0, (double)(num5 - 2));
                    num2 += num3;
                    num3 = Order.Convert.ToDouble(str.Substring(4, 1)) * Math.Pow(10.0, (double)(num5 - 3));
                    num2 += num3;
                    if (Order.Convert.ToDouble(str.Substring(5, 1)) >= 5.0)
                    {
                        num3 = Math.Pow(10.0, (double)(num5 - 3));
                        num2 += num3;
                    }
                }
                else
                {
                    num2 = soundVar;
                }
            }
            num = soundVar;
            if (num < 0.0)
            {
                num *= -1.0;
                num4 = 1;
            }
            if ((num > 0.0) & (num < 1.0))
            {
                while (num < 1.0)
                {
                    num *= 10.0;
                    num5++;
                }
                str = num.ToString();
                if (str.Length > 4)
                {
                    num2 = Order.Convert.ToDouble(str.Substring(0, 1)) / Math.Pow(10.0, (double)num5);
                    num3 = Order.Convert.ToDouble(str.Substring(2, 1)) / Math.Pow(10.0, (double)(num5 + 1));
                    num2 += num3;
                    num3 = Order.Convert.ToDouble(str.Substring(3, 1)) / Math.Pow(10.0, (double)(num5 + 2));
                    num2 += num3;
                    if (Order.Convert.ToDouble(str.Substring(4, 1)) >= 5.0)
                    {
                        num3 = 1.0 / Math.Pow(10.0, (double)(num5 + 2));
                        num2 += num3;
                    }
                }
                else
                {
                    num2 = soundVar;
                }
            }
            if (num4 == 1)
            {
                num2 *= -1.0;
            }
            return num2;
        }

        //public static void SelectData()
        //{
        //    SelectData(0.0, 0.0);
        //}

        //public static void SelectData(double air, double staticpres)
        //{
        //    try
        //    {
        //        SelectData(air, staticpres, "S");
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //    }
        //}

        //public static void SelectData(double air, double staticpres, string presLx)
        //{
        //    try
        //    {
        //        SelectData(air, staticpres, presLx, 20);
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //    }
        //}

        public static void SelectData(double air, double staticpres, string presLx, double AirDens, int repairIndex)
        {
            try
            {
                double temp = staticpres;
                SelectedFan.Clear();
                double minStaPre = 0.0;
                double maxStaPre = 0.0;
                double num3 = 0.0;
                double minAir_Q = air * MinAirFlowTolerance;
                double maxAir_Q = air * MaxAirFlowTolerance;
                double num6 = (maxAir_Q - minAir_Q) / ((double)CalcTimes);
                if (num6 == 0.0)
                {
                    num6 = 1.0;
                }
                foreach (FanClass fanClass in Fanlist.Values)
                {
                    if (fanClass.FanID.Equals("CBZ-180B-1"))
                    {

                    }

                    if (!我不知道接口尺寸)
                    {
                        if (!轴孔大径.Equals(fanClass.轴孔大径))
                        {
                            continue;
                        }
                        if (!锥度.Equals(fanClass.锥度))
                        {
                            continue;
                        }
                        if (!键宽.Equals(fanClass.键宽))
                        {
                            continue;
                        }

                        if (!((Convert.ToInt32(轴伸L) + 2) <= (Convert.ToInt32(fanClass.轮毂高度)) &&
                            (Convert.ToInt32(fanClass.轮毂高度)) <= (Convert.ToInt32(轴伸L) + 6)))
                        {
                            continue;
                        }
                    }


                    //if (!前吹后吹.Equals(fanClass.前吹后吹))
                    //{
                    //    continue;
                    //}
                    //if (!鼓风引风.Equals(fanClass.鼓风引风))
                    //{
                    //    continue;
                    //}


                    if (!CheckDiameter(fanClass))
                    {
                        continue;
                    }

                    if (!CheckRPM(fanClass))
                    {
                        continue;
                    }
                    //if (!CheckDianYa(fanClass))
                    //{
                    //    continue;
                    //}
                    //if (!CheckZhuanSu(fanClass))
                    //{
                    //    continue;
                    //}
                    //if (!CheckType(fanClass))
                    //{
                    //    continue;
                    //}
                    //if (!CheckJiHao(fanClass))
                    //{
                    //    continue;
                    //}

                    //if (!CheckProtNet(fanClass))
                    //{
                    //    continue;
                    //}


                    //staticpres *= (273.0 + AirDens) / (273.0 + Order.Convert.ToDouble(fanClass.Temperature));
                    staticpres *= (1.2) / AirDens;
                    //staticpres = staticpres);
                    minStaPre = staticpres * MinTolerance;
                    maxStaPre = staticpres * MaxTolerance;

                    double repairQ = 1;
                    if (repairIndex == 1)
                    {
                        repairQ = fanClass.m;
                    }
                    else if (repairIndex == 2)
                    {
                        repairQ = fanClass.m1;
                    }
                    else if (repairIndex == 3)
                    {
                        repairQ = fanClass.m2;
                    }

                    fanClass.repairIndex = repairIndex;
                    fanClass.repairQ = repairQ;

                    if ((Math.Round(minAir_Q, 2) <= Math.Ceiling(fanClass.MaxFlow * repairQ)) && (Math.Round(maxAir_Q, 2) >= Math.Floor(fanClass.MinFlow * repairQ)))
                    {
                        for (double i = minAir_Q; i <= maxAir_Q; i += num6)
                        {
                            string str = presLx;
                            if (str == null)
                            {
                                goto Label_0141;
                            }
                            if (!(str == "S"))
                            {
                                if (str == "T")
                                {
                                    goto Label_0135;
                                }
                                goto Label_0141;
                            }
                            num3 = fanClass.StaticPressureY(i);
                            if (repairIndex == 1)
                            {
                                num3 = fanClass.StaticPressureJiaBanY(i);
                            }
                            if (repairIndex == 2)
                            {
                                num3 = fanClass.StaticPressureB3DianJiY(i);
                            }

                            if (repairIndex == 3)
                            {
                                num3 = fanClass.StaticPressureTwoKindY(i);
                            }


                            goto Label_0146;
                        Label_0135:

                            num3 = fanClass.TotalPressureY(i);
                            if (repairIndex == 1)
                            {
                                num3 = fanClass.TotalPressureJiaBanY(i);
                            }
                            if (repairIndex == 2)
                            {
                                num3 = fanClass.TotalPressureB3DianJiY(i);
                            }
                            if (repairIndex == 3)
                            {
                                num3 = fanClass.TotalPressureTwoKindY(i);
                            }

                            goto Label_0146;
                        Label_0141:
                            AirDens = 0;
                        Label_0146:
                            if ((num3 >= minStaPre) && (num3 <= maxStaPre))
                            {
                                SelectedFan.Add(fanClass.FanID, fanClass);
                                break;
                            }
                        }
                    }

                    staticpres = temp;
                }
            }
            catch (Exception exception)
            {
                Alert.Show(exception.Message);
            }
        }
    }
}