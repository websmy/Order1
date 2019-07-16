using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Order
{
    public class FanClass
    {

        public string F1 = "";
        public string F2 = "";
        public string F3 = "";
        public string F4 = "";
        public string F5 = "";
        public string F6 = "";
        public string F7 = "";
        public string F8 = "";
        public string F9 = "";
        public string F10 = "";
        public string F11 = "";
        public string F12 = "";
        public string F13 = "";
        public string F14 = "";
        public string F15 = "";
        public string F16 = "";
        public string F17 = "";
        public string F18 = "";
        public string F19 = "";
        public string F20 = "";
        public string F21 = "";
        public string F22 = "";
        public string F23 = "";
        public string F24 = "";
        public string F25 = "";
        public string F26 = "";
        public string F27 = "";
        public string F28 = "";
        public string F29 = "";
        public string F30 = "";
        public string F31 = "";
        public string F32 = "";
        public string F33 = "";
        public string F34 = "";
        public string F35 = "";
        public string F36 = "";
        public string F37 = "";
        public string F38 = "";
        public string F39 = "";
        public string F40 = "";

        public string 轮毂高度 { get; set; }
        public string 轴孔大径 { get; set; }
        public string 锥度 { get; set; }
        public string 键宽 { get; set; }
        public string 轴伸L { get; set; }
        public string 叶片材质 { get; set; }
        public string 前吹后吹 { get; set; }
        public string 鼓风引风 { get; set; }
        public string 储存温度min { get; set; }
        public string 储存温度max { get; set; }
        public string 防腐要求 { get; set; }



        private string _description = "";
        private double _diameter = 0.0;
        private string _dianJiXingHao = "";
        public string DianJiGongLv = "";
        private int _dianYa = 220;
        private int _dianYuanPinLu = 50;
        private int _type = 0;
        private int _protNet = 0;

        private string _a = "";
        private string _b = "";
        private string _c = "";
        private string _d = "";
        private string _e = "";
        private string _f = "";
        private string _l = "";
        private string _l1 = "";

        public string L2;
        public string L3;
        public string L4;
        public string L5;
        public string L6;
        public string L7;
        public string L8;
        public string L9;

        public string H1;
        public string H2;
        public string H3;
        public string n_d2;

        private string _n_d = "";
        private string _airflow = "";
        private string _motordata = "";
        private string _weight = "";
        private string _标志位 = "";
        private string _叶轮材料 = "";
        private string _图纸名称 = "";

        private string _风筒 = "";
        private string _防护网安装位置 = "";
        private string _出线方式 = "";
        private string _紧固件 = "";
        private string _防护网材料 = "";

        public string 机号 = "";

        public double m;
        public double n;
        public double m1;
        public double n1;
        public double m2;
        public double n2;

        public double repairIndex = 0;//0是没有修正，1是甲板式，2是B3电机，3是两个相乘的
        public double repairQ = 1;

        private int _dianYuanXiangShu = 2;
        private string _FanCatagory = "";
        private string _fanCode = "";
        private string _fanid = "";
        private string _fengXiang = "";
        private int _jiShu = 0;
        private double _jueDu = 0.0;
        private double _maxFlow = 5000.0;
        private double _minFlow = 0.0;
        private int _rPm = 0;
        private string _Temperature = "20";
        private string _yeXing = "";
        public int CurveJC = 3;
        public double[] EfficiencyParas = new double[7];
        public double[] EfficiencyParasStaPre = new double[7];
        public static int FileCount = 7;
        private string[] fileList = new string[FileCount];
        public double[] PowerParas = new double[7];
        public double[] StaticParas = new double[7];
        public double[] JiaBanStaticParas = new double[7];
        public double[] B3DianJiStaticParas = new double[7];
        public double[] TotalParas = new double[7];
        public double[] JiaBanTotalParas = new double[7];
        public double[] B3DianJiTotalParas = new double[7];

        public double[] TwoKindTotalParas = new double[7];
        public double[] TwoKindStaticParas = new double[7];

        internal double EfficiencyPressureY(double xStart)
        {
            switch (this.CurveJC)
            {
                case 2:
                    return (((this.EfficiencyParas[0] * Math.Pow(xStart, 2.0)) + (this.EfficiencyParas[1] * Math.Pow(xStart, 1.0))) + this.EfficiencyParas[6]);

                case 3:
                    return ((((this.EfficiencyParas[0] * Math.Pow(xStart, 3.0)) + (this.EfficiencyParas[1] * Math.Pow(xStart, 2.0))) + (this.EfficiencyParas[2] * Math.Pow(xStart, 1.0))) + this.EfficiencyParas[6]);

                case 4:
                    return (((((this.EfficiencyParas[0] * Math.Pow(xStart, 4.0)) + (this.EfficiencyParas[1] * Math.Pow(xStart, 3.0))) + (this.EfficiencyParas[2] * Math.Pow(xStart, 2.0))) + (this.EfficiencyParas[3] * Math.Pow(xStart, 1.0))) + this.EfficiencyParas[6]);

                case 5:
                    return ((((((this.EfficiencyParas[0] * Math.Pow(xStart, 5.0)) + (this.EfficiencyParas[1] * Math.Pow(xStart, 4.0))) + (this.EfficiencyParas[2] * Math.Pow(xStart, 3.0))) + (this.EfficiencyParas[3] * Math.Pow(xStart, 2.0))) + (this.EfficiencyParas[4] * Math.Pow(xStart, 1.0))) + this.EfficiencyParas[6]);

                case 6:
                    return (((((((this.EfficiencyParas[0] * Math.Pow(xStart, 6.0)) + (this.EfficiencyParas[1] * Math.Pow(xStart, 5.0))) + (this.EfficiencyParas[2] * Math.Pow(xStart, 4.0))) + (this.EfficiencyParas[3] * Math.Pow(xStart, 3.0))) + (this.EfficiencyParas[4] * Math.Pow(xStart, 2.0))) + (this.EfficiencyParas[5] * Math.Pow(xStart, 1.0))) + this.EfficiencyParas[6]);
            }
            return 0.0;
        }

        internal double EfficiencyPressureYStaPre(double xStart)
        {
            switch (this.CurveJC)
            {
                case 2:
                    return (((this.EfficiencyParasStaPre[0] * Math.Pow(xStart, 2.0)) + (this.EfficiencyParasStaPre[1] * Math.Pow(xStart, 1.0))) + this.EfficiencyParasStaPre[6]);

                case 3:
                    return ((((this.EfficiencyParasStaPre[0] * Math.Pow(xStart, 3.0)) + (this.EfficiencyParasStaPre[1] * Math.Pow(xStart, 2.0))) + (this.EfficiencyParasStaPre[2] * Math.Pow(xStart, 1.0))) + this.EfficiencyParasStaPre[6]);

                case 4:
                    return (((((this.EfficiencyParasStaPre[0] * Math.Pow(xStart, 4.0)) + (this.EfficiencyParasStaPre[1] * Math.Pow(xStart, 3.0))) + (this.EfficiencyParasStaPre[2] * Math.Pow(xStart, 2.0))) + (this.EfficiencyParasStaPre[3] * Math.Pow(xStart, 1.0))) + this.EfficiencyParasStaPre[6]);

                case 5:
                    return ((((((this.EfficiencyParasStaPre[0] * Math.Pow(xStart, 5.0)) + (this.EfficiencyParasStaPre[1] * Math.Pow(xStart, 4.0))) + (this.EfficiencyParasStaPre[2] * Math.Pow(xStart, 3.0))) + (this.EfficiencyParasStaPre[3] * Math.Pow(xStart, 2.0))) + (this.EfficiencyParasStaPre[4] * Math.Pow(xStart, 1.0))) + this.EfficiencyParasStaPre[6]);

                case 6:
                    return (((((((this.EfficiencyParasStaPre[0] * Math.Pow(xStart, 6.0)) + (this.EfficiencyParasStaPre[1] * Math.Pow(xStart, 5.0))) + (this.EfficiencyParasStaPre[2] * Math.Pow(xStart, 4.0))) + (this.EfficiencyParasStaPre[3] * Math.Pow(xStart, 3.0))) + (this.EfficiencyParasStaPre[4] * Math.Pow(xStart, 2.0))) + (this.EfficiencyParasStaPre[5] * Math.Pow(xStart, 1.0))) + this.EfficiencyParasStaPre[6]);
            }
            return 0.0;
        }

        internal double GetStep()
        {
            return ((this.MaxFlow - this.MinFlow) / ((double)QueryClass.CalcTimes));
        }

        internal double PowerY(double xStart)
        {
            switch (this.CurveJC)
            {
                case 2:
                    return (((this.PowerParas[0] * Math.Pow(xStart, 2.0)) + (this.PowerParas[1] * Math.Pow(xStart, 1.0))) + this.PowerParas[6]);

                case 3:
                    return ((((this.PowerParas[0] * Math.Pow(xStart, 3.0)) + (this.PowerParas[1] * Math.Pow(xStart, 2.0))) + (this.PowerParas[2] * Math.Pow(xStart, 1.0))) + this.PowerParas[6]);

                case 4:
                    return (((((this.PowerParas[0] * Math.Pow(xStart, 4.0)) + (this.PowerParas[1] * Math.Pow(xStart, 3.0))) + (this.PowerParas[2] * Math.Pow(xStart, 2.0))) + (this.PowerParas[3] * Math.Pow(xStart, 1.0))) + this.PowerParas[6]);

                case 5:
                    return ((((((this.PowerParas[0] * Math.Pow(xStart, 5.0)) + (this.PowerParas[1] * Math.Pow(xStart, 4.0))) + (this.PowerParas[2] * Math.Pow(xStart, 3.0))) + (this.PowerParas[3] * Math.Pow(xStart, 2.0))) + (this.PowerParas[4] * Math.Pow(xStart, 1.0))) + this.PowerParas[6]);

                case 6:
                    return (((((((this.PowerParas[0] * Math.Pow(xStart, 6.0)) + (this.PowerParas[1] * Math.Pow(xStart, 5.0))) + (this.PowerParas[2] * Math.Pow(xStart, 4.0))) + (this.PowerParas[3] * Math.Pow(xStart, 3.0))) + (this.PowerParas[4] * Math.Pow(xStart, 2.0))) + (this.PowerParas[5] * Math.Pow(xStart, 1.0))) + this.PowerParas[6]);
            }
            return 0.0;
        }

        internal double StaticPressureY(double xStart)
        {
            switch (this.CurveJC)
            {
                case 2:
                    return (((this.StaticParas[0] * Math.Pow(xStart, 2.0)) + (this.StaticParas[1] * Math.Pow(xStart, 1.0))) + this.StaticParas[6]);

                case 3:
                    return ((((this.StaticParas[0] * Math.Pow(xStart, 3.0)) + (this.StaticParas[1] * Math.Pow(xStart, 2.0))) + (this.StaticParas[2] * Math.Pow(xStart, 1.0))) + this.StaticParas[6]);

                case 4:
                    return (((((this.StaticParas[0] * Math.Pow(xStart, 4.0)) + (this.StaticParas[1] * Math.Pow(xStart, 3.0))) + (this.StaticParas[2] * Math.Pow(xStart, 2.0))) + (this.StaticParas[3] * Math.Pow(xStart, 1.0))) + this.StaticParas[6]);

                case 5:
                    return ((((((this.StaticParas[0] * Math.Pow(xStart, 5.0)) + (this.StaticParas[1] * Math.Pow(xStart, 4.0))) + (this.StaticParas[2] * Math.Pow(xStart, 3.0))) + (this.StaticParas[3] * Math.Pow(xStart, 2.0))) + (this.StaticParas[4] * Math.Pow(xStart, 1.0))) + this.StaticParas[6]);

                case 6:
                    return (((((((this.StaticParas[0] * Math.Pow(xStart, 6.0)) + (this.StaticParas[1] * Math.Pow(xStart, 5.0))) + (this.StaticParas[2] * Math.Pow(xStart, 4.0))) + (this.StaticParas[3] * Math.Pow(xStart, 3.0))) + (this.StaticParas[4] * Math.Pow(xStart, 2.0))) + (this.StaticParas[5] * Math.Pow(xStart, 1.0))) + this.StaticParas[6]);
            }
            return 0.0;
        }

        internal double StaticPressureTwoKindY(double xStart)
        {
            switch (this.CurveJC)
            {
                case 2:
                    return (((this.TwoKindStaticParas[0] * Math.Pow(xStart, 2.0)) + (this.TwoKindStaticParas[1] * Math.Pow(xStart, 1.0))) + this.TwoKindStaticParas[6]);

                case 3:
                    return ((((this.TwoKindStaticParas[0] * Math.Pow(xStart, 3.0)) + (this.TwoKindStaticParas[1] * Math.Pow(xStart, 2.0))) + (this.TwoKindStaticParas[2] * Math.Pow(xStart, 1.0))) + this.TwoKindStaticParas[6]);

                case 4:
                    return (((((this.TwoKindStaticParas[0] * Math.Pow(xStart, 4.0)) + (this.TwoKindStaticParas[1] * Math.Pow(xStart, 3.0))) + (this.TwoKindStaticParas[2] * Math.Pow(xStart, 2.0))) + (this.TwoKindStaticParas[3] * Math.Pow(xStart, 1.0))) + this.TwoKindStaticParas[6]);

                case 5:
                    return ((((((this.TwoKindStaticParas[0] * Math.Pow(xStart, 5.0)) + (this.TwoKindStaticParas[1] * Math.Pow(xStart, 4.0))) + (this.TwoKindStaticParas[2] * Math.Pow(xStart, 3.0))) + (this.TwoKindStaticParas[3] * Math.Pow(xStart, 2.0))) + (this.TwoKindStaticParas[4] * Math.Pow(xStart, 1.0))) + this.TwoKindStaticParas[6]);

                case 6:
                    return (((((((this.TwoKindStaticParas[0] * Math.Pow(xStart, 6.0)) + (this.TwoKindStaticParas[1] * Math.Pow(xStart, 5.0))) + (this.TwoKindStaticParas[2] * Math.Pow(xStart, 4.0))) + (this.TwoKindStaticParas[3] * Math.Pow(xStart, 3.0))) + (this.TwoKindStaticParas[4] * Math.Pow(xStart, 2.0))) + (this.TwoKindStaticParas[5] * Math.Pow(xStart, 1.0))) + this.TwoKindStaticParas[6]);
            }
            return 0.0;
        }
        internal double StaticPressureJiaBanY(double xStart)
        {
            switch (this.CurveJC)
            {
                case 2:
                    return (((this.JiaBanStaticParas[0] * Math.Pow(xStart, 2.0)) + (this.JiaBanStaticParas[1] * Math.Pow(xStart, 1.0))) + this.JiaBanStaticParas[6]);

                case 3:
                    return ((((this.JiaBanStaticParas[0] * Math.Pow(xStart, 3.0)) + (this.JiaBanStaticParas[1] * Math.Pow(xStart, 2.0))) + (this.JiaBanStaticParas[2] * Math.Pow(xStart, 1.0))) + this.JiaBanStaticParas[6]);

                case 4:
                    return (((((this.JiaBanStaticParas[0] * Math.Pow(xStart, 4.0)) + (this.JiaBanStaticParas[1] * Math.Pow(xStart, 3.0))) + (this.JiaBanStaticParas[2] * Math.Pow(xStart, 2.0))) + (this.JiaBanStaticParas[3] * Math.Pow(xStart, 1.0))) + this.JiaBanStaticParas[6]);

                case 5:
                    return ((((((this.JiaBanStaticParas[0] * Math.Pow(xStart, 5.0)) + (this.JiaBanStaticParas[1] * Math.Pow(xStart, 4.0))) + (this.JiaBanStaticParas[2] * Math.Pow(xStart, 3.0))) + (this.JiaBanStaticParas[3] * Math.Pow(xStart, 2.0))) + (this.JiaBanStaticParas[4] * Math.Pow(xStart, 1.0))) + this.JiaBanStaticParas[6]);

                case 6:
                    return (((((((this.JiaBanStaticParas[0] * Math.Pow(xStart, 6.0)) + (this.JiaBanStaticParas[1] * Math.Pow(xStart, 5.0))) + (this.JiaBanStaticParas[2] * Math.Pow(xStart, 4.0))) + (this.JiaBanStaticParas[3] * Math.Pow(xStart, 3.0))) + (this.JiaBanStaticParas[4] * Math.Pow(xStart, 2.0))) + (this.JiaBanStaticParas[5] * Math.Pow(xStart, 1.0))) + this.JiaBanStaticParas[6]);
            }
            return 0.0;
        }
        internal double StaticPressureB3DianJiY(double xStart)
        {
            switch (this.CurveJC)
            {
                case 2:
                    return (((this.B3DianJiStaticParas[0] * Math.Pow(xStart, 2.0)) + (this.B3DianJiStaticParas[1] * Math.Pow(xStart, 1.0))) + this.B3DianJiStaticParas[6]);

                case 3:
                    return ((((this.B3DianJiStaticParas[0] * Math.Pow(xStart, 3.0)) + (this.B3DianJiStaticParas[1] * Math.Pow(xStart, 2.0))) + (this.B3DianJiStaticParas[2] * Math.Pow(xStart, 1.0))) + this.B3DianJiStaticParas[6]);

                case 4:
                    return (((((this.B3DianJiStaticParas[0] * Math.Pow(xStart, 4.0)) + (this.B3DianJiStaticParas[1] * Math.Pow(xStart, 3.0))) + (this.B3DianJiStaticParas[2] * Math.Pow(xStart, 2.0))) + (this.B3DianJiStaticParas[3] * Math.Pow(xStart, 1.0))) + this.B3DianJiStaticParas[6]);

                case 5:
                    return ((((((this.B3DianJiStaticParas[0] * Math.Pow(xStart, 5.0)) + (this.B3DianJiStaticParas[1] * Math.Pow(xStart, 4.0))) + (this.B3DianJiStaticParas[2] * Math.Pow(xStart, 3.0))) + (this.B3DianJiStaticParas[3] * Math.Pow(xStart, 2.0))) + (this.B3DianJiStaticParas[4] * Math.Pow(xStart, 1.0))) + this.B3DianJiStaticParas[6]);

                case 6:
                    return (((((((this.B3DianJiStaticParas[0] * Math.Pow(xStart, 6.0)) + (this.B3DianJiStaticParas[1] * Math.Pow(xStart, 5.0))) + (this.B3DianJiStaticParas[2] * Math.Pow(xStart, 4.0))) + (this.B3DianJiStaticParas[3] * Math.Pow(xStart, 3.0))) + (this.B3DianJiStaticParas[4] * Math.Pow(xStart, 2.0))) + (this.B3DianJiStaticParas[5] * Math.Pow(xStart, 1.0))) + this.B3DianJiStaticParas[6]);
            }
            return 0.0;
        }
        internal double TotalPressureY(double xStart)
        {
            switch (this.CurveJC)
            {
                case 2:
                    return (((this.TotalParas[0] * Math.Pow(xStart, 2.0)) + (this.TotalParas[1] * Math.Pow(xStart, 1.0))) + this.TotalParas[6]);

                case 3:
                    return ((((this.TotalParas[0] * Math.Pow(xStart, 3.0)) + (this.TotalParas[1] * Math.Pow(xStart, 2.0))) + (this.TotalParas[2] * Math.Pow(xStart, 1.0))) + this.TotalParas[6]);

                case 4:
                    return (((((this.TotalParas[0] * Math.Pow(xStart, 4.0)) + (this.TotalParas[1] * Math.Pow(xStart, 3.0))) + (this.TotalParas[2] * Math.Pow(xStart, 2.0))) + (this.TotalParas[3] * Math.Pow(xStart, 1.0))) + this.TotalParas[6]);

                case 5:
                    return ((((((this.TotalParas[0] * Math.Pow(xStart, 5.0)) + (this.TotalParas[1] * Math.Pow(xStart, 4.0))) + (this.TotalParas[2] * Math.Pow(xStart, 3.0))) + (this.TotalParas[3] * Math.Pow(xStart, 2.0))) + (this.TotalParas[4] * Math.Pow(xStart, 1.0))) + this.TotalParas[6]);

                case 6:
                    return (((((((this.TotalParas[0] * Math.Pow(xStart, 6.0)) + (this.TotalParas[1] * Math.Pow(xStart, 5.0))) + (this.TotalParas[2] * Math.Pow(xStart, 4.0))) + (this.TotalParas[3] * Math.Pow(xStart, 3.0))) + (this.TotalParas[4] * Math.Pow(xStart, 2.0))) + (this.TotalParas[5] * Math.Pow(xStart, 1.0))) + this.TotalParas[6]);
            }
            return 0.0;
        }

        internal double TotalPressureB3DianJiY(double xStart)
        {
            switch (this.CurveJC)
            {
                case 2:
                    return (((this.B3DianJiTotalParas[0] * Math.Pow(xStart, 2.0)) + (this.B3DianJiTotalParas[1] * Math.Pow(xStart, 1.0))) + this.B3DianJiTotalParas[6]);

                case 3:
                    return ((((this.B3DianJiTotalParas[0] * Math.Pow(xStart, 3.0)) + (this.B3DianJiTotalParas[1] * Math.Pow(xStart, 2.0))) + (this.B3DianJiTotalParas[2] * Math.Pow(xStart, 1.0))) + this.B3DianJiTotalParas[6]);

                case 4:
                    return (((((this.B3DianJiTotalParas[0] * Math.Pow(xStart, 4.0)) + (this.B3DianJiTotalParas[1] * Math.Pow(xStart, 3.0))) + (this.B3DianJiTotalParas[2] * Math.Pow(xStart, 2.0))) + (this.B3DianJiTotalParas[3] * Math.Pow(xStart, 1.0))) + this.B3DianJiTotalParas[6]);

                case 5:
                    return ((((((this.B3DianJiTotalParas[0] * Math.Pow(xStart, 5.0)) + (this.B3DianJiTotalParas[1] * Math.Pow(xStart, 4.0))) + (this.B3DianJiTotalParas[2] * Math.Pow(xStart, 3.0))) + (this.B3DianJiTotalParas[3] * Math.Pow(xStart, 2.0))) + (this.B3DianJiTotalParas[4] * Math.Pow(xStart, 1.0))) + this.B3DianJiTotalParas[6]);

                case 6:
                    return (((((((this.B3DianJiTotalParas[0] * Math.Pow(xStart, 6.0)) + (this.B3DianJiTotalParas[1] * Math.Pow(xStart, 5.0))) + (this.B3DianJiTotalParas[2] * Math.Pow(xStart, 4.0))) + (this.B3DianJiTotalParas[3] * Math.Pow(xStart, 3.0))) + (this.B3DianJiTotalParas[4] * Math.Pow(xStart, 2.0))) + (this.B3DianJiTotalParas[5] * Math.Pow(xStart, 1.0))) + this.B3DianJiTotalParas[6]);
            }
            return 0.0;
        }
        internal double TotalPressureJiaBanY(double xStart)
        {
            switch (this.CurveJC)
            {
                case 2:
                    return (((this.JiaBanTotalParas[0] * Math.Pow(xStart, 2.0)) + (this.JiaBanTotalParas[1] * Math.Pow(xStart, 1.0))) + this.JiaBanTotalParas[6]);

                case 3:
                    return ((((this.JiaBanTotalParas[0] * Math.Pow(xStart, 3.0)) + (this.JiaBanTotalParas[1] * Math.Pow(xStart, 2.0))) + (this.JiaBanTotalParas[2] * Math.Pow(xStart, 1.0))) + this.JiaBanTotalParas[6]);

                case 4:
                    return (((((this.JiaBanTotalParas[0] * Math.Pow(xStart, 4.0)) + (this.JiaBanTotalParas[1] * Math.Pow(xStart, 3.0))) + (this.JiaBanTotalParas[2] * Math.Pow(xStart, 2.0))) + (this.JiaBanTotalParas[3] * Math.Pow(xStart, 1.0))) + this.JiaBanTotalParas[6]);

                case 5:
                    return ((((((this.JiaBanTotalParas[0] * Math.Pow(xStart, 5.0)) + (this.JiaBanTotalParas[1] * Math.Pow(xStart, 4.0))) + (this.JiaBanTotalParas[2] * Math.Pow(xStart, 3.0))) + (this.JiaBanTotalParas[3] * Math.Pow(xStart, 2.0))) + (this.JiaBanTotalParas[4] * Math.Pow(xStart, 1.0))) + this.JiaBanTotalParas[6]);

                case 6:
                    return (((((((this.JiaBanTotalParas[0] * Math.Pow(xStart, 6.0)) + (this.JiaBanTotalParas[1] * Math.Pow(xStart, 5.0))) + (this.JiaBanTotalParas[2] * Math.Pow(xStart, 4.0))) + (this.JiaBanTotalParas[3] * Math.Pow(xStart, 3.0))) + (this.JiaBanTotalParas[4] * Math.Pow(xStart, 2.0))) + (this.JiaBanTotalParas[5] * Math.Pow(xStart, 1.0))) + this.JiaBanTotalParas[6]);
            }
            return 0.0;
        }

        internal double TotalPressureTwoKindY(double xStart)
        {
            switch (this.CurveJC)
            {
                case 2:
                    return (((this.TwoKindTotalParas[0] * Math.Pow(xStart, 2.0)) + (this.TwoKindTotalParas[1] * Math.Pow(xStart, 1.0))) + this.TwoKindTotalParas[6]);

                case 3:
                    return ((((this.TwoKindTotalParas[0] * Math.Pow(xStart, 3.0)) + (this.TwoKindTotalParas[1] * Math.Pow(xStart, 2.0))) + (this.TwoKindTotalParas[2] * Math.Pow(xStart, 1.0))) + this.TwoKindTotalParas[6]);

                case 4:
                    return (((((this.TwoKindTotalParas[0] * Math.Pow(xStart, 4.0)) + (this.TwoKindTotalParas[1] * Math.Pow(xStart, 3.0))) + (this.TwoKindTotalParas[2] * Math.Pow(xStart, 2.0))) + (this.TwoKindTotalParas[3] * Math.Pow(xStart, 1.0))) + this.TwoKindTotalParas[6]);

                case 5:
                    return ((((((this.TwoKindTotalParas[0] * Math.Pow(xStart, 5.0)) + (this.TwoKindTotalParas[1] * Math.Pow(xStart, 4.0))) + (this.TwoKindTotalParas[2] * Math.Pow(xStart, 3.0))) + (this.TwoKindTotalParas[3] * Math.Pow(xStart, 2.0))) + (this.TwoKindTotalParas[4] * Math.Pow(xStart, 1.0))) + this.TwoKindTotalParas[6]);

                case 6:
                    return (((((((this.TwoKindTotalParas[0] * Math.Pow(xStart, 6.0)) + (this.TwoKindTotalParas[1] * Math.Pow(xStart, 5.0))) + (this.TwoKindTotalParas[2] * Math.Pow(xStart, 4.0))) + (this.TwoKindTotalParas[3] * Math.Pow(xStart, 3.0))) + (this.TwoKindTotalParas[4] * Math.Pow(xStart, 2.0))) + (this.TwoKindTotalParas[5] * Math.Pow(xStart, 1.0))) + this.TwoKindTotalParas[6]);
            }
            return 0.0;
        }

        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public double Diameter
        {
            get
            {
                return this._diameter;
            }
            set
            {
                this._diameter = value;
            }
        }

        public int DianJiJiShu
        {
            get
            {
                return this._jiShu;
            }
            set
            {
                this._jiShu = value;
            }
        }

        public int Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        public int ProtNet
        {
            get
            {
                return this._protNet;
            }
            set
            {
                this._protNet = value;
            }
        }


        public string DianJiXingHao
        {
            get
            {
                return this._dianJiXingHao;
            }
            set
            {
                this._dianJiXingHao = value;
            }
        }

        public int DianYa
        {
            get
            {
                return this._dianYa;
            }
            set
            {
                this._dianYa = value;
            }
        }

        public string DianYuan
        {
            get
            {
                return (this.DianJiJiShu.ToString() + "ph," + this.DianYa.ToString() + "V," + this.DianYuanPinLu.ToString() + "Hz");
            }
        }

        public int DianYuanPinLu
        {
            get
            {
                return this._dianYuanPinLu;
            }
            set
            {
                this._dianYuanPinLu = value;
            }
        }

        public int DianYuanXiangShu
        {
            get
            {
                return this._dianYuanXiangShu;
            }
            set
            {
                this._dianYuanXiangShu = value;
            }
        }

        public string FanCatagory
        {
            get
            {
                return this._FanCatagory;
            }
            set
            {
                this._FanCatagory = value;
            }
        }

        public string FanCode
        {
            get
            {
                return this._fanCode;
            }
            set
            {
                this._fanCode = value;
            }
        }

        public string FanID
        {
            get
            {
                return this._fanid;
            }
            set
            {
                this._fanid = value;
            }
        }

        public string FengXiang
        {
            get
            {
                return this._fengXiang;
            }
            set
            {
                this._fengXiang = value;
            }
        }

        public string[] FileList
        {
            get
            {
                return this.fileList;
            }
            set
            {
                this.fileList = value;
            }
        }

        public double JueDu
        {
            get
            {
                return this._jueDu;
            }
            set
            {
                this._jueDu = value;
            }
        }

        public double MaxFlow
        {
            get
            {
                return this._maxFlow;
            }
            set
            {
                this._maxFlow = value;
            }
        }

        public double MinFlow
        {
            get
            {
                return this._minFlow;
            }
            set
            {
                this._minFlow = value;
            }
        }

        public int RPM
        {
            get
            {
                return this._rPm;
            }
            set
            {
                this._rPm = value;
            }
        }

        public string Temperature
        {
            get
            {
                return this._Temperature;
            }
            set
            {
                this._Temperature = value;
            }
        }

        public string YeXing
        {
            get
            {
                return this._yeXing;
            }
            set
            {
                this._yeXing = value;
            }
        }

        public string A
        {
            get
            {
                return this._a;
            }
            set
            {
                this._a = value;
            }
        }
        public string B
        {
            get
            {
                return this._b;
            }
            set
            {
                this._b = value;
            }
        }
        public string C
        {
            get
            {
                return this._c;
            }
            set
            {
                this._c = value;
            }
        }
        public string D
        {
            get
            {
                return this._d;
            }
            set
            {
                this._d = value;
            }
        }
        public string E
        {
            get
            {
                return this._e;
            }
            set
            {
                this._e = value;
            }
        }
        public string F
        {
            get
            {
                return this._f;
            }
            set
            {
                this._f = value;
            }
        }
        public string Motordata
        {
            get
            {
                return this._motordata;
            }
            set
            {
                this._motordata = value;
            }
        }
        public string Weight
        {
            get
            {
                return this._weight;
            }
            set
            {
                this._weight = value;
            }
        }
        public string L
        {
            get
            {
                return this._l;
            }
            set
            {
                this._l = value;
            }
        }
        public string L1
        {
            get
            {
                return this._l1;
            }
            set
            {
                this._l1 = value;
            }
        }
        public string n_d
        {
            get
            {
                return this._n_d;
            }
            set
            {
                this._n_d = value;
            }
        }
        public string Airflow
        {
            get
            {
                return this._airflow;
            }
            set
            {
                this._airflow = value;
            }
        }
        public string 标志位
        {
            get
            {
                return this._标志位;
            }
            set
            {
                this._标志位 = value;
            }
        }
        public string 叶轮材料
        {
            get
            {
                return this._叶轮材料;
            }
            set
            {
                this._叶轮材料 = value;
            }
        }
        public string 图纸名称
        {
            get
            {
                return this._图纸名称;
            }
            set
            {
                this._图纸名称 = value;
            }
        }


        public string 风筒
        {
            get
            {
                return this._风筒;
            }
            set
            {
                this._风筒 = value;
            }
        }
        public string 防护网安装位置
        {
            get
            {
                return this._防护网安装位置;
            }
            set
            {
                this._防护网安装位置 = value;
            }
        }
        public string 出线方式
        {
            get
            {
                return this._出线方式;
            }
            set
            {
                this._出线方式 = value;
            }
        }
        public string 紧固件
        {
            get
            {
                return this._紧固件;
            }
            set
            {
                this._紧固件 = value;
            }
        }
        public string 防护网材料
        {
            get
            {
                return this._防护网材料;
            }
            set
            {
                this._防护网材料 = value;
            }
        }

    }
}