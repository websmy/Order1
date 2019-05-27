using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Order
{
    public class MeasureClass
    {

        private string _currentMeasure;
        private string _previousMeasure;
        private MeasureType _type;

        public bool ChangeCurrentMeasureType(string lb)
        {
            try
            {
                this.PreviousMeasure = this.CurrentMeasure;
                this.CurrentMeasure = lb;
                return true;
            }
            catch (Exception exception)
            {
                Alert.Show(exception.Message);
                return false;
            }
        }

        public double ChangeMeasure(double currentValue, string from, string to)
        {
            try
            {
                double siValue = GetSiValue(from);
                double num2 = GetSiValue(to);
                this.PreviousMeasure = this.CurrentMeasure;
                this.CurrentMeasure = to;
                return ((currentValue * num2) / siValue);
            }
            catch (Exception exception)
            {
                Alert.Show(exception.Message);
                return 0.0;
            }
        }

        public static double GetSiValue(string lb)
        {
            try
            {
                return GetSiValue(1.0, lb);
            }
            catch (Exception exception)
            {
                Alert.Show(exception.Message);
                return 1.0;
            }
        }

        public static double GetSiValue(double refInt, string lb)
        {
            try
            {
                switch (lb)
                {
                    case "m":
                        return (1.0 * refInt);

                    case "cm":
                        return (100.0 * refInt);

                    case "mm":
                        return (1000.0 * refInt);

                    case "ft":
                        return (3.2808399 * refInt);

                    case "in":
                        return (39.37007874 * refInt);

                    case "yd":
                        return (1.093613298 * refInt);

                    case "m/s":
                        return (1.0 * refInt);

                    case "m/min":
                        return (60.0 * refInt);

                    case "km/h":
                        return (3.6 * refInt);

                    case "ft/s":
                        return (3.2808333 * refInt);

                    case "ft/h":
                        return (11811.0 * refInt);

                    case "\x00b0C":
                        return (1.0 * refInt);

                    case "K":
                        return (273.15 + refInt);

                    case "\x00b0F":
                        return (32.0 + (1.8 * refInt));

                    case "rad/s":
                        return (1.0 * refInt);

                    case "rad/min":
                        return (60.0 * refInt);

                    case "rpm":
                        return (9.551098376 * refInt);

                    case "rps":
                        return (0.159159637 * refInt);

                    case "kg/m^3":
                        return (1.0 * refInt);

                    case "lb/ft^3":
                        return (0.06243 * refInt);

                    case "W":
                        return (1.0 * refInt);

                    case "kW":
                        return (0.001 * refInt);

                    case "hp":
                        return (0.00134 * refInt);

                    case "hk":
                        return (0.00136 * refInt);

                    case "Pa":
                        return (1.0 * refInt);

                    case "mm Hg":
                        return (0.007500638 * refInt);

                    case "mm H20":
                        return (0.101978381 * refInt);

                    case "kPa":
                        return (0.001 * refInt);

                    case "ft H2O":
                        return (0.000334575 * refInt);

                    case "bar":
                        return (1E-05 * refInt);

                    case "atm":
                        return (9.869E-06 * refInt);

                    case "m³/s":
                        return (1.0 * refInt);

                    case "m³/min":
                        return (60.0 * refInt);

                    case "m³/h":
                        return (3600.0 * refInt);

                    case "ft^3/s":
                        return (35.31466 * refInt);

                    case "CFM":
                        return (2118.8796 * refInt);

                    case "l/s":
                        return (1000.0 * refInt);

                    case "l/h":
                        return (3600000.0 * refInt);

                    case "gallon/min":
                        return (15789.47368 * refInt);

                    case "N":
                        return (1.0 * refInt);

                    case "lbf":
                        return (0.2248 * refInt);

                    case "kgf":
                        return (0.10197162 * refInt);

                    case "kg":
                        return (1.0 * refInt);

                    case "g":
                        return (1000.0 * refInt);

                    case "t":
                        return (0.001 * refInt);

                    case "Ib":
                        return (2.2046 * refInt);
                }
                return refInt;
            }
            catch (Exception exception)
            {
                Alert.Show(exception.Message);
                return refInt;
            }
        }

        public string CurrentMeasure
        {
            get
            {
                return this._currentMeasure;
            }
            set
            {
                this._currentMeasure = value;
            }
        }

        public MeasureType MType
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

        public string PreviousMeasure
        {
            get
            {
                return this._previousMeasure;
            }
            set
            {
                this._previousMeasure = value;
            }
        }

    }
}